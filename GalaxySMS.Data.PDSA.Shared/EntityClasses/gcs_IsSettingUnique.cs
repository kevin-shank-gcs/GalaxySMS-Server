using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_IsSettingUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_IsSettingUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_IsSettingUniquePDSA class
    /// </summary>
    public gcs_IsSettingUniquePDSA() : base()
    {
      ClassName = "gcs_IsSettingUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_IsSettingUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcs_IsSettingUniquePDSACollection : List<gcs_IsSettingUniquePDSA>
  {
    
    /// <summary>
    /// Get all gcs_IsSettingUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_IsSettingUniquePDSA Objects</returns>
    public List<gcs_IsSettingUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_IsSettingUniquePDSA>();
    }
        
    /// <summary>
    /// Get all gcs_IsSettingUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_IsSettingUniquePDSA Objects where IsSelected=True</returns>
    public List<gcs_IsSettingUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_IsSettingUniquePDSA>();
    }

  }
}
