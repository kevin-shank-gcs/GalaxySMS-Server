using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_DoesUserHavePermissionPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_DoesUserHavePermissionPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_DoesUserHavePermissionPDSA class
    /// </summary>
    public gcs_DoesUserHavePermissionPDSA() : base()
    {
      ClassName = "gcs_DoesUserHavePermissionPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_DoesUserHavePermissionPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcs_DoesUserHavePermissionPDSACollection : List<gcs_DoesUserHavePermissionPDSA>
  {
    
    /// <summary>
    /// Get all gcs_DoesUserHavePermissionPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_DoesUserHavePermissionPDSA Objects</returns>
    public List<gcs_DoesUserHavePermissionPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_DoesUserHavePermissionPDSA>();
    }
        
    /// <summary>
    /// Get all gcs_DoesUserHavePermissionPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_DoesUserHavePermissionPDSA Objects where IsSelected=True</returns>
    public List<gcs_DoesUserHavePermissionPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_DoesUserHavePermissionPDSA>();
    }

  }
}
