using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsUserRequirementsPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsUserRequirementsPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _UserRequirementsId = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private bool _PasswordCannotContainName = false;
    private short _PasswordMinimumLength = 0;
    private short _PasswordMaximumLength = 0;
    private short _PasswordMinimumChangeCharacters = 0;
    private short _MinimumPasswordAge = 0;
    private short _MaximumPasswordAge = 0;
    private short _MaintainPasswordHistoryCount = 0;
    private short _DefaultExpirationDays = 0;
    private short _LockoutUserIfInactiveForDays = 0;
    private bool _AllowPasswordChangeAttempt = false;
    private short _RequireLowerCaseLetterCount = 0;
    private short _RequireUpperCaseLetterCount = 0;
    private short _RequireNumericDigitCount = 0;
    private short _RequireSpecialCharacterCount = 0;
    private bool _UseCustomRegEx = false;
    private string _PasswordCustomRegEx = string.Empty;
    private string _RegularExpressionDescription = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private bool _RequireTwoFactorAuthentication = false;
    private Guid _UserRequirementsIdOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the User Requirements Id value
    /// </summary>
    
    [DataMember]
    
    public Guid UserRequirementsId 
    { 
      get { return _UserRequirementsId; }
      set 
      { 
        if(HasValueChanged(_UserRequirementsId, value, "UserRequirementsId"))
        {
          _UserRequirementsId = value; 
          RaisePropertyChanged("UserRequirementsId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Id value
    /// </summary>
    
    [DataMember]
    
    public Guid EntityId 
    { 
      get { return _EntityId; }
      set 
      { 
        if(HasValueChanged(_EntityId, value, "EntityId"))
        {
          _EntityId = value; 
          RaisePropertyChanged("EntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Password Cannot Contain Name value
    /// </summary>
    
    [DataMember]
    
    public bool PasswordCannotContainName 
    { 
      get { return _PasswordCannotContainName; }
      set 
      { 
        if(HasValueChanged(_PasswordCannotContainName, value, "PasswordCannotContainName"))
        {
          _PasswordCannotContainName = value; 
          RaisePropertyChanged("PasswordCannotContainName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Password Minimum Length value
    /// </summary>
    
    [DataMember]
    
    public short PasswordMinimumLength 
    { 
      get { return _PasswordMinimumLength; }
      set 
      { 
        if(HasValueChanged(_PasswordMinimumLength, value, "PasswordMinimumLength"))
        {
          _PasswordMinimumLength = value; 
          RaisePropertyChanged("PasswordMinimumLength");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Password Maximum Length value
    /// </summary>
    
    [DataMember]
    
    public short PasswordMaximumLength 
    { 
      get { return _PasswordMaximumLength; }
      set 
      { 
        if(HasValueChanged(_PasswordMaximumLength, value, "PasswordMaximumLength"))
        {
          _PasswordMaximumLength = value; 
          RaisePropertyChanged("PasswordMaximumLength");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Password Minimum Change Characters value
    /// </summary>
    
    [DataMember]
    
    public short PasswordMinimumChangeCharacters 
    { 
      get { return _PasswordMinimumChangeCharacters; }
      set 
      { 
        if(HasValueChanged(_PasswordMinimumChangeCharacters, value, "PasswordMinimumChangeCharacters"))
        {
          _PasswordMinimumChangeCharacters = value; 
          RaisePropertyChanged("PasswordMinimumChangeCharacters");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Minimum Password Age value
    /// </summary>
    
    [DataMember]
    
    public short MinimumPasswordAge 
    { 
      get { return _MinimumPasswordAge; }
      set 
      { 
        if(HasValueChanged(_MinimumPasswordAge, value, "MinimumPasswordAge"))
        {
          _MinimumPasswordAge = value; 
          RaisePropertyChanged("MinimumPasswordAge");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Maximum Password Age value
    /// </summary>
    
    [DataMember]
    
    public short MaximumPasswordAge 
    { 
      get { return _MaximumPasswordAge; }
      set 
      { 
        if(HasValueChanged(_MaximumPasswordAge, value, "MaximumPasswordAge"))
        {
          _MaximumPasswordAge = value; 
          RaisePropertyChanged("MaximumPasswordAge");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Maintain Password History Count value
    /// </summary>
    
    [DataMember]
    
    public short MaintainPasswordHistoryCount 
    { 
      get { return _MaintainPasswordHistoryCount; }
      set 
      { 
        if(HasValueChanged(_MaintainPasswordHistoryCount, value, "MaintainPasswordHistoryCount"))
        {
          _MaintainPasswordHistoryCount = value; 
          RaisePropertyChanged("MaintainPasswordHistoryCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Default Expiration Days value
    /// </summary>
    
    [DataMember]
    
    public short DefaultExpirationDays 
    { 
      get { return _DefaultExpirationDays; }
      set 
      { 
        if(HasValueChanged(_DefaultExpirationDays, value, "DefaultExpirationDays"))
        {
          _DefaultExpirationDays = value; 
          RaisePropertyChanged("DefaultExpirationDays");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lockout User If Inactive For Days value
    /// </summary>
    
    [DataMember]
    
    public short LockoutUserIfInactiveForDays 
    { 
      get { return _LockoutUserIfInactiveForDays; }
      set 
      { 
        if(HasValueChanged(_LockoutUserIfInactiveForDays, value, "LockoutUserIfInactiveForDays"))
        {
          _LockoutUserIfInactiveForDays = value; 
          RaisePropertyChanged("LockoutUserIfInactiveForDays");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Allow Password Change Attempt value
    /// </summary>
    
    [DataMember]
    
    public bool AllowPasswordChangeAttempt 
    { 
      get { return _AllowPasswordChangeAttempt; }
      set 
      { 
        if(HasValueChanged(_AllowPasswordChangeAttempt, value, "AllowPasswordChangeAttempt"))
        {
          _AllowPasswordChangeAttempt = value; 
          RaisePropertyChanged("AllowPasswordChangeAttempt");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Require Lower Case Letter Count value
    /// </summary>
    
    [DataMember]
    
    public short RequireLowerCaseLetterCount 
    { 
      get { return _RequireLowerCaseLetterCount; }
      set 
      { 
        if(HasValueChanged(_RequireLowerCaseLetterCount, value, "RequireLowerCaseLetterCount"))
        {
          _RequireLowerCaseLetterCount = value; 
          RaisePropertyChanged("RequireLowerCaseLetterCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Require Upper Case Letter Count value
    /// </summary>
    
    [DataMember]
    
    public short RequireUpperCaseLetterCount 
    { 
      get { return _RequireUpperCaseLetterCount; }
      set 
      { 
        if(HasValueChanged(_RequireUpperCaseLetterCount, value, "RequireUpperCaseLetterCount"))
        {
          _RequireUpperCaseLetterCount = value; 
          RaisePropertyChanged("RequireUpperCaseLetterCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Require Numeric Digit Count value
    /// </summary>
    
    [DataMember]
    
    public short RequireNumericDigitCount 
    { 
      get { return _RequireNumericDigitCount; }
      set 
      { 
        if(HasValueChanged(_RequireNumericDigitCount, value, "RequireNumericDigitCount"))
        {
          _RequireNumericDigitCount = value; 
          RaisePropertyChanged("RequireNumericDigitCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Require Special Character Count value
    /// </summary>
    
    [DataMember]
    
    public short RequireSpecialCharacterCount 
    { 
      get { return _RequireSpecialCharacterCount; }
      set 
      { 
        if(HasValueChanged(_RequireSpecialCharacterCount, value, "RequireSpecialCharacterCount"))
        {
          _RequireSpecialCharacterCount = value; 
          RaisePropertyChanged("RequireSpecialCharacterCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Use Custom Reg Ex value
    /// </summary>
    
    [DataMember]
    
    public bool UseCustomRegEx 
    { 
      get { return _UseCustomRegEx; }
      set 
      { 
        if(HasValueChanged(_UseCustomRegEx, value, "UseCustomRegEx"))
        {
          _UseCustomRegEx = value; 
          RaisePropertyChanged("UseCustomRegEx");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Password Custom Reg Ex value
    /// </summary>
    
    [DataMember]
    
    public string PasswordCustomRegEx 
    { 
      get { return _PasswordCustomRegEx; }
      set 
      { 
        if(HasValueChanged(_PasswordCustomRegEx, value, "PasswordCustomRegEx"))
        {
          _PasswordCustomRegEx = value; 
          RaisePropertyChanged("PasswordCustomRegEx");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Regular Expression Description value
    /// </summary>
    
    [DataMember]
    
    public string RegularExpressionDescription 
    { 
      get { return _RegularExpressionDescription; }
      set 
      { 
        if(HasValueChanged(_RegularExpressionDescription, value, "RegularExpressionDescription"))
        {
          _RegularExpressionDescription = value; 
          RaisePropertyChanged("RegularExpressionDescription");
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
    /// Get/Set the Require Two Factor Authentication value
    /// </summary>
    
    [DataMember]
    
    public bool RequireTwoFactorAuthentication 
    { 
      get { return _RequireTwoFactorAuthentication; }
      set 
      { 
        if(HasValueChanged(_RequireTwoFactorAuthentication, value, "RequireTwoFactorAuthentication"))
        {
          _RequireTwoFactorAuthentication = value; 
          RaisePropertyChanged("RequireTwoFactorAuthentication");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the User Requirements IdOld value
    /// </summary>
    
    public Guid UserRequirementsIdOld
    { 
      get { return _UserRequirementsIdOld; }
      set 
      { 
        if(HasValueChanged(_UserRequirementsIdOld, value, "UserRequirementsId"))
        {
          _UserRequirementsIdOld = value; 
          RaisePropertyChanged("UserRequirementsIdOld");
        }
      } 
    }
    #endregion
  }
}
