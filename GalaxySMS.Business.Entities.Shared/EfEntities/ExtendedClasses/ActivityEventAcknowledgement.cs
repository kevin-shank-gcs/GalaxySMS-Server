using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

using System.Runtime.Serialization;

#if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class ActivityEventAcknowledgement
    {
        public ActivityEventAcknowledgement()
        {
            Initialize();
        }

        public ActivityEventAcknowledgement(ActivityEventAcknowledgement e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(ActivityEventAcknowledgement e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.ActivityEventAcknowledgementUid = e.ActivityEventAcknowledgementUid;
            this.ActivityEventUid = e.ActivityEventUid;
            this.DeviceEntityId = e.DeviceEntityId;
            this.DeviceUid = e.DeviceUid;
            this.ActivityEventCategory = e.ActivityEventCategory;
            this.Response = e.Response;
            this.AckedByUserId = e.AckedByUserId;
            this.AckedByUserDisplayName = e.AckedByUserDisplayName;
            this.AckedDateTime = e.AckedDateTime;
            this.AckedUpdatedDateTime = e.AckedUpdatedDateTime;

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

        public ActivityEventAcknowledgement Clone(ActivityEventAcknowledgement e)
        {
            return new ActivityEventAcknowledgement(e);
        }

        public bool Equals(ActivityEventAcknowledgement other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ActivityEventAcknowledgement other)
        {
            if (other == null)
                return false;

            if (other.ActivityEventAcknowledgementUid != this.ActivityEventAcknowledgementUid)
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
