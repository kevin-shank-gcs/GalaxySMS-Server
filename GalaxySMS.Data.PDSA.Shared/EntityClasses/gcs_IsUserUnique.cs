using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_IsUserUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_IsUserUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_IsUserUniquePDSA class
    /// </summary>
    public gcs_IsUserUniquePDSA() : base()
    {
      ClassName = "gcs_IsUserUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_IsUserUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcs_IsUserUniquePDSACollection : List<gcs_IsUserUniquePDSA>
  {
    
    /// <summary>
    /// Get all gcs_IsUserUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_IsUserUniquePDSA Objects</returns>
    public List<gcs_IsUserUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_IsUserUniquePDSA>();
    }
        
    /// <summary>
    /// Get all gcs_IsUserUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_IsUserUniquePDSA Objects where IsSelected=True</returns>
    public List<gcs_IsUserUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_IsUserUniquePDSA>();
    }

  }
}
