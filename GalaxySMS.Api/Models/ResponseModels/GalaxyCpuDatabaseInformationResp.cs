using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class GalaxyCpuDatabaseInformationResp
    {
        public GalaxyCpuDatabaseInformationResp()
        {
            
        }
        public GalaxyCpuDatabaseInformationResp(GalaxyCpuDatabaseInformationResp cpuDatabaseInformation)
        {
        }
        #region Public Properties    
        public Guid ClusterUid { get; set; }
        public Guid GalaxyPanelUid { get; set; }
        public Guid CpuUid { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public int PanelNumber { get; set; }
        public short CpuNumber { get; set; }
        public string SerialNumber { get; set; }
        public string IpAddress { get; set; }
        public bool DefaultEventLoggingOn { get; set; }
        public bool PreventDataLoading { get; set; }
        public bool PreventFlashLoading { get; set; }
        public int LastLogIndex { get; set; }
        public string ClusterName { get; set; }
        public string PanelName { get; set; }
        public string ClusterTypeCode { get; set; }
        public bool ClusterTypeIsActive { get; set; }
        public short CredentialDataLength { get; set; }
        public string PanelLocation { get; set; }
        public string PanelModelTypeCode { get; set; }
        public bool PanelModelIsActive { get; set; }
        public bool CpuIsActive { get; set; }
        public Guid SiteUid { get; set; }
        public string SiteName { get; set; }
        public Guid EntityId { get; set; }
        public string EntityName { get; set; }

        public string TimeZoneId { get; set; }
        //public List<GalaxyPanel_GetAlertEventAcknowledgeDataResp> AlertEventAcknowledgeData { get; set; }

        //public GalaxyPanel_GetAlertEventAcknowledgeDataResp GetAlertEventAcknowledgeData(PanelActivityEventCode eventType)
        //{
        //    switch (eventType)
        //    {
        //        case PanelActivityEventCode.CpuTamperAlarm:
        //            return AlertEventAcknowledgeData?.FirstOrDefault(o => o.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper);

        //        case PanelActivityEventCode.CpuLowBatteryAlarm:
        //            return AlertEventAcknowledgeData?.FirstOrDefault(o => o.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery);

        //        case PanelActivityEventCode.CpuAcFailureAlarm:
        //            return AlertEventAcknowledgeData?.FirstOrDefault(o => o.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure);

        //        case PanelActivityEventCode.EmergencyUnlockActive:
        //            return AlertEventAcknowledgeData?.FirstOrDefault(o => o.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock);

        //    }

        //    return null;
        //}

        #endregion
    }
}
