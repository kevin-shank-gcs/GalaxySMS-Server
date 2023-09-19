using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;
using System.Web;
using GCS.AssaAbloyDSR.DSRManagementService;
using GCS.Core.Common.Logger;

namespace GCS.AssaAbloyDSR
{
    public static class DsrManagementServiceMethodNames
    {
        public const string ListAllAccessPoints = "listAllAccessPoints";
        public const string ListAccessPoints = "listAccessPoints";
        public const string ListAccessPointsOnline = "listAccessPointsOnline";
        public const string GetAccessPointStatus = "getAccessPointStatus";
        public const string FindAccessPointBySerialNumber = "findAccessPointBySerialNumber";
        public const string VerifyAccessPointOnline = "verifyAccessPointOnline";
        public const string ConfirmAccessPoint = "confirmAccessPoint";
        public const string AddAndConfirmAccessPoint = "addAndConfirmAccessPoint";
        public const string RegisterCallback = "registerCallback";
        public const string ListCallbackEndpoints = "listCallbackEndpoints";
        public const string UnRegisterCallback = "unRegisterCallback";
        public const string GetSupportedCredentialFormats = "getSupportedCredentialFormats";
        public const string GetAccessPointTypes = "getAccessPointTypes";
        public const string GetVersionInfo = "getVersionInfo";
        public const string GetStatus = "getStatus";
        public const string SetAccessPointEndpointParams = "setAccessPointEndpointParams";
        public const string RemoveAccessPoint = "removeAccessPoint";
        public const string ClearAccessPoint = "clearAccessPoint";
        public const string ReplaceAccessPoint = "replaceAccessPoint";
        public const string DisableAccessPoint = "disableAccessPoint";
        public const string EnableAccessPoint = "enableAccessPoint";
        public const string AddReaderDescription = "addReaderDescription";
    }

    public class DsrManagementProxy : DsrProxyBase
    {
        private string addressSuffix = "/dsr/Management";
        private DsrConnectionParameters _connectionParameters;
        #region Private methods

        //private ManagementInterfaceClient GetManagementProxy(string methodName)
        //{
        //    var newProxy = new ManagementInterfaceClient();

        //    OperationContractAttribute operationContractAttribute = null;
        //    var properties = typeof (ManagementInterfaceClient).GetProperties();
        //    var methods = typeof (ManagementInterfaceClient).GetMethods();
        //    var method = typeof (ManagementInterface).GetMethod(methodName);

        //    if (method != null)
        //    {
        //        var attributes = method.GetCustomAttributes(typeof (OperationContractAttribute), false);
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
        //    var attrs = Attribute.GetCustomAttributes(typeof (ManagementInterfaceClient)); // Reflection.

        //    //Create address headers with XmlObjectSerializer specified
        //    var serializer = new DataContractSerializer(typeof (string));
        //    var actionHdr = AddressHeader.CreateAddressHeader("Action", _addressHeaderNamespace, $"{sAction}",
        //        serializer);
        //    var messageIdHdr = AddressHeader.CreateAddressHeader("MessageID", _addressHeaderNamespace,
        //        $"urn:uuid:{Guid.NewGuid()}", serializer);
        //    var toHdr = AddressHeader.CreateAddressHeader("To", _addressHeaderNamespace,
        //        newProxy.Endpoint.Address.ToString(), serializer);
        //    var replyToHdr = AddressHeader.CreateAddressHeader("ReplyTo", _addressHeaderNamespace,
        //        HttpUtility.HtmlEncode("<Address>http://www.w3.org/2005/08/addressing/anonymous</Address>"),
        //        serializer);

        //    //Create new endpoint with addressHeader that contains security header
        //    var endpoint = new EndpointAddress(new Uri(string.Format("{0}", newProxy.Endpoint.Address)), actionHdr,
        //        messageIdHdr, toHdr, replyToHdr);

        //    newProxy.Endpoint.Address = endpoint;
        //    return newProxy;
        //}

        private ManagementInterfaceClient GetManagementProxy(string methodName)
        {
            ManagementInterfaceClient newProxy;
            if (_connectionParameters == null)
                newProxy = new ManagementInterfaceClient();
            else
            {
                if (_connectionParameters.UseHttps == false)
                {
                    var binding = new BasicHttpBinding("ManagementInterfaceServiceSoapBinding");
                    binding.OpenTimeout = new TimeSpan(0, 0, 0, 5);
                    var address = new EndpointAddress(
                        $"http://{_connectionParameters.IpAddress}:{_connectionParameters.Port}{addressSuffix}");
                    newProxy = new ManagementInterfaceClient(binding, address);
                }
                else
                {
                    var messageSecurity = 
                        (AsymmetricSecurityBindingElement)SecurityBindingElement.
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
                    var address = new EndpointAddress($"https://{_connectionParameters.IpAddress}:{_connectionParameters.Port}{addressSuffix}");
                    newProxy = new ManagementInterfaceClient(binding, address);
                    if (newProxy.ClientCredentials != null)
                    {
                        newProxy.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "clientuser");
                        newProxy.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindByIssuerName, "localhost");
                        newProxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                    }
                }
            }

            OperationContractAttribute operationContractAttribute = null;
            var properties = typeof(ManagementInterfaceClient).GetProperties();
            var methods = typeof(ManagementInterfaceClient).GetMethods();
            var method = typeof(ManagementInterface).GetMethod(methodName);

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
            var attrs = Attribute.GetCustomAttributes(typeof(ManagementInterfaceClient)); // Reflection.

            //Create address headers with XmlObjectSerializer specified
            var serializer = new DataContractSerializer(typeof(string));
            var actionHdr = AddressHeader.CreateAddressHeader("Action", _addressHeaderNamespace, $"{sAction}",
                serializer);
            var messageIdHdr = AddressHeader.CreateAddressHeader("MessageID", _addressHeaderNamespace,
                $"urn:uuid:{Guid.NewGuid()}", serializer);
            var toHdr = AddressHeader.CreateAddressHeader("To", _addressHeaderNamespace,
                newProxy.Endpoint.Address.ToString(), serializer);
            var replyToHdr = AddressHeader.CreateAddressHeader("ReplyTo", _addressHeaderNamespace,
                HttpUtility.HtmlEncode("<Address>http://www.w3.org/2005/08/addressing/anonymous</Address>"),
                serializer);

            //Create new endpoint with addressHeader that contains security header
            var endpoint = new EndpointAddress(new Uri(string.Format("{0}", newProxy.Endpoint.Address)), actionHdr,
                messageIdHdr, toHdr, replyToHdr);

            newProxy.Endpoint.Address = endpoint;
            return newProxy;
        }

        #endregion

        #region Private fields

        private readonly string _addressHeaderNamespace = "http://www.w3.org/2005/08/addressing";
        //private readonly string _callbackUrl = "http://localhost:9090/callback";

        #endregion

        #region Constructors
        public DsrManagementProxy()
        {

        }

        public DsrManagementProxy(DsrConnectionParameters connectionParameters)
        {
            _connectionParameters = connectionParameters;
        }
        #endregion

        #region Public Methods

        public async Task<IEnumerable<AccessPoint>> GetAllAccessPointsAsync()
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.ListAllAccessPoints))
                {
                    var data = await proxy.listAllAccessPointsAsync();
                    return data.accessPoints.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ListAllAccessPoints, ex);
                throw;
            }
        }

        public async Task<IEnumerable<AccessPoint>> GetAccessPointsAsync(string accessPointType)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.ListAccessPoints))
                {
                    var data = await proxy.listAccessPointsAsync(accessPointType);
                    return data.accessPoints.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ListAccessPoints, ex);
                throw;
            }
        }

        public async Task<IEnumerable<AccessPointType>> GetAccessPointTypesAsync()
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.GetAccessPointTypes))
                {
                    var data = await proxy.getAccessPointTypesAsync();
                    return data.@return.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.GetAccessPointTypes, ex);
                throw;
            }
        }

        public async Task<IEnumerable<AccessPoint>> GetAccessPointsOnlineAsync(string accessPointType)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.ListAccessPointsOnline))
                {
                    var data = await proxy.listAccessPointsOnlineAsync(accessPointType);
                    return data.accessPoints.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ListAccessPointsOnline, ex);
                throw;
            }
        }

        public async Task<accessPointStatus> GetAccessPointStatusAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.GetAccessPointStatus))
                {
                    var data = await proxy.getAccessPointStatusAsync(accessPointId);
                    return data.accessPointStatus;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.GetAccessPointStatus, ex);
                throw;
            }
        }

        public async Task<AccessPoint> FindAccessPointBySerialNumberAsync(string serialNumber)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.FindAccessPointBySerialNumber))
                {
                    var data = await proxy.findAccessPointBySerialNumberAsync(serialNumber);
                    return data.accessPointBySerialNumber.accessPoint;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.FindAccessPointBySerialNumber, ex);
                throw;
            }
        }

        public async Task<bool> VerifyAccessPointOnlineAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.VerifyAccessPointOnline))
                {
                    var data = await proxy.verifyAccessPointOnlineAsync(accessPointId);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.VerifyAccessPointOnline, ex);
                throw;
            }
        }

        public async Task<object> ConfirmAccessPointAsync(string accessPointId, bool confirm)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.ConfirmAccessPoint))
                {
                    var data = await proxy.confirmAccessPointAsync(accessPointId, confirm);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ConfirmAccessPoint, ex);
                throw;
            }
        }

        public async Task<string> AddAndConfirmAccessPointAsync(string accessPointTypeId, string serialNumber)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.AddAndConfirmAccessPoint))
                {
                    var data = await proxy.addAndConfirmAccessPointAsync(accessPointTypeId, serialNumber);
                    return data.@return;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.AddAndConfirmAccessPoint, ex);
                throw;
            }
        }

        public async Task<object> AddReaderDescriptionAsync(string accessPointId, string description)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.AddReaderDescription))
                {
                    var data = await proxy.addReaderDescriptionAsync(accessPointId, description);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.AddReaderDescription, ex);
                throw;
            }
        }

        public async Task<object> RegisterCallbackAsync(string callbackUrl)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.RegisterCallback))
                {
                    var data = await proxy.registerCallbackAsync(callbackUrl);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.RegisterCallback, ex);
                throw;
            }
        }


        public async Task<IEnumerable<CallbackEndpoint>> ListCallbackEndpointsAsync()
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.ListCallbackEndpoints))
                {
                    var data = await proxy.listCallbackEndpointsAsync();
                    return data.accessPoints.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ListCallbackEndpoints, ex);
                throw;
            }
        }


        public async Task<object> UnRegisterCallbackAsync(string callbackUrl)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.UnRegisterCallback))
                {
                    var data = await proxy.unRegisterCallbackAsync(callbackUrl);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.UnRegisterCallback, ex);
                throw;
            }
        }


        public async Task<IEnumerable<CredentialFormat>> GetSupportedCredentialFormatsAsync(string accessPointTypeId)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.GetSupportedCredentialFormats))
                {
                    var data = await proxy.getSupportedCredentialFormatsAsync(accessPointTypeId);
                    return data.@return.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.GetSupportedCredentialFormats, ex);
                throw;
            }
        }

        public async Task<versionInfo> GetVersionInfoAsync()
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.GetVersionInfo))
                {
                    var data = await proxy.getVersionInfoAsync();
                    return data.versionInfo;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.GetVersionInfo, ex);
                throw;
            }
        }

        public async Task<OnlineSince> GetStatusAsync()
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.GetStatus))
                {
                    var data = await proxy.getStatusAsync();
                    //data.onlineSince.lastTimeDsrGotOnline = new DateTime(data.onlineSince.lastTimeDsrGotOnline.Year, data.onlineSince.lastTimeDsrGotOnline.Month, data.onlineSince.lastTimeDsrGotOnline.Day, data.onlineSince.lastTimeDsrGotOnline.Hour, data.onlineSince.lastTimeDsrGotOnline.Minute, data.onlineSince.lastTimeDsrGotOnline.Second, data.onlineSince.lastTimeDsrGotOnline.Millisecond);
                    return data.onlineSince;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.GetStatus, ex);
                throw;
            }
        }

        public async Task<object> SetAccessPointEndpointParamsAsync(string accessPointId,
            EndpointParam endpointParam)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.SetAccessPointEndpointParams))
                {
                    var data = await proxy.setAccessPointEndpointParamsAsync(accessPointId, endpointParam);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.SetAccessPointEndpointParams, ex);
                throw;
            }
        }

        public async Task<object> RemoveAccessPointAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.RemoveAccessPoint))
                {
                    var data = await proxy.removeAccessPointAsync(accessPointId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.RemoveAccessPoint, ex);
                throw;
            }
        }

        public async Task<object> ClearAccessPointAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.ClearAccessPoint))
                {
                    var data = await proxy.clearAccessPointAsync(accessPointId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ClearAccessPoint, ex);
                throw;
            }
        }

        public async Task<object> ReplaceAccessPointAsync(string accessPointId, string serialNumber)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.ReplaceAccessPoint))
                {
                    var data = await proxy.replaceAccessPointAsync(accessPointId, serialNumber);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ReplaceAccessPoint, ex);
                throw;
            }
        }

        public async Task<object> DisableAccessPointAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.DisableAccessPoint))
                {
                    var data = await proxy.disableAccessPointAsync(accessPointId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.DisableAccessPoint, ex);
                throw;
            }
        }

        public async Task<object> EnableAccessPointAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetManagementProxy(DsrManagementServiceMethodNames.EnableAccessPoint))
                {
                    var data = await proxy.enableAccessPointAsync(accessPointId);
                    return data;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.EnableAccessPoint, ex);
                throw;
            }
        }

        #endregion
    }
}