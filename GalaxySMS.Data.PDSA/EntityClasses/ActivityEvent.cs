using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the ActivityEventPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class ActivityEventPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the ActivityEventPDSA class
    /// </summary>
    public ActivityEventPDSA() : base()
    {
      ClassName = "ActivityEventPDSA";
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

      ret += "ActivityEventUid: " + ActivityEventUid.ToString() + " / ";
      ret += "ActivityDateTime: " + ActivityDateTime.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of ActivityEventPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class ActivityEventPDSACollection : List<ActivityEventPDSA>
  {
    /// <summary>
    /// Find a ActivityEventPDSA object
    /// </summary>
    /// <param name="activityEventUid">The Activity Event Uid to find</param>
    /// <returns>A ActivityEventPDSA object</returns>
    public ActivityEventPDSA GetActivityEventPDSA(Guid activityEventUid)
    {
      return Find(x => x.ActivityEventUid == activityEventUid);
    }
    
    /// <summary>
    /// Get all ActivityEventPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of ActivityEventPDSA Objects</returns>
    public List<ActivityEventPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<ActivityEventPDSA>();
    }
        
    /// <summary>
    /// Get all ActivityEventPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of ActivityEventPDSA Objects where IsSelected=True</returns>
    public List<ActivityEventPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<ActivityEventPDSA>();
    }

  }
}
