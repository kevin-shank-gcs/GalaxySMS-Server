using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a PersonCredentialPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class PersonCredentialPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _PersonCredentialUid = Guid.Empty;
    private Guid _CredentialUid = Guid.Empty;
    private Guid _PersonUid = Guid.Empty;
    private Guid _PersonCredentialRoleUid = Guid.Empty;
    private Guid _PersonActivationModeUid = Guid.Empty;
    private Guid _PersonExpirationModeUid = Guid.Empty;
    private Guid _BadgeTemplateUid = Guid.Empty;
    private Guid _DossierBadgeTemplateUid = Guid.Empty;
    private Guid _AccessPortalNoServerReplyBehaviorUid = Guid.Empty;
    private Guid _AccessPortalDeferToServerBehaviorUid = Guid.Empty;
    private string _CredentialDescription = string.Empty;
    private DateTimeOffset? _ActivationDateTime = null;
    private DateTimeOffset? _ExpirationDateTime = null;
    private short _UsageCount = 0;
    private bool _TraceEnabled = false;
    private bool _DuressEnabled = false;
    private bool _ReverseBits = false;
    private short _BiometricEnrollmentStatus = 0;
    private int _BadgePrintLimit = 0;
    private int _BadgePrintCount = 0;
    private DateTimeOffset? _BadgeLastPrinted = null;
    private int _DossierPrintLimit = 0;
    private int _DossierPrintCount = 0;
    private DateTimeOffset? _DossierLastPrinted = null;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private bool _IsActive = false;
    private short _SysGalCardId = 0;
    private Guid _PersonCredentialUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Person Credential Role Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonCredentialRoleUid 
    { 
      get { return _PersonCredentialRoleUid; }
      set 
      { 
        if(HasValueChanged(_PersonCredentialRoleUid, value, "PersonCredentialRoleUid"))
        {
          _PersonCredentialRoleUid = value; 
          RaisePropertyChanged("PersonCredentialRoleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Activation Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonActivationModeUid 
    { 
      get { return _PersonActivationModeUid; }
      set 
      { 
        if(HasValueChanged(_PersonActivationModeUid, value, "PersonActivationModeUid"))
        {
          _PersonActivationModeUid = value; 
          RaisePropertyChanged("PersonActivationModeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Expiration Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonExpirationModeUid 
    { 
      get { return _PersonExpirationModeUid; }
      set 
      { 
        if(HasValueChanged(_PersonExpirationModeUid, value, "PersonExpirationModeUid"))
        {
          _PersonExpirationModeUid = value; 
          RaisePropertyChanged("PersonExpirationModeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Badge Template Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid BadgeTemplateUid 
    { 
      get { return _BadgeTemplateUid; }
      set 
      { 
        if(HasValueChanged(_BadgeTemplateUid, value, "BadgeTemplateUid"))
        {
          _BadgeTemplateUid = value; 
          RaisePropertyChanged("BadgeTemplateUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dossier Badge Template Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DossierBadgeTemplateUid 
    { 
      get { return _DossierBadgeTemplateUid; }
      set 
      { 
        if(HasValueChanged(_DossierBadgeTemplateUid, value, "DossierBadgeTemplateUid"))
        {
          _DossierBadgeTemplateUid = value; 
          RaisePropertyChanged("DossierBadgeTemplateUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal No Server Reply Behavior Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalNoServerReplyBehaviorUid 
    { 
      get { return _AccessPortalNoServerReplyBehaviorUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalNoServerReplyBehaviorUid, value, "AccessPortalNoServerReplyBehaviorUid"))
        {
          _AccessPortalNoServerReplyBehaviorUid = value; 
          RaisePropertyChanged("AccessPortalNoServerReplyBehaviorUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Defer To Server Behavior Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalDeferToServerBehaviorUid 
    { 
      get { return _AccessPortalDeferToServerBehaviorUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalDeferToServerBehaviorUid, value, "AccessPortalDeferToServerBehaviorUid"))
        {
          _AccessPortalDeferToServerBehaviorUid = value; 
          RaisePropertyChanged("AccessPortalDeferToServerBehaviorUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Description value
    /// </summary>
    
    [DataMember]
    
    public string CredentialDescription 
    { 
      get { return _CredentialDescription; }
      set 
      { 
        if(HasValueChanged(_CredentialDescription, value, "CredentialDescription"))
        {
          _CredentialDescription = value; 
          RaisePropertyChanged("CredentialDescription");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activation Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? ActivationDateTime 
    { 
      get { return _ActivationDateTime; }
      set 
      { 
        if(HasValueChanged(_ActivationDateTime, value, "ActivationDateTime"))
        {
          _ActivationDateTime = value; 
          RaisePropertyChanged("ActivationDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Expiration Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? ExpirationDateTime 
    { 
      get { return _ExpirationDateTime; }
      set 
      { 
        if(HasValueChanged(_ExpirationDateTime, value, "ExpirationDateTime"))
        {
          _ExpirationDateTime = value; 
          RaisePropertyChanged("ExpirationDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Usage Count value
    /// </summary>
    
    [DataMember]
    
    public short UsageCount 
    { 
      get { return _UsageCount; }
      set 
      { 
        if(HasValueChanged(_UsageCount, value, "UsageCount"))
        {
          _UsageCount = value; 
          RaisePropertyChanged("UsageCount");
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
    /// Get/Set the Biometric Enrollment Status value
    /// </summary>
    
    [DataMember]
    
    public short BiometricEnrollmentStatus 
    { 
      get { return _BiometricEnrollmentStatus; }
      set 
      { 
        if(HasValueChanged(_BiometricEnrollmentStatus, value, "BiometricEnrollmentStatus"))
        {
          _BiometricEnrollmentStatus = value; 
          RaisePropertyChanged("BiometricEnrollmentStatus");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Badge Print Limit value
    /// </summary>
    
    [DataMember]
    
    public int BadgePrintLimit 
    { 
      get { return _BadgePrintLimit; }
      set 
      { 
        if(HasValueChanged(_BadgePrintLimit, value, "BadgePrintLimit"))
        {
          _BadgePrintLimit = value; 
          RaisePropertyChanged("BadgePrintLimit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Badge Print Count value
    /// </summary>
    
    [DataMember]
    
    public int BadgePrintCount 
    { 
      get { return _BadgePrintCount; }
      set 
      { 
        if(HasValueChanged(_BadgePrintCount, value, "BadgePrintCount"))
        {
          _BadgePrintCount = value; 
          RaisePropertyChanged("BadgePrintCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Badge Last Printed value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? BadgeLastPrinted 
    { 
      get { return _BadgeLastPrinted; }
      set 
      { 
        if(HasValueChanged(_BadgeLastPrinted, value, "BadgeLastPrinted"))
        {
          _BadgeLastPrinted = value; 
          RaisePropertyChanged("BadgeLastPrinted");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dossier Print Limit value
    /// </summary>
    
    [DataMember]
    
    public int DossierPrintLimit 
    { 
      get { return _DossierPrintLimit; }
      set 
      { 
        if(HasValueChanged(_DossierPrintLimit, value, "DossierPrintLimit"))
        {
          _DossierPrintLimit = value; 
          RaisePropertyChanged("DossierPrintLimit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dossier Print Count value
    /// </summary>
    
    [DataMember]
    
    public int DossierPrintCount 
    { 
      get { return _DossierPrintCount; }
      set 
      { 
        if(HasValueChanged(_DossierPrintCount, value, "DossierPrintCount"))
        {
          _DossierPrintCount = value; 
          RaisePropertyChanged("DossierPrintCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dossier Last Printed value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? DossierLastPrinted 
    { 
      get { return _DossierLastPrinted; }
      set 
      { 
        if(HasValueChanged(_DossierLastPrinted, value, "DossierLastPrinted"))
        {
          _DossierLastPrinted = value; 
          RaisePropertyChanged("DossierLastPrinted");
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
    /// Get/Set the Sys Gal Card Id value
    /// </summary>
    
    [DataMember]
    
    public short SysGalCardId 
    { 
      get { return _SysGalCardId; }
      set 
      { 
        if(HasValueChanged(_SysGalCardId, value, "SysGalCardId"))
        {
          _SysGalCardId = value; 
          RaisePropertyChanged("SysGalCardId");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Person Credential UidOld value
    /// </summary>
    
    public Guid PersonCredentialUidOld
    { 
      get { return _PersonCredentialUidOld; }
      set 
      { 
        if(HasValueChanged(_PersonCredentialUidOld, value, "PersonCredentialUid"))
        {
          _PersonCredentialUidOld = value; 
          RaisePropertyChanged("PersonCredentialUidOld");
        }
      } 
    }
    #endregion
  }
}
