using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGalaxyFlashImageUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGalaxyFlashImageUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGalaxyFlashImageUniquePDSA class
    /// </summary>
    public IsGalaxyFlashImageUniquePDSA() : base()
    {
      ClassName = "IsGalaxyFlashImageUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGalaxyFlashImageUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsGalaxyFlashImageUniquePDSACollection : List<IsGalaxyFlashImageUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGalaxyFlashImageUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGalaxyFlashImageUniquePDSA Objects</returns>
    public List<IsGalaxyFlashImageUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGalaxyFlashImageUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGalaxyFlashImageUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGalaxyFlashImageUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGalaxyFlashImageUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGalaxyFlashImageUniquePDSA>();
    }

  }
}
