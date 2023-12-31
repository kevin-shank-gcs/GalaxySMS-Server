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
	using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An assa time schedule day period. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class AssaTimeScheduleDayPeriod : DbObjectBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class AssaTimeScheduleDayPeriod
        {
        	public AssaTimeScheduleDayPeriod()
        	{
        		Initialize();
        	}
        
        	public AssaTimeScheduleDayPeriod(AssaTimeScheduleDayPeriod e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        }
        
        	public void Initialize(AssaTimeScheduleDayPeriod e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.AssaTimeScheduleDayPeriodUid = e.AssaTimeScheduleDayPeriodUid;
        		this.TimeScheduleUid = e.TimeScheduleUid;
        		this.AssaDayPeriodUid = e.AssaDayPeriodUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AssaTimeScheduleDayPeriod Clone(AssaTimeScheduleDayPeriod e)
        	{
        		return new AssaTimeScheduleDayPeriod(e);
        	}
        
        	public bool Equals(AssaTimeScheduleDayPeriod other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AssaTimeScheduleDayPeriod other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AssaTimeScheduleDayPeriodUid != this.AssaTimeScheduleDayPeriodUid )
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
    
    	
        /// <summary>   The assa time schedule day period UID. </summary>
    	private System.Guid _assaTimeScheduleDayPeriodUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the assa time schedule day period UID. </summary>
        ///
        /// <value> The assa time schedule day period UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid AssaTimeScheduleDayPeriodUid
    	{ 
    		get { return _assaTimeScheduleDayPeriodUid; }
    		set
    		{
    			if (_assaTimeScheduleDayPeriodUid != value )
    			{
    				_assaTimeScheduleDayPeriodUid = value;
    				OnPropertyChanged(() => AssaTimeScheduleDayPeriodUid);
    			}
    		}
    	}
    	
        /// <summary>   The time schedule UID. </summary>
    	private System.Guid _timeScheduleUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time schedule UID. </summary>
        ///
        /// <value> The time schedule UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The assa day period UID. </summary>
    	private System.Guid _assaDayPeriodUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the assa day period UID. </summary>
        ///
        /// <value> The assa day period UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid AssaDayPeriodUid
    	{ 
    		get { return _assaDayPeriodUid; }
    		set
    		{
    			if (_assaDayPeriodUid != value )
    			{
    				_assaDayPeriodUid = value;
    				OnPropertyChanged(() => AssaDayPeriodUid);
    			}
    		}
    	}
    	
        /// <summary>   Name of the insert. </summary>
    	private string _insertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The insert date. </summary>
    	private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.DateTimeOffset InsertDate
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
    	
        /// <summary>   Name of the update. </summary>
    	private string _updateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The update. </summary>
    	private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.DateTimeOffset> UpdateDate
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
    	
        /// <summary>   The concurrency value. </summary>
    	private Nullable<short> _concurrencyValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        ///
        /// <value> The concurrency value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    
    	
        /// <summary>   The assa day period. </summary>
    	private AssaDayPeriod _assaDayPeriod;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the assa day period. </summary>
        ///
        /// <value> The assa day period. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual AssaDayPeriod AssaDayPeriod
    	{ 
    		get { return _assaDayPeriod; }
    		set
    		{
    			if (_assaDayPeriod != value )
    			{
    				_assaDayPeriod = value;
    				OnPropertyChanged(() => AssaDayPeriod);
    			}
    		}
    	}
    }
    
}
