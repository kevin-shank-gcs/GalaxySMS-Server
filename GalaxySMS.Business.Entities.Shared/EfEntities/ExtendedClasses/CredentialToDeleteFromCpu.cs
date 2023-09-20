#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class CredentialToDeleteFromCpu
    {
        public CredentialToDeleteFromCpu()
        {
            Initialize();
        }

        public CredentialToDeleteFromCpu(CredentialToDeleteFromCpu e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(CredentialToDeleteFromCpu e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialToDeleteFromCpuUid = e.CredentialToDeleteFromCpuUid;
            this.CpuUid = e.CpuUid;
            this.CardBinaryData = e.CardBinaryData;
            this.DeletedFromDatabaseDate = e.DeletedFromDatabaseDate;
            this.DeletedFromCpuDate = e.DeletedFromCpuDate;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.CpuNumber = e.CpuNumber;
            this.ServerAddress = e.ServerAddress;
            this.IsConnected = e.IsConnected;
            this.IsExtended = e.IsExtended;
            this.DataLength = e.DataLength;
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

        public CredentialToDeleteFromCpu Clone(CredentialToDeleteFromCpu e)
        {
            return new CredentialToDeleteFromCpu(e);
        }

        public bool Equals(CredentialToDeleteFromCpu other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialToDeleteFromCpu other)
        {
            if (other == null)
                return false;

            if (other.CredentialToDeleteFromCpuUid != this.CredentialToDeleteFromCpuUid)
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
