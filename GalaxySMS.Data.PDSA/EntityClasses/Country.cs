using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the CountryPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class CountryPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the CountryPDSA class
    /// </summary>
    public CountryPDSA() : base()
    {
      ClassName = "CountryPDSA";
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

      ret += "CountryUid: " + CountryUid.ToString() + " / ";
      ret += "CountryIso: " + CountryIso.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of CountryPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class CountryPDSACollection : List<CountryPDSA>
  {
    /// <summary>
    /// Find a CountryPDSA object
    /// </summary>
    /// <param name="countryUid">The Country Uid to find</param>
    /// <returns>A CountryPDSA object</returns>
    public CountryPDSA GetCountryPDSA(Guid countryUid)
    {
      return Find(x => x.CountryUid == countryUid);
    }
    
    /// <summary>
    /// Get all CountryPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of CountryPDSA Objects</returns>
    public List<CountryPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<CountryPDSA>();
    }
        
    /// <summary>
    /// Get all CountryPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of CountryPDSA Objects where IsSelected=True</returns>
    public List<CountryPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<CountryPDSA>();
    }

  }
}
