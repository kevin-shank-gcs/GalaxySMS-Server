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
    public partial class AccessPortalElevatorControlTypePanelModel : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalElevatorControlTypePanelModel>, ITableEntityBase
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
        public partial class AccessPortalElevatorControlTypePanelModel
        {
        	public AccessPortalElevatorControlTypePanelModel()
        	{
        		Initialize();
        	}
        
        	public AccessPortalElevatorControlTypePanelModel(AccessPortalElevatorControlTypePanelModel e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AccessPortalElevatorControlTypePanelModel e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.AccessPortalElevatorControlTypePanelModelUid = e.AccessPortalElevatorControlTypePanelModelUid;
        		this.AccessPortalElevatorControlTypeUid = e.AccessPortalElevatorControlTypeUid;
        		this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
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
        
        	public AccessPortalElevatorControlTypePanelModel Clone(AccessPortalElevatorControlTypePanelModel e)
        	{
        		return new AccessPortalElevatorControlTypePanelModel(e);
        	}
        
        	public bool Equals(AccessPortalElevatorControlTypePanelModel other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalElevatorControlTypePanelModel other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalElevatorControlTypePanelModelUid != this.AccessPortalElevatorControlTypePanelModelUid )
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
    	public System.Guid AccessPortalElevatorControlTypePanelModelUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AccessPortalElevatorControlTypeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid GalaxyPanelModelUid { get; set; }
    
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
    	public AccessPortalElevatorControlType AccessPortalElevatorControlType { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public GalaxyPanelModel GalaxyPanelModel { get; set; }
    
    }
}
