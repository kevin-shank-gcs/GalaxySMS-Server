using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortalAlarmEventAcknowledgmentPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class AccessPortalAlarmEventAcknowledgmentPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortalAlarmEventAcknowledgmentPDSA class
    /// </summary>
    public AccessPortalAlarmEventAcknowledgmentPDSA() : base()
    {
      ClassName = "AccessPortalAlarmEventAcknowledgmentPDSA";
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

      ret += "AccessPortalAlarmEventAcknowledgmentUid: " + AccessPortalAlarmEventAcknowledgmentUid.ToString() + " / ";
      ret += "Response: " + Response.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortalAlarmEventAcknowledgmentPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortalAlarmEventAcknowledgmentPDSACollection : List<AccessPortalAlarmEventAcknowledgmentPDSA>
  {
    /// <summary>
    /// Find a AccessPortalAlarmEventAcknowledgmentPDSA object
    /// </summary>
    /// <param name="accessPortalAlarmEventAcknowledgmentUid">The Access Portal Alarm Event Acknowledgment Uid to find</param>
    /// <returns>A AccessPortalAlarmEventAcknowledgmentPDSA object</returns>
    public AccessPortalAlarmEventAcknowledgmentPDSA GetAccessPortalAlarmEventAcknowledgmentPDSA(Guid accessPortalAlarmEventAcknowledgmentUid)
    {
      return Find(x => x.AccessPortalAlarmEventAcknowledgmentUid == accessPortalAlarmEventAcknowledgmentUid);
    }
    
    /// <summary>
    /// Get all AccessPortalAlarmEventAcknowledgmentPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortalAlarmEventAcknowledgmentPDSA Objects</returns>
    public List<AccessPortalAlarmEventAcknowledgmentPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortalAlarmEventAcknowledgmentPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortalAlarmEventAcknowledgmentPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortalAlarmEventAcknowledgmentPDSA Objects where IsSelected=True</returns>
    public List<AccessPortalAlarmEventAcknowledgmentPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortalAlarmEventAcknowledgmentPDSA>();
    }

  }
}
