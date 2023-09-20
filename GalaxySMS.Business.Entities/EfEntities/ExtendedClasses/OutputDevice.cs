using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
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
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.IsTemplate = e.IsTemplate;
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
    }
}