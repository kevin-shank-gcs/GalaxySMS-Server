using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a GalaxyTimePeriodPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyTimePeriodPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyTimePeriodUid = Guid.Empty;
    private Guid _DisplayResourceKey = Guid.Empty;
    private Guid _DescriptionResourceKey = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private string _Display = string.Empty;
    private string _Description = string.Empty;
    private int _PanelTimePeriodNumber = 0;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _CultureName = string.Empty;
    private int _PageNumber = 0;
    private int _PageSize = 0;
    private int _TotalRowCount = 0;
    private bool _DescendingOrder = false;
    private string _SortColumn = string.Empty;
    private Guid _GalaxyTimePeriodUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Galaxy Time Period Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyTimePeriodUid 
    { 
      get { return _GalaxyTimePeriodUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyTimePeriodUid, value, "GalaxyTimePeriodUid"))
        {
          _GalaxyTimePeriodUid = value; 
          RaisePropertyChanged("GalaxyTimePeriodUid");
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
    /// Get/Set the Panel Time Period Number value
    /// </summary>
    
    [DataMember]
    
    public int PanelTimePeriodNumber 
    { 
      get { return _PanelTimePeriodNumber; }
      set 
      { 
        if(HasValueChanged(_PanelTimePeriodNumber, value, "PanelTimePeriodNumber"))
        {
          _PanelTimePeriodNumber = value; 
          RaisePropertyChanged("PanelTimePeriodNumber");
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
    /// Get/Set the Galaxy Time Period UidOld value
    /// </summary>
    
    public Guid GalaxyTimePeriodUidOld
    { 
      get { return _GalaxyTimePeriodUidOld; }
      set 
      { 
        if(HasValueChanged(_GalaxyTimePeriodUidOld, value, "GalaxyTimePeriodUid"))
        {
          _GalaxyTimePeriodUidOld = value; 
          RaisePropertyChanged("GalaxyTimePeriodUidOld");
        }
      } 
    }
    #endregion
  }
}
