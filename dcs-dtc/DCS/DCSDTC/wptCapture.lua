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

    self.dialog:addHotKeyCallback("Ctrl+Shift+d", function() eventCallback:showHide() end)
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

    --self.dialog.sendToJetButton:addMouseUpCallback(function() eventCallback:testButton() end)
    --self.dialog:addHotKeyCallback("Ctrl+Shift+s", function() self.reloadPending = true end)

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

    local isHornet = eventCallback:getAircraftType() == "FA18C"
    local isMudhen = eventCallback:getAircraftType() == "F15E"

    self.dialog.addPPButton:setVisible(isHornet)
    self.dialog.resetAllPP:setVisible(isHornet)

    self.dialog.addButton:setVisible(not isMudhen)
    self.dialog.addAsTgtButton:setVisible(not isMudhen)   
    self.dialog.addButtonA:setVisible(isMudhen)
    self.dialog.addButtonB:setVisible(isMudhen)
    self.dialog.addButtonC:setVisible(isMudhen)
    self.dialog.addAsTgtButtonA:setVisible(isMudhen)
    self.dialog.addAsTgtButtonB:setVisible(isMudhen)
    self.dialog.addAsTgtButtonC:setVisible(isMudhen)
    self.dialog.addSmartButton:setVisible(isMudhen)
    self.dialog.resetAllSmart:setVisible(isMudhen)

    if not isHornet and not isMudhen then
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