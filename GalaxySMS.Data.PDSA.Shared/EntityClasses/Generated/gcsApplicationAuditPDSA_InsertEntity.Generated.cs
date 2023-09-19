using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the gcsApplicationAuditPDSA_InsertPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsApplicationAuditPDSA_InsertPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AuditId = Guid.NewGuid();
    private Guid _ApplicationAuditTypeId = Guid.NewGuid();
    private Guid _TransactionId = Guid.NewGuid();
    private Guid _ApplicationId = Guid.NewGuid();
    private Guid _UserId = Guid.NewGuid();
    private string _ApplicationName = string.Empty;
    private string _ApplicationVersion = string.Empty;
    private string _MachineName = string.Empty;
    private string _LoginName = string.Empty;
    private string _WindowsUserName = string.Empty;
    private string _AuditDetails = string.Empty;
    private string _AuditXml = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Audit Id value
    /// </summary>
    
    public Guid AuditId 
    { 
      get { return _AuditId; }
      set 
      { 
        if(HasValueChanged(_AuditId, value, "@AuditId"))
        {
          _AuditId = value; 
          RaisePropertyChanged("AuditId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Audit Type Id value
    /// </summary>
    
    public Guid ApplicationAuditTypeId 
    { 
      get { return _ApplicationAuditTypeId; }
      set 
      { 
        if(HasValueChanged(_ApplicationAuditTypeId, value, "@ApplicationAuditTypeId"))
        {
          _ApplicationAuditTypeId = value; 
          RaisePropertyChanged("ApplicationAuditTypeId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Transaction Id value
    /// </summary>
    
    public Guid TransactionId 
    { 
      get { return _TransactionId; }
      set 
      { 
        if(HasValueChanged(_TransactionId, value, "@TransactionId"))
        {
          _TransactionId = value; 
          RaisePropertyChanged("TransactionId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Id value
    /// </summary>
    
    public Guid ApplicationId 
    { 
      get { return _ApplicationId; }
      set 
      { 
        if(HasValueChanged(_ApplicationId, value, "@ApplicationId"))
        {
          _ApplicationId = value; 
          RaisePropertyChanged("ApplicationId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the User Id value
    /// </summary>
    
    public Guid UserId 
    { 
      get { return _UserId; }
      set 
      { 
        if(HasValueChanged(_UserId, value, "@UserId"))
        {
          _UserId = value; 
          RaisePropertyChanged("UserId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Name value
    /// </summary>
    
    public string ApplicationName 
    { 
      get { return _ApplicationName; }
      set 
      { 
        if(HasValueChanged(_ApplicationName, value, "@ApplicationName"))
        {
          _ApplicationName = value; 
          RaisePropertyChanged("ApplicationName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Version value
    /// </summary>
    
    public string ApplicationVersion 
    { 
      get { return _ApplicationVersion; }
      set 
      { 
        if(HasValueChanged(_ApplicationVersion, value, "@ApplicationVersion"))
        {
          _ApplicationVersion = value; 
          RaisePropertyChanged("ApplicationVersion");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Machine Name value
    /// </summary>
    
    public string MachineName 
    { 
      get { return _MachineName; }
      set 
      { 
        if(HasValueChanged(_MachineName, value, "@MachineName"))
        {
          _MachineName = value; 
          RaisePropertyChanged("MachineName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Login Name value
    /// </summary>
    
    public string LoginName 
    { 
      get { return _LoginName; }
      set 
      { 
        if(HasValueChanged(_LoginName, value, "@LoginName"))
        {
          _LoginName = value; 
          RaisePropertyChanged("LoginName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Windows User Name value
    /// </summary>
    
    public string WindowsUserName 
    { 
      get { return _WindowsUserName; }
      set 
      { 
        if(HasValueChanged(_WindowsUserName, value, "@WindowsUserName"))
        {
          _WindowsUserName = value; 
          RaisePropertyChanged("WindowsUserName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Audit Details value
    /// </summary>
    
    public string AuditDetails 
    { 
      get { return _AuditDetails; }
      set 
      { 
        if(HasValueChanged(_AuditDetails, value, "@AuditDetails"))
        {
          _AuditDetails = value; 
          RaisePropertyChanged("AuditDetails");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Audit Xml value
    /// </summary>
    
    public string AuditXml 
    { 
      get { return _AuditXml; }
      set 
      { 
        if(HasValueChanged(_AuditXml, value, "@AuditXml"))
        {
          _AuditXml = value; 
          RaisePropertyChanged("AuditXml");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Name value
    /// </summary>
    
    public string InsertName 
    { 
      get { return _InsertName; }
      set 
      { 
        if(HasValueChanged(_InsertName, value, "@InsertName"))
        {
          _InsertName = value; 
          RaisePropertyChanged("InsertName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Date value
    /// </summary>
    
    public DateTimeOffset InsertDate 
    { 
      get { return _InsertDate; }
      set 
      { 
        if(HasValueChanged(_InsertDate, value, "@InsertDate"))
        {
          _InsertDate = value; 
          RaisePropertyChanged("InsertDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the return value value
    /// </summary>
    
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
