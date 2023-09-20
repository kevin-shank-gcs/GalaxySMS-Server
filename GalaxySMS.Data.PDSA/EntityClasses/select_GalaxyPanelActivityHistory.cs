using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the select_GalaxyPanelActivityHistoryPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class select_GalaxyPanelActivityHistoryPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the select_GalaxyPanelActivityHistoryPDSA class
    /// </summary>
    public select_GalaxyPanelActivityHistoryPDSA() : base()
    {
      ClassName = "select_GalaxyPanelActivityHistoryPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of select_GalaxyPanelActivityHistoryPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class select_GalaxyPanelActivityHistoryPDSACollection : List<select_GalaxyPanelActivityHistoryPDSA>
  {
    
    /// <summary>
    /// Get all select_GalaxyPanelActivityHistoryPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of select_GalaxyPanelActivityHistoryPDSA Objects</returns>
    public List<select_GalaxyPanelActivityHistoryPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<select_GalaxyPanelActivityHistoryPDSA>();
    }
        
    /// <summary>
    /// Get all select_GalaxyPanelActivityHistoryPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of select_GalaxyPanelActivityHistoryPDSA Objects where IsSelected=True</returns>
    public List<select_GalaxyPanelActivityHistoryPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<select_GalaxyPanelActivityHistoryPDSA>();
    }

  }
}
