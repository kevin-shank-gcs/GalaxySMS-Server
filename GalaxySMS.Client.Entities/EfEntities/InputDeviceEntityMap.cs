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
    
	[DataContract]
	public partial class InputDeviceEntityMap : DbObjectBase, ITableEntityBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class InputDeviceEntityMap
        {
        	public InputDeviceEntityMap() : base()
        	{
        		Initialize();
        	}
        
        	public InputDeviceEntityMap(InputDeviceEntityMap e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(InputDeviceEntityMap e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.InputDeviceEntityMapUid = e.InputDeviceEntityMapUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.EntityId = e.EntityId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public InputDeviceEntityMap Clone(InputDeviceEntityMap e)
        	{
        		return new InputDeviceEntityMap(e);
        	}
        
        	public bool Equals(InputDeviceEntityMap other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputDeviceEntityMap other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputDeviceEntityMapUid != this.InputDeviceEntityMapUid )
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
    
    	
    	private System.Guid _inputDeviceEntityMapUid;
    
    	[DataMember]
    	public System.Guid InputDeviceEntityMapUid
    	{ 
    		get { return _inputDeviceEntityMapUid; }
    		set
    		{
    			if (_inputDeviceEntityMapUid != value )
    			{
    				_inputDeviceEntityMapUid = value;
    				OnPropertyChanged(() => InputDeviceEntityMapUid);
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
    	
    	private System.Guid _entityId;
    
    	[DataMember]
    	public System.Guid EntityId
    	{ 
    		get { return _entityId; }
    		set
    		{
    			if (_entityId != value )
    			{
    				_entityId = value;
    				OnPropertyChanged(() => EntityId);
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
    
    	
        /// <summary>   The gcs entity. </summary>
    	private gcsEntity _gcsEntity;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs entity. </summary>
        ///
        /// <value> The gcs entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual gcsEntity gcsEntity
    	{ 
    		get { return _gcsEntity; }
    		set
    		{
    			if (_gcsEntity != value )
    			{
    				_gcsEntity = value;
    				OnPropertyChanged(() => gcsEntity);
    			}
    		}
    	}
    }
    
}
