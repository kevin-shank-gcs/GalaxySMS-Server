using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class GalaxyOutputMode
    {
        public GalaxyOutputMode() : base()
        {
            Initialize();
        }

        public GalaxyOutputMode(GalaxyOutputMode e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            OutputCommandUids = new HashSet<Guid>();
            this.gcsBinaryResource = new gcsBinaryResource();
        }

        public void Initialize(GalaxyOutputMode e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyOutputModeUid = e.GalaxyOutputModeUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.Display = e.Display;
            this.Description = e.Description;
            this.Code = e.Code;
            this.IsDefault = e.IsDefault;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.OutputCommandUids != null)
                this.OutputCommandUids = e.OutputCommandUids.ToCollection();

            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            this.ResourceClassName = e.ResourceClassName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.UniqueResourceName = e.UniqueResourceName;
        }

        public GalaxyOutputMode Clone(GalaxyOutputMode e)
        {
            return new GalaxyOutputMode(e);
        }

        public bool Equals(GalaxyOutputMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputMode other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputModeUid != this.GalaxyOutputModeUid)
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
