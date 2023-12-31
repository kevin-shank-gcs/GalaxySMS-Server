using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForAccessProfilePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForAccessProfilePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForAccessProfilePDSA class
    /// </summary>
    public GetEntityIdForAccessProfilePDSA() : base()
    {
      ClassName = "GetEntityIdForAccessProfilePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForAccessProfilePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForAccessProfilePDSACollection : List<GetEntityIdForAccessProfilePDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForAccessProfilePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForAccessProfilePDSA Objects</returns>
    public List<GetEntityIdForAccessProfilePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForAccessProfilePDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForAccessProfilePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForAccessProfilePDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForAccessProfilePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForAccessProfilePDSA>();
    }

  }
}
