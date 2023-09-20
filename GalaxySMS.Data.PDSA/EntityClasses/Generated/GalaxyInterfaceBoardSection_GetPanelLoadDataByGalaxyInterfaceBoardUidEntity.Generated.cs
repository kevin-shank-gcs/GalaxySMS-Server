using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyInterfaceBoardSectionUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardUid = Guid.Empty;
    private Guid _InterfaceBoardSectionModeUid = Guid.Empty;
    private short _SectionNumber = 0;
    private bool _IsSectionActive = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private int _clusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _BoardNumber = 0;
    private short _BoardSectionMode = 0;
    private string _BoardSectionModeDisplay = string.Empty;
    private string _PanelModelTypeCode = string.Empty;
    private string _CpuTypeCode = string.Empty;
    private string _BoardTypeModel = string.Empty;
    private short _BoardTypeTypeCode = 0;
    private string _BoardTypeDisplay = string.Empty;
    private Guid _EntityId = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Galaxy Interface Board Section Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardSectionUid 
    { 
      get { return _GalaxyInterfaceBoardSectionUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionUid, value, "GalaxyInterfaceBoardSectionUid"))
        {
          _GalaxyInterfaceBoardSectionUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Interface Board Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardUid 
    { 
      get { return _GalaxyInterfaceBoardUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardUid, value, "GalaxyInterfaceBoardUid"))
        {
          _GalaxyInterfaceBoardUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardUid");
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
    /// Get/Set the Section Number value
    /// </summary>
    
    [DataMember]
    
    public short SectionNumber 
    { 
      get { return _SectionNumber; }
      set 
      { 
        if(HasValueChanged(_SectionNumber, value, "SectionNumber"))
        {
          _SectionNumber = value; 
          RaisePropertyChanged("SectionNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Section Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsSectionActive 
    { 
      get { return _IsSectionActive; }
      set 
      { 
        if(HasValueChanged(_IsSectionActive, value, "IsSectionActive"))
        {
          _IsSectionActive = value; 
          RaisePropertyChanged("IsSectionActive");
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
    /// Get/Set the Account Code value
    /// </summary>
    
    [DataMember]
    
    public int ClusterGroupId 
    { 
      get { return _clusterGroupId; }
      set 
      { 
        if(HasValueChanged(_clusterGroupId, value, "ClusterGroupId"))
        {
          _clusterGroupId = value; 
          RaisePropertyChanged("ClusterGroupId");
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
    /// Get/Set the Board Number value
    /// </summary>
    
    [DataMember]
    
    public short BoardNumber 
    { 
      get { return _BoardNumber; }
      set 
      { 
        if(HasValueChanged(_BoardNumber, value, "BoardNumber"))
        {
          _BoardNumber = value; 
          RaisePropertyChanged("BoardNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Board Section Mode value
    /// </summary>
    
    [DataMember]
    
    public short BoardSectionMode 
    { 
      get { return _BoardSectionMode; }
      set 
      { 
        if(HasValueChanged(_BoardSectionMode, value, "BoardSectionMode"))
        {
          _BoardSectionMode = value; 
          RaisePropertyChanged("BoardSectionMode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Board Section Mode Display value
    /// </summary>
    
    [DataMember]
    
    public string BoardSectionModeDisplay 
    { 
      get { return _BoardSectionModeDisplay; }
      set 
      { 
        if(HasValueChanged(_BoardSectionModeDisplay, value, "BoardSectionModeDisplay"))
        {
          _BoardSectionModeDisplay = value; 
          RaisePropertyChanged("BoardSectionModeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Panel Model Type Code value
    /// </summary>
    
    [DataMember]
    
    public string PanelModelTypeCode 
    { 
      get { return _PanelModelTypeCode; }
      set 
      { 
        if(HasValueChanged(_PanelModelTypeCode, value, "PanelModelTypeCode"))
        {
          _PanelModelTypeCode = value; 
          RaisePropertyChanged("PanelModelTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Type Code value
    /// </summary>
    
    [DataMember]
    
    public string CpuTypeCode 
    { 
      get { return _CpuTypeCode; }
      set 
      { 
        if(HasValueChanged(_CpuTypeCode, value, "CpuTypeCode"))
        {
          _CpuTypeCode = value; 
          RaisePropertyChanged("CpuTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Board Type Model value
    /// </summary>
    
    [DataMember]
    
    public string BoardTypeModel 
    { 
      get { return _BoardTypeModel; }
      set 
      { 
        if(HasValueChanged(_BoardTypeModel, value, "BoardTypeModel"))
        {
          _BoardTypeModel = value; 
          RaisePropertyChanged("BoardTypeModel");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Board Type Type Code value
    /// </summary>
    
    [DataMember]
    
    public short BoardTypeTypeCode 
    { 
      get { return _BoardTypeTypeCode; }
      set 
      { 
        if(HasValueChanged(_BoardTypeTypeCode, value, "BoardTypeTypeCode"))
        {
          _BoardTypeTypeCode = value; 
          RaisePropertyChanged("BoardTypeTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Board Type Display value
    /// </summary>
    
    [DataMember]
    
    public string BoardTypeDisplay 
    { 
      get { return _BoardTypeDisplay; }
      set 
      { 
        if(HasValueChanged(_BoardTypeDisplay, value, "BoardTypeDisplay"))
        {
          _BoardTypeDisplay = value; 
          RaisePropertyChanged("BoardTypeDisplay");
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
    /// Get/Set the return value value
    /// </summary>
    
    [DataMember]
    
    public int RETURNVALUE 
    { 
      get { return _RETURNVALUE; }
      set 
      { 
        if(HasValueChanged(_RETURNVALUE, value, "@RETURN_VALUE"))
        {
          _RETURNVALUE = value; 
          RaisePropertyChanged("RETURNVALUE");
        }
      } 
    }
        

    #endregion
  }
}
