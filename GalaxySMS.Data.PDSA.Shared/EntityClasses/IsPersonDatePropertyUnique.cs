using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsPersonDatePropertyUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsPersonDatePropertyUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsPersonDatePropertyUniquePDSA class
    /// </summary>
    public IsPersonDatePropertyUniquePDSA() : base()
    {
      ClassName = "IsPersonDatePropertyUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsPersonDatePropertyUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsPersonDatePropertyUniquePDSACollection : List<IsPersonDatePropertyUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsPersonDatePropertyUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsPersonDatePropertyUniquePDSA Objects</returns>
    public List<IsPersonDatePropertyUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsPersonDatePropertyUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsPersonDatePropertyUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsPersonDatePropertyUniquePDSA Objects where IsSelected=True</returns>
    public List<IsPersonDatePropertyUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsPersonDatePropertyUniquePDSA>();
    }

  }
}
