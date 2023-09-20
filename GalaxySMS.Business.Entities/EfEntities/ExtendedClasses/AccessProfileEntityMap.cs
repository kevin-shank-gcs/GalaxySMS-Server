using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessProfileEntityMap
    {
        public AccessProfileEntityMap()
        {
            Initialize();
        }

        public AccessProfileEntityMap(AccessProfileEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessProfileEntityMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessProfileEntityMapUid = e.AccessProfileEntityMapUid;
            this.AccessProfileUid = e.AccessProfileUid;
            this.EntityId = e.EntityId;
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

        public AccessProfileEntityMap Clone(AccessProfileEntityMap e)
        {
            return new AccessProfileEntityMap(e);
        }

        public bool Equals(AccessProfileEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessProfileEntityMap other)
        {
            if (other == null)
                return false;

            if (other.AccessProfileEntityMapUid != this.AccessProfileEntityMapUid)
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
