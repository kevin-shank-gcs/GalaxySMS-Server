using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsMercScpTypeUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsMercScpTypeUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsMercScpTypeUniquePDSA class
    /// </summary>
    public IsMercScpTypeUniquePDSA() : base()
    {
      ClassName = "IsMercScpTypeUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsMercScpTypeUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsMercScpTypeUniquePDSACollection : List<IsMercScpTypeUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsMercScpTypeUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsMercScpTypeUniquePDSA Objects</returns>
    public List<IsMercScpTypeUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsMercScpTypeUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsMercScpTypeUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsMercScpTypeUniquePDSA Objects where IsSelected=True</returns>
    public List<IsMercScpTypeUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsMercScpTypeUniquePDSA>();
    }

  }
}
