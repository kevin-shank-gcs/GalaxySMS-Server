using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AccessProfilePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessProfilePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessProfileUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private string _AccessProfileName = string.Empty;
    private string _Comments = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private int _PageNumber = 0;
    private int _PageSize = 0;
    private int _TotalRowCount = 0;
    private string _SortColumn = string.Empty;
    private bool _DescendingOrder = false;
    private int _PersonCount = 0;
    private bool _OmitNone = false;
    private Guid _AccessProfileUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Access Profile Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessProfileUid 
    { 
      get { return _AccessProfileUid; }
      set 
      { 
        if(HasValueChanged(_AccessProfileUid, value, "AccessProfileUid"))
        {
          _AccessProfileUid = value; 
          RaisePropertyChanged("AccessProfileUid");
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
    /// Get/Set the Access Profile Name value
    /// </summary>
    
    [DataMember]
    
    public string AccessProfileName 
    { 
      get { return _AccessProfileName; }
      set 
      { 
        if(HasValueChanged(_AccessProfileName, value, "AccessProfileName"))
        {
          _AccessProfileName = value; 
          RaisePropertyChanged("AccessProfileName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Comments value
    /// </summary>
    
    [DataMember]
    
    public string Comments 
    { 
      get { return _Comments; }
      set 
      { 
        if(HasValueChanged(_Comments, value, "Comments"))
        {
          _Comments = value; 
          RaisePropertyChanged("Comments");
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
    /// Get/Set the Person Count value
    /// </summary>
    
    [DataMember]
    
    public int PersonCount 
    { 
      get { return _PersonCount; }
      set 
      { 
        if(HasValueChanged(_PersonCount, value, "PersonCount"))
        {
          _PersonCount = value; 
          RaisePropertyChanged("PersonCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Omit None value
    /// </summary>
    
    [DataMember]
    
    public bool OmitNone 
    { 
      get { return _OmitNone; }
      set 
      { 
        if(HasValueChanged(_OmitNone, value, "OmitNone"))
        {
          _OmitNone = value; 
          RaisePropertyChanged("OmitNone");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Access Profile UidOld value
    /// </summary>
    
    public Guid AccessProfileUidOld
    { 
      get { return _AccessProfileUidOld; }
      set 
      { 
        if(HasValueChanged(_AccessProfileUidOld, value, "AccessProfileUid"))
        {
          _AccessProfileUidOld = value; 
          RaisePropertyChanged("AccessProfileUidOld");
        }
      } 
    }
    #endregion
  }
}
