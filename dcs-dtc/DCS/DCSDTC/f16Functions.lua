dofile(lfs.writedir() .. 'Scripts/DCSDTC/commonFunctions.lua')

-- # Utility functions #

function DTC_F16C_GetHUD()
    return DTC_GetDisplay(1)
end

function DTC_F16C_GetDED()
    return DTC_ParseDisplay(6)
end

function DTC_F16C_GetLeftMFD()
    return DTC_GetDisplay(4)
end

function DTC_F16C_GetRightMFD()
    return DTC_GetDisplay(5)
end

function DTC_F16C_GetPage(page, mfd, data)
    local p1Selected = mfd["PB_Menu_Label_ROOT_14.2.PB_Menu_Label_ROOT_Selected14.2.PB_Menu_Label_Black_PB_14.1"] or ""
    local p2Selected = mfd["PB_Menu_Label_ROOT_13.2.PB_Menu_Label_ROOT_Selected13.2.PB_Menu_Label_Black_PB_13.1"] or ""
    local p3Selected = mfd["PB_Menu_Label_ROOT_12.2.PB_Menu_Label_ROOT_Selected12.2.PB_Menu_Label_Black_PB_12.1"] or ""

    if p1Selected == page or p2Selected == page or p3Selected == page then
        return true
    end

    local p1 = mfd["PB_Menu_Label_ROOT_14.2.PB_Menu_Label_14.1"] or ""
    local p2 = mfd["PB_Menu_Label_ROOT_13.2.PB_Menu_Label_13.1"] or ""
    local p3 = mfd["PB_Menu_Label_ROOT_12.2.PB_Menu_Label_12.1"] or ""

    if p1 == page then
        return data.firstPageId
    elseif p2 == page then
        return data.secondPageId
    elseif p3 == page then
        return data.thirdPageId
    else
        return false
    end
end

function DTC_F16C_ExecCmd_SelectMFDPage(page, data)
    local leftMFDPage = DTC_F16C_GetPage(page, DTC_F16C_GetLeftMFD(), data)
    local rightMFDPage = DTC_F16C_GetPage(page, DTC_F16C_GetRightMFD(), data)

    if leftMFDPage == false and rightMFDPage == false then
        return
    end

    local deviceID = 0
    local mfd = ""

    if leftMFDPage ~= false then
        deviceID = data.leftMFDDeviceID
        mfd = "left"
        if leftMFDPage ~= true then
            DTC_ExecCommand(deviceID, leftMFDPage, data.delay, data.activation)
        end
    elseif rightMFDPage ~= false then
        deviceID = data.rightMFDDeviceID
        mfd = "right"
        if rightMFDPage ~= true then
            DTC_ExecCommand(deviceID, rightMFDPage, data.delay, data.activation)
        end
    end

    return mfd, deviceID
end

-- # Shared #

function DTC_F16C_CheckCondition_NAVMode()
    local table = DTC_F16C_GetHUD();
    local str = table["HUD_BlankRoot_PH_com.2.HUD_Indication_bias.2.HUD_Window8_MasterMode.1"] or "";
    if str == "NAV" then
        return true
    end
    return false
end

-- # Datalink #

function DTC_F16C_CheckCondition_FirstCallSignLetter(letter)
    local table = DTC_F16C_GetDED();
    local str = table["CallSign Name char1_inv"] or "";
    if str == letter or str == "" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_SecondCallSignLetter(letter)
    local table = DTC_F16C_GetDED();
    local str = table["CallSign Name char2_inv"] or "";
    if str == letter or str == "" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_FlightLead(status)
    local table = DTC_F16C_GetDED();
    local str = table["FL status"] or "";
    if str == status or str == "" then
        return true
    end 
    return false
end

function DTC_F16C_CheckCondition_TDOA(position, status)
    local table = DTC_F16C_GetDED();
    local str = table["STN TDOA value_" .. position] or "";
    if str == status then
        return true
    end 
    return false
end

function DTC_F16C_ExecCmd_EnableXMIT(data)
    local mfd, deviceID = DTC_F16C_ExecCmd_SelectMFDPage("HSD", data)

    local table = {}
    if mfd == "left" then
        table = DTC_LinesToList(list_indication(4))
    elseif mfd == "right" then
        table = DTC_LinesToList(list_indication(5))
    else
        return
    end

    local i = 1
    repeat
        if table[i] == "OFF Table. Root. Unic ID: _id:132. Text" then
            local currMode = table[i+2] 
            
            if currMode == "OFF" then
                if data.expected == "TNDL" then
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                elseif data.expected == "SMDL" then
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                end
            elseif currMode == "TNDL" then
                if data.expected == "OFF" then
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                elseif data.expected == "SMDL" then
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                end
            elseif currMode == "SMDL" then
                if data.expected == "OFF" then
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                elseif data.expected == "TNDL" then
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                    DTC_ExecCommand(deviceID, data.xmitButtonId, data.delay, data.activation)
                end
            end

            return
        end
        i = i + 1
    until i > #table
end

-- # HARM/HTS #

function DTC_F16C_CheckCondition_HARMEnabled()
    local table = DTC_F16C_GetDED();
    local str = table["Misc Item 0 Name"];
    if str == "HARM" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_HTSEnabled()
    local table = DTC_F16C_GetDED();
    local str = table["Misc Item E Name"];
    if str == "HTS" then
        return true
    end
    return false
end

function DTC_F16C_ExecCmd_SelectHARM(data)
    local mfd, deviceID = DTC_F16C_ExecCmd_SelectMFDPage("SMS", data)
    local strSearch = "AG88";

    for i = 1, 5, 1 do
        local table = {}
        if mfd == "left" then
            table = DTC_F16C_GetLeftMFD()
        elseif mfd == "right" then
            table = DTC_F16C_GetRightMFD()
        else
            return
        end

        local str = table["Table. Root. Unic ID: _id:1321.2.Table. Root. Unic ID: _id:1321. Text.1"];
        if str == nil or str:sub(-#strSearch) == strSearch then
            return
        end

        DTC_ExecCommand(deviceID, data.weaponStep, data.delay, data.activation)
    end
end

function DTC_F16C_CheckCondition_HTSAllNotSelected(mfd)
    local mfdTable;

    if mfd == "left" then
        mfdTable = DTC_F16C_GetLeftMFD();
    else
        mfdTable = DTC_F16C_GetRightMFD();
    end

    local str = mfdTable["ROOT_PAGE.2.HAD_THRT_PAGE.2.ALL Table. Root. Unic ID: _id:178.2.ALL Table. Root. Unic ID: _id:178. Text.1"];
    if str == "ALL" then
        return true
    end
    return false
end

function DTC_F16C_ExecCmd_BuildHTSMFD(data)
    local leftMFDPage = DTC_F16C_GetPage("HAD", DTC_F16C_GetLeftMFD(), data)
    local rightMFDPage = DTC_F16C_GetPage("HAD", DTC_F16C_GetRightMFD(), data)

    if leftMFDPage == false and rightMFDPage == false then
        return
    end

    local deviceID = 0
    local mfd = ""

    if leftMFDPage ~= false then
        deviceID = data.leftMFDDeviceID
        mfd = "left"
        if leftMFDPage ~= true then
            DTC_ExecCommand(deviceID, leftMFDPage, data.delay, data.activation)
        end
    elseif rightMFDPage ~= false then
        deviceID = data.rightMFDDeviceID
        mfd = "right"
        if rightMFDPage ~= true then
            DTC_ExecCommand(deviceID, rightMFDPage, data.delay, data.activation)
        end
    end

    DTC_ExecCommand(deviceID, data.threatButtonId, data.delay, data.activation)
    DTC_Wait()

    if DTC_F16C_CheckCondition_HTSAllNotSelected(mfd) then
        DTC_ExecCommand(deviceID, data.allButtonId, data.delay, data.activation)
    end

    DTC_ExecCommand(deviceID, data.allButtonId, data.delay, data.activation)

    if data.class1 then
        DTC_ExecCommand(deviceID, data.class1, data.delay, data.activation)
    end
    if data.class2 then
        DTC_ExecCommand(deviceID, data.class2, data.delay, data.activation)
    end
    if data.class3 then
        DTC_ExecCommand(deviceID, data.class3, data.delay, data.activation)
    end
    if data.class4 then
        DTC_ExecCommand(deviceID, data.class4, data.delay, data.activation)
    end
    if data.class5 then
        DTC_ExecCommand(deviceID, data.class5, data.delay, data.activation)
    end
    if data.class6 then
        DTC_ExecCommand(deviceID, data.class6, data.delay, data.activation)
    end
    if data.class7 then
        DTC_ExecCommand(deviceID, data.class7, data.delay, data.activation)
    end
    if data.class8 then
        DTC_ExecCommand(deviceID, data.class8, data.delay, data.activation)
    end
    if data.class9 then
        DTC_ExecCommand(deviceID, data.class9, data.delay, data.activation)
    end
    if data.class10 then
        DTC_ExecCommand(deviceID, data.class10, data.delay, data.activation)
    end
    if data.class11 then
        DTC_ExecCommand(deviceID, data.class11, data.delay, data.activation)
    end
    if (data.manual or false) == false then
        DTC_ExecCommand(deviceID, data.manual, data.delay, data.activation)
    end

    DTC_ExecCommand(deviceID, data.threatButtonId, data.delay, data.activation)
end

-- # MFD #

function DTC_F16C_CheckCondition_CRMMode(mfd, mode)
    local table = {}

    if mfd == "left" then
        table = DTC_F16C_GetLeftMFD();
    else
        table = DTC_F16C_GetRightMFD();
    end

    local rws = table["RWS Table. Root. Unic ID: _id:52.2.RWS Table. Root. Unic ID: _id:52. Text.1"] or "";
    local vsr = table["VSR Table. Root. Unic ID: _id:54.2.VSR Table. Root. Unic ID: _id:54. Text.1"] or "";
    local tws = table["TWS Table. Root. Unic ID: _id:55.2.TWS Table. Root. Unic ID: _id:55. Text.1"] or "";

    if (mode == "RWS" and rws == "RWS") or (mode == "VSR" and vsr == "VSR") or (mode == "TWS" and tws == "TWS") then
        return true
    end

    return false
end

function DTC_F16C_CheckCondition_FCRBars(mfd, expectedBars)
    local table = {}

    if mfd == "left" then
        table = DTC_F16C_GetLeftMFD();
    else
        table = DTC_F16C_GetRightMFD();
    end

    local bars = table["FCR_NotModeMenu_RootAA.2.Table. Root. Unic ID: _id:46.2.Table. Root. Unic ID: _id:46. Text.1"] or "";
    local agr = table["AGR Table. Root. Unic ID: _id:72.2.AGR Table. Root. Unic ID: _id:72. Text.1"] or "";

    if agr == "AGR" or bars == "" or bars == expectedBars then
        return true
    end

    return false
end

function DTC_F16C_CheckCondition_FCRAzimuth(mfd, expAz)
    local table = {}

    if mfd == "left" then
        table = DTC_F16C_GetLeftMFD();
    else
        table = DTC_F16C_GetRightMFD();
    end

    local az = table["FCR_NotModeMenu_RootAA.2.Table. Root. Unic ID: _id:47.2.Table. Root. Unic ID: _id:47. Text.2"] or 
                table["FCR_NotModeMenu_RootAG.2.Table. Root. Unic ID: _id:240.2.Table. Root. Unic ID: _id:240. Text.2"] or "";
    local agr = table["AGR Table. Root. Unic ID: _id:72.2.AGR Table. Root. Unic ID: _id:72. Text.1"] or "";

    if agr == "AGR" or az == "" or az == expAz then
        return true
    end

    return false
end


function DTC_F16C_CheckCondition_FCRRange(mfd, expRange)
    local table = {}

    if mfd == "left" then
        table = DTC_F16C_GetLeftMFD();
    else
        table = DTC_F16C_GetRightMFD();
    end

    local range = table["FCR_NotModeMenu_Root.2.Range_Scale_Root.2.Range_Scale_Value.1"] or "";
    local agr = table["AGR Table. Root. Unic ID: _id:72.2.AGR Table. Root. Unic ID: _id:72. Text.1"] or "";

    if agr == "AGR" or range == "" or range == expRange then
        return true
    end

    return false
end

function DTC_F16C_CheckCondition_FCRRangeAuto(mfd)
    local table = {}

    if mfd == "left" then
        table = DTC_F16C_GetLeftMFD();
    else
        table = DTC_F16C_GetRightMFD();
    end

    local val = table["FCR_NotModeMenu_RootAG.2.FCR_MapMenu_RootAG.2.NORM Table. Root. Unic ID: _id:75.2.NORM Table. Root. Unic ID: _id:75. Text.1"] or "";
    local agr = table["AGR Table. Root. Unic ID: _id:72.2.AGR Table. Root. Unic ID: _id:72. Text.1"] or "";

    if agr == "AGR" or val == "NORM" or val == "" then
        return false
    end

    return true
end

-- # Misc #

function DTC_F16C_CheckCondition_BullseyeNotSelected()
    local table = DTC_F16C_GetDED();
    local str = table["BULLSEYE LABEL"];
    if str == "BULLSEYE" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_TACANBandX()
    local table = DTC_F16C_GetDED();
    local str = table["TCN BAND XY"];
    if str == "X" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_TACANBandY()
    local table = DTC_F16C_GetDED();
    local str = table["TCN BAND XY"];
    if str == "Y" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_TACANNotTR()
    local table = DTC_F16C_GetDED();
    local str = table["TCN Mode"];
    if str == "T/R" then
        return false
    end
    return true
end

-- # Radios #

function DTC_F16C_CheckCondition_RadioBoth()
    local table = DTC_F16C_GetDED();
    local str = table["Receiver Mode"] or "";
    if str == "MAIN" then
        return false
    end
    return true
end

-- # Waypoints #

function DTC_F16C_CheckCondition_VIP_TO_TGT_NotSelected()
    local table = DTC_F16C_GetDED();
    local str1 = table["Visual initial point to TGT Label"] or "";
    local str2 = table["Visual initial point to TGT Label_inv"] or "";
    if (str1 == "VIP-TO-TGT") or (str2 == "VIP-TO-TGT") then
        return false
    end
    return true
end

function DTC_F16C_CheckCondition_VIP_TO_TGT_NotHighlighted()
    local table = DTC_F16C_GetDED();
    local str = table["Visual initial point to TGT Label"];
    if str == "VIP-TO-TGT" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_VIP_TO_PUP_NotHighlighted()
    local table = DTC_F16C_GetDED();
    local str = table["Visual initial point to TGT Label"];
    if str == "VIP-TO-PUP" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_TGT_TO_VRP_NotSelected()
    local table = DTC_F16C_GetDED();
    local str1 = table["Target to VRP Label"] or "";
    local str2 = table["Target to VRP Label_inv"] or "";
    if (str1 == "TGT-TO-VRP") or (str2 == "TGT-TO-VRP") then
        return false
    end
    return true
end

function DTC_F16C_CheckCondition_TGT_TO_VRP_NotHighlighted()
    local table = DTC_F16C_GetDED();
    local str = table["Target to VRP Label"];
    if str == "TGT-TO-VRP" then
        return true
    end
    return false
end

function DTC_F16C_CheckCondition_TGT_TO_PUP_NotHighlighted()
    local table = DTC_F16C_GetDED();
    local str = table["Target to VRP Label"];
    if str == "TGT-TO-PUP" then
        return true
    end
    return false
end

function DTC_F16C_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
    local wxButton = mainPanel:get_argument_value(187);
    local flirIncDec = mainPanel:get_argument_value(188);

    if wxButton == 1 then params["uploadCommand"] = "1" end
    if flirIncDec == 1 then params["showDTCCommand"] = "1" end
    if flirIncDec == -1 then params["hideDTCCommand"] = "1" end
end
