using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the select_ActivityEventsPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class select_ActivityEventsPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the select_ActivityEventsPDSA class
    /// </summary>
    public select_ActivityEventsPDSA() : base()
    {
      ClassName = "select_ActivityEventsPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of select_ActivityEventsPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class select_ActivityEventsPDSACollection : List<select_ActivityEventsPDSA>
  {
    
    /// <summary>
    /// Get all select_ActivityEventsPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of select_ActivityEventsPDSA Objects</returns>
    public List<select_ActivityEventsPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<select_ActivityEventsPDSA>();
    }
        
    /// <summary>
    /// Get all select_ActivityEventsPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of select_ActivityEventsPDSA Objects where IsSelected=True</returns>
    public List<select_ActivityEventsPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<select_ActivityEventsPDSA>();
    }

  }
}
