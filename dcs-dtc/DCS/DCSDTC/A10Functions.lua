dofile(lfs.writedir() .. 'Scripts/DCSDTC/commonFunctions.lua')


local function DTC_A10_GetLMFD()
    return DTC_ParseDisplay(1)
end

local function DTC_A10_GetCDU()
    return DTC_ParseDisplay(2)
end

local function DTC_A10_GetHUD()
    return DTC_ParseDisplay(5)
end

local function DTC_A10_ARC210()
    return DTC_ParseDisplay(18)
end



local function DTC_A10_parseFreq(needed)
    local b, c = string.match(needed, "([^%.]+)%.([^%.]+)")

    if not b or not c then
        return nil
    end

    local sk1 = ""
    local sk2 = ""
    local sk3 = ""
    if #b == 3 then
        sk1 = tonumber(string.sub(b, 1, 1))
        sk2 = tonumber(string.sub(b, 2, 2))
        sk3 = tonumber(string.sub(b, 3, 3))
    elseif #b == 2 then
        sk1 = 0
        sk2 = tonumber(string.sub(b, 1, 1))
        sk3 = tonumber(string.sub(b, 2, 2))
    else
        return nil
    end

    local sk4 = tonumber(string.sub(c, 1, 1))
    local sk5 = tonumber(string.sub(c, 2, 3))


    if sk5 == 25 then
        sk5 = 1
    elseif sk5 == 50 then
        sk5 = 2
    elseif sk5 == 75 then
        sk5 = 3
    else
        sk5 = 0
    end
    return { sk1, sk2, sk3, sk4, sk5 }
end

function DTC_A10_ExecCmd_SetAMFM(no, mode)
    local table = DTC_A10_GetHUD()
    local curr = table["Preset_mod_Com1_" .. no] or ""

    if curr ~= mode then
        DTC_ExecCommand(-2, 646, 100, 1, 50)
    end
end

function DTC_A10_ExecCmd_SetFreq(needed)
    local table = DTC_A10_ARC210()
    local freqMhz = table["freq_label_mhz"] or ""
    if freqMhz == "" then
        return false
    end
    local freqKhz = table["freq_label_khz"] or ""
    if freqKhz == "" then
        return false
    end

    local freqCurr = DTC_A10_parseFreq(freqMhz .. "." .. freqKhz)
    local freqNeed = DTC_A10_parseFreq(needed)

    if freqCurr == nil or freqNeed == nil then
        return false
    end
    -- 1 3045
    -- 2 3046
    -- 3 3047
    -- 4 3048
    -- 5 3049
    local res = 0
    for a = 1, 5 do
        if freqCurr[a] < freqNeed[a] then

            for b = freqCurr[a], freqNeed[a] -1 do
                DTC_ExecCommand(55, 3044 + a, -1, 1, 50)
                res = res + 1
            end
        elseif freqCurr[a] > freqNeed[a] then
            for b = freqNeed[a], freqCurr[a] -1 do
                DTC_ExecCommand(55, 3044 + a, -1, -1, 50)
                res = res - 1
            end
        end
    end
    -- return freqStr.." "..freqCurr[5]
    return res
    -- freqMhz.."."..freqKhz
end



function DTC_A10_ExecCmd_SetPreset(needed)
    local table = DTC_A10_ARC210()
    local curr = table["active_channel"] or ""
    if curr == "" then
        return false
    end

    local curPreset = tonumber(curr)

    if needed > curPreset then
        for a = curPreset, needed - 1 do
            DTC_ExecCommand(55, 3027, -1, 1)
        end
        return true
    end

    if needed < curPreset then
        for a = needed, curPreset - 1 do
            DTC_ExecCommand(55, 3027, -1, -1)
        end
        return true
    end

    return false
end


function DTC_A10_ExecCmd_NumMode()
    local table = DTC_A10_GetHUD()
    local under = table["Scratch_PAD_Mode_underline"] or ""
    if DTC_trim(under) == "-" then
        DTC_ExecCommand(8, 3014, 50, 1, 0)
        return true
    end

    local L = table["Scratch_PAD_Mode"] or ""
    if DTC_trim(L) == "L" then
        DTC_ExecCommand(8, 3014, 50, 1, 0)
        DTC_ExecCommand(8, 3014, 50, 1, 0)
        return true
    end
    return false
end

function DTC_A10_ExecCmd_SetReqWptQty(need)
    local table = DTC_A10_GetCDU()
    local str1 = table["NEW_WAYPT_NUM"] or ""

    local curr = str1:gsub("%?", "")

    if tonumber(curr) > 0 then
        for a = tonumber(curr), need do
            DTC_ExecCommand(-2, 1234, 150, 1, 100)
        end
    end

    return true
end 


function DTC_A10_ExecCmd_SetInputFormat()
    local table = DTC_A10_GetCDU();
    local str1 = table["WAYPTCoordFormat1"] or ""
    if DTC_trim(str1) == "UTM" then
        DTC_ExecCommand(-2, 1235, 150, 1, 100)
    end
    return true
end


function DTC_A10_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
    local rtnBtn = mainPanel:get_argument_value(533);
    if rtnBtn == 1 then params["uploadCommand"] = "1" end
end
