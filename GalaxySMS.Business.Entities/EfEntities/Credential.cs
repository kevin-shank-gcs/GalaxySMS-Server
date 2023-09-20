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
    public partial class Credential : EntityBase, IIdentifiableEntity, IEquatable<Credential>, ITableEntityBase, IHasValidData, IAccessControlCredential
    {
    	public System.Guid CredentialUid { get; set; }
    	public System.Guid CredentialFormatUid { get; set; }
    	public string CardNumber { get; set; }
    	public bool CardNumberIsHex { get; set; }
    	public byte[] CardBinaryData { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    	public short BitCount { get; set; }
    
    	public Credential26BitStandard Credential26BitStandard { get; set; }
    	public CredentialBqt36Bit CredentialBqt36Bit { get; set; }
    	public CredentialCorporate1K35Bit CredentialCorporate1K35Bit { get; set; }
    	public CredentialCorporate1K48Bit CredentialCorporate1K48Bit { get; set; }
    	public CredentialFormat CredentialFormat { get; set; }
    	public CredentialCypress37Bit CredentialCypress37Bit { get; set; }
    	public CredentialData CredentialData { get; set; }
    	public CredentialH1030437Bit CredentialH1030437Bit { get; set; }
    	public CredentialPIV75Bit CredentialPIV75Bit { get; set; }
    	public CredentialXceedId40Bit CredentialXceedId40Bit { get; set; }

        #region Implementation of IAccessControlCredential

        public string CredentialFormatDescription
        {
            get
            {
                if( CredentialFormat != null)
                    return CredentialFormat.Display;

               if( this.Credential26BitStandard != null )
                   return this.Credential26BitStandard.CredentialFormatDescription;

                if (this.CredentialCorporate1K35Bit != null)
                    return this.CredentialCorporate1K35Bit.CredentialFormatDescription;

                if (this.CredentialCorporate1K48Bit != null)
                    return this.CredentialCorporate1K48Bit.CredentialFormatDescription;

                if (this.CredentialCypress37Bit != null)
                    return this.CredentialCypress37Bit.CredentialFormatDescription;

                if (this.CredentialH1030437Bit != null)
                    return this.CredentialH1030437Bit.CredentialFormatDescription;

                if (this.CredentialXceedId40Bit != null)
                    return this.CredentialXceedId40Bit.CredentialFormatDescription;

                if (this.CredentialData != null)
                    return this.CredentialData.CredentialFormatDescription;

                if (this.CredentialBqt36Bit != null)
                    return this.CredentialBqt36Bit.CredentialFormatDescription;

                if (this.CredentialPIV75Bit != null)
                    return this.CredentialPIV75Bit.CredentialFormatDescription;

                return string.Format("CredentialFormatUid:{0}", CredentialFormatUid.ToString());

            }

            set{}
        }

        public string CredentialValueDescription
        {
            get
            {
                if (CredentialFormat != null)
                    return CredentialFormat.Display;

                if (this.Credential26BitStandard != null)
                    return this.Credential26BitStandard.CredentialValueDescription;

                if (this.CredentialCorporate1K35Bit != null)
                    return this.CredentialCorporate1K35Bit.CredentialValueDescription;

                if (this.CredentialCorporate1K48Bit != null)
                    return this.CredentialCorporate1K48Bit.CredentialValueDescription;

                if (this.CredentialCypress37Bit != null)
                    return this.CredentialCypress37Bit.CredentialValueDescription;

                if (this.CredentialH1030437Bit != null)
                    return this.CredentialH1030437Bit.CredentialValueDescription;

                if (this.CredentialXceedId40Bit != null)
                    return this.CredentialXceedId40Bit.CredentialValueDescription;

                if (this.CredentialData != null)
                    return this.CredentialData.CredentialValueDescription;

                if (this.CredentialBqt36Bit != null)
                    return this.CredentialBqt36Bit.CredentialValueDescription;

                if (this.CredentialPIV75Bit != null)
                    return this.CredentialPIV75Bit.CredentialValueDescription;

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
                if( this.Credential26BitStandard != null )
                    return this.Credential26BitStandard.CredentialPartsString;

                if( this.CredentialBqt36Bit != null )
                    return this.CredentialBqt36Bit.CredentialPartsString;
             
                if( this.CredentialCorporate1K35Bit != null )
                    return this.CredentialCorporate1K35Bit.CredentialPartsString;
             
                if( this.CredentialCorporate1K48Bit != null )
                    return this.CredentialCorporate1K48Bit.CredentialPartsString;
            
                if( this.CredentialCypress37Bit != null )
                    return this.CredentialCypress37Bit.CredentialPartsString;
             
                if( this.CredentialData != null )
                    return this.CredentialData.CredentialPartsString;
             
                if( this.CredentialH1030437Bit != null )
                    return this.CredentialH1030437Bit.CredentialPartsString;
            
                if( this.CredentialPIV75Bit != null )
                    return this.CredentialPIV75Bit.CredentialPartsString;
           
                if( this.CredentialXceedId40Bit != null )
                    return this.CredentialXceedId40Bit.CredentialPartsString;
            
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
                if( this.Credential26BitStandard != null )
                    return this.Credential26BitStandard.CredentialFormatCodeAndPartsString;

                if( this.CredentialBqt36Bit != null )
                    return this.CredentialBqt36Bit.CredentialFormatCodeAndPartsString;
             
                if( this.CredentialCorporate1K35Bit != null )
                    return this.CredentialCorporate1K35Bit.CredentialFormatCodeAndPartsString;
             
                if( this.CredentialCorporate1K48Bit != null )
                    return this.CredentialCorporate1K48Bit.CredentialFormatCodeAndPartsString;
            
                if( this.CredentialCypress37Bit != null )
                    return this.CredentialCypress37Bit.CredentialFormatCodeAndPartsString;
             
                if( this.CredentialData != null )
                    return this.CredentialData.CredentialFormatCodeAndPartsString;
             
                if( this.CredentialH1030437Bit != null )
                    return this.CredentialH1030437Bit.CredentialFormatCodeAndPartsString;
            
                if( this.CredentialPIV75Bit != null )
                    return this.CredentialPIV75Bit.CredentialFormatCodeAndPartsString;
           
                if( this.CredentialXceedId40Bit != null )
                    return this.CredentialXceedId40Bit.CredentialFormatCodeAndPartsString;
            
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
