////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\UserDefinedProperty.cs
//
// summary:	Implements the user defined property class
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user defined property. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class UserDefinedProperty
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDefinedProperty() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The UserDefinedProperty to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDefinedProperty(UserDefinedProperty e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this UserDefinedProperty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.UserDefinedListPropertyItems = new HashSet<UserDefinedListPropertyItem>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this UserDefinedProperty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The UserDefinedProperty to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(UserDefinedProperty e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.PropertyTypeUid = e.PropertyTypeUid;
            this.PropertySensitivityLevelUid = e.PropertySensitivityLevelUid;
            this.PropertyName = e.PropertyName;
            this.SchemaName = e.SchemaName;
            this.TableName = e.TableName;
            this.ColumnName = e.ColumnName;
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
            this.UniquePropertyName = e.UniquePropertyName;
            this.EntityId = e.EntityId;
            this.UserDefinedBooleanPropertyRules = e.UserDefinedBooleanPropertyRules;
            this.UserDefinedDatePropertyRules = e.UserDefinedDatePropertyRules;
            this.UserDefinedListPropertyItems = e.UserDefinedListPropertyItems.ToCollection();
            this.UserDefinedListPropertyRules = e.UserDefinedListPropertyRules;
            this.UserDefinedNumberPropertyRules = e.UserDefinedNumberPropertyRules;
            this.UserDefinedTextPropertyRules = e.UserDefinedTextPropertyRules;
            this.UserDefinedGuidPropertyRules = e.UserDefinedGuidPropertyRules;
            this.PropertySensitivityLevel = e.PropertySensitivityLevel;

            this.IsVisible = e.IsVisible;
            this.IsReadOnly= e.IsReadOnly;
            this.IsEffectiveReadOnly = e.IsEffectiveReadOnly;

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this UserDefinedProperty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The UserDefinedProperty to process. </param>
        ///
        /// <returns>   A copy of this UserDefinedProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDefinedProperty Clone(UserDefinedProperty e)
        {
            return new UserDefinedProperty(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this UserDefinedProperty is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(UserDefinedProperty other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(UserDefinedProperty other)
        {
            if (other == null)
                return false;

            if (other.UserDefinedPropertyUid != this.UserDefinedPropertyUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }


        /// <summary>   True if this UserDefinedProperty is visible. </summary>
        private bool _isVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this UserDefinedProperty is visible.
        /// </summary>
        ///
        /// <value> True if this UserDefinedProperty is visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    OnPropertyChanged(() => IsVisible, false);
                }
            }
        }


        /// <summary>   True if this UserDefinedProperty is read only. </summary>
        private bool _isReadOnly;

        [DataMember]
        // This is set by the server based on user permissions and the sensitivity level

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this UserDefinedProperty is read only.
        /// </summary>
        ///
        /// <value> True if this UserDefinedProperty is read only, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this UserDefinedProperty is read only.
        /// </summary>
        ///
        /// <value> True if this UserDefinedProperty is read only, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                if (_isReadOnly != value)
                {
                    _isReadOnly = value;
                    OnPropertyChanged(() => IsReadOnly, false);
                    OnPropertyChanged(() => IsEffectiveReadOnly, false);
                }
            }
        }

        /// <summary>   True if this UserDefinedProperty is effective read only. </summary>
        private bool _isEffectiveReadOnly;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This is a combination of the IsReadOnly and IsEffectiveReadOnly properties. This can be used
        /// by the client side to toggle read-only while still respecting the IsReadOnly permission based
        /// property.
        /// </summary>
        ///
        /// <value> True if this UserDefinedProperty is effective read only, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsEffectiveReadOnly
        {
            get { return _isEffectiveReadOnly | IsReadOnly; }
            set
            {
                if (_isEffectiveReadOnly != value)
                {
                    _isEffectiveReadOnly = value;
                    OnPropertyChanged(() => IsEffectiveReadOnly, false);
                }
            }
        }



    }
}
