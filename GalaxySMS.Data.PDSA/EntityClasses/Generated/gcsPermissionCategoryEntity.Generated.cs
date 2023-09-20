using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsPermissionCategoryPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsPermissionCategoryPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _PermissionCategoryId = Guid.Empty;
    private Guid _ApplicationId = Guid.Empty;
    private string _CategoryName = string.Empty;
    private string _PermissionCategoryDescription = string.Empty;
    private bool _IsSystemCategory = false;
    private bool _IsEntityCategory = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _Code = string.Empty;
    private Guid _PermissionCategoryIdOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Permission Category Id value
    /// </summary>
    
    [DataMember]
    
    public Guid PermissionCategoryId 
    { 
      get { return _PermissionCategoryId; }
      set 
      { 
        if(HasValueChanged(_PermissionCategoryId, value, "PermissionCategoryId"))
        {
          _PermissionCategoryId = value; 
          RaisePropertyChanged("PermissionCategoryId");
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
    /// Get/Set the Category Name value
    /// </summary>
    
    [DataMember]
    
    public string CategoryName 
    { 
      get { return _CategoryName; }
      set 
      { 
        if(HasValueChanged(_CategoryName, value, "CategoryName"))
        {
          _CategoryName = value; 
          RaisePropertyChanged("CategoryName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Permission Category Description value
    /// </summary>
    
    [DataMember]
    
    public string PermissionCategoryDescription 
    { 
      get { return _PermissionCategoryDescription; }
      set 
      { 
        if(HasValueChanged(_PermissionCategoryDescription, value, "PermissionCategoryDescription"))
        {
          _PermissionCategoryDescription = value; 
          RaisePropertyChanged("PermissionCategoryDescription");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is System Category value
    /// </summary>
    
    [DataMember]
    
    public bool IsSystemCategory 
    { 
      get { return _IsSystemCategory; }
      set 
      { 
        if(HasValueChanged(_IsSystemCategory, value, "IsSystemCategory"))
        {
          _IsSystemCategory = value; 
          RaisePropertyChanged("IsSystemCategory");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Entity Category value
    /// </summary>
    
    [DataMember]
    
    public bool IsEntityCategory 
    { 
      get { return _IsEntityCategory; }
      set 
      { 
        if(HasValueChanged(_IsEntityCategory, value, "IsEntityCategory"))
        {
          _IsEntityCategory = value; 
          RaisePropertyChanged("IsEntityCategory");
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
    /// Get/Set the Code value
    /// </summary>
    
    [DataMember]
    
    public string Code 
    { 
      get { return _Code; }
      set 
      { 
        if(HasValueChanged(_Code, value, "Code"))
        {
          _Code = value; 
          RaisePropertyChanged("Code");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Permission Category IdOld value
    /// </summary>
    
    public Guid PermissionCategoryIdOld
    { 
      get { return _PermissionCategoryIdOld; }
      set 
      { 
        if(HasValueChanged(_PermissionCategoryIdOld, value, "PermissionCategoryId"))
        {
          _PermissionCategoryIdOld = value; 
          RaisePropertyChanged("PermissionCategoryIdOld");
        }
      } 
    }
    #endregion
  }
}
