local dxgui = require('dxgui')
local DialogLoader = require("DialogLoader")
local ListBoxItem = require('ListBoxItem')
local lfs = require("lfs")

local pointTypes = {
  [1] = {
    Code = "WP",
    Name = "Waypoint",
    Identifiers = {
      [1] = {Code = "CC", Name = "Communications Check Point", Description = "A radio message should be sent upon arrival/crossing"},
      [2] = {Code = "LZ", Name = "Landing Zone", Description = "Helicopter landing or pickup location of ground troops"},
      [3] = {Code = "PP", Name = "Passage Point", Description = "Passage across friendly front line positions"},
      [4] = {Code = "RP", Name = "Release Point", Description = "Final point of navigation route"},
      [5] = {Code = "SP", Name = "Start Point", Description = "First point of navigation route"},
      [6] = {Code = "WP", Name = "Waypoint", Description = "Point used for navigation or routing"},
    }
  },
  [2] = {
    Code = "HZ",
    Name = "Hazard",
    Identifiers = {
      [1] = {Code = "TO", Name = "Tower, Over 1000ft", Description = "Vertical tower hazard >1000 feet AGL"},
      [2] = {Code = "TU", Name = "Tower, Under 1000ft", Description = "Vertical tower hazard <1000 feet AGL"},
      [3] = {Code = "WL", Name = "Wires, Power", Description = "Tall linear wire hazard"},
      [4] = {Code = "WS", Name = "Wires, Telephone/Electric", Description = "Short linear wire Hazards"},
    },
  },
  [3] = {
    Code = "GC",
    Name = "General Control Measure",
    Identifiers = {
      [1]  = {Code = "AP", Name = "Air Control Point", Description = "Point used for control or timing of aircraft movement"},
      [2]  = {Code = "AG", Name = "Airfield, General", Description = "Large airfield without navigational aids"},
      [3]  = {Code = "AI", Name = "Airfield, Instrumented", Description = "Large airfield with navigational aids"},
      [4]  = {Code = "F1", Name = "Artillery Firing Point 1", Description = "1st portion of Artillery Firing Point (i.e., AB1___)"},
      [5]  = {Code = "F2", Name = "Artillery Firing Point 2", Description = "2nd portion of Artillery Firing Point (i.e., ___234)"},
      [6]  = {Code = "AA", Name = "Assembly Area", Description = "Rear area for assembly of friendly forces"},
      [7]  = {Code = "BN", Name = "Battalion", Description = "Battalion echelon, below Brigade but above Company"},
      [8]  = {Code = "BP", Name = "Battle Position", Description = "Position used for engaging enemy forces"},
      [9]  = {Code = "BR", Name = "Bridge/Gap", Description = "Bridge across an obstacle or a passable gap in terrain"},
      [10] = {Code = "BD", Name = "Brigade", Description = "Brigade echelon, below Division but above Battalion"},
      [11] = {Code = "CP", Name = "Checkpoint", Description = "Reference point used for maneuver and orientation"},
      [12] = {Code = "CO", Name = "Company", Description = "Company echelon, below Battalion but above Platoon"},
      [13] = {Code = "CR", Name = "Corps", Description = "Corps echelon, above Division but below U.S. Army"},
      [14] = {Code = "ID", Name = "Datalink Subscriber", Description = "ID and position of datalink network subscriber"},
      [15] = {Code = "DI", Name = "Division", Description = "Division echelon, above Brigade but below Corps"},
      [16] = {Code = "FM", Name = "FARP, Ammo only", Description = "Forward Arming & Refueling Point with munitions"},
      [17] = {Code = "FC", Name = "FARP, Fuel and Ammo", Description = "Forward Arming & Refueling Point with fuel/munitions"},
      [18] = {Code = "FF", Name = "FARP, Fuel only", Description = "Forward Arming & Refueling Point with fuel"},
      [19] = {Code = "FA", Name = "Forward Assembly Area", Description = "Forward area for assembly of friendly forces"},
      [20] = {Code = "GL", Name = "Ground Light/Small Town", Description = "Visual reference point used for navigation/orientation"},
      [21] = {Code = "HA", Name = "Holding Area", Description = "Brief holding area while enroute to/from mission area"},
      [22] = {Code = "AL", Name = "Lighted Airport", Description = "Small lighted airfield"},
      [23] = {Code = "NB", Name = "NBC Area", Description = "Nuclear, Biological, or Chemical contaminated area"},
      [24] = {Code = "BE", Name = "NDB Symbol", Description = "Non-Directional Beacon navigational aid"},
      [25] = {Code = "RH", Name = "Railhead Point", Description = "Location for loading/unloading cargo from trains"},
      [26] = {Code = "GP", Name = "Regiment/Group", Description = "Regiment echelon, above Battalion but below Division"},
      [27] = {Code = "US", Name = "U.S. Army", Description = "U.S. Army echelon, above Corps"},
    },
  },
  [4] = {
    Code = "FC",
    Name = "Friendly Control Measure",
    Identifiers = {
      [1]  = {Code = "AS", Name = "Friendly Air Assault", Description = "Friendly helicopter-borne infantry unit position"},
      [2]  = {Code = "AV", Name = "Friendly Air Cavalry", Description = "Friendly scout/cavalry helicopter position"},
      [3]  = {Code = "AD", Name = "Friendly Air Defense", Description = "Friendly air defense unit/command position"},
      [4]  = {Code = "AB", Name = "Friendly Airborne", Description = "Friendly paratrooper unit position"},
      [5]  = {Code = "AM", Name = "Friendly Armor", Description = "Friendly armor unit position"},
      [6]  = {Code = "CA", Name = "Friendly Armored Cavalry", Description = "Friendly recon/cavalry ground unit position"},
      [7]  = {Code = "AH", Name = "Friendly Attack Helicopter", Description = "Friendly attack helicopter position"},
      [8]  = {Code = "MA", Name = "Friendly Aviation Maintenance", Description = "Friendly helicopter maintenance unit position"},
      [9]  = {Code = "CF", Name = "Friendly Chemical", Description = "Friendly chemical unit position"},
      [10] = {Code = "DF", Name = "Friendly Decontamination", Description = "Friendly decontamination site"},
      [11] = {Code = "FW", Name = "Friendly Electronic Warfare", Description = "Friendly electronic warfare unit position"},
      [12] = {Code = "EN", Name = "Friendly Engineers", Description = "Friendly engineer unit position"},
      [13] = {Code = "FL", Name = "Friendly Field Artillery", Description = "Friendly artillery/MLRS firing position"},
      [14] = {Code = "WF", Name = "Friendly Fixed Wing", Description = "Friendly fixed-wing airbase/staging area"},
      [15] = {Code = "FG", Name = "Friendly Helicopter, General", Description = "Friendly cargo/utility helicopter position"},
      [16] = {Code = "HO", Name = "Friendly Hospital", Description = "Friendly medical facility/trauma care station"},
      [17] = {Code = "FI", Name = "Friendly Infantry", Description = "Friendly infantry unit position"},
      [18] = {Code = "MI", Name = "Friendly Mechanized Infantry", Description = "Friendly mechanized infantry/motor rifle unit position"},
      [19] = {Code = "MD", Name = "Friendly Medical", Description = "Friendly medical unit position/aid station"},
      [20] = {Code = "TF", Name = "Friendly Tactical Operations Center", Description = "Friendly headquarters/command unit position"},
      [21] = {Code = "FU", Name = "Friendly Unit", Description = "Generic friendly unit position/marker"},
    },
  },
  [5] = {
    Code = "EC",
    Name = "Enemy Control Measure",
    Identifiers = {
      [1]  = {Code = "ES", Name = "Enemy Air Assault", Description = "Enemy helicopter-borne infantry unit position"},
      [2]  = {Code = "EV", Name = "Enemy Air Cavalry", Description = "Enemy scout/cavalry helicopter position"},
      [3]  = {Code = "ED", Name = "Enemy Air Defense", Description = "Enemy air defense unit/command position"},
      [4]  = {Code = "EB", Name = "Enemy Airborne", Description = "Enemy paratrooper unit position"},
      [5]  = {Code = "AE", Name = "Enemy Armor", Description = "Enemy armor unit position"},
      [6]  = {Code = "EC", Name = "Enemy Armored Cavalry", Description = "Enemy recon/cavalry ground unit position"},
      [7]  = {Code = "EK", Name = "Enemy Attack Helicopter", Description = "Enemy attack helicopter position"},
      [8]  = {Code = "ME", Name = "Enemy Aviation Maintenance", Description = "Enemy helicopter maintenance unit position"},
      [9]  = {Code = "CE", Name = "Enemy Chemical", Description = "Enemy chemical unit position"},
      [10] = {Code = "DE", Name = "Enemy Decontamination", Description = "Enemy decontamination site"},
      [11] = {Code = "WR", Name = "Enemy Electronic Warfare", Description = "Enemy electronic warfare unit position"},
      [12] = {Code = "EE", Name = "Enemy Engineers", Description = "Enemy engineer unit position"},
      [13] = {Code = "EF", Name = "Enemy Field Artillery", Description = "Enemy artillery/MLRS firing position"},
      [14] = {Code = "WE", Name = "Enemy Fixed Wing", Description = "Enemy fixed-wing airbase/staging area"},
      [15] = {Code = "HG", Name = "Enemy Helicopter, General", Description = "Enemy cargo/utility helicopter position"},
      [16] = {Code = "EH", Name = "Enemy Hospital", Description = "Enemy medical facility/trauma care station"},
      [17] = {Code = "EI", Name = "Enemy Infantry", Description = "Enemy infantry unit position"},
      [18] = {Code = "EM", Name = "Enemy Mechanized Infantry", Description = "Enemy mechanized infantry/motor rifle unit position"},
      [19] = {Code = "EX", Name = "Enemy Medical", Description = "Enemy medical unit position/aid station"},
      [20] = {Code = "ET", Name = "Enemy Tactical Operations Center", Description = "Enemy headquarters/command unit position"},
      [21] = {Code = "EU", Name = "Enemy Unit", Description = "Generic enemy unit position/marker"},
    },
  },
  [6] = {
    Code = "TG",
    Name = "Target",
    Identifiers = {
      {Code = "TG", Name = "Target Point", Description = "Target reference point"},
    },
  },
  [7] = {
    Code = "TH",
    Name = "Threat",
    Identifiers = {
      [1]  = {Code = "S6", Name = "2S6/SA-19 Air Defense Unit", Description = "2S6M Tunguska SAM/SPAAA vehicle"},
      [2]  = {Code = "AA", Name = "Air Defense Gun", Description = "S-60 57mm AA battery w/ SON-9 fire control radar"},
      [3]  = {Code = "AX", Name = "AMX-13 Air Defense Gun", Description = nil},
      [4]  = {Code = "AS", Name = "Aspide SAM System", Description = nil},
      [5]  = {Code = "SR", Name = "Battlefield Surveillance Radar", Description = "Early warning/search radar, 100km threat ring"},
      [6]  = {Code = "BH", Name = "Bloodhound SAM System", Description = nil},
      [7]  = {Code = "BP", Name = "Blowpipe SAM System", Description = nil},
      [8]  = {Code = "CH", Name = "Chapparal SAM System", Description = "M48 SAM vehicle"},
      [9]  = {Code = "CT", Name = "Crotale SAM System", Description = "HQ-7 SAM battery"},
      [10] = {Code = "C2", Name = "CSA-2/1/X SAM System", Description = nil},
      [11] = {Code = "AD", Name = "Friendly Air Defense Unit", Description = "Generic 8 km threat ring"},
      [12] = {Code = "GU", Name = "Generic Air Defense Unit", Description = "Generic 5 km threat ring"},
      [13] = {Code = "GP", Name = "Gepard Air Defense Gun", Description = "Flakpanzer Gepard 30mm SPAAA vehicle"},
      [14] = {Code = "G1", Name = "Growth 1", Description = "Generic 1 km threat ring"},
      [15] = {Code = "G2", Name = "Growth 2", Description = "Generic 2 km threat ring"},
      [16] = {Code = "G3", Name = "Growth 3", Description = "Generic 3 km threat ring"},
      [17] = {Code = "G4", Name = "Growth 4", Description = "Generic 4 km threat ring"},
      [18] = {Code = "HK", Name = "Hawk SAM System", Description = "MIM-23B SAM battery"},
      [19] = {Code = "JA", Name = "Javelin SAM System", Description = nil},
      [20] = {Code = "83", Name = "M1983 Air Defense Gun", Description = nil},
      [21] = {Code = "MK", Name = "Marksman Air Defense Gun", Description = nil},
      [22] = {Code = "NV", Name = "Naval Air Defense System", Description = nil},
      [23] = {Code = "PT", Name = "Patriot SAM System", Description = "MIM-104C SAM battery"},
      [24] = {Code = "RA", Name = "Rapier SAM System", Description = "Rapier FSA SAM battery"},
      [25] = {Code = "70", Name = "RBS-70 SAM System", Description = nil},
      [26] = {Code = "RE", Name = "Redeye SAM System", Description = nil},
      [27] = {Code = "RO", Name = "Roland SAM System", Description = "Marder Roland SAM vehicle"},
      [28]  = {Code = "1", Name = "SA-1 SAM System", Description = nil},
      [29]  = {Code = "10", Name = "SA-10 SAM System", Description = "S-300PS SAM battery"},
      [30]  = {Code = "11", Name = "SA-11 SAM System", Description = "9K37M Buk-M1 battery"},
      [31]  = {Code = "12", Name = "SA-12 SAM System", Description = nil},
      [32]  = {Code = "13", Name = "SA-13 SAM System", Description = "9K13 Strela-10M3 SAM vehicle"},
      [33]  = {Code = "14", Name = "SA-14 SAM System", Description = nil},
      [34]  = {Code = "15", Name = "SA-15 SAM System", Description = "9K331 Tor-M1 SAM vehicle"},
      [35]  = {Code = "16", Name = "SA-16 SAM System", Description = "Igla/Igla-S MANPADS position [used for SA-18 threat]"},
      [36]  = {Code = "17", Name = "SA-17 SAM System", Description = nil},
      [37] = {Code = "2", Name = "SA-2 SAM System", Description = "S-75 SAM battery"},
      [38] = {Code = "3", Name = "SA-3 SAM System", Description = "S-125 SAM battery"},
      [39] = {Code = "4", Name = "SA-4 SAM System", Description = nil},
      [40] = {Code = "5", Name = "SA-5 SAM System", Description = "S-200 SAM battery"},
      [41] = {Code = "6", Name = "SA-6 SAM System", Description = "2K12 Kub SAM battery"},
      [42] = {Code = "7", Name = "SA-7 SAM System", Description = nil},
      [43] = {Code = "8", Name = "SA-8 SAM System", Description = "9K33 Osa SAM vehicle"},
      [44] = {Code = "9", Name = "SA-9 SAM System", Description = "9K31 Strela-1 SAM vehicle"},
      [45] = {Code = "SB", Name = "Sabre Air Defense Gun", Description = nil},
      [46] = {Code = "SM", Name = "SAMP SAM System", Description = nil},
      [47] = {Code = "SC", Name = "SATCP SAM System", Description = nil},
      [48] = {Code = "GS", Name = "Self-Propelled Air Defense Gun", Description = "ZSU-57-2 57mm SPAAA vehicle"},
      [49] = {Code = "SP", Name = "Self-Propelled SAM System", Description = nil},
      [50] = {Code = "SH", Name = "Shahine/R440 SAM System", Description = nil},
      [51] = {Code = "SD", Name = "Spada SAM System", Description = nil},
      [52] = {Code = "SS", Name = "Starstreak SAM System", Description = nil},
      [53] = {Code = "ST", Name = "Stinger SAM System", Description = "Avenger SAM vehicle/Stinger MANPADS position"},
      [54] = {Code = "TR", Name = "Target Acquisition Radar", Description = "PPRU-M1 Sborka air defense coordination radar"},
      [55]  = {Code = "TC", Name = "Tigercat SAM System", Description = nil},
      [56]  = {Code = "GT", Name = "Towed Air Defense Gun", Description = "ZU-23-2 23mm AA emplacement"},
      [57]  = {Code = "SA", Name = "Towed SAM System", Description = "NASAMS 2 SAM battery"},
      [58]  = {Code = "U", Name = "Unknown Air Defense Unit", Description = "Insurgent technical vehicle w/ 23mm AA gun"},
      [59]  = {Code = "VU", Name = "Vulcan Air Defense Gun", Description = "M163 Vulcan SPAAA vehicle"},
      [60]  = {Code = "ZU", Name = "ZSU-23-4 Air Defense Gun", Description = "ZSU-23-4 23mm SPAAA vehicle"},
    },
  },
}

local DTCWptCaptureAH64D = {
    width = 360,
    height = 140,
    dialog = nil,
    visible = false,
    buttonSkin = nil,
}

function DTCWptCaptureAH64D:init(eventCallback)
    local screenWidth, screenHeight = dxgui.GetScreenSize()
    local x = (screenWidth / 2) - 19
    local y = (screenHeight / 2) - 19

    self.buttonSkin = eventCallback:getSkin("buttonSkin");

    self.dialog = DialogLoader.spawnDialogFromFile(lfs.writedir() .. "Scripts\\DCSDTC\\wptCaptureAH64D.dlg")

    self.dialog:setVisible(true)
    self.dialog:setBounds(math.floor(x) - self.width - 20, math.floor(y), self.width, self.height)

    self.dialog.btnOK:setSkin(self.buttonSkin)
    self.dialog.btnOK:addMouseUpCallback(function() 
        local pointType = self.dialog.cboPointType:getSelectedItem()
        local identifier = self.dialog.cboIdentifier:getSelectedItem()
        if identifier == nil then
            return
        end

        local free = self.dialog.txtFree:getText():sub(1,3):gsub("%s+", "")
        if free == "" then free = nil end
        eventCallback:addApacheCoord(pointType.pointType.Code, identifier.identifier.Code, free)
    end)

    self.dialog.btnClose:setSkin(self.buttonSkin)
    self.dialog.btnClose:addMouseUpCallback(function() eventCallback:addButtonApache() end)

    for _, pointType in ipairs(pointTypes) do
        local item = ListBoxItem.new(pointType.Name)
        item.pointType = pointType
        self.dialog.cboPointType:insertItem(item)
    end

    self.dialog.cboPointType:addChangeCallback(function() 
        self.dialog.cboIdentifier:clear()
        local pointType = nil
        for _, pt in ipairs(pointTypes) do
            if pt.Name == self.dialog.cboPointType:getText() then
                pointType = pt
                break
            end
        end

        if pointType ~= nil then
            local count = 0
            for _, ident in ipairs(pointType.Identifiers) do
                local item = ListBoxItem.new(ident.Code .. " - " .. ident.Name)
                item.identifier = ident
                self.dialog.cboIdentifier:insertItem(item)
                count = count + 1
            end
            if count == 1 then
                self.dialog.cboIdentifier:selectItem(self.dialog.cboIdentifier:getItem(0))
            end
        end

    end)

    self:hide()
end

function DTCWptCaptureAH64D:hide()
    self.dialog:setHasCursor(false)
    self.dialog:setSize(0,0)
    self.visible = false
end

function DTCWptCaptureAH64D:show()
    self.dialog:setHasCursor(true)
    self.dialog:setSize(self.width, self.height)
    self.visible = true
end

function DTCWptCaptureAH64D:destroy()
    self.dialog:destroy()
end

return DTCWptCaptureAH64D;