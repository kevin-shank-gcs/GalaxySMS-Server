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
	public partial class AssaDsr
    {
        public AssaDsr()
        {
            Initialize();
        }

        public AssaDsr(AssaDsr e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AssaDsrTimeScheduleMaps = new HashSet<AssaDsrTimeScheduleMap>();
            this.AssaAccessPoints = new HashSet<AssaAccessPoint>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AssaDsr e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaDsrUid = e.AssaDsrUid;
            this.EntityId = e.EntityId;
            this.Name = e.Name;
            this.CallbackUrl = e.CallbackUrl;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.ServerIpAddress = e.ServerIpAddress;
            this.ServerPort = e.ServerPort;
            this.UseHttps = e.UseHttps;
            this.AssaDsrTimeScheduleMaps = e.AssaDsrTimeScheduleMaps.ToCollection();
            this.AssaAccessPoints = e.AssaAccessPoints.ToCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

        }

        public AssaDsr Clone(AssaDsr e)
        {
            return new AssaDsr(e);
        }

        public bool Equals(AssaDsr other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaDsr other)
        {
            if (other == null)
                return false;

            if (other.AssaDsrUid != this.AssaDsrUid)
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