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
    public partial class AccessPortalCommandAudit
    {
        public AccessPortalCommandAudit()
        {
            Initialize();
        }

        public AccessPortalCommandAudit(AccessPortalCommandAudit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalCommandAudit e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalCommandAuditUid = e.AccessPortalCommandAuditUid;
            this.UserId = e.UserId;
            this.AccessPortalCommandUid = e.AccessPortalCommandUid;
            this.AccessPortalUid = e.AccessPortalUid;
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

        public AccessPortalCommandAudit Clone(AccessPortalCommandAudit e)
        {
            return new AccessPortalCommandAudit(e);
        }

        public bool Equals(AccessPortalCommandAudit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalCommandAudit other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalCommandAuditUid != this.AccessPortalCommandAuditUid)
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
