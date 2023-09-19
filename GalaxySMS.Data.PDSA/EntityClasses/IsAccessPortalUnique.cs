using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAccessPortalUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAccessPortalUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAccessPortalUniquePDSA class
    /// </summary>
    public IsAccessPortalUniquePDSA() : base()
    {
      ClassName = "IsAccessPortalUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAccessPortalUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAccessPortalUniquePDSACollection : List<IsAccessPortalUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAccessPortalUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAccessPortalUniquePDSA Objects</returns>
    public List<IsAccessPortalUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAccessPortalUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAccessPortalUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAccessPortalUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAccessPortalUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAccessPortalUniquePDSA>();
    }

  }
}
