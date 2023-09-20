using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class CellCarrier
    {
        public CellCarrier()
        {
            Initialize();
        }

        public CellCarrier(CellCarrier e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(CellCarrier e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CellCarrierUid = e.CellCarrierUid;
            this.CarrierName = e.CarrierName;
            this.MMSSuffix = e.MMSSuffix;
            this.SMSSuffix = e.SMSSuffix;
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

        public CellCarrier Clone(CellCarrier e)
        {
            return new CellCarrier(e);
        }

        public bool Equals(CellCarrier other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CellCarrier other)
        {
            if (other == null)
                return false;

            if (other.CellCarrierUid != this.CellCarrierUid)
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
