////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessPortalGalaxyPanelSpecificEditingData.cs
//
// summary:	Implements the access portal galaxy panel specific editing data class
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
    /// <summary>   The access portal galaxy panel specific editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessPortalGalaxyPanelSpecificEditingData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalGalaxyPanelSpecificEditingData()
        {
            ContactSupervisionTypes = new List<AccessPortalContactSupervisionType>();
            LiquidCrystalDisplays  = new List<LiquidCrystalDisplay>();
            //ElevatorControlTypes = new List<AccessPortalElevatorControlType>();
            ElevatorRelaysInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();
            Areas = new List<Area>();
            TimeSchedules = new List<TimeSchedule>();
            InputOutputGroups = new List<InputOutputGroup>();
            AccessGroups = new List<AccessGroup>();
            //OtisElevatorDecs = new List<OtisElevatorDec>();
        }

        /// <summary>   List of types of the contact supervisions. </summary>
        private IList<AccessPortalContactSupervisionType> _contactSupervisionTypes;
        /// <summary>   The liquid crystal displays. </summary>
        private IList<LiquidCrystalDisplay> _liquidCrystalDisplays;
        /// <summary>   List of types of the elevator controls. </summary>
        private IList<AccessPortalElevatorControlType> _elevatorControlTypes;
        /// <summary>   The elevator relays interface board sections. </summary>
        private IList<GalaxyInterfaceBoardSection> _elevatorRelaysInterfaceBoardSections;
        /// <summary>   The areas. </summary>
        private IList<Area> _areas;
        /// <summary>   The time schedules. </summary>
        private IList<TimeSchedule> _timeSchedules;
        private IList<TimeSchedule> _timeSchedulesWithEmpty;
        /// <summary>   Groups the input output belongs to. </summary>
        private IList<InputOutputGroup> _inputOutputGroups;
        private IList<AccessGroup> _accessGroups;
        //private IList<OtisElevatorDec> _otisElevatorDecs;
        //private IList<KoneDop> _koneElevatorDops;
        //private IList<KoneCop> _koneElevatorCops;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the contact supervisions. </summary>
        ///
        /// <value> A list of types of the contact supervisions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalContactSupervisionType> ContactSupervisionTypes
        {
            get { return _contactSupervisionTypes; }
            set
            {
                if (_contactSupervisionTypes != value)
                {
                    _contactSupervisionTypes = value;
                    OnPropertyChanged(() => ContactSupervisionTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the liquid crystal displays. </summary>
        ///
        /// <value> The liquid crystal displays. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<LiquidCrystalDisplay> LiquidCrystalDisplays
        {
            get { return _liquidCrystalDisplays; }
            set
            {
                if (_liquidCrystalDisplays != value)
                {
                    _liquidCrystalDisplays = value;
                    OnPropertyChanged(() => LiquidCrystalDisplays, false);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets a list of types of the elevator controls. </summary>
        /////
        ///// <value> A list of types of the elevator controls. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public IList<AccessPortalElevatorControlType> ElevatorControlTypes
        //{
        //    get { return _elevatorControlTypes; }
        //    set
        //    {
        //        if (_elevatorControlTypes != value)
        //        {
        //            _elevatorControlTypes = value;
        //            OnPropertyChanged(() => ElevatorControlTypes, false);
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the elevator relays interface board sections. </summary>
        ///
        /// <value> The elevator relays interface board sections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections
        {
            get { return _elevatorRelaysInterfaceBoardSections; }
            set
            {
                if (_elevatorRelaysInterfaceBoardSections != value) 
                {
                    _elevatorRelaysInterfaceBoardSections = value;
                    OnPropertyChanged(() => ElevatorRelaysInterfaceBoardSections, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the areas. </summary>
        ///
        /// <value> The areas. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<Area> Areas
        {
            get { return _areas; }
            set
            {
                if (_areas != value)
                {
                    _areas = value;
                    OnPropertyChanged(() => Areas, false);
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

        public IList<TimeSchedule> TimeSchedulesWithEmpty
        {
            get { return _timeSchedulesWithEmpty; }
            set
            {
                if (_timeSchedulesWithEmpty != value)
                {
                    _timeSchedulesWithEmpty = value;
                    OnPropertyChanged(() => TimeSchedulesWithEmpty, false);
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

        [DataMember]
        public IList<AccessGroup> AccessGroups
        {
            get { return _accessGroups; }
            set
            {
                if (_accessGroups != value)
                {
                    _accessGroups = value;
                    OnPropertyChanged(() => AccessGroups, false);
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

    }
}
