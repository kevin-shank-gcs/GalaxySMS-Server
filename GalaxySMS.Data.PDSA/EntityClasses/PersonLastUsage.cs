using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonLastUsagePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonLastUsagePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonLastUsagePDSA class
    /// </summary>
    public PersonLastUsagePDSA() : base()
    {
      ClassName = "PersonLastUsagePDSA";
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

      ret += "PersonUid: " + PersonUid.ToString() + " / ";
      ret += "PersonUid: " + PersonUid.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonLastUsagePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonLastUsagePDSACollection : List<PersonLastUsagePDSA>
  {
    /// <summary>
    /// Find a PersonLastUsagePDSA object
    /// </summary>
    /// <param name="personUid">The Person Uid to find</param>
    /// <returns>A PersonLastUsagePDSA object</returns>
    public PersonLastUsagePDSA GetPersonLastUsagePDSA(Guid personUid)
    {
      return Find(x => x.PersonUid == personUid);
    }
    
    /// <summary>
    /// Get all PersonLastUsagePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonLastUsagePDSA Objects</returns>
    public List<PersonLastUsagePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonLastUsagePDSA>();
    }
        
    /// <summary>
    /// Get all PersonLastUsagePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonLastUsagePDSA Objects where IsSelected=True</returns>
    public List<PersonLastUsagePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonLastUsagePDSA>();
    }

  }
}
