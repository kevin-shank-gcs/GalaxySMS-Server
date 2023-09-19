using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsPersonEntityMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsPersonEntityMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsPersonEntityMapUniquePDSA class
    /// </summary>
    public IsPersonEntityMapUniquePDSA() : base()
    {
      ClassName = "IsPersonEntityMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsPersonEntityMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsPersonEntityMapUniquePDSACollection : List<IsPersonEntityMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsPersonEntityMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsPersonEntityMapUniquePDSA Objects</returns>
    public List<IsPersonEntityMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsPersonEntityMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsPersonEntityMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsPersonEntityMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsPersonEntityMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsPersonEntityMapUniquePDSA>();
    }

  }
}
