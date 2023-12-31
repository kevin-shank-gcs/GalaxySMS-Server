using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyCpuInformationPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GalaxyCpuInformationPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyCpuInformationPDSA class
    /// </summary>
    public GalaxyCpuInformationPDSA() : base()
    {
      ClassName = "GalaxyCpuInformationPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyCpuInformationPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyCpuInformationPDSACollection : List<GalaxyCpuInformationPDSA>
  {
    
    /// <summary>
    /// Get all GalaxyCpuInformationPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyCpuInformationPDSA Objects</returns>
    public List<GalaxyCpuInformationPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyCpuInformationPDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyCpuInformationPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyCpuInformationPDSA Objects where IsSelected=True</returns>
    public List<GalaxyCpuInformationPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyCpuInformationPDSA>();
    }

  }
}
