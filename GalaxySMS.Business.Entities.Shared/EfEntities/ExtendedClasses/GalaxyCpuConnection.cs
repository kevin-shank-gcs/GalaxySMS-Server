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
	public partial class GalaxyCpuConnection
    {
        public GalaxyCpuConnection()
        {
            Initialize();
        }

        public GalaxyCpuConnection(GalaxyCpuConnection e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyCpuConnection e)
        {
            Initialize();
            if (e == null)
                return;
            this.CpuUid = e.CpuUid;
            this.IsConnected = e.IsConnected;
            this.ServerAddress = e.ServerAddress;
            this.LastConnectedTime = e.LastConnectedTime;
            this.LastDisconnectedTime = e.LastDisconnectedTime;
        }

        public GalaxyCpuConnection Clone(GalaxyCpuConnection e)
        {
            return new GalaxyCpuConnection(e);
        }

        public bool Equals(GalaxyCpuConnection other)
        {
            if (this.CpuUid != other.CpuUid )
                return false;
            return true;
            //return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyCpuConnection other)
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}