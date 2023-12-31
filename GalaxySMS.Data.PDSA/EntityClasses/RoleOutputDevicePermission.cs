using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the RoleOutputDevicePermissionPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class RoleOutputDevicePermissionPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the RoleOutputDevicePermissionPDSA class
    /// </summary>
    public RoleOutputDevicePermissionPDSA() : base()
    {
      ClassName = "RoleOutputDevicePermissionPDSA";
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

      ret += "RoleOutputDevicePermissionUid: " + RoleOutputDevicePermissionUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of RoleOutputDevicePermissionPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class RoleOutputDevicePermissionPDSACollection : List<RoleOutputDevicePermissionPDSA>
  {
    /// <summary>
    /// Find a RoleOutputDevicePermissionPDSA object
    /// </summary>
    /// <param name="roleOutputDevicePermissionUid">The Role Output Device Permission Uid to find</param>
    /// <returns>A RoleOutputDevicePermissionPDSA object</returns>
    public RoleOutputDevicePermissionPDSA GetRoleOutputDevicePermissionPDSA(Guid roleOutputDevicePermissionUid)
    {
      return Find(x => x.RoleOutputDevicePermissionUid == roleOutputDevicePermissionUid);
    }
    
    /// <summary>
    /// Get all RoleOutputDevicePermissionPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of RoleOutputDevicePermissionPDSA Objects</returns>
    public List<RoleOutputDevicePermissionPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<RoleOutputDevicePermissionPDSA>();
    }
        
    /// <summary>
    /// Get all RoleOutputDevicePermissionPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of RoleOutputDevicePermissionPDSA Objects where IsSelected=True</returns>
    public List<RoleOutputDevicePermissionPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<RoleOutputDevicePermissionPDSA>();
    }

  }
}
