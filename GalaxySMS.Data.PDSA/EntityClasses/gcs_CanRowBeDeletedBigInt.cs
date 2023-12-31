using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_CanRowBeDeletedBigIntPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_CanRowBeDeletedBigIntPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_CanRowBeDeletedBigIntPDSA class
    /// </summary>
    public gcs_CanRowBeDeletedBigIntPDSA() : base()
    {
      ClassName = "gcs_CanRowBeDeletedBigIntPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_CanRowBeDeletedBigIntPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcs_CanRowBeDeletedBigIntPDSACollection : List<gcs_CanRowBeDeletedBigIntPDSA>
  {
    
    /// <summary>
    /// Get all gcs_CanRowBeDeletedBigIntPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_CanRowBeDeletedBigIntPDSA Objects</returns>
    public List<gcs_CanRowBeDeletedBigIntPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_CanRowBeDeletedBigIntPDSA>();
    }
        
    /// <summary>
    /// Get all gcs_CanRowBeDeletedBigIntPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_CanRowBeDeletedBigIntPDSA Objects where IsSelected=True</returns>
    public List<gcs_CanRowBeDeletedBigIntPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_CanRowBeDeletedBigIntPDSA>();
    }

  }
}
