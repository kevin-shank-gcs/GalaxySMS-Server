using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsEnumNamespacePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsEnumNamespacePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _EnumNamespaceId = Guid.NewGuid();
    private string _Name = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _EnumNamespaceIdOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Enum Namespace Id value
    /// </summary>
    
    public Guid EnumNamespaceId 
    { 
      get { return _EnumNamespaceId; }
      set 
      { 
        if(HasValueChanged(_EnumNamespaceId, value, "EnumNamespaceId"))
        {
          _EnumNamespaceId = value; 
          RaisePropertyChanged("EnumNamespaceId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Name value
    /// </summary>
    
    public string Name 
    { 
      get { return _Name; }
      set 
      { 
        if(HasValueChanged(_Name, value, "Name"))
        {
          _Name = value; 
          RaisePropertyChanged("Name");
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
    /// Get/Set the Enum Namespace IdOld value
    /// </summary>
    
    public Guid EnumNamespaceIdOld
    { 
      get { return _EnumNamespaceIdOld; }
      set 
      { 
        if(HasValueChanged(_EnumNamespaceIdOld, value, "EnumNamespaceId"))
        {
          _EnumNamespaceIdOld = value; 
          RaisePropertyChanged("EnumNamespaceIdOld");
        }
      } 
    }
    #endregion
  }
}
