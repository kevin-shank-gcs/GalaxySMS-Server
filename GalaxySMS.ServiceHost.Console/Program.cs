using GalaxySMS.Business;
using GalaxySMS.Business.Bootstrapper;
using GalaxySMS.Business.Managers;
using GalaxySMS.Client.Proxies;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Data;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Timers;
using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;
using GCS.Framework.Security;
using Topshelf;
using GalaxyPanelCommunicationManager = GalaxySMS.Business.Managers.GalaxyPanelCommunicationManager;
using SM = System.ServiceModel;
using UserSessionManager = GalaxySMS.Business.Managers.UserSessionManager;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using SharedResources = GalaxySMS.Resources;
using System.IO;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Business.Managers.Support;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.Utils;
#if UseSerilog
using Serilog;
#else
using log4net;
#endif

namespace GalaxySMS.ServiceHost.Console
{
    public class WcfServiceHost
    {
        IDisposable _webApiServer = null;
        System.Timers.Timer _timer = null;
        System.Timers.Timer _initializeTimer = null;

        SM.ServiceHost _hostAccountManager = null;
        SM.ServiceHost _hostGalaxyPanelCommunicationManager = null;
        SM.ServiceHost _hostAdministrationManager = null;
        SM.ServiceHost _hostUserSessionManager = null;
        SM.ServiceHost _hostSystemManager = null;
        SM.ServiceHost _hostPanelDataProcessingManager = null;
        SM.ServiceHost _hostMercuryManager = null;


        GalaxySiteServerConnectionSettings _serverConnectionSettings = null;
        GalaxySiteServerConnection _siteServerConnection = null;
        bool _autoStartPanelListener = true;

        public WcfServiceHost()
        {
            //var logger = LogManager.GetLogger<WcfServiceHost>();

        }

        public void Start()
        {
#if PDSANoLicense
#else
            //try
            //{
            //    Set Entry Assembly
            //   var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            //    System.Console.WriteLine(String.Format("ManagerBase constructor PDSA.Common.PDSACheckAssembly.SetEntryAssembly. ExecutingAssembly={0}", executingAssembly.FullName));

            //    PDSA.Common.PDSACheckAssembly.SetEntryAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            //    Check PDSA License
            //    System.Console.WriteLine(String.Format("ManagerBase constructor PDSA.Common.PDSACheckAssembly.CheckPDSALicense"));
            //    PDSA.Common.PDSACheckAssembly.CheckPDSALicense();
            //    System.Console.WriteLine(String.Format("ManagerBase constructor PDSA.Common.PDSACheckAssembly.CheckPDSALicense"));
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.ToString());
            //}
#endif

#if UseSerilog
            //var connectionString = ConfigurationManager.ConnectionStrings["GalaxySMSLogging"];
            //var tableName = ConfigurationManager.AppSettings["serilog:write-to:MSSqlServer.tableName"];
            //var schemaName = ConfigurationManager.AppSettings["serilog:write-to:MSSqlServer.schemaName"];

            //            Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));

            var filename = $"{Path.GetTempPath()}{GCS.Framework.Utilities.SystemUtilities.MyProcessName}-Serilog.log";
            var file = File.CreateText(filename);
            Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();
#else
            log4net.Config.XmlConfigurator.Configure();
#endif
            var cuName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var envName = Environment.UserName;
            GenericPrincipal principal = new GenericPrincipal(
                new GenericIdentity(cuName), new string[] { "Administrators", "GalaxySMSAdmin" });
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

            var redisCache = typeof(GCS.Framework.Caching.RedisCacheManager).Assembly;
            catalog.Add(new AssemblyCatalog(redisCache));

            //var managers = typeof(AdministrationManager).Assembly;
            //catalog.Add(new AssemblyCatalog(managers));

            StaticObjects.Container = MEFLoader.Init(catalog);
            this.Log().Info($"Container.Catalog count: {StaticObjects.Container.Catalog.Parts.Count()}");

            this.Log().Info("Starting up services...");

            _serverConnectionSettings = new GalaxySiteServerConnectionSettings
            {
                BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp,
                ServerName = "localhost",
                ServerAddress = "localhost",
                PortNumber = 8010
            };

            _siteServerConnection = new GalaxySiteServerConnection(_serverConnectionSettings);

            _hostAccountManager = new SM.ServiceHost(typeof(AccountManager));
            _hostAdministrationManager = new SM.ServiceHost(typeof(AdministrationManager));

            _hostGalaxyPanelCommunicationManager = new SM.ServiceHost(typeof(GalaxyPanelCommunicationManager));
            _hostUserSessionManager = new SM.ServiceHost(typeof(UserSessionManager));
            _hostSystemManager = new SM.ServiceHost(typeof(SystemManagement));
            _hostMercuryManager = new SM.ServiceHost(typeof(MercuryManagement));
            _hostPanelDataProcessingManager = new SM.ServiceHost(typeof(PanelDataProcessingManager));

            StartService(_hostAccountManager, "AccountManager");
            StartService(_hostPanelDataProcessingManager, "PanelDataProcessingManager");
            StartService(_hostGalaxyPanelCommunicationManager, "GalaxyPanelCommunicationManager");
            StartService(_hostAdministrationManager, "AdministrationManager");
            StartService(_hostUserSessionManager, "UserSessionManager");
            StartService(_hostSystemManager, "SystemManagement");
            StartService(_hostMercuryManager, "MercuryManagement");

            _initializeTimer = new System.Timers.Timer(1000);
            _initializeTimer.Elapsed += OnInitializeTimerElapsed;
            _initializeTimer.Start();

            //_timer = new System.Timers.Timer(10000);
            //_timer.Elapsed += OnTimerElapsed;
            //_timer.Start();

            //System.Console.WriteLine("Timer started.");
            this.Log().Info("Timer started.");
        }

        public void Stop()
        {
            if( _timer != null)
            _timer.Stop();

            this.Log().Info("Timer stopped.");

            if (_webApiServer != null)
            {
                _webApiServer.Dispose();
                _webApiServer = null;
            }

            StopService(_hostAccountManager, "AccountManager");
            StopService(_hostAccountManager, "GalaxyPanelCommunicationManager");
            StopService(_hostAdministrationManager, "AdministrationManager");
            StopService(_hostPanelDataProcessingManager, "PanelDataProcessingManager");
            StopService(_hostUserSessionManager, "UserSessionManager");
            StopService(_hostSystemManager, "SystemManagement");
            StopService(_hostMercuryManager, "MercuryManagement");

            Log.CloseAndFlush();

        }

        public void Pause()
        {

        }

        public void Continue()
        {

        }

        public void Shutdown()
        {

        }

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            var logger = LogManager.GetLogger<Program>();
            try
            {
                host.Open();
                //                System.Console.WriteLine("Service '{0}' started.", serviceDescription);
                logger.Info($"Service '{serviceDescription}' started.");
                //LogManager.GetLogger<Program>().InfoFormat("Service '{0}' started.", serviceDescription);
                foreach (var endpoint in host.Description.Endpoints)
                {
                    logger.Info($"Listening on endpoint: '{serviceDescription}' started. Listening on endpoint: Address: {endpoint.Address.Uri.ToString()}, Binding: {endpoint.Binding.Name}, Contract: {endpoint.Contract.ConfigurationName}");
                    //System.Console.WriteLine(string.Format("Listening on endpoint: "));
                    //System.Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                    //System.Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                    //System.Console.WriteLine(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
                }

                //System.Console.WriteLine();
            }
            catch (Exception ex)
            {
                logger.Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            var logger = LogManager.GetLogger<Program>();
            try
            {
                host.Close();
                //System.Console.WriteLine("Service '{0}' stopped.", serviceDescription);
                logger.InfoFormat("Service '{0}' stopped.", serviceDescription);
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.Message);
                //System.Console.WriteLine(ex.ToString());
                logger.Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Globals.Instance.CleanupExpiredSessions();
            Globals.Instance.CleanUpExpiredTwoFactorSessions();
        }


        private async void OnInitializeTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _initializeTimer.Stop();
            _initializeTimer = null;
            var isInitialized = await EnsureSystemIsInitialized();
            if (isInitialized)
                this.Log().Info($"Initializing system finished SUCCESSFULLY.");
            else
                this.Log().Info($"Initializing system finished. ** UNSUCCESSFUL");

            Globals.Instance.LoadSystem();

            // Now seed the database
            var isSeeded = await EnsureDatabaseIsSeeded();
            if (isSeeded)
                this.Log().Info($"Database seeding verification finished SUCCESSFULLY.");
            else
                this.Log().Info($"Database seeding verification finished. ** UNSUCCESSFUL");

            var systemManager = GetManager<GalaxySMS.Client.SDK.Managers.SystemManager>();
            var sys = await systemManager.GetSystemAsync(Globals.Instance.SystemData.SystemId);

            IApplicationUserSessionDataHeader sessionData = new ApplicationUserSessionHeader();
            sessionData.UserName = PrincipalIdentity.CurrentWindowsUserName;
            var settingsRepo = StaticObjects.Container.GetExportedValue<IGcsSettingRepository>();
            _autoStartPanelListener = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.GalaxyCPUConnections, MagicStringsSettingsGalaxyCPUConnectionsKey.AutoStartListener, true, true, sessionData);

            if (_autoStartPanelListener && Globals.Instance.SystemData != null)
            {
                bool bAllowConnections = true;
                if (Globals.Instance.SystemData.IsLicenseTrial && Globals.Instance.SystemData.IsLicenseExpired)
                {
                    this.Log().Info($"Trial license has expired. The system will not communicate with panels.");
                    bAllowConnections = false;
                    // temporarily override this
                    bAllowConnections = true;
                }
                if (bAllowConnections)
                {
                    var panelCommunicationMgr = GetManager<GalaxySMS.Client.SDK.Managers.GalaxyPanelCommunicationManager>();
                    panelCommunicationMgr.StartCommunicationServerAsync(null);
                }
            }


            if (isInitialized)
            {
                _timer = new System.Timers.Timer(10000);
                _timer.Elapsed += OnTimerElapsed;
                _timer.Start();
            }
        }

        public T GetManager<T>() where T : GalaxySMS.Client.SDK.Managers.ManagerBase, new()
        {
            var sessionHeader = _siteServerConnection.ClientUserSessionData;
            var manager = Helpers.GetManager<T>(_siteServerConnection.ConnectionSettings.ServerAddress,
                GalaxySiteServerConnectionSettings.WcfBindingType.Tcp, string.Empty, string.Empty, sessionHeader);
            return manager;
        }

        private async Task<bool> EnsureSystemIsInitialized()
        {
            this.Log().Info("Initializing system...");
            var doesSystemEntityExist = false;
            var entityManager = GetManager<Client.SDK.Managers.EntityManager>();
            if (entityManager != null)
            {
                var sysEntity = await entityManager.GetEntityAsync(new GetParametersWithPhoto()
                {
                    UniqueId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    DoNotValidateAuthorization = true, IncludeMemberCollections = false
                });
                doesSystemEntityExist = sysEntity != null;
            }

            if (doesSystemEntityExist)
            {
                var panelCommMgr = GetManager<GalaxySMS.Client.SDK.Managers.GalaxyPanelCommunicationManager>();
                panelCommMgr.StopCommunicationServerAsync(null);
                Thread.Sleep(250);
            }

            var requestData = new InitializeSystemDatabaseRequest
            {
                SystemData =
                {
                    SystemId = SystemIds.GalaxySMS_System_Id,
                    SystemName = Resources.Resources.DefaultCustomerName,
                    CompanyName = Resources.Resources.DefaultCustomerName,
                    CompanyEmail = Resources.Resources.DefaultCustomerEmail
                },
                InitializeSystemTables = true
            };

            var assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes();
            assemblyAttributes.Guid = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id;
            assemblyAttributes.Product = GalaxySMS.Common.Constants.MagicStrings.GalaxySMS;
            assemblyAttributes.Description = GalaxySMS.Common.Constants.MagicStrings.GalaxySMSDescription;

            var language = new gcsLanguage
            {
                LanguageId = LanguageIds.GalaxySMS_EN_US_Language_Id,
                LanguageName = GalaxySMS.Resources.Resources.LanguageName_enUS,
                CultureName = "en-US",
                Description = GalaxySMS.Resources.Resources.LanguageDescription_enUS,
                Notes = GalaxySMS.Resources.Resources.LanguageNotes_enUS,
                IsActive = true,
                IsDefault = true,
                IsDisplay = true
            };

            requestData.Languages.Add(language);


            var systemEntity = new gcsEntity
            {
                EntityId = EntityIds.GalaxySMS_SystemEntity_Id,
                EntityName = GalaxySMS.Resources.Resources.SystemEntity_Name,
                EntityDescription = GalaxySMS.Resources.Resources.SystemEntity_Description,
                EntityKey = GalaxySMS.Resources.Resources.SystemEntityKey,
                IsDefault = false,
                IsActive = true,
                IsAuthorized = true,
                EntityType = EntityTypes.Reserved
            };
            requestData.Entities.Add(systemEntity);

            var defaultEntity = new gcsEntity
            {
                EntityId = EntityIds.GalaxySMS_DefaultEntity_Id,
                EntityName = GalaxySMS.Resources.Resources.DefaultEntityName,
                EntityDescription = GalaxySMS.Resources.Resources.DefaultEntityDescription,
                EntityKey = GalaxySMS.Resources.Resources.DefaultEntityKey,
                IsDefault = true,
                IsActive = true,
                IsAuthorized = true,
                EntityType = EntityTypes.Administrator
            };


            requestData.Entities.Add(defaultEntity);

            // Create the main GalaxySMS application
            var application = new gcsApplication
            {
                ApplicationId = assemblyAttributes.Guid,
                ApplicationName = assemblyAttributes.Product,
                ApplicationDescription = assemblyAttributes.Description,
                LanguageId = LanguageIds.GalaxySMS_EN_US_Language_Id,
                //SystemRoleId = ApplicationRoleIds.GalaxySMS_AdministatorId,
                IsAuthorized = true
            };
            
            #region Permissions

            #region Panel Communication Permissions

            var panelCommunicationCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.CommunicationControlCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_CommunicationView_Name,
                PermissionCategoryDescription =
                    GalaxySMS.Resources.Resources.PermissionCategory_CommunicationView_Description,
                IsSystemCategory = true
            };

            // Panel communication tab
            var permission = new gcsPermission
            {
                PermissionCategoryId = panelCommunicationCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CommunicationControlCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_GalaxyPanelCommunicationCanView_Name,
                PermissionDescription =
                    GalaxySMS.Resources.Resources.Permission_GalaxyPanelCommunicationCanView_Description,
                IsActive = true
            };
            panelCommunicationCategory.Permissions.Add(permission);

            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});
            application.PermissionCategories.Add(panelCommunicationCategory);

            #endregion

            #region Language View Permissions

            var languagePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.LangaugeDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_LanguageEditing_Name,
                PermissionCategoryDescription =
                    GalaxySMS.Resources.Resources.PermissionCategory_LanguageEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = languagePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.LanguageCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_LanguageViewCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_LanguageViewCanView_Description,
                IsActive = true
            };
            languagePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});

            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = languagePermissionCategory.PermissionCategoryId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.LanguageCanAddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_LanguageViewCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_LanguageViewCanAdd_Description,
                IsActive = true
            };
            languagePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = languagePermissionCategory.PermissionCategoryId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.LanguageCanUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_LanguageViewCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_LanguageViewCanUpdate_Description,
                IsActive = true
            };
            languagePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = languagePermissionCategory.PermissionCategoryId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.LanguageCanDeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_LanguageViewCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_LanguageViewCanDelete_Description,
                IsActive = true
            };
            languagePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(languagePermissionCategory);

            #endregion

            #region Entity View Permissions

            var entityPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.EntityDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_EntityEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_EntityEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = entityPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_EntityViewCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_EntityViewCanView_Description,
                IsActive = true
            };
            entityPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = entityPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.EntityCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_EntityViewCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_EntityViewCanAdd_Description,
                IsActive = true
            };
            entityPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = entityPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.EntityCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_EntityViewCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_EntityViewCanUpdate_Description,
                IsActive = true
            };
            entityPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = entityPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.EntityCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_EntityViewCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_EntityViewCanDelete_Description,
                IsActive = true
            };
            entityPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(entityPermissionCategory);

            #endregion

            #region Application View Permissions

            var applicationPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.ApplicationDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_ApplicationEditing_Name,
                PermissionCategoryDescription =
                    GalaxySMS.Resources.Resources.PermissionCategory_ApplicationEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = applicationPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.ApplicationCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanView_Description,
                IsActive = true
            };
            applicationPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = applicationPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.ApplicationCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanAdd_Description,
                IsActive = true
            };
            applicationPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = applicationPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.ApplicationCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanUpdate_Description,
                IsActive = true
            };
            applicationPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = applicationPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.ApplicationCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ApplicationViewCanDelete_Description,
                IsActive = true
            };
            applicationPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(applicationPermissionCategory);

            #endregion

            #region Role View Permissions

            var rolePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.RoleDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_RoleEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_RoleEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = rolePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RoleCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RoleViewCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RoleViewCanView_Description,
                IsActive = true
            };
            rolePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = rolePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RoleCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RoleViewCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RoleViewCanAdd_Description,
                IsActive = true
            };
            rolePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = rolePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RoleCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RoleViewCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RoleViewCanUpdate_Description,
                IsActive = true
            };
            rolePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = rolePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RoleCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RoleViewCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RoleViewCanDelete_Description,
                IsActive = true
            };
            rolePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(rolePermissionCategory);

            #endregion

            #region Permission Category View Permissions

            var permissionCategoryPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.PermissionCategoryDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_PermissionCategoryEditing_Name,
                PermissionCategoryDescription =
                    GalaxySMS.Resources.Resources.PermissionCategory_PermissionCategoryEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionCategoryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCategoryCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanView_Description,
                IsActive = true
            };
            permissionCategoryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionCategoryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCategoryCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanAdd_Description,
                IsActive = true
            };
            permissionCategoryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionCategoryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCategoryCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanUpdate_Name,
                PermissionDescription =
                    GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanUpdate_Description,
                IsActive = true
            };
            permissionCategoryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionCategoryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCategoryCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanDelete_Name,
                PermissionDescription =
                    GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanDelete_Description,
                IsActive = true
            };
            permissionCategoryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(permissionCategoryPermissionCategory);

            #endregion

            #region Permission View Permissions

            var permissionPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.PermissionDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_PermissionEditing_Name,
                PermissionCategoryDescription =
                    GalaxySMS.Resources.Resources.PermissionCategory_PermissionEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanView_Description,
                IsActive = true
            };
            permissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanAdd_Description,
                IsActive = true
            };
            permissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanUpdate_Name,
                PermissionDescription =
                    GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanUpdate_Description,
                IsActive = true
            };
            permissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = permissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PermissionCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanDelete_Name,
                PermissionDescription =
                    GalaxySMS.Resources.Resources.Permission_PermissionCategoryViewCanDelete_Description,
                IsActive = true
            };
            permissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(permissionPermissionCategory);

            #endregion

            #region User View Permissions

            var userPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.UserDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_UserEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_UserEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.UserCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_UserViewCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_UserViewCanView_Description,
                IsActive = true
            };
            userPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.UserCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_UserViewCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_UserViewCanAdd_Description,
                IsActive = true
            };
            userPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.UserCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_UserViewCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_UserViewCanUpdate_Description,
                IsActive = true
            };
            userPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.UserCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_UserViewCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_UserViewCanDelete_Description,
                IsActive = true
            };
            userPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(userPermissionCategory);

            #endregion

            #region Country Permissions

            var countryPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.CountryDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_CountryEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_CountryEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = countryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CountryCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CountryCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CountryCanView_Description,
                IsActive = true
            };
            countryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = countryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CountryCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CountryCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CountryCanAdd_Description,
                IsActive = true
            };
            countryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = countryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CountryCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CountryCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CountryCanUpdate_Description,
                IsActive = true
            };
            countryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = countryPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CountryCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CountryCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CountryCanDelete_Description,
                IsActive = true
            };
            countryPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(countryPermissionCategory);

            #endregion

            #region State/Province Permissions

            var stateProvincePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.StateProvinceDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_StateProvinceEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_StateProvinceEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = stateProvincePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.StateProvinceCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_StateProvinceCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_StateProvinceCanView_Description,
                IsActive = true
            };
            stateProvincePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = stateProvincePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.StateProvinceCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_StateProvinceCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_StateProvinceCanAdd_Description,
                IsActive = true
            };
            stateProvincePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = stateProvincePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.StateProvinceCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_StateProvinceCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_StateProvinceCanUpdate_Description,
                IsActive = true
            };
            stateProvincePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = stateProvincePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.StateProvinceCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_StateProvinceCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_StateProvinceCanDelete_Description,
                IsActive = true
            };
            stateProvincePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(stateProvincePermissionCategory);

            #endregion

            #region Region Permissions

            var regionPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.RegionDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_RegionEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_RegionEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = regionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RegionCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RegionCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RegionCanView_Description,
                IsActive = true
            };
            regionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = regionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RegionCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RegionCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RegionCanAdd_Description,
                IsActive = true
            };
            regionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = regionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RegionCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RegionCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RegionCanUpdate_Description,
                IsActive = true
            };
            regionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = regionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.RegionCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_RegionCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_RegionCanDelete_Description,
                IsActive = true
            };
            regionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(regionPermissionCategory);

            #endregion

            #region Site Permissions

            var sitePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.SiteDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_SiteEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_SiteEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = sitePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SiteCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SiteCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SiteCanView_Description,
                IsActive = true
            };
            sitePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = sitePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SiteCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SiteCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SiteCanAdd_Description,
                IsActive = true
            };
            sitePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = sitePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SiteCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SiteCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SiteCanUpdate_Description,
                IsActive = true
            };
            sitePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = sitePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SiteCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SiteCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SiteCanDelete_Description,
                IsActive = true
            };
            sitePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(sitePermissionCategory);

            #endregion

            #region Access Portal Permissions

            var accessPortalPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.AccessPortalDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_AccessPortalEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_AccessPortalEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCanView_Description,
                IsActive = true
            };
            accessPortalPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCanAdd_Description,
                IsActive = true
            };
            accessPortalPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCanUpdate_Description,
                IsActive = true
            };
            accessPortalPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCanDelete_Description,
                IsActive = true
            };
            accessPortalPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(accessPortalPermissionCategory);
            #endregion

            #region Monitored Device Permissions

            var monitoredDevicePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.MonitoredDeviceDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_MonitoredDeviceEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_MonitoredDeviceEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = monitoredDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanView_Description,
                IsActive = true
            };
            monitoredDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = monitoredDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanAdd_Description,
                IsActive = true
            };
            monitoredDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = monitoredDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanUpdate_Description,
                IsActive = true
            };
            monitoredDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = monitoredDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_MonitoredDeviceCanDelete_Description,
                IsActive = true
            };
            monitoredDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(monitoredDevicePermissionCategory);

            #endregion

            #region Output Device Permissions

            var outputDevicePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.OutputDeviceDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_OutputDeviceEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_OutputDeviceEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanView_Description,
                IsActive = true
            };
            outputDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanAdd_Description,
                IsActive = true
            };
            outputDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanUpdate_Description,
                IsActive = true
            };
            outputDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputDevicePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputDeviceCanDelete_Description,
                IsActive = true
            };
            outputDevicePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(outputDevicePermissionCategory);

            #endregion

            #region Time Schedule Permissions

            var timeSchedulePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.TimeScheduleDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_TimeScheduleEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_TimeScheduleEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = timeSchedulePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanView_Description,
                IsActive = true
            };
            timeSchedulePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = timeSchedulePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanAdd_Description,
                IsActive = true
            };
            timeSchedulePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = timeSchedulePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanUpdate_Description,
                IsActive = true
            };
            timeSchedulePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = timeSchedulePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_TimeScheduleCanDelete_Description,
                IsActive = true
            };
            timeSchedulePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(timeSchedulePermissionCategory);

            #endregion

            #region Access Permission Permissions

            var accessPermissionPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.AccessPermissionDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_AccessPermissionEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_AccessPermissionEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPermissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPermissionCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanView_Description,
                IsActive = true
            };
            accessPermissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPermissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPermissionCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanAdd_Description,
                IsActive = true
            };
            accessPermissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPermissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPermissionCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanUpdate_Description,
                IsActive = true
            };
            accessPermissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPermissionPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessPermissionCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPermissionCanDelete_Description,
                IsActive = true
            };
            accessPermissionPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(accessPermissionPermissionCategory);

            #endregion

            #region Access Profile Permissions

            var accessProfilePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.AccessProfileDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_AccessProfileEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_AccessProfileEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessProfilePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessProfileCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessProfileCanView_Description,
                IsActive = true
            };
            accessProfilePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessProfilePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessProfileCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessProfileCanAdd_Description,
                IsActive = true
            };
            accessProfilePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessProfilePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessProfileCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessProfileCanUpdate_Description,
                IsActive = true
            };
            accessProfilePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessProfilePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessProfileCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessProfileCanDelete_Description,
                IsActive = true
            };
            accessProfilePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(accessProfilePermissionCategory);

            #endregion

            #region Department Permissions

            var departmentPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.DepartmentDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_DepartmentEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_DepartmentEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = departmentPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.DepartmentCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_DepartmentCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_DepartmentCanView_Description,
                IsActive = true
            };
            departmentPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = departmentPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.DepartmentCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_DepartmentCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_DepartmentCanAdd_Description,
                IsActive = true
            };
            departmentPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = departmentPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.DepartmentCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_DepartmentCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_DepartmentCanUpdate_Description,
                IsActive = true
            };
            departmentPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = departmentPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.DepartmentCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_DepartmentCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_DepartmentCanDelete_Description,
                IsActive = true
            };
            departmentPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(departmentPermissionCategory);

            #endregion

            #region PersonSelectItems Permissions

            var personSelectItemsPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.PersonSelectionItemDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_PersonSelectionItemEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_PersonSelectionItemEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personSelectItemsPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonSelectionItemCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanView_Description,
                IsActive = true
            };
            personSelectItemsPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personSelectItemsPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonSelectionItemCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanAdd_Description,
                IsActive = true
            };
            personSelectItemsPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personSelectItemsPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonSelectionItemCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanUpdate_Description,
                IsActive = true
            };
            personSelectItemsPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personSelectItemsPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonSelectionItemCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonSelectionItemCanDelete_Description,
                IsActive = true
            };
            personSelectItemsPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(personSelectItemsPermissionCategory);

            #endregion

            #region Badge Template Permissions

            var badgeTemplatePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.BadgeTemplateDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_BadgeTemplateEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_BadgeTemplateEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = badgeTemplatePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.BadgeTemplateCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanView_Description,
                IsActive = true
            };
            badgeTemplatePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = badgeTemplatePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.BadgeTemplateCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanAdd_Description,
                IsActive = true
            };
            badgeTemplatePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = badgeTemplatePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.BadgeTemplateCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanUpdate_Description,
                IsActive = true
            };
            badgeTemplatePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = badgeTemplatePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.BadgeTemplateCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_BadgeTemplateCanDelete_Description,
                IsActive = true
            };
            badgeTemplatePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(badgeTemplatePermissionCategory);

            #endregion

            #region Personnel Permissions

            var personnelPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.PersonnelDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_PersonnelEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_PersonnelEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonnelCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonnelCanView_Description,
                IsActive = true
            };
            personnelPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonnelCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonnelCanAdd_Description,
                IsActive = true
            };
            personnelPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonnelCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonnelCanUpdate_Description,
                IsActive = true
            };
            personnelPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PersonnelCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PersonnelCanDelete_Description,
                IsActive = true
            };
            personnelPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(personnelPermissionCategory);

            #endregion

            #region Personnel Property Access Permissions

            var personnelPropertyAccessPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.PersonnelPropertyAccessCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_PersonnelPropertyAccess_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_PersonnelPropertyAccess_Description,
                IsSystemCategory = true
            };

            // Can View Public Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPropertyAccessPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelPublicPropertyAccessCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewPropertyId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanViewPublic_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanViewPublic_Description,
                IsActive = true
            };
            personnelPropertyAccessPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Edit Public Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPropertyAccessPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelPublicPropertyAccessCanEditId,
                PermissionTypeId = PermissionTypeIds.EditPropertyId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanEditPublic_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanEditPublic_Description,
                IsActive = true
            };
            personnelPropertyAccessPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can View Confidentail Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPropertyAccessPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelConfidentialPropertyAccessCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewPropertyId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanViewConfidential_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanViewConfidential_Description,
                IsActive = true
            };
            personnelPropertyAccessPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Edit Confidential Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelPropertyAccessPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelConfidentialPropertyAccessCanEditId,
                PermissionTypeId = PermissionTypeIds.EditPropertyId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanEditConfidential_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanEditConfidential_Description,
                IsActive = true
            };
            personnelPropertyAccessPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Now add the permission category to the application
            application.PermissionCategories.Add(personnelPropertyAccessPermissionCategory);

            #endregion

            #region Personnel Access Control Property Access Permissions

            var personnelAccessControlPropertyAccessPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.PersonnelAccessControlPropertyAccessCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_PersonnelAccessControlPropertyAccess_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_PersonnelAccessControlPropertyAccess_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelAccessControlPropertyAccessPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelAccessControlPropertyAccessCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewPropertyId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanViewPublic_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanViewPublic_Description,
                IsActive = true
            };
            personnelAccessControlPropertyAccessPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Edit Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = personnelAccessControlPropertyAccessPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelAccessControlPropertyAccessCanEditId,
                PermissionTypeId = PermissionTypeIds.EditPropertyId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanEditPublic_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_PropertyAccess_CanEditPublic_Description,
                IsActive = true
            };
            personnelAccessControlPropertyAccessPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(personnelAccessControlPropertyAccessPermissionCategory);

            #endregion

            #region Credential Permissions

            var credentialPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.CredentialDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_CredentialEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_CredentialEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = credentialPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CredentialCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CredentialCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CredentialCanView_Description,
                IsActive = true
            };
            credentialPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CredentialCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CredentialCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CredentialCanAdd_Description,
                IsActive = true
            };
            credentialPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CredentialCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CredentialCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CredentialCanUpdate_Description,
                IsActive = true
            };
            credentialPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.CredentialCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CredentialCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CredentialCanDelete_Description,
                IsActive = true
            };
            credentialPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(credentialPermissionCategory);

            #endregion

            #region System Hardware Permissions

            var systemHardwarePermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.SystemHardwareDataAccessEditingCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_SystemHardwareEditing_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_SystemHardwareEditing_Description,
                IsSystemCategory = true
            };

            // Can View Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = systemHardwarePermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId,
                PermissionTypeId = PermissionTypeIds.ViewId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanView_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanView_Description,
                IsActive = true
            };
            systemHardwarePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Add Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId,
                PermissionTypeId = PermissionTypeIds.AddId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanAdd_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanAdd_Description,
                IsActive = true
            };
            systemHardwarePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Update Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId,
                PermissionTypeId = PermissionTypeIds.EditUpdateId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanUpdate_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanUpdate_Description,
                IsActive = true
            };
            systemHardwarePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Can Delete permission
            permission = new gcsPermission
            {
                PermissionCategoryId = userPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId,
                PermissionTypeId = PermissionTypeIds.DeleteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanDelete_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_SystemHardwareCanDelete_Description,
                IsActive = true
            };
            systemHardwarePermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Now add the permission category to the application
            application.PermissionCategories.Add(systemHardwarePermissionCategory);

            #endregion

            #region Command Permissions

            #region Access Portal Command Permissions
            var accessPortalCommandPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.AccessPortalCommandCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_AccessPortalCommand_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_AccessPortalCommand_Description,
                IsSystemCategory = true
            };

            // Lock Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.Lock,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Lock_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Lock_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Unlock Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.Unlock,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Unlock_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Unlock_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Unlock Momentarily Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.UnlockMomentarily,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_UnlockMomentarily_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_UnlockMomentarily_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Disable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.Disable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Disable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Disable_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Enable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.Enable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Enable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Enable_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Relay 2 Off Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.Relay2Off,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Relay2Off_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Relay2Off_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Relay 2 On Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.Relay2On,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Relay2On_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_Relay2On_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // SetLedTemporaryState Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.SetLedTemporaryState,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_SetLedTemporaryState_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_SetLedTemporaryState_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Request Status Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalCommandPermission.RequestStatus,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_RequestStatus_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalCommand_RequestStatus_Description,
                IsActive = true
            };
            accessPortalCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            application.PermissionCategories.Add(accessPortalCommandPermissionCategory);
            #endregion

            #region Access Portal Group Command Permissions
            var accessPortalGroupCommandPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.AccessPortalGroupCommandCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_AccessPortalGroupCommand_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_AccessPortalGroupCommand_Description,
                IsSystemCategory = true
            };

            // Lock Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Lock,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Lock_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Lock_Description,
                IsActive = true
            };
            accessPortalGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Unlock Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Unlock,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Unlock_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Unlock_Description,
                IsActive = true
            };
            accessPortalGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Disable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Disable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Disable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Disable_Description,
                IsActive = true
            };
            accessPortalGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Enable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = accessPortalGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Enable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Enable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AccessPortalGroupCommand_Enable_Description,
                IsActive = true
            };
            accessPortalGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});




            application.PermissionCategories.Add(accessPortalGroupCommandPermissionCategory);
            #endregion

            #region Input Command Permissions
            var inputCommandPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.InputDeviceCommandCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_InputCommand_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_InputCommand_Description,
                IsSystemCategory = true
            };

            // Shunt Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputCommandPermission.Shunt,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputCommand_Shunt_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputCommand_Shunt_Description,
                IsActive = true
            };
            inputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});




            // Unshunt Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputCommandPermission.Unshunt,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputCommand_Unshunt_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputCommand_Unshunt_Description,
                IsActive = true
            };
            inputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Disable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputCommandPermission.Disable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputCommand_Disable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputCommand_Disable_Description,
                IsActive = true
            };
            inputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Enable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputCommandPermission.Enable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputCommand_Enable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputCommand_Enable_Description,
                IsActive = true
            };
            inputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Request Status Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputCommandPermission.RequestStatus,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputCommand_RequestStatus_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputCommand_RequestStatus_Description,
                IsActive = true
            };
            inputCommandPermissionCategory.Permissions.Add(permission);

            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            application.PermissionCategories.Add(inputCommandPermissionCategory);
            #endregion

            #region Output Command Permissions
            var outputCommandPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.OutputDeviceCommandCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_OutputCommand_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_OutputCommand_Description,
                IsSystemCategory = true
            };

            // On Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSOutputCommandPermission.On,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputCommand_On_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputCommand_On_Description,
                IsActive = true
            };
            outputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Off Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSOutputCommandPermission.Off,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputCommand_Off_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputCommand_Off_Description,
                IsActive = true
            };
            outputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // Disable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSOutputCommandPermission.Disable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputCommand_Disable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputCommand_Disable_Description,
                IsActive = true
            };
            outputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Enable Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSOutputCommandPermission.Enable,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputCommand_Enable_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputCommand_Enable_Description,
                IsActive = true
            };
            outputCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Request Status Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = outputCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSOutputCommandPermission.RequestStatus,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_OutputCommand_RequestStatus_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_OutputCommand_RequestStatus_Description,
                IsActive = true
            };
            outputCommandPermissionCategory.Permissions.Add(permission);

            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            application.PermissionCategories.Add(outputCommandPermissionCategory);
            #endregion

            #region Input Output Group Command Permissions
            var inputOutputGroupCommandPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.InputOutputGroupCommandCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_InputOutputGroupCommand_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_InputOutputGroupCommand_Description,
                IsSystemCategory = true
            };

            // Shunt Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputOutputGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Shunt,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Shunt_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Shunt_Description,
                IsActive = true
            };
            inputOutputGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Unshunt Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputOutputGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Unshunt,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Unshunt_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Unshunt_Description,
                IsActive = true
            };
            inputOutputGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Arm Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputOutputGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Arm,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Arm_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Arm_Description,
                IsActive = true
            };
            inputOutputGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Disarm Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = inputOutputGroupCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Disarm,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Disarm_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_InputOutputGroupCommand_Disarm_Description,
                IsActive = true
            };
            inputOutputGroupCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});




            application.PermissionCategories.Add(inputOutputGroupCommandPermissionCategory);
            #endregion

            #region Cluster Command Permissions
            var clusterCommandPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.ClusterCommandCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_ClusterCommand_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_ClusterCommand_Description,
                IsSystemCategory = true
            };

            // Activate Crisis Mode Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.ActivateCrisisMode,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ActivateCrisisMode_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ActivateCrisisMode_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});



            // Reset Crisis Mode Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.ResetCrisisMode,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ResetCrisisMode_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ResetCrisisMode_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // ResetPanelWarm Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.ResetPanelWarm,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ResetPanelWarm_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ResetPanelWarm_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // ResetPanelCold Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.ResetPanelCold,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ResetPanelCold_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ResetPanelCold_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // ForgivePassback Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.ForgivePassback,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ForgivePassback_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ForgivePassback_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // ForgiveAllPassback Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.ForgiveAllPassback,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ForgiveAllPassback_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ForgiveAllPassback_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // EnableCredential Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.EnableCredential,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_EnableCredential_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_EnableCredential_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // DisableCredential Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.DisableCredential,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_DisableCredential_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_DisableCredential_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // LoadPanelFlash Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.LoadPanelFlash,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_LoadPanelFlash_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_LoadPanelFlash_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // ClearLogBuffer Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.ClearLogBuffer,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ClearLogBuffer_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_ClearLogBuffer_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            // DeleteAllCards Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = clusterCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSClusterCommandPermission.DeleteAllCards,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_ClusterCommand_DeleteAllCards_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_ClusterCommand_DeleteAllCards_Description,
                IsActive = true
            };
            clusterCommandPermissionCategory.Permissions.Add(permission);
            //role.RolePermissions.Add(new gcsRolePermission
            //{
            //    RoleId = role.RoleId,
            //    PermissionId = permission.PermissionId
            //});


            application.PermissionCategories.Add(clusterCommandPermissionCategory);
            #endregion

            #region Alarm Alert Event Command Permissions
            var alarmEventCommandPermissionCategory = new gcsPermissionCategory
            {
                PermissionCategoryId = PermissionCategoryIds.AlarmAlertCommandCategoryId,
                ApplicationId = application.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_AlarmAlertCommand_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_AlarmAlertCommand_Description,
                IsSystemCategory = true
            };

            // Acknowledge Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = alarmEventCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAlarmAlertCommandPermission.Acknowledge,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AlarmAlertCommand_Acknowledge_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AlarmAlertCommand_Acknowledge_Description,
                IsActive = true
            };
            alarmEventCommandPermissionCategory.Permissions.Add(permission);

            // Unlock Command Permission
            permission = new gcsPermission
            {
                PermissionCategoryId = alarmEventCommandPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.GalaxySMSAlarmAlertCommandPermission.Unacknowledge,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_AlarmAlertCommand_Unacknowledge_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_AlarmAlertCommand_Unacknowledge_Description,
                IsActive = true
            };
            alarmEventCommandPermissionCategory.Permissions.Add(permission);

            application.PermissionCategories.Add(alarmEventCommandPermissionCategory);
            #endregion
            #endregion

            #endregion

            requestData.Applications.Add(application);


            // Now create the Admin application
            var appAdminMgr = new gcsApplication
            {
                ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_Admin_Id,
                ApplicationName = GalaxySMS.Common.Constants.ApplicationNames.GalaxySMS_Admin,
                ApplicationDescription = GalaxySMS.Common.Constants.ApplicationDescriptions.GalaxySMS_Admin,
                LanguageId = LanguageIds.GalaxySMS_EN_US_Language_Id,
                //SystemRoleId = ApplicationRoleIds.GalaxySMS_Admin_AdministatorId,
                IsAuthorized = true
            };


            #region Permissions
            #region Can Execute permission(s)
            var canExecuteAdminMgrPermissionCategory = new gcsPermissionCategory()
            {
                PermissionCategoryId = PermissionCategoryIds.GalaxySMS_Admin_CanExecuteCategoryId,
                ApplicationId = appAdminMgr.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_CanExecute_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_CanExecute_Description,
                IsSystemCategory = true,
            };

            var permissionCanExecAdminMgr = new gcsPermission()
            {
                PermissionCategoryId = canExecuteAdminMgrPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.CanExecuteIds.GalaxySMS_Admin_CanExecuteId,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CanExecuteApplication_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CanExecuteApplication_Description,
                IsActive = true
            };
            canExecuteAdminMgrPermissionCategory.Permissions.Add(permissionCanExecAdminMgr);

            appAdminMgr.PermissionCategories.Add(canExecuteAdminMgrPermissionCategory);

            #endregion
            #endregion

            requestData.Applications.Add(appAdminMgr);

            // Now create the Facility Manager application
            var appFacMgr = new gcsApplication
            {
                ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_FacilityManager_Id,
                ApplicationName = GalaxySMS.Common.Constants.ApplicationNames.GalaxySMS_FacilityManager,
                ApplicationDescription = GalaxySMS.Common.Constants.ApplicationDescriptions.GalaxySMS_FacilityManager,
                LanguageId = LanguageIds.GalaxySMS_EN_US_Language_Id,
                //SystemRoleId = ApplicationRoleIds.GalaxySMS_FacilityManager_AdministatorId,
                IsAuthorized = true
            };


            #region Permissions
            #region Can Execute permission(s)
            var canExecuteFacMgrPermissionCategory = new gcsPermissionCategory()
            {
                PermissionCategoryId = PermissionCategoryIds.GalaxySMS_FacilityManager_CanExecuteCategoryId,
                ApplicationId = appFacMgr.ApplicationId,
                CategoryName = GalaxySMS.Resources.Resources.PermissionCategory_CanExecute_Name,
                PermissionCategoryDescription = GalaxySMS.Resources.Resources.PermissionCategory_CanExecute_Description,
                IsSystemCategory = true,
            };

            var permissionCanExecFacMgr = new gcsPermission()
            {
                PermissionCategoryId = canExecuteFacMgrPermissionCategory.PermissionCategoryId,
                PermissionId = PermissionIds.CanExecuteIds.GalaxySMS_FacilityManager_CanExecuteId,
                PermissionTypeId = PermissionTypeIds.ExecuteId,
                PermissionName = GalaxySMS.Resources.Resources.Permission_CanExecuteApplication_Name,
                PermissionDescription = GalaxySMS.Resources.Resources.Permission_CanExecuteApplication_Description,
                IsActive = true,
            };
            canExecuteFacMgrPermissionCategory.Permissions.Add(permissionCanExecFacMgr);

            appFacMgr.PermissionCategories.Add(canExecuteFacMgrPermissionCategory);

            #endregion

            #endregion

            requestData.Applications.Add(appFacMgr);

            var user = new gcsUser
            {
                UserId = UserIds.GalaxySMS_Administrator_Id,
                LanguageId = application.LanguageId,
                FirstName = GalaxySMS.Resources.Resources.DefaultUserFirstName,
                LastName = GalaxySMS.Resources.Resources.DefaultUserLastName,
                Email = GalaxySMS.Resources.Resources.DefaultUserEmail,
                UserName = GalaxySMS.Resources.Resources.DefaultUserLoginName,
                DisplayName = GalaxySMS.Resources.Resources.DefaultUserDisplayName,
                NormalizedEmail = GalaxySMS.Resources.Resources.DefaultUserEmail.ToUpper(),
                NormalizedUserName = GalaxySMS.Resources.Resources.DefaultUserLoginName.ToUpper(),
                UserPassword =
                    Crypto.EncryptString(GalaxySMS.Resources.Resources.DefaultUserPassword,
                        UserIds.GalaxySMS_Administrator_Id.ToString()),
                IsLockedOut = false,
                IsActive = true,
                ResetPasswordFlag = true,
                ImportedFromActiveDirectory = false,
                PrimaryEntityId = EntityIds.GalaxySMS_DefaultEntity_Id,
                PhoneNumber = GalaxySMS.Resources.Resources.DefaultPhoneNumber,
            };

            //foreach (var app in requestData.Applications)
            //{
            //    var a = new gcsApplication(app);
            //    foreach (var e in requestData.Entities)
            //        e.AllApplications.Add(a);
            //}

            user.AllEntities.AddRange(requestData.Entities);

            foreach (var e in user.AllEntities)
            {
                var ue = new gcsUserEntity()
                {
                    EntityId = e.EntityId,
                };
                ue.UserEntityRoles.Add(new gcsUserEntityRole()
                {
                    RoleId = GalaxySMS.Common.Constants.RoleIds.GalaxySMS_AdministatorId
                });

                //foreach (var r in e.AllRoles)
                //{
                //    ue.gcsUserEntityRoles.Add(new gcsUserEntityRole()
                //    {
                //        RoleId = r.RoleId
                //    });
                //}
                user.UserEntities.Add(ue);
            }

            requestData.Users.Add(user);

            var initSystemMgr = GetManager<GalaxySMS.Client.SDK.Managers.InitializeSystemDatabaseManager>();
            var initialized = await initSystemMgr.InitializeSystemDatabaseAsync(requestData);
            return initialized;
        }


        private async Task ClearAllCpuConnectionStatus(GalaxyCpuConnection cpuConnection)
        {
            try
            {
                var mgr = GetManager<GalaxySMS.Client.SDK.Managers.PanelDataProcessingManager>();

                var bRet = await mgr.UpdateGalaxyCpuConnectionAsync(cpuConnection);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }
        private async Task<bool> EnsureDatabaseIsSeeded()
        {
            this.Log().Info($"Verifying that the database is seeded...");

            try
            {
                var seedDatabaseManager = GetManager<GalaxySMS.Client.SDK.Managers.SeedDatabaseManager>();
                var parameters = new SaveParameters<SeedDatabaseRequest>() { SavePhoto = true, };

                #region Brands

                var brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameGalaxyControlSystems,
                    BrandName = SharedResources.Resources.Brand_BrandNameGalaxyControlSystems,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_GalaxyControlSystems,
                };

                BitmapImage imageSource;
                try
                {
                    //imageSource =
                    //    new BitmapImage(
                    //        new Uri(
                    //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/GalaxyLogo.png",
                    //            UriKind.Absolute));

                    //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                    brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/GalaxyControlSystems/GalaxyLogo.png");
                    parameters.Data.Brands.Add(brand);
                }
                catch (Exception e)
                {
                    this.Log().Error(e.ToString());
                }

                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameAssaAbloy,
                    BrandName = SharedResources.Resources.Brand_BrandNameAssaAbloy,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_ASSAABLOY,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/ASSAABLOY/mainAALogo.jpg",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/ASSAABLOY/mainAALogo.jpg");
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameAllegion,
                    BrandName = SharedResources.Resources.Brand_BrandNameAllegion,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Allegion,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Allegion/Allegion_Logo.jpg",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Allegion/Allegion_Logo.jpg");
                parameters.Data.Brands.Add(brand);

                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameFarpointe,
                    BrandName = SharedResources.Resources.Brand_BrandNameFarpointe,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Farpointe,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Farpointe_Logo.jpg",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Farpointe/Farpointe_Logo.jpg");
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameHID,
                    BrandName = SharedResources.Resources.Brand_BrandNameHID,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_HID,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/HID/hidw200.png",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/HID/hidw200.png");
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameSafran,
                    BrandName = SharedResources.Resources.Brand_BrandNameSafranMorpho,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_SafranMorpho,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/SafranMorpho/morpho200.jpg",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/SafranMorpho/morpho200.jpg");
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameSalto,
                    BrandName = SharedResources.Resources.Brand_BrandNameSalto,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Salto,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Salto/SALTO.png",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Salto/SALTO.png");
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameEssex,
                    BrandName = SharedResources.Resources.Brand_BrandNameEssex,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Essex,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Essex/essex-logo.jpg",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Essex/essex-logo.jpg");
                parameters.Data.Brands.Add(brand);

                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameXico,
                    BrandName = SharedResources.Resources.Brand_BrandNameXico,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Xico,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Xico/logo.png",
                //            UriKind.Absolute));
                //brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                brand.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Xico/logo.png");
                parameters.Data.Brands.Add(brand);
                #endregion

                #region CredentialReaderDataFormats

                var credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_GalaxyInfrared,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.Unknown,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.None
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_ClockData,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.ClockDataStandard,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockData
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.ClockDataInverted,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockDataInverted
                };

                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed,
                    PanelDataFormatCode =
                        (int)
                        GalaxySMS.Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockData8DigitFixed
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_RS232G5,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.Rs232G5,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.RS232G5
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_Wiegand,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.WiegandFormat,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_WiegandKey,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.WiegandKey,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.WiegandKey
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.XceedIdPiv,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.XceedIdPiv
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.XceedIdPivWiegand
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_Cardax,
                    PanelDataFormatCode = (int)Common.Enums.CredentialReaderDataFormat.Cardax,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Cardax
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.CardaxWiegand,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.CardaxWiegand
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                #endregion

                #region CredentialReaderType

                var credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.AssaAbloyIPEnabledLock,
                    BrandUid = Common.Constants.BrandIds.Brand_ASSAABLOY,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeName_ASSAAbloyIPEnabledLock,
                    Model = SharedResources.Resources.CredentialReaderTypeName_ASSAAbloyIPEnabledLock,
                    Description = SharedResources.Resources.CredentialReaderTypeName_ASSAAbloyIPEnabledLock,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/ASSAABLOY/Products/WIFI/SAR_Profile SeriesS2.png",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/ASSAABLOY/Products/WIFI/SAR_Profile SeriesS2.png");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardWiegand,
                    BrandUid = Common.Constants.BrandIds.Brand_GalaxyControlSystems,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Standard_Wiegand,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Standard_Wiegand,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Standard_Wiegand,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/standard_wiegand.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/GalaxyControlSystems/standard_wiegand.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardDataClock,
                    BrandUid = Common.Constants.BrandIds.Brand_GalaxyControlSystems,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Standard_DataClock,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Standard_DataClock,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Standard_DataClock,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockData
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/standard_data_clock.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/GalaxyControlSystems/standard_data_clock.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);


                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.FarpointeRanger,
                    BrandUid = Common.Constants.BrandIds.Brand_Farpointe,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Farpointe_Pyramid,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Farpointe_Pyramid,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Farpointe_Pyramid,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Pyramid/grp_pyramid.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Farpointe/Pyramid/grp_pyramid.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.FarpointeDelta,
                    BrandUid = Common.Constants.BrandIds.Brand_Farpointe,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Farpointe_Delta,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Farpointe_Delta,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Farpointe_Delta,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Delta/grp_delta.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Farpointe/Delta/grp_delta.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.FarpointeRanger,
                    BrandUid = Common.Constants.BrandIds.Brand_Farpointe,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Farpointe_Ranger,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Farpointe_Ranger,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Farpointe_Ranger,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Ranger/grp_ranger.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Farpointe/Ranger/grp_ranger.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.HIDProx125K,
                    BrandUid = Common.Constants.BrandIds.Brand_HID,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_HID_125KProx,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_HID_125KProx,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_HID_125KProx,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/HID/125K/readers-prox-banner_0.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/HID/125K/readers-prox-banner_0.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);


                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.HIDiClassSE,
                    BrandUid = Common.Constants.BrandIds.Brand_HID,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_HID_iClassSE,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_HID_iClassSE,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_HID_iClassSE,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/HID/iClass/SE/readers-iclass-se-platform-banner_0.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/HID/iClass/SE/readers-iclass-se-platform-banner_0.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.EssexKeypad,
                    BrandUid = Common.Constants.BrandIds.Brand_Essex,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_EssexKeypad,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_EssexKeypad,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_EssexKeypad,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.None
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Essex/12-PadBothSm.png",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Essex/12-PadBothSm.png");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);


                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.InvertedDataClock,
                    BrandUid = Common.Constants.BrandIds.Brand_Xico,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_XicoMagStripe,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_XicoMagStripe,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_XicoMagStripe,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockDataInverted
                };
                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Xico/36001.jpg",
                //            UriKind.Absolute));
                //credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                credentialReaderType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Xico/36001.jpg");
                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);
                #endregion

                #region AccessPortalTypes

                var accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_AssaIpEnabledLock,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_AssaIpEnabledLock,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.AssaAbloyIPEnabledLock
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);

                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_StandardWiegand,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_StandardWiegand,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardWiegand
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);

                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_StandardDataClock,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_StandardDataClock,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardDataClock
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);


                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_InvertedDataClock,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_InvertedDataClock,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.InvertedDataClock
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);


                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_EssexKeypad,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_EssexKeypad,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.EssexKeypad
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);

                #endregion

                #region InputDeviceSupervisionTypes

                var inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid = GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.None,
                    IsActive = true,
                    IsDefault = true,
                    HasSeriesResistor = false,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervision.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervision.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervision.TroubleShort,
                    AlternateVoltagesEnabled = true,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervisionAlternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervisionAlternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervisionAlternate.TroubleShort,
                    Display = SharedResources.Resources.InputDeviceSupervisionType_None_Display,
                    Description = SharedResources.Resources.InputDeviceSupervisionType_None_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.None.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenNoSupervision.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenNoSupervision.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = 0,
                    TroubleOpenThreshold = 0,
                    TroubleShortThreshold = 0,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold = 0,
                    AlternateTroubleOpenThreshold = 0,
                    AlternateTroubleShortThreshold = 0,
                    Display = SharedResources.Resources.InputDeviceSupervisionType_SeriesInLine_Display,
                    Description = SharedResources.Resources.InputDeviceSupervisionType_SeriesInLine_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeries.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine1000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine1000.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeries.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine2000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine2000.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeries.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine2200,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine2200.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeries.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine4700,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine4700.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeries.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = 0,
                    TroubleOpenThreshold = 0,
                    TroubleShortThreshold = 0,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold = 0,
                    AlternateTroubleOpenThreshold = 0,
                    AlternateTroubleShortThreshold = 0,
                    Display = SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Display,
                    Description = SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine1000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine1000.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine2000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine2000.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine2200,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine2200.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine4700,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine4700.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = 0,
                    TroubleOpenThreshold = 0,
                    TroubleShortThreshold = 0,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold = 0,
                    AlternateTroubleOpenThreshold = 0,
                    AlternateTroubleShortThreshold = 0,
                    Display =
                        SharedResources.Resources.InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLine_Display,
                    Description =
                        SharedResources.Resources
                            .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLine_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeriesAndParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel1000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel1000.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeriesAndParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel2000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel2000.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeriesAndParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel2200,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel2200.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeriesAndParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel4700,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel4700.ToString()
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                //            UriKind.Absolute));
                //inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeriesAndParallel.png");
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                #endregion

                #region AccessPortalContactSupervisionTypes


                var accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.None,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_None_Display,
                    Description =
                        SharedResources.Resources.AccessPortalContactSupervisionType_None_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.None.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.None,
                    IsActive = true,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenNoSupervision.png",
                //            UriKind.Absolute));
                //accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenNoSupervision.png");
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);


                accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.SeriesAndParallel,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_SeriesAndParallel_Display,
                    Description =
                        SharedResources.Resources.AccessPortalContactSupervisionType_SeriesAndParallel_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesAndParallel.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesAndParallel,
                    IsActive = true,
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                //            UriKind.Absolute));
                //accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeriesAndParallel.png");
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);


                accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.SeriesInLine,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_SeriesInLine_Display,
                    Description = SharedResources.Resources.AccessPortalContactSupervisionType_SeriesInLine_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesInLine.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesInLine,
                    IsActive = true,
                    IsDefault = false
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                //            UriKind.Absolute));
                //accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenSeries.png");
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);

                accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.ParallelEndOfLine,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_ParallelEndOfLine_Display,
                    Description =
                        SharedResources.Resources.AccessPortalContactSupervisionType_ParallelEndOfLine_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.ParallelEndOfLine.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.ParallelEndOfLine,
                    IsActive = true
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                //            UriKind.Absolute));
                //accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("InputSupervisionType/NormalOpenParallel.png");
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);

                #endregion

                #region AccessPortalElevatorControlType

                var accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.None,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_None_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_None_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.None.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.None,
                    IsActive = true,
                    IsDefault = true
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/none.png",
                //            UriKind.Absolute));

                //accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("none.png");
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_708);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);


                // Galaxy Control Systems Relay
                accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.GalaxyElevatorControlRelays,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_GalaxyElevatorControlRelays_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_GalaxyElevatorControlRelays_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.GalaxyElevatorControlRelays.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.GalaxyElevatorControlRelays,
                    IsActive = true,
                    IsDefault = false
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/GalaxyLogoArrows.jpg",
                //            UriKind.Absolute));

                //accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/GalaxyControlSystems/GalaxyLogoArrows.jpg");
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_708);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);


                // Otis Compass
                accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.OtisCompass,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_OtisCompass_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_OtisCompass_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.OtisCompass.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.OtisCompass,
                    IsActive = true,
                    IsDefault = false
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Otis/Otis.jpg",
                //            UriKind.Absolute));

                //accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Otis/Otis.jpg");
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_708);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);

                // Kone Compass
                accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.KoneEli,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_KoneEli_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_KoneEli_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.KoneEli.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.KoneEli,
                    IsActive = true,
                    IsDefault = false
                };

                //imageSource =
                //    new BitmapImage(
                //        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Kone/KONE_180.png",
                //            UriKind.Absolute));

                //accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Partners/Kone/KONE_180.png");
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_708);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);
                #endregion

                #region GalaxyOutputMode

                // Follows
                var galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Follows,
                    Display = SharedResources.Resources.GalaxyOutputMode_Follows_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Follows_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Follows,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Follows.ToString()
                };
                //galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/follows.png",
                //            UriKind.Absolute));

                galaxyOutputMode.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/follows.png");
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Latching
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Latching,
                    Display = SharedResources.Resources.GalaxyOutputMode_Latching_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Latching_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Latching,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Latching.ToString()
                };

                //galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/padlock2_unlock-user.png",
                //            UriKind.Absolute));
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/padlock2_unlock-user.png");

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Scheduled
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Scheduled,
                    Display = SharedResources.Resources.GalaxyOutputMode_Scheduled_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Scheduled_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Scheduled,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Scheduled.ToString()
                };
                //galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/scheduled.png",
                //            UriKind.Absolute));
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/scheduled.png");

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // TimeoutRetriggerable
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.TimeoutRetriggerable,
                    Display = SharedResources.Resources.GalaxyOutputMode_TimeoutRetriggerable_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_TimeoutRetriggerable_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.TimeoutRetriggerable,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.TimeoutRetriggerable.ToString()
                };
                //galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                //            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/timeout-retriggerable.png",
                //            UriKind.Absolute));
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/timeout-retriggerable.png");

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Timeout
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Timeout,
                    Display = SharedResources.Resources.GalaxyOutputMode_Timeout_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Timeout_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Timeout,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Timeout.ToString()
                };
                //galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/timeout.png",
                //    UriKind.Absolute));
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/timeout.png");

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Limit
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Limit,
                    Display = SharedResources.Resources.GalaxyOutputMode_Limit_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Limit_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Limit,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Limit.ToString()
                };
                //galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/limit.png",
                //    UriKind.Absolute));
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/limit.png");

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Counter
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Counter,
                    Display = SharedResources.Resources.GalaxyOutputMode_Counter_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Counter_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Counter,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Counter.ToString()
                };
                //galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/counter_up_down.png",
                //    UriKind.Absolute));
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/counter_up_down.png");


                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);


                #endregion

                #region GalaxyOutputInputSourceRelationship

                // OR
                var galaxyOutputInputSourceRelationship = new GalaxyOutputInputSourceRelationship
                {
                    GalaxyOutputInputSourceRelationshipUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceRelationshipIds.OR,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceRelationship_OR_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceRelationship_OR_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.OR,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.OR.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/or.png",
                        //    UriKind.Absolute))
                        BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Logic/or.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceRelationships.Add(galaxyOutputInputSourceRelationship);

                galaxyOutputInputSourceRelationship = new GalaxyOutputInputSourceRelationship
                {
                    GalaxyOutputInputSourceRelationshipUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceRelationshipIds.AND,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceRelationship_AND_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceRelationship_AND_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.AND,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.AND.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/and.png",
                        //    UriKind.Absolute))
                        BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Logic/and.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceRelationships.Add(galaxyOutputInputSourceRelationship);

                #endregion

                #region GalaxyOutputInputSourceMode

                // OR
                var galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.OR,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_OR_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_OR_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.OR,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.OR.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/or.png",
                        //    UriKind.Absolute))
                        BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Logic/or.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);

                // AND
                galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.AND,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_AND_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_AND_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.AND,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.AND.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/and.png",
                        //    UriKind.Absolute))
                        BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Logic/and.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);

                // NAND
                galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.NAND,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_NAND_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_NAND_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NAND,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NAND.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/nand.png",
                        //    UriKind.Absolute))
                        BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Logic/nand.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);

                // NOR
                galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.NOR,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_NOR_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_NOR_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NOR,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NOR.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/nor.png",
                        //    UriKind.Absolute))
                        BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Logic/nor.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);
                #endregion

                #region GalaxyOutputInputSourceTriggerCondition

                // Nothing
                var galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Nothing,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Nothing_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Nothing_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Nothing,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Nothing.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/none.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/none.png")
                   }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Active
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.OnOrAlarm,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Active_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Active_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.OnOrAlarm,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.OnOrAlarm.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-orange.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/alarm_bell-orange.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);


                // Alarm
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Alarm,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Alarm_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Alarm_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Alarm,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Alarm.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-red.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/alarm_bell-red.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // On
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.On,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_On_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_On_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.On,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.On.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/alarm_bell.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Armed
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Armed,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Armed_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Armed_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Armed,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Armed.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-green-dark.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/alarm_bell-green-dark.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Disarmed
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Disarmed,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Disarmed_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Disarmed_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Disarmed,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Disarmed.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-gray.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/alarm_bell-gray.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);


                // Trouble
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Trouble,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Trouble_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Trouble_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Trouble,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Trouble.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm-tools-orange.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/alarm-tools-orange.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Trouble or Alarm
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.TroubleOrAlarm,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_AlarmOrTrouble_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_AlarmOrTrouble_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.TroubleOrAlarm,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.TroubleOrAlarm.ToString(),
                    gcsBinaryResource =
                    {
                        //BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                        //    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm-tools-red.png",
                        //    UriKind.Absolute))
                         BinaryResource = GalaxySMS.Resources.Helpers.GetImageAsBytes("Outputs/32x32/alarm-tools-red.png")
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);
                #endregion
                bool result = await seedDatabaseManager.SeedDatabaseAsync(parameters);
                if (seedDatabaseManager.HasErrors)
                {
                    foreach (var error in seedDatabaseManager.Errors)
                    {
                        this.Log().Error(error.ErrorMessage);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                this.Log().Error(e.ToString());
            }
            return false;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger<Program>();
            //var logFilename = $"{GCS.Framework.Utilities.SystemUtilities.MyFolderLocation}\\Logfiles\\GalaxySMS.Console.log";
            var rc = HostFactory.Run(x =>
             {
                 x.Service<WcfServiceHost>(s =>
                 {
                     s.ConstructUsing(name => new WcfServiceHost());
                     s.WhenStarted(tc => tc.Start());
                     s.WhenStopped(tc => tc.Stop());
                     //s.WhenPaused(tc => tc.Pause());
                     //s.WhenContinued((tc => tc.Continue());
                     //s.WhenShutdown(tc => tc.Shutdown());
                 });

                 x.RunAsLocalSystem();

                 x.SetDescription("GalaxySMS WCF Services");
                 x.SetDisplayName("GalaxySMS.ServiceHost");
                 x.SetServiceName("GalaxySMS.ServiceHost");
#if UseSerilog
                 x.UseSerilog();
#else
                x.UseLog4Net();
#endif
                 x.StartAutomatically();
                 x.EnableServiceRecovery(r =>
                     {
                         r.RestartService(1); // restart the service after 1 minute
                         r.SetResetPeriod(1); // set the reset interval to one day
                     });

                 x.OnException(ex =>
                 {
                     logger.Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                 });
             });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }

    }
}
