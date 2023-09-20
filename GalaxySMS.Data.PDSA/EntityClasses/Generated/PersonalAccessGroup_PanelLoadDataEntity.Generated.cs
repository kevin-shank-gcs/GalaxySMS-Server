using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a PersonalAccessGroup_PanelLoadDataPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class PersonalAccessGroup_PanelLoadDataPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _PersonUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private int _PersonalAccessGroupNumber = 0;
    private int _ClusterNumber = 0;
    private int _ClusterGroupId = 0;
    private int _PanelScheduleNumber = 0;
    private short _DoorNumber = 0;
    private int _PanelNumber = 0;
    private string _AccessGroupDisplay = string.Empty;
    private Guid? _TimeScheduleUid = null;
    private Guid _DefaultTimeScheduleUid = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Person Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonUid 
    { 
      get { return _PersonUid; }
      set 
      { 
        if(HasValueChanged(_PersonUid, value, "PersonUid"))
        {
          _PersonUid = value; 
          RaisePropertyChanged("PersonUid");
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
    /// Get/Set the Personal Access Group Number value
    /// </summary>
    
    [DataMember]
    
    public int PersonalAccessGroupNumber 
    { 
      get { return _PersonalAccessGroupNumber; }
      set 
      { 
        if(HasValueChanged(_PersonalAccessGroupNumber, value, "PersonalAccessGroupNumber"))
        {
          _PersonalAccessGroupNumber = value; 
          RaisePropertyChanged("PersonalAccessGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Number value
    /// </summary>
    
    [DataMember]
    
    public int ClusterNumber 
    { 
      get { return _ClusterNumber; }
      set 
      { 
        if(HasValueChanged(_ClusterNumber, value, "ClusterNumber"))
        {
          _ClusterNumber = value; 
          RaisePropertyChanged("ClusterNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Group Id value
    /// </summary>
    
    [DataMember]
    
    public int ClusterGroupId 
    { 
      get { return _ClusterGroupId; }
      set 
      { 
        if(HasValueChanged(_ClusterGroupId, value, "ClusterGroupId"))
        {
          _ClusterGroupId = value; 
          RaisePropertyChanged("ClusterGroupId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Panel Schedule Number value
    /// </summary>
    
    [DataMember]
    
    public int PanelScheduleNumber 
    { 
      get { return _PanelScheduleNumber; }
      set 
      { 
        if(HasValueChanged(_PanelScheduleNumber, value, "PanelScheduleNumber"))
        {
          _PanelScheduleNumber = value; 
          RaisePropertyChanged("PanelScheduleNumber");
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
    /// Get/Set the Panel Number value
    /// </summary>
    
    [DataMember]
    
    public int PanelNumber 
    { 
      get { return _PanelNumber; }
      set 
      { 
        if(HasValueChanged(_PanelNumber, value, "PanelNumber"))
        {
          _PanelNumber = value; 
          RaisePropertyChanged("PanelNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group Display value
    /// </summary>
    
    [DataMember]
    
    public string AccessGroupDisplay 
    { 
      get { return _AccessGroupDisplay; }
      set 
      { 
        if(HasValueChanged(_AccessGroupDisplay, value, "AccessGroupDisplay"))
        {
          _AccessGroupDisplay = value; 
          RaisePropertyChanged("AccessGroupDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid? TimeScheduleUid 
    { 
      get { return _TimeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleUid, value, "TimeScheduleUid"))
        {
          _TimeScheduleUid = value; 
          RaisePropertyChanged("TimeScheduleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Default Time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DefaultTimeScheduleUid 
    { 
      get { return _DefaultTimeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_DefaultTimeScheduleUid, value, "DefaultTimeScheduleUid"))
        {
          _DefaultTimeScheduleUid = value; 
          RaisePropertyChanged("DefaultTimeScheduleUid");
        }
      } 
    }
        

    #endregion
  }
}
