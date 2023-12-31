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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person activation mode. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class PersonActivationMode
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A person activation mode validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class PersonActivationModeValidator : AbstractValidator<PersonActivationMode>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public PersonActivationModeValidator()
    		{
    			//RuleFor(obj => obj.Description).NotEmpty();
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
    		return new PersonActivationModeValidator();
    	}
    }
    
}
