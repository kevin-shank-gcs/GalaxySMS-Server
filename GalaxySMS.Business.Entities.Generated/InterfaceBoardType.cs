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
    public partial class InterfaceBoardType : EntityBase, IIdentifiableEntity, IEquatable<InterfaceBoardType>, ITableEntityBase
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
        public partial class InterfaceBoardType
        {
        	public InterfaceBoardType()
        	{
        		Initialize();
        	}
        
        	public InterfaceBoardType(InterfaceBoardType e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.GalaxyPanelModelInterfaceBoardTypes = new HashSet<GalaxyPanelModelInterfaceBoardType>();
        	}
        
        	public void Initialize(InterfaceBoardType e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
        		this.TypeCode = e.TypeCode;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.Model = e.Model;
        		this.NumberOfSections = e.NumberOfSections;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.GalaxyPanelModelInterfaceBoardTypes = e.GalaxyPanelModelInterfaceBoardTypes.ToCollection();
        		
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
        
        	public InterfaceBoardType Clone(InterfaceBoardType e)
        	{
        		return new InterfaceBoardType(e);
        	}
        
        	public bool Equals(InterfaceBoardType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InterfaceBoardType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InterfaceBoardTypeUid != this.InterfaceBoardTypeUid )
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
    	public System.Guid InterfaceBoardTypeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short TypeCode { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Description { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string DescriptionResourceKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Model { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short NumberOfSections { get; set; }
    
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
    	public Nullable<System.Guid> BinaryResourceUid { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public gcsResourceString gcsResourceString { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyPanelModelInterfaceBoardType> GalaxyPanelModelInterfaceBoardTypes { get; set; }
    
    }
}
