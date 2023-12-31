using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the RoleAccessPortalPermissionPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class RoleAccessPortalPermissionPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the RoleAccessPortalPermissionPDSA class
    /// </summary>
    public RoleAccessPortalPermissionPDSA() : base()
    {
      ClassName = "RoleAccessPortalPermissionPDSA";
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

      ret += "RoleAccessPortalPermissionUid: " + RoleAccessPortalPermissionUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of RoleAccessPortalPermissionPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class RoleAccessPortalPermissionPDSACollection : List<RoleAccessPortalPermissionPDSA>
  {
    /// <summary>
    /// Find a RoleAccessPortalPermissionPDSA object
    /// </summary>
    /// <param name="roleAccessPortalPermissionUid">The Role Access Portal Permission Uid to find</param>
    /// <returns>A RoleAccessPortalPermissionPDSA object</returns>
    public RoleAccessPortalPermissionPDSA GetRoleAccessPortalPermissionPDSA(Guid roleAccessPortalPermissionUid)
    {
      return Find(x => x.RoleAccessPortalPermissionUid == roleAccessPortalPermissionUid);
    }
    
    /// <summary>
    /// Get all RoleAccessPortalPermissionPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of RoleAccessPortalPermissionPDSA Objects</returns>
    public List<RoleAccessPortalPermissionPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<RoleAccessPortalPermissionPDSA>();
    }
        
    /// <summary>
    /// Get all RoleAccessPortalPermissionPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of RoleAccessPortalPermissionPDSA Objects where IsSelected=True</returns>
    public List<RoleAccessPortalPermissionPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<RoleAccessPortalPermissionPDSA>();
    }

  }
}
