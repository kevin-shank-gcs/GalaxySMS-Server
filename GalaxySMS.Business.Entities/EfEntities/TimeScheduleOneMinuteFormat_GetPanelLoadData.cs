using System;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    /// <summary>
    /// This class contains properties for each data value returned, or parameter to be input/output from the TimeScheduleOneMinuteFormat_GetPanelLoadDataPDSA stored procedure.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

    public partial class TimeScheduleOneMinuteFormat_GetPanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid TimeScheduleUid { get; set; }
        public string ScheduleName { get; set; }
        public string DayTypeName { get; set; }
        public DayTypeCode DayTypeCode { get; set; }
        public int PanelScheduleNumber { get; set; }
        public int PanelTimePeriodNumber { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public Guid ClusterUid { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public string ClusterName { get; set; }
        public Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }
        public string ScheduleTypeDisplay { get; set; }
        public int RETURNVALUE { get; set; }
        #endregion
    }
}
