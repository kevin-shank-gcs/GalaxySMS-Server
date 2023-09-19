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

    public partial class CredentialXceedId40BitPutReq : PutRequestBase
    {

        //        public System.Guid CredentialUid { get; set; }

        [Required]
        [Range(0, 1023)]
        public int SiteCode { get; set; }

        [Required]
        [Range(0, 268435455)]
        public int IdCode { get; set; }
        //public string InsertName { get; set; }
        //public System.DateTimeOffset InsertDate { get; set; }
        //public string UpdateName { get; set; }
        //public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        //public Nullable<short> ConcurrencyValue { get; set; }

        ////public Credential Credential { get; set; }

        public bool HasValidData
        {
            get
            {
                return SiteCode + IdCode != 0;
            }
        }


        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                return "XceedId 40 Bit Wiegand";
            }
            set { }
        }

        public string CredentialValueDescription
        {
            get
            {
                return string.Format("Site Code:{0}, ID Code:{1}", SiteCode, IdCode);
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
                return $"{SiteCode}:{IdCode}";
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
                return $"{GalaxySMS.Common.Enums.CredentialFormatCodes.XceedID40Bit}:{CredentialPartsString}";
            }
            set
            {
                ;
            }
        }
        #endregion
    }
}
