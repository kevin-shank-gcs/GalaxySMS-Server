using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGalaxyPanelAlertEventUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGalaxyPanelAlertEventUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGalaxyPanelAlertEventUniquePDSA class
    /// </summary>
    public IsGalaxyPanelAlertEventUniquePDSA() : base()
    {
      ClassName = "IsGalaxyPanelAlertEventUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGalaxyPanelAlertEventUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsGalaxyPanelAlertEventUniquePDSACollection : List<IsGalaxyPanelAlertEventUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGalaxyPanelAlertEventUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGalaxyPanelAlertEventUniquePDSA Objects</returns>
    public List<IsGalaxyPanelAlertEventUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGalaxyPanelAlertEventUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGalaxyPanelAlertEventUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGalaxyPanelAlertEventUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGalaxyPanelAlertEventUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGalaxyPanelAlertEventUniquePDSA>();
    }

  }
}
