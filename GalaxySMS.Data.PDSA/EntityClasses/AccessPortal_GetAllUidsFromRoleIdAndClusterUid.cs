using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA class
    /// </summary>
    public AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA() : base()
    {
      ClassName = "AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSACollection : List<AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA>
  {
    
    /// <summary>
    /// Get all AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA Objects</returns>
    public List<AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA Objects where IsSelected=True</returns>
    public List<AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSA>();
    }

  }
}
