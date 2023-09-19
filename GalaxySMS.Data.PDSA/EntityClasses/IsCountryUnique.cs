using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsCountryUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsCountryUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsCountryUniquePDSA class
    /// </summary>
    public IsCountryUniquePDSA() : base()
    {
      ClassName = "IsCountryUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsCountryUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsCountryUniquePDSACollection : List<IsCountryUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsCountryUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsCountryUniquePDSA Objects</returns>
    public List<IsCountryUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsCountryUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsCountryUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsCountryUniquePDSA Objects where IsSelected=True</returns>
    public List<IsCountryUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsCountryUniquePDSA>();
    }

  }
}
