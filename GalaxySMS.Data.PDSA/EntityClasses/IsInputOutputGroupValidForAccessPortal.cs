using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsInputOutputGroupValidForAccessPortalPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsInputOutputGroupValidForAccessPortalPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsInputOutputGroupValidForAccessPortalPDSA class
    /// </summary>
    public IsInputOutputGroupValidForAccessPortalPDSA() : base()
    {
      ClassName = "IsInputOutputGroupValidForAccessPortalPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsInputOutputGroupValidForAccessPortalPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsInputOutputGroupValidForAccessPortalPDSACollection : List<IsInputOutputGroupValidForAccessPortalPDSA>
  {
    
    /// <summary>
    /// Get all IsInputOutputGroupValidForAccessPortalPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsInputOutputGroupValidForAccessPortalPDSA Objects</returns>
    public List<IsInputOutputGroupValidForAccessPortalPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsInputOutputGroupValidForAccessPortalPDSA>();
    }
        
    /// <summary>
    /// Get all IsInputOutputGroupValidForAccessPortalPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsInputOutputGroupValidForAccessPortalPDSA Objects where IsSelected=True</returns>
    public List<IsInputOutputGroupValidForAccessPortalPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsInputOutputGroupValidForAccessPortalPDSA>();
    }

  }
}
