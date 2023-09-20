#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class PersonPhoneNumber
    {
        public PersonPhoneNumber()
        {
            Initialize();
        }

        public PersonPhoneNumber(PersonPhoneNumber e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonPhoneNumber e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonPhoneNumberUid = e.PersonPhoneNumberUid;
            this.PersonUid = e.PersonUid;
            this.CellCarrierUid = e.CellCarrierUid;
            this.Label = e.Label;
            this.PhoneNumber = e.PhoneNumber;
            this.SmsPermitted = e.SmsPermitted;
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

        public PersonPhoneNumber Clone(PersonPhoneNumber e)
        {
            return new PersonPhoneNumber(e);
        }

        public bool Equals(PersonPhoneNumber other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonPhoneNumber other)
        {
            if (other == null)
                return false;

            if (other.PersonPhoneNumberUid != this.PersonPhoneNumberUid)
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
