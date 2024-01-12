local dxgui = require('dxgui')
local DialogLoader = require("DialogLoader")
local lfs = require("lfs")

local DTCWptCaptureF15E = {
    width = 340,
    height = 170,
    dialog = nil,
    visible = false
}

function DTCWptCaptureF15E:init(eventCallback)
    local screenWidth, screenHeight = dxgui.GetScreenSize()
    local x = (screenWidth / 2) - 19
    local y = (screenHeight / 2) - 19

    self.dialog = DialogLoader.spawnDialogFromFile(lfs.writedir() .. "Scripts\\DCSDTC\\wptCaptureF15E.dlg")

    self.dialog:setVisible(true)
    self.dialog:setBounds(math.floor(x) - self.width - 20, math.floor(y), self.width, self.height)
    self.dialog.buttonLCFTFront:addMouseUpCallback(function() eventCallback:addSmartCoordButton("LCFT F") end)
    self.dialog.buttonRCFTFront:addMouseUpCallback(function() eventCallback:addSmartCoordButton("RCFT F") end)
    self.dialog.buttonLWing:addMouseUpCallback(function() eventCallback:addSmartCoordButton("L WING") end)
    self.dialog.buttonCenter:addMouseUpCallback(function() eventCallback:addSmartCoordButton("CENTER") end)
    self.dialog.buttonRWing:addMouseUpCallback(function() eventCallback:addSmartCoordButton("R WING") end)
    self.dialog.buttonLCFTMiddle:addMouseUpCallback(function() eventCallback:addSmartCoordButton("LCFT M") end)
    self.dialog.buttonRCFTMiddle:addMouseUpCallback(function() eventCallback:addSmartCoordButton("RCFT M") end)
    self.dialog.buttonLCFTBack:addMouseUpCallback(function() eventCallback:addSmartCoordButton("LCFT R") end)
    self.dialog.buttonRCFTBack:addMouseUpCallback(function() eventCallback:addSmartCoordButton("RCFT R") end)

    self:hide()
end

function DTCWptCaptureF15E:hide()
    self.dialog:setHasCursor(false)
    self.dialog:setSize(0,0)
    self.visible = false
end

function DTCWptCaptureF15E:show()
    self.dialog:setHasCursor(true)
    self.dialog:setSize(self.width, self.height)
    self.visible = true
end

function DTCWptCaptureF15E:destroy()
    self.dialog:destroy()
end

return DTCWptCaptureF15E;