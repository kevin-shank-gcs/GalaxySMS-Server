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
	public partial class PersonalAccessGroupAccessPortalTemp : DbObjectBase, ITableEntityBase
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
        public partial class PersonalAccessGroupAccessPortalTemp
        {
        	public PersonalAccessGroupAccessPortalTemp() : base()
        	{
        		Initialize();
        	}
        
        	public PersonalAccessGroupAccessPortalTemp(PersonalAccessGroupAccessPortalTemp e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonalAccessGroupAccessPortalTemp e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonalAccessGroupAccessPortalUid = e.PersonalAccessGroupAccessPortalUid;
        		this.PersonPersonalAccessGroupUid = e.PersonPersonalAccessGroupUid;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public PersonalAccessGroupAccessPortalTemp Clone(PersonalAccessGroupAccessPortalTemp e)
        	{
        		return new PersonalAccessGroupAccessPortalTemp(e);
        	}
        
        	public bool Equals(PersonalAccessGroupAccessPortalTemp other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonalAccessGroupAccessPortalTemp other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonalAccessGroupAccessPortalUid != this.PersonalAccessGroupAccessPortalUid )
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
    
    	
    	private System.Guid _personalAccessGroupAccessPortalUid;
    
    	[DataMember]
    	public System.Guid PersonalAccessGroupAccessPortalUid
    	{ 
    		get { return _personalAccessGroupAccessPortalUid; }
    		set
    		{
    			if (_personalAccessGroupAccessPortalUid != value )
    			{
    				_personalAccessGroupAccessPortalUid = value;
    				OnPropertyChanged(() => PersonalAccessGroupAccessPortalUid);
    			}
    		}
    	}
    	
    	private System.Guid _personPersonalAccessGroupUid;
    
    	[DataMember]
    	public System.Guid PersonPersonalAccessGroupUid
    	{ 
    		get { return _personPersonalAccessGroupUid; }
    		set
    		{
    			if (_personPersonalAccessGroupUid != value )
    			{
    				_personPersonalAccessGroupUid = value;
    				OnPropertyChanged(() => PersonPersonalAccessGroupUid);
    			}
    		}
    	}
    	
    	private System.Guid _accessPortalUid;
    
    	[DataMember]
    	public System.Guid AccessPortalUid
    	{ 
    		get { return _accessPortalUid; }
    		set
    		{
    			if (_accessPortalUid != value )
    			{
    				_accessPortalUid = value;
    				OnPropertyChanged(() => AccessPortalUid);
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
    }
    
}
