using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class LiquidCrystalDisplay
    {
        public LiquidCrystalDisplay()
        {
            Initialize();
        }

        public LiquidCrystalDisplay(LiquidCrystalDisplay e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(LiquidCrystalDisplay e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.LiquidCrystalDisplayUid = e.LiquidCrystalDisplayUid;
            this.SiteUid = e.SiteUid;
            this.EntityId = e.EntityId;
            this.LcdName = e.LcdName;
            this.Location = e.Location;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyHardwareAddress = e.GalaxyHardwareAddress;
            this.RegionUid = e.RegionUid;
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

        public LiquidCrystalDisplay Clone(LiquidCrystalDisplay e)
        {
            return new LiquidCrystalDisplay(e);
        }

        public bool Equals(LiquidCrystalDisplay other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(LiquidCrystalDisplay other)
        {
            if (other == null)
                return false;

            if (other.LiquidCrystalDisplayUid != this.LiquidCrystalDisplayUid)
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