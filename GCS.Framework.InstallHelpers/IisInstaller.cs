using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Shared.Extensions;
using Microsoft.Web.Administration;
using Microsoft.Win32;

namespace GCS.Framework.InstallHelpers
{
    public class IisInstaller
    {
        private ICollection<string> installedFeatures = new List<string>();
        private ICollection<string> notInstalledFeatures = new List<string>();
        private ICollection<string> missingIISFeatures = new List<string>();
        private ICollection<string> notSupportedFeatures = new List<string>();

        public List<string> IisFeatureNames { get; internal set; } = new List<string>()
        {
            "IIS-ApplicationDevelopment",
            "IIS-CommonHttpFeatures",
            "IIS-DefaultDocument",
            "IIS-ISAPIExtensions",
            "IIS-ISAPIFilter",
            "IIS-ManagementConsole",
//        "IIS-NetFxExtensibility",
            "IIS-NetFxExtensibility45",
            "IIS-RequestFiltering",
            "IIS-Security",
            "IIS-StaticContent",
            "IIS-WebServer",
            "IIS-WebServerRole",
//        "IIS-ASPNET",
            "IIS-ASPNET45",
            "IIS-HttpLogging",
            "IIS-HttpErrors",
            "IIS-HttpRedirect",
            "IIS-HealthAndDiagnostics",
            "IIS-LoggingLibraries",
            "IIS-HttpTracing",
            "IIS-URLAuthorization",
            "IIS-IPSecurity",
            "IIS-Performance",
            "IIS-HttpCompressionDynamic",
            "IIS-WebServerManagementTools",
            "IIS-ManagementScriptingTools",
            "IIS-Metabase",
            "IIS-BasicAuthentication",
            "IIS-WindowsAuthentication" };

        public bool IsIISInstalled(ref string version)
        {
            try
            {
                string _iisRegKey = @"Software\Microsoft\InetStp";
                using (RegistryKey iisKey = Registry.LocalMachine.OpenSubKey(_iisRegKey))
                {
                    version = iisKey.GetValue("VersionString").ToString();
                    return (int)iisKey.GetValue("MajorVersion") >= 6;
                }
            }
            catch
            {
                return false;
            }
        }

        public void RefreshIISStatus()
        {
            var osVers = Environment.OSVersion;
            var sVersion = string.Empty;
            IisInstalled = IsIISInstalled(ref sVersion);
            IisVersion = sVersion;

            var psInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psNotInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psexe = "powershell.exe";

            installedFeatures = psInstalled.LaunchProcess(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Enabled'} | ft -Property featurename");
            notInstalledFeatures = psNotInstalled.LaunchProcess(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Disabled'} | ft -Property featurename");

            missingIISFeatures = IisFeatureNames.Where(p => installedFeatures.All(p2 => p2 != p)).ToList();

            notSupportedFeatures = missingIISFeatures.Where(p => notInstalledFeatures.All(p2 => p2 != p)).ToList();


            var sFeatures = string.Empty;
            foreach (var f in notSupportedFeatures)
            {
                sFeatures += $"\n{f}";
                missingIISFeatures.Remove(f);
            }

            //File.WriteAllText("C:\\temp\\notSupported.txt", sFeatures);

            //sFeatures = string.Empty;
            //foreach (var f in missingIISFeatures)
            //    sFeatures += $"\n{f}";
            //File.WriteAllText("C:\\temp\\missingFeatures.txt", sFeatures);

            //btnInstallIIS.Enabled = true;
            //if (IisInstalled && !missingIISFeatures.Any())
            //{
            //    btnInstallIIS.Visible = false;
            //    lnkLocalHost.Visible = true;
            //    lblIISStatus.Text = string.Format(Properties.Resources.IISInstalledStatus, sIISVersion);
            //}
            //else if (IisInstalled && missingIISFeatures.Any())
            //{
            //    btnInstallIIS.Visible = true;
            //    lnkLocalHost.Visible = true;
            //    lblIISStatus.Text = string.Format(Properties.Resources.IISPartiallyInstalledStatus, sIISVersion);
            //}
            //else
            //{
            //    btnInstallIIS.Visible = true;
            //    lnkLocalHost.Visible = false;
            //    lblIISStatus.Text = Properties.Resources.IISNotInstalledStatus;
            //}
        }


        public async Task RefressIISStatusAsync()
        {
            var osVers = Environment.OSVersion;
            var sVersion = string.Empty;
            IisInstalled = IsIISInstalled(ref sVersion);
            IisVersion = sVersion;

            var psInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psNotInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psexe = "powershell.exe";

            installedFeatures = await psInstalled.LaunchProcessAsync(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Enabled'} | ft -Property featurename");
            notInstalledFeatures = await psNotInstalled.LaunchProcessAsync(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Disabled'} | ft -Property featurename");

            missingIISFeatures = IisFeatureNames.Where(p => installedFeatures.All(p2 => p2 != p)).ToList();

            notSupportedFeatures = missingIISFeatures.Where(p => notInstalledFeatures.All(p2 => p2 != p)).ToList();


            var sFeatures = string.Empty;
            foreach (var f in notSupportedFeatures)
            {
                sFeatures += $"\n{f}";
                missingIISFeatures.Remove(f);
            }
        }


        public int SetupIIS()
        {
            var sArgs = string.Format(
                "/NoRestart /Online /Enable-Feature /all {0}",
                string.Join(
                    " ",
                    missingIISFeatures.Select(name => string.Format("/FeatureName:{0}", name))));
            //var sArgs = string.Format(
            //      "/NoRestart /Online /Enable-Feature {0}",
            //      string.Join(
            //          " ",
            //          missingIISFeatures.Select(name => string.Format("/FeatureName:{0}", name))));
            Trace.WriteLine(sArgs);
            //            File.WriteAllText("C:\\Temp\\dismcmd.txt", sArgs);
            //return 0;

            //            return Run($"{Environment.SystemDirectory}\\dism.exe", sArgs);
            return ProcessRunner.Run($"dism.exe", sArgs, true);
        }


        public async Task<int> InstallIISAsync()
        {
            var sArgs = string.Format(
                "/NoRestart /Online /Enable-Feature /all {0}",
                string.Join(
                    " ",
                    missingIISFeatures.Select(name => string.Format("/FeatureName:{0}", name))));
            //            Trace.WriteLine(sArgs);
            var tempPath = System.IO.Path.GetTempPath();
            //File.AppendAllText($"{tempPath}dismcmd.txt", $"dism.exe {sArgs}");

            var dismReturnCode = await ProcessRunner.RunAsync($"dism.exe", sArgs, true);
            return dismReturnCode;
        }



        public string IisVersion { get; internal set; }
        public bool IisInstalled { get; internal set; }
        public bool AreFeaturesMissing
        {
            get { return MissingIISFeatures.Any(); }
        }

        public bool IsPartiallyInstalled => IisInstalled && AreFeaturesMissing;


        public ICollection<string> InstalledFeatures => installedFeatures;
        public ICollection<string> NotInstalledFeatures => notInstalledFeatures;
        public ICollection<string> MissingIISFeatures => missingIISFeatures;
        public ICollection<string> NotSupportedFeatures => notSupportedFeatures;

    }
}
