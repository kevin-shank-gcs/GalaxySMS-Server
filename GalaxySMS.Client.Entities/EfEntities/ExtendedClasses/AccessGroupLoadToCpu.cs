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
    public partial class AccessGroupLoadToCpu
    {
        public AccessGroupLoadToCpu() : base()
        {
            Initialize();
        }

        public AccessGroupLoadToCpu(AccessGroupLoadToCpu e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(AccessGroupLoadToCpu e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessGroupLoadToCpuUid = e.AccessGroupLoadToCpuUid;
            this.AccessGroupUid = e.AccessGroupUid;
            this.CpuUid = e.CpuUid;
            this.LastLoadedDate = e.LastLoadedDate;
            this.LastForceLoadDate = e.LastForceLoadDate;

        }

        public AccessGroupLoadToCpu Clone(AccessGroupLoadToCpu e)
        {
            return new AccessGroupLoadToCpu(e);
        }

        public bool Equals(AccessGroupLoadToCpu other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroupLoadToCpu other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupLoadToCpuUid != this.AccessGroupLoadToCpuUid)
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
