using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public partial class GalaxyPanelAlarmSettings_PanelLoadData
    {
        public GalaxyPanelAlarmSettings_PanelLoadData()
        {
            Initialize();
        }

        public GalaxyPanelAlarmSettings_PanelLoadData(GalaxyPanelAlarmSettings_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {

        }

        public void Initialize(GalaxyPanelAlarmSettings_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

        this.GalaxyPanelUid = e.GalaxyPanelUid;
        this.ClusterUid = e.ClusterUid;
        this.OffsetIndex = e.OffsetIndex;
        this.ClusterGroupId = e.ClusterGroupId;
        this.ClusterNumber = e.ClusterNumber;
        this.IOGroupNumber = e.IOGroupNumber;
        this.PanelNumber = e.PanelNumber;
        this.Tag  = e.Tag;
        this.IsActive = e.IsActive;
        this.EntityName  = e.EntityName;
        this.EntityId  = e.EntityId;
        this.ClusterName  = e.ClusterName;

    }

    public GalaxyPanelAlarmSettings_PanelLoadData Clone(GalaxyPanelAlarmSettings_PanelLoadData e)
    {
        return new GalaxyPanelAlarmSettings_PanelLoadData(e);
    }

    public bool Equals(GalaxyPanelAlarmSettings_PanelLoadData other)
    {
        return base.Equals(other);
    }

    public bool IsPrimaryKeyEqual(GalaxyPanelAlarmSettings_PanelLoadData other)
    {
        if (other == null)
            return false;

        if (other.IOGroupNumber != this.IOGroupNumber)
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
