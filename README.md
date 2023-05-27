# DCS DTC

https://github.com/the-paid-actor/dcs-dtc

This is a mod for DCS that works as a DTC (Data Cartridge) for the F-16 and F/A-18.

# Features

- Allows uploading to the F-16 cockpit:
  - Waypoints
  - Countermeasure settings
  - Radios
  - MFD pages settings for the major modes (NAV, AA, AG, DGFT, MSL)
  - HARM threat tables
  - HTS threat tables and class selection
  - Bingo fuel setting
  - Low altitude warning settings
  - TGP laser and LST codes
  - TACAN channel and ILS frequency
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
- Saves the settings and presets in the DCS-DTC folder under Documents.

# Requirements

This application is written using .NET Framework 4.7.2. You may want to download the latest version from the Microsoft website.

# Installation

- Grab the latest installer from the Releases tab on Github (the file with msi extension).
- Run the installer. It will create a shortcut on the Start Menu once it finishes.
- Run the application. It will setup itself into DCS automatically.

## Manual setup in DCS

If for some reason you need to manually setup the application in DCS, follow these steps:
- Copy the DCSDTC.lua file from the application install folder into `C:\Users\<your user name>\Saved Games\DCS\Scripts`. Substitute `C:` for the drive 
  where your Windows is installed and `DCS` for `DCS.openbeta` if you are on the beta version.
- In that same folder, edit a file named `Export.lua`. If the file does not exists, create it yourself.
- Add the following line to the end of the file, if its not there already:

```lua
local DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/DCSDTC.lua')
```

# In-cockpit Controls

The mod features usage of unused cockpit buttons in DCS to show/hide the app, and to upload the preset.

## For the Viper:
- pressing the "WX" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- the FLIR increment switch shows the DTC app, while the FLIR decrement switch hides it.

## For the Hornet:

- pressing the "I/P" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- flipping the HUD Video Control switch (right below the BCN button on the UFC) to the up position shows the DTC app, while flipping the switch to the down position hides it.

# Limitations
Some settings in the F/A-18 are depending on the initial status and are thus not idempotent.
If the current status deviates from the default setting, it may not work at all or produce results different from what's intended.
Affected by this are the following features:
  - Countermeasure settings
  - Bingo fuel setting
  - AP BLIM setting
  - Pre-Planned coordinates

The setting of Pre-Planned coordinates relies on the settings for all stations being correct. If those settings are not correct, results may vary from everything working fine, the coordinates being set on the wrong station or any station not receving the set coordinates.

# Help

There is a Discord channel to report bugs, send suggestions and chat with other users. You can join it here:
https://discord.gg/saCACg99EZ

# Credits

See the contributors (https://github.com/the-paid-actor/dcs-dtc/graphs/contributors) page for the list of people who contributed to this project.

This uses some code and inspiration from DCS The Way mod by Comrade Doge. Link to the repository:
https://github.com/aronCiucu/DCSTheWay
