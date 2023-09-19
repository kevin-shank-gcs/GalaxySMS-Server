using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the Cluster_GetPanelCommonLoadDataPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class Cluster_GetPanelCommonLoadDataPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the Cluster_GetPanelCommonLoadDataPDSA class
    /// </summary>
    public Cluster_GetPanelCommonLoadDataPDSA() : base()
    {
      ClassName = "Cluster_GetPanelCommonLoadDataPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of Cluster_GetPanelCommonLoadDataPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class Cluster_GetPanelCommonLoadDataPDSACollection : List<Cluster_GetPanelCommonLoadDataPDSA>
  {
    
    /// <summary>
    /// Get all Cluster_GetPanelCommonLoadDataPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of Cluster_GetPanelCommonLoadDataPDSA Objects</returns>
    public List<Cluster_GetPanelCommonLoadDataPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<Cluster_GetPanelCommonLoadDataPDSA>();
    }
        
    /// <summary>
    /// Get all Cluster_GetPanelCommonLoadDataPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of Cluster_GetPanelCommonLoadDataPDSA Objects where IsSelected=True</returns>
    public List<Cluster_GetPanelCommonLoadDataPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<Cluster_GetPanelCommonLoadDataPDSA>();
    }

  }
}
