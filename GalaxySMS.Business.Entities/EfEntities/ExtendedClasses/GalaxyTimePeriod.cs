using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyTimePeriod
    {
        public GalaxyTimePeriod()
        {
            Initialize();
        }

        public GalaxyTimePeriod(GalaxyTimePeriod e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            TimePeriods = new HashSet<TimePeriod>();
        }

        public void Initialize(GalaxyTimePeriod e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.EntityId = e.EntityId;
            this.Display = e.Display;
            this.Description = e.Description;
            this.PanelTimePeriodNumber = e.PanelTimePeriodNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.TimePeriods != null)
                this.TimePeriods = e.TimePeriods.ToCollection();

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

        public GalaxyTimePeriod Clone(GalaxyTimePeriod e)
        {
            return new GalaxyTimePeriod(e);
        }

        public bool Equals(GalaxyTimePeriod other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyTimePeriod other)
        {
            if (other == null)
                return false;

            if (other.GalaxyTimePeriodUid != this.GalaxyTimePeriodUid)
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
