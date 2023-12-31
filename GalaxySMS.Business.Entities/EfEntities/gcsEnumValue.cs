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
    public partial class gcsEnumValue : EntityBase, IIdentifiableEntity, IEquatable<gcsEnumValue>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsEnumValue
        {
        	public gcsEnumValue()
        	{
        		Initialize();
        	}
        
        	public gcsEnumValue(gcsEnumValue e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsEnumValue e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.EnumValueId = e.EnumValueId;
        		this.EnumNamespaceId = e.EnumNamespaceId;
        		this.Value = e.Value;
        		this.Description = e.Description;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsEnumValue Clone(gcsEnumValue e)
        	{
        		return new gcsEnumValue(e);
        	}
        
        	public bool Equals(gcsEnumValue other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsEnumValue other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.EnumValueId != this.EnumValueId )
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
    	public System.Guid EnumValueId { get; set; }
    	public System.Guid EnumNamespaceId { get; set; }
    	public int Value { get; set; }
    	public string Description { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public gcsEnumNamespace gcsEnumNamespace { get; set; }
    
    }
}
