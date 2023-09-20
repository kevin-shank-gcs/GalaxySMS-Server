using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA class
    /// </summary>
    public InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA() : base()
    {
      ClassName = "InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection : List<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA>
  {
    
    /// <summary>
    /// Get all InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA Objects</returns>
    public List<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA>();
    }
        
    /// <summary>
    /// Get all InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA Objects where IsSelected=True</returns>
    public List<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA>();
    }

  }
}
