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
    public partial class gcsAudit : EntityBase, IIdentifiableEntity, IEquatable<gcsAudit>, ITableEntityBase
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
        public partial class gcsAudit
        {
        	public gcsAudit()
        	{
        		Initialize();
        	}
        
        	public gcsAudit(gcsAudit e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsAudit e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.AuditId = e.AuditId;
        		this.TransactionId = e.TransactionId;
        		this.TableName = e.TableName;
        		this.OperationType = e.OperationType;
        		this.PrimaryKeyColumn = e.PrimaryKeyColumn;
        		this.PrimaryKeyValue = e.PrimaryKeyValue;
        		this.RecordTag = e.RecordTag;
        		this.AuditXml = e.AuditXml;
        		this.ColumnName = e.ColumnName;
        		this.OriginalValue = e.OriginalValue;
        		this.NewValue = e.NewValue;
        		this.OriginalBinaryValue = e.OriginalBinaryValue;
        		this.NewBinaryValue = e.NewBinaryValue;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UserId = e.UserId;
        		
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
        
        	public gcsAudit Clone(gcsAudit e)
        	{
        		return new gcsAudit(e);
        	}
        
        	public bool Equals(gcsAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsAudit other)
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
    	public System.Guid TransactionId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string TableName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string OperationType { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string PrimaryKeyColumn { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PrimaryKeyValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string RecordTag { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string AuditXml { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string ColumnName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string OriginalValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string NewValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] OriginalBinaryValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] NewBinaryValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string InsertName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> InsertDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> UserId { get; set; }
    
    }
}
