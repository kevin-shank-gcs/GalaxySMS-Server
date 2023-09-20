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
    public partial class GalaxyInterfaceBoardSectionCommand : EntityBase, IIdentifiableEntity, IEquatable<GalaxyInterfaceBoardSectionCommand>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class GalaxyInterfaceBoardSectionCommand
        {
        	public GalaxyInterfaceBoardSectionCommand()
        	{
        		Initialize();
        	}
        
        	public GalaxyInterfaceBoardSectionCommand(GalaxyInterfaceBoardSectionCommand e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.GalaxyInterfaceBoardSectionCommandAudits = new HashSet<GalaxyInterfaceBoardSectionCommandAudit>();
        		this.GalaxyInterfaceBoardSectionModeCommands = new HashSet<GalaxyInterfaceBoardSectionModeCommand>();
        	}
        
        	public void Initialize(GalaxyInterfaceBoardSectionCommand e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.GalaxyInterfaceBoardSectionCommandUid = e.GalaxyInterfaceBoardSectionCommandUid;
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
        		this.GalaxyInterfaceBoardSectionCommandAudits = e.GalaxyInterfaceBoardSectionCommandAudits.ToCollection();
        		this.GalaxyInterfaceBoardSectionModeCommands = e.GalaxyInterfaceBoardSectionModeCommands.ToCollection();
        		
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
        
        	public GalaxyInterfaceBoardSectionCommand Clone(GalaxyInterfaceBoardSectionCommand e)
        	{
        		return new GalaxyInterfaceBoardSectionCommand(e);
        	}
        
        	public bool Equals(GalaxyInterfaceBoardSectionCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSectionCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyInterfaceBoardSectionCommandUid != this.GalaxyInterfaceBoardSectionCommandUid )
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
    	public System.Guid GalaxyInterfaceBoardSectionCommandUid { get; set; }
    	public string Display { get; set; }
    	public Nullable<System.Guid> DisplayResourceKey { get; set; }
    	public string Description { get; set; }
    	public Nullable<System.Guid> DescriptionResourceKey { get; set; }
    	public short CommandCode { get; set; }
    	public bool IsActive { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public ICollection<GalaxyInterfaceBoardSectionCommandAudit> GalaxyInterfaceBoardSectionCommandAudits { get; set; }
    	public ICollection<GalaxyInterfaceBoardSectionModeCommand> GalaxyInterfaceBoardSectionModeCommands { get; set; }
    
    }
}
