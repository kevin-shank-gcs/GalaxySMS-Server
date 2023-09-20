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
    public partial class ClusterCommand : EntityBase, IIdentifiableEntity, IEquatable<ClusterCommand>, IHasDisplayResourceKey, IHasDescriptionResourceKey, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class ClusterCommand
        {
        	public ClusterCommand()
        	{
        		Initialize();
        	}
        
        	public ClusterCommand(ClusterCommand e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.ClusterTypeClusterCommands = new HashSet<ClusterTypeClusterCommand>();
        	}
        
        	public void Initialize(ClusterCommand e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.ClusterCommandUid = e.ClusterCommandUid;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.CommandCode = e.CommandCode;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.ClusterTypeClusterCommands = e.ClusterTypeClusterCommands.ToCollection();
        		
        	}
        
        	public ClusterCommand Clone(ClusterCommand e)
        	{
        		return new ClusterCommand(e);
        	}
        
        	public bool Equals(ClusterCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(ClusterCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ClusterCommandUid != this.ClusterCommandUid )
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
    	public System.Guid ClusterCommandUid { get; set; }
    	public short CommandCode { get; set; }
    	public bool IsActive { get; set; }
        public bool IsFlashingCommand { get; set; }
        public ICollection<ClusterTypeClusterCommand> ClusterTypeClusterCommands { get; set; }
        public ICollection<Guid> ClusterTypeIds { get; set; }

        // Common table properties
        public string InsertName { get; set; }
        public System.DateTimeOffset InsertDate { get; set; }
        public string UpdateName { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }

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
        public string UniqueResourceName { get; set; } = string.Empty;
    }
}
