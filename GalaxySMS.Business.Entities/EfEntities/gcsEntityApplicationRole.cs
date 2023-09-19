//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    public partial class gcsEntityApplicationRole : EntityBase, IIdentifiableEntity, IEquatable<gcsEntityApplicationRole>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsEntityApplicationRole
        {
        	public gcsEntityApplicationRole()
        	{
        		Initialize();
        	}
        
        	public gcsEntityApplicationRole(gcsEntityApplicationRole e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.gcsUserEntityApplicationRoles = new HashSet<gcsUserEntityApplicationRole>();
        	}
        
        	public void Initialize(gcsEntityApplicationRole e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.EntityApplicationRoleId = e.EntityApplicationRoleId;
        		this.RoleId = e.RoleId;
        		this.EntityApplicationId = e.EntityApplicationId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.gcsUserEntityApplicationRoles = e.gcsUserEntityApplicationRoles.ToCollection();
        		
        	}
        
        	public gcsEntityApplicationRole Clone(gcsEntityApplicationRole e)
        	{
        		return new gcsEntityApplicationRole(e);
        	}
        
        	public bool Equals(gcsEntityApplicationRole other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsEntityApplicationRole other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.EntityApplicationRoleId != this.EntityApplicationRoleId )
        			return false;
        		return true;
        	}
        
        	public override int GetHashCode()
        	{
        		return base.GetHashCode();
        	}
        
        	public override string ToString()
        	{
        		return base.ToString();
        	}
        }
    }
    */
    	public System.Guid EntityApplicationRoleId { get; set; }
    	public System.Guid RoleId { get; set; }
    	public System.Guid EntityApplicationId { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public gcsEntityApplication gcsEntityApplication { get; set; }
    	public gcsRole gcsRole { get; set; }
    	public ICollection<gcsUserEntityApplicationRole> gcsUserEntityApplicationRoles { get; set; }
    
    }
}
