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
    /// <summary>   A cluster. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Cluster
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A cluster validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	class ClusterValidator : AbstractValidator<Cluster>
    	{
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

    		public ClusterValidator()
    		{
                RuleFor(obj => obj.SiteUid).NotEqual(Guid.Empty);
                RuleFor(obj => obj.EntityId).NotEqual(Guid.Empty);
                RuleFor(obj => obj.ClusterTypeUid).NotEqual(Guid.Empty);
                RuleFor(obj => obj.CredentialDataLengthUid).NotEqual(Guid.Empty);
                RuleFor(obj => obj.TimeScheduleTypeUid).NotEqual(Guid.Empty);

                RuleFor(obj => obj.ClusterName).NotEmpty().Length(1, 65);
                RuleFor(obj => obj.ClusterGroupId).InclusiveBetween(0, 65535);
                RuleFor(obj => (int) obj.ClusterNumber).InclusiveBetween(1, 65535);
                RuleFor(obj => (int) obj.AbaStartDigit).InclusiveBetween(1, 59);
                RuleFor(obj => (int) obj.AbaStopDigit).InclusiveBetween(2, 60);
                RuleFor(obj => (int) obj.AbaStartDigit).LessThan(obj => obj.AbaStopDigit);

                RuleFor(obj => (int) obj.WiegandStartBit).InclusiveBetween(0, 254);
                RuleFor(obj => (int) obj.WiegandStopBit).InclusiveBetween(1, 255);
                RuleFor(obj => (int) obj.WiegandStartBit).LessThan(obj => obj.WiegandStopBit);

                RuleFor(obj => (int) obj.CardaxStartBit).InclusiveBetween(1, 255);
                RuleFor(obj => (int) obj.CardaxStopBit).InclusiveBetween(1, 255);
                RuleFor(obj => (int) obj.CardaxStartBit).LessThan(obj => obj.CardaxStopBit);

                RuleFor(obj => (int) obj.LockoutAfterInvalidAttempts).InclusiveBetween(0, 255);
                RuleFor(obj => (int) obj.LockoutDurationSeconds).InclusiveBetween(0, 65535);
                RuleFor(obj => (int) obj.AccessRuleOverrideTimeout).InclusiveBetween(0, 65535);
                RuleFor(obj => (int) obj.UnlimitedCredentialTimeout).InclusiveBetween(0, 65535);
                RuleFor(obj => obj.TimeZoneId).Length(0, 65);
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
    		return new ClusterValidator();
    	}
    }
    
}
