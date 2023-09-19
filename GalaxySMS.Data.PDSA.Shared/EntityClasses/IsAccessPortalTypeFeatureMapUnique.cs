using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAccessPortalTypeFeatureMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAccessPortalTypeFeatureMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAccessPortalTypeFeatureMapUniquePDSA class
    /// </summary>
    public IsAccessPortalTypeFeatureMapUniquePDSA() : base()
    {
      ClassName = "IsAccessPortalTypeFeatureMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAccessPortalTypeFeatureMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAccessPortalTypeFeatureMapUniquePDSACollection : List<IsAccessPortalTypeFeatureMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAccessPortalTypeFeatureMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAccessPortalTypeFeatureMapUniquePDSA Objects</returns>
    public List<IsAccessPortalTypeFeatureMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAccessPortalTypeFeatureMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAccessPortalTypeFeatureMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAccessPortalTypeFeatureMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAccessPortalTypeFeatureMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAccessPortalTypeFeatureMapUniquePDSA>();
    }

  }
}
