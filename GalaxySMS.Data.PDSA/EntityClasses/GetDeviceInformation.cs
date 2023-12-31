using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GetDeviceInformationPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class GetDeviceInformationPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GetDeviceInformationPDSA class
    /// </summary>
    public GetDeviceInformationPDSA() : base()
    {
      ClassName = "GetDeviceInformationPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of GetDeviceInformationPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GetDeviceInformationPDSACollection : List<GetDeviceInformationPDSA>
  {
    
    /// <summary>
    /// Get all GetDeviceInformationPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GetDeviceInformationPDSA Objects</returns>
    public List<GetDeviceInformationPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GetDeviceInformationPDSA>();
    }
        
    /// <summary>
    /// Get all GetDeviceInformationPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GetDeviceInformationPDSA Objects where IsSelected=True</returns>
    public List<GetDeviceInformationPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GetDeviceInformationPDSA>();
    }

  }
}
