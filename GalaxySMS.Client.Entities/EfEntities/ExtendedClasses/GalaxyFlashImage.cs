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
    public partial class GalaxyFlashImage
    {
        public GalaxyFlashImage() : base()
        {
            Initialize();
        }

        public GalaxyFlashImage(GalaxyFlashImage e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(GalaxyFlashImage e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyFlashImageUid = e.GalaxyFlashImageUid;
            this.GalaxyCpuModelUid = e.GalaxyCpuModelUid;
            this.Package = e.Package;
            this.Description = e.Description;
            this.ImportedFilename = e.ImportedFilename;
            this.FileDateTime = e.FileDateTime;
            this.Checksum = e.Checksum;
            this.Version = e.Version;
            this.DataFormat = e.DataFormat;
            this.Data = e.Data;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyFlashImage Clone(GalaxyFlashImage e)
        {
            return new GalaxyFlashImage(e);
        }

        public bool Equals(GalaxyFlashImage other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyFlashImage other)
        {
            if (other == null)
                return false;

            if (other.GalaxyFlashImageUid != this.GalaxyFlashImageUid)
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
