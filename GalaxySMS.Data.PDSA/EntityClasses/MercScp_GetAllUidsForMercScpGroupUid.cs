using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the MercScp_GetAllUidsForMercScpGroupUidPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class MercScp_GetAllUidsForMercScpGroupUidPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the MercScp_GetAllUidsForMercScpGroupUidPDSA class
    /// </summary>
    public MercScp_GetAllUidsForMercScpGroupUidPDSA() : base()
    {
      ClassName = "MercScp_GetAllUidsForMercScpGroupUidPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of MercScp_GetAllUidsForMercScpGroupUidPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class MercScp_GetAllUidsForMercScpGroupUidPDSACollection : List<MercScp_GetAllUidsForMercScpGroupUidPDSA>
  {
    
    /// <summary>
    /// Get all MercScp_GetAllUidsForMercScpGroupUidPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of MercScp_GetAllUidsForMercScpGroupUidPDSA Objects</returns>
    public List<MercScp_GetAllUidsForMercScpGroupUidPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<MercScp_GetAllUidsForMercScpGroupUidPDSA>();
    }
        
    /// <summary>
    /// Get all MercScp_GetAllUidsForMercScpGroupUidPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of MercScp_GetAllUidsForMercScpGroupUidPDSA Objects where IsSelected=True</returns>
    public List<MercScp_GetAllUidsForMercScpGroupUidPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<MercScp_GetAllUidsForMercScpGroupUidPDSA>();
    }

  }
}
