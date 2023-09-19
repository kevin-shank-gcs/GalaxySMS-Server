using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyOutputMode
    {
        public GalaxyOutputMode()
        {
            Initialize();
        }

        public GalaxyOutputMode(GalaxyOutputMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.OutputCommandUids = new HashSet<Guid>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyOutputMode e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
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
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.OutputCommandUids != null)
                this.OutputCommandUids = e.OutputCommandUids.ToCollection();

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
