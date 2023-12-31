using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a MercScpGroupPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class MercScpGroupPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _MercScpGroupUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private Guid _SiteUid = Guid.Empty;
    private string _Name = string.Empty;
    private int _NumberOfTransactions = 0;
    private short _NumberOfOperatingModes = 0;
    private short _OperatingModeType = 0;
    private bool _AllowConnection = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _Description = string.Empty;
    private int _PageNumber = 0;
    private bool _IsActive = false;
    private int _PageSize = 0;
    private string _SortColumn = string.Empty;
    private bool _DescendingOrder = false;
    private int _TotalRowCount = 0;
    private Guid _MercScpGroupUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Merc Scp Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid MercScpGroupUid 
    { 
      get { return _MercScpGroupUid; }
      set 
      { 
        if(HasValueChanged(_MercScpGroupUid, value, "MercScpGroupUid"))
        {
          _MercScpGroupUid = value; 
          RaisePropertyChanged("MercScpGroupUid");
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
    /// Get/Set the Name value
    /// </summary>
    
    [DataMember]
    
    public string Name 
    { 
      get { return _Name; }
      set 
      { 
        if(HasValueChanged(_Name, value, "Name"))
        {
          _Name = value; 
          RaisePropertyChanged("Name");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Number Of Transactions value
    /// </summary>
    
    [DataMember]
    
    public int NumberOfTransactions 
    { 
      get { return _NumberOfTransactions; }
      set 
      { 
        if(HasValueChanged(_NumberOfTransactions, value, "NumberOfTransactions"))
        {
          _NumberOfTransactions = value; 
          RaisePropertyChanged("NumberOfTransactions");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Number Of Operating Modes value
    /// </summary>
    
    [DataMember]
    
    public short NumberOfOperatingModes 
    { 
      get { return _NumberOfOperatingModes; }
      set 
      { 
        if(HasValueChanged(_NumberOfOperatingModes, value, "NumberOfOperatingModes"))
        {
          _NumberOfOperatingModes = value; 
          RaisePropertyChanged("NumberOfOperatingModes");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Operating Mode Type value
    /// </summary>
    
    [DataMember]
    
    public short OperatingModeType 
    { 
      get { return _OperatingModeType; }
      set 
      { 
        if(HasValueChanged(_OperatingModeType, value, "OperatingModeType"))
        {
          _OperatingModeType = value; 
          RaisePropertyChanged("OperatingModeType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Allow Connection value
    /// </summary>
    
    [DataMember]
    
    public bool AllowConnection 
    { 
      get { return _AllowConnection; }
      set 
      { 
        if(HasValueChanged(_AllowConnection, value, "AllowConnection"))
        {
          _AllowConnection = value; 
          RaisePropertyChanged("AllowConnection");
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
    /// Get/Set the Merc Scp Group UidOld value
    /// </summary>
    
    public Guid MercScpGroupUidOld
    { 
      get { return _MercScpGroupUidOld; }
      set 
      { 
        if(HasValueChanged(_MercScpGroupUidOld, value, "MercScpGroupUid"))
        {
          _MercScpGroupUidOld = value; 
          RaisePropertyChanged("MercScpGroupUidOld");
        }
      } 
    }
    #endregion
  }
}
