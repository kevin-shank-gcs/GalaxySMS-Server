using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_IsPermissionUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_IsPermissionUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_IsPermissionUniquePDSA class
    /// </summary>
    public gcs_IsPermissionUniquePDSA() : base()
    {
      ClassName = "gcs_IsPermissionUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_IsPermissionUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcs_IsPermissionUniquePDSACollection : List<gcs_IsPermissionUniquePDSA>
  {
    
    /// <summary>
    /// Get all gcs_IsPermissionUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_IsPermissionUniquePDSA Objects</returns>
    public List<gcs_IsPermissionUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_IsPermissionUniquePDSA>();
    }
        
    /// <summary>
    /// Get all gcs_IsPermissionUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_IsPermissionUniquePDSA Objects where IsSelected=True</returns>
    public List<gcs_IsPermissionUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_IsPermissionUniquePDSA>();
    }

  }
}
