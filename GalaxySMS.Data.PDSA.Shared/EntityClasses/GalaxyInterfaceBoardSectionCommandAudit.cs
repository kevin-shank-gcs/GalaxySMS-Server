using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the GalaxyInterfaceBoardSectionCommandAuditPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class GalaxyInterfaceBoardSectionCommandAuditPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the GalaxyInterfaceBoardSectionCommandAuditPDSA class
    /// </summary>
    public GalaxyInterfaceBoardSectionCommandAuditPDSA() : base()
    {
      ClassName = "GalaxyInterfaceBoardSectionCommandAuditPDSA";
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

      ret += "GalaxyInterfaceBoardSectionCommandAuditUid: " + GalaxyInterfaceBoardSectionCommandAuditUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of GalaxyInterfaceBoardSectionCommandAuditPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class GalaxyInterfaceBoardSectionCommandAuditPDSACollection : List<GalaxyInterfaceBoardSectionCommandAuditPDSA>
  {
    /// <summary>
    /// Find a GalaxyInterfaceBoardSectionCommandAuditPDSA object
    /// </summary>
    /// <param name="galaxyInterfaceBoardSectionCommandAuditUid">The Galaxy Interface Board Section Command Audit Uid to find</param>
    /// <returns>A GalaxyInterfaceBoardSectionCommandAuditPDSA object</returns>
    public GalaxyInterfaceBoardSectionCommandAuditPDSA GetGalaxyInterfaceBoardSectionCommandAuditPDSA(Guid galaxyInterfaceBoardSectionCommandAuditUid)
    {
      return Find(x => x.GalaxyInterfaceBoardSectionCommandAuditUid == galaxyInterfaceBoardSectionCommandAuditUid);
    }
    
    /// <summary>
    /// Get all GalaxyInterfaceBoardSectionCommandAuditPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSectionCommandAuditPDSA Objects</returns>
    public List<GalaxyInterfaceBoardSectionCommandAuditPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<GalaxyInterfaceBoardSectionCommandAuditPDSA>();
    }
        
    /// <summary>
    /// Get all GalaxyInterfaceBoardSectionCommandAuditPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of GalaxyInterfaceBoardSectionCommandAuditPDSA Objects where IsSelected=True</returns>
    public List<GalaxyInterfaceBoardSectionCommandAuditPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<GalaxyInterfaceBoardSectionCommandAuditPDSA>();
    }

  }
}
