using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the RegionEntityMapPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class RegionEntityMapPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the RegionEntityMapPDSA class
    /// </summary>
    public RegionEntityMapPDSA() : base()
    {
      ClassName = "RegionEntityMapPDSA";
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

      ret += "RegionEntityMapUid: " + RegionEntityMapUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of RegionEntityMapPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class RegionEntityMapPDSACollection : List<RegionEntityMapPDSA>
  {
    /// <summary>
    /// Find a RegionEntityMapPDSA object
    /// </summary>
    /// <param name="regionEntityMapUid">The Region Entity Map Uid to find</param>
    /// <returns>A RegionEntityMapPDSA object</returns>
    public RegionEntityMapPDSA GetRegionEntityMapPDSA(Guid regionEntityMapUid)
    {
      return Find(x => x.RegionEntityMapUid == regionEntityMapUid);
    }
    
    /// <summary>
    /// Get all RegionEntityMapPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of RegionEntityMapPDSA Objects</returns>
    public List<RegionEntityMapPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<RegionEntityMapPDSA>();
    }
        
    /// <summary>
    /// Get all RegionEntityMapPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of RegionEntityMapPDSA Objects where IsSelected=True</returns>
    public List<RegionEntityMapPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<RegionEntityMapPDSA>();
    }

  }
}
