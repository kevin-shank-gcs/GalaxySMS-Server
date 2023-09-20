using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcsUserSessionPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class gcsUserSessionPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcsUserSessionPDSA class
    /// </summary>
    public gcsUserSessionPDSA() : base()
    {
      ClassName = "gcsUserSessionPDSA";
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

      ret += "gcsUserSessionUid: " + gcsUserSessionUid.ToString() + " / ";
      ret += "UserName: " + UserName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of gcsUserSessionPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class gcsUserSessionPDSACollection : List<gcsUserSessionPDSA>
  {
    /// <summary>
    /// Find a gcsUserSessionPDSA object
    /// </summary>
    /// <param name="gcsUserSessionUid">The gcs User Session Uid to find</param>
    /// <returns>A gcsUserSessionPDSA object</returns>
    public gcsUserSessionPDSA GetgcsUserSessionPDSA(Guid gcsUserSessionUid)
    {
      return Find(x => x.gcsUserSessionUid == gcsUserSessionUid);
    }
    
    /// <summary>
    /// Get all gcsUserSessionPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcsUserSessionPDSA Objects</returns>
    public List<gcsUserSessionPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcsUserSessionPDSA>();
    }
        
    /// <summary>
    /// Get all gcsUserSessionPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcsUserSessionPDSA Objects where IsSelected=True</returns>
    public List<gcsUserSessionPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcsUserSessionPDSA>();
    }

  }
}
