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
    public partial class ClusterLedBehaviorMode : EntityBase, IIdentifiableEntity, IEquatable<ClusterLedBehaviorMode>, ITableEntityBase, IHasDisplayResourceKey, IHasDescriptionResourceKey
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class ClusterLedBehaviorMode
        {
        	public ClusterLedBehaviorMode()
        	{
        		Initialize();
        	}
        
        	public ClusterLedBehaviorMode(ClusterLedBehaviorMode e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(ClusterLedBehaviorMode e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.ClusterLedBehaviorModeUid = e.ClusterLedBehaviorModeUid;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.LedBehaviorCode = e.LedBehaviorCode;
        		this.Display = e.Display;
        		this.Description = e.Description;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public ClusterLedBehaviorMode Clone(ClusterLedBehaviorMode e)
        	{
        		return new ClusterLedBehaviorMode(e);
        	}
        
        	public bool Equals(ClusterLedBehaviorMode other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(ClusterLedBehaviorMode other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ClusterLedBehaviorModeUid != this.ClusterLedBehaviorModeUid )
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
    	public System.Guid ClusterLedBehaviorModeUid { get; set; }
    	public Nullable<System.Guid> DisplayResourceKey { get; set; }
    	public Nullable<System.Guid> DescriptionResourceKey { get; set; }
    	public short LedBehaviorCode { get; set; }
    	public string Display { get; set; }
    	public string Description { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }

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
