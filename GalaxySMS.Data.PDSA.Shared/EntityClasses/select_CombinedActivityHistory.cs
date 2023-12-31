using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the select_CombinedActivityHistoryPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class select_CombinedActivityHistoryPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the select_CombinedActivityHistoryPDSA class
    /// </summary>
    public select_CombinedActivityHistoryPDSA() : base()
    {
      ClassName = "select_CombinedActivityHistoryPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of select_CombinedActivityHistoryPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class select_CombinedActivityHistoryPDSACollection : List<select_CombinedActivityHistoryPDSA>
  {
    
    /// <summary>
    /// Get all select_CombinedActivityHistoryPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of select_CombinedActivityHistoryPDSA Objects</returns>
    public List<select_CombinedActivityHistoryPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<select_CombinedActivityHistoryPDSA>();
    }
        
    /// <summary>
    /// Get all select_CombinedActivityHistoryPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of select_CombinedActivityHistoryPDSA Objects where IsSelected=True</returns>
    public List<select_CombinedActivityHistoryPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<select_CombinedActivityHistoryPDSA>();
    }

  }
}
