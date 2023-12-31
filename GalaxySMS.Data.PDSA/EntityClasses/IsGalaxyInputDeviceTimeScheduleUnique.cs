using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGalaxyInputDeviceTimeScheduleUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGalaxyInputDeviceTimeScheduleUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGalaxyInputDeviceTimeScheduleUniquePDSA class
    /// </summary>
    public IsGalaxyInputDeviceTimeScheduleUniquePDSA() : base()
    {
      ClassName = "IsGalaxyInputDeviceTimeScheduleUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGalaxyInputDeviceTimeScheduleUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsGalaxyInputDeviceTimeScheduleUniquePDSACollection : List<IsGalaxyInputDeviceTimeScheduleUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGalaxyInputDeviceTimeScheduleUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGalaxyInputDeviceTimeScheduleUniquePDSA Objects</returns>
    public List<IsGalaxyInputDeviceTimeScheduleUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGalaxyInputDeviceTimeScheduleUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGalaxyInputDeviceTimeScheduleUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGalaxyInputDeviceTimeScheduleUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGalaxyInputDeviceTimeScheduleUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGalaxyInputDeviceTimeScheduleUniquePDSA>();
    }

  }
}
