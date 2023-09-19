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
	using GCS.Core.Common.Contracts;	
    using FluentValidation;
    
	[DataContract]
	public partial class InputDeviceEventProperty : DbObjectBase, ITableEntityBase
    {
    	
    	private System.Guid _inputDeviceEventPropertiesUid;
    
    	[DataMember]
    	public System.Guid InputDeviceEventPropertiesUid
    	{ 
    		get { return _inputDeviceEventPropertiesUid; }
    		set
    		{
    			if (_inputDeviceEventPropertiesUid != value )
    			{
    				_inputDeviceEventPropertiesUid = value;
    				OnPropertyChanged(() => InputDeviceEventPropertiesUid);
    			}
    		}
    	}
    	
    	private System.Guid _inputDeviceUid;
    
    	[DataMember]
    	public System.Guid InputDeviceUid
    	{ 
    		get { return _inputDeviceUid; }
    		set
    		{
    			if (_inputDeviceUid != value )
    			{
    				_inputDeviceUid = value;
    				OnPropertyChanged(() => InputDeviceUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _audioBinaryResourceUid;
    
    	[DataMember]
    	public Nullable<System.Guid> AudioBinaryResourceUid
    	{ 
    		get { return _audioBinaryResourceUid; }
    		set
    		{
    			if (_audioBinaryResourceUid != value )
    			{
    				_audioBinaryResourceUid = value;
    				OnPropertyChanged(() => AudioBinaryResourceUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _userInstructionsNoteUid;
    
    	[DataMember]
    	public Nullable<System.Guid> UserInstructionsNoteUid
    	{ 
    		get { return _userInstructionsNoteUid; }
    		set
    		{
    			if (_userInstructionsNoteUid != value )
    			{
    				_userInstructionsNoteUid = value;
    				OnPropertyChanged(() => UserInstructionsNoteUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _acknowledgeTimeScheduleUid;
    
    	[DataMember]
    	public Nullable<System.Guid> AcknowledgeTimeScheduleUid
    	{ 
    		get { return _acknowledgeTimeScheduleUid; }
    		set
    		{
    			if (_acknowledgeTimeScheduleUid != value )
    			{
    				_acknowledgeTimeScheduleUid = value;
    				OnPropertyChanged(() => AcknowledgeTimeScheduleUid);
    			}
    		}
    	}
    	
    	private System.Guid _inputDeviceAlertEventTypeUid;
    
    	[DataMember]
    	public System.Guid InputDeviceAlertEventTypeUid
    	{ 
    		get { return _inputDeviceAlertEventTypeUid; }
    		set
    		{
    			if (_inputDeviceAlertEventTypeUid != value )
    			{
    				_inputDeviceAlertEventTypeUid = value;
    				OnPropertyChanged(() => InputDeviceAlertEventTypeUid);
    			}
    		}
    	}
    	
    	private int _acknowledgePriority;
    
    	[DataMember]
    	public int AcknowledgePriority
    	{ 
    		get { return _acknowledgePriority; }
    		set
    		{
    			if (_acknowledgePriority != value )
    			{
    				_acknowledgePriority = value;
    				OnPropertyChanged(() => AcknowledgePriority);
    			}
    		}
    	}

        private bool _isActive;

        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(() => IsActive);
                }
            }
        }


        private bool _responseRequired;

        [DataMember]
        public bool ResponseRequired
        {
            get { return _responseRequired; }
            set
            {
                if (_responseRequired != value)
                {
                    _responseRequired = value;
                    OnPropertyChanged(() => ResponseRequired);
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
    	
    	private System.DateTimeOffset _insertDate;
    
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
    	
    	private Nullable<System.DateTimeOffset> _updateDate;
    
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


        //private InputDevice _inputDevice;

        //[DataMember]
        //public virtual InputDevice InputDevice
        //{ 
        //	get { return _inputDevice; }
        //	set
        //	{
        //		if (_inputDevice != value )
        //		{
        //			_inputDevice = value;
        //			OnPropertyChanged(() => InputDevice);
        //		}
        //	}
        //}

        private InputDeviceAlertEventType _inputDeviceAlertEventType;

        [DataMember]
        public virtual InputDeviceAlertEventType InputDeviceAlertEventType
        {
            get { return _inputDeviceAlertEventType; }
            set
            {
                if (_inputDeviceAlertEventType != value)
                {
                    _inputDeviceAlertEventType = value;
                    OnPropertyChanged(() => InputDeviceAlertEventType);
                }
            }
        }

            	
        /// <summary>   The gcs binary resource. </summary>
        private gcsBinaryResource _gcsBinaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs binary resource. </summary>
        ///
        /// <value> The gcs binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual gcsBinaryResource gcsBinaryResource
        { 
            get { return _gcsBinaryResource; }
            set
            {
                if (_gcsBinaryResource != value )
                {
                    _gcsBinaryResource = value;
                    OnPropertyChanged(() => gcsBinaryResource);
                }
            }
        }


        /// <summary>   The note. </summary>
        private Note _note;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the note. </summary>
        ///
        /// <value> The note. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual Note Note
        { 
            get { return _note; }
            set
            {
                if (_note != value )
                {
                    _note = value;
                    OnPropertyChanged(() => Note);
                }
            }
        }

        public object PanelSpecificEditingData { get; set; }

    }
    
}
