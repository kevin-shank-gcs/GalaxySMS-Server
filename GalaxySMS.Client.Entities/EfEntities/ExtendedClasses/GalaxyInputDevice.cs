////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyInputDevice.cs
//
// summary:	Implements the galaxy input device class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using System.Collections.ObjectModel;
using System.Linq;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy input device. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyInputDevice
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInputDevice() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInputDevice to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInputDevice(GalaxyInputDevice e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyInputDevice. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.AlertEvents = new HashSet<InputDeviceAlertEvent>();
            this.ArmingInputOutputGroups = new HashSet<GalaxyInputArmingInputOutputGroup>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyInputDevice. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInputDevice to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(GalaxyInputDevice e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceUid = e.InputDeviceUid;
            this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
            this.GalaxyInputModeUid = e.GalaxyInputModeUid;
            this.DelayDuration = e.DelayDuration;
            this.GalaxyInputDelayTypeUid = e.GalaxyInputDelayTypeUid;
            this.DisableDisarmedOnOffLogEvents = e.DisableDisarmedOnOffLogEvents;
            this.IsNormalOpen = e.IsNormalOpen;
            this.TroubleShortThreshold = e.TroubleShortThreshold;
            this.NormalChangeThreshold = e.NormalChangeThreshold;
            this.TroubleOpenThreshold = e.TroubleOpenThreshold;
            this.AlternateVoltagesEnabled = e.AlternateVoltagesEnabled;
            this.AlternateTroubleShortThreshold = e.AlternateTroubleShortThreshold;
            this.AlternateNormalChangeThreshold = e.AlternateNormalChangeThreshold;
            this.AlternateTroubleOpenThreshold = e.AlternateTroubleOpenThreshold;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            this.TimeSchedule = e.TimeSchedule;
            this.GalaxyHardwareAddress = e.GalaxyHardwareAddress;
            this.TimeSchedule = e.TimeSchedule;
            if (this.AlertEvents != null)
                this.AlertEvents = e.AlertEvents.ToCollection();
            if (this.ArmingInputOutputGroups != null)
                this.ArmingInputOutputGroups = e.ArmingInputOutputGroups.ToCollection();

            VoltagesReply = e.VoltagesReply;
            //HardwareInformation = e.HardwareInformation;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this GalaxyInputDevice. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The GalaxyInputDevice to process. </param>
        ///
        /// <returns>   A copy of this GalaxyInputDevice. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInputDevice Clone(GalaxyInputDevice e)
        {
            return new GalaxyInputDevice(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this GalaxyInputDevice is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(GalaxyInputDevice other)
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

        public bool IsPrimaryKeyEqual(GalaxyInputDevice other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceUid != this.InputDeviceUid)
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

        public InputDeviceAlertEvent MainAlertEvent => AlertEvents.FirstOrDefault();

        public GalaxyInputArmingInputOutputGroup ArmingIoGroup1 => this.ArmingInputOutputGroups.FirstOrDefault(o=>o.OrderNumber == 1);
        public GalaxyInputArmingInputOutputGroup ArmingIoGroup2 => this.ArmingInputOutputGroups.FirstOrDefault(o=>o.OrderNumber == 2);
        public GalaxyInputArmingInputOutputGroup ArmingIoGroup3 => this.ArmingInputOutputGroups.FirstOrDefault(o=>o.OrderNumber == 3);
        public GalaxyInputArmingInputOutputGroup ArmingIoGroup4 => this.ArmingInputOutputGroups.FirstOrDefault(o=>o.OrderNumber == 4);
        //[DataMember]
        //public InputDevice_GetHardwareInformation HardwareInformation {get;set;}
        
        private InputDeviceVoltagesReply _voltagesReply;

        public InputDeviceVoltagesReply VoltagesReply
        {
            get { return _voltagesReply; }
            set
            {
                if (_voltagesReply != value)
                {
                    _voltagesReply = value;
                    OnPropertyChanged(() => VoltagesReply, false);
                }
            }
        }

    }
}
