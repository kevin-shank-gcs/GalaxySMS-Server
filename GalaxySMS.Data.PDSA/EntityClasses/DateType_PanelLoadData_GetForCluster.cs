using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the DateType_PanelLoadData_GetForClusterPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class DateType_PanelLoadData_GetForClusterPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the DateType_PanelLoadData_GetForClusterPDSA class
    /// </summary>
    public DateType_PanelLoadData_GetForClusterPDSA() : base()
    {
      ClassName = "DateType_PanelLoadData_GetForClusterPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of DateType_PanelLoadData_GetForClusterPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class DateType_PanelLoadData_GetForClusterPDSACollection : List<DateType_PanelLoadData_GetForClusterPDSA>
  {
    
    /// <summary>
    /// Get all DateType_PanelLoadData_GetForClusterPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of DateType_PanelLoadData_GetForClusterPDSA Objects</returns>
    public List<DateType_PanelLoadData_GetForClusterPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<DateType_PanelLoadData_GetForClusterPDSA>();
    }
        
    /// <summary>
    /// Get all DateType_PanelLoadData_GetForClusterPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of DateType_PanelLoadData_GetForClusterPDSA Objects where IsSelected=True</returns>
    public List<DateType_PanelLoadData_GetForClusterPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<DateType_PanelLoadData_GetForClusterPDSA>();
    }

  }
}
