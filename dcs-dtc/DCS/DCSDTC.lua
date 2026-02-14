local upstreamLuaExportStart           = LuaExportStart
local upstreamLuaExportAfterNextFrame  = LuaExportAfterNextFrame
local upstreamLuaExportBeforeNextFrame = LuaExportBeforeNextFrame

package.path                           = package.path .. ";" .. lfs.currentdir() .. "/LuaSocket/?.lua"
package.cpath                          = package.cpath .. ";" .. lfs.currentdir() .. "/LuaSocket/?.dll"
package.path                           = package.path .. ";" .. lfs.currentdir() .. "/Scripts/?.lua"

local socket                           = require("socket")
local JSON                             = loadfile("Scripts\\JSON.lua")()

DTC_logFile                            = io.open(lfs.writedir() .. [[Logs\DCSDTC.log]], "w")

dofile(lfs.writedir() .. 'Scripts/DCSDTC/commonFunctions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/f16Functions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/f18Functions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/f15EFunctions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/ah64DFunctions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/C130Functions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/A10Functions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/CH47FFunctions.lua')
dofile(lfs.writedir() .. 'Scripts/DCSDTC/AV8BFunctions.lua')

local udpSpeaker = nil
local tcpServer = nil
local tcpPort = 43001
local udpPortDTCApp = 43000
local udpPortHook = 43001
local processingData = false
local currentCoroutine = nil

function DTC_Net_SendData(data, port)
    if udpSpeaker == nil then
        udpSpeaker = socket.udp()
        udpSpeaker:settimeout(0)
    end

    if pcall(function()
            socket.try(udpSpeaker:sendto(data, "127.0.0.1", port))
        end) then
    else
        DTC_DCSLogError("Unable to send data")
    end
end

function DTC_Net_ReceiveData()
    if tcpServer == nil then
        local server, err = socket.bind("127.0.0.1", tcpPort, 1)
        if server == nil then
            DTC_DCSLogError("Error creating tcp socket - " .. tostring(err))
            return
        end

        tcpServer = server
        tcpServer:settimeout(0)
        DTC_DCSLogInfo("Opened connection")
    end

    local client, err = tcpServer:accept()
    if client == nil then
        return
    end

    client:settimeout(10)
    local data, err = client:receive('*a')

    if err then
        DTC_DCSLogError("Error at receiving: " .. err)
        return
    end

    client:close()
    return data
end

function DTC_ProcessActions()
    local data = DTC_Net_ReceiveData()
    if data ~= nil then
        local func, error = loadstring(data)
        if func == nil then
            DTC_Log(data)
            DTC_Log("Error loading function: " .. error)
            return
        end
        currentCoroutine = coroutine.create(func)
        DTC_Net_SendData("showuploadinprogress", udpPortHook)
    end
end

function DTC_ProcessCoroutine()
    if coroutine.status(currentCoroutine) == "dead" then
        --clean the input queue in case upload was actioned by the user
        DTC_Net_ReceiveData()
        currentCoroutine = nil
        DTC_Net_SendData("hideuploadinprogress", udpPortHook)
        --DTC_Log("Coroutine finished")
        return
    end

    local success, err = coroutine.resume(currentCoroutine)
    --DTC_Log("Output: "..tostring(success))
    if success ~= true then
        DTC_Log("Error in coroutine: " .. err)
        DTC_Net_SendData("hideuploadinprogress", udpPortHook)
        currentCoroutine = nil
    end
end

function DTC_Wait(miliseconds)
    miliseconds = miliseconds or 200
    local start = socket.gettime()
    while true do
        local current = socket.gettime()
        if (current - start) > (miliseconds / 1000) then
            break
        end
        coroutine.yield()
    end
end

function DTC_ExecCommand(device, argument, delay, action, postDelay)
    postDelay = postDelay or 0


     
     if device == -2 then 
         LoSetCommand(argument,  action)
         DTC_Log("Executed command LoSetCommand("..argument..",  "..action..")")
         if delay > 0 then
            DTC_Wait(delay)
         end
         if delay >= 0 then
           LoSetCommand(argument,  action)
         end

     elseif device ==-1 then
         LoSetCommand(argument,  nil)
     else 
         GetDevice(device):performClickableAction(argument, action)

         if delay > 0 then
            DTC_Wait(delay)
         end
         if delay >= 0 then
           GetDevice(device):performClickableAction(argument, 0)
         end
     end
    --DTC_Log("Executed command "..device.." "..argument.." "..action.." "..delay .. " " ..postDelay)
    coroutine.yield()

    if postDelay > 0 then
        DTC_Wait(postDelay)
    end
end

function LuaExportStart()
    if upstreamLuaExportStart ~= nil then
        local successful, err = pcall(upstreamLuaExportStart)
        if not successful then
            DTC_DCSLogError("Error in upstream LuaExportStart function" .. tostring(err))
        end
    end

    DTC_DCSLogInfo("Initialized DTC")
end

function LuaExportBeforeNextFrame()
    if upstreamLuaExportBeforeNextFrame ~= nil then
        local successful, err = pcall(upstreamLuaExportBeforeNextFrame)
        if not successful then
            DTC_DCSLogError("Error in upstream LuaExportBeforeNextFrame function" .. tostring(err))
        end
    end

    if currentCoroutine == nil then
        DTC_ProcessActions()
    else
        DTC_ProcessCoroutine()
    end
end

function LuaExportAfterNextFrame()
    if upstreamLuaExportAfterNextFrame ~= nil then
        local successful, err = pcall(upstreamLuaExportAfterNextFrame)
        if not successful then
            DTC_DCSLogError("Error in upstream LuaExportAfterNextFrame function" .. tostring(err))
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
    params["toggleDTCCommand"] = "0";
    params["toggleDTCCommand"] = "0";
    params["pilot"] = "0";
    params["cpg"] = "0";

    if model == "F16C" then
        DTC_F16C_AfterNextFrame(params)
    end

    if model == "FA18C" then
        DTC_FA18C_AfterNextFrame(params)
    end

    if model == "F15E" then
        DTC_F15E_AfterNextFrame(params)
    end

    if model == "AH64D" then
        DTC_AH64D_AfterNextFrame(params)
    end

    if model == "C130" then
        DTC_C130_AfterNextFrame(params)
    end

    if model == "A10" then
        DTC_A10_AfterNextFrame(params)
    end

    if model == "CH47F" then
        DTC_CH47F_AfterNextFrame(params)
    end

    if model == "AV8B" then
        DTC_AV8B_AfterNextFrame(params)
    end

    local toSend = "{" ..
        "\"model\": " .. "\"" .. model .. "\"" ..
        ", " .. "\"latitude\": " .. "\"" .. coords.latitude .. "\"" ..
        ", " .. "\"longitude\": " .. "\"" .. coords.longitude .. "\"" ..
        ", " .. "\"elevation\": " .. "\"" .. elevation .. "\"" ..
        ", " .. "\"upload\": " .. "\"" .. params["uploadCommand"] .. "\"" ..
        ", " .. "\"pilot\": " .. "\"" .. params["pilot"] .. "\"" ..
        ", " .. "\"cpg\": " .. "\"" .. params["cpg"] .. "\"" ..
        ", " .. "\"showDTC\": " .. "\"" .. params["showDTCCommand"] .. "\"" ..
        ", " .. "\"hideDTC\": " .. "\"" .. params["hideDTCCommand"] .. "\"" ..
        ", " .. "\"toggleDTC\": " .. "\"" .. params["toggleDTCCommand"] .. "\"" ..
        "}"

    DTC_Net_SendData(toSend, udpPortDTCApp)
end
