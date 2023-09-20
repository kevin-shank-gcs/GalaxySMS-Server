using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA class
    /// </summary>
    public AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA() : base()
    {
      ClassName = "AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortal_GetPanelLoadDataByAccessPortalUidPDSACollection : List<AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA>
  {
    
    /// <summary>
    /// Get all AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA Objects</returns>
    public List<AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA Objects where IsSelected=True</returns>
    public List<AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortal_GetPanelLoadDataByAccessPortalUidPDSA>();
    }

  }
}
