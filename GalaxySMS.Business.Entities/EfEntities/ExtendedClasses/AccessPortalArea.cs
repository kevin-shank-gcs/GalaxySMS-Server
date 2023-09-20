using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalArea
    {
        public AccessPortalArea()
        {
            Initialize();
        }

        public AccessPortalArea(AccessPortalArea e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalArea e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalAreaUid = e.AccessPortalAreaUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.AreaUid = e.AreaUid;
            this.AccessPortalAreaTypeUid = e.AccessPortalAreaTypeUid;
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

        public AccessPortalArea Clone(AccessPortalArea e)
        {
            return new AccessPortalArea(e);
        }

        public bool Equals(AccessPortalArea other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalArea other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAreaUid != this.AccessPortalAreaUid)
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