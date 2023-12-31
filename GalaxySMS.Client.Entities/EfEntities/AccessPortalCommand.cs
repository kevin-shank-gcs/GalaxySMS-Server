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
    /// <summary>   The access portal command. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class AccessPortalCommand : DbObjectBase, ITableEntityBase
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
        public partial class AccessPortalCommand
        {
        	public AccessPortalCommand() : base()
        	{
        		Initialize();
        	}
        
        	public AccessPortalCommand(AccessPortalCommand e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.AccessPortalCommandAudits = new HashSet<AccessPortalCommandAudit>();
        		this.AccessPortalTypeAccessPortalCommands = new HashSet<AccessPortalTypeAccessPortalCommand>();
        }
        
        	public void Initialize(AccessPortalCommand e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessPortalCommandUid = e.AccessPortalCommandUid;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.AccessPortalCommandAudits = e.AccessPortalCommandAudits.ToCollection();
        		this.AccessPortalTypeAccessPortalCommands = e.AccessPortalTypeAccessPortalCommands.ToCollection();
        		
        	}
        
        	public AccessPortalCommand Clone(AccessPortalCommand e)
        	{
        		return new AccessPortalCommand(e);
        	}
        
        	public bool Equals(AccessPortalCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalCommandUid != this.AccessPortalCommandUid )
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
    
    	
        /// <summary>   The access portal command UID. </summary>
    	private System.Guid _accessPortalCommandUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal command UID. </summary>
        ///
        /// <value> The access portal command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid AccessPortalCommandUid
    	{ 
    		get { return _accessPortalCommandUid; }
    		set
    		{
    			if (_accessPortalCommandUid != value )
    			{
    				_accessPortalCommandUid = value;
    				OnPropertyChanged(() => AccessPortalCommandUid);
    			}
    		}
    	}
    	
        /// <summary>   The display. </summary>
    	private string _display;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display. </summary>
        ///
        /// <value> The display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Display
    	{ 
    		get { return _display; }
    		set
    		{
    			if (_display != value )
    			{
    				_display = value;
    				OnPropertyChanged(() => Display);
    			}
    		}
    	}
    	
        /// <summary>   The display resource key. </summary>
    	private Nullable<System.Guid> _displayResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display resource key. </summary>
        ///
        /// <value> The display resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> DisplayResourceKey
    	{ 
    		get { return _displayResourceKey; }
    		set
    		{
    			if (_displayResourceKey != value )
    			{
    				_displayResourceKey = value;
    				OnPropertyChanged(() => DisplayResourceKey);
    			}
    		}
    	}
    	
        /// <summary>   The description. </summary>
    	private string _description;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Description
    	{ 
    		get { return _description; }
    		set
    		{
    			if (_description != value )
    			{
    				_description = value;
    				OnPropertyChanged(() => Description);
    			}
    		}
    	}
    	
        /// <summary>   The description resource key. </summary>
    	private Nullable<System.Guid> _descriptionResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description resource key. </summary>
        ///
        /// <value> The description resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> DescriptionResourceKey
    	{ 
    		get { return _descriptionResourceKey; }
    		set
    		{
    			if (_descriptionResourceKey != value )
    			{
    				_descriptionResourceKey = value;
    				OnPropertyChanged(() => DescriptionResourceKey);
    			}
    		}
    	}
    	
        /// <summary>   The is active. </summary>
    	private Nullable<bool> _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the is active. </summary>
        ///
        /// <value> The is active. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<bool> IsActive
    	{ 
    		get { return _isActive; }
    		set
    		{
    			if (_isActive != value )
    			{
    				_isActive = value;
    				OnPropertyChanged(() => IsActive);
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
    
    	
        /// <summary>   The access portal command audits. </summary>
    	private ICollection<AccessPortalCommandAudit> _accessPortalCommandAudits;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal command audits. </summary>
        ///
        /// <value> The access portal command audits. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual ICollection<AccessPortalCommandAudit> AccessPortalCommandAudits
    	{ 
    		get { return _accessPortalCommandAudits; }
    		set
    		{
    			if (_accessPortalCommandAudits != value )
    			{
    				_accessPortalCommandAudits = value;
    				OnPropertyChanged(() => AccessPortalCommandAudits);
    			}
    		}
    	}
    	
     //   /// <summary>   The access portal type access portal commands. </summary>
    	//private ICollection<AccessPortalTypeAccessPortalCommand> _accessPortalTypeAccessPortalCommands;

     //   ////////////////////////////////////////////////////////////////////////////////////////////////////
     //   /// <summary>   Gets or sets the access portal type access portal commands. </summary>
     //   ///
     //   /// <value> The access portal type access portal commands. </value>
     //   ////////////////////////////////////////////////////////////////////////////////////////////////////

    	//[DataMember]
    	//public virtual ICollection<AccessPortalTypeAccessPortalCommand> AccessPortalTypeAccessPortalCommands
    	//{ 
    	//	get { return _accessPortalTypeAccessPortalCommands; }
    	//	set
    	//	{
    	//		if (_accessPortalTypeAccessPortalCommands != value )
    	//		{
    	//			_accessPortalTypeAccessPortalCommands = value;
    	//			OnPropertyChanged(() => AccessPortalTypeAccessPortalCommands);
    	//		}
    	//	}
    	//}
    }
    
}
