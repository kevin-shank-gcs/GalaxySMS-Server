using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class MercScpGroupResp
    {
        public System.Guid MercScpGroupUid { get; set; }
        public System.Guid EntityId { get; set; }
        public System.Guid SiteUid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int NumberOfTransactions { get; set; }
        public short NumberOfOperatingModes { get; set; }
        public short OperatingModeType { get; set; }
        public bool AllowConnection { get; set; }
        public string InsertName { get; set; }
        public System.DateTimeOffset InsertDate { get; set; }
        public string UpdateName { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public gcsEntity gcsEntity { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<MercScp> MercScps { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Site Site { get; set; }public ICollection<Guid> EntityIds { get; set; }public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }public ICollection<Guid> RoleIds { get; set; }public MercScpGroupCounts Counts { get; set; }public ICollection<Guid> DisabledCommandIds { get; set; }
    }
}
