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
    public partial class GalaxyPanelCommand : EntityBase, IIdentifiableEntity, IEquatable<GalaxyPanelCommand>, ITableEntityBase
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
        public partial class GalaxyPanelCommand
        {
        	public GalaxyPanelCommand()
        	{
        		Initialize();
        	}
        
        	public GalaxyPanelCommand(GalaxyPanelCommand e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.GalaxyPanelModelGalaxyPanelCommands = new HashSet<GalaxyPanelModelGalaxyPanelCommand>();
        		this.GalaxyPanelCommandAudits = new HashSet<GalaxyPanelCommandAudit>();
        	}
        
        	public void Initialize(GalaxyPanelCommand e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.GalaxyPanelCommandUid = e.GalaxyPanelCommandUid;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.CommandCode = e.CommandCode;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.IsFlashingCommand = e.IsFlashingCommand;
        		this.GalaxyPanelModelGalaxyPanelCommands = e.GalaxyPanelModelGalaxyPanelCommands.ToCollection();
        		this.GalaxyPanelCommandAudits = e.GalaxyPanelCommandAudits.ToCollection();
        		
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
        
        	public GalaxyPanelCommand Clone(GalaxyPanelCommand e)
        	{
        		return new GalaxyPanelCommand(e);
        	}
        
        	public bool Equals(GalaxyPanelCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyPanelCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyPanelCommandUid != this.GalaxyPanelCommandUid )
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
    	public System.Guid GalaxyPanelCommandUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Display { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> DisplayResourceKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Description { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> DescriptionResourceKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short CommandCode { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsActive { get; set; }
    
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
    	public bool IsFlashingCommand { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyPanelModelGalaxyPanelCommand> GalaxyPanelModelGalaxyPanelCommands { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyPanelCommandAudit> GalaxyPanelCommandAudits { get; set; }
    
    }
}
