////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\PropertySensitivityLevel.cs
//
// summary:	Implements the property sensitivity level class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GalaxySMS.Common.Enums;
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
    public partial class PropertySensitivityLevelBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PropertySensitivityLevelUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.Guid> DisplayResourceKey { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.Guid> DescriptionResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Display { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public SensitivityLevel SensitivityLevel { get; set; }

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
        public ICollection<PropertySensitivityLevelPermissionBasic> PropertySensitivityLevelPermissions { get; set; }

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
