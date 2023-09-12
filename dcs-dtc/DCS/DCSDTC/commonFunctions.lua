function DTC_Log(str)
	DTC_logFile:write(str .. "\n");
	DTC_logFile:flush();
end

function DTC_ParseDisplay(indicator_id)  -- Thanks to [FSF]Ian code
	local t = {}
	local li = list_indication(indicator_id)
	local m = li:gmatch("-----------------------------------------\n([^\n]+)\n([^\n]*)\n")
	while true do
    	local name, value = m()
    	if not name then break end
   			t[name]=value
	end
	return t
end

function DTC_GetPlayerAircraftType()
    local data = LoGetSelfData();
    if data then
	    local model = data["Name"];
        if model == "F-16C_50" then return "F16CM" end
        if model == "FA-18C_hornet" then return "FA18C" end
        if model == "F-15ESE" then return "F15E" end
	    return model;
    end
    return "Unknown"
end

function DTC_SerializeDisplay(val, name, skipnewlines, depth)
    skipnewlines = skipnewlines or false
    depth = depth or 0

    local tmp = string.rep(" ", depth)

    if name then tmp = tmp .. name .. " = " end

    if type(val) == "table" then
        tmp = tmp .. "{" .. (not skipnewlines and "\n" or "")

        for k, v in pairs(val) do
            tmp =  tmp .. DTC_SerializeDisplay(v, k, skipnewlines, depth + 1) .. "," .. (not skipnewlines and "\n" or "")
        end

        tmp = tmp .. string.rep(" ", depth) .. "}"
    elseif type(val) == "number" then
        tmp = tmp .. tostring(val)
    elseif type(val) == "string" then
        tmp = tmp .. string.format("%q", val)
    elseif type(val) == "boolean" then
        tmp = tmp .. (val and "true" or "false")
    else
        tmp = tmp .. "\"[inserializeable datatype:" .. type(val) .. "]\""
    end

    return tmp
end

function DTC_DebugDisplay(display)
	local tbl = DTC_SerializeDisplay(display);
	DTC_Log(tbl);
end