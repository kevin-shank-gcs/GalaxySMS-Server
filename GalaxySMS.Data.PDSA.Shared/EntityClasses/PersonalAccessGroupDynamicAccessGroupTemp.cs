using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonalAccessGroupDynamicAccessGroupTempPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonalAccessGroupDynamicAccessGroupTempPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonalAccessGroupDynamicAccessGroupTempPDSA class
    /// </summary>
    public PersonalAccessGroupDynamicAccessGroupTempPDSA() : base()
    {
      ClassName = "PersonalAccessGroupDynamicAccessGroupTempPDSA";
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

      ret += "PersonalAccessGroupDynamicAccessGroupUid: " + PersonalAccessGroupDynamicAccessGroupUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonalAccessGroupDynamicAccessGroupTempPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonalAccessGroupDynamicAccessGroupTempPDSACollection : List<PersonalAccessGroupDynamicAccessGroupTempPDSA>
  {
    /// <summary>
    /// Find a PersonalAccessGroupDynamicAccessGroupTempPDSA object
    /// </summary>
    /// <param name="personalAccessGroupDynamicAccessGroupUid">The Personal Access Group Dynamic Access Group Uid to find</param>
    /// <returns>A PersonalAccessGroupDynamicAccessGroupTempPDSA object</returns>
    public PersonalAccessGroupDynamicAccessGroupTempPDSA GetPersonalAccessGroupDynamicAccessGroupTempPDSA(Guid personalAccessGroupDynamicAccessGroupUid)
    {
      return Find(x => x.PersonalAccessGroupDynamicAccessGroupUid == personalAccessGroupDynamicAccessGroupUid);
    }
    
    /// <summary>
    /// Get all PersonalAccessGroupDynamicAccessGroupTempPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonalAccessGroupDynamicAccessGroupTempPDSA Objects</returns>
    public List<PersonalAccessGroupDynamicAccessGroupTempPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonalAccessGroupDynamicAccessGroupTempPDSA>();
    }
        
    /// <summary>
    /// Get all PersonalAccessGroupDynamicAccessGroupTempPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonalAccessGroupDynamicAccessGroupTempPDSA Objects where IsSelected=True</returns>
    public List<PersonalAccessGroupDynamicAccessGroupTempPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonalAccessGroupDynamicAccessGroupTempPDSA>();
    }

  }
}
