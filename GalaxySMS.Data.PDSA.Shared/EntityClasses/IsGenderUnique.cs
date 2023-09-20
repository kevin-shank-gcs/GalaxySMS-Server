using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGenderUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGenderUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGenderUniquePDSA class
    /// </summary>
    public IsGenderUniquePDSA() : base()
    {
      ClassName = "IsGenderUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGenderUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsGenderUniquePDSACollection : List<IsGenderUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGenderUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGenderUniquePDSA Objects</returns>
    public List<IsGenderUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGenderUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGenderUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGenderUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGenderUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGenderUniquePDSA>();
    }

  }
}
