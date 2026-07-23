dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')

local function DTC_C130_GetCNI()
    return DTC_ParseDisplay(8)
end

local function hasLineEndingWith(txt, suffix)
    for line in (txt .. "\n"):gmatch("(.-)\n") do
        line = line:gsub("%s+$", "")
        if line:sub(-#suffix) == suffix then
            return true, line
        end
    end
    return false
end

local function FindIndicatorByLineSuffix(deviceid, txttofind)
        local ok, txt = pcall(list_indication, deviceid)
        if ok and type(txt) == "string" and #txt > 0 then
            local found, line = hasLineEndingWith(txt, txttofind)
            if found then
                return line
            end
        end
    return ""
end


function DTC_C130_ExecCmd_SetCNIPage1()
    local table = DTC_C130_GetCNI();

    local str1 = FindIndicatorByLineSuffix(8,"/10")
     
    local sk=string.sub(DTC_trim(str1),1, -4)

    local curPsl= tonumber(sk)

    if curPsl == 1 then
      return true
    end 

    for id = 2, curPsl do
        DTC_ExecCommand(25, 3027, 150, 1, 100)
    end 

    return true
end

function DTC_C130_ExecCmd_PreWaypointSafety()
    DTC_C130_ExecCmd_SetCNIPage1()

    -- Hold CLR for 5 seconds to clear any pending scratchpad input.
    DTC_ExecCommand(25, 3029, -1, 1, 0)
    DTC_Wait(5000)
    DTC_ExecCommand(25, 3029, -1, -1, 0)

    -- Requested cleanup sequence before waypoint entry.
    DTC_ExecCommand(25, 3019, 150, 1, 100) -- LEGS
    DTC_ExecCommand(25, 3012, 150, 1, 100) -- LSK R6
    DTC_ExecCommand(25, 3028, 150, 1, 100) -- DEL
    DTC_ExecCommand(25, 3001, 150, 1, 100) -- LSK L1
    DTC_ExecCommand(25, 3029, 150, 1, 100) -- CLR

    return true
end

function DTC_C130_AfterNextFrame(params)
    local mainPanel = GetDevice(0)
    local unusedBtn = mainPanel:get_argument_value(1166)
    if unusedBtn == 1 then params["uploadCommand"] = "1" end
end