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
    public partial class GalaxyOutputInputSourceRelationship
    {
        public GalaxyOutputInputSourceRelationship() : base()
        {
            Initialize();
        }

        public GalaxyOutputInputSourceRelationship(GalaxyOutputInputSourceRelationship e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.gcsBinaryResource = new gcsBinaryResource();
        }

        public void Initialize(GalaxyOutputInputSourceRelationship e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyOutputInputSourceRelationshipUid = e.GalaxyOutputInputSourceRelationshipUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.Display = e.Display;
            this.Description = e.Description;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
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

        public GalaxyOutputInputSourceRelationship Clone(GalaxyOutputInputSourceRelationship e)
        {
            return new GalaxyOutputInputSourceRelationship(e);
        }

        public bool Equals(GalaxyOutputInputSourceRelationship other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputInputSourceRelationship other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputInputSourceRelationshipUid != this.GalaxyOutputInputSourceRelationshipUid)
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
