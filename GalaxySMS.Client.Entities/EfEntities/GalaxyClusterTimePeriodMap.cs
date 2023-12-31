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
    /// <summary>   Map of galaxy cluster time periods. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class GalaxyClusterTimePeriodMap : DbObjectBase
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
        public partial class GalaxyClusterTimePeriodMap1
        {
        	public GalaxyClusterTimePeriodMap1()
        	{
        		Initialize();
        	}
        
        	public GalaxyClusterTimePeriodMap1(GalaxyClusterTimePeriodMap1 e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        }
        
        	public void Initialize(GalaxyClusterTimePeriodMap1 e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.GalaxyClusterTimePeriodMapUid = e.GalaxyClusterTimePeriodMapUid;
        		this.TimePeriodUid = e.TimePeriodUid;
        		this.ClusterUid = e.ClusterUid;
        		this.PanelPeriodNumber = e.PanelPeriodNumber;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyClusterTimePeriodMap1 Clone(GalaxyClusterTimePeriodMap1 e)
        	{
        		return new GalaxyClusterTimePeriodMap1(e);
        	}
        
        	public bool Equals(GalaxyClusterTimePeriodMap1 other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyClusterTimePeriodMap1 other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyClusterTimePeriodMapUid != this.GalaxyClusterTimePeriodMapUid )
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
    
    	
        /// <summary>   The galaxy cluster time period map UID. </summary>
    	private System.Guid _galaxyClusterTimePeriodMapUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy cluster time period map UID. </summary>
        ///
        /// <value> The galaxy cluster time period map UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid GalaxyClusterTimePeriodMapUid
    	{ 
    		get { return _galaxyClusterTimePeriodMapUid; }
    		set
    		{
    			if (_galaxyClusterTimePeriodMapUid != value )
    			{
    				_galaxyClusterTimePeriodMapUid = value;
    				OnPropertyChanged(() => GalaxyClusterTimePeriodMapUid);
    			}
    		}
    	}
    	
        /// <summary>   The time period UID. </summary>
    	private System.Guid _timePeriodUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time period UID. </summary>
        ///
        /// <value> The time period UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid TimePeriodUid
    	{ 
    		get { return _timePeriodUid; }
    		set
    		{
    			if (_timePeriodUid != value )
    			{
    				_timePeriodUid = value;
    				OnPropertyChanged(() => TimePeriodUid);
    			}
    		}
    	}
    	
        /// <summary>   The cluster UID. </summary>
    	private System.Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid ClusterUid
    	{ 
    		get { return _clusterUid; }
    		set
    		{
    			if (_clusterUid != value )
    			{
    				_clusterUid = value;
    				OnPropertyChanged(() => ClusterUid);
    			}
    		}
    	}
    	
        /// <summary>   The panel period number. </summary>
    	private int _panelPeriodNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel period number. </summary>
        ///
        /// <value> The panel period number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int PanelPeriodNumber
    	{ 
    		get { return _panelPeriodNumber; }
    		set
    		{
    			if (_panelPeriodNumber != value )
    			{
    				_panelPeriodNumber = value;
    				OnPropertyChanged(() => PanelPeriodNumber, true, true);
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
    
    	
        /// <summary>   The cluster. </summary>
    	private Cluster _cluster;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster. </summary>
        ///
        /// <value> The cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual Cluster Cluster
    	{ 
    		get { return _cluster; }
    		set
    		{
    			if (_cluster != value )
    			{
    				_cluster = value;
    				OnPropertyChanged(() => Cluster);
    			}
    		}
    	}
    }
    
}
