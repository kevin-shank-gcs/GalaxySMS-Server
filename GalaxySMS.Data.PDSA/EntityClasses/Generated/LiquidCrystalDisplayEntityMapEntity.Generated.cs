using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a LiquidCrystalDisplayEntityMapPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class LiquidCrystalDisplayEntityMapPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _LiquidCrystalDisplayEntityMapUid = Guid.NewGuid();
    private Guid _LiquidCrystalDisplayUid = Guid.NewGuid();
    private Guid _EntityId = Guid.NewGuid();
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _LiquidCrystalDisplayEntityMapUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Liquid Crystal Display Entity Map Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid LiquidCrystalDisplayEntityMapUid 
    { 
      get { return _LiquidCrystalDisplayEntityMapUid; }
      set 
      { 
        if(HasValueChanged(_LiquidCrystalDisplayEntityMapUid, value, "LiquidCrystalDisplayEntityMapUid"))
        {
          _LiquidCrystalDisplayEntityMapUid = value; 
          RaisePropertyChanged("LiquidCrystalDisplayEntityMapUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Liquid Crystal Display Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid LiquidCrystalDisplayUid 
    { 
      get { return _LiquidCrystalDisplayUid; }
      set 
      { 
        if(HasValueChanged(_LiquidCrystalDisplayUid, value, "LiquidCrystalDisplayUid"))
        {
          _LiquidCrystalDisplayUid = value; 
          RaisePropertyChanged("LiquidCrystalDisplayUid");
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
    /// Get/Set the Liquid Crystal Display Entity Map UidOld value
    /// </summary>
    
    public Guid LiquidCrystalDisplayEntityMapUidOld
    { 
      get { return _LiquidCrystalDisplayEntityMapUidOld; }
      set 
      { 
        if(HasValueChanged(_LiquidCrystalDisplayEntityMapUidOld, value, "LiquidCrystalDisplayEntityMapUid"))
        {
          _LiquidCrystalDisplayEntityMapUidOld = value; 
          RaisePropertyChanged("LiquidCrystalDisplayEntityMapUidOld");
        }
      } 
    }
    #endregion
  }
}
