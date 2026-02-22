dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')

function DTC_C130_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
    local unusedBtn = mainPanel:get_argument_value(1166);
    if unusedBtn == 1 then params["uploadCommand"] = "1" end
end