////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\UserDefinedBooleanPropertyRule.cs
//
// summary:	Implements the user defined boolean property rule class
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

    public partial class UserDefinedBooleanPropertyRule : EntityBase, IIdentifiableEntity, IEquatable<UserDefinedBooleanPropertyRule>, ITableEntityBase//, IHasDisplayResourceKey, IHasDescriptionResourceKey
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid  UserDefinedPropertyUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool   CanBeIndeterminate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TrueDisplay { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid>  TrueDisplayResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TrueDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid>  TrueDescriptionResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FalseDisplay { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid>  FalseDisplayResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FalseDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid>  FalseDescriptionResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string IndeterminateDisplay { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid>  IndeterminateDisplayResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string IndeterminateDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid>  IndeterminateDescriptionResourceKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> DefaultValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName    { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate    { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName    { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset>    UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue    { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedProperty UserDefinedProperty { get; set; }


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
        /// Get/Set TrueDisplayResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TrueDisplayResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set TrueDescriptionResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TrueDescriptionResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set UniqueResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UniqueResourceName { get; set; } = string.Empty;
        /// <summary>
        /// Get/Set FalseDisplayResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FalseDisplayResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set DescriptionResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FalseTrueDescriptionResourceName { get; set; } = string.Empty;
        /// <summary>
        /// Get/Set IndeterminateDisplayResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string IndeterminateDisplayResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set IndeterminateDescriptionResourceName
        /// </summary>

#if NetCoreApi
#else
        [DataMember]
#endif
        public string IndeterminateDescriptionResourceName { get; set; } = string.Empty;

    }
}
