using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessGroup_GetPanelLoadDataByClusterUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessGroup_GetPanelLoadDataByClusterUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessGroup_GetPanelLoadDataByClusterUidPDSA class
    /// </summary>
    public AccessGroup_GetPanelLoadDataByClusterUidPDSA() : base()
    {
      ClassName = "AccessGroup_GetPanelLoadDataByClusterUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessGroup_GetPanelLoadDataByClusterUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessGroup_GetPanelLoadDataByClusterUidPDSACollection : List<AccessGroup_GetPanelLoadDataByClusterUidPDSA>
  {
    
    /// <summary>
    /// Get all AccessGroup_GetPanelLoadDataByClusterUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessGroup_GetPanelLoadDataByClusterUidPDSA Objects</returns>
    public List<AccessGroup_GetPanelLoadDataByClusterUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessGroup_GetPanelLoadDataByClusterUidPDSA>();
    }
        
    /// <summary>
    /// Get all AccessGroup_GetPanelLoadDataByClusterUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessGroup_GetPanelLoadDataByClusterUidPDSA Objects where IsSelected=True</returns>
    public List<AccessGroup_GetPanelLoadDataByClusterUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessGroup_GetPanelLoadDataByClusterUidPDSA>();
    }

  }
}
