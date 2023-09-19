using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PropertySensitivityLevelPermission
    {
        public PropertySensitivityLevelPermission()
        {
            Initialize();
        }

        public PropertySensitivityLevelPermission(PropertySensitivityLevelPermission e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PropertySensitivityLevelPermission e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PropertySensitivityLevelPermissionUid = e.PropertySensitivityLevelPermissionUid;
            this.PermissionId = e.PermissionId;
            this.PropertySensitivityLevelUid = e.PropertySensitivityLevelUid;
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

        public PropertySensitivityLevelPermission Clone(PropertySensitivityLevelPermission e)
        {
            return new PropertySensitivityLevelPermission(e);
        }

        public bool Equals(PropertySensitivityLevelPermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PropertySensitivityLevelPermission other)
        {
            if (other == null)
                return false;

            if (other.PropertySensitivityLevelPermissionUid != this.PropertySensitivityLevelPermissionUid)
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
