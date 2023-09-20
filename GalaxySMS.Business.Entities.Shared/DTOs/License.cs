////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\License.cs
//
// summary:	Implements the license class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class License
    {

        private string idField;

        private string typeField;

        private string expirationField;

        private byte quantityField;

        private LicenseCustomer customerField;

        private LicenseFeature[] productFeaturesField;

        private LicenseAttribute[] licenseAttributesField;

        private string signatureField;
        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Expiration
        {
            get
            {
                return this.expirationField;
            }
            set
            {
                this.expirationField = value;
            }
        }

        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public LicenseCustomer Customer
        {
            get
            {
                return this.customerField;
            }
            set
            {
                this.customerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Feature", IsNullable = false)]
#if NetCoreApi
#else
        [DataMember]
#endif
        public LicenseFeature[] ProductFeatures
        {
            get
            {
                return this.productFeaturesField;
            }
            set
            {
                this.productFeaturesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Attribute", IsNullable = false)]
#if NetCoreApi
#else
        [DataMember]
#endif
        public LicenseAttribute[] LicenseAttributes
        {
            get
            {
                return this.licenseAttributesField;
            }
            set
            {
                this.licenseAttributesField = value;
            }
        }

        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class LicenseCustomer
    {

        private string nameField;

        private string emailField;

        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class LicenseFeature
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
#if NetCoreApi
#else
        [DataMember]
#endif
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class LicenseAttribute
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
#if NetCoreApi
#else
        [DataMember]
#endif
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

}