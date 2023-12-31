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
    public partial class PersonEntityMap : EntityBase, IIdentifiableEntity, IEquatable<PersonEntityMap>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class PersonEntityMap
        {
        	public PersonEntityMap()
        	{
        		Initialize();
        	}
        
        	public PersonEntityMap(PersonEntityMap e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(PersonEntityMap e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PersonEntityUid = e.PersonEntityUid;
        		this.PersonUid = e.PersonUid;
        		this.EntityId = e.EntityId;
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
        
        	public PersonEntityMap Clone(PersonEntityMap e)
        	{
        		return new PersonEntityMap(e);
        	}
        
        	public bool Equals(PersonEntityMap other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonEntityMap other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonEntityUid != this.PersonEntityUid )
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
    	public System.Guid PersonEntityMapUid { get; set; }
    	public System.Guid PersonUid { get; set; }
    	public System.Guid EntityId { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public gcsEntity gcsEntity { get; set; }
    
    }
}
