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
	public partial class MercScpType1 : DbObjectBase, ITableEntityBase
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
        public partial class MercScpType1
        {
        	public MercScpType1() : base()
        	{
        		Initialize();
        	}
        
        	public MercScpType1(MercScpType1 e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(MercScpType1 e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.MercScpTypeUid = e.MercScpTypeUid;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.TypeCode = e.TypeCode;
        		this.TypeCodeValue = e.TypeCodeValue;
        		this.MaxReaders = e.MaxReaders;
        		this.MaxInputs = e.MaxInputs;
        		this.MaxOutputs = e.MaxOutputs;
        		this.MaxSio485Ports = e.MaxSio485Ports;
        		this.OnboardReaders = e.OnboardReaders;
        		this.OnboardInputs = e.OnboardInputs;
        		this.OnboardOutputs = e.OnboardOutputs;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public MercScpType1 Clone(MercScpType1 e)
        	{
        		return new MercScpType1(e);
        	}
        
        	public bool Equals(MercScpType1 other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(MercScpType1 other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.MercScpTypeUid != this.MercScpTypeUid )
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
    
    	
    	private System.Guid _mercScpTypeUid;
    
    	[DataMember]
    	public System.Guid MercScpTypeUid
    	{ 
    		get { return _mercScpTypeUid; }
    		set
    		{
    			if (_mercScpTypeUid != value )
    			{
    				_mercScpTypeUid = value;
    				OnPropertyChanged(() => MercScpTypeUid);
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
    	
    	private string _typeCode;
    
    	[DataMember]
    	public string TypeCode
    	{ 
    		get { return _typeCode; }
    		set
    		{
    			if (_typeCode != value )
    			{
    				_typeCode = value;
    				OnPropertyChanged(() => TypeCode);
    			}
    		}
    	}
    	
    	private int _typeCodeValue;
    
    	[DataMember]
    	public int TypeCodeValue
    	{ 
    		get { return _typeCodeValue; }
    		set
    		{
    			if (_typeCodeValue != value )
    			{
    				_typeCodeValue = value;
    				OnPropertyChanged(() => TypeCodeValue);
    			}
    		}
    	}
    	
    	private int _maxReaders;
    
    	[DataMember]
    	public int MaxReaders
    	{ 
    		get { return _maxReaders; }
    		set
    		{
    			if (_maxReaders != value )
    			{
    				_maxReaders = value;
    				OnPropertyChanged(() => MaxReaders);
    			}
    		}
    	}
    	
    	private int _maxInputs;
    
    	[DataMember]
    	public int MaxInputs
    	{ 
    		get { return _maxInputs; }
    		set
    		{
    			if (_maxInputs != value )
    			{
    				_maxInputs = value;
    				OnPropertyChanged(() => MaxInputs);
    			}
    		}
    	}
    	
    	private int _maxOutputs;
    
    	[DataMember]
    	public int MaxOutputs
    	{ 
    		get { return _maxOutputs; }
    		set
    		{
    			if (_maxOutputs != value )
    			{
    				_maxOutputs = value;
    				OnPropertyChanged(() => MaxOutputs);
    			}
    		}
    	}
    	
    	private short _maxSio485Ports;
    
    	[DataMember]
    	public short MaxSio485Ports
    	{ 
    		get { return _maxSio485Ports; }
    		set
    		{
    			if (_maxSio485Ports != value )
    			{
    				_maxSio485Ports = value;
    				OnPropertyChanged(() => MaxSio485Ports);
    			}
    		}
    	}
    	
    	private short _onboardReaders;
    
    	[DataMember]
    	public short OnboardReaders
    	{ 
    		get { return _onboardReaders; }
    		set
    		{
    			if (_onboardReaders != value )
    			{
    				_onboardReaders = value;
    				OnPropertyChanged(() => OnboardReaders);
    			}
    		}
    	}
    	
    	private short _onboardInputs;
    
    	[DataMember]
    	public short OnboardInputs
    	{ 
    		get { return _onboardInputs; }
    		set
    		{
    			if (_onboardInputs != value )
    			{
    				_onboardInputs = value;
    				OnPropertyChanged(() => OnboardInputs);
    			}
    		}
    	}
    	
    	private short _onboardOutputs;
    
    	[DataMember]
    	public short OnboardOutputs
    	{ 
    		get { return _onboardOutputs; }
    		set
    		{
    			if (_onboardOutputs != value )
    			{
    				_onboardOutputs = value;
    				OnPropertyChanged(() => OnboardOutputs);
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
    }
    
}
