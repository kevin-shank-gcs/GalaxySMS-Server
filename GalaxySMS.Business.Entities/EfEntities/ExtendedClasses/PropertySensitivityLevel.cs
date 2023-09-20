using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PropertySensitivityLevel
    {
        public PropertySensitivityLevel()
        {
            Initialize();
        }

        public PropertySensitivityLevel(PropertySensitivityLevel e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.PropertySensitivityLevelPermissions = new HashSet<PropertySensitivityLevelPermission>();
        }

        public void Initialize(PropertySensitivityLevel e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PropertySensitivityLevelUid = e.PropertySensitivityLevelUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.SensitivityLevel = e.SensitivityLevel;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;

            if(e.PropertySensitivityLevelPermissions !=null)
                this.PropertySensitivityLevelPermissions = e.PropertySensitivityLevelPermissions.ToCollection();
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

        public PropertySensitivityLevel Clone(PropertySensitivityLevel e)
        {
            return new PropertySensitivityLevel(e);
        }

        public bool Equals(PropertySensitivityLevel other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PropertySensitivityLevel other)
        {
            if (other == null)
                return false;

            if (other.PropertySensitivityLevelUid != this.PropertySensitivityLevelUid)
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
