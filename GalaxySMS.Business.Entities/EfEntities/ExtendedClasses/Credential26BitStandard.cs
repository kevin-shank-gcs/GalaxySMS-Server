using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Credential26BitStandard
    {
        public Credential26BitStandard()
        {
            Initialize();
        }

        public Credential26BitStandard(Credential26BitStandard e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(Credential26BitStandard e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialUid = e.CredentialUid;
            this.FacilityCode = e.FacilityCode;
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

        public Credential26BitStandard Clone(Credential26BitStandard e)
        {
            return new Credential26BitStandard(e);
        }

        public bool Equals(Credential26BitStandard other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Credential26BitStandard other)
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
