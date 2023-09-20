// Move to partial class
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsBinaryResource
    {
        public gcsBinaryResource()
        {
            Initialize();
        }

        public gcsBinaryResource(gcsBinaryResource e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsBinaryResource e)
        {
            Initialize();
            if (e == null)
                return;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.DataType = e.DataType;
            this.Category = e.Category;
            this.Tag = e.Tag;
            this.BinaryResource = e.BinaryResource;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
        }

        public gcsBinaryResource Clone(gcsBinaryResource e)
        {
            return new gcsBinaryResource(e);
        }

        public bool Equals(gcsBinaryResource other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsBinaryResource other)
        {
            if (other == null)
                return false;

            if (other.BinaryResourceUid != this.BinaryResourceUid)
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

        public bool HasBeenModified { get; set; }
    }
}


