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
    public partial class GalaxyInputArmingInputOutputGroup : EntityBase, IIdentifiableEntity, IEquatable<GalaxyInputArmingInputOutputGroup>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class GalaxyInputArmingInputOutputGroup
        {
        	public GalaxyInputArmingInputOutputGroup()
        	{
        		Initialize();
        	}
        
        	public GalaxyInputArmingInputOutputGroup(GalaxyInputArmingInputOutputGroup e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(GalaxyInputArmingInputOutputGroup e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.GalaxyInputArmingInputOutputGroupUid = e.GalaxyInputArmingInputOutputGroupUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.OrderNumber = e.OrderNumber;
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
        
        	public GalaxyInputArmingInputOutputGroup Clone(GalaxyInputArmingInputOutputGroup e)
        	{
        		return new GalaxyInputArmingInputOutputGroup(e);
        	}
        
        	public bool Equals(GalaxyInputArmingInputOutputGroup other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyInputArmingInputOutputGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyInputArmingInputOutputGroupUid != this.GalaxyInputArmingInputOutputGroupUid )
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
    	public System.Guid GalaxyInputArmingInputOutputGroupUid { get; set; }
    	public System.Guid InputDeviceUid { get; set; }
    	public System.Guid InputOutputGroupUid { get; set; }
    	public short OrderNumber { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public InputOutputGroup InputOutputGroup { get; set; }
    
    }
}
