local dxgui = require('dxgui')
local DialogLoader = require("DialogLoader")
local lfs = require("lfs")

local DTCWptCapture = {
    width = 450,
    height = 350,
    reloadPending = false,
    dialog = nil,
    visible = false
}

function DTCWptCapture:init(eventCallback)
    local screenWidth, screenHeight = dxgui.GetScreenSize()
    local x = (screenWidth / 2) - 19
    local y = (screenHeight / 2) - 19

    self.dialog = DialogLoader.spawnDialogFromFile(lfs.writedir() .. "Scripts\\DCSDTC\\wptCapture.dlg")
    self.dialog:setVisible(true)
    self.dialog:setBounds(math.floor(x), math.floor(y), self.width, self.height)

    self.dialog:addHotKeyCallback("Ctrl+Shift+d", function() eventCallback:showHideCapture() end)
    self.dialog.addButton:addMouseUpCallback(function() eventCallback:addButton() end)
    self.dialog.addButtonA:addMouseUpCallback(function() eventCallback:addButtonF15E('A') end)
    self.dialog.addButtonB:addMouseUpCallback(function() eventCallback:addButtonF15E('B') end)
    self.dialog.addButtonC:addMouseUpCallback(function() eventCallback:addButtonF15E('C') end)

    self.dialog.addAsTgtButton:addMouseUpCallback(function() eventCallback:addTGTButton() end)
    self.dialog.addAsTgtButtonA:addMouseUpCallback(function() eventCallback:addTGTButtonF15E('A') end)
    self.dialog.addAsTgtButtonB:addMouseUpCallback(function() eventCallback:addTGTButtonF15E('B') end)
    self.dialog.addAsTgtButtonC:addMouseUpCallback(function() eventCallback:addTGTButtonF15E('C') end)

    self.dialog.addPPButton:addMouseUpCallback(function() eventCallback:addPPButton() end)
    self.dialog.addSmartButton:addMouseUpCallback(function() eventCallback:addSmartButton() end)
    self.dialog.clearButton:addMouseUpCallback(function() eventCallback:clearButton() end)
    self.dialog.sendToDTCButton:addMouseUpCallback(function() eventCallback:sendToDTCButton() end)
    self.dialog.sendToJetButton:addMouseUpCallback(function() eventCallback:sendToJetButton() end)
    self.dialog.resetAllSmart:addMouseUpCallback(function() eventCallback:resetAllSmart() end)
    self.dialog.resetAllPP:addMouseUpCallback(function() eventCallback:resetAllPP() end)

    self.dialog.addButtonApache:addMouseUpCallback(function() eventCallback:addButtonApache() end)

    self.dialog:addHotKeyCallback("Ctrl+Shift+s", function() self.reloadPending = true end)

    self:hide()
end

function DTCWptCapture:hide()
    self.dialog:setHasCursor(false)
    self.dialog:setSize(0,0)
    self.visible = false
end

function DTCWptCapture:show(eventCallback)
    self.dialog:setHasCursor(true)
    self.dialog:setSize(self.width, self.height)
    self.visible = true

    local isViper = eventCallback:getAircraftType() == "F16C"
    local isHornet = eventCallback:getAircraftType() == "FA18C"
    local isMudhen = eventCallback:getAircraftType() == "F15E"
    local isApache = eventCallback:getAircraftType() == "AH64D"
    local isC130 = eventCallback:getAircraftType() == "C130"
    local isA10 = eventCallback:getAircraftType() == "A10"
    local isCH47F = eventCallback:getAircraftType() == "CH47F"
    local isAV8B = eventCallback:getAircraftType() == "AV8B"
    local inPlane = (isViper or isHornet or isMudhen or isApache or isC130 or isA10 or isCH47F or isAV8B)

    self.dialog.addButton:setVisible(isMudhen == false)
    self.dialog.addAsTgtButton:setVisible(isViper or isHornet or isApache)

    self.dialog.addPPButton:setVisible(isHornet)
    self.dialog.resetAllPP:setVisible(isHornet)

    self.dialog.addButtonA:setVisible(isMudhen)
    self.dialog.addButtonB:setVisible(isMudhen)
    self.dialog.addButtonC:setVisible(isMudhen)
    self.dialog.addAsTgtButtonA:setVisible(isMudhen)
    self.dialog.addAsTgtButtonB:setVisible(isMudhen)
    self.dialog.addAsTgtButtonC:setVisible(isMudhen)
    self.dialog.addSmartButton:setVisible(isMudhen)
    self.dialog.resetAllSmart:setVisible(isMudhen)

    self.dialog.addButtonApache:setVisible(isApache)
    self.dialog.sendToJetButton:setVisible(inPlane and isApache == false)

    if isViper then
        self.dialog.clearButton:setPosition(228, 20)
    else
        self.dialog.clearButton:setPosition(318, 20)
    end

    if not isMudhen then
        self.dialog.coordListBox:setBounds(50, 52, 400, 250)
    else
        self.dialog.coordListBox:setBounds(50, 112, 400, 190)
    end
end

function DTCWptCapture:setCoordLabel(str)
    self.dialog.coordLabel:setText(str)
end

function DTCWptCapture:setCoordListBox(str)
    self.dialog.coordListBox:setText(str)
end

function DTCWptCapture:destroy()
    self.dialog:destroy()
end

return DTCWptCapture;