--package.path  = package.path..";.\\LuaSocket\\?.lua;"
--package.cpath = package.cpath..";.\\LuaSocket\\?.dll;"
--package.path = package.path .. ";.\\Scripts\\?.lua;.\\Scripts\\UI\\?.lua;"

local Terrain = require('terrain')
local lfs = require("lfs")
local socket = require("socket")

function DTCLoadFile(path)
    local f, err = loadfile(lfs.writedir() .. path)
    if err then
        log.write("DCS-DTC", log.ERROR, err)
    end
    return f()
end

local DTCCaptureDialog = dofile(lfs.writedir() .. 'Scripts/DCSDTC/wptCapture.lua')
local DTCCapturePP = dofile(lfs.writedir() .. 'Scripts/DCSDTC/wptCapturePP.lua')
local DTCCaptureF15E = DTCLoadFile('Scripts/DCSDTC/wptCaptureF15E.lua')
local DTCCaptureAH64D = DTCLoadFile('Scripts/DCSDTC/wptCaptureAH64D.lua')
local DTCUploadInProgressDlg = DTCLoadFile('Scripts/DCSDTC/uploadInProgress.lua')
local DTCKneeboard = DTCLoadFile('Scripts/DCSDTC/kneeboard.lua')

local DTCHook =
{
    logFile = nil,
    inMission = false,

    currentCoord = nil,
    coordList = {},
    coordListCount = 0,

    udpSocketSend = nil,
    udpPortDTCApp = 43002,

    udpSocketReceive = nil,
    udpReceivePort = 43001,

    captureDialog = nil,
    capturePPDialog = nil,
    captureF15EDialog = nil,
    captureAH64DDialog = nil,
    uploadInProgressDialog = nil,
    kneeboardDialog = nil,

    currentAircraft = null
}

-- #########
-- FUNCTIONS
-- #########

function DTCHook:log(str)
    self.logFile:write(str .. "\n");
    self.logFile:flush();
end

function DTCHook:addCoord(tgt, extra)
    if self.currentCoord ~= nil then
        self.currentCoord.target = tgt
        self.currentCoord.extra = extra
        self.currentCoord.sequence = self.coordListCount + 1
        self.coordListCount = self.coordListCount + 1
        table.insert(self.coordList, self.currentCoord)
        self:updateCoordListBox()
        self:updateCurrentCoord()
    end
end

function DTCHook:addPPCoord(station, pp)
    if self.currentCoord ~= nil then
        self.currentCoord.pp = true
        self.currentCoord.ppStation = station
        self.currentCoord.ppNumber = pp

        for k,v in pairs(self.coordList) do
            if v.ppStation == station and v.ppNumber == pp then
                self.coordList[k] = self.currentCoord
                self:updateCoordListBox()
                self:updateCurrentCoord()
                return
            end
        end

        table.insert(self.coordList, self.currentCoord)
        self:updateCoordListBox()
        self:updateCurrentCoord()
    end
end

function DTCHook:resetAllPP()
    local str = '{"resetAllPP":"true"}'
    self:sendData(str)
end

function DTCHook:addSmartCoord(station)
    if self.currentCoord ~= nil then
        self.currentCoord.smart = true
        self.currentCoord.smartStation = station

        for k,v in pairs(self.coordList) do
            if v.smartStation == station then
                self.coordList[k] = self.currentCoord
                self:updateCoordListBox()
                self:updateCurrentCoord()
                return
            end
        end

        table.insert(self.coordList, self.currentCoord)
        self:updateCoordListBox()
        self:updateCurrentCoord()
    end
end

function DTCHook:addApacheCoord(pointType, identifier, free)
    self:addCoord(false, {pointType = pointType, identifier = identifier, free = free})
end

function DTCHook:resetAllSmart()
    local str = '{"resetAllSmart":"true"}'
    self:sendData(str)
end

function DTCHook:updateCurrentCoord()
    local pos = Export.LoGetCameraPosition().p
    local alt = Terrain.GetSurfaceHeightWithSeabed(pos.x, pos.z)
    local lat, lon = Terrain.convertMetersToLatLon(pos.x, pos.z)
    local result = self:formatCoord(lat, lon, alt)
    self.currentCoord = result;
    self.captureDialog:setCoordLabel(result.string)
end

function DTCHook:clearCoords()
    self.coordList = {}
    self.coordListCount = 0
    self:updateCoordListBox()
end

function DTCHook:updateCoordListBox()
    if self:isApache() then
        self:updateCoordListBoxApache()
        return
    end

    local text = ""
    for k,v in pairs(self.coordList) do
        local route = ""
        if v.extra and v.extra.route then route = v.extra.route end
        local type = "STP " .. route
        local sequence = ""
        if v.sequence then sequence = string.format("%02d", v.sequence) .. "  " end
        if v.target then type = "TGT " .. route end
        if v.pp then type = "STA" .. v.ppStation .. " PP" .. v.ppNumber end
        if v.smart then type = v.smartStation .. "   " end
        text = text .. type .. " " .. sequence .. v.string .. "\n"
    end
    self.captureDialog:setCoordListBox(text)
end

function DTCHook:updateCoordListBoxApache()
    local text = ""
    for k,v in pairs(self.coordList) do
        local type = "WP"
        if v.extra and v.extra.pointType then
            type = v.extra.pointType
        elseif v.target then
            type = "TG"
        end

        local identifier = "WP"
        if v.extra and v.extra.identifier then
            identifier = v.extra.identifier
        elseif v.target then
            identifier = "TG"
        end

        local free = "   "
        if v.extra and v.extra.free then
            free = v.extra.free
        end

        local sequence = ""
        if v.sequence then sequence = string.format("%02d", v.sequence) .. "  " end

        text = text .. type .. " " .. identifier .. " " .. free .. " " .. sequence .. v.string .. "\n"
    end
    self.captureDialog:setCoordListBox(text)
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

function DTCHook:updateKneeboardNotes(presetName, data)
    self:sendData("preset_name:"..presetName.."|kneeboard_notes:" .. data)
end

function DTCHook:sendData(data)
    if self.udpSocketSend == nil then
        self.udpSocketSend = socket.udp()
        self.udpSocketSend:settimeout(0)
    end

    local status, err = self.udpSocketSend:sendto(data, "127.0.0.1", self.udpPortDTCApp)
    if err ~= nil then
        self:log("Error: " .. err)
    end
end

function DTCHook:receiveData()
    if self.udpSocketReceive == nil then
        self.udpSocketReceive = socket.udp()
        local result, err = self.udpSocketReceive:setsockname("127.0.0.1", self.udpReceivePort)
        if result ~= 1 then
            self:log("Error 1: " .. err)
        end
        self.udpSocketReceive:settimeout(0)
    end
    local data, err2 = self.udpSocketReceive:receive(8192)
    if err2 ~= nil and err2 ~= "timeout" then
        self:log("Error 2: " .. err)
    end
    if data ~= nil then
        if data == "showuploadinprogress" then
            self:showUploadInProgress()
        elseif data == "hideuploadinprogress" then
            self:hideUploadInProgress()
        else
            local kbpresetname = "preset_name:"
            local kbinfoprefix = "kneeboard_info:"
            local kbnotesprefix = "kneeboard_notes:"
            if string.sub(data, 1, string.len(kbpresetname)) == kbpresetname then
                self.kneeboardDialog:setPresetName(string.sub(data, string.len(kbpresetname)+1))
            elseif string.sub(data, 1, string.len(kbinfoprefix)) == kbinfoprefix then
                self.kneeboardDialog:setInfoText(string.sub(data, string.len(kbinfoprefix)+1))
            elseif string.sub(data, 1, string.len(kbnotesprefix)) == kbnotesprefix then
                self.kneeboardDialog:setNotesText(string.sub(data, string.len(kbnotesprefix)+1))
            end
        end
    end
end

function DTCHook:sendToDTC(upload)
    local str= '{"upload":"'..tostring(upload)..'","data":['
    for k,v in pairs(self.coordList) do
        local json = '{'..
            '"latitude":"'..v.latitude..'"'..
            ',"longitude":"'..v.longitude..'"'..
            ',"elevation":"'..v.elevation..'"'..
            ',"target":"'..tostring(v.target)..'"'

        if v.extra and v.extra.route then
            json = json..
                ',"route":"'..v.extra.route..'"'
        end

        if v.extra and v.extra.pointType then
            json = json..
                ',"pointType":"'..v.extra.pointType..'"'
        end

        if v.extra and v.extra.identifier then
            json = json..
                ',"identifier":"'..v.extra.identifier..'"'
        end

        if v.extra and v.extra.free then
            json = json..
                ',"free":"'..v.extra.free..'"'
        end

        if v.pp then
            json = json..
                ',"pp":"'..tostring(v.pp)..'"'..
                ',"ppStation":'..tostring(v.ppStation)..
                ',"ppNumber":'..tostring(v.ppNumber)
        end

        if v.smart then
            json = json..
                ',"smart":"'..tostring(v.smart)..'"'..
                ',"smartStation":"'..tostring(v.smartStation)..'"'
        end

        json = json .. '}'
        str = str .. json .. ","
    end
    str = str .. "]}"
    self:sendData(str)
end

function DTCHook:isApache()
    return self:getAircraftType() == "AH64D"
end

-- ######
-- DIALOG
-- ######

function DTCHook:getSkin(skin)
    return DTCLoadFile('Scripts/DCSDTC/Skins/'..skin..'.lua')
end

function DTCHook:createDialogs()
    self.captureDialog = DTCCaptureDialog
    self.captureDialog:init(self)

    self.capturePPDialog = DTCCapturePP
    self.capturePPDialog:init(self)

    self.captureF15EDialog = DTCCaptureF15E
    self.captureF15EDialog:init(self)

    self.captureAH64DDialog = DTCCaptureAH64D
    self.captureAH64DDialog:init(self)

    self.kneeboardDialog = DTCKneeboard
    self.kneeboardDialog:init(self)

    self.uploadInProgressDialog = DTCUploadInProgressDlg
    self.uploadInProgressDialog:init(self)
end

function DTCHook:destroyDialogs()
    if self.captureDialog then
        self.captureDialog:destroy()
        self.captureDialog = nil
    end
    if self.capturePPDialog then
        self.capturePPDialog:destroy()
        self.capturePPDialog = nil
    end
    if self.captureF15EDialog then
        self.captureF15EDialog:destroy()
        self.captureF15EDialog = nil
    end
    if self.captureAH64DDialog then
        self.captureAH64DDialog:destroy()
        self.captureAH64DDialog = nil
    end
    if self.kneeboardDialog then
        self.kneeboardDialog:destroy()
        self.kneeboardDialog = nil
    end
    if self.uploadInProgressDialog then
        self.uploadInProgressDialog:destroy()
        self.uploadInProgressDialog = nil
    end
end

function DTCHook:showHideCapture()
    if self.uploadInProgressDialog.visible then
        return
    end
    if self.captureDialog.visible then
        self:hideCapture()
    else
        if self.inMission == false then
            return
        end
        self.captureDialog:show(self)
    end
end

function DTCHook:hideCapture()
    self.captureDialog:hide()

    if not self.captureDialog.visible then
        self.capturePPDialog:hide()
        self.captureF15EDialog:hide()
        self.captureAH64DDialog:hide()
    end
end

function DTCHook:showKneeboard()
    self.kneeboardDialog:show()
end

function DTCHook:hideKneeboard()
    self.kneeboardDialog:hide()
end

function DTCHook:addButton()
    self:addCoord(false)
end

function DTCHook:addTGTButton()
    self:addCoord(true)
end

function DTCHook:clearButton()
    self:clearCoords()
end

function DTCHook:sendToDTCButton()
    self:sendToDTC(false)
end

function DTCHook:sendToJetButton()
    self:sendToDTC(true)
end

function DTCHook:addPPButton()
    if self.capturePPDialog.visible then
        self.capturePPDialog:hide()
    else
        self.capturePPDialog:show()
    end
end

function DTCHook:addSmartButton()
    if self.captureF15EDialog.visible then
        self.captureF15EDialog:hide()
    else
        self.captureF15EDialog:show()
    end
end

function DTCHook:addPPCoordButton(station, pp)
    self:addPPCoord(station, pp)
end

function DTCHook:addSmartCoordButton(station)
    self:addSmartCoord(station)
end

function DTCHook:addButtonF15E(route)
    self:addCoord(false, {route = route})
end

function DTCHook:addTGTButtonF15E(route)
    self:addCoord(true, {route = route})
end

function DTCHook:addButtonApache()
    if self.captureAH64DDialog.visible then
        self.captureAH64DDialog:hide()
    else
        self.captureAH64DDialog:show()
    end
end

function DTCHook:getAircraftType()
    local ac = Export.LoGetSelfData()
    if ac then
        local acName = ac["Name"]
        if acName == "F-16C_50" then return "F16C" end
        if acName == "FA-18C_hornet" then return "FA18C" end
        if acName == "F-15ESE" then return "F15E" end
        if acName == "AH-64D_BLK_II" then return "AH64D" end
        if acName == "C-130J-30" then return "C130" end
        if acName == "A-10C_2" then return "A10" end
        if acName == "CH-47Fbl1" then return "CH47F" end
        if acName == "AV8BNA" then return "AV8B" end
    end
    return ""
end

function DTCHook:checkAircraftTypeChanged()
    local acType = self:getAircraftType()
    if self.currentAircraft == nil then
        self.currentAircraft = acType
    end

    if self.currentAircraft ~= acType then
        self.currentAircraft = acType
        if self.captureDialog ~= nil then
            self:hideCapture()
        end
        if self.kneeboardDialog ~= nil then
            self:hideKneeboard()
        end
    end
end

-- #############
-- DCS CALLBACKS
-- #############

function DTCHook:showUploadInProgress()
    self.captureDialog:hide()
    self.capturePPDialog:hide()
    self.captureF15EDialog:hide()
    self.captureAH64DDialog:hide()
    self.uploadInProgressDialog:show()
end

function DTCHook:hideUploadInProgress()
    self.uploadInProgressDialog:hide()
end

function DTCHook:onMissionLoadEnd()
    self:createDialogs()
    self.inMission = true;
end

function DTCHook:onSimulationFrame()
    if self.inMission then
        self:checkAircraftTypeChanged()
        if self.captureDialog.visible then
            self:updateCurrentCoord()
        end
        self:receiveData()
    end
end

function DTCHook:onSimulationStop()
    self:clearCoords()
    self.captureDialog:hide()
    self.capturePPDialog:hide()
    self.captureF15EDialog:hide()
    self.captureAH64DDialog:hide()
    self.uploadInProgressDialog:hide()
    self.kneeboardDialog:hide()
    self.inMission = false;
end

function DTCHook:needReload()
    if self.captureDialog then
        return self.captureDialog.reloadPending
    end
    return false
end

function DTCHook:dispose()
    self:destroyDialogs()

    if self.udpSocketSend then
        self.udpSocketSend:close()
        self.udpSocketSend = nil
    end
    if self.udpSocketReceive then
        self.udpSocketReceive:close()
        self.udpSocketReceive = nil
    end
    self.reloadPending = false
end

return DTCHook;