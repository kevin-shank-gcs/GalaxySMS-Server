using System;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    /// <summary>
    /// This class contains properties for each data value that makes up a GalaxyTimePeriod_PanelLoadDataPDSA.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

    public partial class GalaxyTimePeriod_GetPanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid GalaxyTimePeriodUid { get; set; }
        public string TimePeriodName { get; set; }
        public int PanelTimePeriodNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public Guid ClusterUid { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public string ClusterName { get; set; }
        //public short ScheduleTypeCode { get; set; }
        public Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }
        public string ScheduleTypeDisplay { get; set; }
        #endregion
    }
}
