////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\GalaxyPanel_GetAlertEventAcknowledgeData.cs
//
// summary:	Implements the galaxy panel get alert event acknowledge data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
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
    public partial class GalaxyPanel_GetAlertEventAcknowledgeData
    {
        #region Public Properties

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelAlertEventTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Tag { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CanHaveAudio { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CanHaveInstructions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CanHaveSchedule { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AcknowledgeTimeScheduleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AcknowledgePriority { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResponseRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ResponseInstructions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UserInstructionsNoteUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AudioBinaryResourceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxySMS.Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }

        #endregion
    }

}
