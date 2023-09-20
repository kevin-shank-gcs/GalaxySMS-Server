using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_IsLanguageUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_IsLanguageUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_IsLanguageUniquePDSA class
    /// </summary>
    public gcs_IsLanguageUniquePDSA() : base()
    {
      ClassName = "gcs_IsLanguageUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_IsLanguageUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcs_IsLanguageUniquePDSACollection : List<gcs_IsLanguageUniquePDSA>
  {
    
    /// <summary>
    /// Get all gcs_IsLanguageUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_IsLanguageUniquePDSA Objects</returns>
    public List<gcs_IsLanguageUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_IsLanguageUniquePDSA>();
    }
        
    /// <summary>
    /// Get all gcs_IsLanguageUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_IsLanguageUniquePDSA Objects where IsSelected=True</returns>
    public List<gcs_IsLanguageUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_IsLanguageUniquePDSA>();
    }

  }
}
