using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessGroup
    {
        public AccessGroup()
        {
            Initialize();
        }

        public AccessGroup(AccessGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.ActivationDate = DateTimeOffset.Now.MinSqlDateTime();
            this.ExpirationDate = DateTimeOffset.Now.MaxSqlDateTime();
            this.AccessPortals = new HashSet<AccessGroupAccessPortal>();
        }

        public void Initialize(AccessGroup e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessGroupUid = e.AccessGroupUid;
            this.ClusterUid = e.ClusterUid;
            this.EntityId = e.EntityId;
            this.AccessGroupNumber = e.AccessGroupNumber;
            this.Display = e.Display;
            this.Description = e.Description;
            this.ServiceComment = e.ServiceComment;
            this.Comment = e.Comment;
            this.IsEnabled = e.IsEnabled;
            this.ActivationDate = e.ActivationDate;
            this.ExpirationDate = e.ExpirationDate;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.CrisisModeAccessGroupUid = e.CrisisModeAccessGroupUid;

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.AccessPortals != null)
                this.AccessPortals = e.AccessPortals.ToCollection();
        }

        public AccessGroup Clone(AccessGroup e)
        {
            return new AccessGroup(e);
        }

        public bool Equals(AccessGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroup other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupUid != this.AccessGroupUid)
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