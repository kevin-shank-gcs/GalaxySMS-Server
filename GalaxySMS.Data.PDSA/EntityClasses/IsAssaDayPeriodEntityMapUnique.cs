using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAssaDayPeriodEntityMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAssaDayPeriodEntityMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAssaDayPeriodEntityMapUniquePDSA class
    /// </summary>
    public IsAssaDayPeriodEntityMapUniquePDSA() : base()
    {
      ClassName = "IsAssaDayPeriodEntityMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAssaDayPeriodEntityMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAssaDayPeriodEntityMapUniquePDSACollection : List<IsAssaDayPeriodEntityMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAssaDayPeriodEntityMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAssaDayPeriodEntityMapUniquePDSA Objects</returns>
    public List<IsAssaDayPeriodEntityMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAssaDayPeriodEntityMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAssaDayPeriodEntityMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAssaDayPeriodEntityMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAssaDayPeriodEntityMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAssaDayPeriodEntityMapUniquePDSA>();
    }

  }
}
