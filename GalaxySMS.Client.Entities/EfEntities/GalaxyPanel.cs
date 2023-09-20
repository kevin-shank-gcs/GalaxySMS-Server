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
	using System.Collections.ObjectModel;
	using System.Linq;

	////////////////////////////////////////////////////////////////////////////////////////////////////
	/// <summary>   Panel for editing the galaxy. </summary>
	///
	/// <remarks>   Kevin, 12/26/2018. </remarks>
	////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class GalaxyPanel : DbObjectBase
	{
		/// <summary>   The galaxy panel UID. </summary>
		private System.Guid _galaxyPanelUid;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the galaxy panel UID. </summary>
		///
		/// <value> The galaxy panel UID. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

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
		
		/// <summary>   The panel number. </summary>
		private int _panelNumber;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the panel number. </summary>
		///
		/// <value> The panel number. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public int PanelNumber
		{ 
			get { return _panelNumber; }
			set
			{
				if (_panelNumber != value )
				{
					_panelNumber = value;
					OnPropertyChanged(() => PanelNumber);
				}
			}
		}
		
		/// <summary>   Name of the panel. </summary>
		private string _panelName;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the name of the panel. </summary>
		///
		/// <value> The name of the panel. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string PanelName
		{ 
			get { return _panelName; }
			set
			{
				if (_panelName != value )
				{
					_panelName = value;
					OnPropertyChanged(() => PanelName);
				}
			}
		}
		
		/// <summary>   The location. </summary>
		private string _location;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the location. </summary>
		///
		/// <value> The location. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string Location
		{ 
			get { return _location; }
			set
			{
				if (_location != value )
				{
					_location = value;
					OnPropertyChanged(() => Location);
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
		
		/// <summary>   The galaxy panel model UID. </summary>
		private Nullable<System.Guid> _galaxyPanelModelUid;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the galaxy panel model UID. </summary>
		///
		/// <value> The galaxy panel model UID. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Nullable<System.Guid> GalaxyPanelModelUid
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
	
		
	 //   /// <summary>   The galaxy panel model. </summary>
		//private GalaxyPanelModel _galaxyPanelModel;

	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////
	 //   /// <summary>   Gets or sets the galaxy panel model. </summary>
	 //   ///
	 //   /// <value> The galaxy panel model. </value>
	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////

		//[DataMember]
		//public virtual GalaxyPanelModel GalaxyPanelModel
		//{ 
		//	get { return _galaxyPanelModel; }
		//	set
		//	{
		//		if (_galaxyPanelModel != value )
		//		{
		//			_galaxyPanelModel = value;
		//			OnPropertyChanged(() => GalaxyPanelModel);
		//		}
		//	}
		//}
		
	 //   /// <summary>   The galaxy panel sites. </summary>
		//private ICollection<GalaxyPanelSite> _galaxyPanelSites;

	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////
	 //   /// <summary>   Gets or sets the galaxy panel sites. </summary>
	 //   ///
	 //   /// <value> The galaxy panel sites. </value>
	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////

		//[DataMember]
		//public virtual ICollection<GalaxyPanelSite> GalaxyPanelSites
		//{ 
		//	get { return _galaxyPanelSites; }
		//	set
		//	{
		//		if (_galaxyPanelSites != value )
		//		{
		//			_galaxyPanelSites = value;
		//			OnPropertyChanged(() => GalaxyPanelSites);
		//		}
		//	}
		//}

		/// <summary>   The cpus. </summary>
		private ObservableCollection<GalaxyCpu> _cpus;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the cpus. </summary>
		///
		/// <value> The cpus. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public ObservableCollection<GalaxyCpu> Cpus
		{
			get { return _cpus; }
			set
			{
				if (_cpus != value)
				{
					_cpus = value;
					OnPropertyChanged(() => Cpus);
				}
			}
		}

		/// <summary>   The interface boards. </summary>
		private ObservableCollection<GalaxyInterfaceBoard> _interfaceBoards;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the interface boards. </summary>
		///
		/// <value> The interface boards. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public ObservableCollection<GalaxyInterfaceBoard> InterfaceBoards
		{
			get { return _interfaceBoards; }
			set
			{
				if (_interfaceBoards != value)
				{
					_interfaceBoards = value;
					OnPropertyChanged(() => InterfaceBoards);
				}
			}
		}


		/// <summary>   Identifier for the cluster group. </summary>
		private int _clusterGroupId;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the identifier of the cluster group. </summary>
		///
		/// <value> The identifier of the cluster group. </value>
		///=================================================================================================
		[DataMember]

		public int ClusterGroupId
		{
			get { return _clusterGroupId; }
			set
			{
				if (_clusterGroupId != value)
				{
					_clusterGroupId = value;
					OnPropertyChanged(() => ClusterGroupId, false);
				}
			}
		}

		/// <summary>   The cluster number. </summary>
		private int _clusterNumber;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the cluster number. </summary>
		///
		/// <value> The cluster number. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public int ClusterNumber
		{
			get { return _clusterNumber; }
			set
			{
				if (_clusterNumber != value)
				{
					_clusterNumber = value;
					OnPropertyChanged(() => ClusterNumber, false);
				}
			}
		}
		

		/// <summary>   The alert events. </summary>
		private ICollection<GalaxyPanelAlertEvent> _alertEvents;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the alert events. </summary>
		///
		/// <value> The alert events. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public ICollection<GalaxyPanelAlertEvent> AlertEvents
		{
			get { return _alertEvents; }
			set
			{
				if (_alertEvents != value)
				{
					_alertEvents = value;
					OnPropertyChanged(() => AlertEvents, false);
				}
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets the alert event low battery. </summary>
		///
		/// <value> The alert event low battery. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public GalaxyPanelAlertEvent AlertEventLowBattery
		{
			get
			{
				return AlertEvents.FirstOrDefault(a => a.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery);
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets the alert event a c failure. </summary>
		///
		/// <value> The alert event a c failure. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public GalaxyPanelAlertEvent AlertEventACFailure
		{
			get
			{
				return AlertEvents.FirstOrDefault(a => a.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure);
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets the alert event tamper. </summary>
		///
		/// <value> The alert event tamper. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public GalaxyPanelAlertEvent AlertEventTamper
		{
			get
			{
				return AlertEvents.FirstOrDefault(a => a.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper);
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets the alert event emergency unlock. </summary>
		///
		/// <value> The alert event emergency unlock. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public GalaxyPanelAlertEvent AlertEventEmergencyUnlock
		{
			get
			{
				return AlertEvents.FirstOrDefault(a => a.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock);
			}
		}
	}

}
