//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    public partial class gcsAuditXml : EntityBase, IIdentifiableEntity, IEquatable<gcsAuditXml>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    using System.Runtime.Serialization;
    
    #if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
    #elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
    #else
    namespace GalaxySMS.Business.Entities
    #endif
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
        
        		this.IsDirty = e.IsDirty;
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
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AuditId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Type { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string TableName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string PKField { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string PKValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string FieldName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string OldValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string NewValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string XmlText { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> UpdateDateTime { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string UserName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string HostMachineName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string AppName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string NTDomain { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string NTUserName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string NETAddress { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> ApplicationUserId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> TransactionID { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Description { get; set; }
    
    }
}
