using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetEntityIdForAssaDsrPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetEntityIdForAssaDsrPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetEntityIdForAssaDsrPDSA class
    /// </summary>
    public GetEntityIdForAssaDsrPDSA() : base()
    {
      ClassName = "GetEntityIdForAssaDsrPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetEntityIdForAssaDsrPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetEntityIdForAssaDsrPDSACollection : List<GetEntityIdForAssaDsrPDSA>
  {
    
    /// <summary>
    /// Get all GetEntityIdForAssaDsrPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetEntityIdForAssaDsrPDSA Objects</returns>
    public List<GetEntityIdForAssaDsrPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetEntityIdForAssaDsrPDSA>();
    }
        
    /// <summary>
    /// Get all GetEntityIdForAssaDsrPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetEntityIdForAssaDsrPDSA Objects where IsSelected=True</returns>
    public List<GetEntityIdForAssaDsrPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetEntityIdForAssaDsrPDSA>();
    }

  }
}
