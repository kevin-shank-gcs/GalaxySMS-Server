//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

#if NetCoreApi
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
        public partial class AccessPortalTypeBasic// : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid AccessPortalTypeUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid CredentialReaderTypeUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.Guid> BinaryResourceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string AccessPortalTypeDescription { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string Name { get { return AccessPortalTypeDescription; } set { AccessPortalTypeDescription = value; } }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public gcsBinaryResourceBasic gcsBinaryResource { get; set; }

    }
}
