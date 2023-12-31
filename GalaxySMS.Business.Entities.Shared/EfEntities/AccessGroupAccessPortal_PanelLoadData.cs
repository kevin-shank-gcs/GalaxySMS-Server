using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    /// <summary>
    /// This class contains properties for each data value that makes up a AccessGroupAccessPortal_PanelLoadDataPDSA.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class AccessGroupAccessPortal_PanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid AccessGroupAccessPortalUid { get; set; }
        public Guid AccessPortalUid { get; set; }
        public Guid? TimeScheduleUid { get; set; }
        public Guid AccessGroupUid { get; set; }
        public int AccessGroupNumber { get; set; }
        public int? PanelScheduleNumber { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsEnabled { get; set; }
        public string AccessGroupName { get; set; }
        public string TimeScheduleName { get; set; }
        public string AccessPortalName { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public int PanelNumber { get; set; }
        public short BoardNumber { get; set; }
        public short SectionNumber { get; set; }
        public short ModuleNumber { get; set; }
        public short NodeNumber { get; set; }
        public short AccessPortalBoardTypeTypeCode { get; set; }
        public string DefaultTimeScheduleName { get; set; }
        public int DefaultTimeScheduleNumber { get; set; }
        public DateTimeOffset CurrentTimeForCluster { get; set; }
        public bool IsNodeActive { get; set; }
        public int ScheduleNumber
        {
            get
            {
                if (!PanelScheduleNumber.HasValue)
                    return DefaultTimeScheduleNumber;
                return PanelScheduleNumber.Value;
            }
        }
        #endregion
    }
}
