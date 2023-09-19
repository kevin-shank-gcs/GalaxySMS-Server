using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class AccessGroupAccessPortalLoadToCpu
    {
        public AccessGroupAccessPortalLoadToCpu() : base()
        {
            Initialize();
        }

        public AccessGroupAccessPortalLoadToCpu(AccessGroupAccessPortalLoadToCpu e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(AccessGroupAccessPortalLoadToCpu e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessGroupAccessPortalLoadToCpuUid = e.AccessGroupAccessPortalLoadToCpuUid;
            this.AccessGroupAccessPortalUid = e.AccessGroupAccessPortalUid;
            this.CpuUid = e.CpuUid;
            this.LastLoadedDate = e.LastLoadedDate;
            this.LastForceLoadDate = e.LastForceLoadDate;

        }

        public AccessGroupAccessPortalLoadToCpu Clone(AccessGroupAccessPortalLoadToCpu e)
        {
            return new AccessGroupAccessPortalLoadToCpu(e);
        }

        public bool Equals(AccessGroupAccessPortalLoadToCpu other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroupAccessPortalLoadToCpu other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupAccessPortalLoadToCpuUid != this.AccessGroupAccessPortalLoadToCpuUid)
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
