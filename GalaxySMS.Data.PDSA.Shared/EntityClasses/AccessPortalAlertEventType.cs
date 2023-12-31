using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortalAlertEventTypePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class AccessPortalAlertEventTypePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortalAlertEventTypePDSA class
    /// </summary>
    public AccessPortalAlertEventTypePDSA() : base()
    {
      ClassName = "AccessPortalAlertEventTypePDSA";
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

      ret += "AccessPortalAlertEventTypeUid: " + AccessPortalAlertEventTypeUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortalAlertEventTypePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class AccessPortalAlertEventTypePDSACollection : List<AccessPortalAlertEventTypePDSA>
  {
    /// <summary>
    /// Find a AccessPortalAlertEventTypePDSA object
    /// </summary>
    /// <param name="accessPortalAlertEventTypeUid">The Access Portal Alert Event Type Uid to find</param>
    /// <returns>A AccessPortalAlertEventTypePDSA object</returns>
    public AccessPortalAlertEventTypePDSA GetAccessPortalAlertEventTypePDSA(Guid accessPortalAlertEventTypeUid)
    {
      return Find(x => x.AccessPortalAlertEventTypeUid == accessPortalAlertEventTypeUid);
    }
    
    /// <summary>
    /// Get all AccessPortalAlertEventTypePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortalAlertEventTypePDSA Objects</returns>
    public List<AccessPortalAlertEventTypePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortalAlertEventTypePDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortalAlertEventTypePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortalAlertEventTypePDSA Objects where IsSelected=True</returns>
    public List<AccessPortalAlertEventTypePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortalAlertEventTypePDSA>();
    }

  }
}
