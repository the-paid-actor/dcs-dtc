dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')

--[[
6 - Pilot left MPD
8 - Pilot right MPD
10 - CPG left MPD
12 -- CPG right MPD
17 - Pilot radio panel
18 - CPG radio panel
]]--

function DTC_AH64D_GetDisplay(display)
    if display == "MFD_PLT_RIGHT" then
        return DTC_AH64D_GetPilotRightMPD()
    elseif display == "MFD_CPG_RIGHT" then
        return DTC_AH64D_GetCPGRightMPD()
    end
end

function DTC_AH64D_GetCPGRightMPD()
    return DTC_ParseDisplay(12)
end

function DTC_AH64D_GetPilotRightMPD()
    return DTC_ParseDisplay(8)
end

function DTC_AH64D_CleanFree(str, id)
    if str == id then
        return ""
    end
    return str
end

function DTC_AH64D_CleanAlt(str)
    str = str:gsub("%s+", "")
    str = str:gsub("FT", "")
    return tonumber(str)
end

function DTC_AH64D_CleanCoord(str)
    str = str:gsub("%s+", "")
    return str
end

function DTC_AH64D_CheckCondition_LabelEqual(display, label, value)
    local tbl = DTC_AH64D_GetDisplay(display)
    if tbl[label] == nil then
        return false
    end
    if tbl[label] == value then
        return true
    end
    return false
end

local DTC_AH64D_Points
local DTC_AH64D_PointsToDelete

function DTC_AH64D_ExecCmd_QueuePointToDelete(type, sequence)
    table.insert(DTC_AH64D_PointsToDelete, {
        type = type,
        sequence = sequence
    })
end

function DTC_AH64D_CheckCondition_IsPointQueuedToDelete(type, sequence)
    for k,v in pairs(DTC_AH64D_PointsToDelete) do
        if v.type == type and v.sequence == sequence then
            return true
        end
    end
    return false
end

function DTC_AH64D_CheckCondition_SequenceInUse(type, sequence)
    for k,v in pairs(DTC_AH64D_Points) do
        if v.sequence == sequence and (((v.type == "W" or v.type == "H") and (type == "W" or type == "H")) or (v.type == type)) then
            return true
        end
    end
    return false
end

function DTC_AH64D_CheckCondition_IsPointEqual(type, sequence, ident, free, coord, alt)
    for k,v in pairs(DTC_AH64D_Points) do
        if v.type == type and v.sequence == sequence and v.ident == ident and v.free == free and v.coord == coord and v.alt == alt then
            return true
        end
    end
    return false
end

function DTC_AH64D_ExecCmd_StoreCurrentCoords(display, data)
    DTC_AH64D_Points = {}
    DTC_AH64D_PointsToDelete = {}

    DTC_AH64D_ExecCmd_StoreCurrentCoords_Priv(DTC_AH64D_Points, display, data)
    DTC_ExecCommand(data.deviceID, data.T1, data.delay, data.action)
    DTC_AH64D_ExecCmd_StoreCurrentCoords_Priv(DTC_AH64D_Points, display, data)
    DTC_ExecCommand(data.deviceID, data.T2, data.delay, data.action)
    DTC_AH64D_ExecCmd_StoreCurrentCoords_Priv(DTC_AH64D_Points, display, data)
end

function DTC_AH64D_ExecCmd_StoreCurrentCoords_Priv(coords, display, data)
    local tempId
    local firstWptCurr
    local firstWptNext

    local tbl = DTC_AH64D_GetDisplay(display)

    for i = 1, 10, 1 do

        firstWptCurr = tbl["PB24_21"] or ""
        tempId = firstWptCurr;
        if tempId ~= "" then
            table.insert(coords, {
                id = tempId, 
                sequence = tonumber(string.sub(tempId, 2)),
                type = string.sub(tempId, 1, 1),
                ident = tbl["LABEL 1"] or "", 
                free = DTC_AH64D_CleanFree(tbl["LABEL 2"] or "", tempId), 
                coord = DTC_AH64D_CleanCoord(tbl["LABEL 5"] or ""), 
                alt = DTC_AH64D_CleanAlt(tbl["LABEL 6"] or "")
            })
        end

        tempId = tbl["PB23_23"] or ""
        if tempId ~= "" then
            table.insert(coords, {
                id = tempId, 
                sequence = tonumber(string.sub(tempId, 2)),
                type = string.sub(tempId, 1, 1),
                ident = tbl["LABEL 21"] or "", 
                free = DTC_AH64D_CleanFree(tbl["LABEL 22"] or "", tempId), 
                coord = DTC_AH64D_CleanCoord(tbl["LABEL 25"] or ""), 
                alt = DTC_AH64D_CleanAlt(tbl["LABEL 26"] or "")
            })
        end

        tempId = tbl["PB22_25"] or ""
        if tempId ~= "" then
            table.insert(coords, {
                id = tempId, 
                sequence = tonumber(string.sub(tempId, 2)),
                type = string.sub(tempId, 1, 1),
                ident = tbl["LABEL 41"] or "", 
                free = DTC_AH64D_CleanFree(tbl["LABEL 42"] or "", tempId), 
                coord = DTC_AH64D_CleanCoord(tbl["LABEL 45"] or ""), 
                alt = DTC_AH64D_CleanAlt(tbl["LABEL 46"] or "")
            })
        end

        tempId = tbl["PB21_27"] or ""
        if tempId ~= "" then
            table.insert(coords, {
                id = tempId, 
                sequence = tonumber(string.sub(tempId, 2)),
                type = string.sub(tempId, 1, 1),
                ident = tbl["LABEL 61"] or "", 
                free = DTC_AH64D_CleanFree(tbl["LABEL 62"] or "", tempId), 
                coord = DTC_AH64D_CleanCoord(tbl["LABEL 65"] or ""), 
                alt = DTC_AH64D_CleanAlt(tbl["LABEL 66"] or "")
            })
        end

        tempId = tbl["PB20_29"] or ""
        if tempId ~= "" then
            table.insert(coords, {
                id = tempId, 
                sequence = tonumber(string.sub(tempId, 2)),
                type = string.sub(tempId, 1, 1),
                ident = tbl["LABEL 81"] or "", 
                free = DTC_AH64D_CleanFree(tbl["LABEL 82"] or "", tempId), 
                coord = DTC_AH64D_CleanCoord(tbl["LABEL 85"] or ""), 
                alt = DTC_AH64D_CleanAlt(tbl["LABEL 86"] or "")
            })
        end

        tempId = tbl["PB19_31"] or ""
        if tempId ~= "" then
            table.insert(coords, {
                id = tempId, 
                sequence = tonumber(string.sub(tempId, 2)),
                type = string.sub(tempId, 1, 1),
                ident = tbl["LABEL 101"] or "", 
                free = DTC_AH64D_CleanFree(tbl["LABEL 102"] or "", tempId), 
                coord = DTC_AH64D_CleanCoord(tbl["LABEL 105"] or ""), 
                alt = DTC_AH64D_CleanAlt(tbl["LABEL 106"] or "")
            })
        end

        DTC_ExecCommand(data.deviceID, data.next, data.delay, data.action)
        
        tbl = DTC_AH64D_GetDisplay(display)
        firstWptNext = tbl["PB24_21"] or ""

        if firstWptNext == "" then
            break
        end

        local exists = false
        for k,v in pairs(coords) do
            if v.id == firstWptNext then
                exists = true
                break
            end
        end

        if exists then
            break
        end

    end
end

function DTC_AH64D_CheckCondition_RouteEmpty(display)
    local tbl = DTC_AH64D_GetDisplay(display)
    local r5 = tbl["PB11_45"] or ""
    local r4 = tbl["PB10_43"] or ""
    local r3 = tbl["PB9_41"] or ""
    local r2 = tbl["PB8_39"] or ""

    return r5 == "END" and r4 == "" and r3 == "" and r2 == ""
end

function DTC_AH64D_CheckCondition_CannotDeletePoint(display)
    local tbl = DTC_AH64D_GetDisplay(display)
    local str = tbl["PB21_45"] or ""
    return str ~= "NO"
end

function DTC_AH64D_ExecCmd_ClickEnd(display, data)
    local tbl = DTC_AH64D_GetDisplay(display)
    local r5 = tbl["PB11_45"] or ""
    local r4 = tbl["PB10_43"] or ""
    local r3 = tbl["PB9_41"] or ""
    local r2 = tbl["PB8_39"] or ""

    local button = 0
    if r5 == "END" then
        button = data.R5
    elseif r4 == "END" then
        button = data.R4
    elseif r3 == "END" then
        button = data.R3
    elseif r2 == "END" then
        button = data.R2
    end

    DTC_ExecCommand(data.deviceID, button, data.delay, data.action)
end

function DTC_AH64D_AfterNextFrame(params)
    local mainPanel = GetDevice(0);
    local pilotDefog = mainPanel:get_argument_value(356);
    local cpgDefog = mainPanel:get_argument_value(394);

    if pilotDefog == 1 then 
        params["uploadCommand"] = "1"
        params["pilot"] = "1"
    end
    if cpgDefog == 1 then
        params["uploadCommand"] = "1"
        params["cpg"] = "1"
    end
end