using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the DateType_GetClustersThatUseDateTypePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class DateType_GetClustersThatUseDateTypePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the DateType_GetClustersThatUseDateTypePDSA class
    /// </summary>
    public DateType_GetClustersThatUseDateTypePDSA() : base()
    {
      ClassName = "DateType_GetClustersThatUseDateTypePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of DateType_GetClustersThatUseDateTypePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class DateType_GetClustersThatUseDateTypePDSACollection : List<DateType_GetClustersThatUseDateTypePDSA>
  {
    
    /// <summary>
    /// Get all DateType_GetClustersThatUseDateTypePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of DateType_GetClustersThatUseDateTypePDSA Objects</returns>
    public List<DateType_GetClustersThatUseDateTypePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<DateType_GetClustersThatUseDateTypePDSA>();
    }
        
    /// <summary>
    /// Get all DateType_GetClustersThatUseDateTypePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of DateType_GetClustersThatUseDateTypePDSA Objects where IsSelected=True</returns>
    public List<DateType_GetClustersThatUseDateTypePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<DateType_GetClustersThatUseDateTypePDSA>();
    }

  }
}
