using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForGalaxyDateTypePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForGalaxyDateTypePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForGalaxyDateTypePDSA class
    /// </summary>
    public GetEntityIdForGalaxyDateTypePDSA() : base()
    {
      ClassName = "GetEntityIdForGalaxyDateTypePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForGalaxyDateTypePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForGalaxyDateTypePDSACollection : List<GetEntityIdForGalaxyDateTypePDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForGalaxyDateTypePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyDateTypePDSA Objects</returns>
    public List<GetEntityIdForGalaxyDateTypePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForGalaxyDateTypePDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForGalaxyDateTypePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyDateTypePDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForGalaxyDateTypePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForGalaxyDateTypePDSA>();
    }

  }
}
