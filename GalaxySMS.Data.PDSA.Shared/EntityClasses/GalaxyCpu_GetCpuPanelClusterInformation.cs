using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyCpu_GetCpuPanelClusterInformationPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GalaxyCpu_GetCpuPanelClusterInformationPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyCpu_GetCpuPanelClusterInformationPDSA class
    /// </summary>
    public GalaxyCpu_GetCpuPanelClusterInformationPDSA() : base()
    {
      ClassName = "GalaxyCpu_GetCpuPanelClusterInformationPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyCpu_GetCpuPanelClusterInformationPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyCpu_GetCpuPanelClusterInformationPDSACollection : List<GalaxyCpu_GetCpuPanelClusterInformationPDSA>
  {
    
    /// <summary>
    /// Get all GalaxyCpu_GetCpuPanelClusterInformationPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyCpu_GetCpuPanelClusterInformationPDSA Objects</returns>
    public List<GalaxyCpu_GetCpuPanelClusterInformationPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyCpu_GetCpuPanelClusterInformationPDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyCpu_GetCpuPanelClusterInformationPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyCpu_GetCpuPanelClusterInformationPDSA Objects where IsSelected=True</returns>
    public List<GalaxyCpu_GetCpuPanelClusterInformationPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyCpu_GetCpuPanelClusterInformationPDSA>();
    }

  }
}
