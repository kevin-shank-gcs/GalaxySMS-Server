using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PersonLcdMessagePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PersonLcdMessagePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PersonLcdMessagePDSA class
    /// </summary>
    public PersonLcdMessagePDSA() : base()
    {
      ClassName = "PersonLcdMessagePDSA";
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

      ret += "PersonLcdMessageUid: " + PersonLcdMessageUid.ToString() + " / ";
      ret += "Message: " + Message.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PersonLcdMessagePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PersonLcdMessagePDSACollection : List<PersonLcdMessagePDSA>
  {
    /// <summary>
    /// Find a PersonLcdMessagePDSA object
    /// </summary>
    /// <param name="personLcdMessageUid">The Person Lcd Message Uid to find</param>
    /// <returns>A PersonLcdMessagePDSA object</returns>
    public PersonLcdMessagePDSA GetPersonLcdMessagePDSA(Guid personLcdMessageUid)
    {
      return Find(x => x.PersonLcdMessageUid == personLcdMessageUid);
    }
    
    /// <summary>
    /// Get all PersonLcdMessagePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PersonLcdMessagePDSA Objects</returns>
    public List<PersonLcdMessagePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PersonLcdMessagePDSA>();
    }
        
    /// <summary>
    /// Get all PersonLcdMessagePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PersonLcdMessagePDSA Objects where IsSelected=True</returns>
    public List<PersonLcdMessagePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PersonLcdMessagePDSA>();
    }

  }
}
