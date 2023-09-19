using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the ActivityEventViewPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class ActivityEventViewPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the ActivityEventViewPDSA class
    /// </summary>
    public ActivityEventViewPDSA() : base()
    {
      ClassName = "ActivityEventViewPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of ActivityEventViewPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class ActivityEventViewPDSACollection : List<ActivityEventViewPDSA>
  {
    
    /// <summary>
    /// Get all ActivityEventViewPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of ActivityEventViewPDSA Objects</returns>
    public List<ActivityEventViewPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<ActivityEventViewPDSA>();
    }
        
    /// <summary>
    /// Get all ActivityEventViewPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of ActivityEventViewPDSA Objects where IsSelected=True</returns>
    public List<ActivityEventViewPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<ActivityEventViewPDSA>();
    }

  }
}
