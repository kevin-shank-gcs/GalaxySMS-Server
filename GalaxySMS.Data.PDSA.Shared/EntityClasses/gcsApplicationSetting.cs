using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the gcsApplicationSettingPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class gcsApplicationSettingPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the gcsApplicationSettingPDSA class
    /// </summary>
    public gcsApplicationSettingPDSA() : base()
    {
      ClassName = "gcsApplicationSettingPDSA";
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

      ret += "ApplicationSettingId: " + ApplicationSettingId.ToString() + " / ";
      ret += "Category: " + Category.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of gcsApplicationSettingPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class gcsApplicationSettingPDSACollection : List<gcsApplicationSettingPDSA>
  {
    /// <summary>
    /// Find a gcsApplicationSettingPDSA object
    /// </summary>
    /// <param name="applicationSettingId">The Application Setting Id to find</param>
    /// <returns>A gcsApplicationSettingPDSA object</returns>
    public gcsApplicationSettingPDSA GetgcsApplicationSettingPDSA(Guid applicationSettingId)
    {
#if SILVERLIGHT
      return this.First(x => x.ApplicationSettingId == applicationSettingId);
#else
      return Find(x => x.ApplicationSettingId == applicationSettingId);
#endif
    }
    
    /// <summary>
    /// Get all gcsApplicationSettingPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of gcsApplicationSettingPDSA Objects</returns>
    public List<gcsApplicationSettingPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<gcsApplicationSettingPDSA>();
    }
        
    /// <summary>
    /// Get all gcsApplicationSettingPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of gcsApplicationSettingPDSA Objects where IsSelected=True</returns>
    public List<gcsApplicationSettingPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<gcsApplicationSettingPDSA>();
    }

  }
}
