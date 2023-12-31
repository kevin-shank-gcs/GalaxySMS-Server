using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForGalaxyTimePeriodPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForGalaxyTimePeriodPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForGalaxyTimePeriodPDSA class
    /// </summary>
    public GetEntityIdForGalaxyTimePeriodPDSA() : base()
    {
      ClassName = "GetEntityIdForGalaxyTimePeriodPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForGalaxyTimePeriodPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForGalaxyTimePeriodPDSACollection : List<GetEntityIdForGalaxyTimePeriodPDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForGalaxyTimePeriodPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyTimePeriodPDSA Objects</returns>
    public List<GetEntityIdForGalaxyTimePeriodPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForGalaxyTimePeriodPDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForGalaxyTimePeriodPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForGalaxyTimePeriodPDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForGalaxyTimePeriodPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForGalaxyTimePeriodPDSA>();
    }

  }
}
