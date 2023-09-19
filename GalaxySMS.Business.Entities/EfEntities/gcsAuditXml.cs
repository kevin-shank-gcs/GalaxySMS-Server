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
    public partial class gcsAuditXml : EntityBase, IIdentifiableEntity, IEquatable<gcsAuditXml>
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsAuditXml
        {
        	public gcsAuditXml()
        	{
        		Initialize();
        	}
        
        	public gcsAuditXml(gcsAuditXml e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsAuditXml e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.AuditId = e.AuditId;
        		this.Type = e.Type;
        		this.TableName = e.TableName;
        		this.PKField = e.PKField;
        		this.PKValue = e.PKValue;
        		this.FieldName = e.FieldName;
        		this.OldValue = e.OldValue;
        		this.NewValue = e.NewValue;
        		this.XmlText = e.XmlText;
        		this.UpdateDateTime = e.UpdateDateTime;
        		this.UserName = e.UserName;
        		this.HostMachineName = e.HostMachineName;
        		this.AppName = e.AppName;
        		this.NTDomain = e.NTDomain;
        		this.NTUserName = e.NTUserName;
        		this.NETAddress = e.NETAddress;
        		this.ApplicationUserId = e.ApplicationUserId;
        		this.TransactionID = e.TransactionID;
        		this.Description = e.Description;
        		
        	}
        
        	public gcsAuditXml Clone(gcsAuditXml e)
        	{
        		return new gcsAuditXml(e);
        	}
        
        	public bool Equals(gcsAuditXml other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsAuditXml other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AuditId != this.AuditId )
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
    	public System.Guid AuditId { get; set; }
    	public string Type { get; set; }
    	public string TableName { get; set; }
    	public string PKField { get; set; }
    	public string PKValue { get; set; }
    	public string FieldName { get; set; }
    	public string OldValue { get; set; }
    	public string NewValue { get; set; }
    	public string XmlText { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDateTime { get; set; }
    	public string UserName { get; set; }
    	public string HostMachineName { get; set; }
    	public string AppName { get; set; }
    	public string NTDomain { get; set; }
    	public string NTUserName { get; set; }
    	public string NETAddress { get; set; }
    	public Nullable<System.Guid> ApplicationUserId { get; set; }
    	public Nullable<System.Guid> TransactionID { get; set; }
    	public string Description { get; set; }
    
    }
}
