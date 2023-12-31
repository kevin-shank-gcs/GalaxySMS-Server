using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForInputDevicePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForInputDevicePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForInputDevicePDSA class
    /// </summary>
    public GetEntityIdForInputDevicePDSA() : base()
    {
      ClassName = "GetEntityIdForInputDevicePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForInputDevicePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForInputDevicePDSACollection : List<GetEntityIdForInputDevicePDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForInputDevicePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForInputDevicePDSA Objects</returns>
    public List<GetEntityIdForInputDevicePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForInputDevicePDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForInputDevicePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForInputDevicePDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForInputDevicePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForInputDevicePDSA>();
    }

  }
}
