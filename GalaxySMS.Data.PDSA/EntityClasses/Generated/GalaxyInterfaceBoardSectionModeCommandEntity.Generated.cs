using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a GalaxyInterfaceBoardSectionModeCommandPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyInterfaceBoardSectionModeCommandPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyInterfaceBoardSectionModeCommandUid = Guid.Empty;
    private Guid _InterfaceBoardSectionModeUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardSectionCommandUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _GalaxyInterfaceBoardSectionModeCommandUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Galaxy Interface Board Section Mode Command Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardSectionModeCommandUid 
    { 
      get { return _GalaxyInterfaceBoardSectionModeCommandUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionModeCommandUid, value, "GalaxyInterfaceBoardSectionModeCommandUid"))
        {
          _GalaxyInterfaceBoardSectionModeCommandUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionModeCommandUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Section Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InterfaceBoardSectionModeUid 
    { 
      get { return _InterfaceBoardSectionModeUid; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardSectionModeUid, value, "InterfaceBoardSectionModeUid"))
        {
          _InterfaceBoardSectionModeUid = value; 
          RaisePropertyChanged("InterfaceBoardSectionModeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Interface Board Section Command Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardSectionCommandUid 
    { 
      get { return _GalaxyInterfaceBoardSectionCommandUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionCommandUid, value, "GalaxyInterfaceBoardSectionCommandUid"))
        {
          _GalaxyInterfaceBoardSectionCommandUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionCommandUid");
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
    /// Get/Set the Galaxy Interface Board Section Mode Command UidOld value
    /// </summary>
    
    public Guid GalaxyInterfaceBoardSectionModeCommandUidOld
    { 
      get { return _GalaxyInterfaceBoardSectionModeCommandUidOld; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionModeCommandUidOld, value, "GalaxyInterfaceBoardSectionModeCommandUid"))
        {
          _GalaxyInterfaceBoardSectionModeCommandUidOld = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionModeCommandUidOld");
        }
      } 
    }
    #endregion
  }
}
