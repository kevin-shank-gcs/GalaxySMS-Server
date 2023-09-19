using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Logger;

namespace GalaxySMS.Core
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            //var logger = LogManager.GetLogger<GalaxySMSCoreService>();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new GalaxySMSCoreService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
