using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AssaAccessPoint
    {
        public AssaAccessPoint()
        {
            Initialize();
        }

        public AssaAccessPoint(AssaAccessPoint e)
        {
            Initialize(e);
        }

        public void Initialize()
        {

        }

        public void Initialize(AssaAccessPoint e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaAccessPointUid = e.AssaAccessPointUid;
            this.AssaDsrUid = e.AssaDsrUid;
            this.AssaAccessPointTypeUid = e.AssaAccessPointTypeUid;
            this.SiteUid = e.SiteUid;
            this.AssaUniqueId = e.AssaUniqueId;
            this.SerialNumber = e.SerialNumber;
            this.AccessPointName = e.AccessPointName;
            this.FirmwareVersion = e.FirmwareVersion;
            this.AccessPointTypeDescription = e.AccessPointTypeDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AccessPoint = e.AccessPoint;
            //if( e.AssaDsr != null )
            //    this.AssaDsr = e.AssaDsr;
            //if (e.AssaAccessPointType != null)
            //    this.AssaAccessPointType = e.AssaAccessPointType;
    }

    public AssaAccessPoint Clone(AssaAccessPoint e)
        {
            return new AssaAccessPoint(e);
        }

        public bool Equals(AssaAccessPoint other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaAccessPoint other)
        {
            if (other == null)
                return false;

            if (other.AssaAccessPointUid != this.AssaAccessPointUid)
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
