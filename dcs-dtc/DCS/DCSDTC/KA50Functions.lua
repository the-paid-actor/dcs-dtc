dofile(lfs.writedir() .. 'Scripts/DCSDTC/commonFunctions.lua')

-- Ka-50 III PVI-800 (device 20). Command ids match the cockpit clickable actions:
-- 3001-3010 digits 0-9, 3011 waypoints, 3018 enter, 3019 cancel, 3026 mode selector.
-- Mode 0.2 is data entry and 0.3 is operate.
local KA50_PVI = 20
local KA50_CMD_0 = 3001
local KA50_CMD_WPT = 3011
local KA50_CMD_ENTER = 3018
local KA50_CMD_CANCEL = 3019
local KA50_CMD_MODE = 3026
local KA50_MODE_ENTER = 0.2
local KA50_MODE_OPER = 0.3
local KA50_ACCEL_RESET_ARG = 572

local function DTC_KA50_Press(cmd)
    DTC_ExecCommand(KA50_PVI, cmd, 250, 0.3, 80)
end

local function DTC_KA50_SetMode(value)
    DTC_ExecCommand(KA50_PVI, KA50_CMD_MODE, -1, value, 0)
    DTC_Wait(400)
end

local function DTC_KA50_TypeDigits(digits)
    for i = 1, #digits do
        local n = tonumber(string.sub(digits, i, i))
        if n ~= nil then
            DTC_KA50_Press(KA50_CMD_0 + n)
        end
    end
end

-- 0 = north or east, 1 = south or west.
local function DTC_KA50_PrepareSign(wantNegative)
    if tonumber(wantNegative) == 1 then
        DTC_KA50_Press(KA50_CMD_0 + 1)
    else
        DTC_KA50_Press(KA50_CMD_0)
    end
end

function DTC_KA50_ExecCmd_BeginWaypointUpload()
    DTC_Log("KA50 PVI waypoint upload start")
    DTC_KA50_SetMode(KA50_MODE_ENTER)
    DTC_KA50_Press(KA50_CMD_CANCEL)
end

function DTC_KA50_ExecCmd_EnterWaypoint(seq, latDigits, latNeg, lonDigits, lonNeg)
    DTC_Log("KA50 PVI enter " .. tostring(seq) .. " lat=" .. tostring(latDigits) .. " lon=" .. tostring(lonDigits))
    -- Point 1: WPT once. Every later point: WPT twice, then the same entry.
    if tonumber(seq) == 1 then
        DTC_KA50_Press(KA50_CMD_WPT)
    else
        DTC_KA50_Press(KA50_CMD_WPT)
        DTC_Wait(250)
        DTC_KA50_Press(KA50_CMD_WPT)
    end
    DTC_Wait(200)

    DTC_KA50_TypeDigits(tostring(seq))
    DTC_Wait(150)

    DTC_KA50_PrepareSign(latNeg)
    DTC_KA50_TypeDigits(tostring(latDigits))
    DTC_KA50_PrepareSign(lonNeg)
    DTC_KA50_TypeDigits(tostring(lonDigits))
    DTC_KA50_Press(KA50_CMD_ENTER)
    DTC_Wait(300)
end

function DTC_KA50_ExecCmd_EndWaypointUpload()
    DTC_KA50_SetMode(KA50_MODE_OPER)
    DTC_Log("KA50 PVI waypoint upload done")
end

function DTC_KA50_AfterNextFrame(params)
    local mainPanel = GetDevice(0)
    local accelReset = mainPanel:get_argument_value(KA50_ACCEL_RESET_ARG)
    if accelReset == 1 then
        params["uploadCommand"] = "1"
    end
end
