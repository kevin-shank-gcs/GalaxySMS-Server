using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AssaAccessPointPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AssaAccessPointPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AssaAccessPointUid = Guid.NewGuid();
    private Guid _AssaDsrUid = Guid.NewGuid();
    private Guid _AssaAccessPointTypeUid = Guid.NewGuid();
    private string _SerialNumber = string.Empty;
    private string _AccessPointName = string.Empty;
    private string _FirmwareVersion = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _SiteUid = Guid.NewGuid();
    private string _AssaUniqueId = string.Empty;
    private string _AccessPointTypeDescription = string.Empty;
    private Guid _AssaAccessPointUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Assa Access Point Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AssaAccessPointUid 
    { 
      get { return _AssaAccessPointUid; }
      set 
      { 
        if(HasValueChanged(_AssaAccessPointUid, value, "AssaAccessPointUid"))
        {
          _AssaAccessPointUid = value; 
          RaisePropertyChanged("AssaAccessPointUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Assa Dsr Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AssaDsrUid 
    { 
      get { return _AssaDsrUid; }
      set 
      { 
        if(HasValueChanged(_AssaDsrUid, value, "AssaDsrUid"))
        {
          _AssaDsrUid = value; 
          RaisePropertyChanged("AssaDsrUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Assa Access Point Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AssaAccessPointTypeUid 
    { 
      get { return _AssaAccessPointTypeUid; }
      set 
      { 
        if(HasValueChanged(_AssaAccessPointTypeUid, value, "AssaAccessPointTypeUid"))
        {
          _AssaAccessPointTypeUid = value; 
          RaisePropertyChanged("AssaAccessPointTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Serial Number value
    /// </summary>
    
    [DataMember]
    
    public string SerialNumber 
    { 
      get { return _SerialNumber; }
      set 
      { 
        if(HasValueChanged(_SerialNumber, value, "SerialNumber"))
        {
          _SerialNumber = value; 
          RaisePropertyChanged("SerialNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Point Name value
    /// </summary>
    
    [DataMember]
    
    public string AccessPointName 
    { 
      get { return _AccessPointName; }
      set 
      { 
        if(HasValueChanged(_AccessPointName, value, "AccessPointName"))
        {
          _AccessPointName = value; 
          RaisePropertyChanged("AccessPointName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Firmware Version value
    /// </summary>
    
    [DataMember]
    
    public string FirmwareVersion 
    { 
      get { return _FirmwareVersion; }
      set 
      { 
        if(HasValueChanged(_FirmwareVersion, value, "FirmwareVersion"))
        {
          _FirmwareVersion = value; 
          RaisePropertyChanged("FirmwareVersion");
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
    /// Get/Set the Site Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid SiteUid 
    { 
      get { return _SiteUid; }
      set 
      { 
        if(HasValueChanged(_SiteUid, value, "SiteUid"))
        {
          _SiteUid = value; 
          RaisePropertyChanged("SiteUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Assa Unique Id value
    /// </summary>
    
    [DataMember]
    
    public string AssaUniqueId 
    { 
      get { return _AssaUniqueId; }
      set 
      { 
        if(HasValueChanged(_AssaUniqueId, value, "AssaUniqueId"))
        {
          _AssaUniqueId = value; 
          RaisePropertyChanged("AssaUniqueId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Point Type Description value
    /// </summary>
    
    [DataMember]
    
    public string AccessPointTypeDescription 
    { 
      get { return _AccessPointTypeDescription; }
      set 
      { 
        if(HasValueChanged(_AccessPointTypeDescription, value, "AccessPointTypeDescription"))
        {
          _AccessPointTypeDescription = value; 
          RaisePropertyChanged("AccessPointTypeDescription");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Assa Access Point UidOld value
    /// </summary>
    
    public Guid AssaAccessPointUidOld
    { 
      get { return _AssaAccessPointUidOld; }
      set 
      { 
        if(HasValueChanged(_AssaAccessPointUidOld, value, "AssaAccessPointUid"))
        {
          _AssaAccessPointUidOld = value; 
          RaisePropertyChanged("AssaAccessPointUidOld");
        }
      } 
    }
    #endregion
  }
}
