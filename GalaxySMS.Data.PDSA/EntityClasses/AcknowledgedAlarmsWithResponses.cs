using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AcknowledgedAlarmsWithResponsesPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class AcknowledgedAlarmsWithResponsesPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AcknowledgedAlarmsWithResponsesPDSA class
    /// </summary>
    public AcknowledgedAlarmsWithResponsesPDSA() : base()
    {
      ClassName = "AcknowledgedAlarmsWithResponsesPDSA";
    }
    #endregion

  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AcknowledgedAlarmsWithResponsesPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AcknowledgedAlarmsWithResponsesPDSACollection : List<AcknowledgedAlarmsWithResponsesPDSA>
  {
    
    /// <summary>
    /// Get all AcknowledgedAlarmsWithResponsesPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AcknowledgedAlarmsWithResponsesPDSA Objects</returns>
    public List<AcknowledgedAlarmsWithResponsesPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AcknowledgedAlarmsWithResponsesPDSA>();
    }
        
    /// <summary>
    /// Get all AcknowledgedAlarmsWithResponsesPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AcknowledgedAlarmsWithResponsesPDSA Objects where IsSelected=True</returns>
    public List<AcknowledgedAlarmsWithResponsesPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AcknowledgedAlarmsWithResponsesPDSA>();
    }

  }
}
