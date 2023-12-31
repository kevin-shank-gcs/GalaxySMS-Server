using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsMercSioTypeUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsMercSioTypeUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsMercSioTypeUniquePDSA class
    /// </summary>
    public IsMercSioTypeUniquePDSA() : base()
    {
      ClassName = "IsMercSioTypeUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsMercSioTypeUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsMercSioTypeUniquePDSACollection : List<IsMercSioTypeUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsMercSioTypeUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsMercSioTypeUniquePDSA Objects</returns>
    public List<IsMercSioTypeUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsMercSioTypeUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsMercSioTypeUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsMercSioTypeUniquePDSA Objects where IsSelected=True</returns>
    public List<IsMercSioTypeUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsMercSioTypeUniquePDSA>();
    }

  }
}
