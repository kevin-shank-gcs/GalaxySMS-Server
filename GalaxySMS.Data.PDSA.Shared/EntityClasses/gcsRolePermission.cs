using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcsRolePermissionPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class gcsRolePermissionPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcsRolePermissionPDSA class
    /// </summary>
    public gcsRolePermissionPDSA() : base()
    {
      ClassName = "gcsRolePermissionPDSA";
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

      ret += "RolePermissionId: " + RolePermissionId.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of gcsRolePermissionPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcsRolePermissionPDSACollection : List<gcsRolePermissionPDSA>
  {
    /// <summary>
    /// Find a gcsRolePermissionPDSA object
    /// </summary>
    /// <param name="rolePermissionId">The Role Permission Id to find</param>
    /// <returns>A gcsRolePermissionPDSA object</returns>
    public gcsRolePermissionPDSA GetgcsRolePermissionPDSA(Guid rolePermissionId)
    {
#if SILVERLIGHT
      return this.First(x => x.RolePermissionId == rolePermissionId);
#else
      return Find(x => x.RolePermissionId == rolePermissionId);
#endif
    }
    
    /// <summary>
    /// Get all gcsRolePermissionPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcsRolePermissionPDSA Objects</returns>
    public List<gcsRolePermissionPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcsRolePermissionPDSA>();
    }
        
    /// <summary>
    /// Get all gcsRolePermissionPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcsRolePermissionPDSA Objects where IsSelected=True</returns>
    public List<gcsRolePermissionPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcsRolePermissionPDSA>();
    }

  }
}
