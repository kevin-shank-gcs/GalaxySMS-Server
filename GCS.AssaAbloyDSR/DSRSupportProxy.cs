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
using GCS.AssaAbloyDSR.DSRSupportService;
using GCS.Core.Common.Logger;

namespace GCS.AssaAbloyDSR
{
    public static class DSRSupportProxyServiceMethodNames
    {
        public const string GetAccessPoint = "getAccessPoint";
        public const string GetAccessPointsList = "getAccessPointsList";
        public const string GetAllAccessPoints = "getAllAccessPoints";
    }

    public class DSRSupportProxy : DsrProxyBase
    {
        #region Private methods
        private string addressSuffix = "/dsr/DsrSupport";

        //private DsrSupportInterfaceClient GetSupportProxy(string methodName)
        //{
        //    var newProxy = new DsrSupportInterfaceClient();
        //    OperationContractAttribute operationContractAttribute = null;
        //    var properties = typeof (DsrSupportInterfaceClient).GetProperties();
        //    var methods = typeof (DsrSupportInterfaceClient).GetMethods();
        //    var method = typeof (DsrSupportInterface).GetMethod(methodName);

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
        //    var attrs = Attribute.GetCustomAttributes(typeof (DsrSupportInterfaceClient)); // Reflection.

        //    //Create address headers with XmlObjectSerializer specified
        //    XmlObjectSerializer serializer = new DataContractSerializer(typeof (string));
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

        private DsrSupportInterfaceClient GetSupportProxy(string methodName)
        {
            DsrSupportInterfaceClient newProxy;
            if (_connectionParameters == null)
                newProxy = new DsrSupportInterfaceClient();
            else
            {
                if (_connectionParameters.UseHttps == false)
                {
                    var binding = new BasicHttpBinding("DsrSupportInterfaceServiceSoapBinding");
                    var address = new EndpointAddress(
                        $"http://{_connectionParameters.IpAddress}:{_connectionParameters.Port}{addressSuffix}");
                    newProxy = new DsrSupportInterfaceClient(binding, address);
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
                    var address = new EndpointAddress(
                        $"https://{_connectionParameters.IpAddress}:{_connectionParameters.Port}{addressSuffix}");
                    newProxy = new DsrSupportInterfaceClient(binding, address);
                    if (newProxy.ClientCredentials != null)
                    {
                        newProxy.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "clientuser");
                        newProxy.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindByIssuerName, "localhost");
                        newProxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                    }
                }
            }
            OperationContractAttribute operationContractAttribute = null;
            var properties = typeof(DsrSupportInterfaceClient).GetProperties();
            var methods = typeof(DsrSupportInterfaceClient).GetMethods();
            var method = typeof(DsrSupportInterface).GetMethod(methodName);

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
            var attrs = Attribute.GetCustomAttributes(typeof(DsrSupportInterfaceClient)); // Reflection.

            //Create address headers with XmlObjectSerializer specified
            XmlObjectSerializer serializer = new DataContractSerializer(typeof(string));
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
        private DsrConnectionParameters _connectionParameters;
        #endregion

        #region Constructors
        public DSRSupportProxy():base()
        {

        }

        public DSRSupportProxy(DsrConnectionParameters connectionParameters) : base()
        {
            _connectionParameters = connectionParameters;
        }
        #endregion

        #region Public Methods

        public async Task<AccessPointDTO> GetAccessPointAsync(string accessPointId)
        {
            try
            {
                using (var proxy = GetSupportProxy(DSRSupportProxyServiceMethodNames.GetAccessPoint))
                {
                    var data = await proxy.getAccessPointAsync(accessPointId);
                    return data.accessPointDTO.accessPointDTO;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DSRSupportProxyServiceMethodNames.GetAccessPoint, ex);
                throw;
            }
        }

        public async Task<IEnumerable<AccessPointDTO>> GetAccessPointsListAsync(string sortBy, string sortOrder, int offset, int maxResults)
        {
            try
            {
                using (var proxy = GetSupportProxy(DSRSupportProxyServiceMethodNames.GetAccessPointsList))
                {
                    var data = await proxy.getAccessPointsListAsync(sortBy, sortOrder, offset, maxResults);
                    return data.accessPointDTOs.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DSRSupportProxyServiceMethodNames.GetAccessPointsList, ex);
                throw;
            }
        }

        public async Task<IEnumerable<AccessPointDTO>> GetAllAccessPointsAsync(string sortBy, string sortOrder, int offset, int maxResults)
        {
            try
            {
                using (var proxy = GetSupportProxy(DSRSupportProxyServiceMethodNames.GetAllAccessPoints))
                {
                    var data = await proxy.getAllAccessPointAsync();
                    return data.accessPointDTOs.ToArray();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(DSRSupportProxyServiceMethodNames.GetAllAccessPoints, ex);
                throw;
            }
        }

        //public async Task<IEnumerable<AccessPointDTO>> GetAllAccessPointsAsync(string sortBy, string sortOrder, int offset, int maxResults)
        //{
        //    try
        //    {
        //        using (var proxy = GetSupportProxy(DSRSupportProxyServiceMethodNames.GetAllAccessPoints))
        //        {
        //            var data = await proxy.();
        //            return data.accessPointDTOs.ToArray();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error(DSRSupportProxyServiceMethodNames.GetAllAccessPoints, ex);
        //        throw;
        //    }
        //}
        #endregion
    }
}