using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InputDevice
    {
        public InputDevice()
        {
            Initialize();
        }

        public InputDevice(InputDevice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(InputDevice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceUid = e.InputDeviceUid;
            this.EntityId = e.EntityId;
            this.SiteUid = e.SiteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.InputName = e.InputName;
            this.Location = e.Location;
            this.ServiceComment = e.ServiceComment;
            this.CriticalityComment = e.CriticalityComment;
            this.Comment = e.Comment;
            this.EMailEventsEnabled = e.EMailEventsEnabled;
            this.TransmitEventsEnabled = e.TransmitEventsEnabled;
            this.FileOutputEnabled = e.FileOutputEnabled;
            this.IsTemplate = e.IsTemplate;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyHardwareAddress = e.GalaxyHardwareAddress;
             this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            this.RegionName = e.RegionName;
            this.SiteName = e.SiteName;

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
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

        public InputDevice Clone(InputDevice e)
        {
            return new InputDevice(e);
        }

        public bool Equals(InputDevice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDevice other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceUid != this.InputDeviceUid)
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