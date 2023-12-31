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
    public partial class CredentialFormat : EntityBase, IIdentifiableEntity, IEquatable<CredentialFormat>, ITableEntityBase
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
        public partial class CredentialFormat
        {
        	public CredentialFormat()
        	{
        		Initialize();
        	}
        
        	public CredentialFormat(CredentialFormat e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.Credentials = new HashSet<Credential>();
        		this.CredentialFormatDataFields = new HashSet<CredentialFormatDataField>();
        		this.CredentialFormatParities = new HashSet<CredentialFormatParity>();
        	}
        
        	public void Initialize(CredentialFormat e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.CredentialFormatUid = e.CredentialFormatUid;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.Display = e.Display;
        		this.Description = e.Description;
        		this.CredentialFormatCode = e.CredentialFormatCode;
        		this.BitLength = e.BitLength;
        		this.IsEnabled = e.IsEnabled;
        		this.BiomenticEnrollmentSupported = e.BiomenticEnrollmentSupported;
        		this.BiometricIdField = e.BiometricIdField;
        		this.UseFullCardCode = e.UseFullCardCode;
        		this.BatchLoadSupported = e.BatchLoadSupported;
        		this.BatchLoadIncrementField = e.BatchLoadIncrementField;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.BiometricEnrollmentSupported = e.BiometricEnrollmentSupported;
        		this.UseCardNumber = e.UseCardNumber;
        		this.Credentials = e.Credentials.ToCollection();
        		this.CredentialFormatDataFields = e.CredentialFormatDataFields.ToCollection();
        		this.CredentialFormatParities = e.CredentialFormatParities.ToCollection();
        		
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
        
        	public CredentialFormat Clone(CredentialFormat e)
        	{
        		return new CredentialFormat(e);
        	}
        
        	public bool Equals(CredentialFormat other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialFormat other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialFormatUid != this.CredentialFormatUid )
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
    	public System.Guid CredentialFormatUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> DisplayResourceKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> DescriptionResourceKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Display { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Description { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short CredentialFormatCode { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short BitLength { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsEnabled { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool BiomenticEnrollmentSupported { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short BiometricIdField { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool UseFullCardCode { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool BatchLoadSupported { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short BatchLoadIncrementField { get; set; }
    
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
    	public string UpdateName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> UpdateDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool BiometricEnrollmentSupported { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool UseCardNumber { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<Credential> Credentials { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CredentialFormatDataField> CredentialFormatDataFields { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public gcsResourceString gcsResourceString { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CredentialFormatParity> CredentialFormatParities { get; set; }
    
    }
}
