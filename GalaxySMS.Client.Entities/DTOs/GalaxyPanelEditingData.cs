////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GalaxyPanelEditingData.cs
//
// summary:	Implements the galaxy panel editing data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy panel editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GalaxyPanelEditingData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelEditingData()
        {
            PanelModels = new List<GalaxyPanelModel>();
            CpuModels = new List<GalaxyCpuModel>();
            InterfaceBoardTypes = new List<InterfaceBoardType>();
            InterfaceBoardSectionModes = new List<InterfaceBoardSectionMode>();
            GalaxyHardwareModuleTypes = new List<GalaxyHardwareModuleType>();
            BoardTypeBoardSectionModes = new List<KeyValuePair<Guid, ObservableCollection<InterfaceBoardSectionMode>>>();
            InputOutputGroups = new List<InputOutputGroup>();
            TimeSchedules = new List<TimeSchedule>();
            AlertEventTypes = new List<GalaxyPanelAlertEventType>();

        }

        /// <summary>   The panel models. </summary>
        private IList<GalaxyPanelModel> _panelModels;
        /// <summary>   The CPU models. </summary>
        private IList<GalaxyCpuModel> _cpuModels;
        /// <summary>   List of types of the interface boards. </summary>
        private IList<InterfaceBoardType> _interfaceBoardTypes;
        /// <summary>   The interface board section modes. </summary>
        private IList<InterfaceBoardSectionMode> _interfaceBoardSectionModes;
        /// <summary>   List of types of the galaxy hardware modules. </summary>
        private IList<GalaxyHardwareModuleType> _galaxyHardwareModuleTypes;

        /// <summary>   Groups the input output belongs to. </summary>
        private IList<InputOutputGroup> _inputOutputGroups;
        private Guid _showDataForPanelModel;
        private IList<TimeSchedule> _timeSchedules;
        private IList<GalaxyPanelAlertEventType> _alertEventTypes;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel models. </summary>
        ///
        /// <value> The panel models. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyPanelModel> PanelModels
        {
            get { return _panelModels; }
            set
            {
                if (_panelModels != value)
                {
                    _panelModels = value;
                    OnPropertyChanged(() => PanelModels, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU models. </summary>
        ///
        /// <value> The CPU models. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyCpuModel> CpuModels
        {
            get { return _cpuModels; }
            set
            {
                if (_cpuModels != value)
                {
                    _cpuModels = value;
                    OnPropertyChanged(() => CpuModels, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the interface boards. </summary>
        ///
        /// <value> A list of types of the interface boards. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<InterfaceBoardType> InterfaceBoardTypes
        {
            get
            {
                if (this.ShowDataForPanelModel == Guid.Empty)
                    return _interfaceBoardTypes;
                return _interfaceBoardTypes.Where(i => i.GalaxyPanelModelUids.Contains(ShowDataForPanelModel)).OrderBy(i => i.Display).ToList();
            }
            set
            {
                if (_interfaceBoardTypes != value)
                {
                    _interfaceBoardTypes = value;
                    OnPropertyChanged(() => InterfaceBoardTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section modes. </summary>
        ///
        /// <value> The interface board section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<InterfaceBoardSectionMode> InterfaceBoardSectionModes
        {
            get { return _interfaceBoardSectionModes; }
            set
            {
                if (_interfaceBoardSectionModes != value)
                {
                    _interfaceBoardSectionModes = value;
                    OnPropertyChanged(() => InterfaceBoardSectionModes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the galaxy hardware modules. </summary>
        ///
        /// <value> A list of types of the galaxy hardware modules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyHardwareModuleType> GalaxyHardwareModuleTypes
        {
            get { return _galaxyHardwareModuleTypes; }
            set
            {
                if (_galaxyHardwareModuleTypes != value)
                {
                    _galaxyHardwareModuleTypes = value;
                    OnPropertyChanged(() => GalaxyHardwareModuleTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time schedules. </summary>
        ///
        /// <value> The time schedules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<TimeSchedule> TimeSchedules
        {
            get { return _timeSchedules; }
            set
            {
                if (_timeSchedules != value)
                {
                    _timeSchedules = value;
                    OnPropertyChanged(() => TimeSchedules, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the groups the input output belongs to. </summary>
        ///
        /// <value> The input output groups. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<InputOutputGroup> InputOutputGroups
        {
            get { return _inputOutputGroups; }
            set
            {
                if (_inputOutputGroups != value)
                {
                    _inputOutputGroups = value;
                    OnPropertyChanged(() => InputOutputGroups, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the show data for panel model. </summary>
        ///
        /// <value> The show data for panel model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid ShowDataForPanelModel
        {
            get { return _showDataForPanelModel; }
            set
            {
                if (_showDataForPanelModel != value)
                {
                    _showDataForPanelModel = value;
                    OnPropertyChanged(() => ShowDataForPanelModel, false);
                    OnPropertyChanged(() => InterfaceBoardTypes, false);
                }
            }
        }


        [DataMember]
        public IList<GalaxyPanelAlertEventType> AlertEventTypes
        {
            get { return _alertEventTypes; }
            set
            {
                if (_alertEventTypes != value)
                {
                    _alertEventTypes = value;
                    OnPropertyChanged(() => AlertEventTypes, false);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board type board section modes. </summary>
        ///
        /// <value> The board type board section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<KeyValuePair<Guid, ObservableCollection<InterfaceBoardSectionMode>>> BoardTypeBoardSectionModes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Builds board type board section modes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BuildBoardTypeBoardSectionModes()
        {
            BoardTypeBoardSectionModes = new List<KeyValuePair<Guid, ObservableCollection<InterfaceBoardSectionMode>>>();
            foreach (var bt in InterfaceBoardTypes)
            {
                var modes = InterfaceBoardSectionModes.Where(m => m.InterfaceBoardTypeUid == bt.InterfaceBoardTypeUid).OrderBy(m => m.Display).ToObservableCollection();
                BoardTypeBoardSectionModes.Add(new KeyValuePair<Guid, ObservableCollection<InterfaceBoardSectionMode>>(bt.InterfaceBoardTypeUid, modes));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets modes for board type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="boardTypeUid"> The board type UID. </param>
        ///
        /// <returns>   The modes for board type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private ObservableCollection<InterfaceBoardSectionMode> GetModesForBoardType(Guid boardTypeUid)
        {

            return BoardTypeBoardSectionModes.Where(m => m.Key == boardTypeUid).Select(m => m.Value).FirstOrDefault();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the dsi 600 section modes. </summary>
        /////
        ///// <value> The dsi 600 section modes. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ObservableCollection<InterfaceBoardSectionMode> DSI600SectionModes
        //{
        //    get { return GetModesForBoardType(Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600); }
        //    set
        //    {
        //        OnPropertyChanged(() => DSI600SectionModes, false);
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the dsi 635 section modes. </summary>
        ///
        /// <value> The dsi 635 section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<InterfaceBoardSectionMode> DSI635SectionModes
        {
            get { return GetModesForBoardType(Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635); }
            set
            {
                OnPropertyChanged(() => DSI635SectionModes, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the dri 600 section modes. </summary>
        ///
        /// <value> The dri 600 section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<InterfaceBoardSectionMode> DRI600SectionModes
        {
            get { return GetModesForBoardType(Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600); }
            set
            {
                OnPropertyChanged(() => DRI600SectionModes, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the dri 635 section modes. </summary>
        ///
        /// <value> The dri 635 section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<InterfaceBoardSectionMode> DRI635SectionModes
        {
            get { return GetModesForBoardType(Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635); }
            set
            {
                OnPropertyChanged(() => DRI635SectionModes, false);
            }
        }

    }
}
