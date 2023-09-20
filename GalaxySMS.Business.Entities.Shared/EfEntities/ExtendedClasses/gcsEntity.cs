//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GalaxySMS.Business.Entities
//{
//    public partial class gcsEntity
//    {
//        public gcsUserRequirement UserRequirements { get; set; }
//    }
//}
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;
using System.Collections.Generic;
using System.Linq;
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
            //this.gcsUserEntities = new HashSet<gcsUserEntity>();
            //this.gcsEntityApplications = new HashSet<gcsEntityApplication>();
            this.AllRoles = new HashSet<gcsRole>();
            this.UserRequirements = new gcsUserRequirement();
            this.gcsBinaryResource = new gcsBinaryResource();
            this.ChildEntities = new HashSet<gcsEntity>();
            this.Settings = new HashSet<gcsSetting>();
            this.Regions = new HashSet<RegionListItem>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsEntity e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityId = e.EntityId;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.ParentEntityId = e.ParentEntityId;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.EntityType = e.EntityType;
            this.AutoMapTimeSchedules = e.AutoMapTimeSchedules;
            this.ClusterGroupId = e.ClusterGroupId;
            this.TimeZoneId = e.TimeZoneId;
            this.License = e.License;
            this.PublicKey = e.PublicKey;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.gcsUserEntities = e.gcsUserEntities.ToCollection();
            //this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
            this.UserRequirements = e.UserRequirements;
            if (e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.ParentEntity != null)
                this.ParentEntity = new gcsEntity(e.ParentEntity);
            if (e.ChildEntities != null)
                this.ChildEntities = e.ChildEntities.ToCollection();
            if (e.Settings != null)
                this.Settings = e.Settings.ToCollection();
            //if (e.AllApplications != null)
            //    this.AllApplications = e.AllApplications.ToCollection();
            if (e.Regions != null)
                this.Regions = e.Regions.ToCollection();
            if (e.AllRoles != null)
                this.AllRoles = e.AllRoles.ToCollection();

            this.TotalRowCount = e.TotalRowCount;
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
            if (other == null)
                return false;

            if (other.EntityId != this.EntityId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.EntityName;
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public gcsUserRequirement UserRequirements { get; set; }


        // Custom properties   
        public enum DataCollectionsMode { ForEntity, ForUser }

        //private ICollection<gcsApplication> _allApplications = new HashSet<gcsApplication>();

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAuthorized { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public DataCollectionsMode CollectionsMode { get; set; }


//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<gcsApplication> AllApplications
//        {
//            get { return _allApplications; }
//            set { _allApplications = value; }
//        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<RegionListItem> Regions { get; set; }


        public bool AccessProfileControlsAG1
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup1);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup1);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup1
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }

        public bool AccessProfileControlsAG2
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup2);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup2);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup2
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }

        public bool AccessProfileControlsAG3
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup3);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup3);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup3
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }

        public bool AccessProfileControlsAG4
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup4);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup4);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup4
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }

        public bool AccessProfileControlsIO1
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup1);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup1);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup1
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }

        public bool AccessProfileControlsIO2
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup2);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup2);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup2
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }

        public bool AccessProfileControlsIO3
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup3);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup3);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup3
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }

        public bool AccessProfileControlsIO4
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup4);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup4);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup4
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
            }
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }

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



    }
}