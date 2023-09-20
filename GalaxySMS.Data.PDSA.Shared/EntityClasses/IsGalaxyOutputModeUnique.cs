using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGalaxyOutputModeUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGalaxyOutputModeUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGalaxyOutputModeUniquePDSA class
    /// </summary>
    public IsGalaxyOutputModeUniquePDSA() : base()
    {
      ClassName = "IsGalaxyOutputModeUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGalaxyOutputModeUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsGalaxyOutputModeUniquePDSACollection : List<IsGalaxyOutputModeUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGalaxyOutputModeUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGalaxyOutputModeUniquePDSA Objects</returns>
    public List<IsGalaxyOutputModeUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGalaxyOutputModeUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGalaxyOutputModeUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGalaxyOutputModeUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGalaxyOutputModeUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGalaxyOutputModeUniquePDSA>();
    }

  }
}
