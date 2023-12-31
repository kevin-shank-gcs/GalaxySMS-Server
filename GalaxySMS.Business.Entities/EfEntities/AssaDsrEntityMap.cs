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
    public partial class AssaDsrEntityMap : EntityBase, IIdentifiableEntity, IEquatable<AssaDsrEntityMap>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class AssaDsrEntityMap
        {
        	public AssaDsrEntityMap()
        	{
        		Initialize();
        	}
        
        	public AssaDsrEntityMap(AssaDsrEntityMap e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AssaDsrEntityMap e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.AssaDsrEntityMapUid = e.AssaDsrEntityMapUid;
        		this.AssaDsrUid = e.AssaDsrUid;
        		this.EntityId = e.EntityId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AssaDsrEntityMap Clone(AssaDsrEntityMap e)
        	{
        		return new AssaDsrEntityMap(e);
        	}
        
        	public bool Equals(AssaDsrEntityMap other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AssaDsrEntityMap other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AssaDsrEntityMapUid != this.AssaDsrEntityMapUid )
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
    	public System.Guid AssaDsrEntityMapUid { get; set; }
    	public System.Guid AssaDsrUid { get; set; }
    	public System.Guid EntityId { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public gcsEntity gcsEntity { get; set; }
    
    }
}
