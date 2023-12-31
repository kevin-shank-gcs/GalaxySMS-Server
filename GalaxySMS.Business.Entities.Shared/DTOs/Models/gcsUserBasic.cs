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
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

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

    public partial class gcsUserBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid UserId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTime> UserActivationDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTime> UserExpirationDate { get; set; }



#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] UserImage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public IEnumerable<gcsUserEntityMinimal> Entities { get; set; } = new HashSet<gcsUserEntityMinimal>();

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset InsertDate { get; set; }
    }
}