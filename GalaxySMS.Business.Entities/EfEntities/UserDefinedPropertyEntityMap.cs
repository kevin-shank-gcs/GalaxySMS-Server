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
    public partial class UserDefinedPropertyEntityMap : EntityBase, IIdentifiableEntity, IEquatable<UserDefinedPropertyEntityMap>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class UserDefinedPropertyEntityMap
        {
        	public UserDefinedPropertyEntityMap()
        	{
        		Initialize();
        	}
        
        	public UserDefinedPropertyEntityMap(UserDefinedPropertyEntityMap e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(UserDefinedPropertyEntityMap e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.UserDefinedPropertyEntityMapUid = e.UserDefinedPropertyEntityMapUid;
        		this.EntityId = e.EntityId;
        		this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public bool IsAnythingDirty
        	{
        		get
        		{
        			//foreach( var o in InterfaceBoardSections)
        			//{
        			//	if (o.IsAnythingDirty == true)
        			//		return true;
        			//}
        			return IsDirty;                
        		}
        	}
        
        	public UserDefinedPropertyEntityMap Clone(UserDefinedPropertyEntityMap e)
        	{
        		return new UserDefinedPropertyEntityMap(e);
        	}
        
        	public bool Equals(UserDefinedPropertyEntityMap other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(UserDefinedPropertyEntityMap other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.UserDefinedPropertyEntityMapUid != this.UserDefinedPropertyEntityMapUid )
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
    	public System.Guid UserDefinedPropertyEntityMapUid { get; set; }
    	public System.Guid EntityId { get; set; }
    	public System.Guid UserDefinedPropertyUid { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public gcsEntity gcsEntity { get; set; }
    
    }
}
