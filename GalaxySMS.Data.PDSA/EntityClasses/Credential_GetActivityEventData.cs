using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the Credential_GetActivityEventDataPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class Credential_GetActivityEventDataPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the Credential_GetActivityEventDataPDSA class
    /// </summary>
    public Credential_GetActivityEventDataPDSA() : base()
    {
      ClassName = "Credential_GetActivityEventDataPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of Credential_GetActivityEventDataPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class Credential_GetActivityEventDataPDSACollection : List<Credential_GetActivityEventDataPDSA>
  {
    
    /// <summary>
    /// Get all Credential_GetActivityEventDataPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of Credential_GetActivityEventDataPDSA Objects</returns>
    public List<Credential_GetActivityEventDataPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<Credential_GetActivityEventDataPDSA>();
    }
        
    /// <summary>
    /// Get all Credential_GetActivityEventDataPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of Credential_GetActivityEventDataPDSA Objects where IsSelected=True</returns>
    public List<Credential_GetActivityEventDataPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<Credential_GetActivityEventDataPDSA>();
    }

  }
}
