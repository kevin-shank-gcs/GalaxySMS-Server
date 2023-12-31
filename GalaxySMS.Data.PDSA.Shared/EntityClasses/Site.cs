using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the SitePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class SitePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the SitePDSA class
    /// </summary>
    public SitePDSA() : base()
    {
      ClassName = "SitePDSA";
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

      ret += "SiteUid: " + SiteUid.ToString() + " / ";
      ret += "SiteName: " + SiteName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of SitePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class SitePDSACollection : List<SitePDSA>
  {
    /// <summary>
    /// Find a SitePDSA object
    /// </summary>
    /// <param name="siteUid">The Site Uid to find</param>
    /// <returns>A SitePDSA object</returns>
    public SitePDSA GetSitePDSA(Guid siteUid)
    {
      return Find(x => x.SiteUid == siteUid);
    }
    
    /// <summary>
    /// Get all SitePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of SitePDSA Objects</returns>
    public List<SitePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<SitePDSA>();
    }
        
    /// <summary>
    /// Get all SitePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of SitePDSA Objects where IsSelected=True</returns>
    public List<SitePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<SitePDSA>();
    }

  }
}
