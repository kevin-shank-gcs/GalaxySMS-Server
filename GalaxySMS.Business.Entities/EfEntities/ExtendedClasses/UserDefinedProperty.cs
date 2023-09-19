using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedProperty
    {
        public UserDefinedProperty()
        {
            Initialize();
        }

        public UserDefinedProperty(UserDefinedProperty e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.UserDefinedListPropertyItems = new HashSet<UserDefinedListPropertyItem>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(UserDefinedProperty e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.PropertyTypeUid = e.PropertyTypeUid;
            this.PropertySensitivityLevelUid = e.PropertySensitivityLevelUid;
            this.PropertyName = e.PropertyName;
            this.SchemaName = e.SchemaName;
            this.TableName = e.TableName;
            this.ColumnName = e.ColumnName;
            this.UniquePropertyName = e.UniquePropertyName;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.EntityId = e.EntityId;
            this.UserDefinedBooleanPropertyRules = e.UserDefinedBooleanPropertyRules;
            this.UserDefinedDatePropertyRules = e.UserDefinedDatePropertyRules;
            this.UserDefinedListPropertyRules = e.UserDefinedListPropertyRules;
            this.UserDefinedNumberPropertyRules = e.UserDefinedNumberPropertyRules;
            this.UserDefinedTextPropertyRules = e.UserDefinedTextPropertyRules;
            this.UserDefinedListPropertyItems = e.UserDefinedListPropertyItems.ToCollection();
            this.UserDefinedGuidPropertyRules = e.UserDefinedGuidPropertyRules;
            this.PropertySensitivityLevel  = e.PropertySensitivityLevel;

            this.IsVisible = e.IsVisible;
            this.IsReadOnly = e.IsReadOnly;

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

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

        public UserDefinedProperty Clone(UserDefinedProperty e)
        {
            return new UserDefinedProperty(e);
        }

        public bool Equals(UserDefinedProperty other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedProperty other)
        {
            if (other == null)
                return false;

            if (other.UserDefinedPropertyUid != this.UserDefinedPropertyUid)
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
