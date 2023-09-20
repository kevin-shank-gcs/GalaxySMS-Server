using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA class
    /// </summary>
    public gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA() : base()
    {
      ClassName = "gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSACollection : List<gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA>
  {
    
    /// <summary>
    /// Get all gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA Objects</returns>
    public List<gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA>();
    }
        
    /// <summary>
    /// Get all gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA Objects where IsSelected=True</returns>
    public List<gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcs_SelectEntityApplicationRoleId_ByEntityApplicationAndRoleIdsPDSA>();
    }

  }
}
