using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the Cluster_GetPanelCommonLoadDataPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class Cluster_GetPanelCommonLoadDataPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _ClusterUid = Guid.Empty;
    private int _ClusterNumber = 0;
    private string _ClusterName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private int _ClusterGroupId = 0;
    private bool _IsActive = false;
    private short _AbaStartDigit = 0;
    private short _AbaStopDigit = 0;
    private bool _AbaFoldOption = false;
    private bool _AbaClipOption = false;
    private short _WiegandStartBit = 0;
    private short _WiegandStopBit = 0;
    private short _CardaxStartBit = 0;
    private short _CardaxStopBit = 0;
    private short _LockoutAfterInvalidAttempts = 0;
    private int _LockoutDurationSeconds = 0;
    private int _AccessRuleOverrideTimeout = 0;
    private int _UnlimitedCredentialTimeout = 0;
    private string _TimeZoneId = string.Empty;
    private int _ActivateCrisisIOGroupNumber = 0;
    private int _ResetCrisisIOGroupNumber = 0;
    private short _LockedLED = 0;
    private short _UnlockedLED = 0;
    private string _ClusterTypeCode = string.Empty;
    private short _CredentialDataLength = 0;
    private short _TimeScheduleTypeCode = 0;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ClusterUid 
    { 
      get { return _ClusterUid; }
      set 
      { 
        if(HasValueChanged(_ClusterUid, value, "ClusterUid"))
        {
          _ClusterUid = value; 
          RaisePropertyChanged("ClusterUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Number value
    /// </summary>
    
    [DataMember]
    
    public int ClusterNumber 
    { 
      get { return _ClusterNumber; }
      set 
      { 
        if(HasValueChanged(_ClusterNumber, value, "ClusterNumber"))
        {
          _ClusterNumber = value; 
          RaisePropertyChanged("ClusterNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Name value
    /// </summary>
    
    [DataMember]
    
    public string ClusterName 
    { 
      get { return _ClusterName; }
      set 
      { 
        if(HasValueChanged(_ClusterName, value, "ClusterName"))
        {
          _ClusterName = value; 
          RaisePropertyChanged("ClusterName");
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
    /// Get/Set the Cluster Group Id value
    /// </summary>
    
    [DataMember]
    
    public int ClusterGroupId 
    { 
      get { return _ClusterGroupId; }
      set 
      { 
        if(HasValueChanged(_ClusterGroupId, value, "ClusterGroupId"))
        {
          _ClusterGroupId = value; 
          RaisePropertyChanged("ClusterGroupId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsActive 
    { 
      get { return _IsActive; }
      set 
      { 
        if(HasValueChanged(_IsActive, value, "IsActive"))
        {
          _IsActive = value; 
          RaisePropertyChanged("IsActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Aba Start Digit value
    /// </summary>
    
    [DataMember]
    
    public short AbaStartDigit 
    { 
      get { return _AbaStartDigit; }
      set 
      { 
        if(HasValueChanged(_AbaStartDigit, value, "AbaStartDigit"))
        {
          _AbaStartDigit = value; 
          RaisePropertyChanged("AbaStartDigit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Aba Stop Digit value
    /// </summary>
    
    [DataMember]
    
    public short AbaStopDigit 
    { 
      get { return _AbaStopDigit; }
      set 
      { 
        if(HasValueChanged(_AbaStopDigit, value, "AbaStopDigit"))
        {
          _AbaStopDigit = value; 
          RaisePropertyChanged("AbaStopDigit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Aba Fold Option value
    /// </summary>
    
    [DataMember]
    
    public bool AbaFoldOption 
    { 
      get { return _AbaFoldOption; }
      set 
      { 
        if(HasValueChanged(_AbaFoldOption, value, "AbaFoldOption"))
        {
          _AbaFoldOption = value; 
          RaisePropertyChanged("AbaFoldOption");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Aba Clip Option value
    /// </summary>
    
    [DataMember]
    
    public bool AbaClipOption 
    { 
      get { return _AbaClipOption; }
      set 
      { 
        if(HasValueChanged(_AbaClipOption, value, "AbaClipOption"))
        {
          _AbaClipOption = value; 
          RaisePropertyChanged("AbaClipOption");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Wiegand Start Bit value
    /// </summary>
    
    [DataMember]
    
    public short WiegandStartBit 
    { 
      get { return _WiegandStartBit; }
      set 
      { 
        if(HasValueChanged(_WiegandStartBit, value, "WiegandStartBit"))
        {
          _WiegandStartBit = value; 
          RaisePropertyChanged("WiegandStartBit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Wiegand Stop Bit value
    /// </summary>
    
    [DataMember]
    
    public short WiegandStopBit 
    { 
      get { return _WiegandStopBit; }
      set 
      { 
        if(HasValueChanged(_WiegandStopBit, value, "WiegandStopBit"))
        {
          _WiegandStopBit = value; 
          RaisePropertyChanged("WiegandStopBit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cardax Start Bit value
    /// </summary>
    
    [DataMember]
    
    public short CardaxStartBit 
    { 
      get { return _CardaxStartBit; }
      set 
      { 
        if(HasValueChanged(_CardaxStartBit, value, "CardaxStartBit"))
        {
          _CardaxStartBit = value; 
          RaisePropertyChanged("CardaxStartBit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cardax Stop Bit value
    /// </summary>
    
    [DataMember]
    
    public short CardaxStopBit 
    { 
      get { return _CardaxStopBit; }
      set 
      { 
        if(HasValueChanged(_CardaxStopBit, value, "CardaxStopBit"))
        {
          _CardaxStopBit = value; 
          RaisePropertyChanged("CardaxStopBit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lockout After Invalid Attempts value
    /// </summary>
    
    [DataMember]
    
    public short LockoutAfterInvalidAttempts 
    { 
      get { return _LockoutAfterInvalidAttempts; }
      set 
      { 
        if(HasValueChanged(_LockoutAfterInvalidAttempts, value, "LockoutAfterInvalidAttempts"))
        {
          _LockoutAfterInvalidAttempts = value; 
          RaisePropertyChanged("LockoutAfterInvalidAttempts");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lockout Duration Seconds value
    /// </summary>
    
    [DataMember]
    
    public int LockoutDurationSeconds 
    { 
      get { return _LockoutDurationSeconds; }
      set 
      { 
        if(HasValueChanged(_LockoutDurationSeconds, value, "LockoutDurationSeconds"))
        {
          _LockoutDurationSeconds = value; 
          RaisePropertyChanged("LockoutDurationSeconds");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Rule Override Timeout value
    /// </summary>
    
    [DataMember]
    
    public int AccessRuleOverrideTimeout 
    { 
      get { return _AccessRuleOverrideTimeout; }
      set 
      { 
        if(HasValueChanged(_AccessRuleOverrideTimeout, value, "AccessRuleOverrideTimeout"))
        {
          _AccessRuleOverrideTimeout = value; 
          RaisePropertyChanged("AccessRuleOverrideTimeout");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Unlimited Credential Timeout value
    /// </summary>
    
    [DataMember]
    
    public int UnlimitedCredentialTimeout 
    { 
      get { return _UnlimitedCredentialTimeout; }
      set 
      { 
        if(HasValueChanged(_UnlimitedCredentialTimeout, value, "UnlimitedCredentialTimeout"))
        {
          _UnlimitedCredentialTimeout = value; 
          RaisePropertyChanged("UnlimitedCredentialTimeout");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Zone Id value
    /// </summary>
    
    [DataMember]
    
    public string TimeZoneId 
    { 
      get { return _TimeZoneId; }
      set 
      { 
        if(HasValueChanged(_TimeZoneId, value, "TimeZoneId"))
        {
          _TimeZoneId = value; 
          RaisePropertyChanged("TimeZoneId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activate Crisis IO Group Number value
    /// </summary>
    
    [DataMember]
    
    public int ActivateCrisisIOGroupNumber 
    { 
      get { return _ActivateCrisisIOGroupNumber; }
      set 
      { 
        if(HasValueChanged(_ActivateCrisisIOGroupNumber, value, "ActivateCrisisIOGroupNumber"))
        {
          _ActivateCrisisIOGroupNumber = value; 
          RaisePropertyChanged("ActivateCrisisIOGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Reset Crisis IO Group Number value
    /// </summary>
    
    [DataMember]
    
    public int ResetCrisisIOGroupNumber 
    { 
      get { return _ResetCrisisIOGroupNumber; }
      set 
      { 
        if(HasValueChanged(_ResetCrisisIOGroupNumber, value, "ResetCrisisIOGroupNumber"))
        {
          _ResetCrisisIOGroupNumber = value; 
          RaisePropertyChanged("ResetCrisisIOGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Locked LED value
    /// </summary>
    
    [DataMember]
    
    public short LockedLED 
    { 
      get { return _LockedLED; }
      set 
      { 
        if(HasValueChanged(_LockedLED, value, "LockedLED"))
        {
          _LockedLED = value; 
          RaisePropertyChanged("LockedLED");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Unlocked LED value
    /// </summary>
    
    [DataMember]
    
    public short UnlockedLED 
    { 
      get { return _UnlockedLED; }
      set 
      { 
        if(HasValueChanged(_UnlockedLED, value, "UnlockedLED"))
        {
          _UnlockedLED = value; 
          RaisePropertyChanged("UnlockedLED");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Type Code value
    /// </summary>
    
    [DataMember]
    
    public string ClusterTypeCode 
    { 
      get { return _ClusterTypeCode; }
      set 
      { 
        if(HasValueChanged(_ClusterTypeCode, value, "ClusterTypeCode"))
        {
          _ClusterTypeCode = value; 
          RaisePropertyChanged("ClusterTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Data Length value
    /// </summary>
    
    [DataMember]
    
    public short CredentialDataLength 
    { 
      get { return _CredentialDataLength; }
      set 
      { 
        if(HasValueChanged(_CredentialDataLength, value, "CredentialDataLength"))
        {
          _CredentialDataLength = value; 
          RaisePropertyChanged("CredentialDataLength");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Schedule Type Code value
    /// </summary>
    
    [DataMember]
    
    public short TimeScheduleTypeCode 
    { 
      get { return _TimeScheduleTypeCode; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleTypeCode, value, "TimeScheduleTypeCode"))
        {
          _TimeScheduleTypeCode = value; 
          RaisePropertyChanged("TimeScheduleTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the return value value
    /// </summary>
    
    [DataMember]
    
    public int RETURNVALUE 
    { 
      get { return _RETURNVALUE; }
      set 
      { 
        if(HasValueChanged(_RETURNVALUE, value, "@RETURN_VALUE"))
        {
          _RETURNVALUE = value; 
          RaisePropertyChanged("RETURNVALUE");
        }
      } 
    }
        

    #endregion
  }
}
