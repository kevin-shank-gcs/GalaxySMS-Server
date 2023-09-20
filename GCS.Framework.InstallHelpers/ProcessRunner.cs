using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Management.Automation;
using static System.Console;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using GCS.Core.Common.Utils;
using GCS.Core.Common.Shared.Extensions;

namespace GCS.Framework.InstallHelpers
{
    public class ProcessRunner
    {
        public ICollection<string> StandardOutput { get; internal set; } = new List<string>();
        public ICollection<string> ErrorOutput { get; internal set; } = new List<string>();
        Process process = new Process();

        public ICollection<string> LaunchProcess(string filename, string script)
        {
            StandardOutput = new List<string>();
            ErrorOutput = new List<string>();

            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
            process.Exited += new EventHandler(process_Exited);

            process.StartInfo.FileName = filename;//"powershell.exe";
            process.StartInfo.Arguments = script;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            //below line is optional if we want a blocking call
            process.WaitForExit();
            return StandardOutput;
        }

        public async Task<ICollection<string>> LaunchProcessAsync(string filename, string script)
        {
            StandardOutput = new List<string>();
            ErrorOutput = new List<string>();

            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
            process.Exited += new EventHandler(process_Exited);

            process.StartInfo.FileName = filename;//"powershell.exe";
            process.StartInfo.Arguments = script;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            //below line is optional if we want a blocking call
            await process.WaitForExitAsync();
            return StandardOutput;
        }

        void process_Exited(object sender, EventArgs e)
        {
//            Trace.WriteLine(String.Format("process exited with code {0}\n", process.ExitCode.ToString()));
        }

        void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Trace.WriteLine(e.Data + "\n");
            if (e.Data != null)
                ErrorOutput.Add(e.Data.Trim());
        }

        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Trace.WriteLine(e.Data + "\n");
            if (e.Data != null)
                StandardOutput.Add(e.Data.Trim());
        }

        public static int Run(string fileName, string arguments, bool bRunAsAdmin)
        {
            //return ExecuteCommand(fileName, arguments);
            Console.WriteLine($"{fileName} {arguments}");
            var psi = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = arguments,
            };
            if( bRunAsAdmin)
                psi.Verb = "runas";
            using (var process = Process.Start(psi))
            {
                process.WaitForExit();
                return process.ExitCode;
            };
        }


        
        public static async Task<int> RunAsync(string fileName, string arguments, bool bRunAsAdmin)
        {
            //return ExecuteCommand(fileName, arguments);
            Console.WriteLine($"{fileName} {arguments}");
            var psi = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = arguments,
            };
            if( bRunAsAdmin)
                psi.Verb = "runas";
            
            using (var process = Process.Start(psi))
            {
                await process.WaitForExitAsync();
                return process.ExitCode;
            };
        }

    }
}
