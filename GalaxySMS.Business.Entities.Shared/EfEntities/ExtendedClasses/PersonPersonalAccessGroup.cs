using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class PersonPersonalAccessGroup
    {
        public PersonPersonalAccessGroup()
        {
            Initialize();
        }

        public PersonPersonalAccessGroup(PersonPersonalAccessGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.AccessPortalUids = new HashSet<Guid>();
            //this.DynamicAccessGroupUids = new HashSet<Guid>();
            this.AccessPortals = new HashSet<AccessPortalUidItem>();
            this.DynamicAccessGroups = new HashSet<AccessGroupUidItem>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonPersonalAccessGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.ClusterUid = e.ClusterUid;
            this.PersonalAccessGroupNumber = e.PersonalAccessGroupNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //if (e.AccessPortalUids != null)
            //    AccessPortalUids = e.AccessPortalUids.ToCollection();
            //if (e.DynamicAccessGroupUids != null)
            //    DynamicAccessGroupUids = e.DynamicAccessGroupUids.ToCollection();
            if (e.AccessPortals != null)
                AccessPortals = e.AccessPortals.ToCollection();
            if (e.DynamicAccessGroups != null)
                DynamicAccessGroups = e.DynamicAccessGroups.ToCollection();

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

        public PersonPersonalAccessGroup Clone(PersonPersonalAccessGroup e)
        {
            return new PersonPersonalAccessGroup(e);
        }

        public bool Equals(PersonPersonalAccessGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonPersonalAccessGroup other)
        {
            if (other == null)
                return false;

            if (other.PersonClusterPermissionUid != this.PersonClusterPermissionUid)
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
