using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a RoleInputDevicePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class RoleInputDevicePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _RoleInputDeviceUid = Guid.Empty;
    private Guid _RoleId = Guid.Empty;
    private Guid _InputDeviceUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _InputName = string.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _RoleInputDeviceUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Role Input Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleInputDeviceUid 
    { 
      get { return _RoleInputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_RoleInputDeviceUid, value, "RoleInputDeviceUid"))
        {
          _RoleInputDeviceUid = value; 
          RaisePropertyChanged("RoleInputDeviceUid");
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
    /// Get/Set the Input Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceUid 
    { 
      get { return _InputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceUid, value, "InputDeviceUid"))
        {
          _InputDeviceUid = value; 
          RaisePropertyChanged("InputDeviceUid");
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
    /// Get/Set the Input Name value
    /// </summary>
    
    [DataMember]
    
    public string InputName 
    { 
      get { return _InputName; }
      set 
      { 
        if(HasValueChanged(_InputName, value, "InputName"))
        {
          _InputName = value; 
          RaisePropertyChanged("InputName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ClusterUid 
    { 
      get { return _ClusterUid; }
      set 
      { 
        if(HasValueChanged(_ClusterUid, value, "ClusterUid"))
        {
          _ClusterUid = value; 
          RaisePropertyChanged("ClusterUid");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Role Input Device UidOld value
    /// </summary>
    
    public Guid RoleInputDeviceUidOld
    { 
      get { return _RoleInputDeviceUidOld; }
      set 
      { 
        if(HasValueChanged(_RoleInputDeviceUidOld, value, "RoleInputDeviceUid"))
        {
          _RoleInputDeviceUidOld = value; 
          RaisePropertyChanged("RoleInputDeviceUidOld");
        }
      } 
    }
    #endregion
  }
}
