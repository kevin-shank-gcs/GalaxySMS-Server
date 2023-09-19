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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input command audit. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class InputCommandAudit : DbObjectBase, ITableEntityBase
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
        public partial class InputCommandAudit
        {
        	public InputCommandAudit() : base()
        	{
        		Initialize();
        	}
        
        	public InputCommandAudit(InputCommandAudit e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(InputCommandAudit e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.InputCommandAuditUid = e.InputCommandAuditUid;
        		this.UserId = e.UserId;
        		this.InputCommandUid = e.InputCommandUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public InputCommandAudit Clone(InputCommandAudit e)
        	{
        		return new InputCommandAudit(e);
        	}
        
        	public bool Equals(InputCommandAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputCommandAuditUid != this.InputCommandAuditUid )
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
    
    	
        /// <summary>   The input command audit UID. </summary>
    	private System.Guid _inputCommandAuditUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input command audit UID. </summary>
        ///
        /// <value> The input command audit UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid InputCommandAuditUid
    	{ 
    		get { return _inputCommandAuditUid; }
    		set
    		{
    			if (_inputCommandAuditUid != value )
    			{
    				_inputCommandAuditUid = value;
    				OnPropertyChanged(() => InputCommandAuditUid);
    			}
    		}
    	}
    	
        /// <summary>   Identifier for the user. </summary>
    	private System.Guid _userId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the user. </summary>
        ///
        /// <value> The identifier of the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid UserId
    	{ 
    		get { return _userId; }
    		set
    		{
    			if (_userId != value )
    			{
    				_userId = value;
    				OnPropertyChanged(() => UserId);
    			}
    		}
    	}
    	
        /// <summary>   The input command UID. </summary>
    	private System.Guid _inputCommandUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input command UID. </summary>
        ///
        /// <value> The input command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid InputCommandUid
    	{ 
    		get { return _inputCommandUid; }
    		set
    		{
    			if (_inputCommandUid != value )
    			{
    				_inputCommandUid = value;
    				OnPropertyChanged(() => InputCommandUid);
    			}
    		}
    	}
    	
        /// <summary>   The input device UID. </summary>
    	private System.Guid _inputDeviceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input device UID. </summary>
        ///
        /// <value> The input device UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
    
    	
        /// <summary>   The gcs user. </summary>
    	private gcsUser _gcsUser;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs user. </summary>
        ///
        /// <value> The gcs user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual gcsUser gcsUser
    	{ 
    		get { return _gcsUser; }
    		set
    		{
    			if (_gcsUser != value )
    			{
    				_gcsUser = value;
    				OnPropertyChanged(() => gcsUser);
    			}
    		}
    	}
    	
        /// <summary>   The input command. </summary>
    	private InputCommand _inputCommand;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input command. </summary>
        ///
        /// <value> The input command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual InputCommand InputCommand
    	{ 
    		get { return _inputCommand; }
    		set
    		{
    			if (_inputCommand != value )
    			{
    				_inputCommand = value;
    				OnPropertyChanged(() => InputCommand);
    			}
    		}
    	}
    	
        /// <summary>   The input device. </summary>
    	private InputDevice _inputDevice;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input device. </summary>
        ///
        /// <value> The input device. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual InputDevice InputDevice
    	{ 
    		get { return _inputDevice; }
    		set
    		{
    			if (_inputDevice != value )
    			{
    				_inputDevice = value;
    				OnPropertyChanged(() => InputDevice);
    			}
    		}
    	}
    }
    
}
