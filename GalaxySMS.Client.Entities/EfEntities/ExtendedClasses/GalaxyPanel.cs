////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyPanel.cs
//
// summary:	Implements the galaxy panel class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Panel for editing the galaxy. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyPanel
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanel()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyPanel to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanel(GalaxyPanel e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyPanel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            //this.GalaxyPanelSites = new HashSet<GalaxyPanelSite>();
            this.Cpus = new ObservableCollection<GalaxyCpu>();
            this.InterfaceBoards = new ObservableCollection<GalaxyInterfaceBoard>();
            this.AlertEvents = new HashSet<GalaxyPanelAlertEvent>();

            InitializeAlertEventsCollection();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the alert events collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitializeAlertEventsCollection()
        {
            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always
                });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyPanel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyPanel to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(GalaxyPanel e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterUid = e.ClusterUid;
            this.PanelNumber = e.PanelNumber;
            this.PanelName = e.PanelName;
            this.Location = e.Location;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            //this.GalaxyPanelSites = e.GalaxyPanelSites.ToCollection();
            this.Cpus = e.Cpus.ToObservableCollection();
            this.InterfaceBoards = e.InterfaceBoards.ToObservableCollection();
            this.AlertEvents = e.AlertEvents.ToCollection();
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterName = e.ClusterName;
            this.TotalRowCount = e.TotalRowCount;
            this.InterfaceBoardCount = e.InterfaceBoardCount;
            this.ActiveCpuCount = e.ActiveCpuCount;
            this.AccessPortalCount = e.AccessPortalCount;
            this.InputDeviceCount = e.InputDeviceCount;
            this.OutputDeviceCount = e.OutputDeviceCount;
            this.ElevatorOutputCount = e.ElevatorOutputCount;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this GalaxyPanel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyPanel to process. </param>
        ///
        /// <returns>   A copy of this GalaxyPanel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanel Clone(GalaxyPanel e)
        {
            return new GalaxyPanel(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this GalaxyPanel is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(GalaxyPanel other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(GalaxyPanel other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelUid != this.GalaxyPanelUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }


        private PanelInqueryReply _panelInqueryReply;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel inquery reply. </summary>
        /// <remarks>   This is a client-side only property provided as a convenience. The client application can populate this property as status updates are received from the server</remarks>
        /// <value> The panel inquery reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelInqueryReply PanelInqueryReply
        {
            get { return _panelInqueryReply; }
            set
            {
                if (_panelInqueryReply != value)
                {
                    _panelInqueryReply = value;
                    OnPropertyChanged(() => PanelInqueryReply, false);
                }
            }
        }


        private LoggingStatusReply _loggingStatusReply;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the logging status reply. </summary>
        /// <remarks>   This is a client-side only property provided as a convenience. The client application can populate this property as status updates are received from the server</remarks>
        /// <value> The logging status reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public LoggingStatusReply LoggingStatusReply
        {
            get { return _loggingStatusReply; }
            set
            {
                if (_loggingStatusReply != value)
                {
                    _loggingStatusReply = value;
                    OnPropertyChanged(() => LoggingStatusReply, false);
                }
            }
        }

        private CredentialCountReply _credentialCountReply;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential count reply. </summary>
        /// <remarks>   This is a client-side only property provided as a convenience. The client application can populate this property as status updates are received from the server</remarks>
        /// <value> The credential count reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialCountReply CredentialCountReply
        {
            get { return _credentialCountReply; }
            set
            {
                if (_credentialCountReply != value)
                {
                    _credentialCountReply = value;
                    OnPropertyChanged(() => CredentialCountReply, false);
                }
            }
        }

        private int _TotalRowCount;

        [DataMember]
        public int TotalRowCount
        {
            get => _TotalRowCount;
            set
            {
                if (_TotalRowCount != value)
                {
                    _TotalRowCount = value;
                    OnPropertyChanged(() => TotalRowCount, false);
                }
            }
        }


        private int _interfaceBoardCount;

        [DataMember]
        public int InterfaceBoardCount
        {
            get { return _interfaceBoardCount; }
            set
            {
                if (_interfaceBoardCount != value)
                {
                    _interfaceBoardCount = value;
                    OnPropertyChanged(() => InterfaceBoardCount, false);
                }
            }
        }

        private int _activeCpuCount;

        [DataMember]
        public int ActiveCpuCount
        {
            get { return _activeCpuCount; }
            set
            {
                if (_activeCpuCount != value)
                {
                    _activeCpuCount = value;
                    OnPropertyChanged(() => ActiveCpuCount, false);
                }
            }
        }

        private int _AccessPortalCount;

        [DataMember]
        public int AccessPortalCount
        {
            get { return _AccessPortalCount; }
            set
            {
                if (_AccessPortalCount != value)
                {
                    _AccessPortalCount = value;
                    OnPropertyChanged(() => AccessPortalCount, false);
                }
            }
        }


        private int _InputDeviceCount;

        [DataMember]
        public int InputDeviceCount
        {
            get { return _InputDeviceCount; }
            set
            {
                if (_InputDeviceCount != value)
                {
                    _InputDeviceCount = value;
                    OnPropertyChanged(() => InputDeviceCount, false);
                }
            }
        }

        private int _OutputDeviceCount;

        [DataMember]
        public int OutputDeviceCount
        {
            get { return _OutputDeviceCount; }
            set
            {
                if (_OutputDeviceCount != value)
                {
                    _OutputDeviceCount = value;
                    OnPropertyChanged(() => OutputDeviceCount, false);
                }
            }
        }

        private int _ElevatorOutputCount;

        [DataMember]
        public int ElevatorOutputCount
        {
            get { return _ElevatorOutputCount; }
            set
            {
                if (_ElevatorOutputCount != value)
                {
                    _ElevatorOutputCount = value;
                    OnPropertyChanged(() => ElevatorOutputCount, false);
                }
            }
        }

        private string _clusterName;

        [DataMember]
        public string ClusterName
        {
            get { return _clusterName; }
            set
            {
                if (_clusterName != value)
                {
                    _clusterName = value;
                    OnPropertyChanged(() => ClusterName, false);
                }
            }
        }


    }
}