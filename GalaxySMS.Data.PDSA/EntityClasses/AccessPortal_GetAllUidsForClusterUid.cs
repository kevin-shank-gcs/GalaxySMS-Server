using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortal_GetAllUidsForClusterUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessPortal_GetAllUidsForClusterUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortal_GetAllUidsForClusterUidPDSA class
    /// </summary>
    public AccessPortal_GetAllUidsForClusterUidPDSA() : base()
    {
      ClassName = "AccessPortal_GetAllUidsForClusterUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortal_GetAllUidsForClusterUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortal_GetAllUidsForClusterUidPDSACollection : List<AccessPortal_GetAllUidsForClusterUidPDSA>
  {
    
    /// <summary>
    /// Get all AccessPortal_GetAllUidsForClusterUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetAllUidsForClusterUidPDSA Objects</returns>
    public List<AccessPortal_GetAllUidsForClusterUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortal_GetAllUidsForClusterUidPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortal_GetAllUidsForClusterUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortal_GetAllUidsForClusterUidPDSA Objects where IsSelected=True</returns>
    public List<AccessPortal_GetAllUidsForClusterUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortal_GetAllUidsForClusterUidPDSA>();
    }

  }
}
