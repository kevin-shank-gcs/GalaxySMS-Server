using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcsUserSettingPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class gcsUserSettingPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcsUserSettingPDSA class
    /// </summary>
    public gcsUserSettingPDSA() : base()
    {
      ClassName = "gcsUserSettingPDSA";
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

      ret += "UserSettingId: " + UserSettingId.ToString() + " / ";
      ret += "Category: " + Category.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of gcsUserSettingPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcsUserSettingPDSACollection : List<gcsUserSettingPDSA>
  {
    /// <summary>
    /// Find a gcsUserSettingPDSA object
    /// </summary>
    /// <param name="userSettingId">The User Setting Id to find</param>
    /// <returns>A gcsUserSettingPDSA object</returns>
    public gcsUserSettingPDSA GetgcsUserSettingPDSA(Guid userSettingId)
    {
#if SILVERLIGHT
      return this.First(x => x.UserSettingId == userSettingId);
#else
      return Find(x => x.UserSettingId == userSettingId);
#endif
    }
    
    /// <summary>
    /// Get all gcsUserSettingPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcsUserSettingPDSA Objects</returns>
    public List<gcsUserSettingPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcsUserSettingPDSA>();
    }
        
    /// <summary>
    /// Get all gcsUserSettingPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcsUserSettingPDSA Objects where IsSelected=True</returns>
    public List<gcsUserSettingPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcsUserSettingPDSA>();
    }

  }
}
