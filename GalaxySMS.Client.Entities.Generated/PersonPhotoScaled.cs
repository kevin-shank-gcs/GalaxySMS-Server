//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    
	[DataContract]
	public partial class PersonPhotoScaled : DbObjectBase, ITableEntityBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class PersonPhotoScaled
        {
        	public PersonPhotoScaled() : base()
        	{
        		Initialize();
        	}
        
        	public PersonPhotoScaled(PersonPhotoScaled e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonPhotoScaled e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonPhotoScaledUid = e.PersonPhotoScaledUid;
        		this.PersonPhotoUid = e.PersonPhotoUid;
        		this.UniqueFilename = e.UniqueFilename;
        		this.PhotoImage = e.PhotoImage;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.Tag = e.Tag;
        		this.PublicUrl = e.PublicUrl;
        		
        	}
        
        	public PersonPhotoScaled Clone(PersonPhotoScaled e)
        	{
        		return new PersonPhotoScaled(e);
        	}
        
        	public bool Equals(PersonPhotoScaled other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonPhotoScaled other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonPhotoScaledUid != this.PersonPhotoScaledUid )
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
    
    	
    	private System.Guid _personPhotoScaledUid;
    
    	[DataMember]
    	public System.Guid PersonPhotoScaledUid
    	{ 
    		get { return _personPhotoScaledUid; }
    		set
    		{
    			if (_personPhotoScaledUid != value )
    			{
    				_personPhotoScaledUid = value;
    				OnPropertyChanged(() => PersonPhotoScaledUid);
    			}
    		}
    	}
    	
    	private System.Guid _personPhotoUid;
    
    	[DataMember]
    	public System.Guid PersonPhotoUid
    	{ 
    		get { return _personPhotoUid; }
    		set
    		{
    			if (_personPhotoUid != value )
    			{
    				_personPhotoUid = value;
    				OnPropertyChanged(() => PersonPhotoUid);
    			}
    		}
    	}
    	
    	private string _uniqueFilename;
    
    	[DataMember]
    	public string UniqueFilename
    	{ 
    		get { return _uniqueFilename; }
    		set
    		{
    			if (_uniqueFilename != value )
    			{
    				_uniqueFilename = value;
    				OnPropertyChanged(() => UniqueFilename);
    			}
    		}
    	}
    	
    	private byte[] _photoImage;
    
    	[DataMember]
    	public byte[] PhotoImage
    	{ 
    		get { return _photoImage; }
    		set
    		{
    			if (_photoImage != value )
    			{
    				_photoImage = value;
    				OnPropertyChanged(() => PhotoImage);
    			}
    		}
    	}
    	
    	private string _insertName;
    
    	[DataMember]
    	public string InsertName
    	{ 
    		get { return _insertName; }
    		set
    		{
    			if (_insertName != value )
    			{
    				_insertName = value;
    				OnPropertyChanged(() => InsertName);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTime> _insertDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> InsertDate
    	{ 
    		get { return _insertDate; }
    		set
    		{
    			if (_insertDate != value )
    			{
    				_insertDate = value;
    				OnPropertyChanged(() => InsertDate);
    			}
    		}
    	}
    	
    	private string _updateName;
    
    	[DataMember]
    	public string UpdateName
    	{ 
    		get { return _updateName; }
    		set
    		{
    			if (_updateName != value )
    			{
    				_updateName = value;
    				OnPropertyChanged(() => UpdateName);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTime> _updateDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> UpdateDate
    	{ 
    		get { return _updateDate; }
    		set
    		{
    			if (_updateDate != value )
    			{
    				_updateDate = value;
    				OnPropertyChanged(() => UpdateDate);
    			}
    		}
    	}
    	
    	private Nullable<short> _concurrencyValue;
    
    	[DataMember]
    	public Nullable<short> ConcurrencyValue
    	{ 
    		get { return _concurrencyValue; }
    		set
    		{
    			if (_concurrencyValue != value )
    			{
    				_concurrencyValue = value;
    				OnPropertyChanged(() => ConcurrencyValue);
    			}
    		}
    	}
    	
    	private string _tag;
    
    	[DataMember]
    	public string Tag
    	{ 
    		get { return _tag; }
    		set
    		{
    			if (_tag != value )
    			{
    				_tag = value;
    				OnPropertyChanged(() => Tag);
    			}
    		}
    	}
    	
    	private string _publicUrl;
    
    	[DataMember]
    	public string PublicUrl
    	{ 
    		get { return _publicUrl; }
    		set
    		{
    			if (_publicUrl != value )
    			{
    				_publicUrl = value;
    				OnPropertyChanged(() => PublicUrl);
    			}
    		}
    	}
    
    	
    	private PersonPhoto _personPhoto;
    
    	[DataMember]
    	public virtual PersonPhoto PersonPhoto
    	{ 
    		get { return _personPhoto; }
    		set
    		{
    			if (_personPhoto != value )
    			{
    				_personPhoto = value;
    				OnPropertyChanged(() => PersonPhoto);
    			}
    		}
    	}
    }
    
}
