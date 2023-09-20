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

    public partial class CredentialCorporate1K35BitReq
    {

        //public System.Guid CredentialUid { get; set; }
  
        [Required]
        [Range(0, 4095)]
        public int CompanyCode { get; set; }
  
        [Required]
        [Range(0, 1048575)]
        public int IdCode { get; set; }
        public bool HasValidData
        {
            get
            {
                return CompanyCode + IdCode != 0;
            }
        }


        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                return "HID Corporate 1000, 35 Bit Wiegand";
            }
            set { }
        }

        public string CredentialValueDescription
        {
            get
            {
                return string.Format("Company Code:{0}, ID Code:{1}", CompanyCode, IdCode);
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
                return $"{CompanyCode}:{IdCode}";
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
                return $"{GalaxySMS.Common.Enums.CredentialFormatCodes.HIDCorp1K35Bit}:{CredentialPartsString}";
            }
            set
            {
                ;
            }
        }
        #endregion

    }
}
