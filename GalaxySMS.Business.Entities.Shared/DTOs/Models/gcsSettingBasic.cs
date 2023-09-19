using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

#if NetCoreApi
//using System.Text.Json.Serialization;
//using GCS.Core.Common.NetCore.Api;
namespace GalaxySMS.Business.Entities.Api.NetCore

#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class gcsSettingBasic : EntityBaseSimple
    {

#if NetCoreApi
        //[LowerCase]
#else
        [DataMember]
#endif
        public System.Guid SettingId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SettingGroup { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SettingSubGroup { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SettingKey { get; set; }

#if NetCoreApi
//        [JsonConverter(typeof(StringGuidLowerCaseConverter))]
#else
        [DataMember]
#endif
        public string Value { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string InsertName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.DateTimeOffset InsertDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string UpdateName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<short> ConcurrencyValue { get; set; }

    }
}
