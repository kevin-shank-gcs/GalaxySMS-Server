using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortal_SelectionListForEntityAndClusterPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessPortal_SelectionListForEntityAndClusterPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortal_SelectionListForEntityAndClusterPDSA class
    /// </summary>
    public AccessPortal_SelectionListForEntityAndClusterPDSA() : base()
    {
      ClassName = "AccessPortal_SelectionListForEntityAndClusterPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortal_SelectionListForEntityAndClusterPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortal_SelectionListForEntityAndClusterPDSACollection : List<AccessPortal_SelectionListForEntityAndClusterPDSA>
  {
    
    /// <summary>
    /// Get all AccessPortal_SelectionListForEntityAndClusterPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortal_SelectionListForEntityAndClusterPDSA Objects</returns>
    public List<AccessPortal_SelectionListForEntityAndClusterPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortal_SelectionListForEntityAndClusterPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortal_SelectionListForEntityAndClusterPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortal_SelectionListForEntityAndClusterPDSA Objects where IsSelected=True</returns>
    public List<AccessPortal_SelectionListForEntityAndClusterPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortal_SelectionListForEntityAndClusterPDSA>();
    }

  }
}
