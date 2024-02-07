
using Newtonsoft.Json;

namespace DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

public class Identifiers
{
    public Identifier[] Waypoints;
    public Identifier[] Hazards;
    public Identifier[] GeneralControlMeasures;
    public Identifier[] FriendlyControlMeasures;
    public Identifier[] EnemyControlMeasures;
    public Identifier[] Targets;
    public Identifier[] Threats;

    private static bool loaded = false;

    private static Identifiers singleton;

    public static Identifier[] GetIdentifiers(PointType type)
    {
        if (!loaded)
        {
            LoadLists();
            loaded = true;
        }

        if (type == PointType.Waypoint)
                return singleton.Waypoints;
        if (type == PointType.Hazard)
                return singleton.Hazards;
        if (type == PointType.GeneralControlMeasure)
                return singleton.GeneralControlMeasures;
        if (type == PointType.FriendlyControlMeasure)
                return singleton.FriendlyControlMeasures;
        if (type == PointType.EnemyControlMeasure)
                return singleton.EnemyControlMeasures;
        if (type == PointType.Target)
                return singleton.Targets;
        if (type == PointType.Threat)
                return singleton.Threats;

        throw new NotImplementedException();
    }

    private static void LoadLists()
    {
        singleton = new Identifiers();

        List<Identifier> wpts = new();
        List<Identifier> hzds = new();
        List<Identifier> gcms = new();
        List<Identifier> fcms = new();
        List<Identifier> ecms = new();
        List<Identifier> tgts = new();
        List<Identifier> thrts = new();

        //Waypoints (WPTHZ)

        wpts.Add(new Identifier("WP", "Waypoint", "Point used for navigation or routing"));
        wpts.Add(new Identifier("SP", "Start Point", "First point of navigation route"));
        wpts.Add(new Identifier("PP", "Passage Point", "Passage across friendly front line positions"));
        wpts.Add(new Identifier("RP", "Release Point", "Final point of navigation route"));
        wpts.Add(new Identifier("CC", "Communications Check Point", "A radio message should be sent upon arrival/crossing"));
        wpts.Add(new Identifier("LZ", "Landing Zone", "Helicopter landing or pickup location of ground troops"));
        singleton.Waypoints = wpts.OrderBy(i => i.Name).ToArray();

        //Hazards (WPTHZ)

        hzds.Add(new Identifier("TO", "Tower, Over 1000’", "Vertical tower hazard >1000 feet AGL"));
        hzds.Add(new Identifier("TU", "Tower, Under 1000’", "Vertical tower hazard <1000 feet AGL"));
        hzds.Add(new Identifier("WL", "Wires, Power", "Tall linear wire hazard"));
        hzds.Add(new Identifier("WS", "Wires, Telephone/Electric", "Short linear wire Hazards"));
        singleton.Hazards = hzds.OrderBy(i => i.Name).ToArray();

        //General Control Measures (CTRLM)

        gcms.Add(new Identifier("AP", "Air Control Point", "Point used for control or timing of aircraft movement"));
        gcms.Add(new Identifier("AG", "Airfield, General", "Large airfield without navigational aids"));
        gcms.Add(new Identifier("AI", "Airfield, Instrumented", "Large airfield with navigational aids"));
        gcms.Add(new Identifier("AL", "Lighted Airport", "Small lighted airfield"));
        gcms.Add(new Identifier("F1", "Artillery Firing Point 1", "1st portion of Artillery Firing Point (i.e., AB1___)"));
        gcms.Add(new Identifier("F2", "Artillery Firing Point 2", "2nd portion of Artillery Firing Point (i.e., ___234)"));
        gcms.Add(new Identifier("AA", "Assembly Area", "Rear area for assembly of friendly forces"));
        gcms.Add(new Identifier("BN", "Battalion", "Battalion echelon, below Brigade but above Company"));
        gcms.Add(new Identifier("BP", "Battle Position", "Position used for engaging enemy forces"));
        gcms.Add(new Identifier("BR", "Bridge/Gap", "Bridge across an obstacle or a passable gap in terrain"));
        gcms.Add(new Identifier("BD", "Brigade", "Brigade echelon, below Division but above Battalion"));
        gcms.Add(new Identifier("CP", "Checkpoint", "Reference point used for maneuver and orientation"));
        gcms.Add(new Identifier("CO", "Company", "Company echelon, below Battalion but above Platoon"));
        gcms.Add(new Identifier("CR", "Corps", "Corps echelon, above Division but below U.S. Army"));
        gcms.Add(new Identifier("DI", "Division", "Division echelon, above Brigade but below Corps"));
        gcms.Add(new Identifier("FF", "FARP, Fuel only", "Forward Arming & Refueling Point with fuel"));
        gcms.Add(new Identifier("FM", "FARP, Ammo only", "Forward Arming & Refueling Point with munitions"));
        gcms.Add(new Identifier("FC", "FARP, Fuel and Ammo", "Forward Arming & Refueling Point with fuel/munitions"));
        gcms.Add(new Identifier("FA", "Forward Assembly Area", "Forward area for assembly of friendly forces"));
        gcms.Add(new Identifier("GL", "Ground Light/Small Town", "Visual reference point used for navigation/orientation"));
        gcms.Add(new Identifier("HA", "Holding Area", "Brief holding area while enroute to/from mission area"));
        gcms.Add(new Identifier("NB", "NBC Area", "Nuclear, Biological, or Chemical contaminated area"));
        gcms.Add(new Identifier("ID", "Datalink Subscriber", "ID and position of datalink network subscriber"));
        gcms.Add(new Identifier("BE", "NDB Symbol", "Non-Directional Beacon navigational aid"));
        gcms.Add(new Identifier("RH", "Railhead Point", "Location for loading/unloading cargo from trains"));
        gcms.Add(new Identifier("GP", "Regiment/Group", "Regiment echelon, above Battalion but below Division"));
        gcms.Add(new Identifier("US", "U.S. Army", "U.S. Army echelon, above Corps"));
        singleton.GeneralControlMeasures = gcms.OrderBy(i => i.Name).ToArray();

        //Friendly Control Measures (CTRLM)

        fcms.Add(new Identifier("AD", "Friendly Air Defense", "Friendly air defense unit/command position"));
        fcms.Add(new Identifier("AS", "Friendly Air Assault", "Friendly helicopter-borne infantry unit position"));
        fcms.Add(new Identifier("AV", "Friendly Air Cavalry", "Friendly scout/cavalry helicopter position"));
        fcms.Add(new Identifier("AB", "Friendly Airborne", "Friendly paratrooper unit position"));
        fcms.Add(new Identifier("AM", "Friendly Armor", "Friendly armor unit position"));
        fcms.Add(new Identifier("CA", "Friendly Armored Cavalry", "Friendly recon/cavalry ground unit position"));
        fcms.Add(new Identifier("MA", "Friendly Aviation Maintenance", "Friendly helicopter maintenance unit position"));
        fcms.Add(new Identifier("CF", "Friendly Chemical", "Friendly chemical unit position"));
        fcms.Add(new Identifier("DF", "Friendly Decontamination", "Friendly decontamination site"));
        fcms.Add(new Identifier("EN", "Friendly Engineers", "Friendly engineer unit position"));
        fcms.Add(new Identifier("FW", "Friendly Electronic Warfare", "Friendly electronic warfare unit position"));
        fcms.Add(new Identifier("WF", "Friendly Fixed Wing", "Friendly fixed-wing airbase/staging area"));
        fcms.Add(new Identifier("FL", "Friendly Field Artillery", "Friendly artillery/MLRS firing position"));
        fcms.Add(new Identifier("AH", "Friendly Attack Helicopter", "Friendly attack helicopter position"));
        fcms.Add(new Identifier("FG", "Friendly Helicopter, General", "Friendly cargo/utility helicopter position"));
        fcms.Add(new Identifier("HO", "Friendly Hospital", "Friendly medical facility/trauma care station"));
        fcms.Add(new Identifier("FI", "Friendly Infantry", "Friendly infantry unit position"));
        fcms.Add(new Identifier("MI", "Friendly Mechanized Infantry", "Friendly mechanized infantry/motor rifle unit position"));
        fcms.Add(new Identifier("MD", "Friendly Medical", "Friendly medical unit position/aid station"));
        fcms.Add(new Identifier("TF", "Friendly Tactical Operations Center", "Friendly headquarters/command unit position"));
        fcms.Add(new Identifier("FU", "Friendly Unit", "Generic friendly unit position/marker"));
        singleton.FriendlyControlMeasures = fcms.OrderBy(i => i.Name).ToArray();

        //Enemy Control Measures (CTRLM)

        ecms.Add(new Identifier("ES", "Enemy Air Assault", "Enemy helicopter-borne infantry unit position"));
        ecms.Add(new Identifier("EV", "Enemy Air Cavalry", "Enemy scout/cavalry helicopter position"));
        ecms.Add(new Identifier("ED", "Enemy Air Defense", "Enemy air defense unit/command position"));
        ecms.Add(new Identifier("EB", "Enemy Airborne", "Enemy paratrooper unit position"));
        ecms.Add(new Identifier("EC", "Enemy Armored Cavalry", "Enemy recon/cavalry ground unit position"));
        ecms.Add(new Identifier("AE", "Enemy Armor", "Enemy armor unit position"));
        ecms.Add(new Identifier("ME", "Enemy Aviation Maintenance", "Enemy helicopter maintenance unit position"));
        ecms.Add(new Identifier("CE", "Enemy Chemical", "Enemy chemical unit position"));
        ecms.Add(new Identifier("DE", "Enemy Decontamination", "Enemy decontamination site"));
        ecms.Add(new Identifier("EE", "Enemy Engineers", "Enemy engineer unit position"));
        ecms.Add(new Identifier("WR", "Enemy Electronic Warfare", "Enemy electronic warfare unit position"));
        ecms.Add(new Identifier("EF", "Enemy Field Artillery", "Enemy artillery/MLRS firing position"));
        ecms.Add(new Identifier("WE", "Enemy Fixed Wing", "Enemy fixed-wing airbase/staging area"));
        ecms.Add(new Identifier("EK", "Enemy Attack Helicopter", "Enemy attack helicopter position"));
        ecms.Add(new Identifier("HG", "Enemy Helicopter, General", "Enemy cargo/utility helicopter position"));
        ecms.Add(new Identifier("EH", "Enemy Hospital", "Enemy medical facility/trauma care station"));
        ecms.Add(new Identifier("EI", "Enemy Infantry", "Enemy infantry unit position"));
        ecms.Add(new Identifier("EM", "Enemy Mechanized Infantry", "Enemy mechanized infantry/motor rifle unit position"));
        ecms.Add(new Identifier("EX", "Enemy Medical", "Enemy medical unit position/aid station"));
        ecms.Add(new Identifier("ET", "Enemy Tactical Operations Center", "Enemy headquarters/command unit position"));
        ecms.Add(new Identifier("EU", "Enemy Unit", "Generic enemy unit position/marker"));
        singleton.EnemyControlMeasures = ecms.OrderBy(i => i.Name).ToArray();

        //Target (TGT/THRT)

        tgts.Add(new Identifier("TG", "Target Point", "Target reference point"));
        singleton.Targets = tgts.OrderBy(i => i.Name).ToArray();

        //Threats (TGT/THRT)

        thrts.Add(new Identifier("AX", "AMX-13 Air Defense Gun"));
        thrts.Add(new Identifier("AS", "Aspide SAM System"));
        thrts.Add(new Identifier("AD", "Friendly Air Defense Unit", "Generic 8 km threat ring"));
        thrts.Add(new Identifier("GP", "Gepard Air Defense Gun", "Flakpanzer Gepard 30mm SPAAA vehicle"));
        thrts.Add(new Identifier("G1", "Growth 1", "Generic 1 km threat ring"));
        thrts.Add(new Identifier("G2", "Growth 2", "Generic 2 km threat ring"));
        thrts.Add(new Identifier("G3", "Growth 3", "Generic 3 km threat ring"));
        thrts.Add(new Identifier("G4", "Growth 4", "Generic 4 km threat ring"));
        thrts.Add(new Identifier("SD", "Spada SAM System"));
        thrts.Add(new Identifier("83", "M1983 Air Defense Gun"));
        thrts.Add(new Identifier("U", "Unknown Air Defense Unit", "Insurgent technical vehicle w/ 23mm AA gun"));
        thrts.Add(new Identifier("S6", "2S6/SA-19 Air Defense Unit", "2S6M Tunguska SAM/SPAAA vehicle"));
        thrts.Add(new Identifier("AA", "Air Defense Gun", "S-60 57mm AA battery w/ SON-9 fire control radar"));
        thrts.Add(new Identifier("GU", "Generic Air Defense Unit", "Generic 5 km threat ring"));
        thrts.Add(new Identifier("MK", "Marksman Air Defense Gun"));
        thrts.Add(new Identifier("SB", "Sabre Air Defense Gun"));
        thrts.Add(new Identifier("GS", "Self-Propelled Air Defense Gun", "ZSU-57-2 57mm SPAAA vehicle"));
        thrts.Add(new Identifier("GT", "Towed Air Defense Gun", "ZU-23-2 23mm AA emplacement"));
        thrts.Add(new Identifier("ZU", "ZSU-23-4 Air Defense Gun", "ZSU-23-4 23mm SPAAA vehicle"));
        thrts.Add(new Identifier("NV", "Naval Air Defense System"));
        thrts.Add(new Identifier("SR", "Battlefield Surveillance Radar", "Early warning/search radar, 100km threat ring"));
        thrts.Add(new Identifier("TR", "Target Acquisition Radar", "PPRU-M1 Sborka air defense coordination radar"));
        thrts.Add(new Identifier("70", "RBS-70 SAM System"));
        thrts.Add(new Identifier("BP", "Blowpipe SAM System"));
        thrts.Add(new Identifier("BH", "Bloodhound SAM System"));
        thrts.Add(new Identifier("CH", "Chapparal SAM System", "M48 SAM vehicle"));
        thrts.Add(new Identifier("CT", "Crotale SAM System", "HQ-7 SAM battery"));
        thrts.Add(new Identifier("C2", "CSA-2/1/X SAM System"));
        thrts.Add(new Identifier("HK", "Hawk SAM System", "MIM-23B SAM battery"));
        thrts.Add(new Identifier("JA", "Javelin SAM System"));
        thrts.Add(new Identifier("PT", "Patriot SAM System", "MIM-104C SAM battery"));
        thrts.Add(new Identifier("RE", "Redeye SAM System"));
        thrts.Add(new Identifier("RA", "Rapier SAM System", "Rapier FSA SAM battery"));
        thrts.Add(new Identifier("RO", "Roland SAM System", "Marder Roland SAM vehicle"));
        thrts.Add(new Identifier("1", "SA-1 SAM System"));
        thrts.Add(new Identifier("2", "SA-2 SAM System", "S-75 SAM battery"));
        thrts.Add(new Identifier("3", "SA-3 SAM System", "S-125 SAM battery"));
        thrts.Add(new Identifier("4", "SA-4 SAM System"));
        thrts.Add(new Identifier("5", "SA-5 SAM System", "S-200 SAM battery"));
        thrts.Add(new Identifier("6", "SA-6 SAM System", "2K12 Kub SAM battery"));
        thrts.Add(new Identifier("7", "SA-7 SAM System"));
        thrts.Add(new Identifier("8", "SA-8 SAM System", "9K33 Osa SAM vehicle"));
        thrts.Add(new Identifier("9", "SA-9 SAM System", "9K31 Strela-1 SAM vehicle"));
        thrts.Add(new Identifier("10", "SA-10 SAM System", "S-300PS SAM battery"));
        thrts.Add(new Identifier("11", "SA-11 SAM System", "9K37M Buk-M1 battery"));
        thrts.Add(new Identifier("12", "SA-12 SAM System"));
        thrts.Add(new Identifier("13", "SA-13 SAM System", "9K13 Strela-10M3 SAM vehicle"));
        thrts.Add(new Identifier("14", "SA-14 SAM System"));
        thrts.Add(new Identifier("15", "SA-15 SAM System", "9K331 Tor-M1 SAM vehicle"));
        thrts.Add(new Identifier("16", "SA-16 SAM System", "Igla/Igla-S MANPADS position [used for SA-18 threat]"));
        thrts.Add(new Identifier("17", "SA-17 SAM System"));
        thrts.Add(new Identifier("SM", "SAMP SAM System"));
        thrts.Add(new Identifier("SC", "SATCP SAM System"));
        thrts.Add(new Identifier("SP", "Self-Propelled SAM System"));
        thrts.Add(new Identifier("SH", "Shahine/R440 SAM System"));
        thrts.Add(new Identifier("SS", "Starstreak SAM System"));
        thrts.Add(new Identifier("TC", "Tigercat SAM System"));
        thrts.Add(new Identifier("ST", "Stinger SAM System", "Avenger SAM vehicle/Stinger MANPADS position"));
        thrts.Add(new Identifier("SA", "Towed SAM System", "NASAMS 2 SAM battery"));
        thrts.Add(new Identifier("VU", "Vulcan Air Defense Gun", "M163 Vulcan SPAAA vehicle"));
        singleton.Threats = thrts.OrderBy(i => i.Name).ToArray();
    }
}

public class Identifier
{
    public string Code { get; }
    public string Name { get; }
    public string Description { get; }

    public Identifier(string code, string name, string description = null)
    {
        Code = code;
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Code} - {Name}";
    }
}
