using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a DepartmentPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class DepartmentPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _DepartmentUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private string _DepartmentName = string.Empty;
    private string _Description = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _DepartmentUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Department Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DepartmentUid 
    { 
      get { return _DepartmentUid; }
      set 
      { 
        if(HasValueChanged(_DepartmentUid, value, "DepartmentUid"))
        {
          _DepartmentUid = value; 
          RaisePropertyChanged("DepartmentUid");
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
    /// Get/Set the Department Name value
    /// </summary>
    
    [DataMember]
    
    public string DepartmentName 
    { 
      get { return _DepartmentName; }
      set 
      { 
        if(HasValueChanged(_DepartmentName, value, "DepartmentName"))
        {
          _DepartmentName = value; 
          RaisePropertyChanged("DepartmentName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Description value
    /// </summary>
    
    [DataMember]
    
    public string Description 
    { 
      get { return _Description; }
      set 
      { 
        if(HasValueChanged(_Description, value, "Description"))
        {
          _Description = value; 
          RaisePropertyChanged("Description");
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
    /// Get/Set the Department UidOld value
    /// </summary>
    
    public Guid DepartmentUidOld
    { 
      get { return _DepartmentUidOld; }
      set 
      { 
        if(HasValueChanged(_DepartmentUidOld, value, "DepartmentUid"))
        {
          _DepartmentUidOld = value; 
          RaisePropertyChanged("DepartmentUidOld");
        }
      } 
    }
    #endregion
  }
}
