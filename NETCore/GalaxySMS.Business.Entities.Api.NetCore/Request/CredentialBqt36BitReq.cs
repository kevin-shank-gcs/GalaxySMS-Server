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

    public partial class CredentialBqt36BitReq
    {

        //public System.Guid CredentialUid { get; set; }

        [Required]
        [Range(0, 16383)]
        public short FacilityCode { get; set; }

        [Required]
        [Range(0, 1048575)]
        public int IdCode { get; set; }

        [Required]
        [Range(1, 15)]
        public short IssueCode { get; set; }

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
