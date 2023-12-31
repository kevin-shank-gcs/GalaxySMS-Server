using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsDayTypeEntityMapUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsDayTypeEntityMapUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsDayTypeEntityMapUniquePDSA class
    /// </summary>
    public IsDayTypeEntityMapUniquePDSA() : base()
    {
      ClassName = "IsDayTypeEntityMapUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsDayTypeEntityMapUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsDayTypeEntityMapUniquePDSACollection : List<IsDayTypeEntityMapUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsDayTypeEntityMapUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsDayTypeEntityMapUniquePDSA Objects</returns>
    public List<IsDayTypeEntityMapUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsDayTypeEntityMapUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsDayTypeEntityMapUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsDayTypeEntityMapUniquePDSA Objects where IsSelected=True</returns>
    public List<IsDayTypeEntityMapUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsDayTypeEntityMapUniquePDSA>();
    }

  }
}
