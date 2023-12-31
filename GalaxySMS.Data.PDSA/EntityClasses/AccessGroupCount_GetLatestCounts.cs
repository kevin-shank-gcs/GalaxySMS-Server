using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessGroupCount_GetLatestCountsPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AccessGroupCount_GetLatestCountsPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessGroupCount_GetLatestCountsPDSA class
    /// </summary>
    public AccessGroupCount_GetLatestCountsPDSA() : base()
    {
      ClassName = "AccessGroupCount_GetLatestCountsPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of AccessGroupCount_GetLatestCountsPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessGroupCount_GetLatestCountsPDSACollection : List<AccessGroupCount_GetLatestCountsPDSA>
  {
    
    /// <summary>
    /// Get all AccessGroupCount_GetLatestCountsPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessGroupCount_GetLatestCountsPDSA Objects</returns>
    public List<AccessGroupCount_GetLatestCountsPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessGroupCount_GetLatestCountsPDSA>();
    }
        
    /// <summary>
    /// Get all AccessGroupCount_GetLatestCountsPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessGroupCount_GetLatestCountsPDSA Objects where IsSelected=True</returns>
    public List<AccessGroupCount_GetLatestCountsPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessGroupCount_GetLatestCountsPDSA>();
    }

  }
}
