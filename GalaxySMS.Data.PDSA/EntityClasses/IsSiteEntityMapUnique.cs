using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsSiteEntityMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsSiteEntityMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsSiteEntityMapUniquePDSA class
    /// </summary>
    public IsSiteEntityMapUniquePDSA() : base()
    {
      ClassName = "IsSiteEntityMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsSiteEntityMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsSiteEntityMapUniquePDSACollection : List<IsSiteEntityMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsSiteEntityMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsSiteEntityMapUniquePDSA Objects</returns>
    public List<IsSiteEntityMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsSiteEntityMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsSiteEntityMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsSiteEntityMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsSiteEntityMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsSiteEntityMapUniquePDSA>();
    }

  }
}
