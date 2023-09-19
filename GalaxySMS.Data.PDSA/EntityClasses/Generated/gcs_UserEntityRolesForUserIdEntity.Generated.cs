using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the gcs_UserEntityRolesForUserIdPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcs_UserEntityRolesForUserIdPDSA : PDSAEntityBase
  {
    #region Private Variables
    private string _UserName = string.Empty;
    private string _EntityName = string.Empty;
    private string _RoleName = string.Empty;
    private Guid _UserId = Guid.Empty;
    private Guid _RoleId = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private Guid _ParentEntityId = Guid.Empty;
    private bool _IsAdministrator = false;
    private bool _InheritParentRoles = false;
    private bool _IsAdministratorRole = false;
    private bool _IncludeAllClusters = false;
    private bool _IncludeAllAccessPortals = false;
    private bool _IncludeAllInputOutputGroups = false;
    private bool _IncludeAllInputDevices = false;
    private bool _IncludeAllOutputDevices = false;
    private bool _IncludeAllSites = false;
    private bool _IncludeAllRegions = false;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the User Name value
    /// </summary>
    
    [DataMember]
    
    public string UserName 
    { 
      get { return _UserName; }
      set 
      { 
        if(HasValueChanged(_UserName, value, "UserName"))
        {
          _UserName = value; 
          RaisePropertyChanged("UserName");
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
    /// Get/Set the Role Name value
    /// </summary>
    
    [DataMember]
    
    public string RoleName 
    { 
      get { return _RoleName; }
      set 
      { 
        if(HasValueChanged(_RoleName, value, "RoleName"))
        {
          _RoleName = value; 
          RaisePropertyChanged("RoleName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the User Id value
    /// </summary>
    
    [DataMember]
    
    public Guid UserId 
    { 
      get { return _UserId; }
      set 
      { 
        if(HasValueChanged(_UserId, value, "UserId"))
        {
          _UserId = value; 
          RaisePropertyChanged("UserId");
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
    /// Get/Set the Parent Entity Id value
    /// </summary>
    
    [DataMember]
    
    public Guid ParentEntityId 
    { 
      get { return _ParentEntityId; }
      set 
      { 
        if(HasValueChanged(_ParentEntityId, value, "ParentEntityId"))
        {
          _ParentEntityId = value; 
          RaisePropertyChanged("ParentEntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Administrator value
    /// </summary>
    
    [DataMember]
    
    public bool IsAdministrator 
    { 
      get { return _IsAdministrator; }
      set 
      { 
        if(HasValueChanged(_IsAdministrator, value, "IsAdministrator"))
        {
          _IsAdministrator = value; 
          RaisePropertyChanged("IsAdministrator");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Inherit Parent Roles value
    /// </summary>
    
    [DataMember]
    
    public bool InheritParentRoles 
    { 
      get { return _InheritParentRoles; }
      set 
      { 
        if(HasValueChanged(_InheritParentRoles, value, "InheritParentRoles"))
        {
          _InheritParentRoles = value; 
          RaisePropertyChanged("InheritParentRoles");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Administrator Role value
    /// </summary>
    
    [DataMember]
    
    public bool IsAdministratorRole 
    { 
      get { return _IsAdministratorRole; }
      set 
      { 
        if(HasValueChanged(_IsAdministratorRole, value, "IsAdministratorRole"))
        {
          _IsAdministratorRole = value; 
          RaisePropertyChanged("IsAdministratorRole");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Clusters value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllClusters 
    { 
      get { return _IncludeAllClusters; }
      set 
      { 
        if(HasValueChanged(_IncludeAllClusters, value, "IncludeAllClusters"))
        {
          _IncludeAllClusters = value; 
          RaisePropertyChanged("IncludeAllClusters");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Access Portals value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllAccessPortals 
    { 
      get { return _IncludeAllAccessPortals; }
      set 
      { 
        if(HasValueChanged(_IncludeAllAccessPortals, value, "IncludeAllAccessPortals"))
        {
          _IncludeAllAccessPortals = value; 
          RaisePropertyChanged("IncludeAllAccessPortals");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Input Output Groups value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllInputOutputGroups 
    { 
      get { return _IncludeAllInputOutputGroups; }
      set 
      { 
        if(HasValueChanged(_IncludeAllInputOutputGroups, value, "IncludeAllInputOutputGroups"))
        {
          _IncludeAllInputOutputGroups = value; 
          RaisePropertyChanged("IncludeAllInputOutputGroups");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Input Devices value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllInputDevices 
    { 
      get { return _IncludeAllInputDevices; }
      set 
      { 
        if(HasValueChanged(_IncludeAllInputDevices, value, "IncludeAllInputDevices"))
        {
          _IncludeAllInputDevices = value; 
          RaisePropertyChanged("IncludeAllInputDevices");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Output Devices value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllOutputDevices 
    { 
      get { return _IncludeAllOutputDevices; }
      set 
      { 
        if(HasValueChanged(_IncludeAllOutputDevices, value, "IncludeAllOutputDevices"))
        {
          _IncludeAllOutputDevices = value; 
          RaisePropertyChanged("IncludeAllOutputDevices");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Sites value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllSites 
    { 
      get { return _IncludeAllSites; }
      set 
      { 
        if(HasValueChanged(_IncludeAllSites, value, "IncludeAllSites"))
        {
          _IncludeAllSites = value; 
          RaisePropertyChanged("IncludeAllSites");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Regions value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllRegions 
    { 
      get { return _IncludeAllRegions; }
      set 
      { 
        if(HasValueChanged(_IncludeAllRegions, value, "IncludeAllRegions"))
        {
          _IncludeAllRegions = value; 
          RaisePropertyChanged("IncludeAllRegions");
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
