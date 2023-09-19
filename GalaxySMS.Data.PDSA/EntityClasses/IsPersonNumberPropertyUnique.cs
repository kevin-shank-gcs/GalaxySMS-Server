using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsPersonNumberPropertyUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsPersonNumberPropertyUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsPersonNumberPropertyUniquePDSA class
    /// </summary>
    public IsPersonNumberPropertyUniquePDSA() : base()
    {
      ClassName = "IsPersonNumberPropertyUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsPersonNumberPropertyUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsPersonNumberPropertyUniquePDSACollection : List<IsPersonNumberPropertyUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsPersonNumberPropertyUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsPersonNumberPropertyUniquePDSA Objects</returns>
    public List<IsPersonNumberPropertyUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsPersonNumberPropertyUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsPersonNumberPropertyUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsPersonNumberPropertyUniquePDSA Objects where IsSelected=True</returns>
    public List<IsPersonNumberPropertyUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsPersonNumberPropertyUniquePDSA>();
    }

  }
}
