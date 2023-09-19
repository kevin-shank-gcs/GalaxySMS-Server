using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AssaAccessPointType
    {
        public AssaAccessPointType()
        {
            Initialize();
        }

        public AssaAccessPointType(AssaAccessPointType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AssaAccessPoints = new HashSet<AssaAccessPoint>();
        }

        public void Initialize(AssaAccessPointType e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaAccessPointTypeUid = e.AssaAccessPointTypeUid;
            this.Id = e.Id;
            this.DisplayName = e.DisplayName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AssaAccessPoints = e.AssaAccessPoints.ToCollection();

        }

        public AssaAccessPointType Clone(AssaAccessPointType e)
        {
            return new AssaAccessPointType(e);
        }

        public bool Equals(AssaAccessPointType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaAccessPointType other)
        {
            if (other == null)
                return false;

            if (other.AssaAccessPointTypeUid != this.AssaAccessPointTypeUid)
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
