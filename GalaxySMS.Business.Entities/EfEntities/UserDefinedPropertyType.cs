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
    public partial class UserDefinedPropertyType : EntityBase, IIdentifiableEntity, IEquatable<UserDefinedPropertyType>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class UserDefinedPropertyType
        {
        	public UserDefinedPropertyType()
        	{
        		Initialize();
        	}
        
        	public UserDefinedPropertyType(UserDefinedPropertyType e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.UserDefinedProperties = new HashSet<UserDefinedProperty>();
        	}
        
        	public void Initialize(UserDefinedPropertyType e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PropertyTypeUid = e.PropertyTypeUid;
        		this.PropertyType = e.PropertyType;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.UserDefinedProperties = e.UserDefinedProperties.ToCollection();
        		
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
        
        	public UserDefinedPropertyType Clone(UserDefinedPropertyType e)
        	{
        		return new UserDefinedPropertyType(e);
        	}
        
        	public bool Equals(UserDefinedPropertyType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(UserDefinedPropertyType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PropertyTypeUid != this.PropertyTypeUid )
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
    	public System.Guid PropertyTypeUid { get; set; }
    	public string PropertyType { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public ICollection<UserDefinedProperty> UserDefinedProperties { get; set; }
    
    }
}
