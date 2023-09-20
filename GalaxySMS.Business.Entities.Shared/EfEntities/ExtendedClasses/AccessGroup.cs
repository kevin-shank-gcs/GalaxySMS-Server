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
            this.ActivationDate = null;
            this.ExpirationDate = null;
            this.AccessPortals = new HashSet<AccessGroupAccessPortal>();
            this.ConcurrencyValue = 0;
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
            this.TotalRowCount = e.TotalRowCount;

            this.ClusterName = e.ClusterName;
            this.CrisisModeAccessGroupName = e.CrisisModeAccessGroupName;
            this.CrisisModeAccessGroupNumber = e.CrisisModeAccessGroupNumber;
            this.DefaultTimeScheduleUid = e.DefaultTimeScheduleUid;
            this.DefaultTimeScheduleName = e.DefaultTimeScheduleName;
        }

        public static AccessGroup Clone(AccessGroup e)
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CrisisModeAccessGroupName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int CrisisModeAccessGroupNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DefaultTimeScheduleName { get; set; }

    }
}