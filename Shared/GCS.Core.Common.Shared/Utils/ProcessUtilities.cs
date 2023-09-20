using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Shared.Extensions;

namespace GCS.Core.Common.Utils
{
    public static class ProcessUtilities
    {
        public static async Task<int> ExecAsync(string command, string args)
        {
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = command;
            psi.Arguments = args;
            psi.CreateNoWindow = true;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            using (var proc = System.Diagnostics.Process.Start(psi))
            {
                await proc.WaitForExitAsync();
                return proc.ExitCode;
            }
        }
    }
}
