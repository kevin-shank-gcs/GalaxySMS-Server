//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class Credential : EntityBase, IIdentifiableEntity, IEquatable<Credential>, ITableEntityBase, IHasValidData, IAccessControlCredential
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid CredentialUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid CredentialFormatUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CardNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CardNumberIsHex { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CardBinaryData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short BitCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Credential26BitStandard Standard26Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialBqt36Bit Bqt36Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialCorporate1K35Bit Corporate1K35Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialCorporate1K48Bit Corporate1K48Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialFormat CredentialFormat { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialCypress37Bit Cypress37Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialData CredentialData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialH1030437Bit H1030437Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialH1030237Bit H1030237Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialPIV75Bit PIV75Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialXceedId40Bit XceedId40Bit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialSoftwareHouse37Bit SoftwareHouse37Bit { get; set; }

        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                if (CredentialFormat != null)
                    return CredentialFormat.Display;

                if (this.Standard26Bit != null)
                    return this.Standard26Bit.CredentialFormatDescription;

                if (this.Corporate1K35Bit != null)
                    return this.Corporate1K35Bit.CredentialFormatDescription;

                if (this.Corporate1K48Bit != null)
                    return this.Corporate1K48Bit.CredentialFormatDescription;

                if (this.Cypress37Bit != null)
                    return this.Cypress37Bit.CredentialFormatDescription;

                if (this.H1030437Bit != null)
                    return this.H1030437Bit.CredentialFormatDescription;

                if (this.XceedId40Bit != null)
                    return this.XceedId40Bit.CredentialFormatDescription;

                if (this.CredentialData != null)
                    return this.CredentialData.CredentialFormatDescription;

                if (this.Bqt36Bit != null)
                    return this.Bqt36Bit.CredentialFormatDescription;

                if (this.PIV75Bit != null)
                    return this.PIV75Bit.CredentialFormatDescription;

                return string.Format("CredentialFormatUid:{0}", CredentialFormatUid.ToString());

            }

            set { }
        }

        public string CredentialValueDescription
        {
            get
            {
                if (CredentialFormat != null)
                    return CredentialFormat.Display;

                if (this.Standard26Bit != null)
                    return this.Standard26Bit.CredentialValueDescription;

                if (this.Corporate1K35Bit != null)
                    return this.Corporate1K35Bit.CredentialValueDescription;

                if (this.Corporate1K48Bit != null)
                    return this.Corporate1K48Bit.CredentialValueDescription;

                if (this.Cypress37Bit != null)
                    return this.Cypress37Bit.CredentialValueDescription;

                if (this.H1030437Bit != null)
                    return this.H1030437Bit.CredentialValueDescription;

                if (this.XceedId40Bit != null)
                    return this.XceedId40Bit.CredentialValueDescription;

                if (this.CredentialData != null)
                    return this.CredentialData.CredentialValueDescription;

                if (this.Bqt36Bit != null)
                    return this.Bqt36Bit.CredentialValueDescription;

                if (this.PIV75Bit != null)
                    return this.PIV75Bit.CredentialValueDescription;

                return string.Format("Card Number:{0}", this.CardNumber);

            }
            set { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential parts string. </summary>
        ///
        /// <value> The credential parts string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CredentialPartsString
        {
            get
            {
                if (this.Standard26Bit != null)
                    return this.Standard26Bit.CredentialPartsString;

                if (this.Bqt36Bit != null)
                    return this.Bqt36Bit.CredentialPartsString;

                if (this.Corporate1K35Bit != null)
                    return this.Corporate1K35Bit.CredentialPartsString;

                if (this.Corporate1K48Bit != null)
                    return this.Corporate1K48Bit.CredentialPartsString;

                if (this.Cypress37Bit != null)
                    return this.Cypress37Bit.CredentialPartsString;

                if (this.CredentialData != null)
                    return this.CredentialData.CredentialPartsString;

                if (this.H1030437Bit != null)
                    return this.H1030437Bit.CredentialPartsString;

                if (this.PIV75Bit != null)
                    return this.PIV75Bit.CredentialPartsString;

                if (this.XceedId40Bit != null)
                    return this.XceedId40Bit.CredentialPartsString;

                return this.CardNumber;
            }
            set
            {
                ;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential format UID and parts string. </summary>
        ///
        /// <value> The credential format UID and parts string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CredentialFormatCodeAndPartsString
        {
            get
            {
                if (this.Standard26Bit != null)
                    return this.Standard26Bit.CredentialFormatCodeAndPartsString;

                if (this.Bqt36Bit != null)
                    return this.Bqt36Bit.CredentialFormatCodeAndPartsString;

                if (this.Corporate1K35Bit != null)
                    return this.Corporate1K35Bit.CredentialFormatCodeAndPartsString;

                if (this.Corporate1K48Bit != null)
                    return this.Corporate1K48Bit.CredentialFormatCodeAndPartsString;

                if (this.Cypress37Bit != null)
                    return this.Cypress37Bit.CredentialFormatCodeAndPartsString;

                if (this.CredentialData != null)
                    return this.CredentialData.CredentialFormatCodeAndPartsString;

                if (this.H1030437Bit != null)
                    return this.H1030437Bit.CredentialFormatCodeAndPartsString;

                if (this.PIV75Bit != null)
                    return this.PIV75Bit.CredentialFormatCodeAndPartsString;

                if (this.XceedId40Bit != null)
                    return this.XceedId40Bit.CredentialFormatCodeAndPartsString;

                return this.CardNumber;

            }
            set
            {
                ;
            }
        }

        #endregion
    }
}
