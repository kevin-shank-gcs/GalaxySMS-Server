using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGalaxyOutputInputSourceTriggerConditionUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGalaxyOutputInputSourceTriggerConditionUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceTriggerConditionUniquePDSA class
    /// </summary>
    public IsGalaxyOutputInputSourceTriggerConditionUniquePDSA() : base()
    {
      ClassName = "IsGalaxyOutputInputSourceTriggerConditionUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGalaxyOutputInputSourceTriggerConditionUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class IsGalaxyOutputInputSourceTriggerConditionUniquePDSACollection : List<IsGalaxyOutputInputSourceTriggerConditionUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGalaxyOutputInputSourceTriggerConditionUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGalaxyOutputInputSourceTriggerConditionUniquePDSA Objects</returns>
    public List<IsGalaxyOutputInputSourceTriggerConditionUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGalaxyOutputInputSourceTriggerConditionUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGalaxyOutputInputSourceTriggerConditionUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGalaxyOutputInputSourceTriggerConditionUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGalaxyOutputInputSourceTriggerConditionUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGalaxyOutputInputSourceTriggerConditionUniquePDSA>();
    }

  }
}
