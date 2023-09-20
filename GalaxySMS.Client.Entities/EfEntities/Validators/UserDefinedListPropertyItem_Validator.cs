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
	using GCS.Core.Common.Contracts;
    using FluentValidation;
    using GalaxySMS.Common.Constants;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user defined list property item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class UserDefinedListPropertyItem
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A user defined list property item validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class UserDefinedListPropertyItemValidator : AbstractValidator<UserDefinedListPropertyItem>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public UserDefinedListPropertyItemValidator()
    		{
		        RuleFor(obj => obj.Display).NotEmpty().Length(StringLimits.MinimumLength, StringLimits.MaximumLengthText65);
		        RuleFor(obj => obj.Description).NotEmpty().Length(StringLimits.MinimumLength, StringLimits.MaximumLengthText1000);
		        RuleFor(obj => obj.ItemValue).NotEmpty().Length(StringLimits.MinimumLength, StringLimits.MaximumLengthText255);
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
    		return new UserDefinedListPropertyItemValidator();
    	}
    }
    
}
