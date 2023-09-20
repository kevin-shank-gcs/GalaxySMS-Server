using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a RoleSitePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class RoleSitePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _RoleSiteUid = Guid.Empty;
    private Guid _RoleId = Guid.Empty;
    private Guid _SiteUid = Guid.Empty;
    private bool _IncludeAllClusters = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _RegionUid = Guid.Empty;
    private string _SiteName = string.Empty;
    private Guid _RoleSiteUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Role Site Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleSiteUid 
    { 
      get { return _RoleSiteUid; }
      set 
      { 
        if(HasValueChanged(_RoleSiteUid, value, "RoleSiteUid"))
        {
          _RoleSiteUid = value; 
          RaisePropertyChanged("RoleSiteUid");
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
    /// Get/Set the Region Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RegionUid 
    { 
      get { return _RegionUid; }
      set 
      { 
        if(HasValueChanged(_RegionUid, value, "RegionUid"))
        {
          _RegionUid = value; 
          RaisePropertyChanged("RegionUid");
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
    /// Get/Set the Role Site UidOld value
    /// </summary>
    
    public Guid RoleSiteUidOld
    { 
      get { return _RoleSiteUidOld; }
      set 
      { 
        if(HasValueChanged(_RoleSiteUidOld, value, "RoleSiteUid"))
        {
          _RoleSiteUidOld = value; 
          RaisePropertyChanged("RoleSiteUidOld");
        }
      } 
    }
    #endregion
  }
}
