using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AccessGroupPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class AccessGroupPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AccessGroupPDSA class
    /// </summary>
    public AccessGroupPDSA() : base()
    {
      ClassName = "AccessGroupPDSA";
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

      ret += "AccessGroupUid: " + AccessGroupUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AccessGroupPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class AccessGroupPDSACollection : List<AccessGroupPDSA>
  {
    /// <summary>
    /// Find a AccessGroupPDSA object
    /// </summary>
    /// <param name="accessGroupUid">The Access Group Uid to find</param>
    /// <returns>A AccessGroupPDSA object</returns>
    public AccessGroupPDSA GetAccessGroupPDSA(Guid accessGroupUid)
    {
      return Find(x => x.AccessGroupUid == accessGroupUid);
    }
    
    /// <summary>
    /// Get all AccessGroupPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AccessGroupPDSA Objects</returns>
    public List<AccessGroupPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AccessGroupPDSA>();
    }
        
    /// <summary>
    /// Get all AccessGroupPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AccessGroupPDSA Objects where IsSelected=True</returns>
    public List<AccessGroupPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AccessGroupPDSA>();
    }

  }
}
