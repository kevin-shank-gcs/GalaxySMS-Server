using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAreaEntityMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAreaEntityMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAreaEntityMapUniquePDSA class
    /// </summary>
    public IsAreaEntityMapUniquePDSA() : base()
    {
      ClassName = "IsAreaEntityMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAreaEntityMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAreaEntityMapUniquePDSACollection : List<IsAreaEntityMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAreaEntityMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAreaEntityMapUniquePDSA Objects</returns>
    public List<IsAreaEntityMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAreaEntityMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAreaEntityMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAreaEntityMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAreaEntityMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAreaEntityMapUniquePDSA>();
    }

  }
}
