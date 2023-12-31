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
    /// <summary>   The gcs role. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsRole
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The gcs role validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class gcsRoleValidator : AbstractValidator<gcsRole>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public gcsRoleValidator()
    		{
                RuleFor(obj => obj.EntityId).NotEmpty();
                RuleFor(obj => obj.RoleName).MaximumLength(65).NotEmpty();
                RuleFor(obj => obj.RoleDescription).MaximumLength(255);
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
    		return new gcsRoleValidator();
    	}
    }
    
}
