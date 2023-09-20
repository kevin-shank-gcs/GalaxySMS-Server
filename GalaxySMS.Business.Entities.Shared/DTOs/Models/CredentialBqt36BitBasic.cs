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
    public partial class CredentialBqt36BitBasic : EntityBaseSimple
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
        public short FacilityCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int IdCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short IssueCode { get; set; }

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

        //public Credential Credential { get; set; }

        public bool HasValidData
        {
            get
            {
                return FacilityCode + IdCode + IssueCode != 0;
            }
        }

        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                return "BQT 36 Bit";
            }
            set { }
        }

        public string CredentialValueDescription
        {
            get
            {
                return string.Format("Facility Code:{0}, ID Code:{1}, Issue Code: {2}", FacilityCode, IdCode, IssueCode);
            }
            set { }
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string CardNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CardBinaryData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the credential parts string. </summary>
        ///
        /// <value> The credential parts string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CredentialPartsString
        {
            get
            {
                return $"{FacilityCode}:{IdCode}:{IssueCode}";
            }
            set
            {
                ;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the credential format UID and parts string. </summary>
        ///
        /// <value> The credential format UID and parts string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CredentialFormatCodeAndPartsString
        {
            get
            {
                return $"{GalaxySMS.Common.Enums.CredentialFormatCodes.Bqt36Bit}:{CredentialPartsString}";
            }
            set
            {
                ;
            }
        }

        #endregion
    }
}
