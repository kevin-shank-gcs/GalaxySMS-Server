using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsRoleOutputDeviceUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsRoleOutputDeviceUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsRoleOutputDeviceUniquePDSA class
    /// </summary>
    public IsRoleOutputDeviceUniquePDSA() : base()
    {
      ClassName = "IsRoleOutputDeviceUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsRoleOutputDeviceUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsRoleOutputDeviceUniquePDSACollection : List<IsRoleOutputDeviceUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsRoleOutputDeviceUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsRoleOutputDeviceUniquePDSA Objects</returns>
    public List<IsRoleOutputDeviceUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsRoleOutputDeviceUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsRoleOutputDeviceUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsRoleOutputDeviceUniquePDSA Objects where IsSelected=True</returns>
    public List<IsRoleOutputDeviceUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsRoleOutputDeviceUniquePDSA>();
    }

  }
}
