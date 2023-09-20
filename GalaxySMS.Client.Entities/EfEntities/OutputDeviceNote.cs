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
	public partial class OutputDeviceNote : DbObjectBase, ITableEntityBase
    {
    	private System.Guid _inputDeviceNoteUid;
    
    	[DataMember]
    	public System.Guid OutputDeviceNoteUid
    	{ 
    		get { return _inputDeviceNoteUid; }
    		set
    		{
    			if (_inputDeviceNoteUid != value )
    			{
    				_inputDeviceNoteUid = value;
    				OnPropertyChanged(() => OutputDeviceNoteUid);
    			}
    		}
    	}
    	
    	private System.Guid _inputDeviceUid;
    
    	[DataMember]
    	public System.Guid OutputDeviceUid
    	{ 
    		get { return _inputDeviceUid; }
    		set
    		{
    			if (_inputDeviceUid != value )
    			{
    				_inputDeviceUid = value;
    				OnPropertyChanged(() => OutputDeviceUid);
    			}
    		}
    	}
    	
    	private System.Guid _noteUid;
    
    	[DataMember]
    	public System.Guid NoteUid
    	{ 
    		get { return _noteUid; }
    		set
    		{
    			if (_noteUid != value )
    			{
    				_noteUid = value;
    				OnPropertyChanged(() => NoteUid);
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
    
    	
    	private OutputDevice _inputDevice;
    
    	[DataMember]
    	public virtual OutputDevice OutputDevice
    	{ 
    		get { return _inputDevice; }
    		set
    		{
    			if (_inputDevice != value )
    			{
    				_inputDevice = value;
    				OnPropertyChanged(() => OutputDevice);
    			}
    		}
    	}
    	
    	private Note _note;
    
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
    }
    
}
