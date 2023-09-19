//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    public partial class CredentialH1030437Bit : EntityBase, IIdentifiableEntity, IEquatable<CredentialH1030437Bit>, ITableEntityBase, IHasValidData, IAccessControlCredential
    {
    	public System.Guid CredentialUid { get; set; }
    	public int FacilityCode { get; set; }
    	public int IdCode { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	//public Credential Credential { get; set; }

        public bool HasValidData
        {
            get
            {
                return FacilityCode + IdCode != 0;
            }
        }


        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                return "HID H10304 37 Bit Wiegand";
            }
            set { }
        }

        public string CredentialValueDescription
        {
            get
            {
                return string.Format("Facility Code:{0}, ID Code:{1}", FacilityCode, IdCode);
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
                return $"{FacilityCode}:{IdCode}";
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
                return $"{GalaxySMS.Common.Enums.CredentialFormatCodes.HIDH1030437Bit}:{CredentialPartsString}";
            }
            set
            {
                ;
            }
        }
        #endregion

    }
}
