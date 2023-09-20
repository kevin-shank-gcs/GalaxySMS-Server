using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the DeviceAlertEventSettings_ByEntityIdPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class DeviceAlertEventSettings_ByEntityIdPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the DeviceAlertEventSettings_ByEntityIdPDSA class
    /// </summary>
    public DeviceAlertEventSettings_ByEntityIdPDSA() : base()
    {
      ClassName = "DeviceAlertEventSettings_ByEntityIdPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of DeviceAlertEventSettings_ByEntityIdPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class DeviceAlertEventSettings_ByEntityIdPDSACollection : List<DeviceAlertEventSettings_ByEntityIdPDSA>
  {
    
    /// <summary>
    /// Get all DeviceAlertEventSettings_ByEntityIdPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of DeviceAlertEventSettings_ByEntityIdPDSA Objects</returns>
    public List<DeviceAlertEventSettings_ByEntityIdPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<DeviceAlertEventSettings_ByEntityIdPDSA>();
    }
        
    /// <summary>
    /// Get all DeviceAlertEventSettings_ByEntityIdPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of DeviceAlertEventSettings_ByEntityIdPDSA Objects where IsSelected=True</returns>
    public List<DeviceAlertEventSettings_ByEntityIdPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<DeviceAlertEventSettings_ByEntityIdPDSA>();
    }

  }
}
