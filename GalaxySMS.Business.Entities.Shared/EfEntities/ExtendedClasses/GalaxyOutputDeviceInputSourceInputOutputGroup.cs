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
    public partial class GalaxyOutputDeviceInputSourceInputOutputGroup
    {
        public GalaxyOutputDeviceInputSourceInputOutputGroup()
        {
            Initialize();
        }

        public GalaxyOutputDeviceInputSourceInputOutputGroup(GalaxyOutputDeviceInputSourceInputOutputGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyOutputDeviceInputSourceInputOutputGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyOutputDeviceInputSourceInputOutputGroupUid = e.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
            this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
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

        public GalaxyOutputDeviceInputSourceInputOutputGroup Clone(GalaxyOutputDeviceInputSourceInputOutputGroup e)
        {
            return new GalaxyOutputDeviceInputSourceInputOutputGroup(e);
        }

        public bool Equals(GalaxyOutputDeviceInputSourceInputOutputGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputDeviceInputSourceInputOutputGroup other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputDeviceInputSourceInputOutputGroupUid != this.GalaxyOutputDeviceInputSourceInputOutputGroupUid)
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
