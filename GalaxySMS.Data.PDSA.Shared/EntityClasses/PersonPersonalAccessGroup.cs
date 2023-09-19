using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonPersonalAccessGroupPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonPersonalAccessGroupPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonPersonalAccessGroupPDSA class
    /// </summary>
    public PersonPersonalAccessGroupPDSA() : base()
    {
      ClassName = "PersonPersonalAccessGroupPDSA";
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

      ret += "PersonClusterPermissionUid: " + PersonClusterPermissionUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonPersonalAccessGroupPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonPersonalAccessGroupPDSACollection : List<PersonPersonalAccessGroupPDSA>
  {
    /// <summary>
    /// Find a PersonPersonalAccessGroupPDSA object
    /// </summary>
    /// <param name="personClusterPermissionUid">The Person Cluster Permission Uid to find</param>
    /// <returns>A PersonPersonalAccessGroupPDSA object</returns>
    public PersonPersonalAccessGroupPDSA GetPersonPersonalAccessGroupPDSA(Guid personClusterPermissionUid)
    {
      return Find(x => x.PersonClusterPermissionUid == personClusterPermissionUid);
    }
    
    /// <summary>
    /// Get all PersonPersonalAccessGroupPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonPersonalAccessGroupPDSA Objects</returns>
    public List<PersonPersonalAccessGroupPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonPersonalAccessGroupPDSA>();
    }
        
    /// <summary>
    /// Get all PersonPersonalAccessGroupPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonPersonalAccessGroupPDSA Objects where IsSelected=True</returns>
    public List<PersonPersonalAccessGroupPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonPersonalAccessGroupPDSA>();
    }

  }
}
