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
	public partial class AccessPortalAreaType
    {
        public AccessPortalAreaType()
        {
            Initialize();
        }

        public AccessPortalAreaType(AccessPortalAreaType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.AccessPortalAreas = new HashSet<AccessPortalArea>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalAreaType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalAreaTypeUid = e.AccessPortalAreaTypeUid;
            this.Tag = e.Tag;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.AccessPortalAreas = e.AccessPortalAreas.ToCollection();

            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
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

        public AccessPortalAreaType Clone(AccessPortalAreaType e)
        {
            return new AccessPortalAreaType(e);
        }

        public bool Equals(AccessPortalAreaType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAreaType other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAreaTypeUid != this.AccessPortalAreaTypeUid)
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