#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif

{
    public partial class AccessPortalAlarmEventAcknowledgment
    {
        public AccessPortalAlarmEventAcknowledgment()
        {
            Initialize();
        }

        public AccessPortalAlarmEventAcknowledgment(AccessPortalAlarmEventAcknowledgment e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalAlarmEventAcknowledgment e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalAlarmEventAcknowledgmentUid = e.AccessPortalAlarmEventAcknowledgmentUid;
            this.AccessPortalActivityEventUid = e.AccessPortalActivityEventUid;
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

        public AccessPortalAlarmEventAcknowledgment Clone(AccessPortalAlarmEventAcknowledgment e)
        {
            return new AccessPortalAlarmEventAcknowledgment(e);
        }

        public bool Equals(AccessPortalAlarmEventAcknowledgment other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAlarmEventAcknowledgment other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAlarmEventAcknowledgmentUid != this.AccessPortalAlarmEventAcknowledgmentUid)
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
