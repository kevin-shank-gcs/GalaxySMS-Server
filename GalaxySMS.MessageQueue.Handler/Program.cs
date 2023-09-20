using System;
using Topshelf;
using GCS.Core.Common.Logger;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Threading;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common.Core;
#if UseSerilog
using Serilog;
#else
using log4net;
#endif

namespace GalaxySMS.MessageQueue.Handler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
#if UseSerilog
            //var connectionString = ConfigurationManager.ConnectionStrings["GalaxySMSLogging"];
            //var tableName = ConfigurationManager.AppSettings["serilog:write-to:MSSqlServer.tableName"];
            //var schemaName = ConfigurationManager.AppSettings["serilog:write-to:MSSqlServer.schemaName"];
            var filename = $"{Path.GetTempPath()}{GCS.Framework.Utilities.SystemUtilities.MyProcessName}-{GCS.Framework.Utilities.SystemUtilities.MyProcessId}-{Environment.TickCount}-Serilog.log";
            var file = File.CreateText(filename);
            Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));

            //Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();
#else
            log4net.Config.XmlConfigurator.Configure();
#endif

            var _logger = LogManager.GetLogger<Program>();

            try
            {
                _logger.Info("Starting...");

                string listenOnQueueName = null;


                var catalog = new List<ComposablePartCatalog>()
                {
                    new AssemblyCatalog(Assembly.GetExecutingAssembly())
                };
                var uiAssembly = typeof(EntityManager).Assembly;
                catalog.Add(new AssemblyCatalog(uiAssembly));

                //            ObjectBase.Container = MEFLoader.Init(catalog);
                StaticObjects.Container = MEFLoader.Init(catalog);

                HostFactory.Run(x =>
                {
                    x.AddCommandLineDefinition("listenOnQueueName", q => { listenOnQueueName = q; });
                    x.ApplyCommandLine();

                    _logger.Info("listenOnQueueName=" + listenOnQueueName);
                    x.Service<QueueListener>(
                        s =>
                        {
                            s.ConstructUsing(() => new QueueListener());
                            s.WhenStarted(tc => tc.Start(listenOnQueueName));
                            s.WhenStopped(tc => tc.Stop());
                            //sc.WhenPaused(tc => tc.Pause());
                            //sc.WhenContinued((tc => tc.Continue());
                            //sc.WhenShutdown(tc => tc.Shutdown());
                        });

                    var logFilename = $"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}\\GCS\\Logfiles\\Server\\GalaxySMS.MessageQueue.Handler - {listenOnQueueName}.log";
                    x.SetDescription($"Process messages from the {listenOnQueueName} message queue");
                    x.SetDisplayName($"GalaxySMS.MessageQueue.Handler - {listenOnQueueName}");
                    x.SetServiceName("GalaxySMS.MessageQueue.Handler");
                    x.SetInstanceName(listenOnQueueName);
#if UseSerilog
                    x.UseSerilog();
#else
                   x.UseLog4Net(logFilename, true);
#endif
                    x.RunAsLocalSystem();
                    x.DependsOnMsmq();
                    x.StartAutomatically();
                    x.EnableServiceRecovery(r =>
                        {
                            r.RestartService(1); // restart the service after 1 minute
                            r.SetResetPeriod(1); // set the reset interval to one day
                        });

                    x.OnException(ex =>
                    {
                        _logger.Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                    });

                });
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("Error running host: {0}", ex);
                _logger.Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
#if UseSerilog
            Log.CloseAndFlush();
#endif
        }
    }
}
