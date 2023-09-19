using Microsoft.Web.Administration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.AccessControl;
using System.Security.Principal;

namespace GCS.Framework.InstallHelpers
{
    public class Helpers
    {
        public static bool IsUserAdmin()
        {
            bool isAdmin;
            try
            {
                // Get current user
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        public static bool IsApplicationInstalled(string guid)
        {
            if (!String.IsNullOrEmpty(guid))
            {
                // Search in Current User:
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    if (key != null)
                    {
                        foreach (String keyName in key.GetSubKeyNames())
                        {
                            if (keyName != null && keyName.Equals(guid, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                return true;
                            }
                        }
                    }
                }

                // Search in Local Machine 32-bit:
                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    if (key != null)
                    {
                        foreach (String keyName in key.GetSubKeyNames())
                        {
                            if (keyName != null && keyName.Equals(guid, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                //var subKey = key.OpenSubKey(keyName, false);
                                //if (subKey != null)
                                //{
                                //    var version = subKey.GetValue("Version");
                                //}
                                return true;
                            }
                        }
                    }
                }

                // Search in Local Machine 64-bit:
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    if (key != null)
                    {
                        foreach (String keyName in key.GetSubKeyNames())
                        {
                            if (keyName != null && keyName.Equals(guid, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                var version = key.GetValue("Version");
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public static bool IsApplicationInstalled(IEnumerable<string> guids)
        {
            if (!guids.Any())
                return false;
            foreach (var g in guids)
            {
                if (IsApplicationInstalled(g) == true)
                    return true;
            }

            return false;
        }

        public class NetFramework4xReleaseNumbers
        {
            public const uint v45 = 378389;
            public const uint v451Win7Win8 = 378758;
            public const uint v451Win81orWinServer2012R2 = 378675;
            public const uint v452 = 379893;
            public const uint v46 = 393297;
            public const uint v46Win10 = 393295;
            public const uint v461 = 394271;
            public const uint v461Win10NovemberUpdate = 394254;
            public const uint v462 = 394806;
            public const uint v462Win10AnniversaryEdition = 394802;
            public const uint v47 = 460805;
            public const uint v47Win10CreatorsUpdate = 460798;
            public const uint v471 = 461310;
            public const uint v471Win10CreatorsUpdate = 461308;
            public const uint v472 = 461808;
            public const uint v472Win10FallCreatersUpdate = 461814;
            public const uint v48Win10May2019Update = 528040;
            public const uint v48WindowsMay2019Update = 528049;
            public const uint v48WindowsMay2020Update = 528372;
            public const uint v48Windows11Server2022Update = 528449;
            public const uint v481Windows112022Update = 533320;
            public const uint v481Windows2022Update = 533325;
        }

        public static bool IsDotNetInstalled(string version, List<uint> releases, ref uint valueFound)
        {
            valueFound = 0;
            if (version != null)
            {
                // Search for .NET
                // Most versions have an "install" value under the main key
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP"))
                {
                    foreach (String keyName in key.GetSubKeyNames())
                    {
                        if (keyName == version)
                        {
                            RegistryKey subKey = key.OpenSubKey(version);

                            // If the version is v4, then look in the "Full" directory inside, otherwise continue.
                            if (version == "v4" && subKey != null)
                            {
                                try { subKey = subKey.OpenSubKey("Full"); }
                                catch (Exception) { return false; }
                            }

                            foreach (String subKeyName in subKey.GetValueNames())
                            {
                                if (releases == null || releases.Count == 0)
                                {
                                    if (subKeyName.Equals("install", StringComparison.OrdinalIgnoreCase))
                                    {
                                        object Test = subKey.GetValue(subKeyName);
                                        if (((Int32)Test) == 1)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (subKeyName.Equals("Release", StringComparison.OrdinalIgnoreCase))
                                    {
                                        object Test = subKey.GetValue(subKeyName);
                                        uint uValue;
                                        if (uint.TryParse(Test.ToString(), out uValue))
                                        {
                                            if (releases.Contains(uValue))
                                            {
                                                valueFound = uValue;
                                                return true;
                                            }
                                            return false;
                                        }
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static string GetInstalledProgramStringValue(string guid, string valueName)
        {
            if (!String.IsNullOrEmpty(guid))
            {
                // Search in Current User:
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    if (key != null)
                    {
                        foreach (String keyName in key.GetSubKeyNames())
                        {
                            if (keyName != null && keyName.Equals(guid, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                var key1 = Registry.CurrentUser.OpenSubKey(String.Format(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{0}", guid));
                                var v = key1.GetValue(valueName);
                                if (v != null)
                                    return v.ToString();
                                return String.Empty;
                            }
                        }
                    }
                }

                // Search in Local Machine 32-bit:
                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    if (key != null)
                    {
                        foreach (String keyName in key.GetSubKeyNames())
                        {
                            if (keyName != null && keyName.Equals(guid, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                var key1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(String.Format(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{0}", guid));
                                var v = key1.GetValue(valueName);
                                if (v != null)
                                    return v.ToString();
                                return String.Empty;
                            }
                        }
                    }
                }

                // Search in Local Machine 64-bit:
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    if (key != null)
                    {
                        foreach (String keyName in key.GetSubKeyNames())
                        {
                            if (keyName != null && keyName.Equals(guid, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                var key1 = Registry.LocalMachine.OpenSubKey(String.Format(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{0}", guid));
                                var v = key1.GetValue(valueName);
                                if (v != null)
                                    return v.ToString();
                                return String.Empty;
                            }
                        }
                    }
                }
            }

            return String.Empty;
        }

        public static string GetServicePath(string serviceName)
        {
            var mc = new ManagementClass("Win32_Service");
            foreach (var mo in mc.GetInstances())
            {
                if (mo.GetPropertyValue("Name").ToString() == serviceName)
                {
                    return mo.GetPropertyValue("PathName").ToString().Trim('"');
                }
            }
            return string.Empty;
        }

        public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, InheritanceFlags inheritanceFlags, PropagationFlags propogationFlags, AccessControlType ControlType)
        {
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(
                new System.Security.AccessControl.FileSystemAccessRule(Account, Rights, inheritanceFlags, propogationFlags, ControlType));
            dInfo.SetAccessControl(dSecurity);
        }

        public static bool DoesWebsiteAppExist(string appName)
        {
            try
            {
                var serverManager = new ServerManager();
                foreach (var site in serverManager.Sites)
                {
                    Trace.WriteLine($"Site -> {site.Name}");
                    foreach (var application in site.Applications)
                    {
                        Trace.WriteLine($"  Application-> {application.Path}");
                        if (application.Path.ToLower().EndsWith(appName.ToLower()))
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return false;
        }

        public static void UrlShortcutToDesktop(string linkName, string linkUrl)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=" + linkUrl);
                writer.Flush();
            }
        }
    }
}
