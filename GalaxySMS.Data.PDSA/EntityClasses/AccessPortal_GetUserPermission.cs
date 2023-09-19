using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortal_GetUserPermissionPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessPortal_GetUserPermissionPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortal_GetUserPermissionPDSA class
    /// </summary>
    public AccessPortal_GetUserPermissionPDSA() : base()
    {
      ClassName = "AccessPortal_GetUserPermissionPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortal_GetUserPermissionPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortal_GetUserPermissionPDSACollection : List<AccessPortal_GetUserPermissionPDSA>
  {
    
    /// <summary>
    /// Get all AccessPortal_GetUserPermissionPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetUserPermissionPDSA Objects</returns>
    public List<AccessPortal_GetUserPermissionPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortal_GetUserPermissionPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortal_GetUserPermissionPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetUserPermissionPDSA Objects where IsSelected=True</returns>
    public List<AccessPortal_GetUserPermissionPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortal_GetUserPermissionPDSA>();
    }

  }
}
