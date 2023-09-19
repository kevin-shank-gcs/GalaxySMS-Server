using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Timers;
using GalaxySMS.Business.Bootstrapper;
using GalaxySMS.Business.Managers;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using SM = System.ServiceModel;
using System.Threading;
using System.Security.Principal;
using GalaxySMS.Business;
using GalaxySMS.Business.WebApi.Controllers;
using GalaxySMS.Client.Proxies;
using GalaxySMS.Data;
using GalaxySMS.ServiceHost.Console.Properties;
using Microsoft.Owin.Hosting;
using GalaxyPanelCommunicationManager = GalaxySMS.Business.Managers.GalaxyPanelCommunicationManager;
using UserSessionManager = GalaxySMS.Business.Managers.UserSessionManager;
using GalaxySMS.Business.SignalR;

namespace GalaxySMS.ServiceHost.Console
{


    public class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    // Set Entry Assembly
            //    var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            //    System.Console.WriteLine(String.Format("ManagerBase constructor PDSA.Common.PDSACheckAssembly.SetEntryAssembly. ExecutingAssembly={0}", executingAssembly.FullName));

            //    PDSA.Common.PDSACheckAssembly.SetEntryAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            //    // Check PDSA License
            //    System.Console.WriteLine(String.Format("ManagerBase constructor PDSA.Common.PDSACheckAssembly.CheckPDSALicense"));
            //    PDSA.Common.PDSACheckAssembly.CheckPDSALicense();
            //    System.Console.WriteLine(String.Format("ManagerBase constructor PDSA.Common.PDSACheckAssembly.CheckPDSALicense"));
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.ToString());
            //}

            IDisposable _webApiServer = null;
            GenericPrincipal principal = new GenericPrincipal(
                new GenericIdentity("Kevin"), new string[] { "Administrators", "GalaxySMSAdmin" });
            Thread.CurrentPrincipal = principal;


            var catalog = new List<ComposablePartCatalog>()
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            };

#if IncludeWebApiControllers
            var webApiControllers = typeof(IdentityController).Assembly;
            catalog.Add(new AssemblyCatalog(webApiControllers));
#endif
            var proxies = typeof(ServiceFactory).Assembly;
            catalog.Add(new AssemblyCatalog(proxies));

            var repositories = typeof(DataRepositoryFactory).Assembly;
            catalog.Add(new AssemblyCatalog(repositories));

            var businessFactory = typeof(BusinessEngineFactory).Assembly;
            catalog.Add(new AssemblyCatalog(businessFactory));

            var managers = typeof(AdministrationManager).Assembly;
            catalog.Add(new AssemblyCatalog(managers));

            //ObjectBase.Container = MEFLoader.Init(catalog);
            StaticObjects.Container = MEFLoader.Init(catalog);


            //ObjectBase.Container = MEFLoader.Init();

            System.Console.WriteLine("Starting up services...");
            System.Console.WriteLine("");

            //#if IncludeWebApiControllers

            int httpPort = Settings.Default.HTTPPort;
            int httpsPort = Settings.Default.HTTPSPort;
            if (httpPort == 0 && httpsPort == 0)
            {
                System.Console.WriteLine("Both HTTPPort and HTTPSPort are 0. This is not a valid configuration");
            }
            else
            {
                var options = new StartOptions();

                if (httpsPort != 0)
                {
                    options.Urls.Add(string.Format("https://+:{0}/", httpsPort));
                }

                if (httpPort != 0)
                {
                    options.Urls.Add(string.Format("http://+:{0}/", httpPort));
                }

                try
                {
                    AppDomain.CurrentDomain.Load(typeof(GalaxySMSSignalRHub).Assembly.FullName);

                    _webApiServer = WebApp.Start<Startup>(options);
                    var sApiMsg = string.Format("WebApi services started on: ");
                    foreach (var s in options.Urls)
                    {
                        sApiMsg += s;
                        sApiMsg += ";";
                    }
                    System.Console.WriteLine(sApiMsg);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(string.Format("{0}", ex.ToString()));
                }

            }
            //#endif

            SM.ServiceHost hostAccountManager = new SM.ServiceHost(typeof(AccountManager));
            SM.ServiceHost hostGalaxyPanelCommunicationManager = new SM.ServiceHost(typeof(GalaxyPanelCommunicationManager));
            SM.ServiceHost hostAdministrationManager = new SM.ServiceHost(typeof(AdministrationManager));
            SM.ServiceHost hostUserSessionManager = new SM.ServiceHost(typeof(UserSessionManager));
            SM.ServiceHost hostSystemManager = new SM.ServiceHost(typeof(SystemManagement));
            SM.ServiceHost hostPanelDataProcessingManager = new SM.ServiceHost(typeof(PanelDataProcessingManager));

            StartService(hostAccountManager, "AccountManager");
            StartService(hostPanelDataProcessingManager, "PanelDataProcessingManager");
            StartService(hostGalaxyPanelCommunicationManager, "GalaxyPanelCommunicationManager");
            StartService(hostAdministrationManager, "AdministrationManager");
            StartService(hostUserSessionManager, "UserSessionManager");
            StartService(hostSystemManager, "SystemManagement");


            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();

            System.Console.WriteLine("Timer started.");

            System.Console.WriteLine("");
            System.Console.WriteLine("Press [Enter] to exit.");

            System.Console.ReadLine();
            System.Console.WriteLine("");

            timer.Stop();

            System.Console.WriteLine("Timer stopped.");

            if (_webApiServer != null)
            {
                _webApiServer.Dispose();
                _webApiServer = null;
            }

            StopService(hostAccountManager, "AccountManager");
            StopService(hostAccountManager, "GalaxyPanelCommunicationManager");
            StopService(hostAdministrationManager, "AdministrationManager");
            StopService(hostPanelDataProcessingManager, "PanelDataProcessingManager");
            StopService(hostUserSessionManager, "UserSessionManager");
            StopService(hostSystemManager, "SystemManagement");
        }

        static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Globals.Instance.CleanupExpiredSessions();
            Globals.Instance.CleanUpExpiredTwoFactorSessions();
            //RentalManager rentalManager = new RentalManager();

            //Reservation[] reservations = rentalManager.GetDeadReservations();
            //if (reservations != null)
            //{
            //    foreach (Reservation reservation in reservations)
            //    {
            //        using (TransactionScope scope = new TransactionScope())
            //        {
            //            rentalManager.CancelReservation(reservation.ReservationId);
            //            scope.Complete();
            //        }
            //    }
            //}
        }

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            try
            {
                host.Open();
                System.Console.WriteLine("Service '{0}' started.", serviceDescription);
                LogManager.GetLogger<Program>().InfoFormat("Service '{0}' started.", serviceDescription);
                foreach (var endpoint in host.Description.Endpoints)
                {
                    System.Console.WriteLine(string.Format("Listening on endpoint:"));
                    System.Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                    System.Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                    System.Console.WriteLine(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
                }

                System.Console.WriteLine();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.ToString());
            }
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            try
            {
                host.Close();
                System.Console.WriteLine("Service '{0}' stopped.", serviceDescription);
                LogManager.GetLogger<Program>().InfoFormat("Service '{0}' stopped.", serviceDescription);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.ToString());
            }
        }

    }
}
