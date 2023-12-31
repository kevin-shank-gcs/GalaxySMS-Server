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
    public partial class StateProvince : EntityBase, IIdentifiableEntity, IEquatable<StateProvince>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class StateProvince
        {
        	public StateProvince()
        	{
        		Initialize();
        	}
        
        	public StateProvince(StateProvince e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.Addresses = new HashSet<Address>();
        	}
        
        	public void Initialize(StateProvince e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.StateProvinceUid = e.StateProvinceUid;
        		this.CountryUid = e.CountryUid;
        		this.StateProvinceCode = e.StateProvinceCode;
        		this.StateProvinceName = e.StateProvinceName;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.CountryName = e.CountryName;
        		this.CountryIso = e.CountryIso;
        		this.Iso3 = e.Iso3;
        		this.Addresses = e.Addresses.ToCollection();
        		
        	}
        
        	public StateProvince Clone(StateProvince e)
        	{
        		return new StateProvince(e);
        	}
        
        	public bool Equals(StateProvince other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(StateProvince other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.StateProvinceUid != this.StateProvinceUid )
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
    	public System.Guid StateProvinceUid { get; set; }
    	public System.Guid CountryUid { get; set; }
    	public string StateProvinceCode { get; set; }
    	public string StateProvinceName { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }

        public ICollection<Address> Addresses { get; set; }
    	public Country Country { get; set; }
    
    }
}
