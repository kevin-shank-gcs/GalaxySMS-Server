using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsEnumNamespace
    {
        public gcsEnumNamespace()
        {
            Initialize();
        }

        public gcsEnumNamespace(gcsEnumNamespace e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsEnumValues = new HashSet<gcsEnumValue>();
        }

        public void Initialize(gcsEnumNamespace e)
        {
            Initialize();
            if (e == null)
                return;
            this.EnumNamespaceId = e.EnumNamespaceId;
            this.Name = e.Name;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsEnumValues = e.gcsEnumValues.ToCollection();

        }

        public gcsEnumNamespace Clone(gcsEnumNamespace e)
        {
            return new gcsEnumNamespace(e);
        }

        public bool Equals(gcsEnumNamespace other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsEnumNamespace other)
        {
            if (other == null)
                return false;

            if (other.EnumNamespaceId != this.EnumNamespaceId)
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

