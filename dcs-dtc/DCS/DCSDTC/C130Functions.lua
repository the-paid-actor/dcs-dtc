dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')

-- Displays

-- # Utility Functions #


-- function DTC_F15E_GetDisplay(disp)
    -- local table;
--    if disp == "FLMPD" then
--        table = DTC_F15E_GetFrontLeftMPD();
--    elseif disp	== "RRMPD" then
--        table = DTC_F15E_GetRearRightMPD();
--    elseif disp	== "RRMPCD" then
--       table = DTC_F15E_GetRearRightMPCD();
--    end
    
--    return table
-- end

-- # Shared #


--function DTC_F15E_ExecCmd_TestUFC(device, string)
--    local table = DTC_F15E_GetUFC(device)
--    local str = table["UFC_CC_04"] or ""
--    if str ~= string then
--        DTC_Log("error " .. str)
--    end
--end

function DTC_C130_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
   -- local ipButtonFront = mainPanel:get_argument_value(297);
   -- local ipButtonRear = mainPanel:get_argument_value(1322);
   --local emButtonFront = mainPanel:get_argument_value(287);
   -- local emButtonRear = mainPanel:get_argument_value(1312);

   -- if ipButtonFront == 1 then params["uploadCommand"] = "1" end
   -- if ipButtonRear == 1 then params["uploadCommand"] = "1" end
   -- if emButtonFront == 1 then params["toggleDTCCommand"] = "1" end
   -- if emButtonRear == 1 then params["toggleDTCCommand"] = "1" end

   params["uploadCommand"] = "1"
end