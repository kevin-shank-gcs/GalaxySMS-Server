using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsTimeScheduleUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsTimeScheduleUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsTimeScheduleUniquePDSA class
    /// </summary>
    public IsTimeScheduleUniquePDSA() : base()
    {
      ClassName = "IsTimeScheduleUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsTimeScheduleUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsTimeScheduleUniquePDSACollection : List<IsTimeScheduleUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsTimeScheduleUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsTimeScheduleUniquePDSA Objects</returns>
    public List<IsTimeScheduleUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsTimeScheduleUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsTimeScheduleUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsTimeScheduleUniquePDSA Objects where IsSelected=True</returns>
    public List<IsTimeScheduleUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsTimeScheduleUniquePDSA>();
    }

  }
}
