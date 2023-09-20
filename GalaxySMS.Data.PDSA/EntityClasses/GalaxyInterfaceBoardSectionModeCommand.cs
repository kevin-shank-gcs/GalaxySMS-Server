using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyInterfaceBoardSectionModeCommandPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class GalaxyInterfaceBoardSectionModeCommandPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyInterfaceBoardSectionModeCommandPDSA class
    /// </summary>
    public GalaxyInterfaceBoardSectionModeCommandPDSA() : base()
    {
      ClassName = "GalaxyInterfaceBoardSectionModeCommandPDSA";
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

      ret += "GalaxyInterfaceBoardSectionModeCommandUid: " + GalaxyInterfaceBoardSectionModeCommandUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyInterfaceBoardSectionModeCommandPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyInterfaceBoardSectionModeCommandPDSACollection : List<GalaxyInterfaceBoardSectionModeCommandPDSA>
  {
    /// <summary>
    /// Find a GalaxyInterfaceBoardSectionModeCommandPDSA object
    /// </summary>
    /// <param name="galaxyInterfaceBoardSectionModeCommandUid">The Galaxy Interface Board Section Mode Command Uid to find</param>
    /// <returns>A GalaxyInterfaceBoardSectionModeCommandPDSA object</returns>
    public GalaxyInterfaceBoardSectionModeCommandPDSA GetGalaxyInterfaceBoardSectionModeCommandPDSA(Guid galaxyInterfaceBoardSectionModeCommandUid)
    {
      return Find(x => x.GalaxyInterfaceBoardSectionModeCommandUid == galaxyInterfaceBoardSectionModeCommandUid);
    }
    
    /// <summary>
    /// Get all GalaxyInterfaceBoardSectionModeCommandPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSectionModeCommandPDSA Objects</returns>
    public List<GalaxyInterfaceBoardSectionModeCommandPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyInterfaceBoardSectionModeCommandPDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyInterfaceBoardSectionModeCommandPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSectionModeCommandPDSA Objects where IsSelected=True</returns>
    public List<GalaxyInterfaceBoardSectionModeCommandPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyInterfaceBoardSectionModeCommandPDSA>();
    }

  }
}
