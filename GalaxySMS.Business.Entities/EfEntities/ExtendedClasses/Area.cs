using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Area
    {
        public Area()
        {
            Initialize();
        }

        public Area(Area e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(Area e)
        {
            Initialize();
            if (e == null)
                return;
            //return;
            this.AreaUid = e.AreaUid;
            this.ClusterUid = e.ClusterUid;
            this.EntityId = e.EntityId;
            this.AreaNumber = e.AreaNumber;
            this.Display = e.Display;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Description = e.Description;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
        }

        public Area Clone(Area e)
        {
            return new Area(e);
        }

        public bool Equals(Area other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Area other)
        {
            if (other == null)
                return false;

            if (other.AreaUid != this.AreaUid)
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