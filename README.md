# **DTC for DCS**

https://github.com/the-paid-actor/dcs-dtc

This is a mod for DCS that works as a DTC (Data Cartridge) for the F-16, F/A-18 and F-15E.

- **Create and recall presets** for each mission / server you fly, or however you want to organize your settings. These are saved in the DCS-DTC folder under Documents.
- **Upload** the settings from a preset to the aircraft.
- Enables you to **share and receive** settings from other people using this mod, either by file or clipboard.
- VR-compatible method to **capture coordinates** using the F10 map view in DCS, or a "markpoint" by flying over a point in the map. Use the Ctrl+Shift+D shortcut to bring a capture dialog inside DCS.

**For real-time support, bug reporting and feature suggestions** use the Discord channel - https://discord.gg/saCACg99EZ

# Features by aircraft

## Viper
  - Waypoints
    - Coordinates / elevation
    - Time over steerpoint
    - Offset aimpoints
    - VIP / VRP settings
  - Countermeasure programs and bingo settings
  - Radios
  - MFD page settings for all master modes (NAV, AA, AG, DGFT, MSL)
  - HARM threat tables
  - HTS threat tables and class selection
  - Bingo fuel setting
  - Bullseye setting
  - Low altitude warning settings
  - TGP laser and LST codes and auto-lasing timer
  - TACAN channel and ILS frequency

## Hornet

  - Waypoints
  - Waypoint sequences
  - JDAM/JSOW/SLAM pre-planned coordinates
  - SLAM-ER waypoints
  - Countermeasure programs
  - Radios
  - Bingo fuel setting
  - Bullseye setting
  - Radar/Barometric altitude warning setting
  - AP BLIM setting
  - TACAN Channel/Band and ILS channel
  - HSI Map visibility

## Strike Eagle

- Sequence Points and Target Points
- Display settings for the Pilot and WSO
- Radio Settings and Presets
- Bingo fuel setting
- Radar altitude warning setting
- TACAN Channel/Band and ILS frequency

# Requirements

This application is written using .NET 7.0. You may want to download the latest version from the Microsoft website. Look for the .NET Desktop Runtime on the link below.

https://dotnet.microsoft.com/en-us/download/dotnet/7.0

# Installation

- Grab the latest installer from the Releases tab on Github (the file with msi extension).
- Run the installer. It will create a shortcut on the Start Menu once it finishes.
- Run the application. It will setup itself into DCS automatically.

## Manual setup in DCS

If for some reason you need to manually setup the application in DCS, follow these steps:
- Copy the all the files from `C:\Program Files (x86)\DCS-DTC\DCS` into `C:\Users\<your user name>\Saved Games\DCS\Scripts`. Substitute `C:` for the drive 
  where your Windows is installed and `DCS` for `DCS.openbeta` if you are on the beta version.
- In that same folder, edit a file named `Export.lua`. If the file does not exists, create it yourself.
- Add the following line to the end of the file, if its not there already:

```lua
local DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/DCSDTC.lua')
```

# In-cockpit Controls

The mod features usage of unused cockpit buttons in DCS to show/hide the app, and to upload the preset.

## Viper

- pressing the "WX" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- the FLIR increment switch shows the DTC app, while the FLIR decrement switch hides it.

## Hornet

- pressing the "I/P" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- flipping the HUD Video Control switch (right below the BCN button on the UFC) to the up position shows the DTC app, while flipping the switch to the down position hides it.

## Strike Eagle

- pressing the "I/P" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- pressing the "EM" button on the UFC will toggle visibility of the DTC app

# Limitations

## Hornet

Some settings in the F/A-18 are depending on the initial status and are thus not idempotent.
If the current status deviates from the default setting, it may not work at all or produce results different from what's intended.
Affected by this are the following features:
  - Countermeasure settings
  - Bingo fuel setting
  - Pre-Planned coordinates

The setting of Pre-Planned coordinates relies on the settings for all stations being correct. If those settings are not correct, results may vary from everything working fine, the coordinates being set on the wrong station or any station not receving the set coordinates.

## Strike Eagle

If you have displays already programmed in the jet, the app will skip uploading the new displays configuration. This will be improved in a future version.

From either seat (pilot/WSO) it is not possible to change displays on the other seat, given that the displays are only rendered when you occupy the respective position. That is the reason for the exclusive choice in the Upload page between uploading Pilot or WSO displays.

Furthermore, the other settings (Waypoints, Radios, Misc) are only tested to work from the pilot seat. Currently there is no way to detect which seat is occupied from the LUA API. If such means become available in the future, a more streamlined system can be developed.

Therefore, the suggestion is for the pilot to upload everything except the WSO displays, and the WSO upload only its displays.

# Help

There is a Discord channel to report bugs, send suggestions and chat with other users. You can join it here:
https://discord.gg/saCACg99EZ

# Credits

See the contributors (https://github.com/the-paid-actor/dcs-dtc/graphs/contributors) page for the list of people who contributed to this project.

This uses some code and inspiration from DCS The Way mod by Comrade Doge. Link to the repository:
https://github.com/aronCiucu/DCSTheWay
