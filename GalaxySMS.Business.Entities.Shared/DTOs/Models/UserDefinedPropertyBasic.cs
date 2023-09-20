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
    public partial class UserDefinedPropertyBasic : EntityBaseSimple
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

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.Guid> DisplayResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.Guid> DescriptionResourceKey { get; set; }

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

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string InsertName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.DateTimeOffset InsertDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string UpdateName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<short> ConcurrencyValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedBooleanPropertyRuleBasic UserDefinedBooleanPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedDatePropertyRuleBasic UserDefinedDatePropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserDefinedListPropertyItemBasic> UserDefinedListPropertyItems { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedListPropertyRuleBasic UserDefinedListPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedNumberPropertyRuleBasic UserDefinedNumberPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedPropertyTypeBasic UserDefinedPropertyType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedTextPropertyRuleBasic UserDefinedTextPropertyRules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedGuidPropertyRuleBasic UserDefinedGuidPropertyRules { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public gcsEntity gcsEntity { get; set; }

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
        public PropertySensitivityLevelBasic PropertySensitivityLevel { get; set; }

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

//        private string _resourceClassName = string.Empty;
//        /// <summary>
//        /// Get/Set ResourceClassName
//        /// </summary>

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string ResourceClassName
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_resourceClassName))
//                    _resourceClassName = this.GetType().Name;
//                return _resourceClassName;
//            }
//            set { _resourceClassName = value; }
//        }

//        /// <summary>
//        /// Get/Set DisplayResourceName
//        /// </summary>

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string DisplayResourceName { get; set; } = string.Empty;

//        /// <summary>
//        /// Get/Set DescriptionResourceName
//        /// </summary>

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string DescriptionResourceName { get; set; } = string.Empty;

//        /// <summary>
//        /// Get/Set UniqueResourceName
//        /// </summary>

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string UniqueResourceName { get; set; } = string.Empty;

    }
}
