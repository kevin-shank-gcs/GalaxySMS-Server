using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyOutputDeviceInputSourcePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class GalaxyOutputDeviceInputSourcePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyOutputDeviceInputSourcePDSA class
    /// </summary>
    public GalaxyOutputDeviceInputSourcePDSA() : base()
    {
      ClassName = "GalaxyOutputDeviceInputSourcePDSA";
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

      ret += "GalaxyOutputDeviceInputSourceUid: " + GalaxyOutputDeviceInputSourceUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyOutputDeviceInputSourcePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyOutputDeviceInputSourcePDSACollection : List<GalaxyOutputDeviceInputSourcePDSA>
  {
    /// <summary>
    /// Find a GalaxyOutputDeviceInputSourcePDSA object
    /// </summary>
    /// <param name="galaxyOutputDeviceInputSourceUid">The Galaxy Output Device Input Source Uid to find</param>
    /// <returns>A GalaxyOutputDeviceInputSourcePDSA object</returns>
    public GalaxyOutputDeviceInputSourcePDSA GetGalaxyOutputDeviceInputSourcePDSA(Guid galaxyOutputDeviceInputSourceUid)
    {
      return Find(x => x.GalaxyOutputDeviceInputSourceUid == galaxyOutputDeviceInputSourceUid);
    }
    
    /// <summary>
    /// Get all GalaxyOutputDeviceInputSourcePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyOutputDeviceInputSourcePDSA Objects</returns>
    public List<GalaxyOutputDeviceInputSourcePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyOutputDeviceInputSourcePDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyOutputDeviceInputSourcePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyOutputDeviceInputSourcePDSA Objects where IsSelected=True</returns>
    public List<GalaxyOutputDeviceInputSourcePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyOutputDeviceInputSourcePDSA>();
    }

  }
}
