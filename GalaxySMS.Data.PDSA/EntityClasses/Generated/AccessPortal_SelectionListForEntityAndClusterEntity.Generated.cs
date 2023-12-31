using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the AccessPortal_SelectionListForEntityAndClusterPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessPortal_SelectionListForEntityAndClusterPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessPortalUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private string _AccessPortalName = string.Empty;
    private string _Location = string.Empty;
    private byte[] _BinaryResource = null;
    private string _ClusterTypeCode = string.Empty;
    private string _GalaxyPanelTypeCode = string.Empty;
    private short _InterfaceBoardTypeCode = 0;
    private string _InterfaceBoardModel = string.Empty;
    private short _InterfaceBoardSectionModeCode = 0;
    private short _ModuleTypeCode = 0;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Access Portal Name value
    /// </summary>
    
    [DataMember]
    
    public string AccessPortalName 
    { 
      get { return _AccessPortalName; }
      set 
      { 
        if(HasValueChanged(_AccessPortalName, value, "AccessPortalName"))
        {
          _AccessPortalName = value; 
          RaisePropertyChanged("AccessPortalName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Location value
    /// </summary>
    
    [DataMember]
    
    public string Location 
    { 
      get { return _Location; }
      set 
      { 
        if(HasValueChanged(_Location, value, "Location"))
        {
          _Location = value; 
          RaisePropertyChanged("Location");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Binary Resource value
    /// </summary>
    
    [DataMember]
    
    public byte[] BinaryResource 
    { 
      get { return _BinaryResource; }
      set 
      { 
        if(HasValueChanged(_BinaryResource, value, "BinaryResource"))
        {
          _BinaryResource = value; 
          RaisePropertyChanged("BinaryResource");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Type Code value
    /// </summary>
    
    [DataMember]
    
    public string ClusterTypeCode 
    { 
      get { return _ClusterTypeCode; }
      set 
      { 
        if(HasValueChanged(_ClusterTypeCode, value, "ClusterTypeCode"))
        {
          _ClusterTypeCode = value; 
          RaisePropertyChanged("ClusterTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Type Code value
    /// </summary>
    
    [DataMember]
    
    public string GalaxyPanelTypeCode 
    { 
      get { return _GalaxyPanelTypeCode; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelTypeCode, value, "GalaxyPanelTypeCode"))
        {
          _GalaxyPanelTypeCode = value; 
          RaisePropertyChanged("GalaxyPanelTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Type Code value
    /// </summary>
    
    [DataMember]
    
    public short InterfaceBoardTypeCode 
    { 
      get { return _InterfaceBoardTypeCode; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardTypeCode, value, "InterfaceBoardTypeCode"))
        {
          _InterfaceBoardTypeCode = value; 
          RaisePropertyChanged("InterfaceBoardTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Model value
    /// </summary>
    
    [DataMember]
    
    public string InterfaceBoardModel 
    { 
      get { return _InterfaceBoardModel; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardModel, value, "InterfaceBoardModel"))
        {
          _InterfaceBoardModel = value; 
          RaisePropertyChanged("InterfaceBoardModel");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Section Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short InterfaceBoardSectionModeCode 
    { 
      get { return _InterfaceBoardSectionModeCode; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardSectionModeCode, value, "InterfaceBoardSectionModeCode"))
        {
          _InterfaceBoardSectionModeCode = value; 
          RaisePropertyChanged("InterfaceBoardSectionModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Module Type Code value
    /// </summary>
    
    [DataMember]
    
    public short ModuleTypeCode 
    { 
      get { return _ModuleTypeCode; }
      set 
      { 
        if(HasValueChanged(_ModuleTypeCode, value, "ModuleTypeCode"))
        {
          _ModuleTypeCode = value; 
          RaisePropertyChanged("ModuleTypeCode");
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
