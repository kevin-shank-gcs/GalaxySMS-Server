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
    /// <summary>   Map of galaxy cluster time schedules. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class GalaxyClusterTimeScheduleMap : DbObjectBase
    {
        /// <summary>   The galaxy cluster time schedule map UID. </summary>
    	private System.Guid _galaxyClusterTimeScheduleMapUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy cluster time schedule map UID. </summary>
        ///
        /// <value> The galaxy cluster time schedule map UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid GalaxyClusterTimeScheduleMapUid
    	{ 
    		get { return _galaxyClusterTimeScheduleMapUid; }
    		set
    		{
    			if (_galaxyClusterTimeScheduleMapUid != value )
    			{
    				_galaxyClusterTimeScheduleMapUid = value;
    				OnPropertyChanged(() => GalaxyClusterTimeScheduleMapUid);
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
    	
        /// <summary>   The cluster UID. </summary>
    	private System.Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The panel schedule number. </summary>
    	private int _panelScheduleNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel schedule number. </summary>
        ///
        /// <value> The panel schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int PanelScheduleNumber
    	{ 
    		get { return _panelScheduleNumber; }
    		set
    		{
    			if (_panelScheduleNumber != value )
    			{
    				_panelScheduleNumber = value;
    				OnPropertyChanged(() => PanelScheduleNumber, true, true);
    			}
    		}
    	}


        /// <summary>   True to fifteen minute format uses holidays. </summary>
        private bool _fifteenMinuteFormatUsesHolidays;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the fifteen minute format uses holidays.
        /// </summary>
        ///
        /// <value> True if fifteen minute format uses holidays, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool FifteenMinuteFormatUsesHolidays 
        {
            get { return _fifteenMinuteFormatUsesHolidays; }
            set
            {
                if (_fifteenMinuteFormatUsesHolidays != value)
                {
                    _fifteenMinuteFormatUsesHolidays = value;
                    OnPropertyChanged(() => FifteenMinuteFormatUsesHolidays, true, true);
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
        
    }
    
}
