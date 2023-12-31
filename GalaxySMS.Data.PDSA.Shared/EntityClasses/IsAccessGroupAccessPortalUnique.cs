using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAccessGroupAccessPortalUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAccessGroupAccessPortalUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAccessGroupAccessPortalUniquePDSA class
    /// </summary>
    public IsAccessGroupAccessPortalUniquePDSA() : base()
    {
      ClassName = "IsAccessGroupAccessPortalUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAccessGroupAccessPortalUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAccessGroupAccessPortalUniquePDSACollection : List<IsAccessGroupAccessPortalUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAccessGroupAccessPortalUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAccessGroupAccessPortalUniquePDSA Objects</returns>
    public List<IsAccessGroupAccessPortalUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAccessGroupAccessPortalUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAccessGroupAccessPortalUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAccessGroupAccessPortalUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAccessGroupAccessPortalUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAccessGroupAccessPortalUniquePDSA>();
    }

  }
}
