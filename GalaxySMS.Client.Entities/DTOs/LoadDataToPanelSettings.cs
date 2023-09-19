using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class LoadDataToPanelSettings : ObjectBase
    {

        private bool _clusterSharedSettings;
        private bool _timeSchedules;
        private bool _allCardData;
        private bool _cardChanges;
        //private bool _accessPortals;
        private bool _accessPortalsInputsOutputs;
        private bool _accessRules;
        private bool _loadIoGroups;
        //private bool _inputOutputDevices;
        private bool _panelAlarms;

        public LoadDataToPanelSettings()
        {

        }

        public LoadDataToPanelSettings(LoadDataToPanelSettings o)
        {
            if( o != null)
            {
                ClusterSharedSettings = o.ClusterSharedSettings;
                TimeSchedules = o.TimeSchedules;
                AllCardData = o.AllCardData;
                //CardChanges = o.CardChanges;
                InputOutputGroups = o.InputOutputGroups;
                AccessPortalsInputsOutputs = o.AccessPortalsInputsOutputs;
                AccessRules = o.AccessRules;
                //InputOutputDevices = o.InputOutputDevices;
                PanelAlarms = o.PanelAlarms;
            }
        }

        [DataMember]
        public bool ClusterSharedSettings
        {
            get { return _clusterSharedSettings; }
            set
            {
                if (_clusterSharedSettings != value)
                {
                    _clusterSharedSettings = value;
                    OnPropertyChanged(() => ClusterSharedSettings, false);
                }
            }
        }


        [DataMember]
        public bool TimeSchedules
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


        [DataMember]
        public bool AllCardData
        {
            get { return _allCardData; }
            set
            {
                if (_allCardData != value)
                {
                    _allCardData = value;
                    OnPropertyChanged(() => AllCardData, false);
                }
            }
        }


        //[DataMember]
        //public bool CardChanges
        //{
        //    get { return _cardChanges; }
        //    set
        //    {
        //        if (_cardChanges != value)
        //        {
        //            _cardChanges = value;
        //            OnPropertyChanged(() => CardChanges, false);
        //        }
        //    }
        //}

        [DataMember]
        public bool InputOutputGroups
        {
            get { return _loadIoGroups; }
            set
            {
                if (_loadIoGroups != value)
                {
                    _loadIoGroups = value;
                    OnPropertyChanged(() => InputOutputGroups, false);
                }
            }
        }


        //[DataMember]
        //public bool AccessPortals
        //{
        //    get { return _accessPortals; }
        //    set
        //    {
        //        if (_accessPortals != value)
        //        {
        //            _accessPortals = value;
        //            OnPropertyChanged(() => AccessPortals, false);
        //        }
        //    }
        //}
        

        [DataMember]
        public bool AccessPortalsInputsOutputs
        {
            get { return _accessPortalsInputsOutputs; }
            set
            {
                if (_accessPortalsInputsOutputs != value)
                {
                    _accessPortalsInputsOutputs = value;
                    OnPropertyChanged(() => AccessPortalsInputsOutputs, false);
                }
            }
        }

        [DataMember]
        public bool AccessRules
        {
            get { return _accessRules; }
            set
            {
                if (_accessRules != value)
                {
                    _accessRules = value;
                    OnPropertyChanged(() => AccessRules, false);
                }
            }
        }


        //[DataMember]
        //public bool InputOutputDevices
        //{
        //    get { return _inputOutputDevices; }
        //    set
        //    {
        //        if (_inputOutputDevices != value)
        //        {
        //            _inputOutputDevices = value;
        //            OnPropertyChanged(() => InputOutputDevices, false);
        //        }
        //    }
        //}


        [DataMember]
        public bool PanelAlarms
        {
            get { return _panelAlarms; }
            set
            {
                if (_panelAlarms != value)
                {
                    _panelAlarms = value;
                    OnPropertyChanged(() => PanelAlarms, false);
                }
            }
        }

    }
}
