////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ReaderRelayTwoSettings.cs
//
// summary:	Implements the reader relay two settings class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A reader relay two settings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class ReaderRelayTwoSettings : ObjectBase
	{
        /// <summary>   The mode. </summary>
	    private BehaviorMode _mode;
        /// <summary>   The activation delay. </summary>
	    private ushort _activationDelay;
        /// <summary>   Duration of the energize. </summary>
	    private ushort _energizeDuration;
        /// <summary>   The schedule number. </summary>
	    private ScheduleNumber _scheduleNumber;
        /// <summary>   The trigger on illegal open. </summary>
	    private YesNo _triggerOnIllegalOpen;
        /// <summary>   The trigger on open too long. </summary>
	    private YesNo _triggerOnOpenTooLong;
        /// <summary>   The trigger on invalid access attempt. </summary>
	    private YesNo _triggerOnInvalidAccessAttempt;
        /// <summary>   The trigger on passback violation. </summary>
	    private YesNo _triggerOnPassbackViolation;
        /// <summary>   The trigger on valid access. </summary>
	    private YesNo _triggerOnValidAccess;
        /// <summary>   The trigger on duress. </summary>
	    private YesNo _triggerOnDuress;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent behavior modes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public enum BehaviorMode {None = 0, Follow, Timeout, Schedule, Latching }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public ReaderRelayTwoSettings()
		{
			ScheduleNumber = new ScheduleNumber();
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mode. </summary>
        ///
        /// <value> The mode. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public BehaviorMode Mode
	    {
	        get { return _mode; }
            set
            {
                if (_mode != value)
                {
                    _mode = value;
                    OnPropertyChanged(() => Mode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the activation delay. </summary>
        ///
        /// <value> The activation delay. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 ActivationDelay
	    {
	        get { return _activationDelay; }
            set
            {
                if (_activationDelay != value)
                {
                    _activationDelay = value;
                    OnPropertyChanged(() => ActivationDelay);
                }
            }
        } // In hundredths of seconds

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duration of the energize. </summary>
        ///
        /// <value> The energize duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 EnergizeDuration
	    {
	        get { return _energizeDuration; }
            set
            {
                if (_energizeDuration != value)
                {
                    _energizeDuration = value;
                    OnPropertyChanged(() => EnergizeDuration);
                }
            }
        } // In hundredths of seconds

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the schedule number. </summary>
        ///
        /// <value> The schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ScheduleNumber ScheduleNumber
	    {
	        get { return _scheduleNumber; }
            set
            {
                if (_scheduleNumber != value)
                {
                    _scheduleNumber = value;
                    OnPropertyChanged(() => ScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the trigger on illegal open. </summary>
        ///
        /// <value> The trigger on illegal open. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo TriggerOnIllegalOpen
	    {
	        get { return _triggerOnIllegalOpen; }
            set
            {
                if (_triggerOnIllegalOpen != value)
                {
                    _triggerOnIllegalOpen = value;
                    OnPropertyChanged(() => TriggerOnIllegalOpen);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the trigger on open too long. </summary>
        ///
        /// <value> The trigger on open too long. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo TriggerOnOpenTooLong
	    {
	        get { return _triggerOnOpenTooLong; }
            set
            {
                if (_triggerOnOpenTooLong != value)
                {
                    _triggerOnOpenTooLong = value;
                    OnPropertyChanged(() => TriggerOnOpenTooLong);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the trigger on invalid access attempt. </summary>
        ///
        /// <value> The trigger on invalid access attempt. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo TriggerOnInvalidAccessAttempt
	    {
	        get { return _triggerOnInvalidAccessAttempt; }
            set
            {
                if (_triggerOnInvalidAccessAttempt != value)
                {
                    _triggerOnInvalidAccessAttempt = value;
                    OnPropertyChanged(() => TriggerOnInvalidAccessAttempt);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the trigger on passback violation. </summary>
        ///
        /// <value> The trigger on passback violation. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo TriggerOnPassbackViolation
	    {
	        get { return _triggerOnPassbackViolation; }
            set
            {
                if (_triggerOnPassbackViolation != value)
                {
                    _triggerOnPassbackViolation = value;
                    OnPropertyChanged(() => TriggerOnPassbackViolation);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the trigger on valid access. </summary>
        ///
        /// <value> The trigger on valid access. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo TriggerOnValidAccess
	    {
	        get { return _triggerOnValidAccess; }
            set
            {
                if (_triggerOnValidAccess != value)
                {
                    _triggerOnValidAccess = value;
                    OnPropertyChanged(() => TriggerOnValidAccess);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the trigger on duress. </summary>
        ///
        /// <value> The trigger on duress. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo TriggerOnDuress
	    {
	        get { return _triggerOnDuress; }
            set
            {
                if (_triggerOnDuress != value)
                {
                    _triggerOnDuress = value;
                    OnPropertyChanged(() => TriggerOnDuress);
                }
            }
        }
	}
}
