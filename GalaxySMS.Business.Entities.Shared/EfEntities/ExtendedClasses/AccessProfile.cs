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
    public partial class AccessProfile
    {
        private int _personCount;

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
            this.ConcurrencyValue = 0;
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
            if (e.AccessProfileClusters != null)
                this.AccessProfileClusters = e.AccessProfileClusters.ToCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            this.TotalRowCount = e.TotalRowCount;
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

        public ListItemBase ToListItemBase()
        {
            return new ListItemBase()
            {
                Uid = AccessProfileUid,
                EntityId = EntityId,
                Name = this.AccessProfileName,
                KeyValue = AccessProfileUid.ToString(),
            };
        }

        public AccessProfileListItem ToAccessPortalListItem()
        {
            return new AccessProfileListItem()
            {
                AccessProfileUid = AccessProfileUid,
                EntityId = EntityId,
                Name = this.AccessProfileName,
                Counts = new AccessProfileCounts()
                { Persons = PersonCount }

            };
        }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public int TotalRowCount { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
        public int PersonCount
        {
            get => _personCount;
            set
            {
                _personCount = value;
                if (Counts == null)
                    Counts = new AccessProfileCounts();
                Counts.Persons = _personCount;
            }
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessProfileCounts Counts { get; set; }

    }
}
