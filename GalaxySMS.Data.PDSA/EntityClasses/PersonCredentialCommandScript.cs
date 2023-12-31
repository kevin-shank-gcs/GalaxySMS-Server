using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonCredentialCommandScriptPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonCredentialCommandScriptPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonCredentialCommandScriptPDSA class
    /// </summary>
    public PersonCredentialCommandScriptPDSA() : base()
    {
      ClassName = "PersonCredentialCommandScriptPDSA";
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

      ret += "PersonCredentialCommandScriptUid: " + PersonCredentialCommandScriptUid.ToString() + " / ";
      ret += "DelayTime: " + DelayTime.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonCredentialCommandScriptPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonCredentialCommandScriptPDSACollection : List<PersonCredentialCommandScriptPDSA>
  {
    /// <summary>
    /// Find a PersonCredentialCommandScriptPDSA object
    /// </summary>
    /// <param name="personCredentialCommandScriptUid">The Person Credential Command Script Uid to find</param>
    /// <returns>A PersonCredentialCommandScriptPDSA object</returns>
    public PersonCredentialCommandScriptPDSA GetPersonCredentialCommandScriptPDSA(Guid personCredentialCommandScriptUid)
    {
      return Find(x => x.PersonCredentialCommandScriptUid == personCredentialCommandScriptUid);
    }
    
    /// <summary>
    /// Get all PersonCredentialCommandScriptPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonCredentialCommandScriptPDSA Objects</returns>
    public List<PersonCredentialCommandScriptPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonCredentialCommandScriptPDSA>();
    }
        
    /// <summary>
    /// Get all PersonCredentialCommandScriptPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonCredentialCommandScriptPDSA Objects where IsSelected=True</returns>
    public List<PersonCredentialCommandScriptPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonCredentialCommandScriptPDSA>();
    }

  }
}
