using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonLcdMessageDisplayModePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonLcdMessageDisplayModePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonLcdMessageDisplayModePDSA class
    /// </summary>
    public PersonLcdMessageDisplayModePDSA() : base()
    {
      ClassName = "PersonLcdMessageDisplayModePDSA";
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

      ret += "PersonLcdMessageDisplayModeUid: " + PersonLcdMessageDisplayModeUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonLcdMessageDisplayModePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonLcdMessageDisplayModePDSACollection : List<PersonLcdMessageDisplayModePDSA>
  {
    /// <summary>
    /// Find a PersonLcdMessageDisplayModePDSA object
    /// </summary>
    /// <param name="personLcdMessageDisplayModeUid">The Person Lcd Message Display Mode Uid to find</param>
    /// <returns>A PersonLcdMessageDisplayModePDSA object</returns>
    public PersonLcdMessageDisplayModePDSA GetPersonLcdMessageDisplayModePDSA(Guid personLcdMessageDisplayModeUid)
    {
      return Find(x => x.PersonLcdMessageDisplayModeUid == personLcdMessageDisplayModeUid);
    }
    
    /// <summary>
    /// Get all PersonLcdMessageDisplayModePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonLcdMessageDisplayModePDSA Objects</returns>
    public List<PersonLcdMessageDisplayModePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonLcdMessageDisplayModePDSA>();
    }
        
    /// <summary>
    /// Get all PersonLcdMessageDisplayModePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonLcdMessageDisplayModePDSA Objects where IsSelected=True</returns>
    public List<PersonLcdMessageDisplayModePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonLcdMessageDisplayModePDSA>();
    }

  }
}
