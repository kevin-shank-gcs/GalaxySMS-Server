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
    public partial class gcsSerializedObject : EntityBase, IIdentifiableEntity, IEquatable<gcsSerializedObject>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsSerializedObject
        {
        	public gcsSerializedObject()
        	{
        		Initialize();
        	}
        
        	public gcsSerializedObject(gcsSerializedObject e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsSerializedObject e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.SerializedObjectId = e.SerializedObjectId;
        		this.ApplicationId = e.ApplicationId;
        		this.ObjectGuid = e.ObjectGuid;
        		this.SerializedObject = e.SerializedObject;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsSerializedObject Clone(gcsSerializedObject e)
        	{
        		return new gcsSerializedObject(e);
        	}
        
        	public bool Equals(gcsSerializedObject other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsSerializedObject other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.SerializedObjectId != this.SerializedObjectId )
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
    	public System.Guid SerializedObjectId { get; set; }
    	public System.Guid ApplicationId { get; set; }
    	public System.Guid ObjectGuid { get; set; }
    	public string SerializedObject { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    }
}
