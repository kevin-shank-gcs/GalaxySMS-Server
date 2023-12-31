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
    public partial class AcknowledgeAlarmPredefinedResponse
    {
    	
    
    	class AcknowledgeAlarmPredefinedResponseValidator : AbstractValidator<AcknowledgeAlarmPredefinedResponse>
    	{
    		public AcknowledgeAlarmPredefinedResponseValidator()
    		{
    			RuleFor(obj => obj.Response).MaximumLength(GalaxySMS.Common.Constants.StringLimits.MaximumLengthText1000);
    		}
    	}
    
    	protected override IValidator GetValidator()
    	{
    		return new AcknowledgeAlarmPredefinedResponseValidator();
    	}
    }
    
}
