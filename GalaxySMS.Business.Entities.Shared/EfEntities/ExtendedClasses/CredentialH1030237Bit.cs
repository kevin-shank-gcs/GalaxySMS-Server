#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class CredentialH1030237Bit
    {
        public CredentialH1030237Bit()
        {
            Initialize();
        }

        public CredentialH1030237Bit(CredentialH1030237Bit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(CredentialH1030237Bit e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialUid = e.CredentialUid;
            this.IdCode = e.IdCode;
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

        public CredentialH1030237Bit Clone(CredentialH1030237Bit e)
        {
            return new CredentialH1030237Bit(e);
        }

        public bool Equals(CredentialH1030237Bit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialH1030237Bit other)
        {
            if (other == null)
                return false;

            if (other.CredentialUid != this.CredentialUid)
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
