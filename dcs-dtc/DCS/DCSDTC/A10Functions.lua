dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')


function DTC_A10_GetCDU()
    return DTC_ParseDisplay(2)
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
