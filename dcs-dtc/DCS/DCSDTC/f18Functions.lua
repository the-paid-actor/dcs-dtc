dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')

function DTC_FA18C_GetLeftDDI()
	return DTC_ParseDisplay(2)
end

function DTC_FA18C_GetRightDDI()
	return DTC_ParseDisplay(3)
end

function DTC_FA18C_GetMPCD()
	return DTC_ParseDisplay(4)
end

function DTC_FA18C_GetIFEI()
	return DTC_ParseDisplay(5)
end

function DTC_FA18C_GetUFC()
	return DTC_ParseDisplay(6)
end

function DTC_FA18C_CheckCondition_NotAtWp0()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["WYPT_Page_Number"]
	if str == "0" then
		return false
	end 
	return true
end

function DTC_FA18C_CheckCondition_NotAtWp0()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["WYPT_Page_Number"]
	if str == "0" then
		return false
	end 
	return true
end

function DTC_FA18C_CheckCondition_BingoIsZero()
	local table = DTC_FA18C_GetIFEI();
	local str = table["txt_BINGO"]
	if str == "0" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_InRadioChannel(radio, channel)
	local table = DTC_FA18C_GetUFC();
	local varName = "UFC_Comm"..radio.."Display"
	local str = table[varName] or ""
	local currChannel = str:gsub("%s+", ""):gsub("`", "1"):gsub("~", "2")
	if currChannel == tostring(channel) then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_IsRadioGuardDisabled()
	local table = DTC_FA18C_GetUFC();
	local str = table["UFC_OptionCueing1"] or ""
	if str ~= ":" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_InSequence(i)
	local table =DTC_FA18C_GetRightDDI();
	local str = table["WYPT_SequenceData"]
	local noSpaces = str:gsub("%s+", "")
	for token in string.gmatch(noSpaces, "[^-]+") do
		if token == i then 
			return true
		end
	end
	return false
end

function DTC_FA18C_CheckCondition_CheckStore(wpn, station)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["STA"..station.."_Label_TYPE"] or ""
	if str == wpn then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_StationSelected(station)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["STA"..station.."_Selective_Box_Line_02"] or "x"
	if str == "" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_IsTargetOfOpportunity()
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["Miss_Type"] or ""
	if str == "TOO1" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_IsPPNotSelected(number)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["MISSION_Type"] or ""
	if str ~= "PP"..number then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_IsPreciseNotSelected()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["PRECISE_1_box__id:26"] or "x"
	if str == "x" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_IsLatLongNotDecimal()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["_1__id:17"] or ""
	if str == "S" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_LmfdNotTac()
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["TAC_id:23"] or ""
	if str == "TAC" then
		return false
	end 
	return true
end

function DTC_FA18C_CheckCondition_RmfdNotSupt()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["SUPT_id:13"] or ""
	if str == "SUPT" then
		return false
	end 
	return true
end

function DTC_FA18C_CheckCondition_RmfdSupt()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["SUPT_id:13"] or ""
	if str == "SUPT" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_LmfdTac()
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["TAC_id:23"] or ""
	if str == "TAC" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_NotBullseye()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["A/A WP_1_box__id:12"] or "x"
	if str == "x" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_MapBoxed()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["MAP_1_box__id:30"] or "x"
	if str == "" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_MapUnboxed()
	local table = DTC_FA18C_GetRightDDI();
	local root = table["HSI_Main_Root"] or "x"
	local str = table["MAP_1_box__id:30"] or "x"
	if root == "x" and str == "x" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_IsBankLimitOnNav()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["_1__id:13"] or ""
	if str == "N" then
		return true
	end 
	return false
end

function DTC_FA18C_GetCurrentWaypoint()
	local table = DTC_FA18C_GetRightDDI()
	local str = table["WYPT_Page_Number"]
	return str;
end

function DTC_FA18C_CheckCondition_SequenceSelected(seq)
	local table = DTC_GetDisplay(3)
	local str = table["_1__id:20.4"] or ""
	local box = table["_1_box__id:21.1"]

	if str == seq and box == "" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_SequencesDeselected()
	local table = DTC_GetDisplay(3)
	local box = table["_1_box__id:21.1"] or "x"
	if box == "x" then
		return true
	end
	return false
end

function DTC_FastestWay(start, target, limit)
    local increment_distance = (target < start) and (limit - start + target) or (target - start)
    local decrement_distance = (target > start) and (start + limit - target) or (start - target)

    if increment_distance < decrement_distance then
        return 1
    elseif decrement_distance < increment_distance then
        return -1
    else
        return 0
    end
end

function DTC_FA18C_ExecCmd_GoToWaypoint(desired, dev, cmdInc, cmdDec, delay, act)
	for i = 1, 70, 1 do
		local wpt = DTC_FA18C_GetCurrentWaypoint();
		local current = 0

		if string.sub(wpt, 1, 1) == "M" then
			local id = tonumber(string.sub(wpt, 2, 2))
			current = 59 + id
		else
			current = tonumber(wpt);
		end

		if current == desired then
			break
		end
		local direction = DTC_FastestWay(current, desired, 69)
		if direction >= 0 then
			DTC_ExecCommand(dev, cmdInc, delay, act)
		else
			DTC_ExecCommand(dev, cmdDec, delay, act)
		end

		coroutine.yield()
	end
end

function DTC_FA18C_ExecCmd_UnSelectStore(device, b1, b2, b3, b4, b5, delay, act)
	local table = DTC_GetDisplay(2)
	local button1Selected = table["_1__id:134.2.BP_6_Break_X_Root.1"]
	local button2Selected = table["_1__id:137.2.BP_7_Break_X_Root.1"]
	local button3Selected = table["_1__id:140.2.BP_8_Break_X_Root.1"]
	local button4Selected = table["_1__id:143.2.BP_9_Break_X_Root.1"]
	local button5Selected = table["_1__id:146.2.BP_10_Break_X_Root.1"]

	if button1Selected == "" then
		DTC_ExecCommand(device, b1, delay, act)
	elseif button2Selected == "" then
		DTC_ExecCommand(device, b2, delay, act)
	elseif button3Selected == "" then
		DTC_ExecCommand(device, b3, delay, act)
	elseif button4Selected == "" then
		DTC_ExecCommand(device, b4, delay, act)
	elseif button5Selected == "" then
		DTC_ExecCommand(device, b5, delay, act)
	end
end

function DTC_FA18C_ExecCmd_SelectStore(store, device, b1, b2, b3, b4, b5, delay, act)
	DTC_FA18C_ExecCmd_UnSelectStore(device, b1, b2, b3, b4, b5, delay, act)
	DTC_Wait()
	DTC_FA18C_ExecCmd_UnSelectStore(device, b1, b2, b3, b4, b5, delay, act)
	DTC_Wait()

	local table = DTC_GetDisplay(2)
	local sta2 = table["_1__id:134.1"] or "";
	local sta3 = table["_1__id:137.1"] or "";
	local sta7 = table["_1__id:143.1"] or "";
	local sta8 = table["_1__id:146.1"] or "";

	if sta2 == store then
		DTC_ExecCommand(device, b1, delay, act)
	elseif sta3 == store then
		DTC_ExecCommand(device, b2, delay, act)
	elseif sta7 == store then
		DTC_ExecCommand(device, b4, delay, act)
	elseif sta8 == store then
		DTC_ExecCommand(device, b5, delay, act)
	end
end

function DTC_FA18C_CheckCondition_InPPStation(station)
	local table = DTC_GetDisplay(2)
	local str = table["Station_JDAM.2.CurrStation_JDAM.1"] or ""
	if str == station then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_DispenserOff()
	local table = DTC_GetDisplay(2)
	local str = table["ALE-47_1__id:3.2"] or ""
	if str == "OFF" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_DispenserOn()
	local table = DTC_GetDisplay(2)
	local str = table["ALE-47_1__id:3.2"] or ""
	if str == "OFF" then
		return false
	end 
	return true
end

function DTC_FA18C_ExecCmd_WaitUntilDispenserOn()
	for i = 1, 20, 1 do
		local table = DTC_GetDisplay(2)
		local str = table["ALE-47_1__id:3.2"] or ""
		local str2 = string.sub(str, 1, 3)
		if str2 == "STB" or str2 == "MAN" or str2 == "S/A" or str2 == "AUT" then
			return
		end
		DTC_Wait(1000)
	end
end

function DTC_FA18C_CheckCondition_DispenserNotSelected()
	local table = DTC_GetDisplay(2)
	local str = table["ALE-47_1_box__id:4.1"] or "x"
	if str == "x" then
		return true
	end
	return false
end

function DTC_FA18C_ExecCmd_SelectDispenserProgram(program, dev, btn, delay, act, postDelay)
	local desired = "CMDS PROG " .. program
	for i = 1, 10, 1 do
		local table = DTC_GetDisplay(2)
		local str = table["EW_CMDS_PROG.1"] or ""
		if str == desired then
			return
		end
		DTC_ExecCommand(dev, btn, delay, act, postDelay)
		coroutine.yield()
	end
end

function DTC_FA18C_ExecCmd_SelectDispenser(type, dev, btn, delay, act, postDelay)
	local table = DTC_GetDisplay(2)
	local key = ""
	if type == "chaff" then
		key = "CHAF_1_box__id:8.1"
	elseif type == "flare" then
		key = "FLAR_1_box__id:6.1"
	elseif type == "repeat" then
		key = "RPT_1_box__id:13.1"
	elseif type == "interval" then
		key = "INT_1_box__id:15.1"
	end
	local str = table[key] or "x"
	if str == "x" then
		DTC_ExecCommand(dev, btn, delay, act, postDelay)
	end
end

function DTC_FA18C_ExecCmd_SetDispenser(type, desired, dev, select, inc, dec, delay, act, postDelay)
	local key = ""
	local limit = 100
	if type == "chaff" then
		key = "EW_Prog_chaff.2"
	elseif type == "flare" then
		key = "EW_Prog_flare.2"
	elseif type == "repeat" then
		key = "EW_Prog_rpt.2"
		limit = 24
	elseif type == "interval" then
		key = "EW_Prog_int.2"
		limit = 5
	end

	local table = DTC_GetDisplay(2)
	local str = table[key] or ""
	if str == "" then
		return
	end
	local current = tonumber(str)
	if current == desired then
		return
	end

	DTC_FA18C_ExecCmd_SelectDispenser(type, dev, select, delay, act, postDelay)

	for i = 1, 100, 1 do
		table = DTC_GetDisplay(2)
		str = table[key] or ""
		if str == "" then
			return
		end
		current = tonumber(str)
		if current == desired then
			return
		end
		--if type ~= "interval" then
			local direction = DTC_FastestWay(current, desired, limit)
			if direction >= 0 then
				DTC_ExecCommand(dev, inc, delay, act, postDelay)
			else
				DTC_ExecCommand(dev, dec, delay, act, postDelay)
			end
		--else
			--DTC_ExecCommand(dev, inc, delay, act, postDelay)
		--end

		coroutine.yield()
	end
end

function DTC_FA18C_CheckCondition_InDispenserMode(mode)
	local table = DTC_GetDisplay(2)
	local str = table["ALE-47_1__id:3.2"] or ""
	local str2 = string.sub(str, 1, 4)
	if str2 ~= mode then
		return false
	end
	return true
end

function DTC_FA18C_CheckCondition_EWHudNotBoxed()
	local table = DTC_GetDisplay(2)
	local str = table["HUD_1_box__id:2.1"] or "x"
	if str == "" then
		return false
	end
	return true
end

function DTC_FA18C_ExecCmd_SetBingo(bingo, dev, inc, dec, delay, act, postDelay)
	local table = DTC_GetDisplay(5)
	local str = table["txt_BINGO.1"] or ""
	if str == "" then
		return
	end
	local current = tonumber(str)
	local diff = bingo - current
	if diff > 0 then
		local qty = math.floor(diff / 100)
		for i = 1, qty, 1 do
			DTC_ExecCommand(dev, inc, delay, act, postDelay)
			coroutine.yield()
		end
	else
		local qty = math.floor(math.abs(diff) / 100)
		for i = 1, qty, 1 do
			DTC_ExecCommand(dev, dec, delay, act, postDelay)
			coroutine.yield()
		end
	end
end

function DTC_FA18C_CheckCondition_HMDMode(mode)
	local table = DTC_GetDisplay(3)
	local str = table["_1__id:8.1"] or ""
	if str == mode then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_HMDOn()
	local table = DTC_GetDisplay(3)
	local str = table["Menu_SUPT.2.HMD_1__id:3.1"] or ""
	if str == "H" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRAging(aging)
	local table = DTC_GetDisplay(3)
	local str = table["TargetAging_Main.2._1__id:7.1"] or ""
	if str == aging then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRPRF(prf)
	local table = DTC_GetDisplay(3)
	local str = table["PDI_1__id:1.1"] or ""
	if str == "HI" and prf == "High" then
		return true
	end
	if str == "MED" and prf == "Medium" then
		return true
	end
	if str == "INTL" and prf == "Interleaved" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRAzimuth(az)
	local table = DTC_GetDisplay(3)
	local str = table["RWS_PB.2.AzimuthScan_Main.2.140°_1__id:31.1"] or ""
	str = str:gsub("°", "")
	if str == az then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRBars(bars)
	local table = DTC_GetDisplay(3)
	local str = table["ElevBarScan_Main.2.1B_1__id:3.1"] or ""
	str = str:gsub("B", "")
	if str == bars then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRRange(range)
	local table = DTC_GetDisplay(3)
	local str = table["RadarRange_VS_scaleMax.1"] or ""
	if str == range then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRBRABoxed(enable)
	local table = DTC_GetDisplay(3)
	local str = table["BRA_1_box__id:17.1"] or "x"
	if str == "" and enable == false then
		return true
	end
	if str == "x" and enable == true then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRRWRBoxed(enable)
	local table = DTC_GetDisplay(3)
	local str = table["RWR_ATTK_Label_PH.2.RWR_ATTK_Label_Box.1"] or "x"
	if str == "" and enable == false then
		return true
	end
	if str == "x" and enable == true then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRDeclutter(mode)
	local table = DTC_GetDisplay(3)
	local str = table["DCLTR _1__id:20.1"] or ""
	if str == "DCLTR" and mode == "Normal" then
		return true
	end
	if str == "DCLTR 1" and mode == "Declutter1" then
		return true
	end
	if str == "DCLTR 2" and mode == "Declutter2" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FCRRWRBoxed(enable)
	local table = DTC_GetDisplay(3)
	local str = table["RWR_ATTK_Label_PH.2.RWR_ATTK_Label_Box.1"] or "x"
	if str == "" and enable == false then
		return true
	end
	if str == "x" and enable == true then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FLIRAvailable()
	local table = DTC_FA18C_GetLeftDDI()
	local str = table["FLIR_1__id:6"] or ""
	if str == "FLIR" then
		return true
	end
	return false
end

function DTC_FA18C_CheckCondition_FLIROn()
	local table = DTC_FA18C_GetLeftDDI()
	local str = table["MPD_FLIR_NotTimedOut_label"] or ""
	if str == "NOT TIMED OUT" then
		return false
	end
	return true
end

function DTC_FA18C_ExecCmd_BoxHMDSetting(setting, expected, dev, down, right, delay, act, post, btn)
	local boxedKey = "HMD_item_"..setting..".2.HMD_item_box_"..setting..".1"
	local nameKey = "HMD_item_"..setting..".2.HMD_item_name_"..setting..".1"
	local valueKey = "HMD_item_"..setting..".2.HMD_item_status_"..setting..".1"
	local table = DTC_GetDisplay(3)
	--check if setting exists
	local name = table[nameKey] or ""
	if name == "" then
		return
	end

	local value = table[valueKey] or ""
	if value == "" or value == expected then
		return
	end

	local found = false
	for i = 1, 3, 1 do
		for j = 1, 20, 1 do
			local table = DTC_GetDisplay(3)

			--check if its boxed
			local boxed = table[boxedKey] or "x"
			if boxed == "" then
				found = true
				break
			end

			DTC_ExecCommand(dev, down, delay, act, post)
			coroutine.yield()
		end
		if found == false then
			DTC_ExecCommand(dev, right, delay, act, post)
			coroutine.yield()
		end
	end
	if found == true then
		DTC_ExecCommand(dev, btn, delay, act, post)
	end
end

function DTC_FA18C_AfterNextFrame(params)
	--DTC_Log(DTC_FA18C_GetCurrentWaypoint())
	--DTC_DebugDisplay(DTC_FA18C_GetRightDDI())
	--DTC_DebugDisplay(DTC_GetDisplay(2))
	local mainPanel = GetDevice(0);
	local ipButton = mainPanel:get_argument_value(99);
	local hudVideoSwitch = mainPanel:get_argument_value(144);

	if ipButton == 1 then params["uploadCommand"] = "1" end
	if hudVideoSwitch >= 0.2 then params["showDTCCommand"] = "1" end
	if hudVideoSwitch > 0 and hudVideoSwitch < 0.2 then params["hideDTCCommand"] = "1" end
end