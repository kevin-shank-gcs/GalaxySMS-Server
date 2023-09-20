using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the DateTypeDefaultBehavior_PanelLoadDataPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class DateTypeDefaultBehavior_PanelLoadDataPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_PanelLoadDataPDSA class
    /// </summary>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA() : base()
    {
      ClassName = "DateTypeDefaultBehavior_PanelLoadDataPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of DateTypeDefaultBehavior_PanelLoadDataPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class DateTypeDefaultBehavior_PanelLoadDataPDSACollection : List<DateTypeDefaultBehavior_PanelLoadDataPDSA>
  {
    
    /// <summary>
    /// Get all DateTypeDefaultBehavior_PanelLoadDataPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of DateTypeDefaultBehavior_PanelLoadDataPDSA Objects</returns>
    public List<DateTypeDefaultBehavior_PanelLoadDataPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<DateTypeDefaultBehavior_PanelLoadDataPDSA>();
    }
        
    /// <summary>
    /// Get all DateTypeDefaultBehavior_PanelLoadDataPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of DateTypeDefaultBehavior_PanelLoadDataPDSA Objects where IsSelected=True</returns>
    public List<DateTypeDefaultBehavior_PanelLoadDataPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<DateTypeDefaultBehavior_PanelLoadDataPDSA>();
    }

  }
}
