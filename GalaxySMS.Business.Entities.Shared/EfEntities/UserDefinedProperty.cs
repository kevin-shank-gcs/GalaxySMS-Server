////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\UserDefinedProperty.cs
//
// summary:	Implements the user defined property class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class UserDefinedProperty : EntityBase, IIdentifiableEntity, IEquatable<UserDefinedProperty>, ITableEntityBase, IHasEntityMappingList, IHasDisplayResourceKey, IHasDescriptionResourceKey
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid UserDefinedPropertyUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PropertyTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PropertySensitivityLevelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PropertyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SchemaName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TableName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ColumnName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Display { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> DisplayResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> DescriptionResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short Code { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int DisplayOrder { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UniquePropertyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedBooleanPropertyRule UserDefinedBooleanPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedDatePropertyRule UserDefinedDatePropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserDefinedListPropertyItem> UserDefinedListPropertyItems { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedListPropertyRule UserDefinedListPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedNumberPropertyRule UserDefinedNumberPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedPropertyType UserDefinedPropertyType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedTextPropertyRule UserDefinedTextPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedGuidPropertyRule UserDefinedGuidPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public gcsEntity gcsEntity { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> EntityIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PropertySensitivityLevel PropertySensitivityLevel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsReadOnly { get; set; }

        private string _resourceClassName = string.Empty;
        /// <summary>
        /// Get/Set ResourceClassName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ResourceClassName
        {
            get
            {
                if (string.IsNullOrEmpty(_resourceClassName))
                    _resourceClassName = this.GetType().Name;
                return _resourceClassName;
            }
            set { _resourceClassName = value; }
        }

        /// <summary>
        /// Get/Set DisplayResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set DescriptionResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DescriptionResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set UniqueResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UniqueResourceName { get; set; } = string.Empty;


        public bool IsRequired
        {
            get
            {
                if (PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Text && this.UserDefinedTextPropertyRules != null)
                {
                    return this.UserDefinedTextPropertyRules.IsRequired || this.UserDefinedTextPropertyRules.MinimumLength > 0;
                }
                else if (PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number && this.UserDefinedNumberPropertyRules != null)
                {
                    return this.UserDefinedNumberPropertyRules.IsRequired;
                }
                else if (PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Date && this.UserDefinedDatePropertyRules != null)
                {
                    return !this.UserDefinedDatePropertyRules.AllowNull;
                }
                else if (PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Guid && this.UserDefinedGuidPropertyRules != null)
                {
                    return this.UserDefinedGuidPropertyRules.IsRequired;
                }
                return false;
            }
        }

    }
}
