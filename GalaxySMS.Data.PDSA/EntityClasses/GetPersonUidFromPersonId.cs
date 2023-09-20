using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetPersonUidFromPersonIdPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetPersonUidFromPersonIdPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetPersonUidFromPersonIdPDSA class
    /// </summary>
    public GetPersonUidFromPersonIdPDSA() : base()
    {
      ClassName = "GetPersonUidFromPersonIdPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetPersonUidFromPersonIdPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetPersonUidFromPersonIdPDSACollection : List<GetPersonUidFromPersonIdPDSA>
  {
    
    /// <summary>
    /// Get all GetPersonUidFromPersonIdPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetPersonUidFromPersonIdPDSA Objects</returns>
    public List<GetPersonUidFromPersonIdPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetPersonUidFromPersonIdPDSA>();
    }
        
    /// <summary>
    /// Get all GetPersonUidFromPersonIdPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetPersonUidFromPersonIdPDSA Objects where IsSelected=True</returns>
    public List<GetPersonUidFromPersonIdPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetPersonUidFromPersonIdPDSA>();
    }

  }
}
