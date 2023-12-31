using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA class
    /// </summary>
    public InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA() : base()
    {
      ClassName = "InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSACollection : List<InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA>
  {
    
    /// <summary>
    /// Get all InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA Objects</returns>
    public List<InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA>();
    }
        
    /// <summary>
    /// Get all InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA Objects where IsSelected=True</returns>
    public List<InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA>();
    }

  }
}
