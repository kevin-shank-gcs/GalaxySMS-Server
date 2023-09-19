using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
