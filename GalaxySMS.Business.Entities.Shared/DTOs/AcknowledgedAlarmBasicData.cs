using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
    //#else
    //    [DataContract]
    //#endif

    //    public partial class AcknowledgedAlarmBasicData
    ////#if NetCoreApi
    ////#else
    ////        : ObjectBase
    ////#endif
    //    {
    //        #region Public Properties
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid ActivityEventUid { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid DeviceEntityId { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid DeviceUid { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid AccessPortalAlarmEventAcknowledgmentUid { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid GalaxyPanelAlarmEventAcknowledgmentUid { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid InputDeviceAlarmEventAcknowledgmentUid { get; set; }

    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid AlarmEventAcknowledgmentUid
    //        {
    //            get
    //            {
    //                if (AccessPortalAlarmEventAcknowledgmentUid != Guid.Empty)
    //                    return AccessPortalAlarmEventAcknowledgmentUid;
    //                if (GalaxyPanelAlarmEventAcknowledgmentUid != Guid.Empty)
    //                    return GalaxyPanelAlarmEventAcknowledgmentUid;
    //                if (InputDeviceAlarmEventAcknowledgmentUid != Guid.Empty)
    //                    return InputDeviceAlarmEventAcknowledgmentUid;
    //                return Guid.Empty;
    //            }

    //            set
    //            {

    //            }
    //        }


    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif

    //        public PanelActivityEventCategory ActivityEventCategory
    //        {
    //            get
    //            {
    //                if (AccessPortalAlarmEventAcknowledgmentUid != Guid.Empty)
    //                    return PanelActivityEventCategory.Door;
    //                if (GalaxyPanelAlarmEventAcknowledgmentUid != Guid.Empty)
    //                    return PanelActivityEventCategory.Panel;
    //                if (InputDeviceAlarmEventAcknowledgmentUid != Guid.Empty)
    //                    return PanelActivityEventCategory.Input;
    //                return PanelActivityEventCategory.Unknown;
    //            }

    //            set
    //            {

    //            }
    //        }


    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public string Response { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public Guid AckedByUserId { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public string AckedByUserDisplayName { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public DateTimeOffset AckedDateTime { get; set; }
    //#if NetCoreApi
    //#else
    //        [DataMember]
    //#endif
    //        public DateTimeOffset AckedUpdatedDateTime { get; set; }
    //        #endregion

    //    }
#else
    [DataContract]
#endif

    public partial class AcknowledgedAlarmBasicData
    //#if NetCoreApi
    //#else
    //        : ObjectBase
    //#endif
    {
        #region Public Properties
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ActivityEventUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceEntityId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid AccessPortalAlarmEventAcknowledgmentUid { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid GalaxyPanelAlarmEventAcknowledgmentUid { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid InputDeviceAlarmEventAcknowledgmentUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AlarmEventAcknowledgmentUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelActivityEventCategory ActivityEventCategory { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string Response { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AckedByUserId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string AckedByUserDisplayName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset AckedDateTime { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset AckedUpdatedDateTime { get; set; }
        #endregion

    }
}
