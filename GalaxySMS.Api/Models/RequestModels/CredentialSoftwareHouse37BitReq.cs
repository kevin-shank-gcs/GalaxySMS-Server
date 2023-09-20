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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class CredentialSoftwareHouse37BitReq
    {

//        public System.Guid CredentialUid { get; set; }
 
        [Required]
        [Range(0, 1023)]
        public int FacilityCode { get; set; }

        [Required]
        [Range(0, 63)]
        public ushort SiteCode { get; set; }

        [Required]
        [Range(0, 65535)]
        public uint IDCode { get; set; }
//    	public string InsertName { get; set; }
//    	public System.DateTimeOffset InsertDate { get; set; }
//    	public string UpdateName { get; set; }
//    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
//    	public Nullable<short> ConcurrencyValue { get; set; }
    
////    	public Credential Credential { get; set; }

        #region Implementation of IHasData

        public bool HasValidData
        {
            get
            {
                return FacilityCode + IDCode + SiteCode != 0;
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
                return string.Format("Facility Code:{0}, Site Code:{1} ID Code:{2}", FacilityCode, SiteCode, IDCode);
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
                return $"{FacilityCode}:{SiteCode}:{IDCode}";
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
