# **DTC for DCS**

https://github.com/the-paid-actor/dcs-dtc

This is a mod for DCS that works as a DTC (Data Cartridge) for the F-16, F/A-18 and F-15E.

- **Create and recall presets** for each mission / server you fly, or however you want to organize your settings. These are saved in the DCS-DTC folder under Documents.
- **Upload** the settings from a preset to the aircraft.
- Enables you to **share and receive** settings from other people using this mod, either by file or clipboard.
- VR-compatible method to **capture coordinates** using the F10 map view in DCS, or a "markpoint" by flying over a point in the map. Use the Ctrl+Shift+D shortcut to bring a capture dialog inside DCS.

**For real-time support, bug reporting and feature suggestions** use the Discord channel - https://discord.gg/saCACg99EZ

# Features

## General

- Ability to import flight plans from Combatflite
- Ability to convert coordinates between various formats (by clicking the ellipsis on the coordinate text fields)
- The coordinate text fields also accept pasting data directly from DCS Alt+click window

## Viper
  - Waypoints with Time Over Steerpoint, Offset aimpoints and VIP / VRP settings
  - Countermeasure programs and bingo settings
  - Radios (guard settings, frequencies and presets)
  - MFD page settings for all master modes (NAV, AA, AG, DGFT, MSL)
  - FCR settings (mode, azimuth, bars, range) for NAV, AA and MSL master modes
  - HARM threat tables
  - HTS threat tables and class selection
  - Datalink settings
  - Bingo fuel setting
  - Bullseye setting
  - Low altitude warning settings
  - TGP laser and LST codes and auto-lasing timer
  - TACAN channel and ILS frequency

## Hornet

  - Waypoints in PRECISE mode
  - Waypoint sequences
  - Countermeasure programs and settings
  - Radios (guard settings, frequencies and presets)
  - FCR settings for AMRAAM, Sparrow and Sidewinder
  - JDAM/JSOW/SLAM pre-planned coordinates
  - SLAM-ER waypoints
  - HMD reject settings
  - Bingo fuel setting
  - Bullseye setting
  - Radar/Barometric altitude warning setting
  - AP BLIM setting
  - TGP laser and LST codes
  - TACAN Channel/Band and ILS channel
  - HSI Map visibility

## Strike Eagle

- Uploads from either Pilot or WSO stations
- Sequence Points and Target Points for routes A, B and C
- Radios (guard settings, frequencies and presets)
- Display settings for the Pilot and WSO
- Smart Weapons coordinates
- Bingo fuel setting
- Radar altitude warning setting
- TACAN Channel/Band and ILS frequency

# Requirements

This application is written using .NET 7.0. You may want to download the latest version from the Microsoft website. Look for the .NET Desktop Runtime on the link below.

https://dotnet.microsoft.com/en-us/download/dotnet/7.0

# Installation

- Grab the latest installer from the Releases tab on Github (the file with msi extension).
- Run the installer. It will create a shortcut on the Start Menu once it finishes.
- Run the application from the Windows Start Menu. It will setup itself into DCS automatically.

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

The mod features usage of unused cockpit buttons in DCS to show/hide the app, and to upload the preset. **Keep in mind** that the commands to show the app only works if the app is already running and DCS is not in exclusive full screen or VR mode. It will put the app in front of DCS, so you can interact with it, otherwise you have to Alt+tab to it.

## Viper

- pressing the "WX" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- the FLIR increment switch shows the DTC app, while the FLIR decrement switch hides it.

## Hornet

- pressing the "I/P" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- flipping the HUD Video Control switch (right below the BCN button on the UFC) to the up position shows the DTC app, while flipping the switch to the down position hides it.

## Strike Eagle

- pressing the "I/P" button on the UFC for more than 1 second will command the upload of the current preset (you must be on the Upload page of the preset for this to happen)
- pressing the "EMIS LMT" button on the UFC will toggle visibility of the DTC app

# Capturing coordinates in DCS

By pressing Ctrl+Shift+D within DCS, a window with a crosshair will popup. By going into the F10 map and positioning the crosshair over a point of interest, you can capture the coordinates of that point as steerpoints or target points. Pressing "Send to DTC" will send the coordinates to the app, and pressing "Send to DTC + Jet" will save the coordinates into the app but also uploads these same coordinates into the aircraft. Otherwise the dialog is self-explanatory.

You can also capture coordinates this way directly into PP stations (Hornet) or Smart Weapons (Strike Eagle).

The shortcut can be changed by editing the dtc-settings.json file located in the Documents\DCS-DTC folder. After editing it, restart the DTC app and after the prompt, restart DCS as well. The shortcut has to be a valid keyboard combination not in use by the aircraft in DCS.

# Limitations

## Hornet

The setting of Pre-Planned coordinates relies on the settings for all stations being correct. This may be improved in the future to not require setting the store type at all.

## Strike Eagle

If you have displays already programmed in the jet, the app will skip uploading the new displays configuration. This will be improved in a future version.

From either seat (pilot/WSO) it is not possible to change displays on the other seat, given that the displays are only rendered when you occupy the respective position. Therefore when selecting the option on the Upload page to set "Pilot and WSO" displays, DTC will jump between the seats to perform the configuration.

# Help

There is a Discord channel to report bugs, send suggestions and chat with other users. You can join it here:
https://discord.gg/saCACg99EZ