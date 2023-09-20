using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputDeviceAlertEventTypePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class InputDeviceAlertEventTypePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputDeviceAlertEventTypePDSA class
    /// </summary>
    public InputDeviceAlertEventTypePDSA() : base()
    {
      ClassName = "InputDeviceAlertEventTypePDSA";
    }
    #endregion

    #region RETURNVALUE property for Stored Procs
    private long _RETURNVALUE;

    /// <summary>
    /// Get/Set the RETURNVALUE from a stored procedure
    /// If you do not use Stored Procedures, feel free to comment this out
    /// </summary>
    public long RETURNVALUE
    {
      get { return _RETURNVALUE; }
      set
      {
        if (_RETURNVALUE != value)
        {
          _RETURNVALUE = value;
          RaisePropertyChanged("RETURNVALUE");
        }
      }
    }
    #endregion
        
    #region Override of ToString()
    /// <summary>
    /// Override the ToString() to display fields and field values.
    /// This helps when viewing Collection classes in Visual Studio
    /// </summary>
    /// <returns>A string with data from this class</returns>
    public override string ToString()
    {
      string ret = string.Empty;

      ret += "InputDeviceAlertEventTypeUid: " + InputDeviceAlertEventTypeUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of InputDeviceAlertEventTypePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputDeviceAlertEventTypePDSACollection : List<InputDeviceAlertEventTypePDSA>
  {
    /// <summary>
    /// Find a InputDeviceAlertEventTypePDSA object
    /// </summary>
    /// <param name="inputDeviceAlertEventTypeUid">The Input Device Alert Event Type Uid to find</param>
    /// <returns>A InputDeviceAlertEventTypePDSA object</returns>
    public InputDeviceAlertEventTypePDSA GetInputDeviceAlertEventTypePDSA(Guid inputDeviceAlertEventTypeUid)
    {
      return Find(x => x.InputDeviceAlertEventTypeUid == inputDeviceAlertEventTypeUid);
    }
    
    /// <summary>
    /// Get all InputDeviceAlertEventTypePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputDeviceAlertEventTypePDSA Objects</returns>
    public List<InputDeviceAlertEventTypePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputDeviceAlertEventTypePDSA>();
    }
        
    /// <summary>
    /// Get all InputDeviceAlertEventTypePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputDeviceAlertEventTypePDSA Objects where IsSelected=True</returns>
    public List<InputDeviceAlertEventTypePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputDeviceAlertEventTypePDSA>();
    }

  }
}
