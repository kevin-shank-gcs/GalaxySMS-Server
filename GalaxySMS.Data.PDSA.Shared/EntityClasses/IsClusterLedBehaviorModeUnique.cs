using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsClusterLedBehaviorModeUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsClusterLedBehaviorModeUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsClusterLedBehaviorModeUniquePDSA class
    /// </summary>
    public IsClusterLedBehaviorModeUniquePDSA() : base()
    {
      ClassName = "IsClusterLedBehaviorModeUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsClusterLedBehaviorModeUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsClusterLedBehaviorModeUniquePDSACollection : List<IsClusterLedBehaviorModeUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsClusterLedBehaviorModeUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsClusterLedBehaviorModeUniquePDSA Objects</returns>
    public List<IsClusterLedBehaviorModeUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsClusterLedBehaviorModeUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsClusterLedBehaviorModeUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsClusterLedBehaviorModeUniquePDSA Objects where IsSelected=True</returns>
    public List<IsClusterLedBehaviorModeUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsClusterLedBehaviorModeUniquePDSA>();
    }

  }
}
