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
	using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU model interface board section mode. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class GalaxyCpuModelInterfaceBoardSectionMode : DbObjectBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyCpuModelInterfaceBoardSectionMode
        {
        	public GalaxyCpuModelInterfaceBoardSectionMode()
        	{
        		Initialize();
        	}
        
        	public GalaxyCpuModelInterfaceBoardSectionMode(GalaxyCpuModelInterfaceBoardSectionMode e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        }
        
        	public void Initialize(GalaxyCpuModelInterfaceBoardSectionMode e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.GalaxyCpuModelInterfaceBoardSectionModeUid = e.GalaxyCpuModelInterfaceBoardSectionModeUid;
        		this.GalaxyCpuModelUid = e.GalaxyCpuModelUid;
        		this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyCpuModelInterfaceBoardSectionMode Clone(GalaxyCpuModelInterfaceBoardSectionMode e)
        	{
        		return new GalaxyCpuModelInterfaceBoardSectionMode(e);
        	}
        
        	public bool Equals(GalaxyCpuModelInterfaceBoardSectionMode other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyCpuModelInterfaceBoardSectionMode other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyCpuModelInterfaceBoardSectionModeUid != this.GalaxyCpuModelInterfaceBoardSectionModeUid )
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
    
    	
        /// <summary>   The galaxy CPU model interface board section mode UID. </summary>
    	private System.Guid _galaxyCpuModelInterfaceBoardSectionModeUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy CPU model interface board section mode UID. </summary>
        ///
        /// <value> The galaxy CPU model interface board section mode UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid GalaxyCpuModelInterfaceBoardSectionModeUid
    	{ 
    		get { return _galaxyCpuModelInterfaceBoardSectionModeUid; }
    		set
    		{
    			if (_galaxyCpuModelInterfaceBoardSectionModeUid != value )
    			{
    				_galaxyCpuModelInterfaceBoardSectionModeUid = value;
    				OnPropertyChanged(() => GalaxyCpuModelInterfaceBoardSectionModeUid);
    			}
    		}
    	}
    	
        /// <summary>   The galaxy CPU model UID. </summary>
    	private System.Guid _galaxyCpuModelUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy CPU model UID. </summary>
        ///
        /// <value> The galaxy CPU model UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid GalaxyCpuModelUid
    	{ 
    		get { return _galaxyCpuModelUid; }
    		set
    		{
    			if (_galaxyCpuModelUid != value )
    			{
    				_galaxyCpuModelUid = value;
    				OnPropertyChanged(() => GalaxyCpuModelUid);
    			}
    		}
    	}
    	
        /// <summary>   The interface board section mode UID. </summary>
    	private System.Guid _interfaceBoardSectionModeUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section mode UID. </summary>
        ///
        /// <value> The interface board section mode UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid InterfaceBoardSectionModeUid
    	{ 
    		get { return _interfaceBoardSectionModeUid; }
    		set
    		{
    			if (_interfaceBoardSectionModeUid != value )
    			{
    				_interfaceBoardSectionModeUid = value;
    				OnPropertyChanged(() => InterfaceBoardSectionModeUid);
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
    
    	
        /// <summary>   The galaxy CPU model. </summary>
    	private GalaxyCpuModel _galaxyCpuModel;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy CPU model. </summary>
        ///
        /// <value> The galaxy CPU model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual GalaxyCpuModel GalaxyCpuModel
    	{ 
    		get { return _galaxyCpuModel; }
    		set
    		{
    			if (_galaxyCpuModel != value )
    			{
    				_galaxyCpuModel = value;
    				OnPropertyChanged(() => GalaxyCpuModel);
    			}
    		}
    	}
    	
        /// <summary>   The interface board section mode. </summary>
    	private InterfaceBoardSectionMode _interfaceBoardSectionMode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section mode. </summary>
        ///
        /// <value> The interface board section mode. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual InterfaceBoardSectionMode InterfaceBoardSectionMode
    	{ 
    		get { return _interfaceBoardSectionMode; }
    		set
    		{
    			if (_interfaceBoardSectionMode != value )
    			{
    				_interfaceBoardSectionMode = value;
    				OnPropertyChanged(() => InterfaceBoardSectionMode);
    			}
    		}
    	}
    }
    
}
