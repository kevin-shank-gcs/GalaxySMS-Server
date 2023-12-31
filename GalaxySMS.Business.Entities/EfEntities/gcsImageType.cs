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
    public partial class gcsImageType : EntityBase, IIdentifiableEntity, IEquatable<gcsImageType>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsImageType
        {
        	public gcsImageType()
        	{
        		Initialize();
        	}
        
        	public gcsImageType(gcsImageType e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsImageType e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.ImageTypeId = e.ImageTypeId;
        		this.ImageTypeCode = e.ImageTypeCode;
        		this.ImageTypeName = e.ImageTypeName;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsImageType Clone(gcsImageType e)
        	{
        		return new gcsImageType(e);
        	}
        
        	public bool Equals(gcsImageType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsImageType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ImageTypeId != this.ImageTypeId )
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
    	public System.Guid ImageTypeId { get; set; }
    	public string ImageTypeCode { get; set; }
    	public string ImageTypeName { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    }
}
