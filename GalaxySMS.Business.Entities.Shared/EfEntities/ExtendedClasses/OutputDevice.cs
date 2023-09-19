using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class OutputDevice
    {
        public OutputDevice()
        {
            Initialize();
        }

        public OutputDevice(OutputDevice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

            this.GalaxyOutputDevice = new GalaxyOutputDevice();

            Notes = new HashSet<Note>();
            Commands = new HashSet<OutputCommand>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(OutputDevice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.EntityId = e.EntityId;
            this.SiteUid = e.SiteUid;
            this.OutputName = e.OutputName;
            this.Location = e.Location;
            this.ServiceComment = e.ServiceComment;
            this.CriticalityComment = e.CriticalityComment;
            this.Comment = e.Comment;
            this.EMailEventsEnabled = e.EMailEventsEnabled;
            this.TransmitEventsEnabled = e.TransmitEventsEnabled;
            this.FileOutputEnabled = e.FileOutputEnabled;
            //this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.IsTemplate = e.IsTemplate;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);

            this.GalaxyOutputDevice = e.GalaxyOutputDevice;
            this.RegionName = e.RegionName;
            this.SiteName = e.SiteName;

            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.ClusterTypeUid = e.ClusterTypeUid;
            this.ClusterTypeCode = e.ClusterTypeCode;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.GalaxyPanelTypeCode = e.GalaxyPanelTypeCode;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.InterfaceBoardTypeCode = e.InterfaceBoardTypeCode;
            this.InterfaceBoardModel = e.InterfaceBoardModel;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InterfaceBoardSectionModeCode = e.InterfaceBoardSectionModeCode;
            this.GalaxyHardwareModuleTypeUid = e.GalaxyHardwareModuleTypeUid;
            this.ModuleTypeCode = e.ModuleTypeCode;
            this.IsNodeActive = e.IsNodeActive;


            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.Notes != null)
                this.Notes = e.Notes.ToCollection();
            this.TotalRowCount = e.TotalRowCount;
            this.IsBoundToHardware = e.IsBoundToHardware;
            ;
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

        public OutputDevice Clone(OutputDevice e)
        {
            return new OutputDevice(e);
        }

        public bool Equals(OutputDevice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(OutputDevice other)
        {
            if (other == null)
                return false;

            if (other.OutputDeviceUid != this.OutputDeviceUid)
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


        public ListItemBase ToListItemBase()
        {
            return new ListItemBase()
            {
                Uid = OutputDeviceUid,
                EntityId = EntityId,
                Name = this.OutputName,
                KeyValue = OutputDeviceUid.ToString(),
                Image = gcsBinaryResource?.BinaryResource
            };
        }


        public OutputDeviceListItemCommands ToOutputDeviceListItemCommands()
        {
            var o = new OutputDeviceListItemCommands()
            {
                Uid = OutputDeviceUid,
                EntityId = EntityId,
                Name = this.OutputName,
                KeyValue = OutputDeviceUid.ToString(),
                Image = gcsBinaryResource?.BinaryResource,
                IsNodeActive = this.IsNodeActive,
                
                //Commands = this.Commands.ToList()
            };
            foreach (var c in Commands)
            {
                o.Commands.Add(new OutputCommandBasic(c));
            }
            return o;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }
    }
}
