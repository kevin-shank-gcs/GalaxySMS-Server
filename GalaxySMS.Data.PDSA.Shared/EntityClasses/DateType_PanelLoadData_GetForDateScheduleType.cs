using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the DateType_PanelLoadData_GetForDateScheduleTypePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class DateType_PanelLoadData_GetForDateScheduleTypePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the DateType_PanelLoadData_GetForDateScheduleTypePDSA class
    /// </summary>
    public DateType_PanelLoadData_GetForDateScheduleTypePDSA() : base()
    {
      ClassName = "DateType_PanelLoadData_GetForDateScheduleTypePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of DateType_PanelLoadData_GetForDateScheduleTypePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class DateType_PanelLoadData_GetForDateScheduleTypePDSACollection : List<DateType_PanelLoadData_GetForDateScheduleTypePDSA>
  {
    
    /// <summary>
    /// Get all DateType_PanelLoadData_GetForDateScheduleTypePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of DateType_PanelLoadData_GetForDateScheduleTypePDSA Objects</returns>
    public List<DateType_PanelLoadData_GetForDateScheduleTypePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<DateType_PanelLoadData_GetForDateScheduleTypePDSA>();
    }
        
    /// <summary>
    /// Get all DateType_PanelLoadData_GetForDateScheduleTypePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of DateType_PanelLoadData_GetForDateScheduleTypePDSA Objects where IsSelected=True</returns>
    public List<DateType_PanelLoadData_GetForDateScheduleTypePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<DateType_PanelLoadData_GetForDateScheduleTypePDSA>();
    }

  }
}
