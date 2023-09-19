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
	public partial class InputDeviceGalaxyHardwareAddress : DbObjectBase, ITableEntityBase
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
        public partial class InputDeviceGalaxyHardwareAddress
        {
        	public InputDeviceGalaxyHardwareAddress() : base()
        	{
        		Initialize();
        	}
        
        	public InputDeviceGalaxyHardwareAddress(InputDeviceGalaxyHardwareAddress e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(InputDeviceGalaxyHardwareAddress e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.InputDeviceGalaxyHardwareAddressUid = e.InputDeviceGalaxyHardwareAddressUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.GalaxyPanelUid = e.GalaxyPanelUid;
        		
        	}
        
        	public InputDeviceGalaxyHardwareAddress Clone(InputDeviceGalaxyHardwareAddress e)
        	{
        		return new InputDeviceGalaxyHardwareAddress(e);
        	}
        
        	public bool Equals(InputDeviceGalaxyHardwareAddress other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputDeviceGalaxyHardwareAddress other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputDeviceGalaxyHardwareAddressUid != this.InputDeviceGalaxyHardwareAddressUid )
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
    
    	
    	private System.Guid _inputDeviceGalaxyHardwareAddressUid;
    
    	[DataMember]
    	public System.Guid InputDeviceGalaxyHardwareAddressUid
    	{ 
    		get { return _inputDeviceGalaxyHardwareAddressUid; }
    		set
    		{
    			if (_inputDeviceGalaxyHardwareAddressUid != value )
    			{
    				_inputDeviceGalaxyHardwareAddressUid = value;
    				OnPropertyChanged(() => InputDeviceGalaxyHardwareAddressUid);
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
    	
    	private System.Guid _galaxyInterfaceBoardSectionNodeUid;
    
    	[DataMember]
    	public System.Guid GalaxyInterfaceBoardSectionNodeUid
    	{ 
    		get { return _galaxyInterfaceBoardSectionNodeUid; }
    		set
    		{
    			if (_galaxyInterfaceBoardSectionNodeUid != value )
    			{
    				_galaxyInterfaceBoardSectionNodeUid = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardSectionNodeUid);
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
    	
    	private System.Guid _galaxyPanelUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelUid
    	{ 
    		get { return _galaxyPanelUid; }
    		set
    		{
    			if (_galaxyPanelUid != value )
    			{
    				_galaxyPanelUid = value;
    				OnPropertyChanged(() => GalaxyPanelUid);
    			}
    		}
    	}
    
    	
    	private GalaxyInterfaceBoardSectionNode _galaxyInterfaceBoardSectionNode;
    
    	[DataMember]
    	public virtual GalaxyInterfaceBoardSectionNode GalaxyInterfaceBoardSectionNode
    	{ 
    		get { return _galaxyInterfaceBoardSectionNode; }
    		set
    		{
    			if (_galaxyInterfaceBoardSectionNode != value )
    			{
    				_galaxyInterfaceBoardSectionNode = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardSectionNode);
    			}
    		}
    	}
    	
    	private InputDevice _inputDevice;
    
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
