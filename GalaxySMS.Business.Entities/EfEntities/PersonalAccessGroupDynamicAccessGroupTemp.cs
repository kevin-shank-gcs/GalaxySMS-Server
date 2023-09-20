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
    public partial class PersonalAccessGroupDynamicAccessGroupTemp : EntityBase, IIdentifiableEntity, IEquatable<PersonalAccessGroupDynamicAccessGroupTemp>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class PersonalAccessGroupDynamicAccessGroupTemp
        {
        	public PersonalAccessGroupDynamicAccessGroupTemp()
        	{
        		Initialize();
        	}
        
        	public PersonalAccessGroupDynamicAccessGroupTemp(PersonalAccessGroupDynamicAccessGroupTemp e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(PersonalAccessGroupDynamicAccessGroupTemp e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PersonalAccessGroupDynamicAccessGroupUid = e.PersonalAccessGroupDynamicAccessGroupUid;
        		this.PersonPersonalAccessGroupUid = e.PersonPersonalAccessGroupUid;
        		this.AccessGroupUid = e.AccessGroupUid;
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
        
        	public PersonalAccessGroupDynamicAccessGroupTemp Clone(PersonalAccessGroupDynamicAccessGroupTemp e)
        	{
        		return new PersonalAccessGroupDynamicAccessGroupTemp(e);
        	}
        
        	public bool Equals(PersonalAccessGroupDynamicAccessGroupTemp other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonalAccessGroupDynamicAccessGroupTemp other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonalAccessGroupDynamicAccessGroupUid != this.PersonalAccessGroupDynamicAccessGroupUid )
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
    	public System.Guid PersonalAccessGroupDynamicAccessGroupUid { get; set; }
    	public System.Guid PersonPersonalAccessGroupUid { get; set; }
    	public System.Guid AccessGroupUid { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    }
}
