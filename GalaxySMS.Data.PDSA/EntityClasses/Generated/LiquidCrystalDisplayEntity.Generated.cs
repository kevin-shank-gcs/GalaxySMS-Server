using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a LiquidCrystalDisplayPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class LiquidCrystalDisplayPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _LiquidCrystalDisplayUid = Guid.NewGuid();
    private Guid _SiteUid = Guid.NewGuid();
    private Guid _EntityId = Guid.NewGuid();
    private string _LcdName = string.Empty;
    private string _Location = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _RegionUid = Guid.NewGuid();
    private Guid _AccessPortalUid = Guid.NewGuid();
    private Guid _GalaxyPanelUid = Guid.NewGuid();
    private string _SiteName = string.Empty;
    private string _RegionName = string.Empty;
    private Guid _LiquidCrystalDisplayUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Liquid Crystal Display Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid LiquidCrystalDisplayUid 
    { 
      get { return _LiquidCrystalDisplayUid; }
      set 
      { 
        if(HasValueChanged(_LiquidCrystalDisplayUid, value, "LiquidCrystalDisplayUid"))
        {
          _LiquidCrystalDisplayUid = value; 
          RaisePropertyChanged("LiquidCrystalDisplayUid");
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
    /// Get/Set the Lcd Name value
    /// </summary>
    
    [DataMember]
    
    public string LcdName 
    { 
      get { return _LcdName; }
      set 
      { 
        if(HasValueChanged(_LcdName, value, "LcdName"))
        {
          _LcdName = value; 
          RaisePropertyChanged("LcdName");
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
    /// Get/Set the Region Name value
    /// </summary>
    
    [DataMember]
    
    public string RegionName 
    { 
      get { return _RegionName; }
      set 
      { 
        if(HasValueChanged(_RegionName, value, "RegionName"))
        {
          _RegionName = value; 
          RaisePropertyChanged("RegionName");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Liquid Crystal Display UidOld value
    /// </summary>
    
    public Guid LiquidCrystalDisplayUidOld
    { 
      get { return _LiquidCrystalDisplayUidOld; }
      set 
      { 
        if(HasValueChanged(_LiquidCrystalDisplayUidOld, value, "LiquidCrystalDisplayUid"))
        {
          _LiquidCrystalDisplayUidOld = value; 
          RaisePropertyChanged("LiquidCrystalDisplayUidOld");
        }
      } 
    }
    #endregion
  }
}
