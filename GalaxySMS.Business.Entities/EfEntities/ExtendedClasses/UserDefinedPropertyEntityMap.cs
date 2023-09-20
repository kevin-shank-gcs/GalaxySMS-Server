using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedPropertyEntityMap
    {
        public UserDefinedPropertyEntityMap()
        {
            Initialize();
        }

        public UserDefinedPropertyEntityMap(UserDefinedPropertyEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(UserDefinedPropertyEntityMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.UserDefinedPropertyEntityMapUid = e.UserDefinedPropertyEntityMapUid;
            this.EntityId = e.EntityId;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
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

        public UserDefinedPropertyEntityMap Clone(UserDefinedPropertyEntityMap e)
        {
            return new UserDefinedPropertyEntityMap(e);
        }

        public bool Equals(UserDefinedPropertyEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedPropertyEntityMap other)
        {
            if (other == null)
                return false;

            if (other.UserDefinedPropertyEntityMapUid != this.UserDefinedPropertyEntityMapUid)
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
