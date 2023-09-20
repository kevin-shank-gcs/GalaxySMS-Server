#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyPanelAlarmEventAcknowledgment
    {
        public GalaxyPanelAlarmEventAcknowledgment()
        {
            Initialize();
        }

        public GalaxyPanelAlarmEventAcknowledgment(GalaxyPanelAlarmEventAcknowledgment e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyPanelAlarmEventAcknowledgment e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyPanelAlarmEventAcknowledgmentUid = e.GalaxyPanelAlarmEventAcknowledgmentUid;
            this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
            this.UserId = e.UserId;
            this.Response = e.Response;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public GalaxyPanelAlarmEventAcknowledgment Clone(GalaxyPanelAlarmEventAcknowledgment e)
        {
            return new GalaxyPanelAlarmEventAcknowledgment(e);
        }

        public bool Equals(GalaxyPanelAlarmEventAcknowledgment other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelAlarmEventAcknowledgment other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelAlarmEventAcknowledgmentUid != this.GalaxyPanelAlarmEventAcknowledgmentUid)
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
