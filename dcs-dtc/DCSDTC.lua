local DEBUG = false	-- set true for development debugging

local tcpServer = nil
local udpSpeaker = nil
package.path  = package.path..";"..lfs.currentdir().."/LuaSocket/?.lua"
package.cpath = package.cpath..";"..lfs.currentdir().."/LuaSocket/?.dll"
package.path  = package.path..";"..lfs.currentdir().."/Scripts/?.lua"
local socket = require("socket")

local JSON = loadfile("Scripts\\JSON.lua")()
local needDelay = false
local keypressinprogress = false
local data
local delay = 0
local delayNeeded = 0
local delayStart = 0
local code = ""
local device = ""
local nextIndex = 1

local skipCondition
local skip = false

local tcpPort = 43001
local udpPort = 43000

local upstreamLuaExportStart = LuaExportStart
local upstreamLuaExportAfterNextFrame = LuaExportAfterNextFrame
local upstreamLuaExportBeforeNextFrame = LuaExportBeforeNextFrame

local function parse_indication(indicator_id)  -- Thanks to [FSF]Ian code
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

local function serializeTable(val, name, skipnewlines, depth)
    skipnewlines = skipnewlines or false
    depth = depth or 0

    local tmp = string.rep(" ", depth)

    if name then tmp = tmp .. name .. " = " end

    if type(val) == "table" then
        tmp = tmp .. "{" .. (not skipnewlines and "\n" or "")

        for k, v in pairs(val) do
            tmp =  tmp .. serializeTable(v, k, skipnewlines, depth + 1) .. "," .. (not skipnewlines and "\n" or "")
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

function LuaExportStart()
    if upstreamLuaExportStart ~= nil then
        successful, err = pcall(upstreamLuaExportStart)
        if not successful then
            log.write("DCS-DTC", log.ERROR, "Error in upstream LuaExportStart function"..tostring(err))
        end
    end
    
	udpSpeaker = socket.udp()
	udpSpeaker:settimeout(0)
	tcpServer = socket.tcp()
    successful, err = tcpServer:bind("127.0.0.1", tcpPort)
    tcpServer:listen(1)
    tcpServer:settimeout(0)
	if not successful then
		log.write("DCS-DTC", log.ERROR, "Error opening tcp socket - "..tostring(err))
	else
		log.write("DCS-DTC", log.INFO, "Opened connection")
	end
end

local function checkConditionHTSAllNotSelected(mfd)
	local mfdTable;

	if mfd == "left" then
		mfdTable = parse_indication(4);
	else
		mfdTable = parse_indication(5);
	end

	local str = mfdTable["ALL Table. Root. Unic ID: _id:178. Text"];
	if str == "ALL" then
		return true
	end
	return false
end

local function checkConditionHARM()
	local table = parse_indication(6);
	local str = table["Misc Item 0 Name"];
	if str == "HARM" then
		return true
	end
	return false
end

local function checkConditionNotInAAMode()
	local table = parse_indication(6);
	local str = table["Master_mode"];
	if str == "A-A" then
		return true
	end
	return false
end

local function checkConditionNotInAGMode()
	local table = parse_indication(6);
	local str = table["Master_mode"];
	if str == "A-G" then
		return true
	end
	return false
end

local function checkConditionHTSOnDED()
	local table = parse_indication(6);
	local str = table["Misc Item E Name"];
	if str == "HTS" then
		return true
	end
	return false
end

local function checkConditionBullseyeNotSelected()
	local table = parse_indication(6);
	local str = table["BULLSEYE LABEL"];
	if str == "BULLSEYE" then
		return true
	end
	return false
end

local function checkConditionBullseyeSelected()
	local table = parse_indication(6);
	local str = table["BULLSEYE LABEL_inv"];
	if str == "BULLSEYE" then
		return true
	end
	return false
end

local function checkConditionTACANBandX()
	local table = parse_indication(6);
	local str = table["TCN BAND XY"];
	if str == "X" then
		return true
	end
	return false
end

local function checkConditionTACANBandY()
	local table = parse_indication(6);
	local str = table["TCN BAND XY"];
	if str == "Y" then
		return true
	end
	return false
end

local function checkConditionHTSOnMFD(mfd)
	local mfdTable;

	if mfd == "left" then
		mfdTable = parse_indication(4);
	else
		mfdTable = parse_indication(5);
	end
	local str = table["HAD_OFF_Lable_name"];
	if str == "HAD" then
		return false
	end
	return true
end

local function checkCondition(condition)
	if condition == "NOT_IN_AA" then
		return checkConditionNotInAAMode();
	elseif condition == "NOT_IN_AG" then
		return checkConditionNotInAGMode();
	elseif condition == "HARM" then
		return checkConditionHARM();
	elseif condition == "HTS_DED" then
		return checkConditionHTSOnDED();	
	elseif condition == "LMFD_HTS" then
		return checkConditionHTSOnMFD("left");	
	elseif condition == "RMFD_HTS" then
		return checkConditionHTSOnMFD("right");	
	elseif condition == "LMFD_HTS_ALL_NOT_SELECTED" then
		return checkConditionHTSAllNotSelected("left");
	elseif condition == "RMFD_HTS_ALL_NOT_SELECTED" then
		return checkConditionHTSAllNotSelected("right");
	elseif condition == "BULLS_NOT_SELECTED" then
		return checkConditionBullseyeNotSelected();
	elseif condition == "BULLS_SELECTED" then
		return checkConditionBullseyeSelected();
	elseif condition == "TACAN_BAND_X" then
		return checkConditionTACANBandX();
	elseif condition == "TACAN_BAND_Y" then
		return checkConditionTACANBandY();
	else
		return false
	end
end

function LuaExportBeforeNextFrame()
    if upstreamLuaExportBeforeNextFrame ~= nil then
        successful, err = pcall(upstreamLuaExportBeforeNextFrame)
        if not successful then
           log.write("DCS-DTC", log.ERROR, "Error in upstream LuaExportBeforeNextFrame function"..tostring(err))
        end
    end

    if needDelay then
		local currentTime = socket.gettime()
		if ((currentTime - delayStart) > delayNeeded) then
			needDelay = false
			if device ~= "wait" then
				GetDevice(device):performClickableAction(code, 0)
			end
		end
	else
		if keypressinprogress then
			local keys = JSON:decode(data)
			for i=nextIndex, #keys do
				local keyObj = keys[i]
				local startCondition = keyObj["start_condition"]
				local endCondition = keyObj["end_condition"]
				
				if endCondition then
					if endCondition == skipCondition then
						skipCondition = nil
						skip = false
						nextIndex = i+1
					end
				elseif skip then
					nextIndex = i+1	
				elseif startCondition then
					skipCondition = startCondition
					skip = not checkCondition(startCondition)
					nextIndex = i+1
				else

					device = keyObj["device"]
					code = keyObj["code"]
					delay = tonumber(keyObj["delay"])
					
					local activate = tonumber(keyObj["activate"])

					if delay > 0 then
						needDelay = true
						delayNeeded = delay / 1000
						delayStart = socket.gettime()
						if device ~= "wait" then
							GetDevice(device):performClickableAction(code, activate)
						end
						nextIndex = i+1
						break
					else
						GetDevice(device):performClickableAction(code, activate)
						if delay == 0 then
							GetDevice(device):performClickableAction(code, 0)
						end
					end
				
				end
			end
			if not needDelay then
				keypressinprogress = false
				nextIndex = 1
			end
		else
		    local client, err = tcpServer:accept()

            if client ~= nil then
                client:settimeout(10)
			    data, err = client:receive()
			    if err then
				    log.write("DCS-DTC", log.ERROR, "Error at receiving: "..err)  
			    end

			    if data then 
				    keypressinprogress = true
			    end
            end
		end
	end
end

function LuaExportAfterNextFrame()
    if upstreamLuaExportAfterNextFrame ~= nil then
        successful, err = pcall(upstreamLuaExportAfterNextFrame)
        if not successful and DEBUG then
            log.write("DCS-DTC", log.ERROR, "Error in upstream LuaExportAfterNextFrame function"..tostring(err))
        end
    end

  	local camPos = LoGetCameraPosition()
	local selfData = LoGetSelfData()

	if camPos ~= nil and selfData ~= nil then
		local loX = camPos['p']['x']
		local loZ = camPos['p']['z']
		local elevation = LoGetAltitude(loX, loZ)
		local coords = LoLoCoordinatesToGeoCoordinates(loX, loZ)
		local model = selfData["Name"];
	
		local toSend = "{"..
			"\"model\": ".."\""..model.."\""..
			", ".."\"latitude\": ".."\""..coords.latitude.."\""..
			", ".."\"longitude\": ".."\""..coords.longitude.."\""..
			", ".."\"elevation\": ".."\""..elevation.."\""..
			"}"

		if pcall(function()
			socket.try(udpSpeaker:sendto(toSend, "127.0.0.1", udpPort)) 
		end) then
		else
			log.write("DCS-DTC", log.ERROR, "Unable to send data")
		end
	end
end
