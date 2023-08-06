package.path  = package.path..";.\\LuaSocket\\?.lua;"
package.cpath = package.cpath..";.\\LuaSocket\\?.dll;"
package.path = package.path .. ";.\\Scripts\\?.lua;.\\Scripts\\UI\\?.lua;"

local dxgui = require('dxgui')
local DialogLoader = require("DialogLoader")
local Terrain = require('terrain')
local lfs = require("lfs")
local socket = require("socket")

local DTCHook =
{
    logFile = io.open(lfs.writedir() .. [[Logs\DCSDTCHook.log]], "w"),
    inMission = false,
    visible = true,

    dialogWidth = 430,
    dialogHeight = 300,
    dialog = nil,

    addButton = nil,
    addAsTgtButton = nil,
    clearButton = nil,
    coordListBox = nil,
    coordLabel = nil,
    sendToDTCButton = nil,

    currentCoord = nil,
    coordList = {},

    udpSocket = nil,
    udpPort = 43002
}

function DTCHook:log(str)
    self.logFile:write(str .. "\n");
    self.logFile:flush();
end

function DTCHook:formatCoord(lat, lon, el)
    local originaLat = lat
    local originalLon = lon
    local latH = 'N'
    local lonH = 'E'

    if lat < 0 then
        latH = 'S'
        lat = -lat
    end

    if lon < 0 then
        lonH = 'W'
        lon = -lon
    end

    local latG = math.floor(lat)
    local latM = lat * 60 - latG * 60
    local lonG = math.floor(lon)
    local lonM = lon * 60 - lonG * 60

    local latitude = string.format("%s %02d°%06.3f’", latH, latG, latM)
    local longitude = string.format("%s %03d°%06.3f’", lonH, lonG, lonM)
    local elevation = string.format("%.0f", el*3.28084)

    return {
        string = latitude .. " " .. longitude .. " " .. elevation .. "ft",
        latitude = originaLat,
        longitude = originalLon,
        elevation = elevation,
        target = false
    }
end

function DTCHook:sendData(data)
    if self.udpSocket == nil then
        self.udpSocket = socket.udp()
        self.udpSocket:settimeout(0)
    end

    local status, err = self.udpSocket:sendto(data, "127.0.0.1", self.udpPort)
    if status ~= 1 then
        self:log("Error: " .. err)
    end
end

function DTCHook:updateCurrentCoord()
    local pos = Export.LoGetCameraPosition().p
    local alt = Terrain.GetSurfaceHeightWithSeabed(pos.x, pos.z)
    local lat, lon = Terrain.convertMetersToLatLon(pos.x, pos.z)
    local result = self:formatCoord(lat, lon, alt)
    self.currentCoord = result;
    self.coordLabel:setText(result.string)
end

function DTCHook:updateCoordListBox()
    local text = ""
    for k,v in pairs(self.coordList) do
        local type = "STP"
        if v.target then type = "TGT" end
        text = text .. type .. " " .. string.format("%02d", k) .. " " .. v.string .. "\n"
    end
    self.coordListBox:setText(text)
end

function DTCHook:addCoord(tgt)
    if self.currentCoord ~= nil then
        self.currentCoord.target = tgt
        table.insert(self.coordList, self.currentCoord)
        self:updateCoordListBox()
    end
end

function DTCHook:clearCoords()
    self.coordList = {}
    self:updateCoordListBox()
end

function DTCHook:sendToDTC()
    local str = "["
    for k,v in pairs(self.coordList) do
        local json = '{"latitude":"' .. v.latitude .. '", "longitude":"' .. v.longitude .. '", "elevation":"' .. v.elevation .. '", "target":"' .. tostring(v.target) .. '"}'
        str = str .. json .. ","
    end
    str = str .. "]"
    self:sendData(str)
end

function DTCHook:createDialog()
    if self.dialog then
        self.dialog:destroy()
    end

    local screenWidth, screenHeight = dxgui.GetScreenSize()
    local x = (screenWidth / 2) - 19
    local y = (screenHeight / 2) - 19

    self.dialog = DialogLoader.spawnDialogFromFile(lfs.writedir() .. "Scripts\\DCSDTC\\waypointCapture.dlg")
    self.dialog:setVisible(true)
    self.dialog:setBounds(math.floor(x), math.floor(y), self.dialogWidth, self.dialogHeight)
    self.dialog:addHotKeyCallback(
        "Ctrl+Shift+d",
        function()
            self:toggle()
        end
    )

    self.dialog:addHotKeyCallback(
        "Ctrl+Shift+s",
        function()
            self:createDialog()
        end
    )

    self.coordLabel = self.dialog.coordLabel
    self.coordListBox = self.dialog.coordListBox

    self.addButton = self.dialog.addButton
    self.addButton:addMouseUpCallback(
        function()
            self:addCoord(false)
        end
    )

    self.addAsTgtButton = self.dialog.addAsTgtButton
    self.addAsTgtButton:addMouseUpCallback(
        function()
            self:addCoord(true)
        end
    )

    self.clearButton = self.dialog.clearButton
    self.clearButton:addMouseUpCallback(
        function()
            self:clearCoords()
        end
    )

    self.sendToDTCButton = self.dialog.sendToDTCButton
    self.sendToDTCButton:addMouseUpCallback(
        function()
            self:sendToDTC()
        end
    )

    self:hide()
end

function DTCHook:toggle()
    if self.visible then
        self:hide()
    else
        self:show()
    end
end

function DTCHook:hide()
    self.dialog:setHasCursor(false)
    self.dialog:setSize(0,0)
    self.visible = false
end

function DTCHook:show()
    if self.inMission == false then
        return
    end
    self.dialog:setHasCursor(true)
    self.dialog:setSize(self.dialogWidth, self.dialogHeight)
    self.visible = true
end

local function initDTCHook()
    local handler = {}

    function handler.onSimulationFrame()
        if DTCHook.inMission and DTCHook.visible then
            DTCHook:updateCurrentCoord()
        end
    end

    function handler.onMissionLoadEnd()
        DTCHook:createDialog()
        DTCHook.inMission = true;
    end

    function handler.onSimulationStop()
        DTCHook:clearCoords()
        DTCHook:hide()
        DTCHook.inMission = false;
    end

    DCS.setUserCallbacks(handler)
end

local status, err = pcall(initDTCHook)
if not status then
    DTCHook:log("Error: " .. err)
end
