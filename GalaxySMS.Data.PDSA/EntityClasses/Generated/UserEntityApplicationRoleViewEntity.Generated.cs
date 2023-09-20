using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a UserEntityApplicationRoleViewPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class UserEntityApplicationRoleViewPDSA : PDSAEntityBase
  {
    #region Private Variables
    private string _UserName = string.Empty;
    private string _EntityName = string.Empty;
    private string _ApplicationName = string.Empty;
    private string _RoleName = string.Empty;
    private Guid _UserEntityApplicationRoleId = Guid.Empty;
    private Guid _EntityApplicationRoleId = Guid.Empty;
    private Guid _UserId = Guid.Empty;
    private Guid _ApplicationId = Guid.Empty;
    private Guid _RoleId = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the User Name value
    /// </summary>
    
    [DataMember]
    
    public string UserName 
    { 
      get { return _UserName; }
      set 
      { 
        if(HasValueChanged(_UserName, value, "UserName"))
        {
          _UserName = value; 
          RaisePropertyChanged("UserName");
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
    /// Get/Set the User Entity Application Role Id value
    /// </summary>
    
    [DataMember]
    
    public Guid UserEntityApplicationRoleId 
    { 
      get { return _UserEntityApplicationRoleId; }
      set 
      { 
        if(HasValueChanged(_UserEntityApplicationRoleId, value, "UserEntityApplicationRoleId"))
        {
          _UserEntityApplicationRoleId = value; 
          RaisePropertyChanged("UserEntityApplicationRoleId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Application Role Id value
    /// </summary>
    
    [DataMember]
    
    public Guid EntityApplicationRoleId 
    { 
      get { return _EntityApplicationRoleId; }
      set 
      { 
        if(HasValueChanged(_EntityApplicationRoleId, value, "EntityApplicationRoleId"))
        {
          _EntityApplicationRoleId = value; 
          RaisePropertyChanged("EntityApplicationRoleId");
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
        if(HasValueChanged(_UserId, value, "UserId"))
        {
          _UserId = value; 
          RaisePropertyChanged("UserId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Id value
    /// </summary>
    
    [DataMember]
    
    public Guid ApplicationId 
    { 
      get { return _ApplicationId; }
      set 
      { 
        if(HasValueChanged(_ApplicationId, value, "ApplicationId"))
        {
          _ApplicationId = value; 
          RaisePropertyChanged("ApplicationId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Role Id value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleId 
    { 
      get { return _RoleId; }
      set 
      { 
        if(HasValueChanged(_RoleId, value, "RoleId"))
        {
          _RoleId = value; 
          RaisePropertyChanged("RoleId");
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
        

    #endregion
  }
}
