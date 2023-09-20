using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAccessProfileUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAccessProfileUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAccessProfileUniquePDSA class
    /// </summary>
    public IsAccessProfileUniquePDSA() : base()
    {
      ClassName = "IsAccessProfileUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAccessProfileUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsAccessProfileUniquePDSACollection : List<IsAccessProfileUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAccessProfileUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAccessProfileUniquePDSA Objects</returns>
    public List<IsAccessProfileUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAccessProfileUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAccessProfileUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAccessProfileUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAccessProfileUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAccessProfileUniquePDSA>();
    }

  }
}
