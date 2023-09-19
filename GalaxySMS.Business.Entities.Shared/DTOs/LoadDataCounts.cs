using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
    public class LoadDataCounts
    {
        #region Public Properties
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalsInputsOutputsCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AllCardDataCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int InterfaceBoardSectionCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputDeviceCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int OutputDeviceCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputOutputGroupCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int CredentialCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int PersonalAccessGroupCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessRulesCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif 
        public int AccessPortalAccessRulesCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int DayTypeCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int TimePeriodCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int TimePeriodDayTypeMapCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int TimeSchedulesCount { get; set; }
        #endregion
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class LoadDataToPanelNotificationCounts
    {
        #region Public Properties
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterSharedSettingsCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TimeSchedulesCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AllCardDataCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputOutputGroupCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalsInputsOutputsCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessRulesCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelAlarmsCount { get; set; }
        #endregion
    }

}
