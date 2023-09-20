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
    public partial class MercScpStatus
    {
        public MercScpStatus()
        {
            Initialize();
        }

        public MercScpStatus(MercScpStatus e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(MercScpStatus e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.MercScpUid = e.MercScpUid;
            this.Online = e.Online;
            this.LastConnected = e.LastConnected;
            this.LastDisconnected = e.LastDisconnected;

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

        public MercScpStatus Clone(MercScpStatus e)
        {
            return new MercScpStatus(e);
        }

        public bool Equals(MercScpStatus other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(MercScpStatus other)
        {
            if (other == null)
                return false;

            if (other.MercScpUid != this.MercScpUid)
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
