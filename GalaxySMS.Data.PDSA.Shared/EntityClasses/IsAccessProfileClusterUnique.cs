using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsAccessProfileClusterUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsAccessProfileClusterUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsAccessProfileClusterUniquePDSA class
    /// </summary>
    public IsAccessProfileClusterUniquePDSA() : base()
    {
      ClassName = "IsAccessProfileClusterUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsAccessProfileClusterUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsAccessProfileClusterUniquePDSACollection : List<IsAccessProfileClusterUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsAccessProfileClusterUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsAccessProfileClusterUniquePDSA Objects</returns>
    public List<IsAccessProfileClusterUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsAccessProfileClusterUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsAccessProfileClusterUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsAccessProfileClusterUniquePDSA Objects where IsSelected=True</returns>
    public List<IsAccessProfileClusterUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsAccessProfileClusterUniquePDSA>();
    }

  }
}
