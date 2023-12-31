using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsInputDeviceAlertEventUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsInputDeviceAlertEventUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsInputDeviceAlertEventUniquePDSA class
    /// </summary>
    public IsInputDeviceAlertEventUniquePDSA() : base()
    {
      ClassName = "IsInputDeviceAlertEventUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsInputDeviceAlertEventUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsInputDeviceAlertEventUniquePDSACollection : List<IsInputDeviceAlertEventUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsInputDeviceAlertEventUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsInputDeviceAlertEventUniquePDSA Objects</returns>
    public List<IsInputDeviceAlertEventUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsInputDeviceAlertEventUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsInputDeviceAlertEventUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsInputDeviceAlertEventUniquePDSA Objects where IsSelected=True</returns>
    public List<IsInputDeviceAlertEventUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsInputDeviceAlertEventUniquePDSA>();
    }

  }
}
