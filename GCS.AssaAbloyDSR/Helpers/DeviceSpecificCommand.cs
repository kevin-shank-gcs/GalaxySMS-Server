using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using GCS.AssaAbloyDSR.DSRAccessControlService;

namespace GCS.AssaAbloyDSR
{
    public class SetConfigParamCommand<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
        public string StringValue { get; set; }

        private XElement ToXElement()
        {
            string typeValue = "U8";
            this.StringValue = Value.ToString();

            if (Value is bool)
            {
                typeValue = "BOOL";
                if (Value.ToString().ToLower() == "true")
                    this.StringValue = "1";
                else
                    this.StringValue = "0";
            }
            else if (Value is byte)
            {
                typeValue = "U8";
            }
            else if (Value is string)
            {
                typeValue = "STRING";
            }
            else if (Value is short)
            {
                typeValue = "U16";
            }
            else if (Value is ushort)
            {
                typeValue = "U16";
            }
            else if (Value is uint)
            {
                typeValue = "U32";
            }
            else if (Value is int)
            {
                typeValue = "U32";
            }
            var xelement = new XElement("Configuration",
                new XElement("configitem",
                new XElement("paramname", Name),
                new XElement("paramvalue", StringValue, new XAttribute("paramtype", typeValue))));

            //new XElement("paramvalue", Value, new XAttribute("paramtype", typeValue))));
            return xelement;
        }

        public XmlElement ToXmlElement()
        {
            var el = this.ToXElement();
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }
    }

    public class FiltersCommand
    {
        public enum FilterTarget : int
        {
            Recording = 0,
            Reporting = 1
        }
        public FiltersCommand()
        {
            Target = FilterTarget.Reporting;
            Filters = new List<string>();
        }

        public FilterTarget Target { get; set; }
        public List<string> Filters { get; set; }

        private XElement ToXElement()
        {
            var rootElement = new XElement("FiltersSetting");
            //           var targetChild = new XElement("target", Target);
            var targetChild = new XElement("target", Convert.ToInt16(Target));
            rootElement.Add(targetChild);
            var filtersChild = new XElement("filters");
            foreach (var filter in Filters)
            {
                filtersChild.Add(new XElement("filter", filter));
            }
            rootElement.Add(filtersChild);

            return rootElement;
        }

        public XmlElement ToXmlElement()
        {
            var el = this.ToXElement();
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }
    }

    public class Alarm
    {
        public Alarm()
        {

        }
        public Alarm(Alarms.AlarmMode mode, Alarms.AlarmType type)
        {
            Mode = mode;
            Type = type;
        }

        public Alarms.AlarmMode Mode { get; set; }
        public Alarms.AlarmType Type { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", Type);
            return base.ToString();
        }
    }

    public class AlarmConfigCommand
    {
        public AlarmConfigCommand()
        {
            Alarms = new List<Alarm>();
        }

        public List<Alarm> Alarms { get; set; }

        private XElement ToXElement()
        {
            var rootElement = new XElement("AlarmConfig");
            foreach (var a in Alarms)
            {
                var alarmChild = new XElement("alarm");
                alarmChild.Add(new XElement("alarmid", Convert.ToInt16(a.Type)));
                alarmChild.Add(new XElement("alarmmode", Convert.ToInt16(a.Mode)));
                rootElement.Add(alarmChild);
            }
            return rootElement;
        }

        public XmlElement ToXmlElement()
        {
            var el = this.ToXElement();
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }
    }

    public class ConfigurationItem<T>
    {
        public ConfigurationItem()
        {
            ParamName = string.Empty;
        }

        public ConfigurationItem(string paramName, T value )
        {
            ParamName = paramName;
            Value = value;
        }

        public string ParamName { get; set; }
        public T Value { get; set; }
    }

    public static class DeviceSpecificCommandTypeHelpers
    {
        public static DeviceSpecificCommandType GetSetConfigParamCommand( IEnumerable<ConfigurationItem<byte>> byteCommands, IEnumerable<ConfigurationItem<UInt16>> uint16Commands, IEnumerable<ConfigurationItem<UInt32>> uint32Commands, IEnumerable<ConfigurationItem<bool>> boolCommands, IEnumerable<ConfigurationItem<string>> stringCommands)
        {
            var command = new DeviceSpecificCommandType();
            command.commandName = "SETCONFIGPARAM";

            if (byteCommands != null)
            {
                foreach (var i in byteCommands)
                {
                    var cmdPayload = new SetConfigParamCommand<byte>();
                    cmdPayload.Name = i.ParamName;    // 102 = strike unlock duration, 114 = SchedulingAlgorithm
                    cmdPayload.Value = i.Value;
                    if (command.commandPayload == null)
                        command.commandPayload = cmdPayload.ToXmlElement();
                    else
                    {
                        var t = cmdPayload.ToXmlElement();
                        var importNode = command.commandPayload.OwnerDocument.ImportNode(t.FirstChild, true);
                        command.commandPayload.AppendChild(importNode);
                    }
                }
            }

            if (uint16Commands != null)
            {
                foreach (var i in uint16Commands)
                {
                    var cmdPayload = new SetConfigParamCommand<UInt16>();
                    cmdPayload.Name = i.ParamName;    // 102 = strike unlock duration, 114 = SchedulingAlgorithm
                    cmdPayload.Value = i.Value;
                    if (command.commandPayload == null)
                        command.commandPayload = cmdPayload.ToXmlElement();
                    else
                    {
                        var t = cmdPayload.ToXmlElement();
                        var importNode = command.commandPayload.OwnerDocument.ImportNode(t.FirstChild, true);
                        command.commandPayload.AppendChild(importNode);
                    }
                }
            }

            if (uint32Commands != null)
            {
                foreach (var i in uint32Commands)
                {
                    var cmdPayload = new SetConfigParamCommand<UInt32>();
                    cmdPayload.Name = i.ParamName;    // 102 = strike unlock duration, 114 = SchedulingAlgorithm
                    cmdPayload.Value = i.Value;
                    if (command.commandPayload == null)
                        command.commandPayload = cmdPayload.ToXmlElement();
                    else
                    {
                        var t = cmdPayload.ToXmlElement();
                        var importNode = command.commandPayload.OwnerDocument.ImportNode(t.FirstChild, true);
                        command.commandPayload.AppendChild(importNode);
                    }
                }
            }

            if (boolCommands != null)
            {
                foreach (var i in boolCommands)
                {
                    var cmdPayload = new SetConfigParamCommand<bool>();
                    cmdPayload.Name = i.ParamName;    // 102 = strike unlock duration, 114 = SchedulingAlgorithm
                    cmdPayload.Value = i.Value;
                    if (command.commandPayload == null)
                        command.commandPayload = cmdPayload.ToXmlElement();
                    else
                    {
                        var t = cmdPayload.ToXmlElement();
                        var importNode = command.commandPayload.OwnerDocument.ImportNode(t.FirstChild, true);
                        command.commandPayload.AppendChild(importNode);
                    }
                }
            }

            if (stringCommands != null)
            {
                foreach (var i in stringCommands)
                {
                    var cmdPayload = new SetConfigParamCommand<string>();
                    cmdPayload.Name = i.ParamName;    // 102 = strike unlock duration, 114 = SchedulingAlgorithm
                    cmdPayload.Value = i.Value;
                    if (command.commandPayload == null)
                        command.commandPayload = cmdPayload.ToXmlElement();
                    else
                    {
                        var t = cmdPayload.ToXmlElement();
                        var importNode = command.commandPayload.OwnerDocument.ImportNode(t.FirstChild, true);
                        command.commandPayload.AppendChild(importNode);
                    }
                }
            }
            
            return command;
        }

        public static DeviceSpecificCommandType GetSetConfigParamCommand<T>(string paramName, T value)
        {
            var cmdPayload = new SetConfigParamCommand<T>();
            cmdPayload.Name = paramName;    // 102 = strike unlock duration, 114 = SchedulingAlgorithm
            cmdPayload.Value = value;

            var command = new DeviceSpecificCommandType();
            command.commandName = "SETCONFIGPARAM";
            command.commandPayload = cmdPayload.ToXmlElement();
            return command;
        }

        public static DeviceSpecificCommandType GetSetFiltersCommand(FiltersCommand.FilterTarget target, string[] filters)
        {
            var cmdPayload = new FiltersCommand();
            cmdPayload.Target = target;   //
            foreach (var filter in filters)
                cmdPayload.Filters.Add(filter);

            var command = new DeviceSpecificCommandType();
            command.commandName = "FILTERS";
            command.commandPayload = cmdPayload.ToXmlElement();
            return command;
        }

        public static DeviceSpecificCommandType GetAlarmConfigCommand(Alarm[] alarms)
        {
            var cmdPayload = new AlarmConfigCommand();
            foreach (var a in alarms)
                cmdPayload.Alarms.Add(a);

            var command = new DeviceSpecificCommandType();
            command.commandName = "ALARMCONFIG";
            command.commandPayload = cmdPayload.ToXmlElement();
            return command;
        }

        public static DeviceSpecificCommandType GetAlarmConfigCommand(Alarm alarm)
        {
            var cmdPayload = new AlarmConfigCommand();
            cmdPayload.Alarms.Add(alarm);

            var command = new DeviceSpecificCommandType();
            command.commandName = "ALARMCONFIG";
            command.commandPayload = cmdPayload.ToXmlElement();
            return command;
        }
    }

    public static class SetConfigParamStringCommands
    {
        public const string SerialNumber = "0";
        public const string EncryptionDecryptionKey = "1";
        public const string SchedulerHourOfDayMap = "117";
        public const string LEAPUsername = "129";
        public const string LEAPPassword = "130";
        public const string AlarmConfiguration = "145";
        public const string FiltersRecording = "146";
        public const string LockDescription = "162";

    }

    public static class VoltageHelpers
    {
        public const double VoltsPerBit = 0.0415;

        public static byte CalculateFromVoltage(double voltage, byte defaultMinimumValue)
        {
            if (voltage <= 0)
                return defaultMinimumValue;

            byte value = (byte) (voltage / VoltsPerBit);
            if( value < defaultMinimumValue)
                return defaultMinimumValue;
            return value;
        }
    }

    public static class SetConfigParamU16Commands
    {
        public const string HardwareOptionsAtManufacturing = "2";
        public const string NVRAMChangesAtRestartMap = "4";
        public const string LRUHeadRecord = "20";
        public const string LRUTailRecord = "21";
        public const string ConsoleXORLengthErrorCounter = "25";
        public const string ConsoleCRCMismatchErrorCounter = "26";
        public const string ConsoleNotSigilErrorCounter = "27";
        public const string ConsoleTimeoutErrorCounter = "28";
        public const string ConsoleLengthTooLongErrorCounter = "29";
        public const string ConsoleLengthTooShortErrorCounter = "30";
        public const string ConsoleHitDefaultErrorCounter = "31";
        public const string ConsoleBufferOverrunErrorCounter = "32";
        public const string ConsoleUARTFramingErrorCounter = "33";
        public const string ConsoleUARTOverrunErrorCounter = "34";
        public const string EventLogStartingRecord = "52";
        public const string EventLogCurrentRecord = "53";
        public const string EventLogTotalEntries = "54";
        public const string EventLogWarnLevel = "56";
        public const string DeclinedLogStartingRecord = "59";
        public const string DeclinedLogCurrentRecord = "60";
        public const string DeclinedLogTotalEntries = "61";
        public const string DeclinedLogWarnLevel = "63";
        public const string AlarmLogStartingRecord = "66";
        public const string AlarmLogCurrentRecord = "67";
        public const string AlarmLogTotalEntries = "68";
        public const string AlarmLogWarnLevel = "70";
        public const string PeriodSchedulerAwakens = "116";
        public const string SchedulerOnAtHoursMinutes1 = "120";
        public const string SchedulerOnAtHoursMinutes2 = "121";
        public const string SchedulerOnAtHoursMinutes3 = "122";
        public const string SchedulerOnAtHoursMinutes4 = "123";
        public const string ExpireUserAtHourMinute = "170";
    }

    public static class SetConfigParamBOOLCommands
    {
        public const string NVRAMDirty = "5";
        public const string NVRAMWriteVerifyEnable = "6";
        public const string WatchdogTimer = "7";
        public const string EarlyCommandAcknowledgement = "8";
        public const string MandatoryAESOnConsole = "9";
        public const string MandatoryAESOnRadio = "10";
        public const string RLENVRAMDump = "11";
        public const string StopOnMortiseFailure = "12";
        public const string NOGAF = "13";
        public const string ExternalCardReaderPower = "14";
        public const string ProxReaderEnable = "15";
        public const string NVRAMChecksumming = "16";
        public const string DailyBatteryCheck = "17";
        public const string BatteryLowStatus = "19";
        public const string DaylightSavingsTimeInEffectFlag = "35";
        public const string EventLogZeroMemoryOnClear = "51";
        public const string DeclinedLogZeroMemoryOnClear = "58";
        public const string AlarmLogZeroMemoryOnClear = "65";
        public const string VisibleFeedbackEnable = "72";
        public const string AudibleFeedbackEnable = "73";
        public const string VisibleIndicatorsEnable = "74";
        public const string AudibleIndicatorsEnable = "75";
        public const string DeclinedLogWriteEnable = "81";
        public const string LowBatteryAudioVisualIndicator = "82";
        public const string PanicMode = "83";
        public const string GlobalTimezoneEnable = "84";
        public const string GlobalExceptionsEnable = "85";
        public const string AutoUnlockEnable = "86";
        public const string DoublePulseEnable = "98";
        public const string RetryOnSessionTimeout = "106";
        public const string MagCardSeparatorInclusion = "141";
        public const string DPACDebuggingEnable = "149";
        public const string FailOpenSecure = "150";
        public const string ExtendedResponses = "154";
        public const string PassageModeIndicator = "155";
        public const string ProxStripSentinel = "157";
        public const string iClassProxStripSentinel = "158";
        public const string UseSecondCredential = "160";
        public const string Prox37AddSentinel = "166";
        public const string AudibleAccess = "168";
        public const string CanadianRXPassageModeEscapeReturn = "169";
        public const string FastEventLogFilter = "171";
        public const string DeadboltRetractRestoresPassageMode = "172";
        public const string PrivacyButton = "174";
    }

    public static class SetConfigParamU8Commands
    {
        public const string DailyBatteryCheckHour = "18";
        public const string RTCCalibrationValue = "22";
        public const string AuxiliaryDeviceVersionRequester = "23";
        public const string LocalLEDAssignment = "24";
        public const string DaylightSavingsTimeModeSelect = "36";
        public const string DaylightSavingsTimeSkipForwardMonth = "37";
        public const string DaylightSavingsTimeSkipForwardDay = "38";
        public const string DaylightSavingsTimeSkipForwardWeek = "39";
        public const string DaylightSavingsTimeSkipForwardDOW = "40";
        public const string DaylightSavingsTimeSkipForwardHour = "41";
        public const string DaylightSavingsTimeSkipForwardMinute = "42";
        public const string DaylightSavingsTimeSkipForwardAdjust = "43";
        public const string DaylightSavingsTimeFallBackMonth = "44";
        public const string DaylightSavingsTimeFallBackDay = "45";
        public const string DaylightSavingsTimeFallBackWeek = "46";
        public const string DaylightSavingsTimeFallBackDOW = "47";
        public const string DaylightSavingsTimeFallBackHour = "48";
        public const string DaylightSavingsTimeFallBackMinute = "49";
        public const string DaylightSavingsTimeFallBackAdjust = "50";
        public const string EventLogWarnDevice = "55";
        public const string EventLogRemoteDevice = "57";
        public const string DeclinedLogWarningDevice = "62";
        public const string DeclinedLogLoggingDevice = "64";
        public const string AlarmLogWarningDevice = "69";
        public const string AlarmLogLoggingDevice = "71";
        public const string WaitFor2ndPINDurationSeconds = "76";
        public const string InvalidAttemptsUntilLockout = "77";
        public const string DurationOfLockoutSeconds = "78";
        public const string KeypadInactivityDelaySeconds = "79";
        public const string InvalidCredentialIdleResetTimeSeconds = "80";
        public const string DPACLockPriorityEmergency = "87";
        public const string DPACLockPrioritySupervisor = "88";
        public const string DPACLockPriorityUser = "89";
        public const string DPACLockPriorityPassageMode = "90";
        public const string DPACLockPriorityPanic = "91";
        public const string DPACLockPriorityLockout = "92";
        public const string DPACLockPriorityRelock = "93";
        public const string DPACLockPriorityBoltThrown = "94";
        public const string DPACLockPriorityConfigChange = "95";
        public const string DPACLockPriorityRemoteUnlock = "96";
        public const string LockType = "97";
        public const string DoublePulseDelayCentiseconds = "99";
        public const string PWMMotorRunDurationCentiseconds = "100";
        public const string MortiseType = "101";
        public const string StrikeUnlockDurationSeconds = "102";
        public const string ExtendedUnlockDurationSeconds = "103";
        public const string DoorAjarTimeSeconds = "104";
        public const string SessionTimeout = "105";
        public const string UnsolicitedMessageEncryption = "107";
        public const string RemoteAuthorizationTimeout = "108";
        public const string RemoteAuthorizationDevice = "109";
        public const string AlarmReportingDevice = "110";
        public const string NotifyUserDevice = "111";
        public const string CommUserReportingDevice = "112";
        public const string SchedulerReportingDevice = "113";
        public const string SchedulingAlgorithm = "114";
        public const string SchedulerAwakeDurationDecaseconds = "115";
        public const string SchedulerDayOfWeekMap = "118";
        public const string RadioType = "124";
        public const string RadioMode = "125";
        public const string RadioTimeout = "126";
        public const string RadioAttempts = "127";
        public const string RadioHousekeepingTimeoutSeconds = "128";
        public const string InhibitVoltageThreshold = "131";
        public const string LowVoltageWarningThreshold = "132";
        public const string PowerTableFor0_00To5_99Volts = "133";
        public const string PowerTableFor6_00To6_49Volts = "134";
        public const string PowerTableFor6_50To6_99Volts = "135";
        public const string PowerTableFor7_00To7_49Volts = "136";
        public const string PowerTableFor7_50To7_99Volts = "137";
        public const string PowerTableFor8_00To8_49Volts = "138";
        public const string PowerTableFor8_50To8_99Volts = "139";
        public const string PowerTableFor9_00AndUpVolts = "140";
        public const string MagCardFields = "142";
        public const string MagCardDataOffset = "143";
        public const string MagCardDataDigits = "144";
        public const string LastAlarmState = "147";
        public const string DoorState = "148";
        public const string ReplacedVoltageThreshold = "151";
        public const string RXHeldTimeSeconds = "152";
        public const string PacketTimeoutSeconds = "153";
        public const string PFMReturnTime = "156";
        public const string CSCReaderMode = "159";
        public const string CallBackLater = "161";
        public const string AntiTailgating = "163";
        public const string AntiTailgatingDelay = "164";
        public const string GlobalAccessMode = "165";
        public const string RTCRecoveryMode = "167";
    }

    public static class SetConfigParamU32Commands
    {
        public const string SchedulerDayOfMonthMap = "119";
    }

    public static class Filters
    {
        public const string ClearAllFilters = "FF";
        public const string INVALIDPIN = "0";
        public const string USER = "1";
        public const string ONETIME = "2";
        public const string PASSAGEBEGIN = "3";
        public const string PASSAGEEND = "4";
        public const string BADTIME = "5";
        public const string LOCKEDOUT = "6";
        public const string LOWBATTERY = "7";
        public const string DEADBATTERY = "8";
        public const string BATTERYREPLACED = "9";
        public const string USERADDED = "10";
        public const string USERDELETED = "11";
        public const string EMERGENCY = "12";
        public const string PANIC = "13";
        public const string RELOCK = "14";
        public const string LOCKOUTBEGIN = "15";
        public const string LOCKOUTEND = "16";
        public const string RESET = "17";
        public const string DATETIMESET = "18";
        public const string LOGCLEARED = "19";
        public const string DBRESET = "20";
        public const string COMMSTARTED = "21";
        public const string COMMENDED = "22";
        public const string FIRMWAREABORT = "23";
        public const string FIRMWAREERROR = "24";
        public const string FIRMWARETIMEOUT = "25";
        public const string DSTFALLBACK = "26";
        public const string DSTSPRINGFORWARD = "27";
        public const string BOLTTHROWN = "28";
        public const string BOLTRETRACTED = "29";
        public const string MASTERCODE = "30";
        public const string COMMUSER = "31";
        public const string DPACDISABLED = "32";
        public const string NOTIFY = "33";
        public const string EXPIRED = "34";
        public const string SUPERVISOR = "35";
        public const string MCCENTER = "36";
        public const string MCCEXIT = "37";
        public const string SERIALRXOVERRUN = "38";
        public const string DPACRXOVERRUN = "39";
        public const string NVRAMPBCLEAR = "40";
        public const string NVRAMLAYOUTCHANGE = "41";
        public const string NVRAMOK = "42";
        public const string USERREPLACED = "43";
        public const string RADIOTIMEOUT = "44";
        public const string SUSPENDEDUSER = "45";
        public const string USERUPDATED = "46";
        public const string DOORBOLTED = "47";
        public const string PANICACTIVE = "48";
        public const string PASSAGEACTIVE = "49";
        public const string PASSAGEINACTIVE = "50";
        public const string BADACCESSMODE = "51";
        public const string CLOCKERR = "52";
        public const string REMOTEUNLOCK = "53";
        public const string TZHAUDISABLED = "54";
        public const string EVENTLOGWRAPPED = "55";
        public const string DECLINEDLOGWRAPPED = "56";
        public const string ALARMLOGWRAPPED = "57";
        public const string RADIOBUSYEMERGENCY = "58";
        public const string RADIOBUSYSUPERVISOR = "59";
        public const string RADIOBUSYONETIME = "60";
        public const string RADIOBUSYUSER = "61";
        public const string RADIOBUSYPANIC = "62";
        public const string RADIOBUSYREX = "63";
        public const string RADIOBUSYLOCKOUT = "64";
        public const string RADIOBUSYRELOCK = "65";
        public const string BATTERYCHECKHELDOFF = "66";
        public const string RMTAUTHREQUEST = "67";
        public const string FIRMWAREUPDATE = "68";
        public const string FIRMWAREUPDATEFAILED = "69";
        public const string MSMFAILURE = "70";
        public const string CLOCKRESET = "71";
        public const string CHECKSUMCONFIG = "72";
        public const string CHECKSUMTZ = "73";
        public const string DEBUG = "74";
    }

    public static class Alarms
    {
        public enum AlarmType : int
        {
            None = 0,
            Valid = 1,
            Denied = 2,
            DoorSecured = 3,
            DoorForced = 4,
            KeyOverride = 5,
            InvalidEntry = 6,
            DoorAjar = 7,
            LowBattery = 8,
            RXHeld = 9
        }
        [Flags]
        public enum AlarmMode : int
        {
            SecuredMode = 1,
            PassageMode = 2,
            RXHeldMode = 4
        }
    }

    public static class ScheduleGuids
    {
        public static Guid Never = Guid.Empty;
        public static Guid Always = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff");
    }

    public class SchedulingAlgorithm
    {
        private string _displayName;

        public SchedulingAlgorithm()
        {

        }

        public SchedulingAlgorithm(ScheduleType type)
        {
            Type = type;
        }

        public SchedulingAlgorithm(ScheduleType type, string displayName)
        {
            Type = type;
            DisplayName = displayName;
        }

        public enum ScheduleType : byte
        {
            AlwaysOn = 0,
            Simple = 1,
            DayOfMonth = 2,
            DayOfWeek = 3,
            CommUser = 4,
            HourOfDay = 5,
            AlwaysOff = 6
        }

        public ScheduleType Type { get; set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return Type.ToString();
                return _displayName;
            }
            set { _displayName = value; }
        }
    }

    public class ScheduleHourMinute
    {
        public ScheduleHourMinute()
        {

        }

        public ScheduleHourMinute(byte hour, byte minute)
        {
            Hour = hour;
            Minute = minute;
        }

        private byte _hour;
        private byte _minute;

        public byte Hour
        {
            get { return _hour; }
            set
            {
                if (value > 23)
                    value = 0;
                _hour = value;
            }
        }

        public byte Minute
        {
            get { return _minute; }
            set
            {
                if (value > 59)
                    value = 0;
                _minute = value;
            }
        }

        public ushort HourMinute
        {
            get
            {
                if (Hour > 23)
                    Hour = 0;
                if (Minute > 59)
                    Minute = 0;
                var temp = string.Format("{0:00}{1:00}", Hour, Minute);
                return Convert.ToUInt16(temp);
            }
        }
    }

    public class AwakenScheduleSetting
    {
        [Flags]
        public enum WeekDayBits:byte
        {
            Sunday=0x1,
            Monday=0x2,
            Tuesday=0x4,
            Wednesday=0x8,
            Thursday=0x10,
            Friday = 0x20,
            Saturday = 0x40
        }

        public AwakenScheduleSetting()
        {
            HoursMinutes = new ScheduleHourMinute[4];
            DaysOfWeek = new List<WeekDay>();
            DaysOfMonth = new bool[32];
            FiveMinuteBlocks = new bool[288];
        }
        public SchedulingAlgorithm SchedulingAlgorithm { get; set; }
        public ushort SimpleMinutes { get; set; }
        public List<WeekDay> DaysOfWeek { get; internal set; }
        public ScheduleHourMinute[] HoursMinutes { get; internal set; }
        public bool[] FiveMinuteBlocks { get; internal set; }
        public bool[] DaysOfMonth { get; internal set; }    // 1st of month = DaysOfMonth[1], 31st of month = DaysOfMonth[31]

        public UInt32 DaysOfMonthBits
        {
            get
            {
                UInt32 value = 0;
                UInt32 theBit = 1;
                for(int dom = 0; dom < 31; dom++)
                {
                    if(DaysOfMonth[dom+1] == true)
                    {
                        theBit <<= dom;
                        value |= theBit;
                    }
                }
                return value;
            }
        }

        public byte DaysOfWeekBits
        {
            get
            {
                byte value = 0;
                foreach( var dow in DaysOfWeek)
                {
                    switch( dow)
                    {
                        case WeekDay.SUNDAY:
                            value |= (byte) WeekDayBits.Sunday;
                            break;

                        case WeekDay.MONDAY:
                            value |= (byte) WeekDayBits.Monday;
                            break;

                        case WeekDay.TUESDAY:
                            value |= (byte) WeekDayBits.Tuesday;
                            break;

                        case WeekDay.WEDNESDAY:
                            value |= (byte) WeekDayBits.Wednesday;
                            break;

                        case WeekDay.THURSDAY:
                            value |= (byte) WeekDayBits.Thursday;
                            break;

                        case WeekDay.FRIDAY:
                            value |= (byte) WeekDayBits.Friday;
                            break;

                        case WeekDay.SATURDAY:
                            value |= (byte) WeekDayBits.Saturday;
                            break;
                    }
                }
                return value;
            }
        }

        public IEnumerable<DeviceSpecificCommandType> GetDeviceSpecificCommands()
        {
            var commands = new List<DeviceSpecificCommandType>();
            var c = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<byte>(SetConfigParamU8Commands.SchedulingAlgorithm, (byte) this.SchedulingAlgorithm.Type);
            commands.Add(c);
            switch (SchedulingAlgorithm.Type)
            {
                case SchedulingAlgorithm.ScheduleType.AlwaysOn:
                case SchedulingAlgorithm.ScheduleType.AlwaysOff:
                    break;

                case SchedulingAlgorithm.ScheduleType.Simple:
                    var cSimple = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<UInt16>(SetConfigParamU16Commands.PeriodSchedulerAwakens, SimpleMinutes);
                    commands.Add(cSimple);
                    break;

                case SchedulingAlgorithm.ScheduleType.DayOfMonth:
                    var cDOM = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<UInt32>(SetConfigParamU32Commands.SchedulerDayOfMonthMap, DaysOfMonthBits);
                    commands.Add(cDOM);

                    // Add up to 4 time of day
                    BuildHourMinuteCommands(ref commands);
                    break;

                case SchedulingAlgorithm.ScheduleType.DayOfWeek:
                    var cDOW = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<byte>(SetConfigParamU8Commands.SchedulerDayOfWeekMap, DaysOfWeekBits);
                    commands.Add(cDOW);

                    // Add up to 4 time of day
                    BuildHourMinuteCommands(ref commands);
                    break;

                case SchedulingAlgorithm.ScheduleType.CommUser:
                    break;

                case SchedulingAlgorithm.ScheduleType.HourOfDay:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();

            }
            return commands;
        }

        public void GetDeviceSpecificCommands(List<ConfigurationItem<byte>> byteCommands, List<ConfigurationItem<UInt16>> uint16Commands, List<ConfigurationItem<UInt32>> uint32Commands, List<ConfigurationItem<bool>> boolCommands, List<ConfigurationItem<string>> stringCommands)
        {
            byteCommands.Add(new ConfigurationItem<byte>(SetConfigParamU8Commands.SchedulingAlgorithm, (byte) this.SchedulingAlgorithm.Type));
            switch (SchedulingAlgorithm.Type)
            {
                case SchedulingAlgorithm.ScheduleType.AlwaysOn:
                case SchedulingAlgorithm.ScheduleType.AlwaysOff:
                    break;

                case SchedulingAlgorithm.ScheduleType.Simple:
                    uint16Commands.Add(new ConfigurationItem<UInt16>(SetConfigParamU16Commands.PeriodSchedulerAwakens, (UInt16) this.SimpleMinutes));
                    break;

                case SchedulingAlgorithm.ScheduleType.DayOfMonth:
                    uint32Commands.Add(new ConfigurationItem<UInt32>(SetConfigParamU32Commands.SchedulerDayOfMonthMap, (UInt32) this.DaysOfMonthBits));

                    // Add up to 4 time of day
                    BuildHourMinuteCommands(ref uint16Commands);
                    break;

                case SchedulingAlgorithm.ScheduleType.DayOfWeek:
                    byteCommands.Add(new ConfigurationItem<byte>(SetConfigParamU8Commands.SchedulerDayOfWeekMap, (byte) DaysOfWeekBits));

                    // Add up to 4 time of day
                    BuildHourMinuteCommands(ref uint16Commands);
                    break;

                case SchedulingAlgorithm.ScheduleType.CommUser:
                    break;

                case SchedulingAlgorithm.ScheduleType.HourOfDay:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        private void BuildHourMinuteCommands(ref List<DeviceSpecificCommandType> commands)
        {
            for (int x = 0; x < HoursMinutes.Length; x++)
            {
                var hm = HoursMinutes[x];
                if (hm != null)
                {
                    DeviceSpecificCommandType cHM = null;
                    switch (x)
                    {
                        case 0:
                            cHM = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes1, hm.HourMinute);
                            break;
                        case 1:
                            cHM = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes2, hm.HourMinute);
                            break;
                        case 2:
                            cHM = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes3, hm.HourMinute);
                            break;
                        case 3:
                            cHM = DeviceSpecificCommandTypeHelpers.GetSetConfigParamCommand<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes4, hm.HourMinute);
                            break;
                    }
                    if (cHM != null)
                        commands.Add(cHM);
                }
            }
        }

        private void BuildHourMinuteCommands(ref List<ConfigurationItem<UInt16>> uint16Commands)
        {
            for (int x = 0; x < HoursMinutes.Length; x++)
            {
                var hm = HoursMinutes[x];
                if (hm != null)
                {
                    DeviceSpecificCommandType cHM = null;
                    switch (x)
                    {
                        case 0:
                            uint16Commands.Add(new ConfigurationItem<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes1, (UInt16) hm.HourMinute));
                            break;
                        case 1:
                            uint16Commands.Add(new ConfigurationItem<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes2, (UInt16) hm.HourMinute));
                            break;
                        case 2:
                            uint16Commands.Add(new ConfigurationItem<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes3, (UInt16) hm.HourMinute));
                            break;
                        case 3:
                            uint16Commands.Add(new ConfigurationItem<UInt16>(SetConfigParamU16Commands.SchedulerOnAtHoursMinutes4, (UInt16) hm.HourMinute));
                            break;
                    }
                }
            }
        }
    }
}
