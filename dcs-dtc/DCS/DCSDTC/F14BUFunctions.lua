dofile(lfs.writedir() .. 'Scripts/DCSDTC/commonFunctions.lua')

DTC_F14BU_LSKCodes = {
    LSK1 = nil,
    LSK15 = nil,
    LSK2 = nil,
    LSK3 = nil,
    LSK4 = nil
}

local F14_DEVICE_ID = 81
local F14_DISPLAY_ID = 28
local F14_PRESS_TIME = 150
local F14_DEFAULT_DELAY = 150
local F14_MAX_PAGE_ATTEMPTS = 50

local F14_COMMANDS = {
    UP = 3045,
    DOWN = 3046,
    RIGHT = 3048,
    FPLN = 3056,
    LSK1 = 3060,
    LSK2 = 3061,
    LSK3 = 3062,
    LSK4 = 3063
}

local function F14_Exec(command, postDelay)
    local cmd = type(command) == "number" and command or F14_COMMANDS[command]
    if cmd == nil then
        return false
    end

    DTC_ExecCommand(F14_DEVICE_ID, cmd, F14_PRESS_TIME, 1, postDelay or F14_DEFAULT_DELAY)
    return true
end

local function F14_ParseDisplay()
    return DTC_ParseDisplay(F14_DISPLAY_ID)
end

local function F14_DisplayContains(display, code, text)
    local value = code ~= nil and display[code] or nil
    return value ~= nil and string.find(value, text, 1, true) ~= nil
end

local function F14_strToCmd(str)
    str = string.upper(tostring(str or ""))

    for i = 1, #str do
        local char = string.sub(str, i, i)
        local cmd = nil
        local digit = tonumber(char)

        if digit ~= nil then
            cmd = 3001 + digit
        elseif char >= "A" and char <= "Z" then
            cmd = 3011 + string.byte(char) - string.byte("A")
        elseif char == "." then
            cmd = 3049
        elseif char == "/" then
            cmd = 3051
        end

        if cmd ~= nil then
            local postDelay = 0
            if i < #str and string.sub(str, i + 1, i + 1) == char then
                postDelay = 100
            end

            F14_Exec(cmd, postDelay)
        end
    end
end

DTC_F14BU_ExecCmd_strToCmd = F14_strToCmd

function DTC_F14BU_ExecCmd_FindLSKCodes()
    local display = F14_ParseDisplay()

    DTC_F14BU_LSKCodes.LSK1 = nil
    DTC_F14BU_LSKCodes.LSK15 = nil
    DTC_F14BU_LSKCodes.LSK2 = nil
    DTC_F14BU_LSKCodes.LSK3 = nil
    DTC_F14BU_LSKCodes.LSK4 = nil

    for code, value in pairs(display) do
        if string.find(value, "START", 1, true) then
            DTC_F14BU_LSKCodes.LSK1 = code
        elseif string.find(value, "ZEROISE", 1, true) then
            DTC_F14BU_LSKCodes.LSK2 = code
        elseif string.find(value, "TIME", 1, true) then
            DTC_F14BU_LSKCodes.LSK3 = code
        elseif string.find(value, "INTERCEPT", 1, true) then
            DTC_F14BU_LSKCodes.LSK4 = code
        elseif string.find(value, "Index", 1, true) then
            DTC_F14BU_LSKCodes.LSK15 = code
        end
    end

    return DTC_F14BU_LSKCodes.LSK1 ~= nil
        and DTC_F14BU_LSKCodes.LSK2 ~= nil
        and DTC_F14BU_LSKCodes.LSK3 ~= nil
        and DTC_F14BU_LSKCodes.LSK4 ~= nil
end

local function F14_CodeToCommand(code)
    for lsk = 1, 4 do
        local command = "LSK" .. lsk
        if code == DTC_F14BU_LSKCodes[command] then
            return command
        end
    end

    return nil
end

local function F14_FindWaypoint(display, seq)
    local seqText = tostring(seq)

    for code, value in pairs(display) do
        local normalizedValue = tostring(value):gsub("^%s*%*?%s*", "")
        local sequence = normalizedValue:sub(1, #seqText)
        local separator = normalizedValue:sub(#seqText + 1, #seqText + 1)

        if sequence == seqText and (separator == " " or separator == "/") then
            return code
        end
    end

    return nil
end

local function F14_FindDisplayValue(display, expectedValue)
    for code, value in pairs(display) do
        if value == expectedValue then
            return code
        end
    end

    return nil
end

local function F14_EnterName(name)
    if name == nil or name == "" or name == "/" then
        return
    end

    F14_strToCmd(name)
    F14_Exec("LSK1")
end

local function F14_EnterElevation(elevation)
    F14_Exec("RIGHT")
    F14_strToCmd(elevation)
    F14_Exec("LSK4")
end

local function F14_OpenFirstEditPage(display)
    if F14_DisplayContains(display, DTC_F14BU_LSKCodes.LSK15, "2/2") then
        F14_Exec("RIGHT")
    end
end

-- When no flight plan exists, DCS does not expose the normal End of Flight Plan
-- entry on the FPLN page. Entering the first waypoint through DIR and issuing
-- the additional UP commands below are a workaround for this DCS bug.
function DTC_F14BU_ExecCmd_EndFlightPlan(seq, name, mgrs, elevation)
    local initialDisplay = F14_ParseDisplay()
    local lsk2Code = DTC_F14BU_LSKCodes.LSK2
    local lsk3Code = DTC_F14BU_LSKCodes.LSK3
    local noFlightPlan = F14_DisplayContains(initialDisplay, lsk2Code, "AUTO")
        and F14_DisplayContains(initialDisplay, lsk3Code, "End of Flight Plan")

    if noFlightPlan then
        if seq == nil then
            return true
        end

        if mgrs == nil or mgrs == "" then
            return false
        end

        local endOfFlightPlanCommand = F14_CodeToCommand(lsk3Code)
        if endOfFlightPlanCommand == nil then
            return false
        end

        F14_strToCmd(mgrs)
        F14_Exec(endOfFlightPlanCommand, 250) -- insert at End of Flight Plan
    end

    F14_Exec("FPLN", 250)

    local lsk1Code = DTC_F14BU_LSKCodes.LSK1

    if lsk1Code ~= nil then
        F14_Exec("UP", 250)

        for _ = 1, F14_MAX_PAGE_ATTEMPTS do
            local beforeDisplay = F14_ParseDisplay()
            local beforeValue = beforeDisplay[lsk1Code]

            local lsk4Code = DTC_F14BU_LSKCodes.LSK4
            if F14_DisplayContains(beforeDisplay, lsk4Code, "EXPAND") then
                F14_Exec("LSK4") -- COMPACT
            end

            F14_Exec("UP", 250)

            local afterDisplay = F14_ParseDisplay()
            local afterValue = afterDisplay[lsk1Code]
            if beforeValue == afterValue then
                break
            end
        end
    end

    for attempt = 1, F14_MAX_PAGE_ATTEMPTS do
        local display = F14_ParseDisplay()
        local waypointKey = F14_FindWaypoint(display, seq)

        if waypointKey ~= nil then
            local command = F14_CodeToCommand(waypointKey)
            if command == nil then
                return false
            end

            F14_Exec(command)
            local editDisplay = F14_ParseDisplay()
            F14_OpenFirstEditPage(editDisplay)

            F14_strToCmd(mgrs)
            F14_Exec("LSK1") -- insert coordinates
            F14_EnterName(name)

            F14_Exec(command) -- open WP EDIT 1/2
            F14_EnterElevation(elevation)
            F14_Exec("FPLN", 250)
            return true
        end

        local endOfFlightPlanKey = F14_FindDisplayValue(display, " *End of Flight Plan")

        if endOfFlightPlanKey ~= nil then
            F14_strToCmd(mgrs)
            local command = F14_CodeToCommand(endOfFlightPlanKey)
            if command == nil then
                return false
            end

            F14_Exec(command)
            F14_Exec(command)

            local editDisplay = F14_ParseDisplay()
            F14_OpenFirstEditPage(editDisplay)

            F14_EnterName(name)

            F14_strToCmd(seq)
            F14_Exec("LSK3")

            F14_EnterElevation(elevation)
            F14_Exec("FPLN", 250)
            return true
        end

        if attempt < F14_MAX_PAGE_ATTEMPTS then
            F14_Exec("DOWN")
        end
    end

    return false
end

function DTC_F14BU_AfterNextFrame(params)
    local mainPanel = GetDevice(0)
    local hsdTest = mainPanel:get_argument_value(1041)
    if hsdTest > 0.5 then params["uploadCommand"] = "1" end
end
