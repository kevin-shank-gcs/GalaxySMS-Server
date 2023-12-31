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
    
	[DataContract]
	public partial class OutputCommand : DbObjectBase, ITableEntityBase
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
        public partial class OutputCommand
        {
        	public OutputCommand() : base()
        	{
        		Initialize();
        	}
        
        	public OutputCommand(OutputCommand e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.OutputCommandAudits = new HashSet<OutputCommandAudit>();
        		this.OutputCommandGalaxyOutputModes = new HashSet<OutputCommandGalaxyOutputMode>();
        }
        
        	public void Initialize(OutputCommand e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.OutputCommandUid = e.OutputCommandUid;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.CommandCode = e.CommandCode;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.OutputCommandAudits = e.OutputCommandAudits.ToCollection();
        		this.OutputCommandGalaxyOutputModes = e.OutputCommandGalaxyOutputModes.ToCollection();
        		
        	}
        
        	public OutputCommand Clone(OutputCommand e)
        	{
        		return new OutputCommand(e);
        	}
        
        	public bool Equals(OutputCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(OutputCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputCommandUid != this.OutputCommandUid )
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
    
    	
    	private System.Guid _outputCommandUid;
    
    	[DataMember]
    	public System.Guid OutputCommandUid
    	{ 
    		get { return _outputCommandUid; }
    		set
    		{
    			if (_outputCommandUid != value )
    			{
    				_outputCommandUid = value;
    				OnPropertyChanged(() => OutputCommandUid);
    			}
    		}
    	}
    	
    	private string _display;
    
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
    	
    	private Nullable<System.Guid> _displayResourceKey;
    
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
    	
    	private string _description;
    
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
    	
    	private Nullable<System.Guid> _descriptionResourceKey;
    
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
    	
    	private short _commandCode;
    
    	[DataMember]
    	public short CommandCode
    	{ 
    		get { return _commandCode; }
    		set
    		{
    			if (_commandCode != value )
    			{
    				_commandCode = value;
    				OnPropertyChanged(() => CommandCode);
    			}
    		}
    	}
    	
    	private Nullable<bool> _isActive;
    
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
    	
    	private Nullable<System.DateTime> _insertDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> InsertDate
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
    	
    	private Nullable<System.DateTime> _updateDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> UpdateDate
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
    
    	
    	private ICollection<OutputCommandAudit> _outputCommandAudits;
    
    	[DataMember]
    	public virtual ICollection<OutputCommandAudit> OutputCommandAudits
    	{ 
    		get { return _outputCommandAudits; }
    		set
    		{
    			if (_outputCommandAudits != value )
    			{
    				_outputCommandAudits = value;
    				OnPropertyChanged(() => OutputCommandAudits);
    			}
    		}
    	}
    	
    	private ICollection<OutputCommandGalaxyOutputMode> _outputCommandGalaxyOutputModes;
    
    	[DataMember]
    	public virtual ICollection<OutputCommandGalaxyOutputMode> OutputCommandGalaxyOutputModes
    	{ 
    		get { return _outputCommandGalaxyOutputModes; }
    		set
    		{
    			if (_outputCommandGalaxyOutputModes != value )
    			{
    				_outputCommandGalaxyOutputModes = value;
    				OnPropertyChanged(() => OutputCommandGalaxyOutputModes);
    			}
    		}
    	}
    }
    
}
