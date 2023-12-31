using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyInterfaceBoardSection_PanelLoadDataPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GalaxyInterfaceBoardSection_PanelLoadDataPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyInterfaceBoardSection_PanelLoadDataPDSA class
    /// </summary>
    public GalaxyInterfaceBoardSection_PanelLoadDataPDSA() : base()
    {
      ClassName = "GalaxyInterfaceBoardSection_PanelLoadDataPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyInterfaceBoardSection_PanelLoadDataPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection : List<GalaxyInterfaceBoardSection_PanelLoadDataPDSA>
  {
    
    /// <summary>
    /// Get all GalaxyInterfaceBoardSection_PanelLoadDataPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSection_PanelLoadDataPDSA Objects</returns>
    public List<GalaxyInterfaceBoardSection_PanelLoadDataPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyInterfaceBoardSection_PanelLoadDataPDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyInterfaceBoardSection_PanelLoadDataPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSection_PanelLoadDataPDSA Objects where IsSelected=True</returns>
    public List<GalaxyInterfaceBoardSection_PanelLoadDataPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyInterfaceBoardSection_PanelLoadDataPDSA>();
    }

  }
}
