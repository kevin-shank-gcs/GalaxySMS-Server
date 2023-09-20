using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

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

    public class TimeScheduleUsageCounts
    {
        #region Public Properties

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid TimeScheduleUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TimeScheduleName { get; set; }
        /// <summary>
        /// Get/Set the Access Group Default Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessGroupDefaultTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Access Group Access Portal Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessGroupAccessPortalCount { get; set; }

        /// <summary>
        /// Get/Set the Access Portal Alert Event Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalAlertEventCount { get; set; }

        /// <summary>
        /// Get/Set the Access Portal Aux Output Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalAuxOutputCount { get; set; }

        /// <summary>
        /// Get/Set the Access Portal Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Input Device Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputDeviceTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Output Device Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int OutputDeviceTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Galaxy Panel Alert Event Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int GalaxyPanelAlertEventTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Input Device Event Properties Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputDeviceEventPropertiesTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Input Output Group Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputOutputGroupTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Person Personal Access Group Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PersonPersonalAccessGroupTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Assa Dsr Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AssaDsrTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Otis Floor Group Time Schedule Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int OtisFloorGroupTimeScheduleCount { get; set; }

        /// <summary>
        /// Get/Set the Total Count value
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalCount { get; set; }

        #endregion
    }
}
