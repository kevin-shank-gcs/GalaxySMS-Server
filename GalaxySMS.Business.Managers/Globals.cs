using AutoMapper;
using GalaxySMS.Business.Entities;
using GalaxySMS.Business.Managers.Support;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.Utils;
using GCS.PanelDataHandlers;
using GCS.PanelDataProcessors.Interfaces;
using Newtonsoft.Json;
using PDSA.MessageBroker;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Redis;
using Hangfire;
using Hangfire.SqlServer;
using GCS.PanelCommunication.PanelCommunicationServerAsync;

namespace GalaxySMS.Business.Managers
{
    public class Globals : IDisposable
    {
        #region Private fields
        private static Globals _instance;
        /// <summary>   Queue for processing messages that need to be sent elsewhere. </summary>
        private BlockingCollection<object> _processingQueue;
        private Timer _waitForProcessingQueueToEmptyTimer;
        private IPanelOutputDataProcessor _panelOutputDataRecorder;
        IDataRepositoryFactory _dataRepositoryFactory;

        private gcsSystem _systemData;
        private string _cdnUploadUrl = "http://localhost:38004";
        private readonly IGcsUserRepository _gcsUserRepository = null;
        private readonly IGcsEntityRepository _gcsEntityRepository = null;
        private string _RedisHost;

        private int _RedisPort;

        // Hangfire server
        private BackgroundJobServer _hangfireServer;
        #endregion

        private Globals()
        {
            CurrentUserSessions = new Dictionary<Guid, UserSessionToken>();
            CurrentTwoFactorPendingUserSessions = new Dictionary<Guid, UserSignInResult>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            Mapper = configuration.CreateMapper();
            LoadSystem();
            _gcsUserRepository = StaticObjects.Container.GetExportedValue<IGcsUserRepository>();
            _gcsEntityRepository = StaticObjects.Container.GetExportedValue<IGcsEntityRepository>();
            MessageBroker = new PDSAMessageBroker();

            _processingQueue = new System.Collections.Concurrent.BlockingCollection<object>();

            StartPanelOutputDataProcessors();

        }

        public void LoadSystem()
        {
            var settingsRepo = StaticObjects.Container.GetExportedValue<IGcsSettingRepository>();
            var gcsSystemRepo = StaticObjects.Container.GetExportedValue<IGcsSystemRepository>();
            IApplicationUserSessionDataHeader sessionData = new ApplicationUserSessionHeader();
            sessionData.UserName = PrincipalIdentity.CurrentWindowsUserName;

            SystemData = gcsSystemRepo.Get(GalaxySMS.Common.Constants.SystemIds.GalaxySMS_System_Id, sessionData, new GetParametersWithPhoto());//GetAll(sessionData, new GetParametersWithPhoto()).FirstOrDefault();

            if (SystemData != null)
            {   // The system (db) has not been initialized at all.

                if (string.IsNullOrEmpty(SystemData?.License))
                    SystemData = gcsSystemRepo.Update(SystemData, sessionData, new SaveParameters() { });

                int timeout = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.UserSession, MagicStringsSettingsUserSessionKey.Timeout, 1440, true, sessionData);

                if (timeout > 0)
                    UserSessionTimeout = new TimeSpan(0, timeout, 0);

                UploadedFilesStaleDays = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Uploads, MagicStringsSettingsUploadsKey.StaleDays, 2, true, sessionData);

                MaxUploadFileSize = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Uploads, MagicStringsSettingsUploadsKey.MaxUploadFileSize, 10 * 1024 * 1024, true, sessionData);

                IdProducerSettings.Url = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.Url, "http://localhost:81/idProducer.BadgingServer/MasterService/JsonService_V2/", true, sessionData);

                IdProducerSettings.DevUrl = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.DevUrl, "http://localhost:81/idProducer.BadgingServer/MasterService/JsonService_V2/", true, sessionData);

                IdProducerSettings.SignalRUrl = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.SignalRUrl, "http://localhost:81/idProducer.BadgingServer/", true, sessionData);

                IdProducerSettings.UserName = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.UserName, "master@idProducer.com", true, sessionData);

                IdProducerSettings.Password = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.Password, "master", true, sessionData);

                IdProducerSettings.DefaultSubscriptionId = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.DefaultSubscriptionId, 1000, true, sessionData);

                IdProducerSettings.AlwaysUseRootSubscription = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id, MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.AlwaysUseRootSub, false, true, sessionData);


                var ipAddresses = GCS.Framework.Utilities.SystemUtilities.MyIPAddresses().Where(o => o.AddressFamily == AddressFamily.InterNetwork);
                var addr = ipAddresses.FirstOrDefault(o => !o.ToString().StartsWith("192.168"));
                if (addr == null)
                    addr = ipAddresses.FirstOrDefault();

                IdProducerSettings.WebClientUrl = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.WebClientUrl, $"http://{addr}/idProducerClient", true, sessionData);


                IdProducerSettings.FailIfPrintDispatcherStopped = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.FailIfPrintDispatcherStopped, false, true, sessionData);

                TwoFactorAuthenticationSettings.TokenLifespan = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.TwoFactorAuth, MagicStringsSettingsTwoFactorAuthKey.TokenLifespan, 10, true, sessionData);

                if (TwoFactorAuthenticationSettings.TokenLifespan < 1)
                    TwoFactorAuthenticationSettings.TokenLifespan = 10;

                TwoFactorAuthenticationSettings.AuthTokenEmailSubject = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.TwoFactorAuth, MagicStringsSettingsTwoFactorAuthKey.EmailSubject, "StarDust Two Factor One-Time Use Access Token", true, sessionData);

                TwoFactorAuthenticationSettings.AuthTokenEmailTemplate = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.TwoFactorAuth, MagicStringsSettingsTwoFactorAuthKey.EmailTemplate, "TwoFactorAuthEmailTemplate.html", true, sessionData);

                TwoFactorAuthenticationSettings.AuthTokenSmsTemplate = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.TwoFactorAuth, MagicStringsSettingsTwoFactorAuthKey.SmsTemplate, "TwoFactorAuthSMSTemplate.txt", true, sessionData);

                PasswordResetSettings.TokenLifespan = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.PasswordReset, MagicStringsSettingsPasswordResetKey.TokenLifespan, 240, true, sessionData);

                if (PasswordResetSettings.TokenLifespan < 1)
                    PasswordResetSettings.TokenLifespan = 10;

                PasswordResetSettings.TokenEmailSubject = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.PasswordReset, MagicStringsSettingsPasswordResetKey.EmailSubject, "StarDust Password Reset One-Time Use Token", true, sessionData);

                PasswordResetSettings.TokenEmailTemplate = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.PasswordReset, MagicStringsSettingsPasswordResetKey.EmailTemplate, "PasswordResetEmailTemplate.html", true, sessionData);

                PasswordResetSettings.TokenSmsTemplate = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.PasswordReset, MagicStringsSettingsPasswordResetKey.SmsTemplate, "PasswordResetSMSTemplate.txt", true, sessionData);



                _cdnUploadUrl = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Cdn,
                    MagicStringsSettingsCdn.GalaxySmsCdnUrl, _cdnUploadUrl, true,
                    sessionData);

                TokenSettings.Key = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Jwt,
                    MagicStringsSettingsJwt.Key, "@Ptk@8L]8rvcS?Q`6NuQW<9O:X9>MMjKz>Z:d/{+)p7&5Bk!![`D]07Yi{Vo", true,
                    sessionData);

                TokenSettings.Issuer = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Jwt,
                    MagicStringsSettingsJwt.Issuer, "https://localhost:5001", true,
                    sessionData);

                TokenSettings.Audience = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Jwt,
                    MagicStringsSettingsJwt.Audience, "https://localhost:5001", true,
                    sessionData);


                RedisCacheEnabled = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.RedisCache,
                    MagicStringsSettingsRedisCache.Enabled, true, true,
                    sessionData);

                // Setup connection to Redis cache server
                _RedisHost = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.RedisCache,
                    MagicStringsSettingsRedisCache.Host, "localhost", true,
                    sessionData);
                _RedisPort = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.RedisCache,
                    MagicStringsSettingsRedisCache.Port, 6379, true,
                    sessionData);
                //var redisPassword = settingsRepo.GetByUniqueKey(
                //    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                //    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.RedisCache,
                //    MagicStringsSettingsRedisCache.Password, string.Empty, true,
                //    sessionData);

                //_redis = ConnectionMultiplexer.Connect($"{redisHost}:{redisPort}");

                HangfireEnabled = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Hangfire,
                    MagicStringsSettingsHangfire.Enabled, false, true,
                    sessionData);

                if (HangfireEnabled && _hangfireServer == null)
                {
                    // Setup Hangfire
                    GlobalConfiguration.Configuration
                        .UseSqlServerStorage("GalaxySMS-Hangfire");
                    //GlobalConfiguration.Configuration
                    //    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    //    .UseSimpleAssemblyNameTypeSerializer()
                    //    .UseRecommendedSerializerSettings()
                    //    .UseSqlServerStorage("GalaxySMS-Hangfire", new SqlServerStorageOptions
                    //    {
                    //        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    //        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    //        QueuePollInterval = TimeSpan.Zero,
                    //        UseRecommendedIsolationLevel = true
                    //    })
                    //    .UseBatches()
                    //    .UsePerformanceCounters();
                    // Create background server 
                    // Optionally create new BackgroundJobServerOptions()
                    //                {
                    //
                    //                }
                    _hangfireServer = new BackgroundJobServer();
                }

                ApproximateDuration = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.ApiServer,
                    MagicStringsSettingsApiServer.ApproximateDuration, 5, true, sessionData);

                CommandTimeoutSeconds = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.ApiServer,
                    MagicStringsSettingsApiServer.CommandTimeoutSeconds, 5, true, sessionData);

                LoadDataTimeoutSeconds = settingsRepo.GetByUniqueKey(
                    GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.ApiServer,
                    MagicStringsSettingsApiServer.LoadDataTimeoutSeconds, 15, true, sessionData);
                //public int CommandTimeoutSeconds { get; internal set; }
                //public int LoadDataTimeoutSeconds { get; internal set; }

            }
        }

        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals();
                }
                return _instance;
            }
        }
        public IMapper Mapper { get; internal set; }
        public Dictionary<Guid, UserSessionToken> CurrentUserSessions { get; }
        public Dictionary<Guid, UserSignInResult> CurrentTwoFactorPendingUserSessions { get; }
        public TimeSpan UserSessionTimeout { get; internal set; }
        public int UploadedFilesStaleDays { get; internal set; }
        public long MaxUploadFileSize { get; internal set; }
        public UserSessionToken GetUserBySessionId(Guid sessionId)
        {
            try
            {
                if (sessionId == Guid.Empty)
                    return null;
                var t = (from cus in CurrentUserSessions
                         where cus.Key == sessionId
                         select cus).FirstOrDefault();
                if (t.Value == null)
                {
                    var tr = GetTwoFactorUserBySessionId(sessionId);
                    if (tr != null)
                        return tr.SessionToken;
                }
                if (t.Key == Guid.Empty)
                    throw new UnauthorizedAccessException();
                if (t.Value.SessionId != Guid.Empty)    // Already Signed out
                    t.Value.KeepAlive();
                return t.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public UserSignInResult GetTwoFactorUserBySessionId(Guid sessionId)
        {
            try
            {
                if (sessionId == Guid.Empty)
                    return null;
                var t = (from cus in CurrentTwoFactorPendingUserSessions
                         where cus.Key == sessionId
                         select cus).FirstOrDefault();
                if (t.Key == Guid.Empty)
                    throw new UnauthorizedAccessException();

                t.Value.SessionToken.KeepAlive();
                return t.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PDSAMessageBroker MessageBroker { get; internal set; }
        public IdProducerSettings IdProducerSettings { get; internal set; } = new IdProducerSettings();
        public TwoFactorAuthenticationSettings TwoFactorAuthenticationSettings { get; internal set; } = new TwoFactorAuthenticationSettings();
        public JwtTokenSettings TokenSettings { get; internal set; } = new JwtTokenSettings();
        public PasswordResetSettings PasswordResetSettings { get; internal set; } = new PasswordResetSettings();

        public string TemplateFolder
        {
            get;
            internal set;
        } = $"{GCS.Core.Common.Utils.SystemUtilities.MyFolderLocation}\\Templates\\";

        //private IConnectionMultiplexer _redis;
        //private IDatabase _redisDb => _redis?.GetDatabase();
        public bool RedisCacheEnabled { get; internal set; }
        public bool HangfireEnabled { get; internal set; }
        public string RedisConnectionString => $"{_RedisHost}:{_RedisPort}";

        public int ApproximateDuration { get; internal set; }
        public int CommandTimeoutSeconds { get; internal set; }
        public int LoadDataTimeoutSeconds { get; internal set; }



        //public T GetCachedItem<T>(string key)
        //{
        //    if (RedisCacheEnabled && Instance._redisDb != null)
        //    {
        //        var s = Globals.Instance._redisDb.StringGet(key);
        //        if (!string.IsNullOrEmpty(s))
        //        {
        //            var returnItem = JsonConvert.DeserializeObject<T>(s);
        //            return returnItem;
        //        }
        //    }

        //    return default;
        //}

        //public async Task<T> GetCachedItemAsync<T>(string key)
        //{
        //    if (RedisCacheEnabled && Instance._redisDb != null)
        //    {
        //        var s = await Globals.Instance._redisDb.StringGetAsync(key);
        //        if (!string.IsNullOrEmpty(s))
        //        {
        //            var returnItem = JsonConvert.DeserializeObject<T>(s);
        //            return returnItem;
        //        }
        //    }

        //    return default;
        //}

        //public bool SetCachedItem<T>(string key, T item)
        //{
        //    if (RedisCacheEnabled && Instance._redisDb != null)
        //    {
        //        var s = JsonConvert.SerializeObject(item);
        //        var bRet = Globals.Instance._redisDb.StringSet(key, s);
        //        return bRet;
        //    }

        //    return false;
        //}

        //public async Task<bool> SetCachedItemAsync<T>(string key, T item)
        //{
        //    if (RedisCacheEnabled && Instance._redisDb != null)
        //    {
        //        var s = JsonConvert.SerializeObject(item);
        //        var bRet = await Globals.Instance._redisDb.StringSetAsync(key, s);
        //        return bRet;
        //    }

        //    return false;
        //}



        public gcsSystem SystemData
        {
            get => _systemData;
            set => _systemData = value;
        }
        public void SendToProcessingQueue(object o)
        {
            if (o != null)
                _processingQueue.Add(o);
        }

        public void CleanupExpiredSessions()
        {
            var expiredKeys = new List<Guid>();
            foreach (var token in CurrentUserSessions)
            {
                if (token.Value.IsSessionExpired == true)
                {
                    expiredKeys.Add(token.Key);
                }
            }

            foreach (var key in expiredKeys)
            {
                CurrentUserSessions.Remove(key);
            }
        }

        public void CleanUpExpiredTwoFactorSessions()
        {
            var expiredKeys = new List<Guid>();
            foreach (var token in CurrentTwoFactorPendingUserSessions)
            {
                if (token.Value.SessionToken.CreatedDateTime + TimeSpan.FromMinutes(this.TwoFactorAuthenticationSettings.TokenLifespan) < DateTimeOffset.Now)
                {
                    expiredKeys.Add(token.Key);
                }
            }

            foreach (var key in expiredKeys)
            {
                CurrentTwoFactorPendingUserSessions.Remove(key);
            }

        }
        public void UpdateIdProducerLoginSettings(string username, string password, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            IdProducerSettings.UserName = username;
            IdProducerSettings.Password = password;
            //GCS.Core.Common.Config.ConfigurationUtilities.SaveAppSetting(string.Empty, string.Empty, "IdProducerUserName", username);
            //GCS.Core.Common.Config.ConfigurationUtilities.SaveAppSetting(string.Empty, string.Empty, "IdProducerPassword", password);

            var settingsRepo = StaticObjects.Container.GetExportedValue<IGcsSettingRepository>();

            var settingUserName = settingsRepo.Save(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.UserName, IdProducerSettings.UserName, sessionData, saveParams);

            var settingPassword = settingsRepo.Save(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.IdProducer, MagicStringsSettingsIdProducerKey.Password, IdProducerSettings.Password, sessionData, saveParams);

        }

        public async Task<string> PushBlobToCdn(PushBlobToCdnParameters parameters, string jwt)
        {
            this.Log().Info($"Pushing blob to Cdn: OwnerType: {parameters.TypeOfOwner}, OwnerUid: {parameters.OwnerUid}, Filename: {parameters.Filename}, DataLength: {parameters.Data.Length}");
            try
            {
                //switch (_cdnConnectionInfo.StorageType)
                //{
                //    case CdnConnectionInfo.CdnType.FileSystem:
                //        return PushBlobToFileSystem(parameters);
                //}


                //var json = JsonConvert.SerializeObject(parameters);
                //var data = new StringContent(json, Encoding.UTF8, "application/json");

                //var client = new HttpClient();

                //var response = await client.PostAsync(Globals.Instance._cdnUploadUrl, data);

                //string result = response.Content.ReadAsStringAsync().Result;

                //client.Dispose();
                //return result;
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.BaseAddress = Globals.Instance._cdnUploadUrl;
                        var url = "/api/upload";
                        webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                        webClient.Headers[HttpRequestHeader.Authorization] = $"bearer {jwt}";
                        string data = JsonConvert.SerializeObject(parameters);
                        var response = webClient.UploadString(url, data);
                        return response;
                        //var result = JsonConvert.DeserializeObject<string>(response);
                        //return result;
                        //System.Console.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return string.Empty;

            }
            catch (Exception e)
            {
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
                //throw e;
            }

            return string.Empty;
        }

        public async Task<int> DeleteBlobFromCdn(DeleteBlobFromCdnParameters parameters, string jwt)
        {
            this.Log().Info($"Deleting blob from Cdn: OwnerType: {parameters.TypeOfOwner}, OwnerUid: {parameters.OwnerUid}, Filename: {parameters.Filename}");
            try
            {
                //switch (_cdnConnectionInfo.StorageType)
                //{
                //    case CdnConnectionInfo.CdnType.FileSystem:
                //        return PushBlobToFileSystem(parameters);
                //}


                //var json = JsonConvert.SerializeObject(parameters);
                //var data = new StringContent(json, Encoding.UTF8, "application/json");

                //var client = new HttpClient();

                //var response = await client.PostAsync(Globals.Instance._cdnUploadUrl, data);

                //string result = response.Content.ReadAsStringAsync().Result;

                //client.Dispose();
                //return result;
                try
                {
                    int numberDeleted = 0;
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.BaseAddress = Globals.Instance._cdnUploadUrl;
                        var url = "/api/upload";
                        webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                        webClient.Headers[HttpRequestHeader.Authorization] = $"bearer {jwt}";
                        string data = JsonConvert.SerializeObject(parameters);
                        var uploadBytes = Encoding.UTF8.GetBytes(data);
                        var responseBytes = webClient.UploadData(url, "DELETE", uploadBytes);
                        string response = Encoding.UTF8.GetString(responseBytes);
                        if (!string.IsNullOrEmpty(response))
                        {
                            int.TryParse(response, out numberDeleted);
                        }
                        return numberDeleted;
                        //var result = JsonConvert.DeserializeObject<string>(response);
                        //return result;
                        //System.Console.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception e)
            {
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
            }

            return 0;
        }

        //public bool DoesUserHaveEntityApplication(Guid userId, Guid entityId, Guid applicationId)
        //{
        //    try
        //    {
        //        return _gcsUserRepository.DoesUserHaveEntityApplication(userId, entityId, applicationId);
        //    }
        //    catch (Exception e)
        //    {
        //        this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
        //    }

        //    return false;
        //}

        public bool DoesEntityExist(Guid entityId)
        {
            try
            {
                return _gcsEntityRepository.DoesExist(entityId);
            }
            catch (Exception e)
            {
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
            }

            return false;
        }

        public bool DoesUserHaveEntity(Guid userId, Guid entityId)
        {
            try
            {
                return _gcsUserRepository.DoesUserHaveEntity(userId, entityId);
            }
            catch (Exception e)
            {
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
            }

            return false;
        }

        public bool DoesUserHavePermission(Guid userId, Guid entityId, Guid permissionId)
        {
            try
            {
                return _gcsUserRepository.DoesUserHavePermission(userId, entityId, permissionId);
            }
            catch (Exception e)
            {
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
            }

            return false;
        }


        public bool DoesUserHaveAdminRole(Guid userId, Guid entityId)
        {
            try
            {
                return _gcsUserRepository.DoesUserHaveAdminRole(userId, entityId);
            }
            catch (Exception e)
            {
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
            }

            return false;
        }
        //private string PushBlobToFileSystem(PushBlobToCdnParameters parameters)
        //{
        //    try
        //    {
        //        if (_cdnConnectionInfo.StorageType != CdnConnectionInfo.CdnType.FileSystem)
        //            return string.Empty;

        //        var fullFolder = $"{_cdnConnectionInfo.FileSystemPath}\\{parameters.DataType.ToString().ToLower()}\\{parameters.TypeOfOwner.ToString().ToLower()}\\{parameters.OwnerUid}";
        //        var publicUrl =
        //            $"{_cdnConnectionInfo.PublicUrl}/{parameters.DataType.ToString().ToLower()}/{parameters.TypeOfOwner.ToString().ToLower()}/{parameters.OwnerUid}/{parameters.Filename}";
        //        if (!System.IO.Directory.Exists(fullFolder))
        //            System.IO.Directory.CreateDirectory(fullFolder);
        //        var fullFileName = $"{fullFolder}\\{parameters.Filename}";
        //        System.IO.File.WriteAllBytes(fullFileName, parameters.Data);
        //        return publicUrl;
        //    }
        //    catch (Exception e)
        //    {
        //        this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.Name}. {e}");
        //    }

        //    return string.Empty;
        //}
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>	Gets the manager for security system. </summary>
        ///// <value>	The security system manager. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public SecuritySystemManager SecuritySystemManager { get; }

        //public string ServerURI { get; internal set; }
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>	Gets the system galaxy sdk license. </summary>
        ///// <value>	The system galaxy sdk license. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public SystemGalaxySDKEntities.License SystemGalaxySDKLicense
        //{
        //    get { return SecuritySystemManager.License; }
        //}

        //public SystemGalaxySDKEntities.UserToken UserToken { get; }

        //public HttpStatusCode UserActionNotPermittedStatusCode
        //{
        //    get { return HttpStatusCode.Unauthorized; }
        //}

        //public string UserActionNotPermittedDescription
        //{
        //    get { return Resources.ResponseMessage_UserActionNotPermittedDescription; }
        //}

        //public HttpStatusCode InvalidUserGuidHTTPStatusCode
        //{
        //    get { return HttpStatusCode.Unauthorized; }
        //}

        //public string InvalidUserGuidHTTPStatusDescription
        //{
        //    get { return Resources.ResponseMessage_InvalidUserGuidHTTPStatusDescription; }
        //}

        //public string DuplicateNameDescription
        //{
        //    get { return Resources.ResponseMessage_DuplicateRecord; }
        //}

        //public string RecordNotFoundDescription
        //{
        //    get { return Resources.ResponseMessage_RecordNotFound; }
        //}

        //public HttpStatusCode InvalidAPILicenseHTTPStatusCode
        //{
        //    get { return HttpStatusCode.Unauthorized; }
        //}

        //public string InvalidAPILicenseHTTPStatusDescription
        //{
        //    get { return "The API License is invalid"; }
        //}

        #region IDisposable Members

        public void Dispose()
        {
            if (_processingQueue != null)
            {
                _processingQueue.CompleteAdding();
                if (_processingQueue.Count > 0)
                {
                    _waitForProcessingQueueToEmptyTimer = new System.Threading.Timer(WaitForProcessingQueueToEmptyTimerCallback, null, 500, 250);
                }
                else
                {
                    if (_panelOutputDataRecorder != null)
                        _panelOutputDataRecorder.StopProcessor();
                }
            }

            //if (_signalRClient != null)
            //{
            //    _signalRClient.Dispose();
            //    _signalRClient = null;
            //}
        }

        #endregion


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Starts panel output data processors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void StartPanelOutputDataProcessors()
        {
            // Create the thread object. This does not start the thread.
            _panelOutputDataRecorder = new PanelOutputDataProcessor();
            _panelOutputDataRecorder.ProcessData(this._processingQueue);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Callback, called when the wait for processing queue to empty timer. </summary>
        ///
        /// <remarks>   Kevin, 1/30/2014. </remarks>
        ///
        /// <param name="state">    The state. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void WaitForProcessingQueueToEmptyTimerCallback(object state)
        {
            if (_processingQueue.Count == 0)
            {
                if (_waitForProcessingQueueToEmptyTimer != null)
                    _waitForProcessingQueueToEmptyTimer.Dispose();
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0}, WaitForProcessingQueueToEmptyTimerCallback called. ProcessingQueue is now empty.", System.Environment.TickCount));
                this.Log().DebugFormat($"{System.Environment.TickCount}, {System.Reflection.MethodBase.GetCurrentMethod()?.Name} called. ProcessingQueue is now empty.");
                if (_panelOutputDataRecorder != null)
                    _panelOutputDataRecorder.StopProcessor();

                _waitForProcessingQueueToEmptyTimer = null;
            }
            else
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0} WaitForProcessingQueueToEmptyTimerCallback called while waiting for processingQueue to empty. Count:{1}", System.Environment.TickCount, _processingQueue.Count));
                this.Log().DebugFormat($"{System.Environment.TickCount} {System.Reflection.MethodBase.GetCurrentMethod()?.Name} called while waiting for processingQueue to empty. Count:{_processingQueue.Count}");
            }
        }

        //private void _ssManager_ControllerInformationEvent(object sender, ControllerInformationEventArgs e)
        //{
        //    Trace.WriteLine(string.Format("_ssManager_ControllerInformationEvent Cluster:{0}, Controller:{1}, CPU:{2}",
        //        e.EventData.LoopClusterID, e.EventData.UnitNumberID, e.EventData.CpuNumber));

        //    var dictionary =
        //        GetClusterPanelDataDictionary(e.EventData.LoopClusterID);
        //    if (dictionary != null)
        //    {
        //        SystemGalaxySDKEntities.ControllerStatusData controllerData = null;
        //        var key = string.Format("{0}:{1}:{2}", e.EventData.LoopClusterID, e.EventData.UnitNumberID,
        //            e.EventData.CpuNumber);
        //        if (dictionary.TryGetValue(key, out controllerData) == false)
        //        {
        //        }
        //        if (controllerData == null)
        //            controllerData = new SystemGalaxySDKEntities.ControllerStatusData();
        //        if (controllerData.ControllerInfo == null)
        //            controllerData.ControllerInfo = new SystemGalaxySDKEntities.ControlUnitInformation();

        //        controllerData.ControllerInfo.ActivityLoggingEnabled =
        //            (SystemGalaxySDKEntities.ActivityLoggingEnabledState)
        //                Enum.Parse(typeof(SystemGalaxySDKEntities.ActivityLoggingEnabledState),
        //                    e.EventData.ActivityLoggingEnabled.ToString());
        //        controllerData.ControllerInfo.CardCodeFormat =
        //            (SystemGalaxySDKEntities.CardCodeSize)
        //                Enum.Parse(typeof(SystemGalaxySDKEntities.CardCodeSize), e.EventData.CardCodeFormat.ToString());
        //        controllerData.ControllerInfo.CrisisModeActive =
        //            (SystemGalaxySDKEntities.CrisisModeState)
        //                Enum.Parse(typeof(SystemGalaxySDKEntities.CrisisModeState),
        //                    e.EventData.CrisisModeActive.ToString());
        //        switch (controllerData.ControllerInfo.CrisisModeActive)
        //        {
        //            case SystemGalaxySDKEntities.CrisisModeState.Active:
        //                controllerData.ControllerInfo.CrisisModeStateDescription = Resources.ControllerCrisisMode_Active;
        //                break;

        //            case SystemGalaxySDKEntities.CrisisModeState.Inactive:
        //                controllerData.ControllerInfo.CrisisModeStateDescription =
        //                    Resources.ControllerCrisisMode_Inactive;
        //                break;

        //            case SystemGalaxySDKEntities.CrisisModeState.Unknown:
        //                controllerData.ControllerInfo.CrisisModeStateDescription =
        //                    Resources.ControllerCrisisMode_Unknown;
        //                break;
        //        }
        //        controllerData.ControllerInfo.LastRestartColdOrWarm =
        //            (SystemGalaxySDKEntities.CpuResetType)
        //                Enum.Parse(typeof(SystemGalaxySDKEntities.CpuResetType),
        //                    e.EventData.LastRestartColdOrWarm.ToString());
        //        controllerData.ControllerInfo.ModelNumber =
        //            (SystemGalaxySDKEntities.CpuModel)
        //                Enum.Parse(typeof(SystemGalaxySDKEntities.CpuModel), e.EventData.ModelNumber.ToString());
        //        controllerData.ControllerInfo.OptionSwitches = e.EventData.OptionSwitches;
        //        controllerData.ControllerInfo.ResponseTime = e.EventData.CreatedDate;
        //        controllerData.ControllerInfo.SerialNumber = e.EventData.SerialNumber;
        //        controllerData.ControllerInfo.UnacknowledgedActivityLogCount =
        //            e.EventData.UnacknowledgedActivityLogCount;
        //        if (controllerData.ControllerInfo.Version == null)
        //            controllerData.ControllerInfo.Version = new SystemGalaxySDKEntities.FirmwareVersion();
        //        controllerData.ControllerInfo.Version.Major = e.EventData.Version.Major;
        //        controllerData.ControllerInfo.Version.Minor = e.EventData.Version.Minor;
        //        controllerData.ControllerInfo.Version.LetterCode = e.EventData.Version.LetterCode;
        //        controllerData.ControllerInfo.ZLinkConnected = e.EventData.ZLinkConnected;
        //        dictionary[key] = controllerData;

        //        if (_signalRClient != null)
        //        {
        //            var webapiControllerData = Mapper.Map<WebApiEntities.ControllerStatusData>(controllerData);

        //            _signalRClient.SendControllerStatusDataAsync(webapiControllerData);
        //        }
        //    }
        //}

        //private void _ssManager_ControllerPingReplyEvent(object sender, ControllerPingReplyEventArgs e)
        //{
        //    var dictionary =
        //        GetClusterPanelDataDictionary(e.EventData.LoopClusterID);
        //    if (dictionary != null)
        //    {
        //        SystemGalaxySDKEntities.ControllerStatusData controllerData = null;
        //        var key = string.Format("{0}:{1}:{2}", e.EventData.LoopClusterID, e.EventData.UnitNumberID,
        //            e.EventData.CpuNumber);
        //        if (dictionary.TryGetValue(key, out controllerData))
        //        {
        //        }

        //        if (controllerData == null)
        //            controllerData = new SystemGalaxySDKEntities.ControllerStatusData();
        //        if (controllerData.PingReply == null)
        //            controllerData.PingReply = new SystemGalaxySDKEntities.ControllerPingReply();
        //        controllerData.PingReply.AckNackType =
        //            (SystemGalaxySDKEntities.ControllerReplyBase.AckNack)
        //                Enum.Parse(typeof(SystemGalaxySDKEntities.ControllerReplyBase.AckNack),
        //                    e.EventData.AckNackType.ToString());
        //        controllerData.PingReply.ResponseTime = e.EventData.CreatedDate;
        //        dictionary[key] = controllerData;

        //        if (_signalRClient != null)
        //        {
        //            var webapiControllerData = Mapper.Map<WebApiEntities.ControllerStatusData>(controllerData);

        //            _signalRClient.SendControllerStatusDataAsync(webapiControllerData);
        //        }
        //    }
        //}

        //private void _ssManager_ControllerCardCountEvent(object sender, ControllerCardCountEventArgs e)
        //{
        //    var dictionary =
        //        GetClusterPanelDataDictionary(e.EventData.LoopClusterID);
        //    if (dictionary != null)
        //    {
        //        SystemGalaxySDKEntities.ControllerStatusData controllerData = null;
        //        var key = string.Format("{0}:{1}:{2}", e.EventData.LoopClusterID, e.EventData.UnitNumberID,
        //            e.EventData.CpuNumber);
        //        if (dictionary.TryGetValue(key, out controllerData))
        //        {
        //        }
        //        if (controllerData == null)
        //            controllerData = new SystemGalaxySDKEntities.ControllerStatusData();
        //        if (controllerData.CardCount == null)
        //            controllerData.CardCount = new SystemGalaxySDKEntities.ControllerCardCount();
        //        controllerData.CardCount.CardCount = e.EventData.CardCount;
        //        controllerData.CardCount.ResponseTime = e.EventData.CreatedDate;
        //        dictionary[key] = controllerData;

        //        if (_signalRClient != null)
        //        {
        //            var webapiControllerData = Mapper.Map<WebApiEntities.ControllerStatusData>(controllerData);

        //            _signalRClient.SendControllerStatusDataAsync(webapiControllerData);
        //        }
        //    }
        //}

        //private void _ssManager_ControllerLoggingStatusInformationEvent(object sender,
        //    ControllerLoggingStatusInformationEventArgs e)
        //{
        //    var dictionary =
        //        GetClusterPanelDataDictionary(e.EventData.LoopClusterID);
        //    if (dictionary != null)
        //    {
        //        SystemGalaxySDKEntities.ControllerStatusData controllerData = null;
        //        var key = string.Format("{0}:{1}:{2}", e.EventData.LoopClusterID, e.EventData.UnitNumberID,
        //            e.EventData.CpuNumber);
        //        if (dictionary.TryGetValue(key, out controllerData))
        //        {
        //        }
        //        if (controllerData == null)
        //            controllerData = new SystemGalaxySDKEntities.ControllerStatusData();
        //        if (controllerData.LoggingInfo == null)
        //            controllerData.LoggingInfo = new SystemGalaxySDKEntities.ControlUnitLoggingStatusInformation();
        //        controllerData.LoggingInfo.ActivityLoggingEnabled =
        //            (SystemGalaxySDKEntities.ActivityLoggingEnabledState)
        //                Enum.Parse(typeof(SystemGalaxySDKEntities.ActivityLoggingEnabledState),
        //                    e.EventData.ActivityLoggingEnabled.ToString());
        //        controllerData.LoggingInfo.BufferedActivityLogCount = e.EventData.BufferedActivityLogCount;
        //        controllerData.LoggingInfo.UnacknowledgedActivityLogCount =
        //            e.EventData.UnacknowledgedActivityLogCount;
        //        controllerData.LoggingInfo.ResponseTime = e.EventData.CreatedDate;

        //        dictionary[key] = controllerData;

        //        if (_signalRClient != null)
        //        {
        //            var webapiControllerData = Mapper.Map<WebApiEntities.ControllerStatusData>(controllerData);

        //            _signalRClient.SendControllerStatusDataAsync(webapiControllerData);
        //        }
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>	Log on. </summary>
        ///// <remarks>	Kevin, 1/22/2013. </remarks>
        ///// <exception cref="Exception">	Thrown when an exception error condition occurs. </exception>
        ///// <param name="credential">	The credential. </param>
        ///// <returns>	. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public SystemGalaxySDKEntities.UserToken LogOn(SystemGalaxySDKEntities.UserLogOnCredential credential)
        //{
        //    try
        //    {
        //        var token = SecuritySystemManager.LogOn(credential);
        //        return token;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>	Log off. </summary>
        ///// <remarks>	Kevin, 1/22/2013. </remarks>
        ///// <exception cref="Exception">	Thrown when an exception error condition occurs. </exception>
        ///// <param name="token">	The token. </param>
        ///// <returns>	true if it succeeds, false if it fails. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public bool LogOff(SystemGalaxySDKEntities.UserToken token)
        //{
        //    try
        //    {
        //        return SecuritySystemManager.LogOff(token);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public SystemGalaxySDKEntities.UserToken GetUserTokenByTokenGuid(Guid userGuid,
        //    bool bReturnGlobalTokenIfNotFound)
        //{
        //    try
        //    {
        //        if (userGuid == Guid.Empty)
        //            return Instance.UserToken;
        //        var token = SecuritySystemManager.GetUserToken(userGuid.ToString());
        //        if (token == null && bReturnGlobalTokenIfNotFound)
        //            return Instance.UserToken;
        //        return token;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool ConnectToClientGateway(Guid tokenGuid)
        //{
        //    return SecuritySystemManager.ConnectToClientGatewayService(GetUserTokenByTokenGuid(tokenGuid, true), null);
        //}

        //public SystemGalaxySDKEntities.DoorReaderStatus GetDoorStatus(uint doorId)
        //{
        //    SystemGalaxySDKEntities.DoorReaderStatus returnStatus = null;
        //    try
        //    {
        //        if (_doorStatusDictionary != null)
        //        {
        //            if (_doorStatusDictionary.TryGetValue(doorId, out returnStatus))
        //            {
        //                Trace.WriteLine(
        //                    string.Format(
        //                        "{0}, TickCount: {1} GCS.WebServices.ApplicationData GetDoorStatus DoorId: {2}, Relays: {3}",
        //                        DateTimeOffset.Now.ToShortTimeString(), Environment.TickCount, doorId, returnStatus.Relays));
        //            }
        //            else
        //            {
        //                Trace.WriteLine(
        //                    string.Format(
        //                        "{0}, TickCount: {1} GCS.WebServices.ApplicationData GetDoorStatus DoorId: {2} not found",
        //                        DateTimeOffset.Now.ToShortTimeString(), Environment.TickCount, doorId));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(string.Format("GCS.WebServices.ApplicationData GetDoorStatus Exception: {0}",
        //            ex.Message));
        //    }
        //    return returnStatus;
        //}

        //public SystemGalaxySDKEntities.ControllerStatusData GetControllerCpuStatusData(uint clusterId, uint unitNumber,
        //    short cpuNumber)
        //{
        //    SystemGalaxySDKEntities.ControllerStatusData controllerData = null;
        //    var dictionary = GetClusterPanelDataDictionary(clusterId);
        //    if (dictionary != null)
        //    {
        //        var key = string.Format("{0}:{1}:{2}", clusterId, unitNumber, cpuNumber);
        //        if (dictionary.TryGetValue(key, out controllerData) == false)
        //        {
        //            controllerData = new SystemGalaxySDKEntities.ControllerStatusData();
        //        }
        //    }
        //    return controllerData;
        //}

        //public SystemGalaxySDKEntities.ControllerStatusData GetClusterInfo(uint clusterId)
        //{
        //    SystemGalaxySDKEntities.ControllerStatusData returnData = null;
        //    try
        //    {
        //        var dictionary = GetClusterPanelDataDictionary(clusterId);
        //        if (dictionary != null)
        //        {
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(string.Format("GCS.WebServices.ApplicationData GetClusterInfo Exception: {0}",
        //            ex.Message));
        //    }
        //    return returnData;
        //}
    }
}