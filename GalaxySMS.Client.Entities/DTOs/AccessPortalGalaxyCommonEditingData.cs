////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessPortalGalaxyCommonEditingData.cs
//
// summary:	Implements the access portal galaxy common editing data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal galaxy common editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessPortalGalaxyCommonEditingData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalGalaxyCommonEditingData()
        {
            AccessPortalTypes = new List<AccessPortalType>();
            AutomaticForgivePassbackFrequencies = new List<AutomaticForgivePassbackFrequency>();
            PinRequiredModes = new List<PinRequiredMode>();
            MultiFactorModes = new List<AccessPortalMultiFactorMode>();
            //ContactSupervisionTypes = new List<AccessPortalContactSupervisionType>();
            DeferToServerBehaviors = new List<AccessPortalDeferToServerBehavior>();
            NoServerReplyBehaviors = new List<AccessPortalNoServerReplyBehavior>();
            LockPushButtonBehaviors = new List<AccessPortalLockPushButtonBehavior>();
            //LiquidCrystalDisplays  = new List<LiquidCrystalDisplay>();
            ElevatorControlTypes = new List<AccessPortalElevatorControlType>();
            //ElevatorRelaysInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();
            AuxiliaryOutputModes = new List<AccessPortalAuxiliaryOutputMode>();
            //Areas = new List<Area>();
            //TimeSchedules = new List<TimeSchedule>();
            //InputOutputGroups = new List<InputOutputGroup>();
            AlertEventTypes = new List<AccessPortalAlertEventType>();
            AreaTypes = new List<AccessPortalAreaType>();
            TimeScheduleTypes = new List<AccessPortalScheduleType>();
            Commands = new List<AccessPortalCommand>();
            //OtisElevatorDecs = new List<OtisElevatorDec>();
        }

        /// <summary>   The automatic forgive passback frequencies. </summary>
        private IList<AutomaticForgivePassbackFrequency> _automaticForgivePassbackFrequencies;
        /// <summary>   The pin required modes. </summary>
        private IList<PinRequiredMode> _pinRequiredModes;
        //private IList<AccessPortalContactSupervisionType> _contactSupervisionTypes;
        /// <summary>   The defer to server behaviors. </summary>
        private IList<AccessPortalDeferToServerBehavior> _deferToServerBehaviors;
        /// <summary>   The no server reply behaviors. </summary>
        private IList<AccessPortalNoServerReplyBehavior> _noServerReplyBehaviors;
        /// <summary>   The lock push button behaviors. </summary>
        private IList<AccessPortalLockPushButtonBehavior> _lockPushButtonBehaviors;
        //private IList<LiquidCrystalDisplay> _liquidCrystalDisplays;
        private IList<AccessPortalElevatorControlType> _elevatorControlTypes;
        //private IList<OtisElevatorDec> _otisElevatorDecs;
        //private IList<GalaxyInterfaceBoardSection> _elevatorRelaysInterfaceBoardSections;
        //private IList<Area> _areas;
        //private IList<TimeSchedule> _timeSchedules;
        //private IList<InputOutputGroup> _inputOupuGroups;
        /// <summary>   The auxiliary output modes. </summary>
        private IList<AccessPortalAuxiliaryOutputMode> _auxiliaryOutputModes;
        /// <summary>   List of types of the alert events. </summary>
        private IList<AccessPortalAlertEventType> _alertEventTypes;
        /// <summary>   List of types of the areas. </summary>
        private IList<AccessPortalAreaType> _areaTypes;
        /// <summary>   List of types of the time schedules. </summary>
        private IList<AccessPortalScheduleType> _timeScheduleTypes;
        /// <summary>   List of types of the access portals. </summary>
        private IList<AccessPortalType> _accessPortalTypes;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portals. </summary>
        ///
        /// <value> A list of types of the access portals. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalType> AccessPortalTypes
        {
            get { return _accessPortalTypes; }
            set
            {
                if (_accessPortalTypes != value)
                {
                    _accessPortalTypes = value;
                    OnPropertyChanged(() => AccessPortalTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the areas. </summary>
        ///
        /// <value> A list of types of the areas. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalAreaType> AreaTypes
        {
            get { return _areaTypes; }
            set
            {
                if (_areaTypes != value)
                {
                    _areaTypes = value;
                    OnPropertyChanged(() => AreaTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the time schedules. </summary>
        ///
        /// <value> A list of types of the time schedules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalScheduleType> TimeScheduleTypes
        {
            get { return _timeScheduleTypes; }
            set
            {
                if (_timeScheduleTypes != value)
                {
                    _timeScheduleTypes = value;
                    OnPropertyChanged(() => TimeScheduleTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the automatic forgive passback frequencies. </summary>
        ///
        /// <value> The automatic forgive passback frequencies. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AutomaticForgivePassbackFrequency> AutomaticForgivePassbackFrequencies
        {
            get { return _automaticForgivePassbackFrequencies; }
            set
            {
                if (_automaticForgivePassbackFrequencies != value)
                {
                    _automaticForgivePassbackFrequencies = value;
                    OnPropertyChanged(() => AutomaticForgivePassbackFrequencies, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pin required modes. </summary>
        ///
        /// <value> The pin required modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<PinRequiredMode> PinRequiredModes
        {
            get { return _pinRequiredModes; }
            set
            {
                if (_pinRequiredModes != value)
                {
                    _pinRequiredModes = value;
                    OnPropertyChanged(() => PinRequiredModes, false);
                }
            }
        }

        private IList<AccessPortalMultiFactorMode> _multiFactorModes;

        [DataMember]
        public IList<AccessPortalMultiFactorMode> MultiFactorModes
        {
            get { return _multiFactorModes; }
            set
            {
                if (_multiFactorModes != value)
                {
                    _multiFactorModes = value;
                    OnPropertyChanged(() => MultiFactorModes, false);
                }
            }
        }


        //[DataMember]
        //public IList<AccessPortalContactSupervisionType> ContactSupervisionTypes
        //{
        //    get { return _contactSupervisionTypes; }
        //    set
        //    {
        //        if (_contactSupervisionTypes != value)
        //        {
        //            _contactSupervisionTypes = value;
        //            OnPropertyChanged(() => ContactSupervisionTypes, false);
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the defer to server behaviors. </summary>
        ///
        /// <value> The defer to server behaviors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalDeferToServerBehavior> DeferToServerBehaviors
        {
            get { return _deferToServerBehaviors; }
            set
            {
                if (_deferToServerBehaviors != value)
                {
                    _deferToServerBehaviors = value;
                    OnPropertyChanged(() => DeferToServerBehaviors, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the no server reply behaviors. </summary>
        ///
        /// <value> The no server reply behaviors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalNoServerReplyBehavior> NoServerReplyBehaviors
        {
            get { return _noServerReplyBehaviors; }
            set
            {
                if (_noServerReplyBehaviors != value)
                {
                    _noServerReplyBehaviors = value;
                    OnPropertyChanged(() => NoServerReplyBehaviors, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the lock push button behaviors. </summary>
        ///
        /// <value> The lock push button behaviors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalLockPushButtonBehavior> LockPushButtonBehaviors
        {
            get { return _lockPushButtonBehaviors; }    
            set 
            {
                if (_lockPushButtonBehaviors != value)
                {
                    _lockPushButtonBehaviors = value;
                    OnPropertyChanged(() => LockPushButtonBehaviors, false);
                }
            }
        }


        //[DataMember]
        //public IList<LiquidCrystalDisplay> LiquidCrystalDisplays
        //{
        //    get { return _liquidCrystalDisplays; }
        //    set
        //    {
        //        if (_liquidCrystalDisplays != value)
        //        {
        //            _liquidCrystalDisplays = value;
        //            OnPropertyChanged(() => LiquidCrystalDisplays, false);
        //        }
        //    }
        //}

        [DataMember]
        public IList<AccessPortalElevatorControlType> ElevatorControlTypes
        {
            get { return _elevatorControlTypes; }
            set
            {
                if (_elevatorControlTypes != value)
                {
                    _elevatorControlTypes = value;
                    OnPropertyChanged(() => ElevatorControlTypes, false);
                }
            }
        }


        //[DataMember]
        //public IList<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections
        //{
        //    get { return _elevatorRelaysInterfaceBoardSections; }
        //    set
        //    {
        //        if (_elevatorRelaysInterfaceBoardSections != value) 
        //        {
        //            _elevatorRelaysInterfaceBoardSections = value;
        //            OnPropertyChanged(() => ElevatorRelaysInterfaceBoardSections, false);
        //        }
        //    }
        //}


        //[DataMember]
        //public IList<Area> Areas
        //{
        //    get { return _areas; }
        //    set
        //    {
        //        if (_areas != value)
        //        {
        //            _areas = value;
        //            OnPropertyChanged(() => Areas, false);
        //        }
        //    }
        //}

        //[DataMember]
        //public IList<TimeSchedule> TimeSchedules
        //{
        //    get { return _timeSchedules; }
        //    set
        //    {
        //        if (_timeSchedules != value)
        //        {
        //            _timeSchedules = value;
        //            OnPropertyChanged(() => TimeSchedules, false);
        //        }
        //    }
        //}

        //[DataMember]
        //public IList<InputOutputGroup> InputOutputGroups
        //{
        //    get { return _inputOupuGroups; }
        //    set
        //    {
        //        if (_inputOupuGroups != value)
        //        {
        //            _inputOupuGroups = value;
        //            OnPropertyChanged(() => InputOutputGroups, false);
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the auxiliary output modes. </summary>
        ///
        /// <value> The auxiliary output modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalAuxiliaryOutputMode> AuxiliaryOutputModes
        {
            get { return _auxiliaryOutputModes; }
            set 
            {
                if (_auxiliaryOutputModes != value)
                {
                    _auxiliaryOutputModes = value;
                    OnPropertyChanged(() => AuxiliaryOutputModes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the alert events. </summary>
        ///
        /// <value> A list of types of the alert events. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalAlertEventType> AlertEventTypes
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

        //[DataMember]
        //public IList<OtisElevatorDec> OtisElevatorDecs
        //{
        //    get { return _otisElevatorDecs; }
        //    set
        //    {
        //        if (_otisElevatorDecs != value)
        //        {
        //            _otisElevatorDecs = value;
        //            OnPropertyChanged(() => OtisElevatorDecs, false);
        //        }
        //    }
        //}

        private IList<AccessPortalCommand> _commands;

        [DataMember]
        public IList<AccessPortalCommand> Commands
        {
            get { return _commands; }
            set
            {
                if (_commands != value)
                {
                    _commands = value;
                    OnPropertyChanged(() => Commands, false);
                }
            }
        }

    }
}
