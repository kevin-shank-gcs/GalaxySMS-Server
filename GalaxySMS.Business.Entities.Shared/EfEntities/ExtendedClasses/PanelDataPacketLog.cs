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
	public partial class PanelDataPacketLog
    {
        public PanelDataPacketLog()
        {
            Initialize();
        }

        public PanelDataPacketLog(PanelDataPacketLog e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PanelDataPacketLog e)
        {
            Initialize();
            if (e == null)
                return;
            this.Id = e.Id;
            this.InsertDate = e.InsertDate;
            this.UpdateDate = e.UpdateDate;
            this.Length = e.Length;
            this.Distribute = e.Distribute;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterId = e.ClusterId;
            this.PanelId = e.PanelId;
            this.CpuId = e.CpuId;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.SecondsFromWeekStart = e.SecondsFromWeekStart;
            this.Sequence = e.Sequence;
            this.RawData = e.RawData;
            this.Direction = e.Direction;

        }

        public PanelDataPacketLog Clone(PanelDataPacketLog e)
        {
            return new PanelDataPacketLog(e);
        }

        public bool Equals(PanelDataPacketLog other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PanelDataPacketLog other)
        {
            if (other == null)
                return false;

            if (other.Id != this.Id)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
