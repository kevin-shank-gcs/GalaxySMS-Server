using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForBadgeTemplatePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForBadgeTemplatePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForBadgeTemplatePDSA class
    /// </summary>
    public GetEntityIdForBadgeTemplatePDSA() : base()
    {
      ClassName = "GetEntityIdForBadgeTemplatePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForBadgeTemplatePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForBadgeTemplatePDSACollection : List<GetEntityIdForBadgeTemplatePDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForBadgeTemplatePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForBadgeTemplatePDSA Objects</returns>
    public List<GetEntityIdForBadgeTemplatePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForBadgeTemplatePDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForBadgeTemplatePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForBadgeTemplatePDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForBadgeTemplatePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForBadgeTemplatePDSA>();
    }

  }
}
