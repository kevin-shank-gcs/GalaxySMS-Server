using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForGalaxyInputOutputGroupPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForGalaxyInputOutputGroupPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForGalaxyInputOutputGroupPDSA class
    /// </summary>
    public GetEntityIdForGalaxyInputOutputGroupPDSA() : base()
    {
      ClassName = "GetEntityIdForGalaxyInputOutputGroupPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForGalaxyInputOutputGroupPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForGalaxyInputOutputGroupPDSACollection : List<GetEntityIdForGalaxyInputOutputGroupPDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForGalaxyInputOutputGroupPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyInputOutputGroupPDSA Objects</returns>
    public List<GetEntityIdForGalaxyInputOutputGroupPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForGalaxyInputOutputGroupPDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForGalaxyInputOutputGroupPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyInputOutputGroupPDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForGalaxyInputOutputGroupPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForGalaxyInputOutputGroupPDSA>();
    }

  }
}
