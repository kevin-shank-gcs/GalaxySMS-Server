using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a RegionPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class RegionPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _RegionUid = Guid.NewGuid();
    private string _RegionName = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _RegionId = string.Empty;
    private Guid _EntityId = Guid.NewGuid();
    private Guid _BinaryResourceUid = Guid.NewGuid();
    private byte[] _BinaryResource = null;
    private Guid _RegionUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Region Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RegionUid 
    { 
      get { return _RegionUid; }
      set 
      { 
        if(HasValueChanged(_RegionUid, value, "RegionUid"))
        {
          _RegionUid = value; 
          RaisePropertyChanged("RegionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Region Name value
    /// </summary>
    
    [DataMember]
    
    public string RegionName 
    { 
      get { return _RegionName; }
      set 
      { 
        if(HasValueChanged(_RegionName, value, "RegionName"))
        {
          _RegionName = value; 
          RaisePropertyChanged("RegionName");
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
    /// Get/Set the Region Id value
    /// </summary>
    
    [DataMember]
    
    public string RegionId 
    { 
      get { return _RegionId; }
      set 
      { 
        if(HasValueChanged(_RegionId, value, "RegionId"))
        {
          _RegionId = value; 
          RaisePropertyChanged("RegionId");
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
    /// Get/Set the Binary Resource value
    /// </summary>
    
    [DataMember]
    
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
    /// Get/Set the Region UidOld value
    /// </summary>
    
    public Guid RegionUidOld
    { 
      get { return _RegionUidOld; }
      set 
      { 
        if(HasValueChanged(_RegionUidOld, value, "RegionUid"))
        {
          _RegionUidOld = value; 
          RaisePropertyChanged("RegionUidOld");
        }
      } 
    }
    #endregion
  }
}
