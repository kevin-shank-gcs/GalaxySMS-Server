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
    public partial class RoleOutputDevice
    {
        public RoleOutputDevice()
        {
            Initialize();
        }

        public RoleOutputDevice(RoleOutputDevice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RoleOutputDevicePermissions = new HashSet<RoleOutputDevicePermission>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleOutputDevice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleOutputDeviceUid = e.RoleOutputDeviceUid;
            this.RoleId = e.RoleId;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleOutputDevicePermissions = e.RoleOutputDevicePermissions.ToCollection();
            this.OutputName = e.OutputName;

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

        public RoleOutputDevice Clone(RoleOutputDevice e)
        {
            return new RoleOutputDevice(e);
        }

        public bool Equals(RoleOutputDevice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleOutputDevice other)
        {
            if (other == null)
                return false;

            if (other.RoleOutputDeviceUid != this.RoleOutputDeviceUid)
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
        public string OutputName { get; set; }

    }
}
