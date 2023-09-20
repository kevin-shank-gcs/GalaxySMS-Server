//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
    using GCS.Core.Common.Core;
    public partial class AccessGroup : EntityBase, IIdentifiableEntity, IEquatable<AccessGroup>, ITableEntityBase, IHasEntityMappingList, IHasDisplayResourceKey, IHasDescriptionResourceKey
    {
        /*	// Move to partial class
        using System;
        using System.Collections.Generic;
        using GCS.Core.Common.Contracts;
        using GCS.Core.Common.Core;
        using GCS.Core.Common.Extensions;

        namespace GalaxySMS.Business.Entities
        {
            public partial class AccessGroup
            {
                public AccessGroup()
                {
                    Initialize();
                }

                public AccessGroup(AccessGroup e)
                {
                    Initialize(e);
                }

                public void Initialize()
                {
                }

                public void Initialize(AccessGroup e)
                {
                    Initialize();
                    if( e == null )
                        return;
                    this.AccessGroupUid = e.AccessGroupUid;
                    this.ClusterUid = e.ClusterUid;
                    this.AccessGroupNumber = e.AccessGroupNumber;
                    this.AccessGroupName = e.AccessGroupName;
                    this.Description = e.Description;
                    this.ServiceComment = e.ServiceComment;
                    this.Comment = e.Comment;
                    this.IsExtended = e.IsExtended;
                    this.IsEnabled = e.IsEnabled;
                    this.ActivationDate = e.ActivationDate;
                    this.ExpirationDate = e.ExpirationDate;
                    this.InsertName = e.InsertName;
                    this.InsertDate = e.InsertDate;
                    this.UpdateName = e.UpdateName;
                    this.UpdateDate = e.UpdateDate;
                    this.ConcurrencyValue = e.ConcurrencyValue;
                    this.DisplayResourceKey = e.DisplayResourceKey;
                    this.DescriptionResourceKey = e.DescriptionResourceKey;

                }

                public AccessGroup Clone(AccessGroup e)
                {
                    return new AccessGroup(e);
                }

                public bool Equals(AccessGroup other)
                {
                    return base.Equals(other);
                }

                public bool IsPrimaryKeyEqual(AccessGroup other)
                {
                    if( other == null ) 
                        return false;

                    if(other.AccessGroupUid != this.AccessGroupUid )
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
        */
        public System.Guid AccessGroupUid { get; set; }
        public System.Guid ClusterUid { get; set; }
        public System.Guid EntityId { get; set; }
        public int AccessGroupNumber { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public string ServiceComment { get; set; }
        public string Comment { get; set; }
        public bool IsEnabled { get; set; }
        public Nullable<System.DateTimeOffset> ActivationDate { get; set; }
        public Nullable<System.DateTimeOffset> ExpirationDate { get; set; }
        public string InsertName { get; set; }
        public System.DateTimeOffset InsertDate { get; set; }
        public string UpdateName { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }
        public Nullable<System.Guid> DisplayResourceKey { get; set; }
        public Nullable<System.Guid> DescriptionResourceKey { get; set; }
        public Nullable<System.Guid> CrisisModeAccessGroupUid { get; set; }

        public Cluster Cluster { get; set; }
        public ICollection<Guid> EntityIds { get; set; }
        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }
        public ICollection<AccessGroupAccessPortal> AccessPortals { get; set; }

        private string _resourceClassName = string.Empty;
        /// <summary>
        /// Get/Set ResourceClassName
        /// </summary>
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
        public string DisplayResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set DescriptionResourceName
        /// </summary>
        public string DescriptionResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set UniqueResourceName
        /// </summary>
        public string UniqueResourceName { get; set; } = string.Empty;
    }
}


