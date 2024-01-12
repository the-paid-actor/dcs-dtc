local dxgui = require('dxgui')
local DialogLoader = require("DialogLoader")
local lfs = require("lfs")

local DTCWptCapturePP = {
    width = 425,
    height = 170,
    dialog = nil,
    visible = false
}

function DTCWptCapturePP:init(eventCallback)
    local screenWidth, screenHeight = dxgui.GetScreenSize()
    local x = (screenWidth / 2) - 19
    local y = (screenHeight / 2) - 19

    self.dialog = DialogLoader.spawnDialogFromFile(lfs.writedir() .. "Scripts\\DCSDTC\\wptCapturePP.dlg")
    self.dialog:setVisible(true)
    self.dialog:setBounds(math.floor(x) - self.width - 20, math.floor(y), self.width, self.height)
    self.dialog.buttonSta2PP1:addMouseUpCallback(function() eventCallback:addPPCoordButton(2,1) end)
    self.dialog.buttonSta2PP2:addMouseUpCallback(function() eventCallback:addPPCoordButton(2,2) end)
    self.dialog.buttonSta2PP3:addMouseUpCallback(function() eventCallback:addPPCoordButton(2,3) end)
    self.dialog.buttonSta2PP4:addMouseUpCallback(function() eventCallback:addPPCoordButton(2,4) end)
    self.dialog.buttonSta2PP5:addMouseUpCallback(function() eventCallback:addPPCoordButton(2,5) end)
    self.dialog.buttonSta2PP6:addMouseUpCallback(function() eventCallback:addPPCoordButton(2,6) end)
    self.dialog.buttonSta3PP1:addMouseUpCallback(function() eventCallback:addPPCoordButton(3,1) end)
    self.dialog.buttonSta3PP2:addMouseUpCallback(function() eventCallback:addPPCoordButton(3,2) end)
    self.dialog.buttonSta3PP3:addMouseUpCallback(function() eventCallback:addPPCoordButton(3,3) end)
    self.dialog.buttonSta3PP4:addMouseUpCallback(function() eventCallback:addPPCoordButton(3,4) end)
    self.dialog.buttonSta3PP5:addMouseUpCallback(function() eventCallback:addPPCoordButton(3,5) end)
    self.dialog.buttonSta3PP6:addMouseUpCallback(function() eventCallback:addPPCoordButton(3,6) end)
    self.dialog.buttonSta7PP1:addMouseUpCallback(function() eventCallback:addPPCoordButton(7,1) end)
    self.dialog.buttonSta7PP2:addMouseUpCallback(function() eventCallback:addPPCoordButton(7,2) end)
    self.dialog.buttonSta7PP3:addMouseUpCallback(function() eventCallback:addPPCoordButton(7,3) end)
    self.dialog.buttonSta7PP4:addMouseUpCallback(function() eventCallback:addPPCoordButton(7,4) end)
    self.dialog.buttonSta7PP5:addMouseUpCallback(function() eventCallback:addPPCoordButton(7,5) end)
    self.dialog.buttonSta7PP6:addMouseUpCallback(function() eventCallback:addPPCoordButton(7,6) end)
    self.dialog.buttonSta8PP1:addMouseUpCallback(function() eventCallback:addPPCoordButton(8,1) end)
    self.dialog.buttonSta8PP2:addMouseUpCallback(function() eventCallback:addPPCoordButton(8,2) end)
    self.dialog.buttonSta8PP3:addMouseUpCallback(function() eventCallback:addPPCoordButton(8,3) end)
    self.dialog.buttonSta8PP4:addMouseUpCallback(function() eventCallback:addPPCoordButton(8,4) end)
    self.dialog.buttonSta8PP5:addMouseUpCallback(function() eventCallback:addPPCoordButton(8,5) end)
    self.dialog.buttonSta8PP6:addMouseUpCallback(function() eventCallback:addPPCoordButton(8,6) end)

    self:hide()
end

function DTCWptCapturePP:hide()
    self.dialog:setHasCursor(false)
    self.dialog:setSize(0,0)
    self.visible = false
end

function DTCWptCapturePP:show()
    self.dialog:setHasCursor(true)
    self.dialog:setSize(self.width, self.height)
    self.visible = true
end

function DTCWptCapturePP:destroy()
    self.dialog:destroy()
end

return DTCWptCapturePP;