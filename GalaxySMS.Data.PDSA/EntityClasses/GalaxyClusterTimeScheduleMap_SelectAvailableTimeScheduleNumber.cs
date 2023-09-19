using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA class
    /// </summary>
    public GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA() : base()
    {
      ClassName = "GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSACollection : List<GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA>
  {
    
    /// <summary>
    /// Get all GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA Objects</returns>
    public List<GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA Objects where IsSelected=True</returns>
    public List<GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA>();
    }

  }
}
