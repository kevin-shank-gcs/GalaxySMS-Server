using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAccessPortalAreaTypeUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAccessPortalAreaTypeUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAccessPortalAreaTypeUniquePDSA class
    /// </summary>
    public IsAccessPortalAreaTypeUniquePDSA() : base()
    {
      ClassName = "IsAccessPortalAreaTypeUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAccessPortalAreaTypeUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAccessPortalAreaTypeUniquePDSACollection : List<IsAccessPortalAreaTypeUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAccessPortalAreaTypeUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAccessPortalAreaTypeUniquePDSA Objects</returns>
    public List<IsAccessPortalAreaTypeUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAccessPortalAreaTypeUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAccessPortalAreaTypeUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAccessPortalAreaTypeUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAccessPortalAreaTypeUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAccessPortalAreaTypeUniquePDSA>();
    }

  }
}
