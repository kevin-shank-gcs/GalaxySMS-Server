using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AccessPortalGalaxyHardwareAddressPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessPortalGalaxyHardwareAddressPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessPortalGalaxyHardwareAddressUid = Guid.Empty;
    private Guid _AccessPortalUid = Guid.Empty;
        private Guid _GalaxyInterfaceBoardSectionNodeUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private short _DoorNumber = 0;
    private Guid _AccessPortalGalaxyHardwareAddressUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Access Portal Galaxy Hardware Address Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalGalaxyHardwareAddressUid 
    { 
      get { return _AccessPortalGalaxyHardwareAddressUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalGalaxyHardwareAddressUid, value, "AccessPortalGalaxyHardwareAddressUid"))
        {
          _AccessPortalGalaxyHardwareAddressUid = value; 
          RaisePropertyChanged("AccessPortalGalaxyHardwareAddressUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalUid 
    { 
      get { return _AccessPortalUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalUid, value, "AccessPortalUid"))
        {
          _AccessPortalUid = value; 
          RaisePropertyChanged("AccessPortalUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Interface Board Section Node Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardSectionNodeUid 
    { 
      get { return _GalaxyInterfaceBoardSectionNodeUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionNodeUid, value, "GalaxyInterfaceBoardSectionNodeUid"))
        {
          _GalaxyInterfaceBoardSectionNodeUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionNodeUid");
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
    /// Get/Set the Galaxy Panel Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelUid 
    { 
      get { return _GalaxyPanelUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelUid, value, "GalaxyPanelUid"))
        {
          _GalaxyPanelUid = value; 
          RaisePropertyChanged("GalaxyPanelUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Door Number value
    /// </summary>
    
    [DataMember]
    
    public short DoorNumber 
    { 
      get { return _DoorNumber; }
      set 
      { 
        if(HasValueChanged(_DoorNumber, value, "DoorNumber"))
        {
          _DoorNumber = value; 
          RaisePropertyChanged("DoorNumber");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Access Portal Galaxy Hardware Address UidOld value
    /// </summary>
    
    public Guid AccessPortalGalaxyHardwareAddressUidOld
    { 
      get { return _AccessPortalGalaxyHardwareAddressUidOld; }
      set 
      { 
        if(HasValueChanged(_AccessPortalGalaxyHardwareAddressUidOld, value, "AccessPortalGalaxyHardwareAddressUid"))
        {
          _AccessPortalGalaxyHardwareAddressUidOld = value; 
          RaisePropertyChanged("AccessPortalGalaxyHardwareAddressUidOld");
        }
      } 
    }
    #endregion
  }
}
