using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAssaDsrTimeScheduleMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAssaDsrTimeScheduleMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAssaDsrTimeScheduleMapUniquePDSA class
    /// </summary>
    public IsAssaDsrTimeScheduleMapUniquePDSA() : base()
    {
      ClassName = "IsAssaDsrTimeScheduleMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAssaDsrTimeScheduleMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsAssaDsrTimeScheduleMapUniquePDSACollection : List<IsAssaDsrTimeScheduleMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAssaDsrTimeScheduleMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAssaDsrTimeScheduleMapUniquePDSA Objects</returns>
    public List<IsAssaDsrTimeScheduleMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAssaDsrTimeScheduleMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAssaDsrTimeScheduleMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAssaDsrTimeScheduleMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAssaDsrTimeScheduleMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAssaDsrTimeScheduleMapUniquePDSA>();
    }

  }
}
