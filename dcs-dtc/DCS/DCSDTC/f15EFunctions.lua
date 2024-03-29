dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')

-- Displays
-- 0 - NF FOV
-- 1 - HUD
-- 2 - Blank
-- 3 - Left MPD
-- 4 - ??
-- 5 - MPCD
-- 6 - ??
-- 7 - Right MPD
-- 8 - ??
-- 9 - UFC
-- 10 - RLMPCD
-- 12 - RLMPD
-- 14 - RRMPD
-- 16 - RRMPCD

-- # Utility Functions #

function DTC_F15E_GetFrontLeftMPD()
    return DTC_ParseDisplay(3)
end

function DTC_F15E_GetFrontRightMPD()
    return DTC_ParseDisplay(7)
end

function DTC_F15E_GetFrontMPCD()
    return DTC_ParseDisplay(5)
end

function DTC_F15E_GetRearLeftMPCD()
    return DTC_ParseDisplay(10)
end

function DTC_F15E_GetRearLeftMPD()
    return DTC_ParseDisplay(12)
end

function DTC_F15E_GetRearRightMPD()
    return DTC_ParseDisplay(14)
end

function DTC_F15E_GetRearRightMPCD()
    return DTC_ParseDisplay(16)
end

function DTC_F15E_GetUFC(ufc)
    ufc = ufc or "UFC_PILOT"
    if ufc == "UFC_PILOT" then
        return DTC_F15E_GetUFCFront()
    else
        return DTC_F15E_GetUFCRear()
    end
end

function DTC_F15E_GetUFCFront()
    return DTC_ParseDisplay(9)
end

function DTC_F15E_GetUFCRear()
    return DTC_ParseDisplay(18)
end

function DTC_F15E_GetDisplay(disp)
    local table;
    if disp == "FLMPD" then
        table = DTC_F15E_GetFrontLeftMPD();
    elseif disp == "FRMPD" then
        table = DTC_F15E_GetFrontRightMPD();
    elseif disp	== "FMPCD" then
        table = DTC_F15E_GetFrontMPCD();
    elseif disp	== "RLMPCD" then
        table = DTC_F15E_GetRearLeftMPCD();
    elseif disp	== "RLMPD" then
        table = DTC_F15E_GetRearLeftMPD();
    elseif disp	== "RRMPD" then
        table = DTC_F15E_GetRearRightMPD();
    elseif disp	== "RRMPCD" then
        table = DTC_F15E_GetRearRightMPCD();
    end
    return table
end

-- # Shared #

function DTC_F15E_CheckCondition_DisplayInMainMenu(display)
    local table = DTC_F15E_GetDisplay(display);
    local pb06 = table["PB06"] or "";
    local pb11 = table["PB11"] or "";
    if pb06 == "PROG" and pb11 == "M2" then
        return true
    end
    return false
end

function DTC_F15E_CheckCondition_ProgBoxed(display)
    local table = DTC_F15E_GetDisplay(display);
    local pb06 = table["PRG_PB06_T"] or "";
    if pb06 == "PROG" then
        return true
    end
    return false
end

function DTC_F15E_CheckCondition_InFrontCockpit()
    local table = DTC_F15E_GetFrontLeftMPD()
    if next(table) == nil then
        return false
    end
    return true
end

function DTC_F15E_CheckCondition_InRearCockpit()
    local table = DTC_F15E_GetRearLeftMPD()
    if next(table) == nil then
        return false
    end
    return true
end

local DTC_F15E_CockpitFrontRearState

function DTC_F15E_ExecCmd_SaveCockpitFrontRearState()
    if DTC_F15E_CheckCondition_InRearCockpit() then
        DTC_F15E_CockpitFrontRearState = "REAR"
    else
        DTC_F15E_CockpitFrontRearState = "FRONT"
    end
end

function DTC_F15E_ExecCmd_RestoreCockpitFrontRearState()
    if DTC_F15E_CockpitFrontRearState == "FRONT" then
        DTC_F15E_ExecCmd_GoToFrontCockpit()
    elseif DTC_F15E_CockpitFrontRearState == "REAR" then
        DTC_F15E_ExecCmd_GoToRearCockpit()
    end
    DTC_F15E_CockpitFrontRearState = nil
end

-- # Displays #

function DTC_F15E_CheckCondition_NoDisplaysProgrammed(disp)
    local table = DTC_F15E_GetDisplay(disp);
    local str = table["PRG_Label_1"] or table["PRG_Label_2"] or table["PRG_Label_3"] or ""
    if str == "" then
        return true
    end
    return false
end

function DTC_F15E_ExecCmd_GoToFrontCockpit()
    LoSetCommand(7)
    if DTC_F15E_CheckCondition_InFrontCockpit() == false then
        LoSetCommand(1602)
    end
end

function DTC_F15E_ExecCmd_GoToRearCockpit()
    LoSetCommand(7)
    if DTC_F15E_CheckCondition_InRearCockpit() == false then
        LoSetCommand(1602)
    end
end

-- # Misc #

function DTC_F15E_CheckCondition_IsTACANBand(ufc, band)
    local table = DTC_F15E_GetUFC(ufc);
    local str = table["UFC_SC_01"] or "";
    if str ~= "" and str.sub(str, -1) == band then
        return true
    end
    return false
end

function DTC_F15E_CheckCondition_IsTACANOff(ufc)
    local table = DTC_F15E_GetUFC(ufc);
    local str = table["UFC_SC_12"] or ""
    if str == "TCN ON " then
        return false
    end
    return true
end

-- # Radios #

function DTC_F15E_CheckCondition_AMSelected(ufc)
    local table = DTC_F15E_GetUFC(ufc);
    local str = table["UFC_SC_11"] or "";
    if str == "MAN-AM*" then
        return true
    end
    return false
end

function DTC_F15E_CheckCondition_IsRadioPresetOrFreqSelected(ufc, radio, mode)
    local table = DTC_F15E_GetUFC(ufc);
    local radio1Preset = table["UFC_SC_06"] or "x";
    local radio2Preset = table["UFC_SC_07"] or "x";
    local radio1Freq = table["UFC_SC_05"] or "x";
    local radio2Freq = table["UFC_SC_08"] or "x";

    if radio == "1" then
        if mode == "preset" then
            return (string.sub(radio1Preset, 1, 1) == "*")
        elseif mode == "freq" then
            return (string.sub(radio1Freq, 1, 1) == "*")
        end
    elseif radio == "2" then
        if mode == "preset" then
            return (string.sub(radio2Preset, -1) == "*")
        elseif mode == "freq" then
            return (string.sub(radio2Freq, -1) == "*")
        end
    end

    return false
end

function DTC_F15E_CheckCondition_IsRadioGuardEnabledDisabled(ufc, radio, mode)
    local table = DTC_F15E_GetUFC(ufc);
    local radio1Freq = table["UFC_SC_05"] or "x";
    local radio2Freq = table["UFC_SC_08"] or "x";
    radio2Freq = radio2Freq:gsub("*", ""):gsub("%s+", "")

    if radio == "1" then
        if mode == "enabled" then
            return string.sub(radio1Freq, -1) == "G"
        elseif mode == "disabled" then
            return string.sub(radio1Freq, -1) ~= "G"
        end
    elseif radio == "2" then
        if mode == "enabled" then
            return string.sub(radio2Freq, -1) == "G"
        elseif mode == "disabled" then
            return string.sub(radio2Freq, -1) ~= "G"
        end
    end

    return false
end

-- # SmartWeapons #

function DTC_F15E_CheckCondition_SmartStationSelected(display, station)
    local table = DTC_F15E_GetDisplay(display);
    local str = table["SWPNS_Page_Title_2"] or ""
    if str == station then
        return true
    end
    return false
end

-- # Waypoints #

function DTC_F15E_CheckCondition_UFCScratchPadDifferent(ufc, expected)
    local table = DTC_F15E_GetUFC(ufc);
    local str = table["UFC_SC_01"] or "";
    if str ~= expected then
        return true
    end
    return false
end

--function DTC_F15E_ExecCmd_TestUFC(device, string)
--    local table = DTC_F15E_GetUFC(device)
--    local str = table["UFC_CC_04"] or ""
--    if str ~= string then
--        DTC_Log("error " .. str)
--    end
--end

function DTC_F15E_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
    local ipButtonFront = mainPanel:get_argument_value(297);
    local ipButtonRear = mainPanel:get_argument_value(1322);
    local emButtonFront = mainPanel:get_argument_value(287);
    local emButtonRear = mainPanel:get_argument_value(1312);

    if ipButtonFront == 1 then params["uploadCommand"] = "1" end
    if ipButtonRear == 1 then params["uploadCommand"] = "1" end
    if emButtonFront == 1 then params["toggleDTCCommand"] = "1" end
    if emButtonRear == 1 then params["toggleDTCCommand"] = "1" end
end