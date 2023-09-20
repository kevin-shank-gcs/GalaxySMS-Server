using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using GCS.AssaAbloyDSR.DSRAccessControlService;
using GCS.Core.Common.Logger;

namespace GCS.AssaAbloyDSR
{
    public class DsrAccessControlProxy : DsrProxyBase
    {
        public const string AlwaysOnScheduleId = "ffffffff-ffff-ffff-ffff-ffffffffffff";

        #region Private fields

        private readonly string _addressHeaderNamespace = "http://www.w3.org/2005/08/addressing";
        private string addressSuffix = "/dsr/AccessControl";
        private DsrConnectionParameters _connectionParameters;

        #endregion

        #region Private methods
        //private AccessControlInterfaceClient GetAccessControlProxy(string methodName)
        //{
        //    var newProxy = new AccessControlInterfaceClient();
        //    OperationContractAttribute operationContractAttribute = null;
        //    var properties = typeof(AccessControlInterfaceClient).GetProperties();
        //    var methods = typeof(AccessControlInterfaceClient).GetMethods();
        //    var method = typeof(AccessControlInterface).GetMethod(methodName);

        //    if (method != null)
        //    {
        //        var attributes = method.GetCustomAttributes(typeof(OperationContractAttribute), false);
        //        if (attributes.Length != 0 && attributes[0] is OperationContractAttribute)
        //        {
        //            operationContractAttribute = attributes[0] as OperationContractAttribute;
        //        }
        //    }

        //    var sAction = string.Empty;
        //    if (operationContractAttribute != null)
        //    {
        //        sAction = operationContractAttribute.Action;
        //    }
        //    var attrs = Attribute.GetCustomAttributes(typeof(AccessControlInterfaceClient)); // Reflection.

        //    //Create address headers with XmlObjectSerializer specified
        //    XmlObjectSerializer serializer = new DataContractSerializer(typeof(string));
        //    var actionHdr = AddressHeader.CreateAddressHeader("Action", _addressHeaderNamespace, $"{sAction}",
        //        serializer);
        //    var messageIdHdr = AddressHeader.CreateAddressHeader("MessageID", _addressHeaderNamespace,
        //        $"urn:uuid:{Guid.NewGuid()}", serializer);
        //    var toHdr = AddressHeader.CreateAddressHeader("To", _addressHeaderNamespace,
        //        newProxy.Endpoint.Address.ToString(), serializer);
        //    var replyToHdr = AddressHeader.CreateAddressHeader("ReplyTo", _addressHeaderNamespace,
        //        HttpUtility.HtmlEncode("<Address>http://www.w3.org/2005/08/addressing/anonymous</Address>"), serializer);

        //    //Create new endpoint with addressHeader that contains security header
        //    var endpoint = new EndpointAddress(new Uri(string.Format("{0}", newProxy.Endpoint.Address)), actionHdr,
        //        messageIdHdr, toHdr, replyToHdr);

        //    newProxy.Endpoint.Address = endpoint;
        //    return newProxy;
        //}

        private AccessControlInterfaceClient GetAccessControlProxy(string methodName)
        {
            AccessControlInterfaceClient newProxy;
            if (_connectionParameters == null)
                newProxy = new AccessControlInterfaceClient();
            else
            {
                if (_connectionParameters.UseHttps == false)
                {
                    var binding = new BasicHttpBinding("AccessControlInterfaceServiceSoapBinding");
                    binding.OpenTimeout = new TimeSpan(0,0, 0, 5);

                    var address = new EndpointAddress(
                        $"http://{_connectionParameters.IpAddress}:{_connectionParameters.Port}{addressSuffix}");
                    newProxy = new AccessControlInterfaceClient(binding, address);
                }
                else
                {
                    var messageSecurity =
                        (AsymmetricSecurityBindingElement) SecurityBindingElement.
                        CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);

                    var x509ProtectionParameters = new X509SecurityTokenParameters();
                    x509ProtectionParameters.RequireDerivedKeys = false;
                    x509ProtectionParameters.X509ReferenceStyle = X509KeyIdentifierClauseType.Any;
                    x509ProtectionParameters.ReferenceStyle = SecurityTokenReferenceStyle.Internal;
                    x509ProtectionParameters.InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient;
                    messageSecurity.InitiatorTokenParameters = x509ProtectionParameters;
                    messageSecurity.RecipientTokenParameters = x509ProtectionParameters;
                    messageSecurity.IncludeTimestamp = false;
                    messageSecurity.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15;
                    messageSecurity.RequireSignatureConfirmation = false;
                    messageSecurity.EndpointSupportingTokenParameters.Signed.Add(x509ProtectionParameters);
                    messageSecurity.LocalClientSettings.DetectReplays = false;
                    CustomBinding binding = new CustomBinding(messageSecurity, new HttpTransportBindingElement());
                    binding.SendTimeout = new TimeSpan(0, 1, 0);
                    binding.ReceiveTimeout = new TimeSpan(0, 1, 0);
                    binding.CloseTimeout = new TimeSpan(0, 1, 0);
                    binding.OpenTimeout = new TimeSpan(0, 1, 0);
                    var address = new EndpointAddress(
                        $"https://{_connectionParameters.IpAddress}:{_connectionParameters.Port}{addressSuffix}");
                    newProxy = new AccessControlInterfaceClient(binding, address);
                    if (newProxy.ClientCredentials != null)
                    {
                        newProxy.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "clientuser");
                        newProxy.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindByIssuerName, "localhost");
                        newProxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                    }
                }
            }
            OperationContractAttribute operationContractAttribute = null;
            var properties = typeof(AccessControlInterfaceClient).GetProperties();
            var methods = typeof(AccessControlInterfaceClient).GetMethods();
            var method = typeof(AccessControlInterface).GetMethod(methodName);

            if (method != null)
            {
                var attributes = method.GetCustomAttributes(typeof(OperationContractAttribute), false);
                if (attributes.Length != 0 && attributes[0] is OperationContractAttribute)
                {
                    operationContractAttribute = attributes[0] as OperationContractAttribute;
                }
            }

            var sAction = string.Empty;
            if (operationContractAttribute != null)
            {
                sAction = operationContractAttribute.Action;
            }
            var attrs = Attribute.GetCustomAttributes(typeof(AccessControlInterfaceClient)); // Reflection.

            //Create address headers with XmlObjectSerializer specified
            XmlObjectSerializer serializer = new DataContractSerializer(typeof(string));
            var actionHdr = AddressHeader.CreateAddressHeader("Action", _addressHeaderNamespace, $"{sAction}",
                serializer);
            var messageIdHdr = AddressHeader.CreateAddressHeader("MessageID", _addressHeaderNamespace,
                $"urn:uuid:{Guid.NewGuid()}", serializer);
            var toHdr = AddressHeader.CreateAddressHeader("To", _addressHeaderNamespace,
                newProxy.Endpoint.Address.ToString(), serializer);
            var replyToHdr = AddressHeader.CreateAddressHeader("ReplyTo", _addressHeaderNamespace,
                HttpUtility.HtmlEncode("<Address>http://www.w3.org/2005/08/addressing/anonymous</Address>"), serializer);

            //Create new endpoint with addressHeader that contains security header
            var endpoint = new EndpointAddress(new Uri(string.Format("{0}", newProxy.Endpoint.Address)), actionHdr,
                messageIdHdr, toHdr, replyToHdr);

            newProxy.Endpoint.Address = endpoint;
            return newProxy;
        }

        #endregion

        #region Constructors

        public DsrAccessControlProxy() : base()
        {

        }
        public DsrAccessControlProxy(DsrConnectionParameters connectionParameters) : base()
        {
            _connectionParameters = connectionParameters;
        }
        #endregion

        #region Public methods

        #region Helper methods
        public DSRAccessControlService.DsrUUID CreateAccessControlServiceDsrUuid()
        {
            var uuid = new DSRAccessControlService.DsrUUID { requestId = Guid.NewGuid().ToString() };
            return uuid;
        }
        public DSRAccessControlService.DsrUUID CreateAccessControlServiceDsrUuid(Guid uid)
        {
            var uuid = new DSRAccessControlService.DsrUUID { requestId = uid.ToString() };
            return uuid;
        }

        public DSRAccessControlService.DsrUUID CreateAccessControlServiceDsrUuid(string uid)
        {
            Guid g = Guid.Empty;
            if (Guid.TryParse(uid, out g))
                return CreateAccessControlServiceDsrUuid(g);
            else
                return CreateAccessControlServiceDsrUuid();
        }

        public LocalDate GetLocalDate(DateTime dateTime)
        {
            var localDate = new LocalDate();
            localDate.year = dateTime.Year;
            localDate.month = dateTime.Month;
            localDate.dayOfMonth = dateTime.Day;
            return localDate;
        }

        public LocalTime GetLocalTime(DateTime dateTime)
        {
            var localTime = new LocalTime();
            localTime.hour = dateTime.Hour;
            localTime.minute = dateTime.Minute;
            localTime.second = dateTime.Second;
            localTime.millisecond = dateTime.Millisecond;
            return localTime;
        }

        public LocalDateTime GetLocalDateTime(DateTime dateTime)
        {
            var ldt = new LocalDateTime();
            ldt.localDate = GetLocalDate(dateTime);
            ldt.localTime = GetLocalTime(dateTime);
            return ldt;
        }

        public DateTimePeriod GetDateTimePeriod(DateTime start, DateTime end)
        {
            var dtp = new DateTimePeriod();
            dtp.start = GetLocalDateTime(start);
            dtp.end = GetLocalDateTime(end);
            return dtp;
        }

        public User CreateUser(Guid guid, DateTime validFrom, DateTime validUntil)
        {
            var user = new User();
            user.id = guid.ToString();
            user.validity = GetDateTimePeriod(validFrom, validUntil);
            return user;
        }
        #endregion

        #region Access Point methods

        public async Task<IEnumerable<DSRAccessControlService.LogEntry>> GetNewLogsAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetNewLogs))
                {
                    var data = await proxy.getNewLogsAsync(accessPointId);
                    return data.logEntry.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetNewLogs, ex);
                throw;
            }
        }

        public async Task<object> ExecuteDeviceSpecificCommandAsync(string accessPointId, DeviceSpecificCommandType commandType)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.DeviceSpecificCommand))
                {
                    var data = await proxy.deviceSpecificCommandAsync(accessPointId, commandType);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.DeviceSpecificCommand, ex);
                throw;
            }
        }

        public async Task<object> PulseOpenAsync(string accessPointId, long pulseTime)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.PulseOpen))
                {
                    var data = await proxy.pulseOpenAsync(accessPointId, pulseTime);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.PulseOpen, ex);
                throw;
            }
        }

        public async Task<object> UnlockAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.Unlock))
                {
                    var data = await proxy.unlockAsync(accessPointId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.Unlock, ex);
                throw;
            }
        }

        public async Task<object> LockAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.Lock))
                {
                    var data = await proxy.lockAsync(accessPointId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.Lock, ex);
                throw;
            }
        }

        public async Task<DateTime> GetDateTimeAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetDateTime))
                {
                    var data = await proxy.getDateTimeAsync(accessPointId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetDateTime, ex);
                throw;
            }
        }

        public async Task<object> SetDateTimeAsync(string accessPointId, DateTime dateTime)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.SetDateTime))
                {
                    var data = await proxy.setDateTimeAsync(accessPointId, dateTime);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.SetDateTime, ex);
                throw;
            }
        }

        public async Task<object> ReloadAccessPointProvisioningDataAsync(string accessPointId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ReloadAccessPointProvisioningData))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.reloadAccessPointProvisioningDataAsync(accessPointId, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ReloadAccessPointProvisioningData, ex);
                throw;
            }
        }

        public async Task<IEnumerable<DSRAccessControlService.LogEntry>> GetLogsByDateAsync(string accessPointId, DateTime startingDate, DateTime endingDate)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetLogsByDate))
                {
                    var data = await proxy.getLogsByDateAsync(accessPointId, startingDate, endingDate);
                    return data.logEntry.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetLogsByDate, ex);
                throw;
            }
        }

        public async Task<object> ResetAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.Reset))
                {
                    var data = await proxy.resetAsync(accessPointId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.Reset, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> RemoveAllAuthorizationsFromAccessPointAsync(string accessPointId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveAllAuthorizationsFromAccessPoint))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.removeAllAuthorizationsFromAccessPointAsync(accessPointId, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveAllAuthorizationsFromAccessPoint, ex);
                throw;
            }
        }

        public async Task<object> AddAccessPointsToAuthorizationAsync(IEnumerable<string> accessPointIds, Guid authorizationId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddAccessPointsToAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addAccessPointsToAuthorizationAsync(accessPointIds.ToArray(), authorizationId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddAccessPointsToAuthorization, ex);
                throw;
            }
        }

        public async Task<object> RemoveAccessPointsFromAuthorizationAsync(IEnumerable<string> accessPointIds, Guid authorizationId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveAccessPointsFromAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeAccessPointsFromAuthorizationAsync(accessPointIds.ToArray(), authorizationId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveAccessPointsFromAuthorization, ex);
                throw;
            }
        }

        public async Task<long> GetEntityIdCountForAccessPoint(DSRAccessControlService.EntityType entityType, string accessPointId, bool allowDuplicates)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetEntityIdCountForAccessPoint))
                {
                    var data = await proxy.getEntityIdCountForAccessPointAsync(entityType, accessPointId, allowDuplicates);
                    return data.count;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetEntityIdCountForAccessPoint, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> FindEntityIdsForAccessPoint(DSRAccessControlService.EntityType entityType, string accessPointId, bool allowDuplicates)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindEntityIdsForAccessPoint))
                {
                    var data = await proxy.findEntityIdsForAccessPointAsync(entityType, accessPointId, allowDuplicates);
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindEntityIdsForAccessPoint, ex);
                throw;
            }
        }
        #endregion

        #region Access Point Mode methods
        public async Task<IEnumerable<string>> GetAccessPointModeIdsAsync()
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetAccessPointModeIds))
                {
                    var data = await proxy.getAccessPointModeIdsAsync();
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetAccessPointModeIds, ex);
                throw;
            }
        }

        public async Task<string> AddAccessPointModeAsync(AccessPointMode accessPointMode, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddAccessPointMode))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addAccessPointModeAsync(accessPointMode, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddAccessPointMode, ex);
                throw;
            }
        }

        public async Task<object> RemoveAccessPointModeAsync(Guid accessPointModeId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveAccessPointMode))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeAccessPointModeAsync(accessPointModeId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveAccessPointMode, ex);
                throw;
            }
        }

        public async Task<object> ModifyAccessPointModeAsync(AccessPointMode accessPointMode, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ModifyAccessPointMode))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.modifyAccessPointModeAsync(accessPointMode, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ModifyAccessPointMode, ex);
                throw;
            }
        }

        public async Task<IEnumerable<AccessPointMode>> FindAccessPointModesAsync(IEnumerable<Guid> accessPointModeIds)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindAccessPointModes))
                {
                    var uids = accessPointModeIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.findAccessPointModesAsync(uids.ToArray());
                    return data.accessPointModes.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindAccessPointModes, ex);
                throw;
            }
        }
        #endregion

        #region Day Exception methods

        public async Task<string> AddDayExceptionAsync(DayException dayException, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddDayException))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addDayExceptionAsync(dayException, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddDayException, ex);
                throw;
            }
        }

        public async Task<object> RemoveDayExceptionAsync(Guid dayExceptionId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveDayException))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeDayExceptionAsync(dayExceptionId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveDayException, ex);
                throw;
            }
        }

        public async Task<object> ModifyDayExceptionAsync(DayException dayException, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ModifyDayException))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.modifyDayExceptionAsync(dayException, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ModifyDayException, ex);
                throw;
            }
        }

        public async Task<object> AddDayExceptionToDayExceptionGroupAsync(Guid dayExceptionGroupId, Guid dayExceptionId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddDayExceptionToDayExceptionGroup))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addDayExceptionToDayExceptionGroupAsync(dayExceptionGroupId.ToString().ToLower(), dayExceptionId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddDayExceptionToDayExceptionGroup, ex);
                throw;
            }
        }

        public async Task<object> RemoveDayExceptionFromDayExceptionGroupAsync(Guid dayExceptionGroupId, Guid dayExceptionId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveDayExceptionFromDayExceptionGroup))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeDayExceptionFromDayExceptionGroupAsync(dayExceptionGroupId.ToString().ToLower(), dayExceptionId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveDayExceptionFromDayExceptionGroup, ex);
                throw;
            }
        }

        public async Task<IEnumerable<DayException>> FindDayExceptionsAsync(IEnumerable<Guid> dayExceptionIds)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindDayExceptions))
                {
                    var uids = dayExceptionIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.findDayExceptionsAsync(uids.ToArray());
                    return data.dayExceptions.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindDayExceptions, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetDayExceptionIdsAsync()
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetDayExceptionIds))
                {
                    var data = await proxy.getDayExceptionIdsAsync();
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetDayExceptionIds, ex);
                throw;
            }
        }

        #endregion

        #region Day Exception Group methods

        public async Task<string> AddDayExceptionGroupAsync(DayExceptionGroup dayExceptionGroup, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddDayExceptionGroup))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addDayExceptionGroupAsync(dayExceptionGroup, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddDayExceptionGroup, ex);
                throw;
            }
        }

        public async Task<object> RemoveDayExceptionGroupAsync(Guid dayExceptionGroupId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveDayExceptionGroup))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeDayExceptionGroupAsync(dayExceptionGroupId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveDayExceptionGroup, ex);
                throw;
            }
        }

        public async Task<object> ModifyDayExceptionGroupAsync(DayExceptionGroup dayExceptionGroup, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ModifyDayExceptionGroup))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.modifyDayExceptionGroupAsync(dayExceptionGroup, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ModifyDayExceptionGroup, ex);
                throw;
            }
        }

        public async Task<object> AddDayExceptionGroupToScheduleAsync(Guid scheduleId, Guid dayExceptionGroupId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddDayExceptionGroupToSchedule))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addDayExceptionGroupToScheduleAsync(scheduleId.ToString().ToLower(), dayExceptionGroupId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddDayExceptionGroupToSchedule, ex);
                throw;
            }
        }

        public async Task<object> RemoveDayExceptionGroupFromScheduleAsync(Guid scheduleId, Guid dayExceptionGroupId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveDayExceptionGroupFromSchedule))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeDayExceptionGroupFromScheduleAsync(scheduleId.ToString().ToLower(), dayExceptionGroupId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveDayExceptionGroupFromSchedule, ex);
                throw;
            }
        }

        public async Task<IEnumerable<DayExceptionGroup>> FindDayExceptionGroupsAsync(IEnumerable<Guid> dayExceptionGroupIds)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindDayExceptionGroups))
                {
                    var uids = dayExceptionGroupIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.findDayExceptionGroupsAsync(uids.ToArray());
                    return data.dayExceptionGroups.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindDayExceptionGroups, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetDayExceptionGroupIdsAsync()
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetDayExceptionGroupIds))
                {
                    var data = await proxy.getDayExceptionGroupIdsAsync();
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetDayExceptionGroupIds, ex);
                throw;
            }
        }
        #endregion

        #region Day Period methods

        public async Task<string> AddDayPeriodAsync(DayPeriod dayPeriod, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddDayPeriod))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addDayPeriodAsync(dayPeriod, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddDayPeriod, ex);
                throw;
            }
        }

        public async Task<object> RemoveDayPeriodAsync(Guid dayPeriodId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveDayPeriod))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeDayPeriodAsync(dayPeriodId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveDayPeriod, ex);
                throw;
            }
        }

        public async Task<object> ModifyDayPeriodAsync(DayPeriod dayPeriod, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ModifyDayPeriod))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.modifyDayPeriodAsync(dayPeriod, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ModifyDayPeriod, ex);
                throw;
            }
        }

        public async Task<object> AddDayPeriodToScheduleAsync(Guid scheduleId, Guid dayPeriodId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddDayPeriodToSchedule))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.addDayPeriodToScheduleAsync(scheduleId.ToString().ToLower(), dayPeriodId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddDayPeriodToSchedule, ex);
                throw;
            }
        }

        public async Task<object> RemoveDayPeriodFromScheduleAsync(Guid scheduleId, Guid dayPeriodId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveDayPeriodFromSchedule))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();

                    var data = await proxy.removeDayPeriodFromScheduleAsync(scheduleId.ToString().ToLower(), dayPeriodId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveDayPeriodFromSchedule, ex);
                throw;
            }
        }

        public async Task<IEnumerable<DayPeriod>> FindDayPeriodsAsync(IEnumerable<Guid> dayPeriodIds)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindDayPeriods))
                {
                    var uids = dayPeriodIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.findDayPeriodsAsync(uids.ToArray());
                    return data.dayPeriods.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindDayPeriods, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetDayPeriodIdsAsync()
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetDayPeriodIds))
                {
                    var data = await proxy.getDayPeriodIdsAsync();
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetDayPeriodIds, ex);
                throw;
            }
        }

        #endregion

        #region User methods

        public async Task<string> AddUserAsync(User user, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddUser))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.addUserAsync(user, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddUser, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetUserIdsAsync()
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetUserIds))
                {
                    var data = await proxy.getUserIdsAsync();
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetUserIds, ex);
                throw;
            }
        }

        public async Task<object> RemoveUserAsync(Guid userId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveUser))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.removeUserAsync(userId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveUser, ex);
                throw;
            }
        }

        public async Task<object> ModifyUserAsync(User user, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ModifyUser))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.modifyUserAsync(user, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ModifyUser, ex);
                throw;
            }
        }

        public async Task<object> RemoveUserCascadingAsync(Guid userId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveUserCascading))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.removeUserCascadingAsync(userId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveUserCascading, ex);
                throw;
            }
        }

        public async Task<IEnumerable<User>> FindUsersAsync(IEnumerable<Guid> userIds)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindUsers))
                {
                    var uids = userIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.findUsersAsync(uids.ToArray());
                    return data.users.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindUsers, ex);
                throw;
            }
        }

        public async Task<object> AddUsersToAuthorizationAsync(IEnumerable<Guid> userIds, Guid authorizationId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddUsersToAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var uids = userIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.addUsersToAuthorizationAsync(uids, authorizationId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddUsersToAuthorization, ex);
                throw;
            }
        }

        public async Task<object> RemoveUsersFromAuthorizationAsync(IEnumerable<Guid> userIds, Guid authorizationId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveUsersFromAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var uids = userIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.removeUsersFromAuthorizationAsync(uids, authorizationId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveUsersFromAuthorization, ex);
                throw;
            }
        }
        #endregion

        #region Schedule methods
        public async Task<string> AddScheduleAsync(Schedule schedule, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddSchedule))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.addScheduleAsync(schedule, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddSchedule, ex);
                throw;
            }
        }

        public async Task<object> ModifyScheduleAsync(Schedule schedule, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ModifySchedule))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.modifyScheduleAsync(schedule, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ModifySchedule, ex);
                throw;
            }
        }

        public async Task<object> RemoveScheduleAsync(Guid scheduleId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                if (scheduleId == new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"))
                    return null;

                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveSchedule))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.removeScheduleAsync(scheduleId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveSchedule, ex);
                throw;
            }
        }

        public async Task<IEnumerable<Schedule>> FindSchedulesAsync(IEnumerable<Guid> scheduleIds)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindSchedules))
                {
                    var uids = scheduleIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.findSchedulesAsync(uids.ToArray());
                    return data.schedules.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindSchedules, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetScheduleIdsAsync()
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetScheduleIds))
                {
                    var data = await proxy.getScheduleIdsAsync();
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetScheduleIds, ex);
                throw;
            }
        }
        #endregion

        #region Authorization methods
        public async Task<string> AddAuthorizationAsync(Authorization authorization, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.AddAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.addAuthorizationAsync(authorization, requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.AddAuthorization, ex);
                throw;
            }
        }

        public async Task<object> ModifyAuthorizationAsync(Authorization authorization, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ModifyAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.modifyAuthorizationAsync(authorization, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ModifyAuthorization, ex);
                throw;
            }
        }

        public async Task<object> RemoveAuthorizationAsync(Guid authorizationId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.RemoveAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.removeAuthorizationAsync(authorizationId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.RemoveAuthorization, ex);
                throw;
            }
        }

        public async Task<object> SetNewScheduleInAuthorizationAsync(Guid scheduleId, Guid authorizationId, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.SetNewScheduleInAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.setNewScheduleInAuthorizationAsync(scheduleId.ToString().ToLower(), authorizationId.ToString().ToLower(), requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.SetNewScheduleInAuthorization, ex);
                throw;
            }
        }

        public async Task<object> SetAuthorizationTypeForAuthorizationAsync(Guid authorizationId, AuthorizationType authorizationType, DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.SetAuthorizationTypeForAuthorization))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.setAuthorizationTypeForAuthorizationAsync(authorizationId.ToString().ToLower(), authorizationType, requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.SetAuthorizationTypeForAuthorization, ex);
                throw;
            }
        }

        public async Task<IEnumerable<Authorization>> FindAuthorizationsAsync(IEnumerable<Guid> authorizationIds)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.FindAuthorizations))
                {
                    var uids = authorizationIds.Select(g => g.ToString().ToLower()).ToArray();
                    var data = await proxy.findAuthorizationsAsync(uids.ToArray());
                    return data.authorizations.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.FindAuthorizations, ex);
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetAuthorizationIdsAsync()
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.GetAuthorizationIds))
                {
                    var data = await proxy.getAuthorizationIdsAsync();
                    return data.entity;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.GetAuthorizationIds, ex);
                throw;
            }
        }
        #endregion

        #region General methods
        public async Task<object> ClearAllAsync(DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.ClearAll))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.clearAllAsync(requestId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.ClearAll, ex);
                throw;
            }
        }

        public async Task<IEnumerable<orphanedEntities>> DeleteAllOrphanEntitiesAsync(DSRAccessControlService.DsrUUID requestId)
        {
            try
            {
                using (var proxy = GetAccessControlProxy(DsrAccessControlServiceMethodNames.DeleteAllOrphanEntities))
                {
                    if (requestId == null)
                        requestId = CreateAccessControlServiceDsrUuid();
                    var data = await proxy.deleteAllOrphanEntitiesAsync(requestId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrAccessControlServiceMethodNames.DeleteAllOrphanEntities, ex);
                throw;
            }
        }
        #endregion

        #endregion

        #region Public properties

        #endregion

    }
    public static class DsrAccessControlServiceMethodNames
    {
        public const string PulseOpen = "pulseOpen";
        public const string Unlock = "unlock";
        public const string Lock = "lock";
        public const string AddUser = "addUser";
        public const string RemoveUser = "removeUser";
        public const string ModifyUser = "modifyUser";
        public const string RemoveUserCascading = "removeUserCascading";
        public const string AddSchedule = "addSchedule";
        public const string ModifySchedule = "modifySchedule";
        public const string RemoveSchedule = "removeSchedule";
        public const string AddAuthorization = "addAuthorization";
        public const string ModifyAuthorization = "modifyAuthorization";
        public const string RemoveAuthorization = "removeAuthorization";
        public const string GetDateTime = "getDateTime";
        public const string SetDateTime = "setDateTime";
        public const string GetNewLogs = "getNewLogs";
        public const string GetLogsByDate = "getLogsByDate";
        public const string ReloadAccessPointProvisioningData = "reloadAccessPointProvisioningData";
        public const string RemoveAllAuthorizationsFromAccessPoint = "removeAllAuthorizationsFromAccessPoint";
        public const string DeleteAllOrphanEntities = "deleteAllOrphanEntities";
        public const string ClearAll = "clearAll";
        public const string DeviceSpecificCommand = "deviceSpecificCommand";
        public const string Reset = "reset";
        public const string AddUsersToAuthorization = "addUsersToAuthorization";
        public const string AddAccessPointsToAuthorization = "addAccessPointsToAuthorization";
        public const string RemoveUsersFromAuthorization = "removeUsersFromAuthorization";
        public const string RemoveAccessPointsFromAuthorization = "removeAccessPointsFromAuthorization";
        public const string SetNewScheduleInAuthorization = "setNewScheduleInAuthorization";
        public const string SetAuthorizationTypeForAuthorization = "setAuthorizationTypeForAuthorization";
        public const string AddAccessPointMode = "addAccessPointMode";
        public const string RemoveAccessPointMode = "removeAccessPointMode";
        public const string ModifyAccessPointMode = "modifyAccessPointMode";
        public const string AddDayException = "addDayException";
        public const string RemoveDayException = "removeDayException";
        public const string ModifyDayException = "modifyDayException";
        public const string AddDayExceptionGroup = "addDayExceptionGroup";
        public const string RemoveDayExceptionGroup = "removeDayExceptionGroup";
        public const string ModifyDayExceptionGroup = "modifyDayExceptionGroup";
        public const string AddDayPeriod = "addDayPeriod";
        public const string RemoveDayPeriod = "removeDayPeriod";
        public const string ModifyDayPeriod = "modifyDayPeriod";
        public const string AddDayExceptionToDayExceptionGroup = "addDayExceptionToDayExceptionGroup";
        public const string RemoveDayExceptionFromDayExceptionGroup = "removeDayExceptionFromDayExceptionGroup";
        public const string AddDayExceptionGroupToSchedule = "addDayExceptionGroupToSchedule";
        public const string AddDayPeriodToSchedule = "addDayPeriodToSchedule";
        public const string RemoveDayExceptionGroupFromSchedule = "removeDayExceptionGroupFromSchedule";
        public const string RemoveDayPeriodFromSchedule = "removeDayPeriodFromSchedule";
        public const string FindAuthorizations = "findAuthorizations";
        public const string FindUsers = "findUsers";
        public const string FindSchedules = "findSchedules";
        public const string FindAccessPointModes = "findAccessPointModes";
        public const string FindDayPeriods = "findDayPeriods";
        public const string FindDayExceptions = "findDayExceptions";
        public const string FindDayExceptionGroups = "findDayExceptionGroups";
        public const string GetUserIds = "getUserIds";
        public const string GetAuthorizationIds = "getAuthorizationIds";
        public const string GetScheduleIds = "getScheduleIds";
        public const string GetDayPeriodIds = "getDayPeriodIds";
        public const string GetDayExceptionGroupIds = "getDayExceptionGroupIds";
        public const string GetDayExceptionIds = "getDayExceptionIds";
        public const string GetAccessPointModeIds = "getAccessPointModeIds";
        public const string GetEntityIdCountForAccessPoint = "getEntityIdCountForAccessPoint";
        public const string FindEntityIdsForAccessPoint = "findEntityIdsForAccessPoint";

    }


}
