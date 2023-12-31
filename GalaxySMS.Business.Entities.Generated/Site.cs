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
    public partial class Site : EntityBase, IIdentifiableEntity, IEquatable<Site>, ITableEntityBase
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
        public partial class Site
        {
        	public Site()
        	{
        		Initialize();
        	}
        
        	public Site(Site e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.AssaAccessPoints = new HashSet<AssaAccessPoint>();
        		this.GalaxyPanelSites = new HashSet<GalaxyPanelSite>();
        		this.RoleSites = new HashSet<RoleSite>();
        		this.MercScpGroups = new HashSet<MercScpGroup>();
        	}
        
        	public void Initialize(Site e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.SiteUid = e.SiteUid;
        		this.RegionUid = e.RegionUid;
        		this.SiteName = e.SiteName;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.SiteId = e.SiteId;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.Longitude = e.Longitude;
        		this.Latitude = e.Latitude;
        		this.AddressUid = e.AddressUid;
        		this.EntityId = e.EntityId;
        		this.AssaAccessPoints = e.AssaAccessPoints.ToCollection();
        		this.GalaxyPanelSites = e.GalaxyPanelSites.ToCollection();
        		this.RoleSites = e.RoleSites.ToCollection();
        		this.MercScpGroups = e.MercScpGroups.ToCollection();
        		
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
        
        	public Site Clone(Site e)
        	{
        		return new Site(e);
        	}
        
        	public bool Equals(Site other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(Site other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.SiteUid != this.SiteUid )
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
    	public System.Guid SiteUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid RegionUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string SiteName { get; set; }
    
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
    	public string SiteId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> BinaryResourceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<double> Longitude { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<double> Latitude { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> AddressUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid EntityId { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public gcsBinaryResource gcsBinaryResource { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Address Address { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AssaAccessPoint> AssaAccessPoints { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyPanelSite> GalaxyPanelSites { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<RoleSite> RoleSites { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<MercScpGroup> MercScpGroups { get; set; }
    
    }
}
