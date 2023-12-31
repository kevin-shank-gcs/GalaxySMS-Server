using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsInputOutputGroupAssignmentUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsInputOutputGroupAssignmentUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsInputOutputGroupAssignmentUniquePDSA class
    /// </summary>
    public IsInputOutputGroupAssignmentUniquePDSA() : base()
    {
      ClassName = "IsInputOutputGroupAssignmentUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsInputOutputGroupAssignmentUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsInputOutputGroupAssignmentUniquePDSACollection : List<IsInputOutputGroupAssignmentUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsInputOutputGroupAssignmentUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsInputOutputGroupAssignmentUniquePDSA Objects</returns>
    public List<IsInputOutputGroupAssignmentUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsInputOutputGroupAssignmentUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsInputOutputGroupAssignmentUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsInputOutputGroupAssignmentUniquePDSA Objects where IsSelected=True</returns>
    public List<IsInputOutputGroupAssignmentUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsInputOutputGroupAssignmentUniquePDSA>();
    }

  }
}
