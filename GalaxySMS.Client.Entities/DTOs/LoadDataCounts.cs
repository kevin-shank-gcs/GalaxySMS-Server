using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class LoadDataCounts
    {
        #region Public Properties
        [DataMember]
        public int AccessPortalsInputsOutputsCount { get; set; }

        [DataMember]
        public int AllCardDataCount { get; set; }

        [DataMember]
        public int InterfaceBoardSectionCount { get; set; }

        [DataMember]
        public int AccessPortalCount { get; set; }

        [DataMember]
        public int InputDeviceCount { get; set; }

        [DataMember]
        public int OutputDeviceCount { get; set; }

        [DataMember]
        public int InputOutputGroupCount { get; set; }

        [DataMember]
        public int CredentialCount { get; set; }

        [DataMember]
        public int PersonalAccessGroupCount { get; set; }

        [DataMember]
        public int AccessRulesCount { get; set; }

        [DataMember] 
        public int AccessPortalAccessRulesCount { get; set; }

        [DataMember]
        public int DayTypeCount { get; set; }

        [DataMember]
        public int TimePeriodCount { get; set; }

        [DataMember]
        public int TimePeriodDayTypeMapCount { get; set; }

        [DataMember]
        public int TimeSchedulesCount { get; set; }
        #endregion
    }

    public class LoadDataToPanelNotificationCounts
    {
        #region Public Properties
        [DataMember]
        public int ClusterSharedSettingsCount { get; set; }

        [DataMember]
        public int TimeSchedulesCount { get; set; }

        [DataMember]
        public int AllCardDataCount { get; set; }

        [DataMember]
        public int InputOutputGroupCount { get; set; }

        [DataMember]
        public int AccessPortalsInputsOutputsCount { get; set; }

        [DataMember]
        public int AccessRulesCount { get; set; }

        [DataMember]
        public int PanelAlarmsCount { get; set; }
        #endregion
    }

}
