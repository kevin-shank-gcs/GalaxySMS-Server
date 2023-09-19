using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the InputDevice_GetUserPermissionPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class InputDevice_GetUserPermissionPDSA : PDSAEntityBase
  {
    #region Private Variables
    private string _DisplayName = string.Empty;
    private string _EntityName = string.Empty;
    private string _ApplicationName = string.Empty;
    private string _RoleName = string.Empty;
    private string _PermissionName = string.Empty;
    private Guid _InputDeviceUid = Guid.Empty;
    private string _InputName = string.Empty;
    private Guid _PermissionId = Guid.Empty;
    private Guid _UserId = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Display Name value
    /// </summary>
    
    [DataMember]
    
    public string DisplayName 
    { 
      get { return _DisplayName; }
      set 
      { 
        if(HasValueChanged(_DisplayName, value, "DisplayName"))
        {
          _DisplayName = value; 
          RaisePropertyChanged("DisplayName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Name value
    /// </summary>
    
    [DataMember]
    
    public string EntityName 
    { 
      get { return _EntityName; }
      set 
      { 
        if(HasValueChanged(_EntityName, value, "EntityName"))
        {
          _EntityName = value; 
          RaisePropertyChanged("EntityName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Name value
    /// </summary>
    
    [DataMember]
    
    public string ApplicationName 
    { 
      get { return _ApplicationName; }
      set 
      { 
        if(HasValueChanged(_ApplicationName, value, "ApplicationName"))
        {
          _ApplicationName = value; 
          RaisePropertyChanged("ApplicationName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Role Name value
    /// </summary>
    
    [DataMember]
    
    public string RoleName 
    { 
      get { return _RoleName; }
      set 
      { 
        if(HasValueChanged(_RoleName, value, "RoleName"))
        {
          _RoleName = value; 
          RaisePropertyChanged("RoleName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Permission Name value
    /// </summary>
    
    [DataMember]
    
    public string PermissionName 
    { 
      get { return _PermissionName; }
      set 
      { 
        if(HasValueChanged(_PermissionName, value, "PermissionName"))
        {
          _PermissionName = value; 
          RaisePropertyChanged("PermissionName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceUid 
    { 
      get { return _InputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceUid, value, "InputDeviceUid"))
        {
          _InputDeviceUid = value; 
          RaisePropertyChanged("InputDeviceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Name value
    /// </summary>
    
    [DataMember]
    
    public string InputName 
    { 
      get { return _InputName; }
      set 
      { 
        if(HasValueChanged(_InputName, value, "InputName"))
        {
          _InputName = value; 
          RaisePropertyChanged("InputName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Permission Id value
    /// </summary>
    
    [DataMember]
    
    public Guid PermissionId 
    { 
      get { return _PermissionId; }
      set 
      { 
        if(HasValueChanged(_PermissionId, value, "PermissionId"))
        {
          _PermissionId = value; 
          RaisePropertyChanged("PermissionId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the User Id value
    /// </summary>
    
    [DataMember]
    
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
