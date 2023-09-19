using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyCpuModel
    {
        public GalaxyCpuModel()
        {
            Initialize();
        }

        public GalaxyCpuModel(GalaxyCpuModel e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyCpus = new HashSet<GalaxyCpu>();
        }

        public void Initialize(GalaxyCpuModel e)
        {

            Initialize();
            if (e == null)
                return;
            this.GalaxyCpuModelUid = e.GalaxyCpuModelUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.TypeCode = e.TypeCode;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.GalaxyCpus = e.GalaxyCpus.ToCollection();


            // Common table properties
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            // IHasDisplayResource & IHasDescriptionResource members
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
        }

        public GalaxyCpuModel Clone(GalaxyCpuModel e)
        {
            return new GalaxyCpuModel(e);
        }

        public bool Equals(GalaxyCpuModel other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyCpuModel other)
        {
            if (other == null)
                return false;

            if (other.GalaxyCpuModelUid != this.GalaxyCpuModelUid)
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
