using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA class
    /// </summary>
    public MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA() : base()
    {
      ClassName = "MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSACollection : List<MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA>
  {
    
    /// <summary>
    /// Get all MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA Objects</returns>
    public List<MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA>();
    }
        
    /// <summary>
    /// Get all MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA Objects where IsSelected=True</returns>
    public List<MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA>();
    }

  }
}
