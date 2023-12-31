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
    public partial class gcsResourceString : EntityBase, IIdentifiableEntity, IEquatable<gcsResourceString>, ITableEntityBase
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
        public partial class gcsResourceString
        {
        	public gcsResourceString()
        	{
        		Initialize();
        	}
        
        	public gcsResourceString(gcsResourceString e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.gcsApplicationAuditTypes = new HashSet<gcsApplicationAuditType>();
        		this.InterfaceBoardSectionModes = new HashSet<InterfaceBoardSectionMode>();
        		this.InterfaceBoardTypes = new HashSet<InterfaceBoardType>();
        		this.CredentialDataLengths = new HashSet<CredentialDataLength>();
        		this.TimeScheduleTypes = new HashSet<TimeScheduleType>();
        		this.GalaxyInputDelayTypes = new HashSet<GalaxyInputDelayType>();
        		this.GalaxyInputModes = new HashSet<GalaxyInputMode>();
        		this.InputDeviceSupervisionTypes = new HashSet<InputDeviceSupervisionType>();
        		this.CredentialFormats = new HashSet<CredentialFormat>();
        		this.PersonActivationModes = new HashSet<PersonActivationMode>();
        		this.PersonCredentialRoles = new HashSet<PersonCredentialRole>();
        		this.PersonExpirationModes = new HashSet<PersonExpirationMode>();
        		this.gcsPermissionTypes = new HashSet<gcsPermissionType>();
        		this.PropertySensitivityLevels = new HashSet<PropertySensitivityLevel>();
        		this.AccessPortalCommandChoices = new HashSet<AccessPortalCommandChoice>();
        	}
        
        	public void Initialize(gcsResourceString e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.ResourceId = e.ResourceId;
        		this.ResourceName = e.ResourceName;
        		this.ResourceNumber = e.ResourceNumber;
        		this.ResourceClassName = e.ResourceClassName;
        		this.DefaultValue = e.DefaultValue;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.gcsApplicationAuditTypes = e.gcsApplicationAuditTypes.ToCollection();
        		this.InterfaceBoardSectionModes = e.InterfaceBoardSectionModes.ToCollection();
        		this.InterfaceBoardTypes = e.InterfaceBoardTypes.ToCollection();
        		this.CredentialDataLengths = e.CredentialDataLengths.ToCollection();
        		this.TimeScheduleTypes = e.TimeScheduleTypes.ToCollection();
        		this.GalaxyInputDelayTypes = e.GalaxyInputDelayTypes.ToCollection();
        		this.GalaxyInputModes = e.GalaxyInputModes.ToCollection();
        		this.InputDeviceSupervisionTypes = e.InputDeviceSupervisionTypes.ToCollection();
        		this.CredentialFormats = e.CredentialFormats.ToCollection();
        		this.PersonActivationModes = e.PersonActivationModes.ToCollection();
        		this.PersonCredentialRoles = e.PersonCredentialRoles.ToCollection();
        		this.PersonExpirationModes = e.PersonExpirationModes.ToCollection();
        		this.gcsPermissionTypes = e.gcsPermissionTypes.ToCollection();
        		this.PropertySensitivityLevels = e.PropertySensitivityLevels.ToCollection();
        		this.AccessPortalCommandChoices = e.AccessPortalCommandChoices.ToCollection();
        		
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
        
        	public gcsResourceString Clone(gcsResourceString e)
        	{
        		return new gcsResourceString(e);
        	}
        
        	public bool Equals(gcsResourceString other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsResourceString other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ResourceId != this.ResourceId )
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
    	public System.Guid ResourceId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string ResourceName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<int> ResourceNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string ResourceClassName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string DefaultValue { get; set; }
    
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
    	public ICollection<gcsApplicationAuditType> gcsApplicationAuditTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<InterfaceBoardSectionMode> InterfaceBoardSectionModes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<InterfaceBoardType> InterfaceBoardTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CredentialDataLength> CredentialDataLengths { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<TimeScheduleType> TimeScheduleTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyInputDelayType> GalaxyInputDelayTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyInputMode> GalaxyInputModes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<InputDeviceSupervisionType> InputDeviceSupervisionTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CredentialFormat> CredentialFormats { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonActivationMode> PersonActivationModes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonCredentialRole> PersonCredentialRoles { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonExpirationMode> PersonExpirationModes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsPermissionType> gcsPermissionTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PropertySensitivityLevel> PropertySensitivityLevels { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AccessPortalCommandChoice> AccessPortalCommandChoices { get; set; }
    
    }
}
