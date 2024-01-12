local dxgui = require('dxgui')
local DialogLoader = require("DialogLoader")
local lfs = require("lfs")

local DTCUploadInProgress = {
    width = 300,
    height = 40,
    reloadPending = false,
    dialog = nil,
    visible = false
}

function DTCUploadInProgress:init(eventCallback)
    local screenWidth, screenHeight = dxgui.GetScreenSize()
    local x = (screenWidth / 2) + 400
    local y = (screenHeight / 2) - 400

    self.dialog = DialogLoader.spawnDialogFromFile(lfs.writedir() .. "Scripts\\DCSDTC\\uploadInProgress.dlg")
    self.dialog:setVisible(true)
    self.dialog:setPosition(math.floor(x), math.floor(y))

    self:hide()
end

function DTCUploadInProgress:hide()
    self.dialog:setHasCursor(false)
    self.dialog:setSize(0,0)
    self.visible = false
end

function DTCUploadInProgress:show(eventCallback)
    self.dialog:setHasCursor(true)
    self.dialog:setSize(self.width, self.height)
    self.visible = true
end

function DTCUploadInProgress:destroy()
    self.dialog:destroy()
end

return DTCUploadInProgress;