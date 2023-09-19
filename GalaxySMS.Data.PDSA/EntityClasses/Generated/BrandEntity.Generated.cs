using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a BrandPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class BrandPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _BrandUid = Guid.NewGuid();
    private Guid _BinaryResourceUid = Guid.NewGuid();
    private string _BrandName = string.Empty;
    private string _CompanyName = string.Empty;
    private string _Category = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _BrandUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Brand Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid BrandUid 
    { 
      get { return _BrandUid; }
      set 
      { 
        if(HasValueChanged(_BrandUid, value, "BrandUid"))
        {
          _BrandUid = value; 
          RaisePropertyChanged("BrandUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Binary Resource Uid value
    /// </summary>
    
    [DataMember]
    
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
    /// Get/Set the Brand Name value
    /// </summary>
    
    [DataMember]
    
    public string BrandName 
    { 
      get { return _BrandName; }
      set 
      { 
        if(HasValueChanged(_BrandName, value, "BrandName"))
        {
          _BrandName = value; 
          RaisePropertyChanged("BrandName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Company Name value
    /// </summary>
    
    [DataMember]
    
    public string CompanyName 
    { 
      get { return _CompanyName; }
      set 
      { 
        if(HasValueChanged(_CompanyName, value, "CompanyName"))
        {
          _CompanyName = value; 
          RaisePropertyChanged("CompanyName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Category value
    /// </summary>
    
    [DataMember]
    
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
    /// Get/Set the Brand UidOld value
    /// </summary>
    
    public Guid BrandUidOld
    { 
      get { return _BrandUidOld; }
      set 
      { 
        if(HasValueChanged(_BrandUidOld, value, "BrandUid"))
        {
          _BrandUidOld = value; 
          RaisePropertyChanged("BrandUidOld");
        }
      } 
    }
    #endregion
  }
}
