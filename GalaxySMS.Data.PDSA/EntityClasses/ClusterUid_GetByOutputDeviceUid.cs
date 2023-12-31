using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the ClusterUid_GetByOutputDeviceUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class ClusterUid_GetByOutputDeviceUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the ClusterUid_GetByOutputDeviceUidPDSA class
    /// </summary>
    public ClusterUid_GetByOutputDeviceUidPDSA() : base()
    {
      ClassName = "ClusterUid_GetByOutputDeviceUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of ClusterUid_GetByOutputDeviceUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class ClusterUid_GetByOutputDeviceUidPDSACollection : List<ClusterUid_GetByOutputDeviceUidPDSA>
  {
    
    /// <summary>
    /// Get all ClusterUid_GetByOutputDeviceUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of ClusterUid_GetByOutputDeviceUidPDSA Objects</returns>
    public List<ClusterUid_GetByOutputDeviceUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<ClusterUid_GetByOutputDeviceUidPDSA>();
    }
        
    /// <summary>
    /// Get all ClusterUid_GetByOutputDeviceUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of ClusterUid_GetByOutputDeviceUidPDSA Objects where IsSelected=True</returns>
    public List<ClusterUid_GetByOutputDeviceUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<ClusterUid_GetByOutputDeviceUidPDSA>();
    }

  }
}
