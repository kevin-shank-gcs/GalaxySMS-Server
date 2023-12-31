using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetPersonIdForPersonPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetPersonIdForPersonPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetPersonIdForPersonPDSA class
    /// </summary>
    public GetPersonIdForPersonPDSA() : base()
    {
      ClassName = "GetPersonIdForPersonPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetPersonIdForPersonPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetPersonIdForPersonPDSACollection : List<GetPersonIdForPersonPDSA>
  {
    
    /// <summary>
    /// Get all GetPersonIdForPersonPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetPersonIdForPersonPDSA Objects</returns>
    public List<GetPersonIdForPersonPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetPersonIdForPersonPDSA>();
    }
        
    /// <summary>
    /// Get all GetPersonIdForPersonPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetPersonIdForPersonPDSA Objects where IsSelected=True</returns>
    public List<GetPersonIdForPersonPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetPersonIdForPersonPDSA>();
    }

  }
}
