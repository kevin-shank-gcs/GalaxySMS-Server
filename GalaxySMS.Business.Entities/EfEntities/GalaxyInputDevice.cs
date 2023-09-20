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
    public partial class GalaxyInputDevice : EntityBase, IIdentifiableEntity, IEquatable<GalaxyInputDevice>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class GalaxyInputDevice
        {
        	public GalaxyInputDevice()
        	{
        		Initialize();
        	}
        
        	public GalaxyInputDevice(GalaxyInputDevice e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(GalaxyInputDevice e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
        		this.GalaxyInputModeUid = e.GalaxyInputModeUid;
        		this.DelayDuration = e.DelayDuration;
        		this.GalaxyInputDelayTypeUid = e.GalaxyInputDelayTypeUid;
        		this.DisableDisarmedOnOffLogEvents = e.DisableDisarmedOnOffLogEvents;
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
        
        	public GalaxyInputDevice Clone(GalaxyInputDevice e)
        	{
        		return new GalaxyInputDevice(e);
        	}
        
        	public bool Equals(GalaxyInputDevice other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyInputDevice other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputDeviceUid != this.InputDeviceUid )
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
    	public System.Guid InputDeviceUid { get; set; }
    	public System.Guid InputDeviceSupervisionTypeUid { get; set; }
    	public System.Guid GalaxyInputModeUid { get; set; }
    	public int DelayDuration { get; set; }
    	public System.Guid GalaxyInputDelayTypeUid { get; set; }
    	public bool DisableDisarmedOnOffLogEvents { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public InputDevice InputDevice { get; set; }
    	public InputDeviceSupervisionType InputDeviceSupervisionType { get; set; }
    
    }
}
