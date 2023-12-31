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
    public partial class PersonalAccessGroupAccessPortal : EntityBase, IIdentifiableEntity, IEquatable<PersonalAccessGroupAccessPortal>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class PersonalAccessGroupAccessPortal
        {
        	public PersonalAccessGroupAccessPortal()
        	{
        		Initialize();
        	}
        
        	public PersonalAccessGroupAccessPortal(PersonalAccessGroupAccessPortal e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(PersonalAccessGroupAccessPortal e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PersonalAccessGroupAccessPortalUid = e.PersonalAccessGroupAccessPortalUid;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
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
        
        	public PersonalAccessGroupAccessPortal Clone(PersonalAccessGroupAccessPortal e)
        	{
        		return new PersonalAccessGroupAccessPortal(e);
        	}
        
        	public bool Equals(PersonalAccessGroupAccessPortal other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonalAccessGroupAccessPortal other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonalAccessGroupAccessPortalUid != this.PersonalAccessGroupAccessPortalUid )
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
    	public System.Guid PersonalAccessGroupAccessPortalUid { get; set; }
    	public System.Guid AccessPortalUid { get; set; }
    	public System.Guid PersonClusterPermissionUid { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public AccessPortal AccessPortal { get; set; }
    
    }
}
