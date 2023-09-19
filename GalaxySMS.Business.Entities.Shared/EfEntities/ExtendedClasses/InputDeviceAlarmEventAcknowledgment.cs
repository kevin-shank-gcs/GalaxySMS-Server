#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class InputDeviceAlarmEventAcknowledgment
    {
        public InputDeviceAlarmEventAcknowledgment()
        {
            Initialize();
        }

        public InputDeviceAlarmEventAcknowledgment(InputDeviceAlarmEventAcknowledgment e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputDeviceAlarmEventAcknowledgment e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceAlarmEventAcknowledgmentUid = e.InputDeviceAlarmEventAcknowledgmentUid;
            this.InputDeviceActivityEventUid = e.InputDeviceActivityEventUid;
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

        public InputDeviceAlarmEventAcknowledgment Clone(InputDeviceAlarmEventAcknowledgment e)
        {
            return new InputDeviceAlarmEventAcknowledgment(e);
        }

        public bool Equals(InputDeviceAlarmEventAcknowledgment other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceAlarmEventAcknowledgment other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceAlarmEventAcknowledgmentUid != this.InputDeviceAlarmEventAcknowledgmentUid)
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
