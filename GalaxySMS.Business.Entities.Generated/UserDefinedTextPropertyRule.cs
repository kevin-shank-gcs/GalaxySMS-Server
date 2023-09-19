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
    public partial class UserDefinedTextPropertyRule : EntityBase, IIdentifiableEntity, IEquatable<UserDefinedTextPropertyRule>, ITableEntityBase
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
        public partial class UserDefinedTextPropertyRule
        {
        	public UserDefinedTextPropertyRule()
        	{
        		Initialize();
        	}
        
        	public UserDefinedTextPropertyRule(UserDefinedTextPropertyRule e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(UserDefinedTextPropertyRule e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.UserDefinedPropertyTextRuleUid = e.UserDefinedPropertyTextRuleUid;
        		this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
        		this.MinimumLength = e.MinimumLength;
        		this.MaximumLength = e.MaximumLength;
        		this.DefaultValue = e.DefaultValue;
        		this.Mask = e.Mask;
        		this.ValidationRegEx = e.ValidationRegEx;
        		this.AllUpperCase = e.AllUpperCase;
        		this.FirstCharacterUpperCase = e.FirstCharacterUpperCase;
        		this.IsRequired = e.IsRequired;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.EmptyContent = e.EmptyContent;
        		this.ValidationErrorMessage = e.ValidationErrorMessage;
        		this.MaximumLengthLimit = e.MaximumLengthLimit;
        		
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
        
        	public UserDefinedTextPropertyRule Clone(UserDefinedTextPropertyRule e)
        	{
        		return new UserDefinedTextPropertyRule(e);
        	}
        
        	public bool Equals(UserDefinedTextPropertyRule other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(UserDefinedTextPropertyRule other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.UserDefinedPropertyTextRuleUid != this.UserDefinedPropertyTextRuleUid )
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
    	public System.Guid UserDefinedPropertyTextRuleUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid UserDefinedPropertyUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short MinimumLength { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short MaximumLength { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string DefaultValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Mask { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string ValidationRegEx { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool AllUpperCase { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool FirstCharacterUpperCase { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsRequired { get; set; }
    
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
    	public string EmptyContent { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string ValidationErrorMessage { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short MaximumLengthLimit { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public UserDefinedProperty UserDefinedProperty { get; set; }
    
    }
}
