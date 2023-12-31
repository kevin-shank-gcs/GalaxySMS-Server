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
    public partial class AssaAccessPointType : EntityBase, IIdentifiableEntity, IEquatable<AssaAccessPointType>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class AssaAccessPointType
        {
        	public AssaAccessPointType()
        	{
        		Initialize();
        	}
        
        	public AssaAccessPointType(AssaAccessPointType e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.AssaAccessPoints = new HashSet<AssaAccessPoint>();
        	}
        
        	public void Initialize(AssaAccessPointType e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.AssaAccessPointTypeUid = e.AssaAccessPointTypeUid;
        		this.Id = e.Id;
        		this.DisplayName = e.DisplayName;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.AssaAccessPoints = e.AssaAccessPoints.ToCollection();
        		
        	}
        
        	public AssaAccessPointType Clone(AssaAccessPointType e)
        	{
        		return new AssaAccessPointType(e);
        	}
        
        	public bool Equals(AssaAccessPointType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AssaAccessPointType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AssaAccessPointTypeUid != this.AssaAccessPointTypeUid )
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
    	public System.Guid AssaAccessPointTypeUid { get; set; }
    	public string Id { get; set; }
    	public string DisplayName { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public ICollection<AssaAccessPoint> AssaAccessPoints { get; set; }
    
    }
}
