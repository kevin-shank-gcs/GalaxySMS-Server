using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyInterfaceBoardSectionNodePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class GalaxyInterfaceBoardSectionNodePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyInterfaceBoardSectionNodePDSA class
    /// </summary>
    public GalaxyInterfaceBoardSectionNodePDSA() : base()
    {
      ClassName = "GalaxyInterfaceBoardSectionNodePDSA";
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

      ret += "GalaxyInterfaceBoardSectionNodeUid: " + GalaxyInterfaceBoardSectionNodeUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyInterfaceBoardSectionNodePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyInterfaceBoardSectionNodePDSACollection : List<GalaxyInterfaceBoardSectionNodePDSA>
  {
    /// <summary>
    /// Find a GalaxyInterfaceBoardSectionNodePDSA object
    /// </summary>
    /// <param name="galaxyInterfaceBoardSectionNodeUid">The Galaxy Interface Board Section Node Uid to find</param>
    /// <returns>A GalaxyInterfaceBoardSectionNodePDSA object</returns>
    public GalaxyInterfaceBoardSectionNodePDSA GetGalaxyInterfaceBoardSectionNodePDSA(Guid galaxyInterfaceBoardSectionNodeUid)
    {
      return Find(x => x.GalaxyInterfaceBoardSectionNodeUid == galaxyInterfaceBoardSectionNodeUid);
    }
    
    /// <summary>
    /// Get all GalaxyInterfaceBoardSectionNodePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSectionNodePDSA Objects</returns>
    public List<GalaxyInterfaceBoardSectionNodePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyInterfaceBoardSectionNodePDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyInterfaceBoardSectionNodePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSectionNodePDSA Objects where IsSelected=True</returns>
    public List<GalaxyInterfaceBoardSectionNodePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyInterfaceBoardSectionNodePDSA>();
    }

  }
}
