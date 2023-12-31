using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the ClusterUid_GetByGalaxyHardwareModuleUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class ClusterUid_GetByGalaxyHardwareModuleUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the ClusterUid_GetByGalaxyHardwareModuleUidPDSA class
    /// </summary>
    public ClusterUid_GetByGalaxyHardwareModuleUidPDSA() : base()
    {
      ClassName = "ClusterUid_GetByGalaxyHardwareModuleUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of ClusterUid_GetByGalaxyHardwareModuleUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class ClusterUid_GetByGalaxyHardwareModuleUidPDSACollection : List<ClusterUid_GetByGalaxyHardwareModuleUidPDSA>
  {
    
    /// <summary>
    /// Get all ClusterUid_GetByGalaxyHardwareModuleUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of ClusterUid_GetByGalaxyHardwareModuleUidPDSA Objects</returns>
    public List<ClusterUid_GetByGalaxyHardwareModuleUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<ClusterUid_GetByGalaxyHardwareModuleUidPDSA>();
    }
        
    /// <summary>
    /// Get all ClusterUid_GetByGalaxyHardwareModuleUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of ClusterUid_GetByGalaxyHardwareModuleUidPDSA Objects where IsSelected=True</returns>
    public List<ClusterUid_GetByGalaxyHardwareModuleUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<ClusterUid_GetByGalaxyHardwareModuleUidPDSA>();
    }

  }
}
