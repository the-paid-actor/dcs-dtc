local tcpServer = nil
local udpSpeaker = nil
package.path  = package.path..";"..lfs.currentdir().."/LuaSocket/?.lua"
package.cpath = package.cpath..";"..lfs.currentdir().."/LuaSocket/?.dll"
package.path  = package.path..";"..lfs.currentdir().."/Scripts/?.lua"
local socket = require("socket")
local JSON = loadfile("Scripts\\JSON.lua")()

DTC_logFile = io.open(lfs.writedir() .. [[Logs\DCSDTC.log]], "w")

dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')
dofile(lfs.writedir()..'Scripts/DCSDTC/f16Functions.lua')
dofile(lfs.writedir()..'Scripts/DCSDTC/f18Functions.lua')

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

local function checkCondition(condition, param1, param2)
    local ac = DTC_GetPlayerAircraftType();
    local funcName = 'DTC_'..ac..'_CheckCondition_'..condition;
    local res = _G[funcName](param1, param2)
    return res
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
                    local param1 = keyObj["param1"]
                    local param2 = keyObj["param2"]
                    skip = not checkCondition(startCondition, param1, param2)
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
        if not successful then
            log.write("DCS-DTC", log.ERROR, "Error in upstream LuaExportAfterNextFrame function"..tostring(err))
        end
    end

    local camPos = LoGetCameraPosition()
    local loX = camPos['p']['x']
    local loZ = camPos['p']['z']
    local elevation = LoGetAltitude(loX, loZ)
    local coords = LoLoCoordinatesToGeoCoordinates(loX, loZ)
    local model = DTC_GetPlayerAircraftType();

    local params = {};
    params["uploadCommand"] = "0";
    params["showDTCCommand"] = "0";
    params["hideDTCCommand"] = "0";

    if model ==	"F16CM" then
        DTC_F16CM_AfterNextFrame(params)
    end

    if model == "FA18C" then
        DTC_FA18C_AfterNextFrame(params)
    end

    local toSend = "{"..
        "\"model\": ".."\""..model.."\""..
        ", ".."\"latitude\": ".."\""..coords.latitude.."\""..
        ", ".."\"longitude\": ".."\""..coords.longitude.."\""..
        ", ".."\"elevation\": ".."\""..elevation.."\""..
        ", ".."\"upload\": ".."\""..params["uploadCommand"].."\""..
        ", ".."\"showDTC\": ".."\""..params["showDTCCommand"].."\""..
        ", ".."\"hideDTC\": ".."\""..params["hideDTCCommand"].."\""..
        "}"

    if pcall(function()
        socket.try(udpSpeaker:sendto(toSend, "127.0.0.1", udpPort)) 
    end) then
    else
        log.write("DCS-DTC", log.ERROR, "Unable to send data")
    end
end