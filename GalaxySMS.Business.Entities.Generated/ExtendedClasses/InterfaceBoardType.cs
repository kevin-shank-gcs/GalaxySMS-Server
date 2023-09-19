using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InterfaceBoardType
    {
        public InterfaceBoardType()
        {
            Initialize();
        }

        public InterfaceBoardType(InterfaceBoardType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(InterfaceBoardType e)
        {
            Initialize();
            if (e == null)
                return;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.TypeCode = e.TypeCode;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Model = e.Model;
            this.NumberOfSections = e.NumberOfSections;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public InterfaceBoardType Clone(InterfaceBoardType e)
        {
            return new InterfaceBoardType(e);
        }

        public bool Equals(InterfaceBoardType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InterfaceBoardType other)
        {
            if (other == null)
                return false;

            if (other.InterfaceBoardTypeUid != this.InterfaceBoardTypeUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}