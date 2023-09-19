using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class RoleMercScpGroup
    {
        public RoleMercScpGroup() : base()
        {
            Initialize();
        }

        public RoleMercScpGroup(RoleMercScpGroup e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.RoleMercScpGroupPermissions = new HashSet<RoleMercScpGroupPermission>();
        }

        public void Initialize(RoleMercScpGroup e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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
