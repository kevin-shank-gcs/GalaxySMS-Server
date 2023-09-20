using GCS.Core.Common.Logger;
using System;
using System.IO;
using System.ServiceProcess;
#if UseSerilog
using Serilog;
#else
using log4net;
#endif

namespace GalaxySMS.MessageQueue.Processor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var title = System.Configuration.ConfigurationManager.AppSettings["title"];
            try
            {
#if UseSerilog
                //var connectionString = ConfigurationManager.ConnectionStrings["GalaxySMSLogging"];
                //var tableName = ConfigurationManager.AppSettings["serilog:write-to:MSSqlServer.tableName"];
                //var schemaName = ConfigurationManager.AppSettings["serilog:write-to:MSSqlServer.schemaName"];

                var file = File.CreateText($"{Path.GetTempPath()}{title}-Serilog.log");
                Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));

                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    .CreateLogger();
#else
            log4net.Config.XmlConfigurator.Configure();
#endif

                var logger = LogManager.GetLogger<GalaxySMSMessageQueueProcessorService>();
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new GalaxySMSMessageQueueProcessorService()
                };
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception e)
            {
                File.WriteAllText($"{Path.GetTempPath()}{title}_error.log", e.ToString());
            }
        }
    }
}
