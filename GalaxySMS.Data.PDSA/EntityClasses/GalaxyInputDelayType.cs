using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyInputDelayTypePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class GalaxyInputDelayTypePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyInputDelayTypePDSA class
    /// </summary>
    public GalaxyInputDelayTypePDSA() : base()
    {
      ClassName = "GalaxyInputDelayTypePDSA";
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

      ret += "GalaxyInputDelayTypeUid: " + GalaxyInputDelayTypeUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyInputDelayTypePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class GalaxyInputDelayTypePDSACollection : List<GalaxyInputDelayTypePDSA>
  {
    /// <summary>
    /// Find a GalaxyInputDelayTypePDSA object
    /// </summary>
    /// <param name="galaxyInputDelayTypeUid">The Galaxy Input Delay Type Uid to find</param>
    /// <returns>A GalaxyInputDelayTypePDSA object</returns>
    public GalaxyInputDelayTypePDSA GetGalaxyInputDelayTypePDSA(Guid galaxyInputDelayTypeUid)
    {
      return Find(x => x.GalaxyInputDelayTypeUid == galaxyInputDelayTypeUid);
    }
    
    /// <summary>
    /// Get all GalaxyInputDelayTypePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyInputDelayTypePDSA Objects</returns>
    public List<GalaxyInputDelayTypePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyInputDelayTypePDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyInputDelayTypePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyInputDelayTypePDSA Objects where IsSelected=True</returns>
    public List<GalaxyInputDelayTypePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyInputDelayTypePDSA>();
    }

  }
}
