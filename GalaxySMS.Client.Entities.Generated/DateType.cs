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
	public partial class DateType : DbObjectBase, ITableEntityBase
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
        public partial class DateType
        {
        	public DateType() : base()
        	{
        		Initialize();
        	}
        
        	public DateType(DateType e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(DateType e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.DateTypeUid = e.DateTypeUid;
        		this.EntityId = e.EntityId;
        		this.DayTypeUid = e.DayTypeUid;
        		this.Date = e.Date;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.Title = e.Title;
        		
        	}
        
        	public DateType Clone(DateType e)
        	{
        		return new DateType(e);
        	}
        
        	public bool Equals(DateType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(DateType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.DateTypeUid != this.DateTypeUid )
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
    
    	
    	private System.Guid _dateTypeUid;
    
    	[DataMember]
    	public System.Guid DateTypeUid
    	{ 
    		get { return _dateTypeUid; }
    		set
    		{
    			if (_dateTypeUid != value )
    			{
    				_dateTypeUid = value;
    				OnPropertyChanged(() => DateTypeUid);
    			}
    		}
    	}
    	
    	private System.Guid _entityId;
    
    	[DataMember]
    	public System.Guid EntityId
    	{ 
    		get { return _entityId; }
    		set
    		{
    			if (_entityId != value )
    			{
    				_entityId = value;
    				OnPropertyChanged(() => EntityId);
    			}
    		}
    	}
    	
    	private System.Guid _dayTypeUid;
    
    	[DataMember]
    	public System.Guid DayTypeUid
    	{ 
    		get { return _dayTypeUid; }
    		set
    		{
    			if (_dayTypeUid != value )
    			{
    				_dayTypeUid = value;
    				OnPropertyChanged(() => DayTypeUid);
    			}
    		}
    	}
    	
    	private System.DateTime _date;
    
    	[DataMember]
    	public System.DateTime Date
    	{ 
    		get { return _date; }
    		set
    		{
    			if (_date != value )
    			{
    				_date = value;
    				OnPropertyChanged(() => Date);
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
    	
    	private string _title;
    
    	[DataMember]
    	public string Title
    	{ 
    		get { return _title; }
    		set
    		{
    			if (_title != value )
    			{
    				_title = value;
    				OnPropertyChanged(() => Title);
    			}
    		}
    	}
    
    	
    	private DayType _dayType;
    
    	[DataMember]
    	public virtual DayType DayType
    	{ 
    		get { return _dayType; }
    		set
    		{
    			if (_dayType != value )
    			{
    				_dayType = value;
    				OnPropertyChanged(() => DayType);
    			}
    		}
    	}
    }
    
}
