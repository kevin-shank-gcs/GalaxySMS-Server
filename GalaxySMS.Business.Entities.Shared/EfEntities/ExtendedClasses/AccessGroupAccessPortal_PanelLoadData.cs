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

    public partial class AccessGroupAccessPortal_PanelLoadData
    {
        public AccessGroupAccessPortal_PanelLoadData()
        {
            Initialize();
        }

        public AccessGroupAccessPortal_PanelLoadData(AccessGroupAccessPortal_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessGroupAccessPortal_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.AccessPortalUid = e.AccessPortalUid;
            this.AccessGroupUid = e.AccessGroupUid;
            this.AccessGroupAccessPortalUid = e.AccessGroupAccessPortalUid;
            this.AccessGroupNumber = e.AccessGroupNumber;
            this.ActivationDate = e.ActivationDate;
            this.ExpirationDate = e.ExpirationDate;
            this.IsEnabled = e.IsEnabled;
            this.PanelScheduleNumber = e.PanelScheduleNumber;
            this.TimeScheduleName = e.TimeScheduleName;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.AccessPortalBoardTypeTypeCode = e.AccessPortalBoardTypeTypeCode;
            this.DefaultTimeScheduleName = e.DefaultTimeScheduleName;
            this.DefaultTimeScheduleNumber = e.DefaultTimeScheduleNumber;
            this.CurrentTimeForCluster = e.CurrentTimeForCluster;
            this.IsNodeActive = e.IsNodeActive;
        }

        public AccessGroupAccessPortal_PanelLoadData Clone(AccessGroupAccessPortal_PanelLoadData e)
        {
            return new AccessGroupAccessPortal_PanelLoadData(e);
        }

        public bool Equals(AccessGroupAccessPortal_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroupAccessPortal_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalUid != this.AccessPortalUid)
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
