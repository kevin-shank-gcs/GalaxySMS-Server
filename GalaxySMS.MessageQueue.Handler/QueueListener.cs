using System;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.MessageQueue.Handler.Properties;
//using GalaxySMS.Business.SignalR;
#if NETFRAMEWORK
#if SignalRCore
#else
using GalaxySMS.Business.SignalR;
#endif
#elif NETCOREAPP

#endif
using GalaxySMS.MessageQueue.Integration;
using GalaxySMS.MessageQueue.Integration.Workflows;
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.Utils;
using GCS.Framework.MessageQueue.Messaging;
using GCS.Framework.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SystemUtilities = GCS.Framework.Utilities.SystemUtilities;

namespace GalaxySMS.MessageQueue.Handler
{
    public class QueueListener
    {
        private CancellationTokenSource _cancellationTokenSource;
#if NETFRAMEWORK
#if SignalRCore
        private SignalRCore.SignalRClient _signalRClient;
#else
        private SignalRClient _signalRClient;
#endif
#elif NETCOREAPP

#endif
        private bool _signalRClientConnected = false;
        private string _signalRUrl;
        private string _queueName;
        private string _apiUrl;
        private UserSessionToken _userSessionToken;
        private GalaxySMS.Data.GcsSettingRepository _settingsRepository;
        private IApplicationUserSessionDataHeader _sessionData;
        private Timer _reconnectSignalRTimer;
        private ushort _autoReconnectSeconds = 0;
        private ushort _signalRPort = 0;

        public async void Start(string queueName)
        {
            this.Log().Info($"QueueListener starting...");

            if (string.IsNullOrEmpty(queueName))
            {
                this.Log().Info($"queueName is null or empty, reading from config file");
                queueName = ConfigurationManager.AppSettings["listenOnQueueName"];
                if (string.IsNullOrEmpty(queueName))
                {
                    throw new ArgumentException(
                        "'listenOnQueueName:[queueName]' must be specified as an appSetting or command line argument");
                }
            }
            _queueName = queueName;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateParseHandling = DateParseHandling.DateTimeOffset
            };

            _apiUrl = ConfigurationManager.AppSettings["apiUrl"];
            _settingsRepository = new Data.GcsSettingRepository();
            _sessionData = new ApplicationUserSessionHeader();
            _sessionData.UserName = PrincipalIdentity.CurrentWindowsUserName;

            var serverConnectionSettings = new GalaxySiteServerConnectionSettings();
            serverConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            serverConnectionSettings.ServerName = Settings.Default.ServerAddress;
            serverConnectionSettings.ServerAddress = Settings.Default.ServerAddress;
            serverConnectionSettings.PortNumber = Settings.Default.ServerPort;
            serverConnectionSettings.ApiServerUrl = _apiUrl;
            //serverConnectionSettings.SignalRServerUrl = Settings.Default.SignalRServerUrl;

            var siteServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);

            MyHelpers.ServerConnection = siteServerConnection;
            MyHelpers.MyAssemblyAttributes = SystemUtilities.GetEntryAssemblyAttributes();

            var value = ConfigurationManager.AppSettings["signalRPort"];
            if (value != null)
            {
                if (ushort.TryParse(value.ToString(), out _signalRPort))
                {
                    value = ConfigurationManager.AppSettings["signalRReconnectSeconds"];
                    if (value != null)
                        ushort.TryParse(value.ToString(), out _autoReconnectSeconds);
                }
                else
                    _signalRPort = 0;
            }

            // Hardcode the SignalR port to 0 (disable) if the queue name is recorder
            if (_queueName.ToLower().Contains("recorder"))
                _signalRPort = 0;

#if NETFRAMEWORK
#if SignalRCore
            if (_signalRPort > 0)
            {

                await GetUserTokenFromApi();
                _signalRClient = new SignalRCore.SignalRClient();
                _signalRClient.ConnectionClosedEvent += _signalRClient_ConnectionClosedEvent;
                _signalRUrl = $"http://localhost:{_signalRPort}";
                
                //Thread.Sleep(10 * 1000);

                _signalRClientConnected = await ConnectToSignalR();
            }
            else
                this.Log().InfoFormat("SignalR connectivity is disabled because the signalRPort value is not valid.");
#else
            if (signalRPort > 0)
            {
                _signalRClient = new SignalRClient();
                _signalRClient.ConnectionClosedEvent += _signalRClient_ConnectionClosedEvent;
                _signalRUrl = $"http://localhost:{_signalRPort}/signalr";
                //_signalRUrl = $"http://localhost:{_signalRPort}";
                _signalRClientConnected = await ConnectToSignalR();
            }
            else
                this.Log().InfoFormat("SignalR connectivity is disabled because the signalRPort value is not valid.");
#endif
#elif NETCOREAPP

#endif

            this.Log().InfoFormat("Starting with queueName: {0}", _queueName);

            _cancellationTokenSource = new CancellationTokenSource();
            switch (queueName)
            {
                case QueueNames.PanelMessage:
                    StartListening<PanelMessageReceivedWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;

                case QueueNames.PanelMessageRecorder:
                    StartListening<PanelMessageRecorderWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;

                case QueueNames.PanelMessagePublisher:
                    StartListening<PanelMessageReceivedPublisherWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;

                case QueueNames.PanelMessageRecorderSubscriber:
                    StartListening<PanelMessageRecorderWorkflow>(queueName, MessagePattern.PublishSubscribe);
                    break;

                case QueueNames.PanelMessageDecoderSubscriber:
                    StartListening<PanelMessageDecoderWorkflow>(queueName, MessagePattern.PublishSubscribe);
                    break;
                case QueueNames.PanelMessageDecoder:
                    StartListening<PanelMessageDecoderWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;
                case QueueNames.MercPanelMessage:
                    StartListening<MercPanelMessageReceivedWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;

                case QueueNames.MercPanelMessageRecorder:
                    StartListening<MercPanelMessageRecorderWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;

                case QueueNames.MercPanelMessagePublisher:
                    StartListening<MercPanelMessageReceivedPublisherWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;

                case QueueNames.MercPanelMessageRecorderSubscriber:
                    StartListening<MercPanelMessageRecorderWorkflow>(queueName, MessagePattern.PublishSubscribe);
                    break;

                case QueueNames.MercPanelMessageDecoderSubscriber:
                    StartListening<MercPanelMessageDecoderWorkflow>(queueName, MessagePattern.PublishSubscribe);
                    break;

                case QueueNames.MercPanelMessageDecoder:
                    StartListening<MercPanelMessageDecoderWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;

                case QueueNames.GalaxyJob:
                    StartListening<GalaxyJobWorkflow>(queueName, MessagePattern.FireAndForget);
                    break;
            }
        }

        private void _signalRClient_ConnectionClosedEvent(object sender, SignalRCore.SignalRClient.SignalRConnectionClosedEventArgs e)
        {
            this.Log().Info($"SignalR Connection Closed");
            _signalRClientConnected = false;
            if (_autoReconnectSeconds != 0)
            {
                _reconnectSignalRTimer = new Timer(ReconnectToSignalR, null, _autoReconnectSeconds * 1000, Timeout.Infinite);
            }
        }

        private async void ReconnectToSignalR(object state)
        {
            if (_signalRClientConnected == false)
            {
                this.Log().Info($"Attempting SignalR Reconnection");
                if (_userSessionToken == null || _userSessionToken.IsSessionExpired)
                {
                    await GetUserTokenFromApi();
                }
                _signalRClient = new SignalRCore.SignalRClient();
                _signalRClient.ConnectionClosedEvent += _signalRClient_ConnectionClosedEvent;
                _signalRUrl = $"http://localhost:{_signalRPort}";
                _signalRClientConnected = await ConnectToSignalR();
                if (!_signalRClientConnected)
                {
                    if (_autoReconnectSeconds != 0)
                    {
                        _reconnectSignalRTimer = new Timer(ReconnectToSignalR, null, _autoReconnectSeconds * 1000, Timeout.Infinite);
                    }
                }
            }
        }

#if NETFRAMEWORK
#if SignalRCore
#else
        private void _signalRClient_ConnectionClosedEvent(object sender, SignalRClient.SignalRConnectionClosedEventArgs e)
        {
            _signalRClientConnected = false;
        }
#endif
#elif NETCOREAPP

#endif


        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async Task<bool> ConnectToSignalR()
        {
            var bResult = false;
            this.Log().Info($"ConnectToSignalR URL: {_signalRUrl}");

            if (!string.IsNullOrEmpty(_signalRUrl))
            {
                var now = DateTimeOffset.Now;
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var logFolder = $"{localAppData}\\{ConfigurationManager.AppSettings["signalRLogFolder"]}";
                var logFilename = ConfigurationManager.AppSettings["signalRLogFilename"];
                try
                {

                    if (!System.IO.Directory.Exists(logFolder))
                        System.IO.Directory.CreateDirectory(logFolder);
                    if (System.IO.Directory.Exists(logFolder))
                    {
#if NETFRAMEWORK
                        if (!string.IsNullOrEmpty(_userSessionToken?.JwtToken))
                            _signalRClient.Jwt = _userSessionToken.JwtToken;
                        bResult = await _signalRClient.ConnectAsync(_signalRUrl, Guid.Empty, $"{logFolder}\\{logFilename}", true);
                        // Do not join any groups because this program only sends notifications
                        //if (bResult && _userSessionToken != null && _userSessionToken.SessionId != Guid.Empty)
                        //{
                        //    await _signalRClient.JoinGroup(_userSessionToken.SessionId.ToString());
                        //    foreach (var ue in _userSessionToken.UserData.UserEntities)
                        //        await _signalRClient.JoinGroup(ue.EntityId.ToString());
                        //}
#elif NETCOREAPP

#endif
                    }
                }
                catch (Exception ex)
                {
                    this.Log().Error($"ConnectToSignalR exception:{ex}");
                }

                this.Log().Info($"ConnectToSignalR SignalRClient.ConnectAsync returned: {bResult}");
                return bResult;
            }
            return false;
        }

        private async Task GetUserTokenFromApi()
        {
            try
            {
                var userName = _settingsRepository.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Api, MagicStringsSettingsApiKey.UserName, "administrator", true, _sessionData);

                var password = _settingsRepository.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    MagicStringsSettingsGroup.SettingsGroup, MagicStringsSettingsSubGroup.Api, MagicStringsSettingsApiKey.Password, "P@$$word", true, _sessionData);

                var encryptedUser = GCS.Framework.Security.Crypto.EncryptString(userName,
                    $"{MagicStringsSettingsSubGroup.Api}{MagicStringsSettingsApiKey.UserName}");
                var encryptedPassword = GCS.Framework.Security.Crypto.EncryptString(password,
                    $"{MagicStringsSettingsSubGroup.Api}{MagicStringsSettingsApiKey.Password}");

                using (var client = new HttpClient())
                {
                    var args = new
                    {
                        ApplicationId = "00000000-0000-0000-0000-000000000000",
                        AuthenticationType = 2,
                        IncludeEntityPhotos = false,
                        EntityPhotosPixelWidth = 200,
                        IncludeUserPhotos = false,
                        SignInBy = 0,
                        UserName = userName,
                        Password = password,
                    };

                    string json = JsonConvert.SerializeObject(args);

                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"{_apiUrl}/api/auth/signinrequest", httpContent);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var signinResult = JsonConvert.DeserializeObject<UserSignInResult>(responseContent);
                    if (signinResult.RequestResult == UserSignInRequestResult.Success ||
                        signinResult.RequestResult == UserSignInRequestResult.SuccessWithInfo)
                    {
                        _userSessionToken = signinResult.SessionToken;
                    }
                    else
                    {
                        _userSessionToken = null;
                    }

                }

            }

            catch (Exception ex)
            {
                this.Log().Error($"GetUserTokenFromApi exception:{ex}");
            }

        }

        private void StartListening<TWorkflow>(string name, MessagePattern pattern)
                   where TWorkflow : IPanelMessageWorkflow, new()
        {
            try
            {
                var workflowName = typeof(TWorkflow).Name;
                var queue = MessageQueueFactory.CreateInbound(name, pattern);
                this.Log().InfoFormat("Listening with queue type: {0}, on address: {1}", queue.GetType().Name, queue.Address);
                queue.Listen(x =>
                {
                    TWorkflow workflow = default(TWorkflow);
                    object data = null;

                    if (x.BodyType == typeof(PanelActivityLogMessage))
                    {
                        data = x.BodyAs<PanelActivityLogMessage>();
                    }
                    else if (x.BodyType == typeof(PanelCredentialActivityLogMessage))
                    {
                        data = x.BodyAs<PanelCredentialActivityLogMessage>();
                    }
                    else if (x.BodyType == typeof(AccessPortalStatusReply))
                    {
                        data = x.BodyAs<AccessPortalStatusReply>();
                    }
                    else if (x.BodyType == typeof(InputDeviceStatusReply))
                    {
                        data = x.BodyAs<InputDeviceStatusReply>();
                    }
                    else if (x.BodyType == typeof(PingReply))
                    {
                        data = x.BodyAs<PingReply>();
                    }
                    else if (x.BodyType == typeof(PanelInqueryReply))
                    {
                        data = x.BodyAs<PanelInqueryReply>();
                    }
                    else if (x.BodyType == typeof(LoggingStatusReply))
                    {
                        data = x.BodyAs<LoggingStatusReply>();
                    }
                    else if (x.BodyType == typeof(CredentialCountReply))
                    {
                        data = x.BodyAs<CredentialCountReply>();
                    }
                    else if (x.BodyType == typeof(InputOutputGroupCommandReply))
                    {
                        data = x.BodyAs<InputOutputGroupCommandReply>();
                    }
                    else if (x.BodyType == typeof(AccessPortalCommandReply))
                    {
                        data = x.BodyAs<AccessPortalCommandReply>();
                    }
                    else if (x.BodyType == typeof(InputDeviceCommandReply))
                    {
                        data = x.BodyAs<InputDeviceCommandReply>();
                    }
                    else if (x.BodyType == typeof(OutputDeviceCommandReply))
                    {
                        data = x.BodyAs<OutputDeviceCommandReply>();
                    }
                    else if (x.BodyType == typeof(ElevatorOutputDeviceCommandReply))
                    {
                        data = x.BodyAs<ElevatorOutputDeviceCommandReply>();
                    }
                    else if (x.BodyType == typeof(CardChangeAreaEvent))
                    {
                        data = x.BodyAs<CardChangeAreaEvent>();
                    }
                    else if (x.BodyType == typeof(CpuResetReply))
                    {
                        data = x.BodyAs<CpuResetReply>();
                    }
                    else if (x.BodyType == typeof(PanelMessageBase))
                    {
                        data = x.BodyAs<PanelMessageBase>();
                    }
                    else if (x.BodyType == typeof(PanelBoardInformationCollection))
                    {
                        data = x.BodyAs<PanelBoardInformationCollection>();
                    }
                    else if (x.BodyType == typeof(FlashProgressMessage))
                    {
                        data = x.BodyAs<FlashProgressMessage>();
                    }
                    else if (x.BodyType == typeof(PanelLoadDataReply))
                    {
                        data = x.BodyAs<PanelLoadDataReply>();
                        //if (x.BodyType == typeof(PanelLoadDataReply<AbaSettings>))
                        //    data = x.BodyAs<PanelLoadDataReply<AbaSettings>>();
                    }
                    else if (x.BodyType == typeof(SerialChannelGalaxyDoorModuleDataCollection))
                    {
                        data = x.BodyAs<SerialChannelGalaxyDoorModuleDataCollection>();
                    }
                    else if (x.BodyType == typeof(SerialChannelGalaxyInputModuleDataCollection))
                    {
                        data = x.BodyAs<SerialChannelGalaxyInputModuleDataCollection>();
                    }
                    else if (x.BodyType == typeof(AcknowledgedAlarmBasicData))
                    {
                        data = x.BodyAs<AcknowledgedAlarmBasicData>();
                    }
                    else if (x.BodyType == typeof(InputDeviceVoltagesReply))
                    {
                        data = x.BodyAs<InputDeviceVoltagesReply>();
                    }
                    else if (x.BodyType == typeof(CpuConnectionInfo))
                    {
                        data = x.BodyAs<CpuConnectionInfo>();
                    }
                    else if (x.BodyType == typeof(SaveJobParameters<gcsEntity>))
                    {
                        data = x.BodyAs<SaveJobParameters<gcsEntity>>();
                    }
                    else if (x.BodyType == typeof(SaveJobParameters<CommandParameters<ClusterDataLoadParameters>>))
                    {
                        data = x.BodyAs<SaveJobParameters<CommandParameters<ClusterDataLoadParameters>>>();
                    }
                    else if (x.BodyType == typeof(SignalREnvelope<OperationStatusInfo>))
                    {
                        data = x.BodyAs<SignalREnvelope<OperationStatusInfo>>();
                    }
                    else if (x.BodyType == typeof(GalaxyCpuCommandReply))
                    {
                        data = x.BodyAs<GalaxyCpuCommandReply>();
                    }
                    else if (x.BodyType == typeof(EchoReply))
                    {
                        data = x.BodyAs<EchoReply>();
                    }

                    if (data != null)
                    {
#if NETFRAMEWORK
                        if (_signalRClientConnected == false && !string.IsNullOrEmpty(_signalRUrl))
                        {
                            Task.Run(async () =>
                            {
                                _signalRClientConnected = await ConnectToSignalR();

                            }).Wait();
                        }
#elif NETCOREAPP

#endif

                        workflow = new TWorkflow
                        {
#if NETFRAMEWORK
#if SignalRCore
                            SignalRClient = _signalRClient,
#else
                            SignalRClient = _signalRClient,
#endif
#elif NETCOREAPP

#endif
                            Data = data
                        };
                        workflow.Run();
                    }
                    else
                        this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} {workflowName} Received message type: {x.BodyType}");

                }, _cancellationTokenSource.Token);
            }
            catch (AggregateException ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        //private static void CheckUserExists(DoesUserExistRequest doesUserExistRequest, Message requestMessage,
        //                                    IMessageQueue requestQueue)
        //{
        //    LogManager.GetLogger<object>().InfoFormat("Starting CheckUserExists for: {0}, at: {1}", doesUserExistRequest.EmailAddress,
        //                      DateTimeOffset.Now.TimeOfDay);
        //    var validator = new UserValidator(doesUserExistRequest.EmailAddress);
        //    var responseBody = new DoesUserExistResponse
        //    {
        //        Exists = validator.Exists()
        //    };
        //    var responseQueue = requestQueue.GetReplyQueue(requestMessage);
        //    responseQueue.Send(new Message
        //    {
        //        Body = responseBody
        //    });
        //    LogManager.GetLogger<object>().InfoFormat("Returned: {0} for DoesUserExist, EmailAddress: {1}, to: {2}, at: {3}",
        //                      responseBody.Exists,
        //                      doesUserExistRequest.EmailAddress, responseQueue.Address, DateTimeOffset.Now.TimeOfDay);
        //}

        //private static void ProcessDataWrapper(GalaxyDataWrapper dataMessage)
        //{
        //    var msg = $"ClusterGroupId: {dataMessage.ClusterGroupId}, Cluster #:{dataMessage.ClusterNumber}, Panel #:{dataMessage.PanelNumber}, CPU #:{dataMessage.CpuNumber}";
        //    LogManager.GetLogger<object>().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} ProcesStarting process message for: {msg}");
        //    var workflow = new PanelMessageReceivedWorkflow();
        //    workflow.Data = dataMessage;
        //    workflow.Run();
        //    LogManager.GetLogger<object>().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} ProcessDataWrapper complete for: {msg}");
        //}
    }
}
