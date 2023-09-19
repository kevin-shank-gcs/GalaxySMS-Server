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
    public partial class PersonPhoto : EntityBase, IIdentifiableEntity, IEquatable<PersonPhoto>, ITableEntityBase
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
        public partial class PersonPhoto
        {
        	public PersonPhoto()
        	{
        		Initialize();
        	}
        
        	public PersonPhoto(PersonPhoto e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.PersonPhotoScaleds = new HashSet<PersonPhotoScaled>();
        	}
        
        	public void Initialize(PersonPhoto e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PersonPhotoUid = e.PersonPhotoUid;
        		this.PersonUid = e.PersonUid;
        		this.Tag = e.Tag;
        		this.PhotoImage = e.PhotoImage;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.UniqueFilename = e.UniqueFilename;
        		this.OriginalFilename = e.OriginalFilename;
        		this.ContentType = e.ContentType;
        		this.IsDefault = e.IsDefault;
        		this.PublicUrl = e.PublicUrl;
        		this.PersonPhotoScaleds = e.PersonPhotoScaleds.ToCollection();
        		
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
        
        	public PersonPhoto Clone(PersonPhoto e)
        	{
        		return new PersonPhoto(e);
        	}
        
        	public bool Equals(PersonPhoto other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonPhoto other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonPhotoUid != this.PersonPhotoUid )
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
    	public System.Guid PersonPhotoUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PersonUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Tag { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] PhotoImage { get; set; }
    
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
    	public string UniqueFilename { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string OriginalFilename { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string ContentType { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsDefault { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string PublicUrl { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Person Person { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonPhotoScaled> PersonPhotoScaleds { get; set; }
    
    }
}
