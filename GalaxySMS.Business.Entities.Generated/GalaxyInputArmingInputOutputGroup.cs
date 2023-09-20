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
    public partial class GalaxyInputArmingInputOutputGroup : EntityBase, IIdentifiableEntity, IEquatable<GalaxyInputArmingInputOutputGroup>, ITableEntityBase
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
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid GalaxyInputArmingInputOutputGroupUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid InputDeviceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid InputOutputGroupUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short OrderNumber { get; set; }
    
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
    	public InputOutputGroup InputOutputGroup { get; set; }
    
    }
}
