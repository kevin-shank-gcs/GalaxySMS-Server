//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GCS.Core.Common.UI.Converters;

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user defined text property rule. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class UserDefinedTextPropertyRule
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A user defined text property rule validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class UserDefinedTextPropertyRuleValidator : AbstractValidator<UserDefinedTextPropertyRule>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public UserDefinedTextPropertyRuleValidator()
    		{
                RuleFor(obj => obj.MinimumLength).LessThanOrEqualTo(obj=>obj.MaximumLength);
		        RuleFor(obj => obj.MaximumLength).LessThanOrEqualTo(obj => obj.MaximumLengthLimit);
		        RuleFor(obj => obj.DefaultValue).Length(0, 255);
		        RuleFor(obj => obj.Mask).Length(0, 255);
		        RuleFor(obj => obj.ValidationRegEx).Length(0, 255);
		        RuleFor(obj => obj.EmptyContent).Length(0, 255);
		        RuleFor(obj => obj.ValidationErrorMessage).Length(0, 1000);
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
    		return new UserDefinedTextPropertyRuleValidator();
    	}
    }
    
}
