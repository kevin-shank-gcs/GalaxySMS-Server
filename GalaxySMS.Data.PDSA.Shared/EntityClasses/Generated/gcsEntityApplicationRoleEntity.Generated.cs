using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsEntityApplicationRolePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsEntityApplicationRolePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _EntityApplicationRoleId = Guid.Empty;
    private Guid _RoleId = Guid.Empty;
    private Guid _EntityApplicationId = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _EntityApplicationRoleIdOld = Guid.Empty;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Entity Application Id value
    /// </summary>
    
    [DataMember]
    
    public Guid EntityApplicationId 
    { 
      get { return _EntityApplicationId; }
      set 
      { 
        if(HasValueChanged(_EntityApplicationId, value, "EntityApplicationId"))
        {
          _EntityApplicationId = value; 
          RaisePropertyChanged("EntityApplicationId");
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
    /// Get/Set the Entity Application Role IdOld value
    /// </summary>
    
    public Guid EntityApplicationRoleIdOld
    { 
      get { return _EntityApplicationRoleIdOld; }
      set 
      { 
        if(HasValueChanged(_EntityApplicationRoleIdOld, value, "EntityApplicationRoleId"))
        {
          _EntityApplicationRoleIdOld = value; 
          RaisePropertyChanged("EntityApplicationRoleIdOld");
        }
      } 
    }
    #endregion
  }
}
