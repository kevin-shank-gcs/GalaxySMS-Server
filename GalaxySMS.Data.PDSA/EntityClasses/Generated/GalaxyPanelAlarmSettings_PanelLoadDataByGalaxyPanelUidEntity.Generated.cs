using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _PanelNumber = 0;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private string _EntityName = string.Empty;
    private Guid _EntityId = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private string _ClusterName = string.Empty;
    private string _Tag = string.Empty;
    private int _IOGroupNumber = 0;
    private short _OffsetIndex = 0;
    private bool _IsActive = false;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Entity Name value
    /// </summary>
    
    [DataMember]
    
    public string EntityName 
    { 
      get { return _EntityName; }
      set 
      { 
        if(HasValueChanged(_EntityName, value, "EntityName"))
        {
          _EntityName = value; 
          RaisePropertyChanged("EntityName");
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
    /// Get/Set the Cluster Name value
    /// </summary>
    
    [DataMember]
    
    public string ClusterName 
    { 
      get { return _ClusterName; }
      set 
      { 
        if(HasValueChanged(_ClusterName, value, "ClusterName"))
        {
          _ClusterName = value; 
          RaisePropertyChanged("ClusterName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Tag value
    /// </summary>
    
    [DataMember]
    
    public string Tag 
    { 
      get { return _Tag; }
      set 
      { 
        if(HasValueChanged(_Tag, value, "Tag"))
        {
          _Tag = value; 
          RaisePropertyChanged("Tag");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the IO Group Number value
    /// </summary>
    
    [DataMember]
    
    public int IOGroupNumber 
    { 
      get { return _IOGroupNumber; }
      set 
      { 
        if(HasValueChanged(_IOGroupNumber, value, "IOGroupNumber"))
        {
          _IOGroupNumber = value; 
          RaisePropertyChanged("IOGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Offset Index value
    /// </summary>
    
    [DataMember]
    
    public short OffsetIndex 
    { 
      get { return _OffsetIndex; }
      set 
      { 
        if(HasValueChanged(_OffsetIndex, value, "OffsetIndex"))
        {
          _OffsetIndex = value; 
          RaisePropertyChanged("OffsetIndex");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsActive 
    { 
      get { return _IsActive; }
      set 
      { 
        if(HasValueChanged(_IsActive, value, "IsActive"))
        {
          _IsActive = value; 
          RaisePropertyChanged("IsActive");
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
