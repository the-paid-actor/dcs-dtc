--package.path  = package.path..";.\\LuaSocket\\?.lua;"
--package.cpath = package.cpath..";.\\LuaSocket\\?.dll;"
--package.path = package.path .. ";.\\Scripts\\?.lua;.\\Scripts\\UI\\?.lua;"

--local dxgui = require('dxgui')
--local DialogLoader = require("DialogLoader")
--local Terrain = require('terrain')
local lfs = require("lfs")
--local socket = require("socket")

local logFile = io.open(lfs.writedir() .. [[Logs\DCSDTCHook.log]], "w")
local hook = nil
local inMission = false

local function loadHookLogic()
    if hook then
        hook:dispose()
    end
    hook = loadfile(lfs.writedir() .. 'Scripts/DCSDTC/hook.lua')()
    hook.logFile = logFile
    if inMission then
        hook:onMissionLoadEnd()
    end
    log.write("DCS-DTC", log.INFO, "DTC Hook reloaded")
end

loadHookLogic()

local function initDTCHook()
    local handler = {}

    function handler.onMissionLoadEnd()
        inMission = true
        hook:onMissionLoadEnd()
    end

    function handler.onSimulationFrame()
        if hook:needReload() then
            loadHookLogic()
        end
        hook:onSimulationFrame()
    end

    function handler.onSimulationStop()
        inMission = false
        hook:onSimulationStop()
    end

    DCS.setUserCallbacks(handler)
end

local status, err = pcall(initDTCHook)
if not status then
    hook:log("Error: " .. err)
end
log.write("DCS-DTC", log.INFO, "DTC Hook initialized")
