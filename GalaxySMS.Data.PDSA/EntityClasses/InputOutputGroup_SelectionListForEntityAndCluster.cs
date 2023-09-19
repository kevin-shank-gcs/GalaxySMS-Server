using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputOutputGroup_SelectionListForEntityAndClusterPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class InputOutputGroup_SelectionListForEntityAndClusterPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputOutputGroup_SelectionListForEntityAndClusterPDSA class
    /// </summary>
    public InputOutputGroup_SelectionListForEntityAndClusterPDSA() : base()
    {
      ClassName = "InputOutputGroup_SelectionListForEntityAndClusterPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of InputOutputGroup_SelectionListForEntityAndClusterPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputOutputGroup_SelectionListForEntityAndClusterPDSACollection : List<InputOutputGroup_SelectionListForEntityAndClusterPDSA>
  {
    
    /// <summary>
    /// Get all InputOutputGroup_SelectionListForEntityAndClusterPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputOutputGroup_SelectionListForEntityAndClusterPDSA Objects</returns>
    public List<InputOutputGroup_SelectionListForEntityAndClusterPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputOutputGroup_SelectionListForEntityAndClusterPDSA>();
    }
        
    /// <summary>
    /// Get all InputOutputGroup_SelectionListForEntityAndClusterPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputOutputGroup_SelectionListForEntityAndClusterPDSA Objects where IsSelected=True</returns>
    public List<InputOutputGroup_SelectionListForEntityAndClusterPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputOutputGroup_SelectionListForEntityAndClusterPDSA>();
    }

  }
}
