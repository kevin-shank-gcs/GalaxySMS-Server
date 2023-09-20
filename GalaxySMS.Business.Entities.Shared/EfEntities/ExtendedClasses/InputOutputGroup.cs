using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class InputOutputGroup
    {
        public InputOutputGroup()
        {
            Initialize();
        }

        public InputOutputGroup(InputOutputGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.InputOutputGroupAssignments = new HashSet<InputOutputGroupAssignment>();
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            Commands = new HashSet<InputOutputGroupCommand>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputOutputGroup e)
        {
            Initialize();
            if (e == null)
                return;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.ClusterUid = e.ClusterUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.EntityId = e.EntityId;
            this.IOGroupNumber = e.IOGroupNumber;
            this.Display = e.Display;
            this.LocalIOGroup = e.LocalIOGroup;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Description = e.Description;
            if (e.InputOutputGroupAssignments != null)
                this.InputOutputGroupAssignments = e.InputOutputGroupAssignments.ToCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.Commands != null)
                this.Commands = e.Commands.ToCollection();
            this.TotalRowCount = e.TotalRowCount;
        }

        public InputOutputGroup Clone(InputOutputGroup e)
        {
            return new InputOutputGroup(e);
        }

        public bool Equals(InputOutputGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputOutputGroup other)
        {
            if (other == null)
                return false;

            if (other.InputOutputGroupUid != this.InputOutputGroupUid)
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
    }
}
