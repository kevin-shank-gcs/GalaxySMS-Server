using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace GCS.Framework.InstallHelpers
{
    public class MsmqInstaller
    {
        private ICollection<string> installedFeatures = new List<string>();
        private ICollection<string> notInstalledFeatures = new List<string>();
        private ICollection<string> missingMSMQFeatures = new List<string>();
        private ICollection<string> notSupportedFeatures = new List<string>();

        public List<string> MSMQFeatureNames { get; internal set; } = new List<string>()
        {
            "MSMQ-Container",
//            "MSQM-DCOMProxy",
            "MSMQ-Server",
            "MSMQ-ADIntegration",
//            "MSMQ-HTTP",
            "MSMQ-Multicast",
            "MSMQ-Triggers"};

        public void RefreshMSMQStatus()
        {
            var osVers = Environment.OSVersion;
            var sVersion = string.Empty;
            MSMQServiceInstalled = IsMSMQServiceInstalled();

            var psInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psNotInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psexe = "powershell.exe";

            installedFeatures = psInstalled.LaunchProcess(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Enabled'} | ft -Property featurename");
            notInstalledFeatures = psNotInstalled.LaunchProcess(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Disabled'} | ft -Property featurename");

            missingMSMQFeatures = MSMQFeatureNames.Where(p => installedFeatures.All(p2 => p2 != p)).ToList();

            notSupportedFeatures = missingMSMQFeatures.Where(p => notInstalledFeatures.All(p2 => p2 != p)).ToList();


            var sFeatures = string.Empty;
            foreach (var f in notSupportedFeatures)
            {
                sFeatures += $"\n{f}";
                missingMSMQFeatures.Remove(f);
            }
        }

        public async Task RefreshMSMQStatusAsync()
        {
            var osVers = Environment.OSVersion;
            var sVersion = string.Empty;
            MSMQServiceInstalled = IsMSMQServiceInstalled();

            var psInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psNotInstalled = new GCS.Framework.InstallHelpers.ProcessRunner();
            var psexe = "powershell.exe";

            installedFeatures = await psInstalled.LaunchProcessAsync(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Enabled'} | ft -Property featurename");
            notInstalledFeatures = await psNotInstalled.LaunchProcessAsync(psexe, "Get-WindowsOptionalFeature -Online | where {$_.state -eq 'Disabled'} | ft -Property featurename");

            missingMSMQFeatures = MSMQFeatureNames.Where(p => installedFeatures.All(p2 => p2 != p)).ToList();

            notSupportedFeatures = missingMSMQFeatures.Where(p => notInstalledFeatures.All(p2 => p2 != p)).ToList();


            var sFeatures = string.Empty;
            foreach (var f in notSupportedFeatures)
            {
                sFeatures += $"\n{f}";
                missingMSMQFeatures.Remove(f);
            }
        }

        public bool IsMSMQServiceInstalled()
        {
            try
            {
                var services = ServiceController.GetServices().ToList();
                var msQue = services.Find(o => o.ServiceName == "MSMQ");
                if (msQue != null)
                {
                    return true;
                    //if (msQue.Status == ServiceControllerStatus.Running)
                    //{
                    //    // It is running.
                    //}
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public int InstallMSMQ()
        {
            var sArgs = string.Format(
                "/NoRestart /Online /Enable-Feature /all {0}",
                string.Join(
                    " ",
                    missingMSMQFeatures.Select(name => string.Format("/FeatureName:{0}", name))));
            Trace.WriteLine(sArgs);
            return ProcessRunner.Run($"dism.exe", sArgs, true);
        }


        public async Task<int> InstallMSMQAsync()
        {
            var sArgs = string.Format(
                "/NoRestart /Online /Enable-Feature /all {0}",
                string.Join(
                    " ",
                    missingMSMQFeatures.Select(name => string.Format("/FeatureName:{0}", name))));
//            Trace.WriteLine(sArgs);
            var tempPath = System.IO.Path.GetTempPath();
            File.AppendAllText($"{tempPath}dismcmd.txt", $"dism.exe {sArgs}");

            return await ProcessRunner.RunAsync($"dism.exe", sArgs, true);
        }

        public bool MSMQServiceInstalled { get; internal set; }
        public bool AreFeaturesMissing
        {
            get { return MissingMSMQFeatures.Any(); }
        }

        public bool IsPartiallyInstalled => MSMQServiceInstalled && AreFeaturesMissing;

        public ICollection<string> InstalledFeatures => installedFeatures;
        public ICollection<string> NotInstalledFeatures => notInstalledFeatures;
        public ICollection<string> MissingMSMQFeatures => missingMSMQFeatures;
        public ICollection<string> NotSupportedFeatures => notSupportedFeatures;

    }
}
