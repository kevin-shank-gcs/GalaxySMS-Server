using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsTimePeriodEntityMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsTimePeriodEntityMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsTimePeriodEntityMapUniquePDSA class
    /// </summary>
    public IsTimePeriodEntityMapUniquePDSA() : base()
    {
      ClassName = "IsTimePeriodEntityMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsTimePeriodEntityMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsTimePeriodEntityMapUniquePDSACollection : List<IsTimePeriodEntityMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsTimePeriodEntityMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsTimePeriodEntityMapUniquePDSA Objects</returns>
    public List<IsTimePeriodEntityMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsTimePeriodEntityMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsTimePeriodEntityMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsTimePeriodEntityMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsTimePeriodEntityMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsTimePeriodEntityMapUniquePDSA>();
    }

  }
}
