using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    /// <summary>
    /// This class contains properties for each data value that makes up a DateType_PanelLoadDataPDSA.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

    public partial class DateType_PanelLoadData : ObjectBase
    {
        #region Public Variables
        public Guid DateTypeUid { get; set; }
        public DateTimeOffset Date_x { get; set; }
        public string DayTypeName { get; set; }
        public short PanelDayTypeNumber { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public Guid ClusterUid { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public string ClusterName { get; set; }
        public short ScheduleTypeCode { get; set; }
        public string ScheduleTypeDisplay { get; set; }
        #endregion
    }
}
