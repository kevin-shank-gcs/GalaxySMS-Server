using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessPortalPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class AccessPortalPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessPortalPDSA class
    /// </summary>
    public AccessPortalPDSA() : base()
    {
      ClassName = "AccessPortalPDSA";
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
      ret += "PortalName: " + PortalName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AccessPortalPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class AccessPortalPDSACollection : List<AccessPortalPDSA>
  {
    /// <summary>
    /// Find a AccessPortalPDSA object
    /// </summary>
    /// <param name="accessPortalUid">The Access Portal Uid to find</param>
    /// <returns>A AccessPortalPDSA object</returns>
    public AccessPortalPDSA GetAccessPortalPDSA(Guid accessPortalUid)
    {
      return Find(x => x.AccessPortalUid == accessPortalUid);
    }
    
    /// <summary>
    /// Get all AccessPortalPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessPortalPDSA Objects</returns>
    public List<AccessPortalPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessPortalPDSA>();
    }
        
    /// <summary>
    /// Get all AccessPortalPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessPortalPDSA Objects where IsSelected=True</returns>
    public List<AccessPortalPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessPortalPDSA>();
    }

  }
}
