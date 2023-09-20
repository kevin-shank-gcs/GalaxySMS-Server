using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsUserEntityApplicationRolePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsUserEntityApplicationRolePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _UserEntityApplicationRoleId = Guid.NewGuid();
    private Guid _UserEntityId = Guid.NewGuid();
    private Guid _EntityApplicationRoleId = Guid.NewGuid();
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _UserId = Guid.NewGuid();
    private Guid _EntityId = Guid.NewGuid();
    private Guid _ApplicationId = Guid.NewGuid();
    private Guid _RoleId = Guid.NewGuid();
    private Guid _UserEntityApplicationRoleIdOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the User Entity Application Role Id value
    /// </summary>
    
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
    /// Get/Set the User Entity Id value
    /// </summary>
    
    public Guid UserEntityId 
    { 
      get { return _UserEntityId; }
      set 
      { 
        if(HasValueChanged(_UserEntityId, value, "UserEntityId"))
        {
          _UserEntityId = value; 
          RaisePropertyChanged("UserEntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Application Role Id value
    /// </summary>
    
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
    /// Get/Set the Insert Name value
    /// </summary>
    
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
    /// Get/Set the User Id value
    /// </summary>
    
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
    /// Get/Set the Entity Id value
    /// </summary>
    
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
    /// Get/Set the Application Id value
    /// </summary>
    
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
    /// Get/Set the User Entity Application Role IdOld value
    /// </summary>
    
    public Guid UserEntityApplicationRoleIdOld
    { 
      get { return _UserEntityApplicationRoleIdOld; }
      set 
      { 
        if(HasValueChanged(_UserEntityApplicationRoleIdOld, value, "UserEntityApplicationRoleId"))
        {
          _UserEntityApplicationRoleIdOld = value; 
          RaisePropertyChanged("UserEntityApplicationRoleIdOld");
        }
      } 
    }
    #endregion
  }
}
