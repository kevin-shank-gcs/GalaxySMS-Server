using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessProfile
    {
        public AccessProfile()
        {
            Initialize();
        }

        public AccessProfile(AccessProfile e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AccessProfileClusters = new HashSet<AccessProfileCluster>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(AccessProfile e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessProfileUid = e.AccessProfileUid;
            this.EntityId = e.EntityId;
            this.AccessProfileName = e.AccessProfileName;
            this.Comments = e.Comments;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AccessProfileClusters = e.AccessProfileClusters.ToCollection();
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

        public AccessProfile Clone(AccessProfile e)
        {
            return new AccessProfile(e);
        }

        public bool Equals(AccessProfile other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessProfile other)
        {
            if (other == null)
                return false;

            if (other.AccessProfileUid != this.AccessProfileUid)
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
