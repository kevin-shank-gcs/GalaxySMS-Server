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
	using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Address
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The address validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class AddressValidator : AbstractValidator<Address>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public AddressValidator()
    		{
                RuleFor(obj => obj.StateProvinceUid).NotEqual(Guid.Empty);
                RuleFor(obj => obj.StreetAddress).NotEmpty();
                RuleFor(obj => obj.City).NotEmpty();
                RuleFor(obj => obj.PostalCode).NotEmpty();
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
    		return new AddressValidator();
    	}
    }
    
}
