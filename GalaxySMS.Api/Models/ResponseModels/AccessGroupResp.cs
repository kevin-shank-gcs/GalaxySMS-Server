using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{

    public partial class AccessGroupResp
    {
        public System.Guid AccessGroupUid { get; set; }

        public System.Guid ClusterUid { get; set; }
        public System.Guid EntityId { get; set; }

        public int AccessGroupNumber { get; set; }

        public string Display { get; set; }

        public string Description { get; set; }

        public string ServiceComment { get; set; }
        public string Comment { get; set; }

        public bool IsEnabled { get; set; }

        public Nullable<System.DateTimeOffset> ActivationDate { get; set; }

        public Nullable<System.DateTimeOffset> ExpirationDate { get; set; }

        public string InsertName { get; set; }

        public System.DateTimeOffset InsertDate { get; set; }

        public string UpdateName { get; set; }

        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

        public Nullable<short> ConcurrencyValue { get; set; }

        //public Nullable<System.Guid> DisplayResourceKey { get; set; }
        //public Nullable<System.Guid> DescriptionResourceKey { get; set; }

        public Nullable<System.Guid> CrisisModeAccessGroupUid { get; set; }

        public ICollection<Guid> EntityIds { get; set; }

        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

        public ICollection<AccessGroupAccessPortalBasic> AccessPortals { get; set; }

        //private string _resourceClassName = string.Empty;

        //public string ResourceClassName
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_resourceClassName))
        //            _resourceClassName = this.GetType().Name;
        //        return _resourceClassName;
        //    }
        //    set { _resourceClassName = value; }
        //}

        //public string DisplayResourceName { get; set; } = string.Empty;

        //public string DescriptionResourceName { get; set; } = string.Empty;
        //public string UniqueResourceName { get; set; } = string.Empty;
    }
}


