using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortalAlertEventPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class AccessPortalAlertEventPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortalAlertEventPDSA class
    /// </summary>
    public AccessPortalAlertEventPDSA() : base()
    {
      ClassName = "AccessPortalAlertEventPDSA";
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

      ret += "AccessPortalAlertEventUid: " + AccessPortalAlertEventUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortalAlertEventPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class AccessPortalAlertEventPDSACollection : List<AccessPortalAlertEventPDSA>
  {
    /// <summary>
    /// Find a AccessPortalAlertEventPDSA object
    /// </summary>
    /// <param name="accessPortalAlertEventUid">The Access Portal Alert Event Uid to find</param>
    /// <returns>A AccessPortalAlertEventPDSA object</returns>
    public AccessPortalAlertEventPDSA GetAccessPortalAlertEventPDSA(Guid accessPortalAlertEventUid)
    {
      return Find(x => x.AccessPortalAlertEventUid == accessPortalAlertEventUid);
    }
    
    /// <summary>
    /// Get all AccessPortalAlertEventPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortalAlertEventPDSA Objects</returns>
    public List<AccessPortalAlertEventPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortalAlertEventPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortalAlertEventPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortalAlertEventPDSA Objects where IsSelected=True</returns>
    public List<AccessPortalAlertEventPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortalAlertEventPDSA>();
    }

  }
}
