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

function DTC_FA18C_CheckCondition_DispenserOff()
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["EW_ALE47_MODE_label_cross_Root"] or "x"
	if str == "" then
		return true
	end 
	return false
end

function DTC_FA18C_GetCurrentWaypoint()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["WYPT_Page_Number"]
	return tonumber(str);
end

function DTC_FA18C_ExecCmd_GoToWaypoint(desired, dev, cmdInc, cmdDec, delay, act)
	while true do
		local wpt = DTC_FA18C_GetCurrentWaypoint();
		if wpt == desired then
			break
		end
		if wpt > desired then
			DTC_ExecCommand(dev, cmdDec, delay, act)
		end
		if wpt < desired then
			DTC_ExecCommand(dev, cmdInc, delay, act)
		end
		coroutine.yield()
	end
end

function DTC_FA18C_AfterNextFrame(params)
	--DTC_DebugDisplay(DTC_FA18C_GetRightDDI())
	local mainPanel = GetDevice(0);
	local ipButton = mainPanel:get_argument_value(99);
	local hudVideoSwitch = mainPanel:get_argument_value(144);

	if ipButton == 1 then params["uploadCommand"] = "1" end
	if hudVideoSwitch >= 0.2 then params["showDTCCommand"] = "1" end
	if hudVideoSwitch > 0 and hudVideoSwitch < 0.2 then params["hideDTCCommand"] = "1" end
end