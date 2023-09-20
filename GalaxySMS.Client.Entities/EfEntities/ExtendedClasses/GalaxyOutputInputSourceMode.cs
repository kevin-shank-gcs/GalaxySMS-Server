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
    public partial class GalaxyOutputInputSourceMode
    {
        public GalaxyOutputInputSourceMode() : base()
        {
            Initialize();
        }

        public GalaxyOutputInputSourceMode(GalaxyOutputInputSourceMode e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.gcsBinaryResource = new gcsBinaryResource();
        }

        public void Initialize(GalaxyOutputInputSourceMode e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyOutputInputSourceModeUid = e.GalaxyOutputInputSourceModeUid;
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

            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            this.ResourceClassName = e.ResourceClassName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.UniqueResourceName = e.UniqueResourceName;
        }

        public GalaxyOutputInputSourceMode Clone(GalaxyOutputInputSourceMode e)
        {
            return new GalaxyOutputInputSourceMode(e);
        }

        public bool Equals(GalaxyOutputInputSourceMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputInputSourceMode other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputInputSourceModeUid != this.GalaxyOutputInputSourceModeUid)
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
