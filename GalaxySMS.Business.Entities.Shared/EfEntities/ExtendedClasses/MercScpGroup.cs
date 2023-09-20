using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MercScpGroup
    {
        public MercScpGroup()
        {
            Initialize();
        }

        public MercScpGroup(MercScpGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(MercScpGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.MercScpGroupUid = e.MercScpGroupUid;
            this.EntityId = e.EntityId;
            this.SiteUid = e.SiteUid;
            this.Name = e.Name;
            this.Description = e.Description;
            IsActive = e.IsActive;
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }


        public MercScpGroupListItemCommands ToMercScpGroupListItemCommands()
        {
            var o = new MercScpGroupListItemCommands()
            {
                Uid = MercScpGroupUid,
                Name = this.Name,
                Description = this.Description,
                //ClusterNumber = this.ClusterNumber,
                //ClusterGroupId = this.ClusterGroupId,
                IsActive = this.IsActive,
#if NetCoreApi
#else
                //Image = gcsBinaryResource?.BinaryResource,
#endif
                Counts = this.Counts,
                DisabledCommandIds = this.DisabledCommandIds.ToList()
            };
            //foreach (var c in this.ClusterCommands)
            //{
            //    o.Commands.Add(new ClusterCommandBasic(c));
            //}
            //foreach (var c in this.ClusterFlashingCommands)
            //{
            //    o.FlashingCommands.Add(new ClusterCommandBasic(c));
            //}
            return o;
        }

    }
}
