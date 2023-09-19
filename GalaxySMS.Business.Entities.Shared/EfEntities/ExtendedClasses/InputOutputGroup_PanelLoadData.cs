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

    public partial class InputOutputGroup_PanelLoadData
    {
        public InputOutputGroup_PanelLoadData()
        {
            Initialize();
        }

        public InputOutputGroup_PanelLoadData(InputOutputGroup_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {

        }

        public void Initialize(InputOutputGroup_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.ClusterUid = e.ClusterUid;
            this.InputOutputGroupName = e.InputOutputGroupName;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.IOGroupNumber = e.IOGroupNumber;
            this.PanelScheduleNumber = e.PanelScheduleNumber;
            this.LocalIOGroup = e.LocalIOGroup;
            this.TimeScheduleName = e.TimeScheduleName;
            this.EntityName = e.EntityName;
            this.EntityId = e.EntityId;
            this.ClusterName = e.ClusterName;

        }

        public InputOutputGroup_PanelLoadData Clone(InputOutputGroup_PanelLoadData e)
        {
            return new InputOutputGroup_PanelLoadData(e);
        }

        public bool Equals(InputOutputGroup_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputOutputGroup_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.InputOutputGroupUid != this.InputOutputGroupUid)
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
