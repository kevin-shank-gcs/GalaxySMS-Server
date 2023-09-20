using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsInputDeviceActivityAlarmEventUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsInputDeviceActivityAlarmEventUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsInputDeviceActivityAlarmEventUniquePDSA class
    /// </summary>
    public IsInputDeviceActivityAlarmEventUniquePDSA() : base()
    {
      ClassName = "IsInputDeviceActivityAlarmEventUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsInputDeviceActivityAlarmEventUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsInputDeviceActivityAlarmEventUniquePDSACollection : List<IsInputDeviceActivityAlarmEventUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsInputDeviceActivityAlarmEventUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsInputDeviceActivityAlarmEventUniquePDSA Objects</returns>
    public List<IsInputDeviceActivityAlarmEventUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsInputDeviceActivityAlarmEventUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsInputDeviceActivityAlarmEventUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsInputDeviceActivityAlarmEventUniquePDSA Objects where IsSelected=True</returns>
    public List<IsInputDeviceActivityAlarmEventUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsInputDeviceActivityAlarmEventUniquePDSA>();
    }

  }
}
