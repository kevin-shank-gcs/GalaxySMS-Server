using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class ClusterCommandAudit
    {
        public ClusterCommandAudit()
        {
            Initialize();
        }

        public ClusterCommandAudit(ClusterCommandAudit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(ClusterCommandAudit e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.ClusterCommandAuditUid = e.ClusterCommandAuditUid;
            this.ClusterCommandUid = e.ClusterCommandUid;
            this.UserId = e.UserId;
            this.ClusterUid = e.ClusterUid;
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

        public ClusterCommandAudit Clone(ClusterCommandAudit e)
        {
            return new ClusterCommandAudit(e);
        }

        public bool Equals(ClusterCommandAudit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ClusterCommandAudit other)
        {
            if (other == null)
                return false;

            if (other.ClusterCommandAuditUid != this.ClusterCommandAuditUid)
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