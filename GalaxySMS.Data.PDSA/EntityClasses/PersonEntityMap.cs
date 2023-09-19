using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonEntityMapPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonEntityMapPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonEntityMapPDSA class
    /// </summary>
    public PersonEntityMapPDSA() : base()
    {
      ClassName = "PersonEntityMapPDSA";
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

      ret += "PersonEntityMapUid: " + PersonEntityMapUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonEntityMapPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonEntityMapPDSACollection : List<PersonEntityMapPDSA>
  {
    /// <summary>
    /// Find a PersonEntityMapPDSA object
    /// </summary>
    /// <param name="personEntityMapUid">The Person Entity Map Uid to find</param>
    /// <returns>A PersonEntityMapPDSA object</returns>
    public PersonEntityMapPDSA GetPersonEntityMapPDSA(Guid personEntityMapUid)
    {
      return Find(x => x.PersonEntityMapUid == personEntityMapUid);
    }
    
    /// <summary>
    /// Get all PersonEntityMapPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonEntityMapPDSA Objects</returns>
    public List<PersonEntityMapPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonEntityMapPDSA>();
    }
        
    /// <summary>
    /// Get all PersonEntityMapPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonEntityMapPDSA Objects where IsSelected=True</returns>
    public List<PersonEntityMapPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonEntityMapPDSA>();
    }

  }
}
