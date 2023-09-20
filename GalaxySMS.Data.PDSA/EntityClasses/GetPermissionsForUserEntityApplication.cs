using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetPermissionsForUserEntityApplicationPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetPermissionsForUserEntityApplicationPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetPermissionsForUserEntityApplicationPDSA class
    /// </summary>
    public GetPermissionsForUserEntityApplicationPDSA() : base()
    {
      ClassName = "GetPermissionsForUserEntityApplicationPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetPermissionsForUserEntityApplicationPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetPermissionsForUserEntityApplicationPDSACollection : List<GetPermissionsForUserEntityApplicationPDSA>
  {
    
    /// <summary>
    /// Get all GetPermissionsForUserEntityApplicationPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetPermissionsForUserEntityApplicationPDSA Objects</returns>
    public List<GetPermissionsForUserEntityApplicationPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetPermissionsForUserEntityApplicationPDSA>();
    }
        
    /// <summary>
    /// Get all GetPermissionsForUserEntityApplicationPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetPermissionsForUserEntityApplicationPDSA Objects where IsSelected=True</returns>
    public List<GetPermissionsForUserEntityApplicationPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetPermissionsForUserEntityApplicationPDSA>();
    }

  }
}
