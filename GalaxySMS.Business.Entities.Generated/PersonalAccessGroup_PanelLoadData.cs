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
    public partial class PersonalAccessGroup_PanelLoadData : EntityBase, IIdentifiableEntity, IEquatable<PersonalAccessGroup_PanelLoadData>, ITableEntityBase
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
        public partial class PersonalAccessGroup_PanelLoadData
        {
        	public PersonalAccessGroup_PanelLoadData()
        	{
        		Initialize();
        	}
        
        	public PersonalAccessGroup_PanelLoadData(PersonalAccessGroup_PanelLoadData e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(PersonalAccessGroup_PanelLoadData e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PersonUid = e.PersonUid;
        		this.ClusterUid = e.ClusterUid;
        		this.GalaxyPanelUid = e.GalaxyPanelUid;
        		this.PersonalAccessGroupNumber = e.PersonalAccessGroupNumber;
        		this.ClusterNumber = e.ClusterNumber;
        		this.ClusterGroupId = e.ClusterGroupId;
        		this.PanelScheduleNumber = e.PanelScheduleNumber;
        		this.DoorNumber = e.DoorNumber;
        		this.PanelNumber = e.PanelNumber;
        		this.AccessGroupDisplay = e.AccessGroupDisplay;
        		this.TimeScheduleUid = e.TimeScheduleUid;
        		this.DefaultTimeScheduleUid = e.DefaultTimeScheduleUid;
        		
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
        
        	public PersonalAccessGroup_PanelLoadData Clone(PersonalAccessGroup_PanelLoadData e)
        	{
        		return new PersonalAccessGroup_PanelLoadData(e);
        	}
        
        	public bool Equals(PersonalAccessGroup_PanelLoadData other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonalAccessGroup_PanelLoadData other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonUid != this.PersonUid )
        			return false;
        	if(other.ClusterUid != this.ClusterUid )
        			return false;
        	if(other.GalaxyPanelUid != this.GalaxyPanelUid )
        			return false;
        	if(other.PersonalAccessGroupNumber != this.PersonalAccessGroupNumber )
        			return false;
        	if(other.ClusterNumber != this.ClusterNumber )
        			return false;
        	if(other.PanelScheduleNumber != this.PanelScheduleNumber )
        			return false;
        	if(other.DoorNumber != this.DoorNumber )
        			return false;
        	if(other.PanelNumber != this.PanelNumber )
        			return false;
        	if(other.AccessGroupDisplay != this.AccessGroupDisplay )
        			return false;
        	if(other.TimeScheduleUid != this.TimeScheduleUid )
        			return false;
        	if(other.DefaultTimeScheduleUid != this.DefaultTimeScheduleUid )
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
    	public System.Guid PersonUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid ClusterUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid GalaxyPanelUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int PersonalAccessGroupNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int ClusterNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string ClusterGroupId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int PanelScheduleNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short DoorNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int PanelNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string AccessGroupDisplay { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid TimeScheduleUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid DefaultTimeScheduleUid { get; set; }
    
    }
}
