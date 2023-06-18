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

function DTC_FA18C_CheckCondition_AtWp0()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["WYPT_Page_Number"]
	if str == "0" then
		return true
	end 
	return false
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

function DTC_FA18C_CheckCondition_IsJdam(i, n)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["STA".. i .. "_Label_TYPE"]
	if str == "J-" .. n then 
		return true 
	end
	return false
end

function DTC_FA18C_CheckCondition_IsSlam(i)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["STA".. i .. "_Label_TYPE"]
	if str == "SLAM" then 
		return true 
	end
	return false
end

function DTC_FA18C_CheckCondition_IsSlamER(i)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["STA".. i .. "_Label_TYPE"]
	if str == "SLMR" then 
		return true 
	end
	return false
end

function DTC_FA18C_CheckCondition_IsJsowA(i)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["STA".. i .. "_Label_TYPE"]
	if str == "JSA" then 
		return true 
	end
	return false
end

function DTC_FA18C_CheckCondition_IsJsowC(i)
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["STA".. i .. "_Label_TYPE"]
	if str == "JSC" then 
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

function DTC_FA18C_CheckCondition_NavBlim()
	local table = DTC_FA18C_GetRightDDI();
	local str = table["_1__id:13"] or ""
	if str == "N" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition_DispOff()
	local table = DTC_FA18C_GetLeftDDI();
	local str = table["EW_ALE47_MODE_label_cross_Root"] or "x"
	if str == "" then
		return true
	end 
	return false
end

function DTC_FA18C_CheckCondition(condition)
	if condition == "NOT_AT_WP0" then
		return DTC_FA18C_CheckCondition_NotAtWp0();
	elseif condition == "AT_WP0" then
		return DTC_FA18C_CheckCondition_AtWp0();
	elseif condition == "BINGO_ZERO" then
		return DTC_FA18C_CheckCondition_BingoIsZero();
	elseif condition:find("^IN_SEQ_") ~= nil then
		return DTC_FA18C_CheckCondition_InSequence(string.match(condition, "%d+"));
	elseif condition:find("^STA_IS_GBUTE_") ~= nil then -- GBU38
		return DTC_FA18C_CheckCondition_IsJdam(string.match(condition, "%d+"), 82);
	elseif condition:find("^STA_IS_GBUTO_") ~= nil then -- GBU31
		return DTC_FA18C_CheckCondition_IsJdam(string.match(condition, "%d+"), 84);
	elseif condition:find("^STA_IS_GBUTOP_") ~= nil then -- GBU31 - Penetrating
		return DTC_FA18C_CheckCondition_IsJdam(string.match(condition, "%d+"), 109);
	elseif condition:find("^STA_IS_GBUTT_") ~= nil then -- GBU32
		return DTC_FA18C_CheckCondition_IsJdam(string.match(condition, "%d+"), 83);
	elseif condition:find("^STA_IS_JSOWA_") ~= nil then
		return DTC_FA18C_CheckCondition_IsJsowA(string.match(condition, "%d+"));
	elseif condition:find("^STA_IS_JSOWC_") ~= nil then
		return DTC_FA18C_CheckCondition_IsJsowA(string.match(condition, "%d+"));
	elseif condition:find("^STA_IS_SLAM_") ~= nil then
		return DTC_FA18C_CheckCondition_IsSlam(string.match(condition, "%d+"));
	elseif condition:find("^STA_IS_SLAMER_") ~= nil then
		return DTC_FA18C_CheckCondition_IsSlamER(string.match(condition, "%d+"));
	elseif condition == "LMFD_NOT_TAC" then
		return DTC_FA18C_CheckCondition_LmfdNotTac();
	elseif condition == "RMFD_NOT_SUPT" then
		return DTC_FA18C_CheckCondition_RmfdNotSupt();
	elseif condition == "NOT_BULLSEYE" then
		return DTC_FA18C_CheckCondition_NotBullseye();
	elseif condition == "MAP_BOXED" then
		return DTC_FA18C_CheckCondition_MapBoxed();
	elseif condition == "MAP_UNBOXED" then
		return DTC_FA18C_CheckCondition_MapUnboxed();
	elseif condition == "NAV_BLIM" then
		return DTC_FA18C_CheckCondition_NavBlim();
	elseif condition == "DISP_OFF" then
		return DTC_FA18C_CheckCondition_DispOff();
	else
		return false
	end
end

function DTC_FA18C_AfterNextFrame(params)
	local mainPanel = GetDevice(0);
	local ipButton = mainPanel:get_argument_value(99);
	local hudVideoSwitch = mainPanel:get_argument_value(144);

	if ipButton == 1 then params["uploadCommand"] = "1" end
	if hudVideoSwitch >= 0.2 then params["showDTCCommand"] = "1" end
	if hudVideoSwitch > 0 and hudVideoSwitch < 0.2 then params["hideDTCCommand"] = "1" end
end