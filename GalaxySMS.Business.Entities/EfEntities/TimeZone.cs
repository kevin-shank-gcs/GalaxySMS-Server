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
    public partial class TimeZone : EntityBase, IIdentifiableEntity, IEquatable<TimeZone>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class TimeZone
        {
        	public TimeZone()
        	{
        		Initialize();
        	}
        
        	public TimeZone(TimeZone e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(TimeZone e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.TimeZoneUid = e.TimeZoneUid;
        		this.Id = e.Id;
        		this.DisplayName = e.DisplayName;
        		this.StandardName = e.StandardName;
        		this.DaylightName = e.DaylightName;
        		this.SupportsDaylightSavingsTime = e.SupportsDaylightSavingsTime;
        		this.BaseUtcOffset = e.BaseUtcOffset;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public TimeZone Clone(TimeZone e)
        	{
        		return new TimeZone(e);
        	}
        
        	public bool Equals(TimeZone other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(TimeZone other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.TimeZoneUid != this.TimeZoneUid )
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
    	public System.Guid TimeZoneUid { get; set; }
    	public string Id { get; set; }
    	public string DisplayName { get; set; }
    	public string StandardName { get; set; }
    	public string DaylightName { get; set; }
    	public bool SupportsDaylightSavingsTime { get; set; }
    	public long BaseUtcOffset { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    }
}
