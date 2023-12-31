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
    /// <summary>   A person credential command script. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class PersonCredentialCommandScript : DbObjectBase, ITableEntityBase
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
        public partial class PersonCredentialCommandScript
        {
        	public PersonCredentialCommandScript() : base()
        	{
        		Initialize();
        	}
        
        	public PersonCredentialCommandScript(PersonCredentialCommandScript e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonCredentialCommandScript e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonCredentialCommandScriptUid = e.PersonCredentialCommandScriptUid;
        		this.PersonCredentialUid = e.PersonCredentialUid;
        		this.CommandScriptUid = e.CommandScriptUid;
        		this.DelayedCommandScriptUid = e.DelayedCommandScriptUid;
        		this.DelayTime = e.DelayTime;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public PersonCredentialCommandScript Clone(PersonCredentialCommandScript e)
        	{
        		return new PersonCredentialCommandScript(e);
        	}
        
        	public bool Equals(PersonCredentialCommandScript other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonCredentialCommandScript other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonCredentialCommandScriptUid != this.PersonCredentialCommandScriptUid )
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
    
    	
        /// <summary>   The person credential command script UID. </summary>
    	private System.Guid _personCredentialCommandScriptUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person credential command script UID. </summary>
        ///
        /// <value> The person credential command script UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid PersonCredentialCommandScriptUid
    	{ 
    		get { return _personCredentialCommandScriptUid; }
    		set
    		{
    			if (_personCredentialCommandScriptUid != value )
    			{
    				_personCredentialCommandScriptUid = value;
    				OnPropertyChanged(() => PersonCredentialCommandScriptUid);
    			}
    		}
    	}
    	
        /// <summary>   The person credential UID. </summary>
    	private System.Guid _personCredentialUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person credential UID. </summary>
        ///
        /// <value> The person credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid PersonCredentialUid
    	{ 
    		get { return _personCredentialUid; }
    		set
    		{
    			if (_personCredentialUid != value )
    			{
    				_personCredentialUid = value;
    				OnPropertyChanged(() => PersonCredentialUid);
    			}
    		}
    	}
    	
        /// <summary>   The command script UID. </summary>
    	private System.Guid _commandScriptUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command script UID. </summary>
        ///
        /// <value> The command script UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid CommandScriptUid
    	{ 
    		get { return _commandScriptUid; }
    		set
    		{
    			if (_commandScriptUid != value )
    			{
    				_commandScriptUid = value;
    				OnPropertyChanged(() => CommandScriptUid);
    			}
    		}
    	}
    	
        /// <summary>   The delayed command script UID. </summary>
    	private Nullable<System.Guid> _delayedCommandScriptUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the delayed command script UID. </summary>
        ///
        /// <value> The delayed command script UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> DelayedCommandScriptUid
    	{ 
    		get { return _delayedCommandScriptUid; }
    		set
    		{
    			if (_delayedCommandScriptUid != value )
    			{
    				_delayedCommandScriptUid = value;
    				OnPropertyChanged(() => DelayedCommandScriptUid);
    			}
    		}
    	}
    	
        /// <summary>   The delay time. </summary>
    	private Nullable<System.DateTimeOffset> _delayTime;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the delay time. </summary>
        ///
        /// <value> The delay time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.DateTimeOffset> DelayTime
    	{ 
    		get { return _delayTime; }
    		set
    		{
    			if (_delayTime != value )
    			{
    				_delayTime = value;
    				OnPropertyChanged(() => DelayTime);
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
    
    	
        /// <summary>   The person credential. </summary>
    	private PersonCredential _personCredential;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person credential. </summary>
        ///
        /// <value> The person credential. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual PersonCredential PersonCredential
    	{ 
    		get { return _personCredential; }
    		set
    		{
    			if (_personCredential != value )
    			{
    				_personCredential = value;
    				OnPropertyChanged(() => PersonCredential);
    			}
    		}
    	}
    }
    
}
