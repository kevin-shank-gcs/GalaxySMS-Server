using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsPersonInputOutputGroupUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsPersonInputOutputGroupUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsPersonInputOutputGroupUniquePDSA class
    /// </summary>
    public IsPersonInputOutputGroupUniquePDSA() : base()
    {
      ClassName = "IsPersonInputOutputGroupUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsPersonInputOutputGroupUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsPersonInputOutputGroupUniquePDSACollection : List<IsPersonInputOutputGroupUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsPersonInputOutputGroupUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsPersonInputOutputGroupUniquePDSA Objects</returns>
    public List<IsPersonInputOutputGroupUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsPersonInputOutputGroupUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsPersonInputOutputGroupUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsPersonInputOutputGroupUniquePDSA Objects where IsSelected=True</returns>
    public List<IsPersonInputOutputGroupUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsPersonInputOutputGroupUniquePDSA>();
    }

  }
}
