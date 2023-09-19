using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AssaDsrEntityMap
    {
        public AssaDsrEntityMap()
        {
            Initialize();
        }

        public AssaDsrEntityMap(AssaDsrEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AssaDsrEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaDsrEntityMapUid = e.AssaDsrEntityMapUid;
            this.AssaDsrUid = e.AssaDsrUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AssaDsrEntityMap Clone(AssaDsrEntityMap e)
        {
            return new AssaDsrEntityMap(e);
        }

        public bool Equals(AssaDsrEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaDsrEntityMap other)
        {
            if (other == null)
                return false;

            if (other.AssaDsrEntityMapUid != this.AssaDsrEntityMapUid)
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
