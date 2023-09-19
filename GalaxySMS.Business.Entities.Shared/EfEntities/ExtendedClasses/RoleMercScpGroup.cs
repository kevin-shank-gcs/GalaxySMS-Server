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
    public partial class RoleMercScpGroup
    {
        public RoleMercScpGroup()
        {
            Initialize();
        }

        public RoleMercScpGroup(RoleMercScpGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RoleMercScpGroupPermissions = new HashSet<RoleMercScpGroupPermission>();
        }

        public void Initialize(RoleMercScpGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleMercScpGroupUid = e.RoleMercScpGroupUid;
            this.MercScpGroupUid = e.MercScpGroupUid;
            this.RoleId = e.RoleId;
            this.IncludeAllAccessPortals = e.IncludeAllAccessPortals;
            this.IncludeAllInputOutputGroups = e.IncludeAllInputOutputGroups;
            this.IncludeAllInputDevices = e.IncludeAllInputDevices;
            this.IncludeAllOutputDevices = e.IncludeAllOutputDevices;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleMercScpGroupPermissions = e.RoleMercScpGroupPermissions.ToCollection();

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

        public RoleMercScpGroup Clone(RoleMercScpGroup e)
        {
            return new RoleMercScpGroup(e);
        }

        public bool Equals(RoleMercScpGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleMercScpGroup other)
        {
            if (other == null)
                return false;

            if (other.RoleMercScpGroupUid != this.RoleMercScpGroupUid)
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
