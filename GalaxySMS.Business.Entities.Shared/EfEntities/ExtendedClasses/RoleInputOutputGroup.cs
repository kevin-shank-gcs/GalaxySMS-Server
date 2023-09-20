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
    public partial class RoleInputOutputGroup
    {
        public RoleInputOutputGroup()
        {
            Initialize();
        }

        public RoleInputOutputGroup(RoleInputOutputGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RoleInputOutputGroupPermissions = new HashSet<RoleInputOutputGroupPermission>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleInputOutputGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleInputOutputGroupUid = e.RoleInputOutputGroupUid;
            this.RoleId = e.RoleId;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleInputOutputGroupPermissions = e.RoleInputOutputGroupPermissions.ToCollection();
            this.InputOutputGroupName = e.InputOutputGroupName;

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

        public RoleInputOutputGroup Clone(RoleInputOutputGroup e)
        {
            return new RoleInputOutputGroup(e);
        }

        public bool Equals(RoleInputOutputGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleInputOutputGroup other)
        {
            if (other == null)
                return false;

            if (other.RoleInputOutputGroupUid != this.RoleInputOutputGroupUid)
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
        public string InputOutputGroupName { get; set; }

    }
}
