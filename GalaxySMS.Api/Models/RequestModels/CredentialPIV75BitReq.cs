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

    public partial class CredentialPIV75BitReq
    {

//        public System.Guid CredentialUid { get; set; }
  
        [Required]
        [Range(0, 16383)]
        public int AgencyCode { get; set; }
  
        [Required]
        [Range(0, 16383)]
        public int SiteCode { get; set; }
  
        [Required]
        [Range(0, 1048575)]
        public int CredentialCode { get; set; }
        //public string InsertName { get; set; }
        //public System.DateTimeOffset InsertDate { get; set; }
        //public string UpdateName { get; set; }
        //public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        //public Nullable<short> ConcurrencyValue { get; set; }

        ////public Credential Credential1 { get; set; }

        public bool HasValidData
        {
            get
            {
                return AgencyCode + SiteCode + CredentialCode != 0;
            }
        }


        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                return "PIV 75 Bit Wiegand";
            }
            set { }
        }

        public string CredentialValueDescription
        {
            get
            {
                return string.Format("Agency Code:{0}, Site Code:{1}, Credential Code:{2}", AgencyCode, SiteCode, CredentialCode);
            }
            set { }
        }
        public string CardNumber { get; set; }
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
                return $"{AgencyCode}:{SiteCode}:{CredentialCode}";
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
                return $"{GalaxySMS.Common.Enums.CredentialFormatCodes.PIV75Bit}:{CredentialPartsString}";
            }
            set
            {
                ;
            }
        }

        #endregion
    }
}
