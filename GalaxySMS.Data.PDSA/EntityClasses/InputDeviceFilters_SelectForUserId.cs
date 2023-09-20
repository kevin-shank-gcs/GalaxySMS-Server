using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputDeviceFilters_SelectForUserIdPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class InputDeviceFilters_SelectForUserIdPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputDeviceFilters_SelectForUserIdPDSA class
    /// </summary>
    public InputDeviceFilters_SelectForUserIdPDSA() : base()
    {
      ClassName = "InputDeviceFilters_SelectForUserIdPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of InputDeviceFilters_SelectForUserIdPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputDeviceFilters_SelectForUserIdPDSACollection : List<InputDeviceFilters_SelectForUserIdPDSA>
  {
    
    /// <summary>
    /// Get all InputDeviceFilters_SelectForUserIdPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputDeviceFilters_SelectForUserIdPDSA Objects</returns>
    public List<InputDeviceFilters_SelectForUserIdPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputDeviceFilters_SelectForUserIdPDSA>();
    }
        
    /// <summary>
    /// Get all InputDeviceFilters_SelectForUserIdPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputDeviceFilters_SelectForUserIdPDSA Objects where IsSelected=True</returns>
    public List<InputDeviceFilters_SelectForUserIdPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputDeviceFilters_SelectForUserIdPDSA>();
    }

  }
}
