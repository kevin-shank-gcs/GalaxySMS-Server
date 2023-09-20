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
	public partial class InputDeviceSupervisionTypeInterfaceBoardSectionMode
    {
        public InputDeviceSupervisionTypeInterfaceBoardSectionMode()
        {
            Initialize();
        }

        public InputDeviceSupervisionTypeInterfaceBoardSectionMode(InputDeviceSupervisionTypeInterfaceBoardSectionMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputDeviceSupervisionTypeInterfaceBoardSectionMode e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid =
                e.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
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

        public InputDeviceSupervisionTypeInterfaceBoardSectionMode Clone(
            InputDeviceSupervisionTypeInterfaceBoardSectionMode e)
        {
            return new InputDeviceSupervisionTypeInterfaceBoardSectionMode(e);
        }

        public bool Equals(InputDeviceSupervisionTypeInterfaceBoardSectionMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceSupervisionTypeInterfaceBoardSectionMode other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid !=
                this.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid)
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