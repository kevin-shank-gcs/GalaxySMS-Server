using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForGalaxyInterfaceBoardSectionPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForGalaxyInterfaceBoardSectionPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForGalaxyInterfaceBoardSectionPDSA class
    /// </summary>
    public GetEntityIdForGalaxyInterfaceBoardSectionPDSA() : base()
    {
      ClassName = "GetEntityIdForGalaxyInterfaceBoardSectionPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForGalaxyInterfaceBoardSectionPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForGalaxyInterfaceBoardSectionPDSACollection : List<GetEntityIdForGalaxyInterfaceBoardSectionPDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForGalaxyInterfaceBoardSectionPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyInterfaceBoardSectionPDSA Objects</returns>
    public List<GetEntityIdForGalaxyInterfaceBoardSectionPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForGalaxyInterfaceBoardSectionPDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForGalaxyInterfaceBoardSectionPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyInterfaceBoardSectionPDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForGalaxyInterfaceBoardSectionPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForGalaxyInterfaceBoardSectionPDSA>();
    }

  }
}
