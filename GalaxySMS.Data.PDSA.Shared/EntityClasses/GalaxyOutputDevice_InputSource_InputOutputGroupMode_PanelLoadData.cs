using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA class
    /// </summary>
    public GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA() : base()
    {
      ClassName = "GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSACollection : List<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA>
  {
    
    /// <summary>
    /// Get all GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA Objects</returns>
    public List<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA Objects where IsSelected=True</returns>
    public List<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataPDSA>();
    }

  }
}
