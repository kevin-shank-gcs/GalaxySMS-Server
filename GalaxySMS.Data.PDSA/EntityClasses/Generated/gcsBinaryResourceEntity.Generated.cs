using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsBinaryResourcePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsBinaryResourcePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _BinaryResourceUid = Guid.NewGuid();
    private string _DataType = string.Empty;
    private string _Category = string.Empty;
    private string _Tag = string.Empty;
    private byte[] _BinaryResource = null;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _BinaryResourceUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Binary Resource Uid value
    /// </summary>
    
    public Guid BinaryResourceUid 
    { 
      get { return _BinaryResourceUid; }
      set 
      { 
        if(HasValueChanged(_BinaryResourceUid, value, "BinaryResourceUid"))
        {
          _BinaryResourceUid = value; 
          RaisePropertyChanged("BinaryResourceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Data Type value
    /// </summary>
    
    public string DataType 
    { 
      get { return _DataType; }
      set 
      { 
        if(HasValueChanged(_DataType, value, "DataType"))
        {
          _DataType = value; 
          RaisePropertyChanged("DataType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Category value
    /// </summary>
    
    public string Category 
    { 
      get { return _Category; }
      set 
      { 
        if(HasValueChanged(_Category, value, "Category"))
        {
          _Category = value; 
          RaisePropertyChanged("Category");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Tag value
    /// </summary>
    
    public string Tag 
    { 
      get { return _Tag; }
      set 
      { 
        if(HasValueChanged(_Tag, value, "Tag"))
        {
          _Tag = value; 
          RaisePropertyChanged("Tag");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Binary Resource value
    /// </summary>
    
    public byte[] BinaryResource 
    { 
      get { return _BinaryResource; }
      set 
      { 
        if(HasValueChanged(_BinaryResource, value, "BinaryResource"))
        {
          _BinaryResource = value; 
          RaisePropertyChanged("BinaryResource");
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
    /// Get/Set the Binary Resource UidOld value
    /// </summary>
    
    public Guid BinaryResourceUidOld
    { 
      get { return _BinaryResourceUidOld; }
      set 
      { 
        if(HasValueChanged(_BinaryResourceUidOld, value, "BinaryResourceUid"))
        {
          _BinaryResourceUidOld = value; 
          RaisePropertyChanged("BinaryResourceUidOld");
        }
      } 
    }
    #endregion
  }
}
