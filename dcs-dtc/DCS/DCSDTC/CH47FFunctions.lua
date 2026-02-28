dofile(lfs.writedir() .. 'Scripts/DCSDTC/commonFunctions.lua')

local function DTC_CH47F_GetCDU()
    return DTC_ParseDisplay(1)
end

local function DTC_CH47F_TURN(curPosition, NeedPosition, min, max)

    local size = max - min + 1

    -- starting from 0
    local current = curPosition - min
    local target = NeedPosition - min

    -- diff when rotating to the right
    local right =(target - current) % size

    -- diff when rotating to the left
    local left = right - size

    -- let’s choose the shorter path
    if math.abs(right) <= math.abs(left) then
        return right
        -- positive = to the right
    else
        return left
        -- negative = to the left
    end
end

local function DTC_CH47F_parseFreq(a)

    local b, c = string.match(a, "([^%.]+)%.([^%.]+)")

    if not b or not c then
        return nil
    end

    local sk1, sk2

    if #b == 3 then
        sk1 = string.sub(b, 1, 2)
        sk2 = string.sub(b, 3, 3)
    elseif #b == 2 then
        sk1 = string.sub(b, 1, 1)
        sk2 = string.sub(b, 2, 2)
    else
        return nil
    end

    local sk3 = string.sub(c, 1, 1)

    local sk4 = string.sub(c, 2, 3)
    if sk4 == "25" then
        sk4 = "1"
    elseif sk4 == "50" then
        sk4 = "2"
    elseif sk4 == "75" then
        sk4 = "3"
    else
        sk4 = "0"
    end

    return { sk1, sk2, sk3, sk4 }
end

function DTC_CH47F_ExecCmd_SetV3(reikiama)
    DTC_ExecCommand(51, 3009, -1, 0.1, 500)
    -- If there was a preset before, the CDU shows incorrect information — you need to move it for it to refresh
    local table = DTC_CH47F_GetCDU();

    local str1 = table["V3_freq"] or ""

    local freqStr = DTC_trim(str1)

    local freqCurr = DTC_CH47F_parseFreq(freqStr)


    local freqNeed = DTC_CH47F_parseFreq(reikiama)

    ------------------------------
    local cmd = 3009
    for i = 1, 4 do
        if i == 1 then
            min = 3
            max = 15
        elseif i == 4 then
            min = 0
            max = 3
        else
            min = 3
            max = 15
        end
        local toTurn = DTC_CH47F_TURN(freqCurr[i], freqNeed[i], min, max)


        local mkey = 0.1
        local wait = 250
        if i == 4 then
            mkey = 0.25
            wait = 450
        end


        if toTurn < 0 then
            mkey = - mkey
        end

        --  DTC_Log(tostring(i).. "=[" .. tostring(toTurn) .. "] esama="..freqCurr[i]..", reikia="..freqNeed[i])

        for a = 1, math.abs(toTurn) do
            DTC_ExecCommand(51, cmd, -1, mkey, wait)
        end
        cmd = cmd + 2
    end
end

function DTC_CH47F_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
    local mfdDataBtn = mainPanel:get_argument_value(423);
    if mfdDataBtn == 1 then params["uploadCommand"] = "1" end
end