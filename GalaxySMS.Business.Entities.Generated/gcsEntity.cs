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
    public partial class gcsEntity : EntityBase, IIdentifiableEntity, IEquatable<gcsEntity>, ITableEntityBase
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
        public partial class gcsEntity
        {
        	public gcsEntity()
        	{
        		Initialize();
        	}
        
        	public gcsEntity(gcsEntity e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.gcsUserEntities = new HashSet<gcsUserEntity>();
        		this.gcsEntityApplications = new HashSet<gcsEntityApplication>();
        		this.Regions = new HashSet<Region>();
        		this.AccessPortalEntityMaps = new HashSet<AccessPortalEntityMap>();
        		this.RegionEntityMaps = new HashSet<RegionEntityMap>();
        		this.SiteEntityMaps = new HashSet<SiteEntityMap>();
        		this.TimeSchedules = new HashSet<TimeSchedule>();
        		this.TimeScheduleEntityMaps = new HashSet<TimeScheduleEntityMap>();
        		this.AssaDsrEntityMaps = new HashSet<AssaDsrEntityMap>();
        		this.AssaDayPeriods = new HashSet<AssaDayPeriod>();
        		this.AssaDayPeriodEntityMaps = new HashSet<AssaDayPeriodEntityMap>();
        		this.DateTypeEntityMaps = new HashSet<DateTypeEntityMap>();
        		this.DayTypes = new HashSet<DayType>();
        		this.DayTypeEntityMaps = new HashSet<DayTypeEntityMap>();
        		this.TimePeriods = new HashSet<TimePeriod>();
        		this.TimePeriodEntityMaps = new HashSet<TimePeriodEntityMap>();
        		this.AccessGroupEntityMaps = new HashSet<AccessGroupEntityMap>();
        		this.AreaEntityMaps = new HashSet<AreaEntityMap>();
        		this.InputOutputGroupEntityMaps = new HashSet<InputOutputGroupEntityMap>();
        		this.ClusterEntityMaps = new HashSet<ClusterEntityMap>();
        		this.AccessGroups = new HashSet<AccessGroup>();
        		this.Areas = new HashSet<Area>();
        		this.InputOutputGroups = new HashSet<InputOutputGroup>();
        		this.InputDeviceEntityMaps = new HashSet<InputDeviceEntityMap>();
        		this.OutputDeviceEntityMaps = new HashSet<OutputDeviceEntityMap>();
        		this.LiquidCrystalDisplayEntityMaps = new HashSet<LiquidCrystalDisplayEntityMap>();
        		this.GalaxyTimePeriods = new HashSet<GalaxyTimePeriod>();
        		this.GalaxyTimePeriodEntityMaps = new HashSet<GalaxyTimePeriodEntityMap>();
        		this.DateTypeDefaultBehaviors = new HashSet<DateTypeDefaultBehavior>();
        		this.BadgeTemplates = new HashSet<BadgeTemplate>();
        		this.BadgeTemplateEntityMaps = new HashSet<BadgeTemplateEntityMap>();
        		this.Departments = new HashSet<Department>();
        		this.UserDefinedPropertyEntityMaps = new HashSet<UserDefinedPropertyEntityMap>();
        		this.Genders = new HashSet<Gender>();
        		this.PersonRecordTypes = new HashSet<PersonRecordType>();
        		this.PersonActiveStatusTypes = new HashSet<PersonActiveStatusType>();
        		this.UserDefinedProperties = new HashSet<UserDefinedProperty>();
        		this.AccessProfiles = new HashSet<AccessProfile>();
        		this.AccessProfileEntityMaps = new HashSet<AccessProfileEntityMap>();
        		this.CommandScripts = new HashSet<CommandScript>();
        		this.CredentialFormatEntities = new HashSet<CredentialFormatEntity>();
        		this.People = new HashSet<Person>();
        		this.CredentialFormatEntityMaps = new HashSet<CredentialFormatEntityMap>();
        		this.PersonEntityMaps = new HashSet<PersonEntityMap>();
        		this.gcsSettings = new HashSet<gcsSetting>();
        		this.AcknowledgeAlarmPredefinedResponses = new HashSet<AcknowledgeAlarmPredefinedResponse>();
        		this.gcsLargeObjectStorages = new HashSet<gcsLargeObjectStorage>();
        		this.gcsEntityCounts = new HashSet<gcsEntityCount>();
        		this.MercScpGroups = new HashSet<MercScpGroup>();
        	}
        
        	public void Initialize(gcsEntity e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.EntityId = e.EntityId;
        		this.ImageBinaryResourceUid = e.ImageBinaryResourceUid;
        		this.EntityName = e.EntityName;
        		this.EntityDescription = e.EntityDescription;
        		this.EntityKey = e.EntityKey;
        		this.IsDefault = e.IsDefault;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.License = e.License;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.ParentEntityId = e.ParentEntityId;
        		this.PublicKey = e.PublicKey;
        		this.EntityType = e.EntityType;
        		this.AutoMapTimeSchedules = e.AutoMapTimeSchedules;
        		this.ClusterGroupId = e.ClusterGroupId;
        		this.TimeZoneId = e.TimeZoneId;
        		this.gcsUserEntities = e.gcsUserEntities.ToCollection();
        		this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
        		this.Regions = e.Regions.ToCollection();
        		this.AccessPortalEntityMaps = e.AccessPortalEntityMaps.ToCollection();
        		this.RegionEntityMaps = e.RegionEntityMaps.ToCollection();
        		this.SiteEntityMaps = e.SiteEntityMaps.ToCollection();
        		this.TimeSchedules = e.TimeSchedules.ToCollection();
        		this.TimeScheduleEntityMaps = e.TimeScheduleEntityMaps.ToCollection();
        		this.AssaDsrEntityMaps = e.AssaDsrEntityMaps.ToCollection();
        		this.AssaDayPeriods = e.AssaDayPeriods.ToCollection();
        		this.AssaDayPeriodEntityMaps = e.AssaDayPeriodEntityMaps.ToCollection();
        		this.DateTypeEntityMaps = e.DateTypeEntityMaps.ToCollection();
        		this.DayTypes = e.DayTypes.ToCollection();
        		this.DayTypeEntityMaps = e.DayTypeEntityMaps.ToCollection();
        		this.TimePeriods = e.TimePeriods.ToCollection();
        		this.TimePeriodEntityMaps = e.TimePeriodEntityMaps.ToCollection();
        		this.AccessGroupEntityMaps = e.AccessGroupEntityMaps.ToCollection();
        		this.AreaEntityMaps = e.AreaEntityMaps.ToCollection();
        		this.InputOutputGroupEntityMaps = e.InputOutputGroupEntityMaps.ToCollection();
        		this.ClusterEntityMaps = e.ClusterEntityMaps.ToCollection();
        		this.AccessGroups = e.AccessGroups.ToCollection();
        		this.Areas = e.Areas.ToCollection();
        		this.InputOutputGroups = e.InputOutputGroups.ToCollection();
        		this.InputDeviceEntityMaps = e.InputDeviceEntityMaps.ToCollection();
        		this.OutputDeviceEntityMaps = e.OutputDeviceEntityMaps.ToCollection();
        		this.LiquidCrystalDisplayEntityMaps = e.LiquidCrystalDisplayEntityMaps.ToCollection();
        		this.GalaxyTimePeriods = e.GalaxyTimePeriods.ToCollection();
        		this.GalaxyTimePeriodEntityMaps = e.GalaxyTimePeriodEntityMaps.ToCollection();
        		this.DateTypeDefaultBehaviors = e.DateTypeDefaultBehaviors.ToCollection();
        		this.BadgeTemplates = e.BadgeTemplates.ToCollection();
        		this.BadgeTemplateEntityMaps = e.BadgeTemplateEntityMaps.ToCollection();
        		this.Departments = e.Departments.ToCollection();
        		this.UserDefinedPropertyEntityMaps = e.UserDefinedPropertyEntityMaps.ToCollection();
        		this.Genders = e.Genders.ToCollection();
        		this.PersonRecordTypes = e.PersonRecordTypes.ToCollection();
        		this.PersonActiveStatusTypes = e.PersonActiveStatusTypes.ToCollection();
        		this.UserDefinedProperties = e.UserDefinedProperties.ToCollection();
        		this.AccessProfiles = e.AccessProfiles.ToCollection();
        		this.AccessProfileEntityMaps = e.AccessProfileEntityMaps.ToCollection();
        		this.CommandScripts = e.CommandScripts.ToCollection();
        		this.CredentialFormatEntities = e.CredentialFormatEntities.ToCollection();
        		this.People = e.People.ToCollection();
        		this.CredentialFormatEntityMaps = e.CredentialFormatEntityMaps.ToCollection();
        		this.PersonEntityMaps = e.PersonEntityMaps.ToCollection();
        		this.gcsSettings = e.gcsSettings.ToCollection();
        		this.AcknowledgeAlarmPredefinedResponses = e.AcknowledgeAlarmPredefinedResponses.ToCollection();
        		this.gcsLargeObjectStorages = e.gcsLargeObjectStorages.ToCollection();
        		this.gcsEntityCounts = e.gcsEntityCounts.ToCollection();
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
        
        	public gcsEntity Clone(gcsEntity e)
        	{
        		return new gcsEntity(e);
        	}
        
        	public bool Equals(gcsEntity other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsEntity other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.EntityId != this.EntityId )
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
    	public System.Guid EntityId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> ImageBinaryResourceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string EntityName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string EntityDescription { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string EntityKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsDefault { get; set; }
    
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
    	public string License { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> BinaryResourceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> ParentEntityId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string PublicKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string EntityType { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool AutoMapTimeSchedules { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int ClusterGroupId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string TimeZoneId { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsUserEntity> gcsUserEntities { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsEntityApplication> gcsEntityApplications { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public gcsBinaryResource gcsBinaryResource { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<Region> Regions { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public gcsBinaryResource gcsBinaryResource1 { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AccessPortalEntityMap> AccessPortalEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<RegionEntityMap> RegionEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<SiteEntityMap> SiteEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<TimeSchedule> TimeSchedules { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<TimeScheduleEntityMap> TimeScheduleEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AssaDsrEntityMap> AssaDsrEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AssaDayPeriod> AssaDayPeriods { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AssaDayPeriodEntityMap> AssaDayPeriodEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<DateTypeEntityMap> DateTypeEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<DayType> DayTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<DayTypeEntityMap> DayTypeEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<TimePeriod> TimePeriods { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<TimePeriodEntityMap> TimePeriodEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AccessGroupEntityMap> AccessGroupEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AreaEntityMap> AreaEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<InputOutputGroupEntityMap> InputOutputGroupEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<ClusterEntityMap> ClusterEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AccessGroup> AccessGroups { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<Area> Areas { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<InputOutputGroup> InputOutputGroups { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<InputDeviceEntityMap> InputDeviceEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<OutputDeviceEntityMap> OutputDeviceEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<LiquidCrystalDisplayEntityMap> LiquidCrystalDisplayEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyTimePeriod> GalaxyTimePeriods { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<GalaxyTimePeriodEntityMap> GalaxyTimePeriodEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<DateTypeDefaultBehavior> DateTypeDefaultBehaviors { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<BadgeTemplate> BadgeTemplates { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<BadgeTemplateEntityMap> BadgeTemplateEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<Department> Departments { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<UserDefinedPropertyEntityMap> UserDefinedPropertyEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<Gender> Genders { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonRecordType> PersonRecordTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonActiveStatusType> PersonActiveStatusTypes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<UserDefinedProperty> UserDefinedProperties { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AccessProfile> AccessProfiles { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AccessProfileEntityMap> AccessProfileEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CommandScript> CommandScripts { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CredentialFormatEntity> CredentialFormatEntities { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<Person> People { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CredentialFormatEntityMap> CredentialFormatEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonEntityMap> PersonEntityMaps { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsSetting> gcsSettings { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<AcknowledgeAlarmPredefinedResponse> AcknowledgeAlarmPredefinedResponses { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsLargeObjectStorage> gcsLargeObjectStorages { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsEntityCount> gcsEntityCounts { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<MercScpGroup> MercScpGroups { get; set; }
    
    }
}
