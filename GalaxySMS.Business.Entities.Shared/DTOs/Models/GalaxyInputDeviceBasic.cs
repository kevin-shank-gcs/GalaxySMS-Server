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
    public partial class GalaxyInputDeviceBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid InputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid InputDeviceSupervisionTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid GalaxyInputModeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int DelayDuration { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid GalaxyInputDelayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DisableDisarmedOnOffLogEvents { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsNormalOpen { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short TroubleShortThreshold { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short NormalChangeThreshold { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short TroubleOpenThreshold { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AlternateVoltagesEnabled { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short AlternateTroubleShortThreshold { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short AlternateNormalChangeThreshold { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short AlternateTroubleOpenThreshold { get; set; }


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

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceAlertEventBasic> AlertEvents { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyInputDeviceTimeScheduleBasic TimeSchedule { get; set; }
        
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputDeviceGalaxyHardwareAddressBasic GalaxyHardwareAddress { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInputArmingInputOutputGroupBasic> ArmingInputOutputGroups { get; set; }

    }
}
