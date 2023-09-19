using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    public partial class RoleInputDevice
    {
        public RoleInputDevice()
        {
            Initialize();
        }

        public RoleInputDevice(RoleInputDevice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RoleInputDevicePermissions = new HashSet<RoleInputDevicePermission>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleInputDevice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleInputDeviceUid = e.RoleInputDeviceUid;
            this.RoleId = e.RoleId;
            this.InputDeviceUid = e.InputDeviceUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleInputDevicePermissions = e.RoleInputDevicePermissions.ToCollection();
            this.InputName = e.InputName;
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

        public RoleInputDevice Clone(RoleInputDevice e)
        {
            return new RoleInputDevice(e);
        }

        public bool Equals(RoleInputDevice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleInputDevice other)
        {
            if (other == null)
                return false;

            if (other.RoleInputDeviceUid != this.RoleInputDeviceUid)
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputName { get; set; }

    }
}
