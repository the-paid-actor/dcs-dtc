using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DTC.Models.Base
{
    internal static class DCSInstallCheck
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        static extern string SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken = default);
        static Guid SavedGamesFolderGuid = new Guid("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4");

        public static bool Check()
        {
            if (Settings.SkipDCSInstallCheck) return true;

            var savedGamesPath = SHGetKnownFolderPath(SavedGamesFolderGuid, 0);
            if (string.IsNullOrEmpty(savedGamesPath))
            {
                DTCMessageBox.ShowError("Saved Games folder not found. Cannot continue.");
                return false;
            }

            if (!Settings.LuaInstallStable && !Settings.LuaInstallOpenBeta)
            {
                Settings.LuaInstallStable = true;
                Settings.LuaInstallOpenBeta = true;
            }

            var dcsStablePathExists = false;
            var dcsOpenBetaPathExists = false;

            if (Settings.LuaInstallStable)
            {
                if (string.IsNullOrEmpty(Settings.LuaInstallFolderStable))
                {
                    var dcsStablePath = Path.Combine(savedGamesPath, "DCS");
                    dcsStablePathExists = Directory.Exists(dcsStablePath);
                    if (dcsStablePathExists)
                    {
                        Settings.LuaInstallFolderStable = dcsStablePath;
                    }
                    else
                    {
                        Settings.LuaInstallStable = false;
                    }
                }
                else
                {
                    dcsStablePathExists = true;
                }
            }

            if (Settings.LuaInstallOpenBeta)
            {
                if (string.IsNullOrEmpty(Settings.LuaInstallFolderOpenBeta))
                {
                    var dcsOpenBetaPath = Path.Combine(savedGamesPath, "DCS.openbeta");
                    dcsOpenBetaPathExists = Directory.Exists(dcsOpenBetaPath);
                    if (dcsOpenBetaPathExists)
                    {
                        Settings.LuaInstallFolderOpenBeta = dcsOpenBetaPath;
                    }
                    else
                    {
                        Settings.LuaInstallOpenBeta = false;
                    }
                }
                else
                {
                    dcsOpenBetaPathExists = true;
                }
            }

            if (!dcsStablePathExists && !dcsOpenBetaPathExists)
            {
                DTCMessageBox.ShowError("DCS or DCS.openbeta folder not found under Saved Games.\n\nPlease run DCS once, then exit DCS and try again.");
                return false;
            }

            if (Settings.LuaInstallStable)
            {
                Settings.LuaInstallStable = CheckAndInstall(Settings.LuaInstallFolderStable);
            }
            if (Settings.LuaInstallOpenBeta)
            {
                Settings.LuaInstallOpenBeta = CheckAndInstall(Settings.LuaInstallFolderOpenBeta);
            }

            if (!Settings.LuaInstallStable && !Settings.LuaInstallOpenBeta)
            {
                DTCMessageBox.ShowError("Cannot continue since DTC is not installed on either DCS or DCS.openbeta folder under Saved Games.");
                return false;
            }

            return true;
        }

        private static bool CheckAndInstall(string path)
        {
            var userAsked = false;
            var dtcLuaInstalled = false;
            var dtcLuaUpdated = false;

            var scriptsFolder = Path.Combine(path, "Scripts");
            if (!Directory.Exists(scriptsFolder))
            {
                if (AskUserToInstall(path) == false) return false;
                userAsked = true;
                Directory.CreateDirectory(scriptsFolder);
            }

            var exportLuaPath = Path.Combine(scriptsFolder, "Export.lua");
            if (!File.Exists(exportLuaPath))
            {
                if (!userAsked && AskUserToInstall(path) == false) return false;
                userAsked = true;
                File.WriteAllText(exportLuaPath, "");
            }

            var exportLuaContent = File.ReadAllText(exportLuaPath);
            if (!exportLuaContent.Contains("local DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/DCSDTC.lua')"))
            {
                if (!exportLuaContent.Contains("DCSDTC.lua"))
                {
                    if (!userAsked && AskUserToInstall(path) == false) return false;
                    dtcLuaInstalled = true;
                    exportLuaContent += "\n\nlocal DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/DCSDTC.lua')";
                    File.WriteAllText(exportLuaPath, exportLuaContent);
                }
                else
                {
                    DTCMessageBox.ShowError($"Incorrect DCSDTC.lua install on {exportLuaPath}.\n\nPlease delete the incorrect line, run DTC again, and it will be installed automatically.");
                    return false;
                }
            }

            var dcsDtcLuaPath = Path.Combine(scriptsFolder, "DCSDTC.lua");
            var originalDcsDtcLuaPath = Path.Combine(FileStorage.GetCurrentFolder(), "DCS", "DCSDTC.lua");
            if (!File.Exists(dcsDtcLuaPath))
            {
                dtcLuaInstalled = true;
                File.Copy(originalDcsDtcLuaPath, dcsDtcLuaPath);
            }

            var dcsDtcLuaContent = File.ReadAllText(dcsDtcLuaPath);
            var originalDcsDtcLuaContent = File.ReadAllText(originalDcsDtcLuaPath);

            if (dcsDtcLuaContent != originalDcsDtcLuaContent)
            {
                dtcLuaUpdated = true;
                File.Copy(originalDcsDtcLuaPath, dcsDtcLuaPath, true);
            }

            var folderChanged1 = CopyDCSDTCFolder("DCSDTC", scriptsFolder);
            var folderChanged2 = CopyDCSDTCFolder("Hooks", scriptsFolder);

            if (dtcLuaInstalled || dtcLuaUpdated || folderChanged1 || folderChanged2)
            {
                var txt = dtcLuaInstalled ? "installed" : "updated";
                DTCMessageBox.ShowInfo($"DCSDTC.lua was {txt} in {path}.\n\nIf DCS is running, please restart DCS.");
            }

            return true;
        }

        private static bool CopyDCSDTCFolder(string folderToCopy, string scriptsFolder)
        {
            var changed = false;
            var localFolder = Path.Combine(FileStorage.GetCurrentFolder(), "DCS", folderToCopy);
            var remoteFolder = Path.Combine(scriptsFolder, folderToCopy);

            if (!Directory.Exists(remoteFolder))
            {
                Directory.CreateDirectory(remoteFolder);
            }

            foreach (var localFile in Directory.GetFiles(localFolder))
            {
                var remoteFile = Path.Combine(remoteFolder, Path.GetFileName(localFile));
                if (!File.Exists(remoteFile))
                {
                    File.Copy(localFile, remoteFile);
                    changed = true;
                }

                var localFileContent = File.ReadAllText(localFile);
                var remoteFileContent = File.ReadAllText(remoteFile);
                if (localFileContent != remoteFileContent)
                {
                    File.Copy(localFile, remoteFile, true);
                    changed = true;
                }
            }

            return changed;
        }

        private static bool AskUserToInstall(string path)
        {
            return DTCMessageBox.ShowQuestion($"DTC is not installed at {path}. Do you want to install it?");
        }
    }
}