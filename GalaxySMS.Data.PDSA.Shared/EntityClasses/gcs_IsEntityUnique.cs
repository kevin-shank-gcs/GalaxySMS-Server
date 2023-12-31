using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_IsEntityUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_IsEntityUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_IsEntityUniquePDSA class
    /// </summary>
    public gcs_IsEntityUniquePDSA() : base()
    {
      ClassName = "gcs_IsEntityUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_IsEntityUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcs_IsEntityUniquePDSACollection : List<gcs_IsEntityUniquePDSA>
  {
    
    /// <summary>
    /// Get all gcs_IsEntityUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_IsEntityUniquePDSA Objects</returns>
    public List<gcs_IsEntityUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_IsEntityUniquePDSA>();
    }
        
    /// <summary>
    /// Get all gcs_IsEntityUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_IsEntityUniquePDSA Objects where IsSelected=True</returns>
    public List<gcs_IsEntityUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_IsEntityUniquePDSA>();
    }

  }
}
