dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')

function DTC_CH47F_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
    local mfdDataBtn = mainPanel:get_argument_value(423);
    if mfdDataBtn == 1 then params["uploadCommand"] = "1" end
end