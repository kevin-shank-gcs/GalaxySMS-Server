using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGalaxyPanelAlertEventTypeUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGalaxyPanelAlertEventTypeUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGalaxyPanelAlertEventTypeUniquePDSA class
    /// </summary>
    public IsGalaxyPanelAlertEventTypeUniquePDSA() : base()
    {
      ClassName = "IsGalaxyPanelAlertEventTypeUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGalaxyPanelAlertEventTypeUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsGalaxyPanelAlertEventTypeUniquePDSACollection : List<IsGalaxyPanelAlertEventTypeUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGalaxyPanelAlertEventTypeUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGalaxyPanelAlertEventTypeUniquePDSA Objects</returns>
    public List<IsGalaxyPanelAlertEventTypeUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGalaxyPanelAlertEventTypeUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGalaxyPanelAlertEventTypeUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGalaxyPanelAlertEventTypeUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGalaxyPanelAlertEventTypeUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGalaxyPanelAlertEventTypeUniquePDSA>();
    }

  }
}
