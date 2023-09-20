using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyTimePeriodEntityMap
    {
        public GalaxyTimePeriodEntityMap()
        {
            Initialize();
        }

        public GalaxyTimePeriodEntityMap(GalaxyTimePeriodEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyTimePeriodEntityMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyTimePeriodEntityMapUid = e.GalaxyTimePeriodEntityMapUid;
            this.EntityId = e.EntityId;
            this.GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
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

        public GalaxyTimePeriodEntityMap Clone(GalaxyTimePeriodEntityMap e)
        {
            return new GalaxyTimePeriodEntityMap(e);
        }

        public bool Equals(GalaxyTimePeriodEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyTimePeriodEntityMap other)
        {
            if (other == null)
                return false;

            if (other.GalaxyTimePeriodEntityMapUid != this.GalaxyTimePeriodEntityMapUid)
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
