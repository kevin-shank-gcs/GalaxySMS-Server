using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the InputDeviceAlarmEventAcknowledgmentPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class InputDeviceAlarmEventAcknowledgmentPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the InputDeviceAlarmEventAcknowledgmentPDSA class
    /// </summary>
    public InputDeviceAlarmEventAcknowledgmentPDSA() : base()
    {
      ClassName = "InputDeviceAlarmEventAcknowledgmentPDSA";
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

      ret += "InputDeviceAlarmEventAcknowledgmentUid: " + InputDeviceAlarmEventAcknowledgmentUid.ToString() + " / ";
      ret += "Response: " + Response.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of InputDeviceAlarmEventAcknowledgmentPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class InputDeviceAlarmEventAcknowledgmentPDSACollection : List<InputDeviceAlarmEventAcknowledgmentPDSA>
  {
    /// <summary>
    /// Find a InputDeviceAlarmEventAcknowledgmentPDSA object
    /// </summary>
    /// <param name="inputDeviceAlarmEventAcknowledgmentUid">The Input Device Alarm Event Acknowledgment Uid to find</param>
    /// <returns>A InputDeviceAlarmEventAcknowledgmentPDSA object</returns>
    public InputDeviceAlarmEventAcknowledgmentPDSA GetInputDeviceAlarmEventAcknowledgmentPDSA(Guid inputDeviceAlarmEventAcknowledgmentUid)
    {
      return Find(x => x.InputDeviceAlarmEventAcknowledgmentUid == inputDeviceAlarmEventAcknowledgmentUid);
    }
    
    /// <summary>
    /// Get all InputDeviceAlarmEventAcknowledgmentPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of InputDeviceAlarmEventAcknowledgmentPDSA Objects</returns>
    public List<InputDeviceAlarmEventAcknowledgmentPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<InputDeviceAlarmEventAcknowledgmentPDSA>();
    }
        
    /// <summary>
    /// Get all InputDeviceAlarmEventAcknowledgmentPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of InputDeviceAlarmEventAcknowledgmentPDSA Objects where IsSelected=True</returns>
    public List<InputDeviceAlarmEventAcknowledgmentPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<InputDeviceAlarmEventAcknowledgmentPDSA>();
    }

  }
}
