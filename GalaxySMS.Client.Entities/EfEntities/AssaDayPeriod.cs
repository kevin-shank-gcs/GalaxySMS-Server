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
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Contracts;
    using System.Collections.ObjectModel;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An assa day period. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
	public partial class AssaDayPeriod : DbObjectBase, IHasEntityMappingList
    {  	
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
    	
        /// <summary>   Identifier for the entity. </summary>
    	private System.Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    	
        /// <summary>   The name. </summary>
    	private string _name;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Name
    	{ 
    		get { return _name; }
    		set
    		{
    			if (_name != value )
    			{
    				_name = value;
    				OnPropertyChanged(() => Name);
    			}
    		}
    	}
    	
        /// <summary>   True to sunday. </summary>
    	private bool _sunday;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the sunday. </summary>
        ///
        /// <value> True if sunday, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool Sunday
    	{ 
    		get { return _sunday; }
    		set
    		{
    			if (_sunday != value )
    			{
    				_sunday = value;
    				OnPropertyChanged(() => Sunday);
    			}
    		}
    	}
    	
        /// <summary>   True to monday. </summary>
    	private bool _monday;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the monday. </summary>
        ///
        /// <value> True if monday, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool Monday
    	{ 
    		get { return _monday; }
    		set
    		{
    			if (_monday != value )
    			{
    				_monday = value;
    				OnPropertyChanged(() => Monday);
    			}
    		}
    	}
    	
        /// <summary>   True to tuesday. </summary>
    	private bool _tuesday;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the tuesday. </summary>
        ///
        /// <value> True if tuesday, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool Tuesday
    	{ 
    		get { return _tuesday; }
    		set
    		{
    			if (_tuesday != value )
    			{
    				_tuesday = value;
    				OnPropertyChanged(() => Tuesday);
    			}
    		}
    	}
    	
        /// <summary>   True to wednesday. </summary>
    	private bool _wednesday;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the wednesday. </summary>
        ///
        /// <value> True if wednesday, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool Wednesday
    	{ 
    		get { return _wednesday; }
    		set
    		{
    			if (_wednesday != value )
    			{
    				_wednesday = value;
    				OnPropertyChanged(() => Wednesday);
    			}
    		}
    	}
    	
        /// <summary>   True to thursday. </summary>
    	private bool _thursday;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the thursday. </summary>
        ///
        /// <value> True if thursday, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool Thursday
    	{ 
    		get { return _thursday; }
    		set
    		{
    			if (_thursday != value )
    			{
    				_thursday = value;
    				OnPropertyChanged(() => Thursday);
    			}
    		}
    	}
    	
        /// <summary>   True to friday. </summary>
    	private bool _friday;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the friday. </summary>
        ///
        /// <value> True if friday, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool Friday
    	{ 
    		get { return _friday; }
    		set
    		{
    			if (_friday != value )
    			{
    				_friday = value;
    				OnPropertyChanged(() => Friday);
    			}
    		}
    	}
    	
        /// <summary>   True to saturday. </summary>
    	private bool _saturday;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the saturday. </summary>
        ///
        /// <value> True if saturday, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool Saturday
    	{ 
    		get { return _saturday; }
    		set
    		{
    			if (_saturday != value )
    			{
    				_saturday = value;
    				OnPropertyChanged(() => Saturday);
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
    	
        /// <summary>   Identifier for the assa dsr day period. </summary>
    	private string _assaDsrDayPeriodId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the assa dsr day period. </summary>
        ///
        /// <value> The identifier of the assa dsr day period. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string AssaDsrDayPeriodId
    	{ 
    		get { return _assaDsrDayPeriodId; }
    		set
    		{
    			if (_assaDsrDayPeriodId != value )
    			{
    				_assaDsrDayPeriodId = value;
    				OnPropertyChanged(() => AssaDsrDayPeriodId);
    			}
    		}
    	}
    
    	
        /// <summary>   The gcs entity. </summary>
    	private gcsEntity _gcsEntity;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs entity. </summary>
        ///
        /// <value> The gcs entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual gcsEntity gcsEntity
    	{ 
    		get { return _gcsEntity; }
    		set
    		{
    			if (_gcsEntity != value )
    			{
    				_gcsEntity = value;
    				OnPropertyChanged(() => gcsEntity);
    			}
    		}
    	}
    	
        /// <summary>   The assa day period time periods. </summary>
    	private ICollection<AssaDayPeriodTimePeriod> _assaDayPeriodTimePeriods;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the assa day period time periods. </summary>
        ///
        /// <value> The assa day period time periods. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual ICollection<AssaDayPeriodTimePeriod> AssaDayPeriodTimePeriods
    	{ 
    		get { return _assaDayPeriodTimePeriods; }
    		set
    		{
    			if (_assaDayPeriodTimePeriods != value )
    			{
    				_assaDayPeriodTimePeriods = value;
    				OnPropertyChanged(() => AssaDayPeriodTimePeriods);
    			}
    		}
    	}
    	
        /// <summary>   The assa time schedule day periods. </summary>
    	private ICollection<AssaTimeScheduleDayPeriod> _assaTimeScheduleDayPeriods;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the assa time schedule day periods. </summary>
        ///
        /// <value> The assa time schedule day periods. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual ICollection<AssaTimeScheduleDayPeriod> AssaTimeScheduleDayPeriods
    	{ 
    		get { return _assaTimeScheduleDayPeriods; }
    		set
    		{
    			if (_assaTimeScheduleDayPeriods != value )
    			{
    				_assaTimeScheduleDayPeriods = value;
    				OnPropertyChanged(() => AssaTimeScheduleDayPeriods);
    			}
    		}
    	}

        /// <summary>   The time periods. </summary>
        private ObservableCollection<TimePeriod> _timePeriods;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time periods. </summary>
        ///
        /// <value> The time periods. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ObservableCollection<TimePeriod> TimePeriods
        {
            get { return _timePeriods; }
            set
            {
                if (_timePeriods != value)
                {
                    _timePeriods = value;
                    OnPropertyChanged(() => TimePeriods);
                }
            }
        }

        #region Implementation of IHasEntityMappingList

        /// <summary>   List of identifiers for the entities. </summary>
        private ICollection<Guid> _entityIds;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the entities. </summary>
        ///
        /// <value> A list of identifiers of the entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<Guid> EntityIds
        {
            get { return _entityIds; }
            set
            {
                if (_entityIds != value)
                {
                    _entityIds = value;
                    OnPropertyChanged(() => EntityIds);
                }
            }
        }

        /// <summary>   The mapped entities permission levels. </summary>
        private ICollection<EntityIdEntityMapPermissionLevel> _MappedEntitiesPermissionLevels;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mapped entities permission levels. </summary>
        ///
        /// <value> The mapped entities permission levels. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels
        {
            get { return _MappedEntitiesPermissionLevels; }
            set
            {
                if (_MappedEntitiesPermissionLevels != value)
                {
                    _MappedEntitiesPermissionLevels = value;
                    OnPropertyChanged(() => MappedEntitiesPermissionLevels);
                }
            }
        }
        #endregion
    }
    
}
