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
    public partial class CountryBasic //: EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid CountryUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CountryIso { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CountryName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LongCountryName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Iso3 { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string NumberCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public bool UnitedNationsMemberState { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string CallingCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string CCTLD { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] FlagImage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<StateProvinceBasic> StateProvinces { get; set; }

    }
}
