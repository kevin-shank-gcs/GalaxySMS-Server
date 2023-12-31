using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputDeviceActivityAlarmEventPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class InputDeviceActivityAlarmEventPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputDeviceActivityAlarmEventPDSA class
    /// </summary>
    public InputDeviceActivityAlarmEventPDSA() : base()
    {
      ClassName = "InputDeviceActivityAlarmEventPDSA";
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

      ret += "InputDeviceActivityEventUid: " + InputDeviceActivityEventUid.ToString() + " / ";
      ret += "InputDeviceActivityEventUid: " + InputDeviceActivityEventUid.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of InputDeviceActivityAlarmEventPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputDeviceActivityAlarmEventPDSACollection : List<InputDeviceActivityAlarmEventPDSA>
  {
    /// <summary>
    /// Find a InputDeviceActivityAlarmEventPDSA object
    /// </summary>
    /// <param name="inputDeviceActivityEventUid">The Input Device Activity Event Uid to find</param>
    /// <returns>A InputDeviceActivityAlarmEventPDSA object</returns>
    public InputDeviceActivityAlarmEventPDSA GetInputDeviceActivityAlarmEventPDSA(Guid inputDeviceActivityEventUid)
    {
      return Find(x => x.InputDeviceActivityEventUid == inputDeviceActivityEventUid);
    }
    
    /// <summary>
    /// Get all InputDeviceActivityAlarmEventPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputDeviceActivityAlarmEventPDSA Objects</returns>
    public List<InputDeviceActivityAlarmEventPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputDeviceActivityAlarmEventPDSA>();
    }
        
    /// <summary>
    /// Get all InputDeviceActivityAlarmEventPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputDeviceActivityAlarmEventPDSA Objects where IsSelected=True</returns>
    public List<InputDeviceActivityAlarmEventPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputDeviceActivityAlarmEventPDSA>();
    }

  }
}
