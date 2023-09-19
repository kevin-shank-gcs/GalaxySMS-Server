using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyFlashImage
    {
        public GalaxyFlashImage()
        {
            Initialize();
        }

        public GalaxyFlashImage(GalaxyFlashImage e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyFlashImage e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
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
