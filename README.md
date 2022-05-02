# DCS DTC

https://github.com/the-paid-actor/dcs-dtc

This is a mod for DCS that works as a DTC (Data Cartridge) for the F-16 and F/A-18.

Features:

- Allows uploading to the F-16 cockpit:
  - Waypoints
  - Countermeasure settings
  - Radios
  - MFD pages settings for the major modes (NAV, AA, AG, DGFT, MSL)
- Allows uploading to the F/A-18 cockpit:
  - Waypoints
  - Waypoint sequences
  - Countermeasure settings
  - Weapon Pre-Planned coordinates
  - Radios
  - Bingo fuel setting
  - Radar/Barometric altitude warning setting
  - AP BLIM setting
  - TACAN Channel/Band setting
- Enables you to share and receive settings from other people using this mod, either by file or clipboard
- Allows capturing a waypoint coordinate using the F10 view in DCS, or a "markpoint" by flying over a point in the map.

## Requirements

This application is written using .NET Framework 4.7.2. You may want to download the latest version from the Microsoft website.

## Installation

- Grab the zip file from the Releases tab on Github.
- Unzip it into a folder of your choice.
- Copy the DCSDTC.lua file into `C:\Users\<your user name>\Saved Games\DCS\Scripts`. Substitute `C:` for the drive 
  where your Windows is installed and `DCS` for `DCS.openbeta` if you are on the beta version.
- In that same folder, edit a file named `Export.lua`. If the file does not exists, create it yourself.
- Add the following line to the end of the file, if its not there already:

```lua
local DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/DCSDTC.lua')
```

## Limitations
Some settings in the F/A-18 are depending on the initial status and are thus not idempotent.
If the current status deviates from the default setting, it may not work at all or produce results different from what's intended.
Affected by this are the following features:
  - Countermeasure settings
  - Bingo fuel setting
  - AP BLIM setting
  - Pre-Planned coordinates

The setting of Pre-Planned coordinates relies on the settings for all stations being correct. 
If those settings are not correct, results may vary from everything working fine, the coordinates being set on the wrong station or any station not receving the set coordinates.
## Help

Contact me on Discord (The_Paid_Actor#1368) if you have issues, questions or suggestions.

## Credits

This uses some code and inspiration from DCS The Way mod by Comrade Doge. Link to the repository:
https://github.com/aronCiucu/DCSTheWay
