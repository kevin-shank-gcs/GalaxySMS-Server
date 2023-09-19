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
    /// <summary>   A time schedule. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class TimeSchedule
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A time schedule validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class TimeScheduleValidator : AbstractValidator<TimeSchedule>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public TimeScheduleValidator()
    		{
    			RuleFor(obj => obj.Display).NotEmpty().Length(1, 65);
                RuleFor(obj => obj.Description).NotEmpty().Length(1, 1000);
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
    		return new TimeScheduleValidator();
    	}
    }
    
}
