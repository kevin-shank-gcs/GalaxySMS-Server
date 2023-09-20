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
    public partial class gcsResourceImage : EntityBase, IIdentifiableEntity, IEquatable<gcsResourceImage>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsResourceImage
        {
        	public gcsResourceImage()
        	{
        		Initialize();
        	}
        
        	public gcsResourceImage(gcsResourceImage e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsResourceImage e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.ResourceImageId = e.ResourceImageId;
        		this.ResourceName = e.ResourceName;
        		this.ResourceNumber = e.ResourceNumber;
        		this.ResourceClassName = e.ResourceClassName;
        		this.ImageTypeId = e.ImageTypeId;
        		this.ImageData = e.ImageData;
        		this.ImageUri = e.ImageUri;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsResourceImage Clone(gcsResourceImage e)
        	{
        		return new gcsResourceImage(e);
        	}
        
        	public bool Equals(gcsResourceImage other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsResourceImage other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ResourceImageId != this.ResourceImageId )
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
    	public System.Guid ResourceImageId { get; set; }
    	public string ResourceName { get; set; }
    	public Nullable<int> ResourceNumber { get; set; }
    	public string ResourceClassName { get; set; }
    	public Nullable<System.Guid> ImageTypeId { get; set; }
    	public byte[] ImageData { get; set; }
    	public string ImageUri { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    }
}
