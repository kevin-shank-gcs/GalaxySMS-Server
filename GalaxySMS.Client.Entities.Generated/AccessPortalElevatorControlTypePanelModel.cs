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
	public partial class AccessPortalElevatorControlTypePanelModel : DbObjectBase, ITableEntityBase
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
        public partial class AccessPortalElevatorControlTypePanelModel
        {
        	public AccessPortalElevatorControlTypePanelModel() : base()
        	{
        		Initialize();
        	}
        
        	public AccessPortalElevatorControlTypePanelModel(AccessPortalElevatorControlTypePanelModel e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(AccessPortalElevatorControlTypePanelModel e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessPortalElevatorControlTypePanelModelUid = e.AccessPortalElevatorControlTypePanelModelUid;
        		this.AccessPortalElevatorControlTypeUid = e.AccessPortalElevatorControlTypeUid;
        		this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AccessPortalElevatorControlTypePanelModel Clone(AccessPortalElevatorControlTypePanelModel e)
        	{
        		return new AccessPortalElevatorControlTypePanelModel(e);
        	}
        
        	public bool Equals(AccessPortalElevatorControlTypePanelModel other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalElevatorControlTypePanelModel other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalElevatorControlTypePanelModelUid != this.AccessPortalElevatorControlTypePanelModelUid )
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
    
    	
    	private System.Guid _accessPortalElevatorControlTypePanelModelUid;
    
    	[DataMember]
    	public System.Guid AccessPortalElevatorControlTypePanelModelUid
    	{ 
    		get { return _accessPortalElevatorControlTypePanelModelUid; }
    		set
    		{
    			if (_accessPortalElevatorControlTypePanelModelUid != value )
    			{
    				_accessPortalElevatorControlTypePanelModelUid = value;
    				OnPropertyChanged(() => AccessPortalElevatorControlTypePanelModelUid);
    			}
    		}
    	}
    	
    	private System.Guid _accessPortalElevatorControlTypeUid;
    
    	[DataMember]
    	public System.Guid AccessPortalElevatorControlTypeUid
    	{ 
    		get { return _accessPortalElevatorControlTypeUid; }
    		set
    		{
    			if (_accessPortalElevatorControlTypeUid != value )
    			{
    				_accessPortalElevatorControlTypeUid = value;
    				OnPropertyChanged(() => AccessPortalElevatorControlTypeUid);
    			}
    		}
    	}
    	
    	private System.Guid _galaxyPanelModelUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelModelUid
    	{ 
    		get { return _galaxyPanelModelUid; }
    		set
    		{
    			if (_galaxyPanelModelUid != value )
    			{
    				_galaxyPanelModelUid = value;
    				OnPropertyChanged(() => GalaxyPanelModelUid);
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
    
    	
    	private AccessPortalElevatorControlType _accessPortalElevatorControlType;
    
    	[DataMember]
    	public virtual AccessPortalElevatorControlType AccessPortalElevatorControlType
    	{ 
    		get { return _accessPortalElevatorControlType; }
    		set
    		{
    			if (_accessPortalElevatorControlType != value )
    			{
    				_accessPortalElevatorControlType = value;
    				OnPropertyChanged(() => AccessPortalElevatorControlType);
    			}
    		}
    	}
    	
    	private GalaxyPanelModel _galaxyPanelModel;
    
    	[DataMember]
    	public virtual GalaxyPanelModel GalaxyPanelModel
    	{ 
    		get { return _galaxyPanelModel; }
    		set
    		{
    			if (_galaxyPanelModel != value )
    			{
    				_galaxyPanelModel = value;
    				OnPropertyChanged(() => GalaxyPanelModel);
    			}
    		}
    	}
    }
    
}
