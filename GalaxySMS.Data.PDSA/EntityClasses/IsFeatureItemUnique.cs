using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsFeatureItemUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsFeatureItemUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsFeatureItemUniquePDSA class
    /// </summary>
    public IsFeatureItemUniquePDSA() : base()
    {
      ClassName = "IsFeatureItemUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsFeatureItemUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsFeatureItemUniquePDSACollection : List<IsFeatureItemUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsFeatureItemUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsFeatureItemUniquePDSA Objects</returns>
    public List<IsFeatureItemUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsFeatureItemUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsFeatureItemUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsFeatureItemUniquePDSA Objects where IsSelected=True</returns>
    public List<IsFeatureItemUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsFeatureItemUniquePDSA>();
    }

  }
}
