using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the Credential_GetPanelLoadDataByPersonUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class Credential_GetPanelLoadDataByPersonUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _PersonUid = Guid.Empty;
    private string _FirstName = string.Empty;
    private string _LastName = string.Empty;
    private string _PersonId = string.Empty;
    private DateTimeOffset _PersonActivationDateTime = DateTimeOffset.Now;
    private DateTimeOffset _PersonExpirationDateTime = DateTimeOffset.Now;
    private DateTimeOffset _PersonTerminationDate = DateTimeOffset.Now;
    private bool _VeryImportantPerson = false;
    private bool _HasPhysicalDisability = false;
    private bool _HasVertigo = false;
    private bool _PersonInactiveState = false;
    private bool _PINExempt = false;
    private bool _PassbackExempt = false;
    private bool _CanToggleLockState = false;
    private bool _PersonAccessControlPropertiesIsActive = false;
    private int _PIN = 0;
    private Guid _PersonAccessControlPropertiesAccessProfileUid = Guid.Empty;
    private Guid _PersonCredentialUid = Guid.Empty;
    private Guid _CredentialUid = Guid.Empty;
    private DateTimeOffset _CredentialActivationDateTime = DateTimeOffset.Now;
    private DateTimeOffset _CredentialExpirationDateTime = DateTimeOffset.Now;
    private short _CredentialUsageCount = 0;
    private bool _DuressEnabled = false;
    private bool _ReverseBits = false;
    private bool _TraceEnabled = false;
    private bool _PersonCredentialIsActive = false;
    private short _CredentialRoleCode = 0;
    private short _CredentialActivationModeCode = 0;
    private short _CredentialExpirationModeCode = 0;
    private short _NoServerReplyBehaviorCode = 0;
    private short _DeferToServerBehaviorCode = 0;
    private DateTimeOffset _LastPanelImpactingChangeDate = DateTimeOffset.Now;
    private byte[] _CredentialBits = null;
    private string _CredentialFormatDisplay = string.Empty;
    private short _CredentialFormatCode = 0;
    private short _BitCount = 0;
    private byte[] _CardBinaryData = null;
    private string _CardNumber = string.Empty;
    private bool _CardNumberIsHex = false;
    private long _FacCompSiteCode = 0;
    private long _IdCode = 0;
    private long _IssueCode = 0;
    private DateTimeOffset _LcdStartingDate = DateTimeOffset.Now;
    private DateTimeOffset _LcdEndingDate = DateTimeOffset.Now;
    private string _LcdMessage = string.Empty;
    private short _LcdMessageDisplayModeCode = 0;
    private Guid _ClusterUid = Guid.Empty;
    private string _ClusterName = string.Empty;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private string _ClusterTypeCode = string.Empty;
    private bool _ClusterIsActive = false;
    private short _CredentialDataLength = 0;
    private int _PanelNumber = 0;
    private int _CpuNumber = 0;
    private int _AccessGroup1 = 0;
    private int _AccessGroup2 = 0;
    private int _AccessGroup3 = 0;
    private int _AccessGroup4 = 0;
    private short _PersonalAccessGroupNumber = 0;
    private int _InputOutputGroup1 = 0;
    private int _InputOutputGroup2 = 0;
    private int _InputOutputGroup3 = 0;
    private int _InputOutputGroup4 = 0;
    private bool _OtisSplitGroupOperation = false;
    private bool _OtisCimOverride = false;
    private Guid _CpuUid = Guid.Empty;
    private string _ServerAddress = string.Empty;
    private bool _IsConnected = false;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Person Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonUid 
    { 
      get { return _PersonUid; }
      set 
      { 
        if(HasValueChanged(_PersonUid, value, "PersonUid"))
        {
          _PersonUid = value; 
          RaisePropertyChanged("PersonUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the First Name value
    /// </summary>
    
    [DataMember]
    
    public string FirstName 
    { 
      get { return _FirstName; }
      set 
      { 
        if(HasValueChanged(_FirstName, value, "FirstName"))
        {
          _FirstName = value; 
          RaisePropertyChanged("FirstName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Last Name value
    /// </summary>
    
    [DataMember]
    
    public string LastName 
    { 
      get { return _LastName; }
      set 
      { 
        if(HasValueChanged(_LastName, value, "LastName"))
        {
          _LastName = value; 
          RaisePropertyChanged("LastName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Id value
    /// </summary>
    
    [DataMember]
    
    public string PersonId 
    { 
      get { return _PersonId; }
      set 
      { 
        if(HasValueChanged(_PersonId, value, "PersonId"))
        {
          _PersonId = value; 
          RaisePropertyChanged("PersonId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Activation Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset PersonActivationDateTime 
    { 
      get { return _PersonActivationDateTime; }
      set 
      { 
        if(HasValueChanged(_PersonActivationDateTime, value, "PersonActivationDateTime"))
        {
          _PersonActivationDateTime = value; 
          RaisePropertyChanged("PersonActivationDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Expiration Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset PersonExpirationDateTime 
    { 
      get { return _PersonExpirationDateTime; }
      set 
      { 
        if(HasValueChanged(_PersonExpirationDateTime, value, "PersonExpirationDateTime"))
        {
          _PersonExpirationDateTime = value; 
          RaisePropertyChanged("PersonExpirationDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Termination Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset PersonTerminationDate 
    { 
      get { return _PersonTerminationDate; }
      set 
      { 
        if(HasValueChanged(_PersonTerminationDate, value, "PersonTerminationDate"))
        {
          _PersonTerminationDate = value; 
          RaisePropertyChanged("PersonTerminationDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Very Important Person value
    /// </summary>
    
    [DataMember]
    
    public bool VeryImportantPerson 
    { 
      get { return _VeryImportantPerson; }
      set 
      { 
        if(HasValueChanged(_VeryImportantPerson, value, "VeryImportantPerson"))
        {
          _VeryImportantPerson = value; 
          RaisePropertyChanged("VeryImportantPerson");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Has Physical Disability value
    /// </summary>
    
    [DataMember]
    
    public bool HasPhysicalDisability 
    { 
      get { return _HasPhysicalDisability; }
      set 
      { 
        if(HasValueChanged(_HasPhysicalDisability, value, "HasPhysicalDisability"))
        {
          _HasPhysicalDisability = value; 
          RaisePropertyChanged("HasPhysicalDisability");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Has Vertigo value
    /// </summary>
    
    [DataMember]
    
    public bool HasVertigo 
    { 
      get { return _HasVertigo; }
      set 
      { 
        if(HasValueChanged(_HasVertigo, value, "HasVertigo"))
        {
          _HasVertigo = value; 
          RaisePropertyChanged("HasVertigo");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Inactive State value
    /// </summary>
    
    [DataMember]
    
    public bool PersonInactiveState 
    { 
      get { return _PersonInactiveState; }
      set 
      { 
        if(HasValueChanged(_PersonInactiveState, value, "PersonInactiveState"))
        {
          _PersonInactiveState = value; 
          RaisePropertyChanged("PersonInactiveState");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the PIN Exempt value
    /// </summary>
    
    [DataMember]
    
    public bool PINExempt 
    { 
      get { return _PINExempt; }
      set 
      { 
        if(HasValueChanged(_PINExempt, value, "PINExempt"))
        {
          _PINExempt = value; 
          RaisePropertyChanged("PINExempt");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Passback Exempt value
    /// </summary>
    
    [DataMember]
    
    public bool PassbackExempt 
    { 
      get { return _PassbackExempt; }
      set 
      { 
        if(HasValueChanged(_PassbackExempt, value, "PassbackExempt"))
        {
          _PassbackExempt = value; 
          RaisePropertyChanged("PassbackExempt");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Can Toggle Lock State value
    /// </summary>
    
    [DataMember]
    
    public bool CanToggleLockState 
    { 
      get { return _CanToggleLockState; }
      set 
      { 
        if(HasValueChanged(_CanToggleLockState, value, "CanToggleLockState"))
        {
          _CanToggleLockState = value; 
          RaisePropertyChanged("CanToggleLockState");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Access Control Properties Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool PersonAccessControlPropertiesIsActive 
    { 
      get { return _PersonAccessControlPropertiesIsActive; }
      set 
      { 
        if(HasValueChanged(_PersonAccessControlPropertiesIsActive, value, "PersonAccessControlPropertiesIsActive"))
        {
          _PersonAccessControlPropertiesIsActive = value; 
          RaisePropertyChanged("PersonAccessControlPropertiesIsActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the PIN value
    /// </summary>
    
    [DataMember]
    
    public int PIN 
    { 
      get { return _PIN; }
      set 
      { 
        if(HasValueChanged(_PIN, value, "PIN"))
        {
          _PIN = value; 
          RaisePropertyChanged("PIN");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Access Control Properties Access Profile Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonAccessControlPropertiesAccessProfileUid 
    { 
      get { return _PersonAccessControlPropertiesAccessProfileUid; }
      set 
      { 
        if(HasValueChanged(_PersonAccessControlPropertiesAccessProfileUid, value, "PersonAccessControlPropertiesAccessProfileUid"))
        {
          _PersonAccessControlPropertiesAccessProfileUid = value; 
          RaisePropertyChanged("PersonAccessControlPropertiesAccessProfileUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Credential Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonCredentialUid 
    { 
      get { return _PersonCredentialUid; }
      set 
      { 
        if(HasValueChanged(_PersonCredentialUid, value, "PersonCredentialUid"))
        {
          _PersonCredentialUid = value; 
          RaisePropertyChanged("PersonCredentialUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialUid 
    { 
      get { return _CredentialUid; }
      set 
      { 
        if(HasValueChanged(_CredentialUid, value, "CredentialUid"))
        {
          _CredentialUid = value; 
          RaisePropertyChanged("CredentialUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Activation Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset CredentialActivationDateTime 
    { 
      get { return _CredentialActivationDateTime; }
      set 
      { 
        if(HasValueChanged(_CredentialActivationDateTime, value, "CredentialActivationDateTime"))
        {
          _CredentialActivationDateTime = value; 
          RaisePropertyChanged("CredentialActivationDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Expiration Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset CredentialExpirationDateTime 
    { 
      get { return _CredentialExpirationDateTime; }
      set 
      { 
        if(HasValueChanged(_CredentialExpirationDateTime, value, "CredentialExpirationDateTime"))
        {
          _CredentialExpirationDateTime = value; 
          RaisePropertyChanged("CredentialExpirationDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Usage Count value
    /// </summary>
    
    [DataMember]
    
    public short CredentialUsageCount 
    { 
      get { return _CredentialUsageCount; }
      set 
      { 
        if(HasValueChanged(_CredentialUsageCount, value, "CredentialUsageCount"))
        {
          _CredentialUsageCount = value; 
          RaisePropertyChanged("CredentialUsageCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Duress Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool DuressEnabled 
    { 
      get { return _DuressEnabled; }
      set 
      { 
        if(HasValueChanged(_DuressEnabled, value, "DuressEnabled"))
        {
          _DuressEnabled = value; 
          RaisePropertyChanged("DuressEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Reverse Bits value
    /// </summary>
    
    [DataMember]
    
    public bool ReverseBits 
    { 
      get { return _ReverseBits; }
      set 
      { 
        if(HasValueChanged(_ReverseBits, value, "ReverseBits"))
        {
          _ReverseBits = value; 
          RaisePropertyChanged("ReverseBits");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Trace Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool TraceEnabled 
    { 
      get { return _TraceEnabled; }
      set 
      { 
        if(HasValueChanged(_TraceEnabled, value, "TraceEnabled"))
        {
          _TraceEnabled = value; 
          RaisePropertyChanged("TraceEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Credential Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool PersonCredentialIsActive 
    { 
      get { return _PersonCredentialIsActive; }
      set 
      { 
        if(HasValueChanged(_PersonCredentialIsActive, value, "PersonCredentialIsActive"))
        {
          _PersonCredentialIsActive = value; 
          RaisePropertyChanged("PersonCredentialIsActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Role Code value
    /// </summary>
    
    [DataMember]
    
    public short CredentialRoleCode 
    { 
      get { return _CredentialRoleCode; }
      set 
      { 
        if(HasValueChanged(_CredentialRoleCode, value, "CredentialRoleCode"))
        {
          _CredentialRoleCode = value; 
          RaisePropertyChanged("CredentialRoleCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Activation Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short CredentialActivationModeCode 
    { 
      get { return _CredentialActivationModeCode; }
      set 
      { 
        if(HasValueChanged(_CredentialActivationModeCode, value, "CredentialActivationModeCode"))
        {
          _CredentialActivationModeCode = value; 
          RaisePropertyChanged("CredentialActivationModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Expiration Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short CredentialExpirationModeCode 
    { 
      get { return _CredentialExpirationModeCode; }
      set 
      { 
        if(HasValueChanged(_CredentialExpirationModeCode, value, "CredentialExpirationModeCode"))
        {
          _CredentialExpirationModeCode = value; 
          RaisePropertyChanged("CredentialExpirationModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the No Server Reply Behavior Code value
    /// </summary>
    
    [DataMember]
    
    public short NoServerReplyBehaviorCode 
    { 
      get { return _NoServerReplyBehaviorCode; }
      set 
      { 
        if(HasValueChanged(_NoServerReplyBehaviorCode, value, "NoServerReplyBehaviorCode"))
        {
          _NoServerReplyBehaviorCode = value; 
          RaisePropertyChanged("NoServerReplyBehaviorCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Defer To Server Behavior Code value
    /// </summary>
    
    [DataMember]
    
    public short DeferToServerBehaviorCode 
    { 
      get { return _DeferToServerBehaviorCode; }
      set 
      { 
        if(HasValueChanged(_DeferToServerBehaviorCode, value, "DeferToServerBehaviorCode"))
        {
          _DeferToServerBehaviorCode = value; 
          RaisePropertyChanged("DeferToServerBehaviorCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Last Panel Impacting Change Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset LastPanelImpactingChangeDate 
    { 
      get { return _LastPanelImpactingChangeDate; }
      set 
      { 
        if(HasValueChanged(_LastPanelImpactingChangeDate, value, "LastPanelImpactingChangeDate"))
        {
          _LastPanelImpactingChangeDate = value; 
          RaisePropertyChanged("LastPanelImpactingChangeDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Bits value
    /// </summary>
    
    [DataMember]
    
    public byte[] CredentialBits 
    { 
      get { return _CredentialBits; }
      set 
      { 
        if(HasValueChanged(_CredentialBits, value, "CredentialBits"))
        {
          _CredentialBits = value; 
          RaisePropertyChanged("CredentialBits");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Format Display value
    /// </summary>
    
    [DataMember]
    
    public string CredentialFormatDisplay 
    { 
      get { return _CredentialFormatDisplay; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatDisplay, value, "CredentialFormatDisplay"))
        {
          _CredentialFormatDisplay = value; 
          RaisePropertyChanged("CredentialFormatDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Format Code value
    /// </summary>
    
    [DataMember]
    
    public short CredentialFormatCode 
    { 
      get { return _CredentialFormatCode; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatCode, value, "CredentialFormatCode"))
        {
          _CredentialFormatCode = value; 
          RaisePropertyChanged("CredentialFormatCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Bit Count value
    /// </summary>
    
    [DataMember]
    
    public short BitCount 
    { 
      get { return _BitCount; }
      set 
      { 
        if(HasValueChanged(_BitCount, value, "BitCount"))
        {
          _BitCount = value; 
          RaisePropertyChanged("BitCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Card Binary Data value
    /// </summary>
    
    [DataMember]
    
    public byte[] CardBinaryData 
    { 
      get { return _CardBinaryData; }
      set 
      { 
        if(HasValueChanged(_CardBinaryData, value, "CardBinaryData"))
        {
          _CardBinaryData = value; 
          RaisePropertyChanged("CardBinaryData");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Card Number value
    /// </summary>
    
    [DataMember]
    
    public string CardNumber 
    { 
      get { return _CardNumber; }
      set 
      { 
        if(HasValueChanged(_CardNumber, value, "CardNumber"))
        {
          _CardNumber = value; 
          RaisePropertyChanged("CardNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Card Number Is Hex value
    /// </summary>
    
    [DataMember]
    
    public bool CardNumberIsHex 
    { 
      get { return _CardNumberIsHex; }
      set 
      { 
        if(HasValueChanged(_CardNumberIsHex, value, "CardNumberIsHex"))
        {
          _CardNumberIsHex = value; 
          RaisePropertyChanged("CardNumberIsHex");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Fac Comp Site Code value
    /// </summary>
    
    [DataMember]
    
    public long FacCompSiteCode 
    { 
      get { return _FacCompSiteCode; }
      set 
      { 
        if(HasValueChanged(_FacCompSiteCode, value, "FacCompSiteCode"))
        {
          _FacCompSiteCode = value; 
          RaisePropertyChanged("FacCompSiteCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Id Code value
    /// </summary>
    
    [DataMember]
    
    public long IdCode 
    { 
      get { return _IdCode; }
      set 
      { 
        if(HasValueChanged(_IdCode, value, "IdCode"))
        {
          _IdCode = value; 
          RaisePropertyChanged("IdCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Issue Code value
    /// </summary>
    
    [DataMember]
    
    public long IssueCode 
    { 
      get { return _IssueCode; }
      set 
      { 
        if(HasValueChanged(_IssueCode, value, "IssueCode"))
        {
          _IssueCode = value; 
          RaisePropertyChanged("IssueCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lcd Starting Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset LcdStartingDate 
    { 
      get { return _LcdStartingDate; }
      set 
      { 
        if(HasValueChanged(_LcdStartingDate, value, "LcdStartingDate"))
        {
          _LcdStartingDate = value; 
          RaisePropertyChanged("LcdStartingDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lcd Ending Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset LcdEndingDate 
    { 
      get { return _LcdEndingDate; }
      set 
      { 
        if(HasValueChanged(_LcdEndingDate, value, "LcdEndingDate"))
        {
          _LcdEndingDate = value; 
          RaisePropertyChanged("LcdEndingDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lcd Message value
    /// </summary>
    
    [DataMember]
    
    public string LcdMessage 
    { 
      get { return _LcdMessage; }
      set 
      { 
        if(HasValueChanged(_LcdMessage, value, "LcdMessage"))
        {
          _LcdMessage = value; 
          RaisePropertyChanged("LcdMessage");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lcd Message Display Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short LcdMessageDisplayModeCode 
    { 
      get { return _LcdMessageDisplayModeCode; }
      set 
      { 
        if(HasValueChanged(_LcdMessageDisplayModeCode, value, "LcdMessageDisplayModeCode"))
        {
          _LcdMessageDisplayModeCode = value; 
          RaisePropertyChanged("LcdMessageDisplayModeCode");
        }
      } 
    }
        
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
    /// Get/Set the Cluster Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool ClusterIsActive 
    { 
      get { return _ClusterIsActive; }
      set 
      { 
        if(HasValueChanged(_ClusterIsActive, value, "ClusterIsActive"))
        {
          _ClusterIsActive = value; 
          RaisePropertyChanged("ClusterIsActive");
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
    /// Get/Set the Panel Number value
    /// </summary>
    
    [DataMember]
    
    public int PanelNumber 
    { 
      get { return _PanelNumber; }
      set 
      { 
        if(HasValueChanged(_PanelNumber, value, "PanelNumber"))
        {
          _PanelNumber = value; 
          RaisePropertyChanged("PanelNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Number value
    /// </summary>
    
    [DataMember]
    
    public int CpuNumber 
    { 
      get { return _CpuNumber; }
      set 
      { 
        if(HasValueChanged(_CpuNumber, value, "CpuNumber"))
        {
          _CpuNumber = value; 
          RaisePropertyChanged("CpuNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group 1 value
    /// </summary>
    
    [DataMember]
    
    public int AccessGroup1 
    { 
      get { return _AccessGroup1; }
      set 
      { 
        if(HasValueChanged(_AccessGroup1, value, "AccessGroup1"))
        {
          _AccessGroup1 = value; 
          RaisePropertyChanged("AccessGroup1");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group 2 value
    /// </summary>
    
    [DataMember]
    
    public int AccessGroup2 
    { 
      get { return _AccessGroup2; }
      set 
      { 
        if(HasValueChanged(_AccessGroup2, value, "AccessGroup2"))
        {
          _AccessGroup2 = value; 
          RaisePropertyChanged("AccessGroup2");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group 3 value
    /// </summary>
    
    [DataMember]
    
    public int AccessGroup3 
    { 
      get { return _AccessGroup3; }
      set 
      { 
        if(HasValueChanged(_AccessGroup3, value, "AccessGroup3"))
        {
          _AccessGroup3 = value; 
          RaisePropertyChanged("AccessGroup3");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group 4 value
    /// </summary>
    
    [DataMember]
    
    public int AccessGroup4 
    { 
      get { return _AccessGroup4; }
      set 
      { 
        if(HasValueChanged(_AccessGroup4, value, "AccessGroup4"))
        {
          _AccessGroup4 = value; 
          RaisePropertyChanged("AccessGroup4");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Personal Access Group Number value
    /// </summary>
    
    [DataMember]
    
    public short PersonalAccessGroupNumber 
    { 
      get { return _PersonalAccessGroupNumber; }
      set 
      { 
        if(HasValueChanged(_PersonalAccessGroupNumber, value, "PersonalAccessGroupNumber"))
        {
          _PersonalAccessGroupNumber = value; 
          RaisePropertyChanged("PersonalAccessGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group 1 value
    /// </summary>
    
    [DataMember]
    
    public int InputOutputGroup1 
    { 
      get { return _InputOutputGroup1; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroup1, value, "InputOutputGroup1"))
        {
          _InputOutputGroup1 = value; 
          RaisePropertyChanged("InputOutputGroup1");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group 2 value
    /// </summary>
    
    [DataMember]
    
    public int InputOutputGroup2 
    { 
      get { return _InputOutputGroup2; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroup2, value, "InputOutputGroup2"))
        {
          _InputOutputGroup2 = value; 
          RaisePropertyChanged("InputOutputGroup2");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group 3 value
    /// </summary>
    
    [DataMember]
    
    public int InputOutputGroup3 
    { 
      get { return _InputOutputGroup3; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroup3, value, "InputOutputGroup3"))
        {
          _InputOutputGroup3 = value; 
          RaisePropertyChanged("InputOutputGroup3");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group 4 value
    /// </summary>
    
    [DataMember]
    
    public int InputOutputGroup4 
    { 
      get { return _InputOutputGroup4; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroup4, value, "InputOutputGroup4"))
        {
          _InputOutputGroup4 = value; 
          RaisePropertyChanged("InputOutputGroup4");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Otis Split Group Operation value
    /// </summary>
    
    [DataMember]
    
    public bool OtisSplitGroupOperation 
    { 
      get { return _OtisSplitGroupOperation; }
      set 
      { 
        if(HasValueChanged(_OtisSplitGroupOperation, value, "OtisSplitGroupOperation"))
        {
          _OtisSplitGroupOperation = value; 
          RaisePropertyChanged("OtisSplitGroupOperation");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Otis Cim Override value
    /// </summary>
    
    [DataMember]
    
    public bool OtisCimOverride 
    { 
      get { return _OtisCimOverride; }
      set 
      { 
        if(HasValueChanged(_OtisCimOverride, value, "OtisCimOverride"))
        {
          _OtisCimOverride = value; 
          RaisePropertyChanged("OtisCimOverride");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CpuUid 
    { 
      get { return _CpuUid; }
      set 
      { 
        if(HasValueChanged(_CpuUid, value, "CpuUid"))
        {
          _CpuUid = value; 
          RaisePropertyChanged("CpuUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Server Address value
    /// </summary>
    
    [DataMember]
    
    public string ServerAddress 
    { 
      get { return _ServerAddress; }
      set 
      { 
        if(HasValueChanged(_ServerAddress, value, "ServerAddress"))
        {
          _ServerAddress = value; 
          RaisePropertyChanged("ServerAddress");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Connected value
    /// </summary>
    
    [DataMember]
    
    public bool IsConnected 
    { 
      get { return _IsConnected; }
      set 
      { 
        if(HasValueChanged(_IsConnected, value, "IsConnected"))
        {
          _IsConnected = value; 
          RaisePropertyChanged("IsConnected");
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
