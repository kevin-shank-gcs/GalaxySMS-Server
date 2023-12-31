using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcsEntity_GetTimeScheduleCountPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcsEntity_GetTimeScheduleCountPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcsEntity_GetTimeScheduleCountPDSA class
    /// </summary>
    public gcsEntity_GetTimeScheduleCountPDSA() : base()
    {
      ClassName = "gcsEntity_GetTimeScheduleCountPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcsEntity_GetTimeScheduleCountPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class gcsEntity_GetTimeScheduleCountPDSACollection : List<gcsEntity_GetTimeScheduleCountPDSA>
  {
    
    /// <summary>
    /// Get all gcsEntity_GetTimeScheduleCountPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcsEntity_GetTimeScheduleCountPDSA Objects</returns>
    public List<gcsEntity_GetTimeScheduleCountPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcsEntity_GetTimeScheduleCountPDSA>();
    }
        
    /// <summary>
    /// Get all gcsEntity_GetTimeScheduleCountPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcsEntity_GetTimeScheduleCountPDSA Objects where IsSelected=True</returns>
    public List<gcsEntity_GetTimeScheduleCountPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcsEntity_GetTimeScheduleCountPDSA>();
    }

  }
}
