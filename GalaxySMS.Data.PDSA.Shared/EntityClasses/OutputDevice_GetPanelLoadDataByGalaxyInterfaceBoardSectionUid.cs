using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA class
    /// </summary>
    public OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA() : base()
    {
      ClassName = "OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSACollection : List<OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA>
  {
    
    /// <summary>
    /// Get all OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA Objects</returns>
    public List<OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA>();
    }
        
    /// <summary>
    /// Get all OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA Objects where IsSelected=True</returns>
    public List<OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA>();
    }

  }
}
