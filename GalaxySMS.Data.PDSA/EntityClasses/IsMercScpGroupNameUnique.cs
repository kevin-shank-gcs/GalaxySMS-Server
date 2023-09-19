using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsMercScpGroupNameUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsMercScpGroupNameUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsMercScpGroupNameUniquePDSA class
    /// </summary>
    public IsMercScpGroupNameUniquePDSA() : base()
    {
      ClassName = "IsMercScpGroupNameUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsMercScpGroupNameUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsMercScpGroupNameUniquePDSACollection : List<IsMercScpGroupNameUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsMercScpGroupNameUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsMercScpGroupNameUniquePDSA Objects</returns>
    public List<IsMercScpGroupNameUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsMercScpGroupNameUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsMercScpGroupNameUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsMercScpGroupNameUniquePDSA Objects where IsSelected=True</returns>
    public List<IsMercScpGroupNameUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsMercScpGroupNameUniquePDSA>();
    }

  }
}
