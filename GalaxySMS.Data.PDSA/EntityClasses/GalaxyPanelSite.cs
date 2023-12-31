using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyPanelSitePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class GalaxyPanelSitePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyPanelSitePDSA class
    /// </summary>
    public GalaxyPanelSitePDSA() : base()
    {
      ClassName = "GalaxyPanelSitePDSA";
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

      ret += "GalaxyPanelSiteUid: " + GalaxyPanelSiteUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyPanelSitePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class GalaxyPanelSitePDSACollection : List<GalaxyPanelSitePDSA>
  {
    /// <summary>
    /// Find a GalaxyPanelSitePDSA object
    /// </summary>
    /// <param name="galaxyPanelSiteUid">The Galaxy Panel Site Uid to find</param>
    /// <returns>A GalaxyPanelSitePDSA object</returns>
    public GalaxyPanelSitePDSA GetGalaxyPanelSitePDSA(Guid galaxyPanelSiteUid)
    {
      return Find(x => x.GalaxyPanelSiteUid == galaxyPanelSiteUid);
    }
    
    /// <summary>
    /// Get all GalaxyPanelSitePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyPanelSitePDSA Objects</returns>
    public List<GalaxyPanelSitePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyPanelSitePDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyPanelSitePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyPanelSitePDSA Objects where IsSelected=True</returns>
    public List<GalaxyPanelSitePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyPanelSitePDSA>();
    }

  }
}
