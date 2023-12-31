using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GalaxyClusterPanelInformation_GetForCpuPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyClusterPanelInformation_GetForCpuPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _ClusterUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private Guid _CpuUid = Guid.Empty;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _CpuNumber = 0;
    private string _SerialNumber = string.Empty;
    private string _IpAddress = string.Empty;
    private bool _DefaultEventLoggingOn = false;
    private bool _PreventDataLoading = false;
    private bool _PreventFlashLoading = false;
    private int _LastLogIndex = 0;
    private string _ClusterName = string.Empty;
    private string _PanelName = string.Empty;
    private string _ClusterTypeCode = string.Empty;
    private bool _ClusterTypeIsActive = false;
    private short _CredentialDataLength = 0;
    private string _PanelLocation = string.Empty;
    private string _PanelModelTypeCode = string.Empty;
    private bool _PanelModelIsActive = false;
    private bool _CpuIsActive = false;
    private Guid _SiteUid = Guid.Empty;
    private string _SiteName = string.Empty;
    private Guid _EntityId = Guid.Empty;
    private string _EntityName = string.Empty;
    private string _EntityType = string.Empty;
    private string _TimeZoneId = string.Empty;
    private bool _IsConnected = false;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CpuUid 
    { 
      get { return _CpuUid; }
      set 
      { 
        if(HasValueChanged(_CpuUid, value, "CpuUid"))
        {
          _CpuUid = value; 
          RaisePropertyChanged("CpuUid");
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
    /// Get/Set the Cpu Number value
    /// </summary>
    
    [DataMember]
    
    public short CpuNumber 
    { 
      get { return _CpuNumber; }
      set 
      { 
        if(HasValueChanged(_CpuNumber, value, "CpuNumber"))
        {
          _CpuNumber = value; 
          RaisePropertyChanged("CpuNumber");
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
    /// Get/Set the Ip Address value
    /// </summary>
    
    [DataMember]
    
    public string IpAddress 
    { 
      get { return _IpAddress; }
      set 
      { 
        if(HasValueChanged(_IpAddress, value, "IpAddress"))
        {
          _IpAddress = value; 
          RaisePropertyChanged("IpAddress");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Default Event Logging On value
    /// </summary>
    
    [DataMember]
    
    public bool DefaultEventLoggingOn 
    { 
      get { return _DefaultEventLoggingOn; }
      set 
      { 
        if(HasValueChanged(_DefaultEventLoggingOn, value, "DefaultEventLoggingOn"))
        {
          _DefaultEventLoggingOn = value; 
          RaisePropertyChanged("DefaultEventLoggingOn");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Prevent Data Loading value
    /// </summary>
    
    [DataMember]
    
    public bool PreventDataLoading 
    { 
      get { return _PreventDataLoading; }
      set 
      { 
        if(HasValueChanged(_PreventDataLoading, value, "PreventDataLoading"))
        {
          _PreventDataLoading = value; 
          RaisePropertyChanged("PreventDataLoading");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Prevent Flash Loading value
    /// </summary>
    
    [DataMember]
    
    public bool PreventFlashLoading 
    { 
      get { return _PreventFlashLoading; }
      set 
      { 
        if(HasValueChanged(_PreventFlashLoading, value, "PreventFlashLoading"))
        {
          _PreventFlashLoading = value; 
          RaisePropertyChanged("PreventFlashLoading");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Last Log Index value
    /// </summary>
    
    [DataMember]
    
    public int LastLogIndex 
    { 
      get { return _LastLogIndex; }
      set 
      { 
        if(HasValueChanged(_LastLogIndex, value, "LastLogIndex"))
        {
          _LastLogIndex = value; 
          RaisePropertyChanged("LastLogIndex");
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
    /// Get/Set the Panel Name value
    /// </summary>
    
    [DataMember]
    
    public string PanelName 
    { 
      get { return _PanelName; }
      set 
      { 
        if(HasValueChanged(_PanelName, value, "PanelName"))
        {
          _PanelName = value; 
          RaisePropertyChanged("PanelName");
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
    /// Get/Set the Cluster Type Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool ClusterTypeIsActive 
    { 
      get { return _ClusterTypeIsActive; }
      set 
      { 
        if(HasValueChanged(_ClusterTypeIsActive, value, "ClusterTypeIsActive"))
        {
          _ClusterTypeIsActive = value; 
          RaisePropertyChanged("ClusterTypeIsActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Data Length value
    /// </summary>
    
    [DataMember]
    
    public short CredentialDataLength 
    { 
      get { return _CredentialDataLength; }
      set 
      { 
        if(HasValueChanged(_CredentialDataLength, value, "CredentialDataLength"))
        {
          _CredentialDataLength = value; 
          RaisePropertyChanged("CredentialDataLength");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Panel Location value
    /// </summary>
    
    [DataMember]
    
    public string PanelLocation 
    { 
      get { return _PanelLocation; }
      set 
      { 
        if(HasValueChanged(_PanelLocation, value, "PanelLocation"))
        {
          _PanelLocation = value; 
          RaisePropertyChanged("PanelLocation");
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
    /// Get/Set the Panel Model Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool PanelModelIsActive 
    { 
      get { return _PanelModelIsActive; }
      set 
      { 
        if(HasValueChanged(_PanelModelIsActive, value, "PanelModelIsActive"))
        {
          _PanelModelIsActive = value; 
          RaisePropertyChanged("PanelModelIsActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool CpuIsActive 
    { 
      get { return _CpuIsActive; }
      set 
      { 
        if(HasValueChanged(_CpuIsActive, value, "CpuIsActive"))
        {
          _CpuIsActive = value; 
          RaisePropertyChanged("CpuIsActive");
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
    /// Get/Set the Site Name value
    /// </summary>
    
    [DataMember]
    
    public string SiteName 
    { 
      get { return _SiteName; }
      set 
      { 
        if(HasValueChanged(_SiteName, value, "SiteName"))
        {
          _SiteName = value; 
          RaisePropertyChanged("SiteName");
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
    /// Get/Set the Entity Type value
    /// </summary>
    
    [DataMember]
    
    public string EntityType 
    { 
      get { return _EntityType; }
      set 
      { 
        if(HasValueChanged(_EntityType, value, "EntityType"))
        {
          _EntityType = value; 
          RaisePropertyChanged("EntityType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Zone Id value
    /// </summary>
    
    [DataMember]
    
    public string TimeZoneId 
    { 
      get { return _TimeZoneId; }
      set 
      { 
        if(HasValueChanged(_TimeZoneId, value, "TimeZoneId"))
        {
          _TimeZoneId = value; 
          RaisePropertyChanged("TimeZoneId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Connected value
    /// </summary>
    
    [DataMember]
    
    public bool IsConnected 
    { 
      get { return _IsConnected; }
      set 
      { 
        if(HasValueChanged(_IsConnected, value, "IsConnected"))
        {
          _IsConnected = value; 
          RaisePropertyChanged("IsConnected");
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
