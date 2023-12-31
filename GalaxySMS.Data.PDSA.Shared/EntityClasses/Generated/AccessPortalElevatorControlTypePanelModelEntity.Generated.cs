using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AccessPortalElevatorControlTypePanelModelPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessPortalElevatorControlTypePanelModelPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessPortalElevatorControlTypePanelModelUid = Guid.NewGuid();
    private Guid _AccessPortalElevatorControlTypeUid = Guid.NewGuid();
    private Guid _GalaxyPanelModelUid = Guid.NewGuid();
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _AccessPortalElevatorControlTypePanelModelUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Access Portal Elevator Control Type Panel Model Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalElevatorControlTypePanelModelUid 
    { 
      get { return _AccessPortalElevatorControlTypePanelModelUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalElevatorControlTypePanelModelUid, value, "AccessPortalElevatorControlTypePanelModelUid"))
        {
          _AccessPortalElevatorControlTypePanelModelUid = value; 
          RaisePropertyChanged("AccessPortalElevatorControlTypePanelModelUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Elevator Control Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalElevatorControlTypeUid 
    { 
      get { return _AccessPortalElevatorControlTypeUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalElevatorControlTypeUid, value, "AccessPortalElevatorControlTypeUid"))
        {
          _AccessPortalElevatorControlTypeUid = value; 
          RaisePropertyChanged("AccessPortalElevatorControlTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Model Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelModelUid 
    { 
      get { return _GalaxyPanelModelUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelModelUid, value, "GalaxyPanelModelUid"))
        {
          _GalaxyPanelModelUid = value; 
          RaisePropertyChanged("GalaxyPanelModelUid");
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
    /// Get/Set the Access Portal Elevator Control Type Panel Model UidOld value
    /// </summary>
    
    public Guid AccessPortalElevatorControlTypePanelModelUidOld
    { 
      get { return _AccessPortalElevatorControlTypePanelModelUidOld; }
      set 
      { 
        if(HasValueChanged(_AccessPortalElevatorControlTypePanelModelUidOld, value, "AccessPortalElevatorControlTypePanelModelUid"))
        {
          _AccessPortalElevatorControlTypePanelModelUidOld = value; 
          RaisePropertyChanged("AccessPortalElevatorControlTypePanelModelUidOld");
        }
      } 
    }
    #endregion
  }
}
