using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_DoesUserHaveEntityPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_DoesUserHaveEntityPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_DoesUserHaveEntityPDSA class
    /// </summary>
    public gcs_DoesUserHaveEntityPDSA() : base()
    {
      ClassName = "gcs_DoesUserHaveEntityPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_DoesUserHaveEntityPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class gcs_DoesUserHaveEntityPDSACollection : List<gcs_DoesUserHaveEntityPDSA>
  {
    
    /// <summary>
    /// Get all gcs_DoesUserHaveEntityPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_DoesUserHaveEntityPDSA Objects</returns>
    public List<gcs_DoesUserHaveEntityPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_DoesUserHaveEntityPDSA>();
    }
        
    /// <summary>
    /// Get all gcs_DoesUserHaveEntityPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_DoesUserHaveEntityPDSA Objects where IsSelected=True</returns>
    public List<gcs_DoesUserHaveEntityPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_DoesUserHaveEntityPDSA>();
    }

  }
}
