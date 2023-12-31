using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA class
    /// </summary>
    public AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA() : base()
    {
      ClassName = "AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessGroup_GetPanelLoadDataByAccessGroupUidPDSACollection : List<AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA>
  {
    
    /// <summary>
    /// Get all AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA Objects</returns>
    public List<AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA>();
    }
        
    /// <summary>
    /// Get all AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA Objects where IsSelected=True</returns>
    public List<AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA>();
    }

  }
}
