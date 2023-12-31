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
    /// <summary>   A time zone. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class TimeZone : DbObjectBase
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
        public partial class TimeZone
        {
        	public TimeZone() : base()
        	{
        		Initialize();
        	}
        
        	public TimeZone(TimeZone e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(TimeZone e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.TimeZoneUid = e.TimeZoneUid;
        		this.Id = e.Id;
        		this.DisplayName = e.DisplayName;
        		this.StandardName = e.StandardName;
        		this.DaylightName = e.DaylightName;
        		this.SupportsDaylightSavingsTime = e.SupportsDaylightSavingsTime;
        		this.BaseUtcOffset = e.BaseUtcOffset;
        		
        	}
        
        	public TimeZone Clone(TimeZone e)
        	{
        		return new TimeZone(e);
        	}
        
        	public bool Equals(TimeZone other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(TimeZone other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.TimeZoneUid != this.TimeZoneUid )
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
    
    	
        /// <summary>   The time zone UID. </summary>
    	private System.Guid _timeZoneUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time zone UID. </summary>
        ///
        /// <value> The time zone UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid TimeZoneUid
    	{ 
    		get { return _timeZoneUid; }
    		set
    		{
    			if (_timeZoneUid != value )
    			{
    				_timeZoneUid = value;
    				OnPropertyChanged(() => TimeZoneUid);
    			}
    		}
    	}
    	
        /// <summary>   The identifier. </summary>
    	private string _id;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier. </summary>
        ///
        /// <value> The identifier. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Id
    	{ 
    		get { return _id; }
    		set
    		{
    			if (_id != value )
    			{
    				_id = value;
    				OnPropertyChanged(() => Id);
    			}
    		}
    	}
    	
        /// <summary>   Name of the display. </summary>
    	private string _displayName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the display. </summary>
        ///
        /// <value> The name of the display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string DisplayName
    	{ 
    		get { return _displayName; }
    		set
    		{
    			if (_displayName != value )
    			{
    				_displayName = value;
    				OnPropertyChanged(() => DisplayName);
    			}
    		}
    	}
    	
        /// <summary>   Name of the standard. </summary>
    	private string _standardName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the standard. </summary>
        ///
        /// <value> The name of the standard. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string StandardName
    	{ 
    		get { return _standardName; }
    		set
    		{
    			if (_standardName != value )
    			{
    				_standardName = value;
    				OnPropertyChanged(() => StandardName);
    			}
    		}
    	}
    	
        /// <summary>   Name of the daylight. </summary>
    	private string _daylightName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the daylight. </summary>
        ///
        /// <value> The name of the daylight. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string DaylightName
    	{ 
    		get { return _daylightName; }
    		set
    		{
    			if (_daylightName != value )
    			{
    				_daylightName = value;
    				OnPropertyChanged(() => DaylightName);
    			}
    		}
    	}
    	
        /// <summary>   True to supports daylight savings time. </summary>
    	private bool _supportsDaylightSavingsTime;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the supports daylight savings time.
        /// </summary>
        ///
        /// <value> True if supports daylight savings time, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool SupportsDaylightSavingsTime
    	{ 
    		get { return _supportsDaylightSavingsTime; }
    		set
    		{
    			if (_supportsDaylightSavingsTime != value )
    			{
    				_supportsDaylightSavingsTime = value;
    				OnPropertyChanged(() => SupportsDaylightSavingsTime);
    			}
    		}
    	}
    	
        /// <summary>   The base UTC offset. </summary>
    	private int _baseUtcOffset;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the base UTC offset. </summary>
        ///
        /// <value> The base UTC offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int BaseUtcOffset
    	{ 
    		get { return _baseUtcOffset; }
    		set
    		{
    			if (_baseUtcOffset != value )
    			{
    				_baseUtcOffset = value;
    				OnPropertyChanged(() => BaseUtcOffset);
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
                if (_insertName != value)
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
                if (_insertDate != value)
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
                if (_updateName != value)
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
                if (_updateDate != value)
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
                if (_concurrencyValue != value)
                {
                    _concurrencyValue = value;
                    OnPropertyChanged(() => ConcurrencyValue);
                }
            }
        }
    }

}
