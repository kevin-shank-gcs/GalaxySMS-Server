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
    public partial class InputDeviceGalaxyHardwareAddress : EntityBase, IIdentifiableEntity, IEquatable<InputDeviceGalaxyHardwareAddress>, ITableEntityBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid InputDeviceGalaxyHardwareAddressUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid InputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid GalaxyInterfaceBoardSectionNodeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public GalaxyInterfaceBoardSectionNode GalaxyInterfaceBoardSectionNode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public InputDevice InputDevice { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif

        public bool IsNodeActive { get; set; }
    }
}
