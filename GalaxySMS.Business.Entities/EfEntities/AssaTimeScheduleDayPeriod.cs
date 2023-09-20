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
    public partial class AssaTimeScheduleDayPeriod : EntityBase, IIdentifiableEntity, IEquatable<AssaTimeScheduleDayPeriod>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class AssaTimeScheduleDayPeriod
        {
        	public AssaTimeScheduleDayPeriod()
        	{
        		Initialize();
        	}
        
        	public AssaTimeScheduleDayPeriod(AssaTimeScheduleDayPeriod e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AssaTimeScheduleDayPeriod e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.AssaTimeScheduleDayPeriodUid = e.AssaTimeScheduleDayPeriodUid;
        		this.TimeScheduleUid = e.TimeScheduleUid;
        		this.AssaDayPeriodUid = e.AssaDayPeriodUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AssaTimeScheduleDayPeriod Clone(AssaTimeScheduleDayPeriod e)
        	{
        		return new AssaTimeScheduleDayPeriod(e);
        	}
        
        	public bool Equals(AssaTimeScheduleDayPeriod other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AssaTimeScheduleDayPeriod other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AssaTimeScheduleDayPeriodUid != this.AssaTimeScheduleDayPeriodUid )
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
    	public System.Guid AssaTimeScheduleDayPeriodUid { get; set; }
    	public System.Guid TimeScheduleUid { get; set; }
    	public System.Guid AssaDayPeriodUid { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public AssaDayPeriod AssaDayPeriod { get; set; }
    
    }
}
