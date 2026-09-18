dofile(lfs.writedir() .. 'Scripts/DCSDTC/commonFunctions.lua')

function  DTC_OH58D_ExecCmd_setType(chanId, need_man, autoChan)
    local table = DTC_GetDisplay(8)
    local value = table["CHNL" .. chanId .. ".1"] or ""

    if need_man == 1 then

       if value == "M" then
         return -1
       end

      if value == "C" then
         DTC_ExecCommand(42, 3069, 150,-1)
         return -2
      end

      for i = 1, tonumber(value) or 0 do
            DTC_ExecCommand(42, 3069,150, -1)
      end
      return -tonumber(value)
    end

    local plus = 0


    if value == "C" then
        DTC_ExecCommand(42, 3069,150, 1) 
        value = "M"
    end 
    
    if value == "M" then
        DTC_ExecCommand(42, 3069,150, 1) 
        value = 1
    end 
    
    if tonumber(value) == tonumber(autoChan) then
        return {plus}
    end
     
   plus = autoChan - (tonumber(value) or 0)
    

     if plus>0 then
       for i = 1, plus do
            DTC_ExecCommand(42, 3069,150, 1) 
       end
        
      elseif plus<0 then    
        for i = 1, -plus do
          DTC_ExecCommand(42, 3069,150, -1) 
        end
        
     end    
    return {plus}
end

function  DTC_OH58D_ExecCmd_ToCommsPage()
    local table = DTC_GetDisplay(3)
    local value = table["L2.2.L2_TEXT.2"] or ""
    if string.sub(value, 1, 3) ~= "UHF" then
        DTC_ExecCommand(11, 3011, 150, 1)
    end 
    return string.sub(value, 1, 3)

end

function DTC_OH58D_ExecCmd_ToWpPage(attempt)
    attempt = attempt or 1
    if attempt > 10 then
        return false
    end

    local table = DTC_GetDisplay(3)

    local ct1 = table["CT.1"] or ""
    if ct1 == "NEW WAYPOINT" then
        return true
    end

    local pageLine1 = table["R2.2.R2_TEXT.1"] or ""
    local pageLine2 = table["R2.2.R2_TEXT.2"] or ""

    if DTC_trim(pageLine1) ~= "NAV" or DTC_trim(pageLine2) ~= "SETUP" then
        DTC_ExecCommand(11, 3009, 150, 1) --B2
        DTC_Wait(100)
        return DTC_OH58D_ExecCmd_ToWpPage(attempt + 1) 
    end
        
    DTC_ExecCommand(11, 3014, 150, 1) --R2
    DTC_ExecCommand(11, 3004, 150, 1) --L4
    
    table = DTC_GetDisplay(3)
    local coordFormat = table["CT2.1"] or ""
    if DTC_trim(coordFormat) == "UTM" then
        DTC_ExecCommand(11, 3016, 150, 1)
    end

 return true
end




function DTC_OH58D_AfterNextFrame(params)
    local mainPanel = GetDevice(0)
    local iffBtn = mainPanel:get_argument_value(209)

    if iffBtn == 1 then
        params["uploadCommand"] = "1"
    end
end
