using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsRoleOutputDevicePermissionUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsRoleOutputDevicePermissionUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsRoleOutputDevicePermissionUniquePDSA class
    /// </summary>
    public IsRoleOutputDevicePermissionUniquePDSA() : base()
    {
      ClassName = "IsRoleOutputDevicePermissionUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsRoleOutputDevicePermissionUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsRoleOutputDevicePermissionUniquePDSACollection : List<IsRoleOutputDevicePermissionUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsRoleOutputDevicePermissionUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsRoleOutputDevicePermissionUniquePDSA Objects</returns>
    public List<IsRoleOutputDevicePermissionUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsRoleOutputDevicePermissionUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsRoleOutputDevicePermissionUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsRoleOutputDevicePermissionUniquePDSA Objects where IsSelected=True</returns>
    public List<IsRoleOutputDevicePermissionUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsRoleOutputDevicePermissionUniquePDSA>();
    }

  }
}
