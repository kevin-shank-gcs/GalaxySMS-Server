using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonExpirationModePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonExpirationModePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonExpirationModePDSA class
    /// </summary>
    public PersonExpirationModePDSA() : base()
    {
      ClassName = "PersonExpirationModePDSA";
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

      ret += "PersonExpirationModeUid: " + PersonExpirationModeUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonExpirationModePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonExpirationModePDSACollection : List<PersonExpirationModePDSA>
  {
    /// <summary>
    /// Find a PersonExpirationModePDSA object
    /// </summary>
    /// <param name="personExpirationModeUid">The Person Expiration Mode Uid to find</param>
    /// <returns>A PersonExpirationModePDSA object</returns>
    public PersonExpirationModePDSA GetPersonExpirationModePDSA(Guid personExpirationModeUid)
    {
      return Find(x => x.PersonExpirationModeUid == personExpirationModeUid);
    }
    
    /// <summary>
    /// Get all PersonExpirationModePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonExpirationModePDSA Objects</returns>
    public List<PersonExpirationModePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonExpirationModePDSA>();
    }
        
    /// <summary>
    /// Get all PersonExpirationModePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonExpirationModePDSA Objects where IsSelected=True</returns>
    public List<PersonExpirationModePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonExpirationModePDSA>();
    }

  }
}
