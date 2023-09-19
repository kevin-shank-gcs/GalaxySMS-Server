using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the IsGalaxyCpuLoggingControlUniquePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class IsGalaxyCpuLoggingControlUniquePDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsGalaxyCpuLoggingControlUniquePDSA class
    /// </summary>
    public IsGalaxyCpuLoggingControlUniquePDSA() : base()
    {
      ClassName = "IsGalaxyCpuLoggingControlUniquePDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of IsGalaxyCpuLoggingControlUniquePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class IsGalaxyCpuLoggingControlUniquePDSACollection : List<IsGalaxyCpuLoggingControlUniquePDSA>
  {
    
    /// <summary>
    /// Get all IsGalaxyCpuLoggingControlUniquePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of IsGalaxyCpuLoggingControlUniquePDSA Objects</returns>
    public List<IsGalaxyCpuLoggingControlUniquePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<IsGalaxyCpuLoggingControlUniquePDSA>();
    }
        
    /// <summary>
    /// Get all IsGalaxyCpuLoggingControlUniquePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of IsGalaxyCpuLoggingControlUniquePDSA Objects where IsSelected=True</returns>
    public List<IsGalaxyCpuLoggingControlUniquePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<IsGalaxyCpuLoggingControlUniquePDSA>();
    }

  }
}
