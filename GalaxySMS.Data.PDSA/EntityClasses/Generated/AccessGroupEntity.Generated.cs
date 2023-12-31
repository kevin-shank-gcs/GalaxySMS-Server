using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AccessGroupPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessGroupPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessGroupUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _DisplayResourceKey = Guid.Empty;
    private int _AccessGroupNumber = 0;
    private Guid _DescriptionResourceKey = Guid.Empty;
    private string _Description = string.Empty;
    private string _Display = string.Empty;
    private string _ServiceComment = string.Empty;
    private string _Comment = string.Empty;
    private bool _IsEnabled = false;
    private DateTime? _ActivationDate = null;
    private DateTime? _ExpirationDate = null;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _EntityId = Guid.Empty;
    private Guid _CrisisModeAccessGroupUid = Guid.Empty;
    private Guid _DefaultTimeScheduleUid = Guid.Empty;
    private string _CultureName = string.Empty;
    private int _PageNumber = 0;
    private int _PageSize = 0;
    private int _TotalRowCount = 0;
    private string _SortColumn = string.Empty;
    private bool _DescendingOrder = false;
    private bool _IncludeSystemGroups = false;
    private int _CrisisModeAccessGroupNumber = 0;
    private string _CrisisModeAccessGroupName = string.Empty;
    private string _ClusterName = string.Empty;
    private string _DefaultTimeScheduleName = string.Empty;
    private Guid _AccessGroupUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Access Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessGroupUid 
    { 
      get { return _AccessGroupUid; }
      set 
      { 
        if(HasValueChanged(_AccessGroupUid, value, "AccessGroupUid"))
        {
          _AccessGroupUid = value; 
          RaisePropertyChanged("AccessGroupUid");
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
    /// Get/Set the Display Resource Key value
    /// </summary>
    
    [DataMember]
    
    public Guid DisplayResourceKey 
    { 
      get { return _DisplayResourceKey; }
      set 
      { 
        if(HasValueChanged(_DisplayResourceKey, value, "DisplayResourceKey"))
        {
          _DisplayResourceKey = value; 
          RaisePropertyChanged("DisplayResourceKey");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group Number value
    /// </summary>
    
    [DataMember]
    
    public int AccessGroupNumber 
    { 
      get { return _AccessGroupNumber; }
      set 
      { 
        if(HasValueChanged(_AccessGroupNumber, value, "AccessGroupNumber"))
        {
          _AccessGroupNumber = value; 
          RaisePropertyChanged("AccessGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Description Resource Key value
    /// </summary>
    
    [DataMember]
    
    public Guid DescriptionResourceKey 
    { 
      get { return _DescriptionResourceKey; }
      set 
      { 
        if(HasValueChanged(_DescriptionResourceKey, value, "DescriptionResourceKey"))
        {
          _DescriptionResourceKey = value; 
          RaisePropertyChanged("DescriptionResourceKey");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Description value
    /// </summary>
    
    [DataMember]
    
    public string Description 
    { 
      get { return _Description; }
      set 
      { 
        if(HasValueChanged(_Description, value, "Description"))
        {
          _Description = value; 
          RaisePropertyChanged("Description");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Display value
    /// </summary>
    
    [DataMember]
    
    public string Display 
    { 
      get { return _Display; }
      set 
      { 
        if(HasValueChanged(_Display, value, "Display"))
        {
          _Display = value; 
          RaisePropertyChanged("Display");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Service Comment value
    /// </summary>
    
    [DataMember]
    
    public string ServiceComment 
    { 
      get { return _ServiceComment; }
      set 
      { 
        if(HasValueChanged(_ServiceComment, value, "ServiceComment"))
        {
          _ServiceComment = value; 
          RaisePropertyChanged("ServiceComment");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Comment value
    /// </summary>
    
    [DataMember]
    
    public string Comment 
    { 
      get { return _Comment; }
      set 
      { 
        if(HasValueChanged(_Comment, value, "Comment"))
        {
          _Comment = value; 
          RaisePropertyChanged("Comment");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool IsEnabled 
    { 
      get { return _IsEnabled; }
      set 
      { 
        if(HasValueChanged(_IsEnabled, value, "IsEnabled"))
        {
          _IsEnabled = value; 
          RaisePropertyChanged("IsEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activation Date value
    /// </summary>
    
    [DataMember]
    
    public DateTime? ActivationDate 
    { 
      get { return _ActivationDate; }
      set 
      { 
        if(HasValueChanged(_ActivationDate, value, "ActivationDate"))
        {
          _ActivationDate = value; 
          RaisePropertyChanged("ActivationDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Expiration Date value
    /// </summary>
    
    [DataMember]
    
    public DateTime? ExpirationDate 
    { 
      get { return _ExpirationDate; }
      set 
      { 
        if(HasValueChanged(_ExpirationDate, value, "ExpirationDate"))
        {
          _ExpirationDate = value; 
          RaisePropertyChanged("ExpirationDate");
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
    /// Get/Set the Crisis Mode Access Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CrisisModeAccessGroupUid 
    { 
      get { return _CrisisModeAccessGroupUid; }
      set 
      { 
        if(HasValueChanged(_CrisisModeAccessGroupUid, value, "CrisisModeAccessGroupUid"))
        {
          _CrisisModeAccessGroupUid = value; 
          RaisePropertyChanged("CrisisModeAccessGroupUid");
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
        
    /// <summary>
    /// Get/Set the Culture Name value
    /// </summary>
    
    [DataMember]
    
    public string CultureName 
    { 
      get { return _CultureName; }
      set 
      { 
        if(HasValueChanged(_CultureName, value, "CultureName"))
        {
          _CultureName = value; 
          RaisePropertyChanged("CultureName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Page Number value
    /// </summary>
    
    [DataMember]
    
    public int PageNumber 
    { 
      get { return _PageNumber; }
      set 
      { 
        if(HasValueChanged(_PageNumber, value, "PageNumber"))
        {
          _PageNumber = value; 
          RaisePropertyChanged("PageNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Page Size value
    /// </summary>
    
    [DataMember]
    
    public int PageSize 
    { 
      get { return _PageSize; }
      set 
      { 
        if(HasValueChanged(_PageSize, value, "PageSize"))
        {
          _PageSize = value; 
          RaisePropertyChanged("PageSize");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Total Row Count value
    /// </summary>
    
    [DataMember]
    
    public int TotalRowCount 
    { 
      get { return _TotalRowCount; }
      set 
      { 
        if(HasValueChanged(_TotalRowCount, value, "TotalRowCount"))
        {
          _TotalRowCount = value; 
          RaisePropertyChanged("TotalRowCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Sort Column value
    /// </summary>
    
    [DataMember]
    
    public string SortColumn 
    { 
      get { return _SortColumn; }
      set 
      { 
        if(HasValueChanged(_SortColumn, value, "SortColumn"))
        {
          _SortColumn = value; 
          RaisePropertyChanged("SortColumn");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Descending Order value
    /// </summary>
    
    [DataMember]
    
    public bool DescendingOrder 
    { 
      get { return _DescendingOrder; }
      set 
      { 
        if(HasValueChanged(_DescendingOrder, value, "DescendingOrder"))
        {
          _DescendingOrder = value; 
          RaisePropertyChanged("DescendingOrder");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include System Groups value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeSystemGroups 
    { 
      get { return _IncludeSystemGroups; }
      set 
      { 
        if(HasValueChanged(_IncludeSystemGroups, value, "IncludeSystemGroups"))
        {
          _IncludeSystemGroups = value; 
          RaisePropertyChanged("IncludeSystemGroups");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Crisis Mode Access Group Number value
    /// </summary>
    
    [DataMember]
    
    public int CrisisModeAccessGroupNumber 
    { 
      get { return _CrisisModeAccessGroupNumber; }
      set 
      { 
        if(HasValueChanged(_CrisisModeAccessGroupNumber, value, "CrisisModeAccessGroupNumber"))
        {
          _CrisisModeAccessGroupNumber = value; 
          RaisePropertyChanged("CrisisModeAccessGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Crisis Mode Access Group Name value
    /// </summary>
    
    [DataMember]
    
    public string CrisisModeAccessGroupName 
    { 
      get { return _CrisisModeAccessGroupName; }
      set 
      { 
        if(HasValueChanged(_CrisisModeAccessGroupName, value, "CrisisModeAccessGroupName"))
        {
          _CrisisModeAccessGroupName = value; 
          RaisePropertyChanged("CrisisModeAccessGroupName");
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
    /// Get/Set the Default Time Schedule Name value
    /// </summary>
    
    [DataMember]
    
    public string DefaultTimeScheduleName 
    { 
      get { return _DefaultTimeScheduleName; }
      set 
      { 
        if(HasValueChanged(_DefaultTimeScheduleName, value, "DefaultTimeScheduleName"))
        {
          _DefaultTimeScheduleName = value; 
          RaisePropertyChanged("DefaultTimeScheduleName");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Access Group UidOld value
    /// </summary>
    
    public Guid AccessGroupUidOld
    { 
      get { return _AccessGroupUidOld; }
      set 
      { 
        if(HasValueChanged(_AccessGroupUidOld, value, "AccessGroupUid"))
        {
          _AccessGroupUidOld = value; 
          RaisePropertyChanged("AccessGroupUidOld");
        }
      } 
    }
    #endregion
  }
}
