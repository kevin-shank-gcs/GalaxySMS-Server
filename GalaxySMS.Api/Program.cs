using GCS.Framework.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace GalaxySMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(SystemUtilities.MyFolderLocation)
               .AddJsonFile("appsettings.json")
               .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                //Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));
                var file = File.CreateText($"{Path.GetTempPath()}{GCS.Framework.Utilities.SystemUtilities.MyProcessName}-Serilog.log");
                Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));
                Log.Information("Starting GalaxySMS Api host");
                var host = CreateHostBuilder(args).Build();


                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GalaxySMS Api host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // Before Serilog
        //public static void Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args).Build();

        //    //SeedDb(host);

        //    host.Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .UseWindowsService()
        //        .ConfigureLogging(logging =>
        //        {
        //            // clear default logging providers
        //            logging.ClearProviders();

        //            // add built-in providers manually, as needed 
        //            logging.AddConsole();
        //            //logging.AddDebug();  
        //            logging.AddEventLog(eventLogSettings =>
        //            {
        //                eventLogSettings.SourceName = "GalaxySMS.Api";
        //            });
        //            //logging.AddEventSourceLogger();
        //            //logging.AddTraceSource(sourceSwitchName); 
        //        })
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
