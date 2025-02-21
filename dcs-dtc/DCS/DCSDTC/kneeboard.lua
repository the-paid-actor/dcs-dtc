local dxgui = require('dxgui')
local DialogLoader = require("DialogLoader")
local lfs = require("lfs")
local Input = require("Input")

local TextBoxMode_Info = 1
local TextBoxMode_Notes = 2

local Theme_Light = 1
local Theme_Dark = 2
local Theme_Auto = 3

local DTCKneeboard = {
    width = 660,
    height = 1000,
    dialog = nil,
    visible = false,

    notesLightSkin = nil,
    notesDarkSkin = nil,
    infoLightSkin = nil,
    infoDarkSkin = nil,

    infoText = "",
    notesText = "",
    presetName = "",

    textboxMode = TextBoxMode_Info,
    theme = Theme_Light,

    keyboardLocked = false,
    callback = nil,
}

function DTCKneeboard:init(eventCallback)
    self.callback = eventCallback

    dxgui.AddMouseCallback("down", function(x, y)
        if self.visible then
            local winX, winY, winW, winH = self.dialog:getBounds()
            if x < winX or x > (winX + winW) or y < winY or y > (winY + winH) then
                self:unlockKeyboardInput()
            end
        end
    end)

    self:initDialog(eventCallback)
end

function DTCKneeboard:initDialog(eventCallback)
    local screenWidth, screenHeight = dxgui.GetScreenSize()
    local x = screenWidth - self.width - 50
    local y = (screenHeight / 2) - self.height / 2

    self.dialog = DialogLoader.spawnDialogFromFile(lfs.writedir() .. "Scripts\\DCSDTC\\kneeboard.dlg")
    self.dialog:setVisible(true)
    self.dialog:setBounds(math.floor(x), math.floor(y), self.width, self.height)
    self.dialog:addHotKeyCallback("Ctrl+Shift+k", function() self:showHide() end)

    self.notesLightSkin = eventCallback:getSkin("kneeboardNotesLightSkin");
    self.notesDarkSkin = eventCallback:getSkin("kneeboardNotesDarkSkin");
    self.infoLightSkin = eventCallback:getSkin("kneeboardInfoLightSkin");
    self.infoDarkSkin = eventCallback:getSkin("kneeboardInfoDarkSkin");

    self.dialog.btnInfo:addMouseUpCallback(function() self:switchToInfo() end)
    self.dialog.btnNotes:addMouseUpCallback(function() self:switchToNotes() end)
    self.dialog.btnClose:addMouseUpCallback(function() self:hide() end)

    self.dialog.btnLight:addMouseUpCallback(function() self:switchToLight() end)
    self.dialog.btnDark:addMouseUpCallback(function() self:switchToDark() end)
    self.dialog.btnAuto:addMouseUpCallback(function() self:switchToAuto() end)

    self.dialog.textbox:addFocusCallback(function() self:textboxFocused() end)
    self.dialog.textbox:addKeyDownCallback(function(txt, key) self:textboxKeyPressed(key) end)
    self.dialog.textbox:addChangeCallback(function() self:updateNotes() end)

    self:switchToAuto()
    self:switchToInfo()
    self:hide()
end

function DTCKneeboard:updateNotes()
    if self.textboxMode == TextBoxMode_Notes then
        local notes = self.dialog.textbox:getText()
        if notes ~= self.notesText then
            self.notesText = notes
            self.callback:updateKneeboardNotes(self.presetName, notes)
        end
    end
end

function DTCKneeboard:unlockKeyboardInput()
    if self.keyboardLocked then
        self.dialog.textbox:setFocused(false)
        DCS.unlockKeyboardInput(true)
        self.keyboardLocked = false
        if self.textboxMode == TextBoxMode_Notes then
            self:updateNotes()
        end
    end
end

function DTCKneeboard:lockKeyboardInput()
    if self.keyboardLocked then
        return
    end

    local keyboardEvents = Input.getDeviceKeys(Input.getKeyboardDeviceName())
    local inputActions = Input.getEnvTable().Actions

    local removeCommandEvents = function(commandEvents)
        for i, commandEvent in ipairs(commandEvents) do
            for j = #keyboardEvents, 1, -1 do
                if keyboardEvents[j] == commandEvent then
                    table.remove(keyboardEvents, j)
                    break
                end
            end
        end 
    end

    removeCommandEvents(Input.getUiLayerCommandKeyboardKeys(inputActions.iCommandChat))
    removeCommandEvents(Input.getUiLayerCommandKeyboardKeys(inputActions.iCommandAllChat))
    removeCommandEvents(Input.getUiLayerCommandKeyboardKeys(inputActions.iCommandFriendlyChat))
    removeCommandEvents(Input.getUiLayerCommandKeyboardKeys(inputActions.iCommandChatShowHide))

    DCS.lockKeyboardInput(keyboardEvents)
    self.keyboardLocked = true
end

function DTCKneeboard:textboxFocused()
    if self.dialog.textbox:getFocused() then
        self:lockKeyboardInput()
    else
        self:unlockKeyboardInput()
    end
end

function DTCKneeboard:textboxKeyPressed(key)
    if key == "escape" then
        self:unlockKeyboardInput()
    end
end

function DTCKneeboard:switchToInfo()
    self:unlockKeyboardInput()
    self.textboxMode = TextBoxMode_Info
    self.dialog.textbox:setText("")
    self.dialog.textbox:setReadOnly(true)
    self:updateUITheme()

    self.dialog.btnInfo:setText("* Info")
    self.dialog.btnNotes:setText("Notes")

    self.dialog.textbox:setText(self.infoText)
end

function DTCKneeboard:switchToNotes()
    self:unlockKeyboardInput()
    self.textboxMode = TextBoxMode_Notes
    self.dialog.textbox:setText("")
    self.dialog.textbox:setReadOnly(false)
    self:updateUITheme()

    self.dialog.btnInfo:setText("Info")
    self.dialog.btnNotes:setText("* Notes")

    self.dialog.textbox:setText(self.notesText)
end

function DTCKneeboard:updateUITheme()
    local theme = self:getCurrentTheme()
    if self.textboxMode == TextBoxMode_Info then
        if theme == Theme_Light then
            self.dialog.textbox:setSkin(self.infoLightSkin)
        elseif theme == Theme_Dark then
            self.dialog.textbox:setSkin(self.infoDarkSkin)
        end
    elseif self.textboxMode == TextBoxMode_Notes then
        if theme == Theme_Light then
            self.dialog.textbox:setSkin(self.notesLightSkin)
        elseif theme == Theme_Dark then
            self.dialog.textbox:setSkin(self.notesDarkSkin)
        end
    end
end

function DTCKneeboard:getCurrentTheme()
    if self.theme ~= Theme_Auto then
        return self.theme
    else
        local time = Export.LoGetMissionStartTime() + Export.LoGetModelTime()
        if time > 72000 or time < 28800 then
            return Theme_Dark
        else
            return Theme_Light
        end
    end
end

function DTCKneeboard:switchToLight()
    self.theme = Theme_Light
    self.dialog.btnLight:setText("* Light")
    self.dialog.btnDark:setText("Dark")
    self.dialog.btnAuto:setText("Auto")
    self:updateUITheme()
end

function DTCKneeboard:switchToDark()
    self.theme = Theme_Dark
    self.dialog.btnLight:setText("Light")
    self.dialog.btnDark:setText("* Dark")
    self.dialog.btnAuto:setText("Auto")
    self:updateUITheme()
end

function DTCKneeboard:switchToAuto()
    self.theme = Theme_Auto
    self.dialog.btnLight:setText("Light")
    self.dialog.btnDark:setText("Dark")
    self.dialog.btnAuto:setText("* Auto")
    self:updateUITheme()
end

function DTCKneeboard:setPresetName(name)
    self.presetName = name
    self.dialog.lblPresetName:setText(name)
end

function DTCKneeboard:setInfoText(text)
    self.infoText = text
    self:switchToInfo()
end

function DTCKneeboard:setNotesText(text)
    self.notesText = text
end 

function DTCKneeboard:showHide()
    if self.visible then
        self:hide()
    else
        self:show()
    end
end

function DTCKneeboard:hide()
    self.dialog:setHasCursor(false)
    self.dialog:setSize(0,0)
    self.visible = false
end

function DTCKneeboard:show()
    if self.dialog == nil then
        self:initDialog()
    end
    self.dialog:setHasCursor(true)
    self.dialog:setSize(self.width, self.height)
    self.visible = true
end

function DTCKneeboard:destroy()
    self.visible = false
    self.dialog:destroy()
end

return DTCKneeboard;