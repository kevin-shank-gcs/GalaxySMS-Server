using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA class
    /// </summary>
    public AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA() : base()
    {
      ClassName = "AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSACollection : List<AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA>
  {
    
    /// <summary>
    /// Get all AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA Objects</returns>
    public List<AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA Objects where IsSelected=True</returns>
    public List<AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSA>();
    }

  }
}
