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
	public partial class PersonPersonalAccessGroup : DbObjectBase, ITableEntityBase
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
        public partial class PersonPersonalAccessGroup
        {
        	public PersonPersonalAccessGroup() : base()
        	{
        		Initialize();
        	}
        
        	public PersonPersonalAccessGroup(PersonPersonalAccessGroup e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonPersonalAccessGroup e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
        		this.TimeScheduleUid = e.TimeScheduleUid;
        		this.ClusterUid = e.ClusterUid;
        		this.PersonalAccessGroupNumber = e.PersonalAccessGroupNumber;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public PersonPersonalAccessGroup Clone(PersonPersonalAccessGroup e)
        	{
        		return new PersonPersonalAccessGroup(e);
        	}
        
        	public bool Equals(PersonPersonalAccessGroup other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonPersonalAccessGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonClusterPermissionUid != this.PersonClusterPermissionUid )
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
    
    	
    	private System.Guid _personClusterPermissionUid;
    
    	[DataMember]
    	public System.Guid PersonClusterPermissionUid
    	{ 
    		get { return _personClusterPermissionUid; }
    		set
    		{
    			if (_personClusterPermissionUid != value )
    			{
    				_personClusterPermissionUid = value;
    				OnPropertyChanged(() => PersonClusterPermissionUid);
    			}
    		}
    	}
    	
    	private System.Guid _timeScheduleUid;
    
    	[DataMember]
    	public System.Guid TimeScheduleUid
    	{ 
    		get { return _timeScheduleUid; }
    		set
    		{
    			if (_timeScheduleUid != value )
    			{
    				_timeScheduleUid = value;
    				OnPropertyChanged(() => TimeScheduleUid);
    			}
    		}
    	}
    	
    	private System.Guid _clusterUid;
    
    	[DataMember]
    	public System.Guid ClusterUid
    	{ 
    		get { return _clusterUid; }
    		set
    		{
    			if (_clusterUid != value )
    			{
    				_clusterUid = value;
    				OnPropertyChanged(() => ClusterUid);
    			}
    		}
    	}
    	
    	private short _personalAccessGroupNumber;
    
    	[DataMember]
    	public short PersonalAccessGroupNumber
    	{ 
    		get { return _personalAccessGroupNumber; }
    		set
    		{
    			if (_personalAccessGroupNumber != value )
    			{
    				_personalAccessGroupNumber = value;
    				OnPropertyChanged(() => PersonalAccessGroupNumber);
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
    
    	
    	private PersonClusterPermission _personClusterPermission;
    
    	[DataMember]
    	public virtual PersonClusterPermission PersonClusterPermission
    	{ 
    		get { return _personClusterPermission; }
    		set
    		{
    			if (_personClusterPermission != value )
    			{
    				_personClusterPermission = value;
    				OnPropertyChanged(() => PersonClusterPermission);
    			}
    		}
    	}
    }
    
}
