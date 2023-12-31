//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using GCS.Framework.CredentialProcessor;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential piv 75 bit. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class CredentialPIV75Bit
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A credential piv 75 bit validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class CredentialPIV75BitValidator : AbstractValidator<CredentialPIV75Bit>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public CredentialPIV75BitValidator()
    		{
                //RuleFor(obj => obj.AgencyCode).InclusiveBetween((int)CredentialPIV75BitFormat, (int)CredentialPIV75BitFormat.FacilityCodeMaximumValue);;
                //RuleFor(obj => obj.SiteCode).InclusiveBetween((int)CredentialPIV75BitFormat.IdCodeMinimumValue, (int)CredentialPIV75BitFormat.IdCodeMaximumValue);
                //RuleFor(obj => obj.CredentialCode).InclusiveBetween((short)CredentialPIV75BitFormat.IssueCodeMinimumValue, (short)CredentialPIV75BitFormat.IssueCodeMaximumValue);
    		}
    	}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The validator. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	protected override IValidator GetValidator()
    	{
    		return new CredentialPIV75BitValidator();
    	}
    }
    
}
