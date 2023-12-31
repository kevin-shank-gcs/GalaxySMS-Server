using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortalLastUsagePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class AccessPortalLastUsagePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortalLastUsagePDSA class
    /// </summary>
    public AccessPortalLastUsagePDSA() : base()
    {
      ClassName = "AccessPortalLastUsagePDSA";
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

      ret += "AccessPortalUid: " + AccessPortalUid.ToString() + " / ";
      ret += "AccessPortalUid: " + AccessPortalUid.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortalLastUsagePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortalLastUsagePDSACollection : List<AccessPortalLastUsagePDSA>
  {
    /// <summary>
    /// Find a AccessPortalLastUsagePDSA object
    /// </summary>
    /// <param name="accessPortalUid">The Access Portal Uid to find</param>
    /// <returns>A AccessPortalLastUsagePDSA object</returns>
    public AccessPortalLastUsagePDSA GetAccessPortalLastUsagePDSA(Guid accessPortalUid)
    {
      return Find(x => x.AccessPortalUid == accessPortalUid);
    }
    
    /// <summary>
    /// Get all AccessPortalLastUsagePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortalLastUsagePDSA Objects</returns>
    public List<AccessPortalLastUsagePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortalLastUsagePDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortalLastUsagePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortalLastUsagePDSA Objects where IsSelected=True</returns>
    public List<AccessPortalLastUsagePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortalLastUsagePDSA>();
    }

  }
}
