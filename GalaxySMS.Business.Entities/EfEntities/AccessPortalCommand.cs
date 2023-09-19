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
    public partial class AccessPortalCommand : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalCommand>,  IHasDisplayResourceKey, IHasDescriptionResourceKey, ITableEntityBase
    {
    	public System.Guid AccessPortalCommandUid { get; set; }
    	public Nullable<bool> IsActive { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public ICollection<AccessPortalTypeAccessPortalCommand> AccessPortalTypeAccessPortalCommands { get; set; }
        public ICollection<Guid> AccessPortalTypeIds { get; set; }

        // IHasDisplayResourceKey, IHasDescriptionResourceKey members
        public string Display { get; set; }
        public Nullable<System.Guid> DisplayResourceKey { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> DescriptionResourceKey { get; set; }

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
        public string UniqueResourceName { get; set; } = string.Empty;    }
}
