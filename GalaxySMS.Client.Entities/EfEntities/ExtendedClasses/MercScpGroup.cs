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
    public partial class MercScpGroup
    {
        public MercScpGroup() : base()
        {
            Initialize();
        }

        public MercScpGroup(MercScpGroup e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            //           this.MercScps = new HashSet<MercScp>();
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(MercScpGroup e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.MercScpGroupUid = e.MercScpGroupUid;
            this.EntityId = e.EntityId;
            this.SiteUid = e.SiteUid;
            this.Name = e.Name;
            this.Description = e.Description;
            this.IsActive = e.IsActive;
            this.NumberOfTransactions = e.NumberOfTransactions;
            this.NumberOfOperatingModes = e.NumberOfOperatingModes;
            this.OperatingModeType = e.OperatingModeType;
            this.AllowConnection = e.AllowConnection;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

        }

        public MercScpGroup Clone(MercScpGroup e)
        {
            return new MercScpGroup(e);
        }

        public bool Equals(MercScpGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(MercScpGroup other)
        {
            if (other == null)
                return false;

            if (other.MercScpGroupUid != this.MercScpGroupUid)
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
