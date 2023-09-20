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
    public partial class CredentialSoftwareHouse37BitBasic : EntityBaseSimple
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
        public int FacilityCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ushort SiteCode { get; set; }
        
#if NetCoreApi
#else
        [DataMember]
#endif
    	public uint IdCode { get; set; }
        
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
    
//    	public Credential Credential { get; set; }

        #region Implementation of IHasData

        public bool HasValidData
        {
            get
            {
                return FacilityCode + IdCode + SiteCode != 0;
            }
        }

        #endregion

        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                return "Software House 37 Bit";
            }
            set { }
        }

        public string CredentialValueDescription
        {
            get
            {
                return string.Format("Facility Code:{0}, Site Code:{1} ID Code:{2}", FacilityCode, SiteCode, IdCode);
            }
            set { }
        }

        public string CardNumber
        {
            get
            {
                return string.Empty;
            }

            set
            {

            }
        }


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
                return $"{FacilityCode}:{SiteCode}:{IdCode}";
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
                return $"{GalaxySMS.Common.Enums.CredentialFormatCodes.SoftwareHouse37Bit}:{CredentialPartsString}";
            }
            set
            {
                ;
            }
        }
        #endregion

    
    }
}
