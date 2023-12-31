using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a InputDeviceSupervisionTypeInterfaceBoardSectionModePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class InputDeviceSupervisionTypeInterfaceBoardSectionModePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _InputDeviceSupervisionTypeInterfaceBoardSectionModeUid = Guid.NewGuid();
    private Guid _InterfaceBoardSectionModeUid = Guid.NewGuid();
    private Guid _InputDeviceSupervisionTypeUid = Guid.NewGuid();
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _InputDeviceSupervisionTypeInterfaceBoardSectionModeUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Input Device Supervision Type Interface Board Section Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceSupervisionTypeInterfaceBoardSectionModeUid 
    { 
      get { return _InputDeviceSupervisionTypeInterfaceBoardSectionModeUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceSupervisionTypeInterfaceBoardSectionModeUid, value, "InputDeviceSupervisionTypeInterfaceBoardSectionModeUid"))
        {
          _InputDeviceSupervisionTypeInterfaceBoardSectionModeUid = value; 
          RaisePropertyChanged("InputDeviceSupervisionTypeInterfaceBoardSectionModeUid");
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
    /// Get/Set the Input Device Supervision Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceSupervisionTypeUid 
    { 
      get { return _InputDeviceSupervisionTypeUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceSupervisionTypeUid, value, "InputDeviceSupervisionTypeUid"))
        {
          _InputDeviceSupervisionTypeUid = value; 
          RaisePropertyChanged("InputDeviceSupervisionTypeUid");
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
    /// Get/Set the Input Device Supervision Type Interface Board Section Mode UidOld value
    /// </summary>
    
    public Guid InputDeviceSupervisionTypeInterfaceBoardSectionModeUidOld
    { 
      get { return _InputDeviceSupervisionTypeInterfaceBoardSectionModeUidOld; }
      set 
      { 
        if(HasValueChanged(_InputDeviceSupervisionTypeInterfaceBoardSectionModeUidOld, value, "InputDeviceSupervisionTypeInterfaceBoardSectionModeUid"))
        {
          _InputDeviceSupervisionTypeInterfaceBoardSectionModeUidOld = value; 
          RaisePropertyChanged("InputDeviceSupervisionTypeInterfaceBoardSectionModeUidOld");
        }
      } 
    }
    #endregion
  }
}
