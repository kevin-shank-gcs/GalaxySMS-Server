
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyCpuLoggingControl
    {
        public GalaxyCpuLoggingControl()
        {
            Initialize();
        }

        public GalaxyCpuLoggingControl(GalaxyCpuLoggingControl e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyCpuLoggingControl e)
        {
            Initialize();
            if (e == null)
                return;
            this.CpuUid = e.CpuUid;
            this.LastLogIndex = e.LastLogIndex;
            this.InsertDate = e.InsertDate;
            this.UpdateDate = e.UpdateDate;

        }

        public GalaxyCpuLoggingControl Clone(GalaxyCpuLoggingControl e)
        {
            return new GalaxyCpuLoggingControl(e);
        }

        public bool Equals(GalaxyCpuLoggingControl other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyCpuLoggingControl other)
        {
            if (other == null)
                return false;

            if (other.CpuUid != this.CpuUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
