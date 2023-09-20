using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA class
    /// </summary>
    public InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA() : base()
    {
      ClassName = "InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSACollection : List<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA>
  {
    
    /// <summary>
    /// Get all InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA Objects</returns>
    public List<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA>();
    }
        
    /// <summary>
    /// Get all InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA Objects where IsSelected=True</returns>
    public List<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionNodeUidPDSA>();
    }

  }
}
