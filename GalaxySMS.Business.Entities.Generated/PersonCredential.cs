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
    public partial class PersonCredential : EntityBase, IIdentifiableEntity, IEquatable<PersonCredential>, ITableEntityBase
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
        public partial class PersonCredential
        {
        	public PersonCredential()
        	{
        		Initialize();
        	}
        
        	public PersonCredential(PersonCredential e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.PersonClusterPermissions = new HashSet<PersonClusterPermission>();
        		this.PersonCredentialCommandScripts = new HashSet<PersonCredentialCommandScript>();
        	}
        
        	public void Initialize(PersonCredential e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PersonCredentialUid = e.PersonCredentialUid;
        		this.CredentialUid = e.CredentialUid;
        		this.PersonUid = e.PersonUid;
        		this.PersonCredentialRoleUid = e.PersonCredentialRoleUid;
        		this.PersonActivationModeUid = e.PersonActivationModeUid;
        		this.PersonExpirationModeUid = e.PersonExpirationModeUid;
        		this.BadgeTemplateUid = e.BadgeTemplateUid;
        		this.DossierBadgeTemplateUid = e.DossierBadgeTemplateUid;
        		this.AccessPortalNoServerReplyBehaviorUid = e.AccessPortalNoServerReplyBehaviorUid;
        		this.AccessPortalDeferToServerBehaviorUid = e.AccessPortalDeferToServerBehaviorUid;
        		this.CredentialDescription = e.CredentialDescription;
        		this.ActivationDateTime = e.ActivationDateTime;
        		this.ExpirationDateTime = e.ExpirationDateTime;
        		this.UsageCount = e.UsageCount;
        		this.TraceEnabled = e.TraceEnabled;
        		this.DuressEnabled = e.DuressEnabled;
        		this.ReverseBits = e.ReverseBits;
        		this.BiometricEnrollmentStatus = e.BiometricEnrollmentStatus;
        		this.BadgePrintLimit = e.BadgePrintLimit;
        		this.BadgePrintCount = e.BadgePrintCount;
        		this.BadgeLastPrinted = e.BadgeLastPrinted;
        		this.DossierPrintLimit = e.DossierPrintLimit;
        		this.DossierPrintCount = e.DossierPrintCount;
        		this.DossierLastPrinted = e.DossierLastPrinted;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.IsActive = e.IsActive;
        		this.SysGalCardId = e.SysGalCardId;
        		this.PersonClusterPermissions = e.PersonClusterPermissions.ToCollection();
        		this.PersonCredentialCommandScripts = e.PersonCredentialCommandScripts.ToCollection();
        		
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
        
        	public PersonCredential Clone(PersonCredential e)
        	{
        		return new PersonCredential(e);
        	}
        
        	public bool Equals(PersonCredential other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonCredential other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonCredentialUid != this.PersonCredentialUid )
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
    	public System.Guid PersonCredentialUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid CredentialUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PersonUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PersonCredentialRoleUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PersonActivationModeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PersonExpirationModeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid BadgeTemplateUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid DossierBadgeTemplateUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AccessPortalNoServerReplyBehaviorUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AccessPortalDeferToServerBehaviorUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string CredentialDescription { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> ActivationDateTime { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> ExpirationDateTime { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short UsageCount { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool TraceEnabled { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool DuressEnabled { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool ReverseBits { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<short> BiometricEnrollmentStatus { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<int> BadgePrintLimit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<int> BadgePrintCount { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> BadgeLastPrinted { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<int> DossierPrintLimit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<int> DossierPrintCount { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> DossierLastPrinted { get; set; }
    
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
    	public bool IsActive { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<short> SysGalCardId { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonClusterPermission> PersonClusterPermissions { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonCredentialCommandScript> PersonCredentialCommandScripts { get; set; }
    
    }
}
