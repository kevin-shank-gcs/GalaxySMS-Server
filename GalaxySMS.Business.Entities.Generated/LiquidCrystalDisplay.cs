//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    public partial class LiquidCrystalDisplay : EntityBase, IIdentifiableEntity, IEquatable<LiquidCrystalDisplay>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    using System.Runtime.Serialization;
    
    #if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
    #elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
    #else
    namespace GalaxySMS.Business.Entities
    #endif
    {
        public partial class LiquidCrystalDisplay
        {
        	public LiquidCrystalDisplay()
        	{
        		Initialize();
        	}
        
        	public LiquidCrystalDisplay(LiquidCrystalDisplay e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.LiquidCrystalDisplayGalaxyHardwareAddresses = new HashSet<LiquidCrystalDisplayGalaxyHardwareAddress>();
        		this.AccessPortalProperties = new HashSet<AccessPortalProperty>();
        	}
        
        	public void Initialize(LiquidCrystalDisplay e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.LiquidCrystalDisplayUid = e.LiquidCrystalDisplayUid;
        		this.SiteUid = e.SiteUid;
        		this.EntityId = e.EntityId;
        		this.LcdName = e.LcdName;
        		this.Location = e.Location;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.LiquidCrystalDisplayGalaxyHardwareAddresses = e.LiquidCrystalDisplayGalaxyHardwareAddresses.ToCollection();
        		this.AccessPortalProperties = e.AccessPortalProperties.ToCollection();
        		
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
        
        	public LiquidCrystalDisplay Clone(LiquidCrystalDisplay e)
        	{
        		return new LiquidCrystalDisplay(e);
        	}
        
        	public bool Equals(LiquidCrystalDisplay other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(LiquidCrystalDisplay other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.LiquidCrystalDisplayUid != this.LiquidCrystalDisplayUid )
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
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid LiquidCrystalDisplayUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid SiteUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid EntityId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string LcdName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Location { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string InsertName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> InsertDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string UpdateName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> UpdateDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<LiquidCrystalDisplayGalaxyHardwareAddress> LiquidCrystalDisplayGalaxyHardwareAddresses { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AccessPortalProperty> AccessPortalProperties { get; set; }
    
    }
}
