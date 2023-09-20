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
	public partial class CredentialToLoadToCpu
    {
        public CredentialToLoadToCpu()
        {
            Initialize();
        }

        public CredentialToLoadToCpu(CredentialToLoadToCpu e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(CredentialToLoadToCpu e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialToLoadToCpuUid = e.CredentialToLoadToCpuUid;
            this.CpuUid = e.CpuUid;
            this.CredentialUid = e.CredentialUid;
            this.LastCredentialChangeDate = e.LastCredentialChangeDate;
            this.LastPersonalAccessGroupChangeDate = e.LastPersonalAccessGroupChangeDate;
            this.LastCredentialLoadedDate = e.LastCredentialLoadedDate;
            this.LastPersonalAccessGroupLoadedDate = e.LastPersonalAccessGroupLoadedDate;
            this.LastForceLoadDate = e.LastForceLoadDate;
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

        public CredentialToLoadToCpu Clone(CredentialToLoadToCpu e)
        {
            return new CredentialToLoadToCpu(e);
        }

        public bool Equals(CredentialToLoadToCpu other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialToLoadToCpu other)
        {
            if (other == null)
                return false;

            if (other.CredentialToLoadToCpuUid != this.CredentialToLoadToCpuUid)
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
