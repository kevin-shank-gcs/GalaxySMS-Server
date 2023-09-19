using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a MercScpIdReportPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class MercScpIdReportPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _MercScpIdReportUid = Guid.Empty;
    private string _MacAddress = string.Empty;
    private int _DriverSpcId = 0;
    private int _ScpId = 0;
    private string _SerialNumber = string.Empty;
    private string _DeviceId = string.Empty;
    private string _DeviceVersion = string.Empty;
    private int _SoftwareRevisionMajor = 0;
    private int _SoftwareRevisionMinor = 0;
    private int _CumulativeBuildCount = 0;
    private bool _NeedsConfiguration = false;
    private string _TlsStatus = string.Empty;
    private int _OemCode = 0;
    private short _CurrentOperatingMode = 0;
    private short _Input1State = 0;
    private short _Input2State = 0;
    private short _Input3State = 0;
    private int _BioDb1Active = 0;
    private int _BioDb1Max = 0;
    private int _BioDb2Active = 0;
    private int _BioDb2Max = 0;
    private int _AssetDbActive = 0;
    private int _AssetDbMax = 0;
    private string _FirmwareAdvisory = string.Empty;
    private short _DipSwitchCurrent = 0;
    private short _DipSwitchPowerUp = 0;
    private int _DbActiveRecords = 0;
    private int _DbMaxSize = 0;
    private long _CurrentClock = 0;
    private int _RamFree = 0;
    private int _RamSize = 0;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _MercScpIdReportUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Merc Scp Id Report Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid MercScpIdReportUid 
    { 
      get { return _MercScpIdReportUid; }
      set 
      { 
        if(HasValueChanged(_MercScpIdReportUid, value, "MercScpIdReportUid"))
        {
          _MercScpIdReportUid = value; 
          RaisePropertyChanged("MercScpIdReportUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Mac Address value
    /// </summary>
    
    [DataMember]
    
    public string MacAddress 
    { 
      get { return _MacAddress; }
      set 
      { 
        if(HasValueChanged(_MacAddress, value, "MacAddress"))
        {
          _MacAddress = value; 
          RaisePropertyChanged("MacAddress");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Driver Spc Id value
    /// </summary>
    
    [DataMember]
    
    public int DriverSpcId 
    { 
      get { return _DriverSpcId; }
      set 
      { 
        if(HasValueChanged(_DriverSpcId, value, "DriverSpcId"))
        {
          _DriverSpcId = value; 
          RaisePropertyChanged("DriverSpcId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Scp Id value
    /// </summary>
    
    [DataMember]
    
    public int ScpId 
    { 
      get { return _ScpId; }
      set 
      { 
        if(HasValueChanged(_ScpId, value, "ScpId"))
        {
          _ScpId = value; 
          RaisePropertyChanged("ScpId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Serial Number value
    /// </summary>
    
    [DataMember]
    
    public string SerialNumber 
    { 
      get { return _SerialNumber; }
      set 
      { 
        if(HasValueChanged(_SerialNumber, value, "SerialNumber"))
        {
          _SerialNumber = value; 
          RaisePropertyChanged("SerialNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Id value
    /// </summary>
    
    [DataMember]
    
    public string DeviceId 
    { 
      get { return _DeviceId; }
      set 
      { 
        if(HasValueChanged(_DeviceId, value, "DeviceId"))
        {
          _DeviceId = value; 
          RaisePropertyChanged("DeviceId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Version value
    /// </summary>
    
    [DataMember]
    
    public string DeviceVersion 
    { 
      get { return _DeviceVersion; }
      set 
      { 
        if(HasValueChanged(_DeviceVersion, value, "DeviceVersion"))
        {
          _DeviceVersion = value; 
          RaisePropertyChanged("DeviceVersion");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Software Revision Major value
    /// </summary>
    
    [DataMember]
    
    public int SoftwareRevisionMajor 
    { 
      get { return _SoftwareRevisionMajor; }
      set 
      { 
        if(HasValueChanged(_SoftwareRevisionMajor, value, "SoftwareRevisionMajor"))
        {
          _SoftwareRevisionMajor = value; 
          RaisePropertyChanged("SoftwareRevisionMajor");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Software Revision Minor value
    /// </summary>
    
    [DataMember]
    
    public int SoftwareRevisionMinor 
    { 
      get { return _SoftwareRevisionMinor; }
      set 
      { 
        if(HasValueChanged(_SoftwareRevisionMinor, value, "SoftwareRevisionMinor"))
        {
          _SoftwareRevisionMinor = value; 
          RaisePropertyChanged("SoftwareRevisionMinor");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cumulative Build Count value
    /// </summary>
    
    [DataMember]
    
    public int CumulativeBuildCount 
    { 
      get { return _CumulativeBuildCount; }
      set 
      { 
        if(HasValueChanged(_CumulativeBuildCount, value, "CumulativeBuildCount"))
        {
          _CumulativeBuildCount = value; 
          RaisePropertyChanged("CumulativeBuildCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Needs Configuration value
    /// </summary>
    
    [DataMember]
    
    public bool NeedsConfiguration 
    { 
      get { return _NeedsConfiguration; }
      set 
      { 
        if(HasValueChanged(_NeedsConfiguration, value, "NeedsConfiguration"))
        {
          _NeedsConfiguration = value; 
          RaisePropertyChanged("NeedsConfiguration");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Tls Status value
    /// </summary>
    
    [DataMember]
    
    public string TlsStatus 
    { 
      get { return _TlsStatus; }
      set 
      { 
        if(HasValueChanged(_TlsStatus, value, "TlsStatus"))
        {
          _TlsStatus = value; 
          RaisePropertyChanged("TlsStatus");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Oem Code value
    /// </summary>
    
    [DataMember]
    
    public int OemCode 
    { 
      get { return _OemCode; }
      set 
      { 
        if(HasValueChanged(_OemCode, value, "OemCode"))
        {
          _OemCode = value; 
          RaisePropertyChanged("OemCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Current Operating Mode value
    /// </summary>
    
    [DataMember]
    
    public short CurrentOperatingMode 
    { 
      get { return _CurrentOperatingMode; }
      set 
      { 
        if(HasValueChanged(_CurrentOperatingMode, value, "CurrentOperatingMode"))
        {
          _CurrentOperatingMode = value; 
          RaisePropertyChanged("CurrentOperatingMode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input 1 State value
    /// </summary>
    
    [DataMember]
    
    public short Input1State 
    { 
      get { return _Input1State; }
      set 
      { 
        if(HasValueChanged(_Input1State, value, "Input1State"))
        {
          _Input1State = value; 
          RaisePropertyChanged("Input1State");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input 2 State value
    /// </summary>
    
    [DataMember]
    
    public short Input2State 
    { 
      get { return _Input2State; }
      set 
      { 
        if(HasValueChanged(_Input2State, value, "Input2State"))
        {
          _Input2State = value; 
          RaisePropertyChanged("Input2State");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input 3 State value
    /// </summary>
    
    [DataMember]
    
    public short Input3State 
    { 
      get { return _Input3State; }
      set 
      { 
        if(HasValueChanged(_Input3State, value, "Input3State"))
        {
          _Input3State = value; 
          RaisePropertyChanged("Input3State");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Bio Db 1 Active value
    /// </summary>
    
    [DataMember]
    
    public int BioDb1Active 
    { 
      get { return _BioDb1Active; }
      set 
      { 
        if(HasValueChanged(_BioDb1Active, value, "BioDb1Active"))
        {
          _BioDb1Active = value; 
          RaisePropertyChanged("BioDb1Active");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Bio Db 1 Max value
    /// </summary>
    
    [DataMember]
    
    public int BioDb1Max 
    { 
      get { return _BioDb1Max; }
      set 
      { 
        if(HasValueChanged(_BioDb1Max, value, "BioDb1Max"))
        {
          _BioDb1Max = value; 
          RaisePropertyChanged("BioDb1Max");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Bio Db 2 Active value
    /// </summary>
    
    [DataMember]
    
    public int BioDb2Active 
    { 
      get { return _BioDb2Active; }
      set 
      { 
        if(HasValueChanged(_BioDb2Active, value, "BioDb2Active"))
        {
          _BioDb2Active = value; 
          RaisePropertyChanged("BioDb2Active");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Bio Db 2 Max value
    /// </summary>
    
    [DataMember]
    
    public int BioDb2Max 
    { 
      get { return _BioDb2Max; }
      set 
      { 
        if(HasValueChanged(_BioDb2Max, value, "BioDb2Max"))
        {
          _BioDb2Max = value; 
          RaisePropertyChanged("BioDb2Max");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Asset Db Active value
    /// </summary>
    
    [DataMember]
    
    public int AssetDbActive 
    { 
      get { return _AssetDbActive; }
      set 
      { 
        if(HasValueChanged(_AssetDbActive, value, "AssetDbActive"))
        {
          _AssetDbActive = value; 
          RaisePropertyChanged("AssetDbActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Asset Db Max value
    /// </summary>
    
    [DataMember]
    
    public int AssetDbMax 
    { 
      get { return _AssetDbMax; }
      set 
      { 
        if(HasValueChanged(_AssetDbMax, value, "AssetDbMax"))
        {
          _AssetDbMax = value; 
          RaisePropertyChanged("AssetDbMax");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Firmware Advisory value
    /// </summary>
    
    [DataMember]
    
    public string FirmwareAdvisory 
    { 
      get { return _FirmwareAdvisory; }
      set 
      { 
        if(HasValueChanged(_FirmwareAdvisory, value, "FirmwareAdvisory"))
        {
          _FirmwareAdvisory = value; 
          RaisePropertyChanged("FirmwareAdvisory");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dip Switch Current value
    /// </summary>
    
    [DataMember]
    
    public short DipSwitchCurrent 
    { 
      get { return _DipSwitchCurrent; }
      set 
      { 
        if(HasValueChanged(_DipSwitchCurrent, value, "DipSwitchCurrent"))
        {
          _DipSwitchCurrent = value; 
          RaisePropertyChanged("DipSwitchCurrent");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dip Switch Power Up value
    /// </summary>
    
    [DataMember]
    
    public short DipSwitchPowerUp 
    { 
      get { return _DipSwitchPowerUp; }
      set 
      { 
        if(HasValueChanged(_DipSwitchPowerUp, value, "DipSwitchPowerUp"))
        {
          _DipSwitchPowerUp = value; 
          RaisePropertyChanged("DipSwitchPowerUp");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Db Active Records value
    /// </summary>
    
    [DataMember]
    
    public int DbActiveRecords 
    { 
      get { return _DbActiveRecords; }
      set 
      { 
        if(HasValueChanged(_DbActiveRecords, value, "DbActiveRecords"))
        {
          _DbActiveRecords = value; 
          RaisePropertyChanged("DbActiveRecords");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Db Max Size value
    /// </summary>
    
    [DataMember]
    
    public int DbMaxSize 
    { 
      get { return _DbMaxSize; }
      set 
      { 
        if(HasValueChanged(_DbMaxSize, value, "DbMaxSize"))
        {
          _DbMaxSize = value; 
          RaisePropertyChanged("DbMaxSize");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Current Clock value
    /// </summary>
    
    [DataMember]
    
    public long CurrentClock 
    { 
      get { return _CurrentClock; }
      set 
      { 
        if(HasValueChanged(_CurrentClock, value, "CurrentClock"))
        {
          _CurrentClock = value; 
          RaisePropertyChanged("CurrentClock");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Ram Free value
    /// </summary>
    
    [DataMember]
    
    public int RamFree 
    { 
      get { return _RamFree; }
      set 
      { 
        if(HasValueChanged(_RamFree, value, "RamFree"))
        {
          _RamFree = value; 
          RaisePropertyChanged("RamFree");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Ram Size value
    /// </summary>
    
    [DataMember]
    
    public int RamSize 
    { 
      get { return _RamSize; }
      set 
      { 
        if(HasValueChanged(_RamSize, value, "RamSize"))
        {
          _RamSize = value; 
          RaisePropertyChanged("RamSize");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Name value
    /// </summary>
    
    [DataMember]
    
    public string InsertName 
    { 
      get { return _InsertName; }
      set 
      { 
        if(HasValueChanged(_InsertName, value, "InsertName"))
        {
          _InsertName = value; 
          RaisePropertyChanged("InsertName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset InsertDate 
    { 
      get { return _InsertDate; }
      set 
      { 
        if(HasValueChanged(_InsertDate, value, "InsertDate"))
        {
          _InsertDate = value; 
          RaisePropertyChanged("InsertDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Name value
    /// </summary>
    
    [DataMember]
    
    public string UpdateName 
    { 
      get { return _UpdateName; }
      set 
      { 
        if(HasValueChanged(_UpdateName, value, "UpdateName"))
        {
          _UpdateName = value; 
          RaisePropertyChanged("UpdateName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset UpdateDate 
    { 
      get { return _UpdateDate; }
      set 
      { 
        if(HasValueChanged(_UpdateDate, value, "UpdateDate"))
        {
          _UpdateDate = value; 
          RaisePropertyChanged("UpdateDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Concurrency Value value
    /// </summary>
    
    [DataMember]
    
    public short ConcurrencyValue 
    { 
      get { return _ConcurrencyValue; }
      set 
      { 
        if(HasValueChanged(_ConcurrencyValue, value, "ConcurrencyValue"))
        {
          _ConcurrencyValue = value; 
          RaisePropertyChanged("ConcurrencyValue");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Merc Scp Id Report UidOld value
    /// </summary>
    
    public Guid MercScpIdReportUidOld
    { 
      get { return _MercScpIdReportUidOld; }
      set 
      { 
        if(HasValueChanged(_MercScpIdReportUidOld, value, "MercScpIdReportUid"))
        {
          _MercScpIdReportUidOld = value; 
          RaisePropertyChanged("MercScpIdReportUidOld");
        }
      } 
    }
    #endregion
  }
}
