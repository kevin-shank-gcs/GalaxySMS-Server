using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForMercScpGroupPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForMercScpGroupPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForMercScpGroupPDSA class
    /// </summary>
    public GetEntityIdForMercScpGroupPDSA() : base()
    {
      ClassName = "GetEntityIdForMercScpGroupPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForMercScpGroupPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForMercScpGroupPDSACollection : List<GetEntityIdForMercScpGroupPDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForMercScpGroupPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForMercScpGroupPDSA Objects</returns>
    public List<GetEntityIdForMercScpGroupPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForMercScpGroupPDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForMercScpGroupPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForMercScpGroupPDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForMercScpGroupPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForMercScpGroupPDSA>();
    }

  }
}
