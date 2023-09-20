using System.Collections.Generic;
using System.Linq;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyCpuDatabaseInformation
    {
        public GalaxyCpuDatabaseInformation()
        {
            Initialize();
        }

        public GalaxyCpuDatabaseInformation(GalaxyCpuDatabaseInformation e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            AlertEventAcknowledgeData = new List<GalaxyPanel_GetAlertEventAcknowledgeData>();
        }

        public void Initialize(GalaxyCpuDatabaseInformation e)
        {
            Initialize();
            if (e == null)
                return;

            ClusterUid = e.ClusterUid;
            GalaxyPanelUid = e.GalaxyPanelUid;
            CpuUid = e.CpuUid;
            ClusterGroupId = e.ClusterGroupId;
            ClusterNumber = e.ClusterNumber;
            PanelNumber = e.PanelNumber;
            CpuNumber = e.CpuNumber;
            SerialNumber = e.SerialNumber;
            IpAddress = e.IpAddress;
            DefaultEventLoggingOn = e.DefaultEventLoggingOn;
            PreventDataLoading = e.PreventDataLoading;
            PreventFlashLoading = e.PreventFlashLoading;
            LastLogIndex = e.LastLogIndex;
            ClusterName = e.ClusterName;
            PanelName = e.PanelName;
            ClusterTypeCode = e.ClusterTypeCode;
            ClusterTypeIsActive = e.ClusterTypeIsActive;
            CredentialDataLength = e.CredentialDataLength;
            PanelLocation = e.PanelLocation;
            PanelModelTypeCode = e.PanelModelTypeCode;
            PanelModelIsActive = e.PanelModelIsActive;
            CpuIsActive = e.CpuIsActive;
            EntityId = e.EntityId;
            EntityName = e.EntityName;
            EntityType = e.EntityType;
            SiteUid = e.SiteUid;
            SiteName = e.SiteName;
            TimeZoneId = e.TimeZoneId;
            IsConnected = e.IsConnected;
            if (e.AlertEventAcknowledgeData != null)
                AlertEventAcknowledgeData = e.AlertEventAcknowledgeData.ToList();

        }

        public GalaxyCpuDatabaseInformation Clone(GalaxyCpuDatabaseInformation e)
        {
            return new GalaxyCpuDatabaseInformation(e);
        }

        public bool Equals(GalaxyCpuDatabaseInformation other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyCpuDatabaseInformation other)
        {
            if (other == null)
                return false;

            if (other.CpuUid != this.CpuUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
