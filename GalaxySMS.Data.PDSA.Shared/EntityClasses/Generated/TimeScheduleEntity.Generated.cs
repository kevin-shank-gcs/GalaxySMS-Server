using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a TimeSchedulePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class TimeSchedulePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _TimeScheduleUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private Guid _DisplayResourceKey = Guid.Empty;
    private Guid _DescriptionResourceKey = Guid.Empty;
    private string _InsertName = string.Empty;
    private string _Display = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _Description = string.Empty;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _GalaxyClusterUid = Guid.Empty;
    private string _AssaAbloyDSRId = string.Empty;
    private string _AssaDsrUid = string.Empty;
    private string _CultureName = string.Empty;
    private Guid _TimeScheduleUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid TimeScheduleUid 
    { 
      get { return _TimeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleUid, value, "TimeScheduleUid"))
        {
          _TimeScheduleUid = value; 
          RaisePropertyChanged("TimeScheduleUid");
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
    /// Get/Set the Galaxy Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyClusterUid 
    { 
      get { return _GalaxyClusterUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyClusterUid, value, "GalaxyClusterUid"))
        {
          _GalaxyClusterUid = value; 
          RaisePropertyChanged("GalaxyClusterUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Assa Abloy DSR Id value
    /// </summary>
    
    [DataMember]
    
    public string AssaAbloyDSRId 
    { 
      get { return _AssaAbloyDSRId; }
      set 
      { 
        if(HasValueChanged(_AssaAbloyDSRId, value, "AssaAbloyDSRId"))
        {
          _AssaAbloyDSRId = value; 
          RaisePropertyChanged("AssaAbloyDSRId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Assa Dsr Uid value
    /// </summary>
    
    [DataMember]
    
    public string AssaDsrUid 
    { 
      get { return _AssaDsrUid; }
      set 
      { 
        if(HasValueChanged(_AssaDsrUid, value, "AssaDsrUid"))
        {
          _AssaDsrUid = value; 
          RaisePropertyChanged("AssaDsrUid");
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
    /// Get/Set the Time Schedule UidOld value
    /// </summary>
    
    public Guid TimeScheduleUidOld
    { 
      get { return _TimeScheduleUidOld; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleUidOld, value, "TimeScheduleUid"))
        {
          _TimeScheduleUidOld = value; 
          RaisePropertyChanged("TimeScheduleUidOld");
        }
      } 
    }
    #endregion
  }
}
