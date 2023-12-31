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
    /// <summary>   An input output group command audit. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class InputOutputGroupCommandAudit : DbObjectBase, ITableEntityBase
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
        public partial class InputOutputGroupCommandAudit
        {
        	public InputOutputGroupCommandAudit() : base()
        	{
        		Initialize();
        	}
        
        	public InputOutputGroupCommandAudit(InputOutputGroupCommandAudit e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(InputOutputGroupCommandAudit e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.InputOutputGroupCommandAuditUid = e.InputOutputGroupCommandAuditUid;
        		this.UserId = e.UserId;
        		this.InputOutputGroupCommandUid = e.InputOutputGroupCommandUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public InputOutputGroupCommandAudit Clone(InputOutputGroupCommandAudit e)
        	{
        		return new InputOutputGroupCommandAudit(e);
        	}
        
        	public bool Equals(InputOutputGroupCommandAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputOutputGroupCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputOutputGroupCommandAuditUid != this.InputOutputGroupCommandAuditUid )
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
    
    	
        /// <summary>   The input output group command audit UID. </summary>
    	private System.Guid _inputOutputGroupCommandAuditUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group command audit UID. </summary>
        ///
        /// <value> The input output group command audit UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid InputOutputGroupCommandAuditUid
    	{ 
    		get { return _inputOutputGroupCommandAuditUid; }
    		set
    		{
    			if (_inputOutputGroupCommandAuditUid != value )
    			{
    				_inputOutputGroupCommandAuditUid = value;
    				OnPropertyChanged(() => InputOutputGroupCommandAuditUid);
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
    	
        /// <summary>   The input output group command UID. </summary>
    	private System.Guid _inputOutputGroupCommandUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group command UID. </summary>
        ///
        /// <value> The input output group command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid InputOutputGroupCommandUid
    	{ 
    		get { return _inputOutputGroupCommandUid; }
    		set
    		{
    			if (_inputOutputGroupCommandUid != value )
    			{
    				_inputOutputGroupCommandUid = value;
    				OnPropertyChanged(() => InputOutputGroupCommandUid);
    			}
    		}
    	}
    	
        /// <summary>   The input output group UID. </summary>
    	private System.Guid _inputOutputGroupUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group UID. </summary>
        ///
        /// <value> The input output group UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid InputOutputGroupUid
    	{ 
    		get { return _inputOutputGroupUid; }
    		set
    		{
    			if (_inputOutputGroupUid != value )
    			{
    				_inputOutputGroupUid = value;
    				OnPropertyChanged(() => InputOutputGroupUid);
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
    	
        /// <summary>   Group the input output belongs to. </summary>
    	private InputOutputGroup _inputOutputGroup;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the group the input output belongs to. </summary>
        ///
        /// <value> The input output group. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual InputOutputGroup InputOutputGroup
    	{ 
    		get { return _inputOutputGroup; }
    		set
    		{
    			if (_inputOutputGroup != value )
    			{
    				_inputOutputGroup = value;
    				OnPropertyChanged(() => InputOutputGroup);
    			}
    		}
    	}
    	
        /// <summary>   The input output group command. </summary>
    	private InputOutputGroupCommand _inputOutputGroupCommand;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group command. </summary>
        ///
        /// <value> The input output group command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual InputOutputGroupCommand InputOutputGroupCommand
    	{ 
    		get { return _inputOutputGroupCommand; }
    		set
    		{
    			if (_inputOutputGroupCommand != value )
    			{
    				_inputOutputGroupCommand = value;
    				OnPropertyChanged(() => InputOutputGroupCommand);
    			}
    		}
    	}
    }
    
}
