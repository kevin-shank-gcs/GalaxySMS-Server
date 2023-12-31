using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the DateTypeEntityMapPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class DateTypeEntityMapPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the DateTypeEntityMapPDSA class
    /// </summary>
    public DateTypeEntityMapPDSA() : base()
    {
      ClassName = "DateTypeEntityMapPDSA";
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

      ret += "DateTypeEntityMapUid: " + DateTypeEntityMapUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of DateTypeEntityMapPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class DateTypeEntityMapPDSACollection : List<DateTypeEntityMapPDSA>
  {
    /// <summary>
    /// Find a DateTypeEntityMapPDSA object
    /// </summary>
    /// <param name="dateTypeEntityMapUid">The Date Type Entity Map Uid to find</param>
    /// <returns>A DateTypeEntityMapPDSA object</returns>
    public DateTypeEntityMapPDSA GetDateTypeEntityMapPDSA(Guid dateTypeEntityMapUid)
    {
      return Find(x => x.DateTypeEntityMapUid == dateTypeEntityMapUid);
    }
    
    /// <summary>
    /// Get all DateTypeEntityMapPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of DateTypeEntityMapPDSA Objects</returns>
    public List<DateTypeEntityMapPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<DateTypeEntityMapPDSA>();
    }
        
    /// <summary>
    /// Get all DateTypeEntityMapPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of DateTypeEntityMapPDSA Objects where IsSelected=True</returns>
    public List<DateTypeEntityMapPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<DateTypeEntityMapPDSA>();
    }

  }
}
