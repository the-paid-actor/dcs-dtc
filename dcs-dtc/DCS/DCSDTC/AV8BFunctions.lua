dofile(lfs.writedir()..'Scripts/DCSDTC/commonFunctions.lua')


function DTC_AV8B_GetLeftmMFD()
    return DTC_ParseDisplay(3)
end




local function DTC_AV8B_SetLeftMfd1()
    local table = DTC_AV8B_GetLeftmMFD();
    local str1 = table["EHSD_PB02_OL"] or ""  -- jei D , tai prasinis langas su DATA
    DTC_Log("str1="..DTC_trim(str1).."]")
    if DTC_trim(str1) == "D" then 
      return true
    end

    local str2 = table["PB02"] or ""   -- jeie e tai langas su FEHSD
    DTC_Log("str2=["..DTC_trim(str2).."]")
    if DTC_trim(str2) == "E" then 
       DTC_ExecCommand(26, 3201, 150, 1, 100)
       return false 

    else 
      DTC_ExecCommand(26, 3217, 150, 1, 150)
    end  

    return false
end

function DTC_AV8B_ExecCmd_SetLeftMfd() 
   for id = 1, 5 do
      if DTC_AV8B_SetLeftMfd1() == true then 
         return true; 
      end 
   end

  return false
end


function DTC_AV8B_AfterNextFrame(params)
  --  local mainPanel = GetDevice(0);
  -- params["uploadCommand"] = "1"
end
