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
    /// <summary>   A credential cypress 37 bit. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class CredentialCypress37Bit
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A credential cypress 37 bit validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class CredentialCypress37BitValidator : AbstractValidator<CredentialCypress37Bit>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public CredentialCypress37BitValidator()
    		{
		        RuleFor(obj => obj.FacilityCode).InclusiveBetween((int)CredentialCypress37BitFormat.FacilityCodeMinimumValue, (int)CredentialCypress37BitFormat.FacilityCodeMaximumValue);
		        RuleFor(obj => obj.IdCode).InclusiveBetween((int)CredentialCypress37BitFormat.IdCodeMinimumValue, (int)CredentialCypress37BitFormat.IdCodeMaximumValue);
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
    		return new CredentialCypress37BitValidator();
    	}
    }
    
}
