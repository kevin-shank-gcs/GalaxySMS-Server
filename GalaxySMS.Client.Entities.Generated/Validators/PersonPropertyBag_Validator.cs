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
    public partial class PersonPropertyBag
    {
    	
    
    	class PersonPropertyBagValidator : AbstractValidator<PersonPropertyBag>
    	{
    		public PersonPropertyBagValidator()
    		{
    			//RuleFor(obj => obj.Description).NotEmpty();
    		}
    	}
    
    	protected override IValidator GetValidator()
    	{
    		return new PersonPropertyBagValidator();
    	}
    }
    
}
