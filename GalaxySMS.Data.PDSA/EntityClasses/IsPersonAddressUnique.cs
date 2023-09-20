using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsPersonAddressUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsPersonAddressUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsPersonAddressUniquePDSA class
    /// </summary>
    public IsPersonAddressUniquePDSA() : base()
    {
      ClassName = "IsPersonAddressUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsPersonAddressUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsPersonAddressUniquePDSACollection : List<IsPersonAddressUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsPersonAddressUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsPersonAddressUniquePDSA Objects</returns>
    public List<IsPersonAddressUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsPersonAddressUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsPersonAddressUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsPersonAddressUniquePDSA Objects where IsSelected=True</returns>
    public List<IsPersonAddressUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsPersonAddressUniquePDSA>();
    }

  }
}
