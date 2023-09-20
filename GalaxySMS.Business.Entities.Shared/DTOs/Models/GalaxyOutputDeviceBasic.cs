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
    public partial class GalaxyOutputDeviceBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
    	public System.Guid OutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
    	public System.Guid TimeScheduleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
    	public System.Guid GalaxyOutputModeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
    	public System.Guid GalaxyOutputInputSourceRelationshipUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
    	public int TimeoutDuration { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
    	public int Limit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
    	public bool InvertOutput { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//    	public string InsertName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//    	public System.DateTimeOffset InsertDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//    	public string UpdateName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//    	public Nullable<short> ConcurrencyValue { get; set; }
    

#if NetCoreApi
#else
        [DataMember]
#endif
    	public ICollection<GalaxyOutputDeviceInputSourceBasic> GalaxyOutputDeviceInputSources { get; set; }
    
#if NetCoreApi
#else
        [DataMember]
#endif
        public OutputDeviceGalaxyHardwareAddressBasic GalaxyHardwareAddress { get; set; }

    }
}
