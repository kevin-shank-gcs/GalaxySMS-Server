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
    public partial class RoleCluster : EntityBase, IIdentifiableEntity, IEquatable<RoleCluster>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class RoleCluster
        {
        	public RoleCluster()
        	{
        		Initialize();
        	}
        
        	public RoleCluster(RoleCluster e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.RoleClusterPermissions = new HashSet<RoleClusterPermission>();
        	}
        
        	public void Initialize(RoleCluster e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.RoleClusterUid = e.RoleClusterUid;
        		this.RoleId = e.RoleId;
        		this.ClusterUid = e.ClusterUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.RoleClusterPermissions = e.RoleClusterPermissions.ToCollection();
        		
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
        
        	public RoleCluster Clone(RoleCluster e)
        	{
        		return new RoleCluster(e);
        	}
        
        	public bool Equals(RoleCluster other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleCluster other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleClusterUid != this.RoleClusterUid )
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
    	public System.Guid RoleClusterUid { get; set; }
    	public System.Guid RoleId { get; set; }
    	public System.Guid ClusterUid { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public Cluster Cluster { get; set; }
    	public gcsRole gcsRole { get; set; }
    	public ICollection<RoleClusterPermission> RoleClusterPermissions { get; set; }
    
    }
}
