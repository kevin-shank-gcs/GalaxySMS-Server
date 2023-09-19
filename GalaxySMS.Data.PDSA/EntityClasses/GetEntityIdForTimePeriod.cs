using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForTimePeriodPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForTimePeriodPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForTimePeriodPDSA class
    /// </summary>
    public GetEntityIdForTimePeriodPDSA() : base()
    {
      ClassName = "GetEntityIdForTimePeriodPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForTimePeriodPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForTimePeriodPDSACollection : List<GetEntityIdForTimePeriodPDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForTimePeriodPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForTimePeriodPDSA Objects</returns>
    public List<GetEntityIdForTimePeriodPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForTimePeriodPDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForTimePeriodPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForTimePeriodPDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForTimePeriodPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForTimePeriodPDSA>();
    }

  }
}
