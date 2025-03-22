# **DTC for DCS**

https://github.com/the-paid-actor/dcs-dtc

This is a Windows application that mimics the functions of a DTC (Data Cartridge) for the F-16, F/A-18, F-15E and Apache.

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
- Custom in-game kneeboard with synced notes
- Command-line options for loading a preset and uploading a preset

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
  - Custom HARM emitter IDs

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

## Apache

- Waypoints and Hazards
- Control Measures
- Targets and Threats
- TSD settings

# Requirements

This application is written using .NET 7.0. You may want to download the latest version from the Microsoft website. Look for the .NET Desktop Runtime on the link below.

https://dotnet.microsoft.com/en-us/download/dotnet/7.0

# Installation

- Grab the latest installer from the Releases tab on Github (the file with msi extension).
- Run the installer. It will create a shortcut on the Start Menu once it finishes.
- Run the application from the Windows Start Menu. It will setup itself into DCS automatically.

If the application does not start, check if you have Controlled Folder Access enabled in Windows Defender. If so, you will have to add the application to the list of allowed apps, since it creates its storage under the Documents folder. https://support.microsoft.com/en-us/windows/allow-an-app-to-access-controlled-folders-b5b6627a-b008-2ca2-7931-7e51e912b034

If the application still does not start, check the Windows Event Viewer for errors related to the application. https://www.windowscentral.com/how-use-event-viewer-windows-10

## Manual setup in DCS

If for some reason you need to manually setup the application in DCS, follow these steps:
- Copy the all the files from `C:\Program Files (x86)\DCS-DTC\DCS` into `C:\Users\<your user name>\Saved Games\DCS\Scripts`. Substitute `C:` for the drive 
  where your Windows is installed and `DCS` for `DCS.openbeta` if you are on the beta version.
- In that same folder, edit a file named `Export.lua`. If the file does not exists, create it yourself.
- Add the following line to the end of the file, if its not there already:

```lua
local DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/DCSDTC.lua')
```

## Uninstalling

Uninstalling the program via Windows only uninstall the program files, but not the files in DCS. Therefore to fully remove DTC you must delete the following as well:

- Saved Games\DCS\Scripts\DCSDTC folder
- Saved Games\DCS\Scripts\DCSDTC.lua file
- Saved Games\DCS\Scripts\Hooks\DCSDTCHook.lua file
- In Saved Games\DCS\Scripts\Export.lua, remove the line that references DTC

Uninstalling also does not remove the Documents\DCS-DTC folder where your presets are saved.

# In-cockpit Controls

The mod features usage of unused cockpit buttons in DCS to show/hide the app, and to upload the preset. **Keep in mind** that the commands to show the app only works if the app is already running and DCS is not in exclusive full screen or VR mode. It will put the app in front of DCS, so you can interact with it, otherwise you have to Alt+tab to it.

## Viper

- pressing the "WX" button on the UFC for more than 1 second will command the upload of the current preset.
- the FLIR increment switch shows the DTC app, while the FLIR decrement switch hides it.

## Hornet

- pressing the "I/P" button on the UFC for more than 1 second will command the upload of the current preset.
- flipping the HUD Video Control switch (right below the BCN button on the UFC) to the up position shows the DTC app, while flipping the switch to the down position hides it.

## Strike Eagle

- pressing the "I/P" button on the UFC for more than 1 second will command the upload of the current preset.
- pressing the "EMIS LMT" button on the UFC will toggle visibility of the DTC app.

## Apache

- pressing the "Defog" button on either station for more than 1 second will command the upload of the current preset.

# Capturing coordinates in DCS

By pressing Ctrl+Shift+D within DCS, a window with a crosshair will popup. By going into the F10 map and positioning the crosshair over a point of interest, you can capture the coordinates of that point as steerpoints or target points. Pressing "Send to DTC" will send the coordinates to the app, and pressing "Send to DTC + Jet" will save the coordinates into the app but also uploads these same coordinates into the aircraft. Otherwise the dialog is self-explanatory.

You can also capture coordinates this way directly into PP stations (Hornet) or Smart Weapons (Strike Eagle).

The shortcut can be changed by editing the dtc-settings.json file located in the Documents\DCS-DTC folder. After editing it, restart the DTC app and after the prompt, restart DCS as well. The shortcut has to be a valid keyboard combination not in use by the aircraft in DCS.

# In-game Kneeboard

There is a custom in-game kneeboard which is accessible by pressing Ctrl+Shift+K. Once you upload a preset, it shows a summary of the preset in textual form - a list of waypoints and their names, preset radio frequencies and their labels, etc.

It also has a Notes field which auto-syncs back to the preset and vice-versa. In the DTC app, the Kneeboard preview and the Notes field are acessible by clicking the clipboard icon on the top right of a loaded preset.

The shortcut can be changed by editing the dtc-settings.json file located in the Documents\DCS-DTC folder. After editing it, restart the DTC app and after the prompt, restart DCS as well. The shortcut has to be a valid keyboard combination not in use by the aircraft in DCS.

# Command-line options

There are a few command-line options available which provide a limited automation capability to DTC. These options are:

<table>
  <tr>
    <td width=150>--load "&ltpath&gt"</td>
    <td>Loads a preset from the specified path. The path is relative to the Documents\DCS-DTC path. For example, to load a preset for the F-16 you would supply --load "F16C\mypreset.json". Include double quotes to avoid problems with spaces in the file name.</td>
  </tr>
  <tr>
    <td width=150>--upload</td>
    <td>Executes an upload of the loaded preset to the jet. Only used after --load. If the preset is from the Apache, an additional option must be supplied immediately following it: either --pilot or --cpg, to indicate for which station the upload must be executed for. </td>
  </tr>
  <tr>
    <td width=150>--exit</td>
    <td>Exits the DTC app after executing the command.</td>
  </tr>
</table>

For example, to upload an Apache preset for the pilot and exit DTC afterwards:

--load "AH64D\preset.json" --upload --pilot --exit

# Custom HARM emitter IDs

In order to use custom HARM emitter IDs (from a DCS mod, for example), you can create a dtc-emitter.json file in the Documents\DCS-DTC folder and add custom emitters there. The format is identical to the default dtc-emitter.json file present in the DTC install, except there is no HTSTable attribute as the built-in HTS tables are hardcoded in DCS.

Custom emitters will appear when defining a manual HTS table or for the HARM WPN page tables, in addition to the default ones.

For example, this defines a custom emitter:

```
[
  {
    "Country": "Russia",
    "HARMCode": 500,
    "F16RWR": "PT",
    "Type": "STR",
    "Name": "Pantsir S1",
    "NATO": "SA-22 Greyhound"
  },
  {
    "Country": "Russia",
    "HARMCode": 501,
    "F16RWR": "PT",
    "Type": "STR",
    "Name": "Pantsir S2",
    "NATO": "SA-22 Greyhound"
  }
]
```

# Limitations

## Hornet

The setting of Pre-Planned coordinates relies on the settings for ALL stations being correct in DTC (i.e. matching the munitions in the actual in-game jet). This may be improved in the future to not require setting the store type at all.

## Strike Eagle

If you have displays already programmed in the jet, the app will skip uploading the new displays configuration. This will be improved in a future version.

From either seat (pilot/WSO) it is not possible to change displays on the other seat, given that the displays are only rendered when you occupy the respective position. Therefore when selecting the option on the Upload page to set "Pilot and WSO" displays, DTC will jump between the seats to perform the configuration.

## Apache

During the upload process, do not change anything in the cockpit displays, like changing zoom levels, or otherwise the data input may not work correctly.

## VR

As a windows app, the application will not show up in VR. Because it is a windows app. What you can do is prepare the presets beforehand, outside of VR, then use the in-cockpit controls to upload the preset, and use the coordinate capture dialog in DCS to capture additional waypoints and targets while in VR.

# Help

There is a Discord channel to report bugs, send suggestions and chat with other users. You can join it here:
https://discord.gg/saCACg99EZ