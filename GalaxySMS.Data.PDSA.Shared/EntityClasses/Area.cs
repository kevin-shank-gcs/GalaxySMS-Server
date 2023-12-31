using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the AreaPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class AreaPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the AreaPDSA class
    /// </summary>
    public AreaPDSA() : base()
    {
      ClassName = "AreaPDSA";
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

      ret += "AreaUid: " + AreaUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of AreaPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class AreaPDSACollection : List<AreaPDSA>
  {
    /// <summary>
    /// Find a AreaPDSA object
    /// </summary>
    /// <param name="areaUid">The Area Uid to find</param>
    /// <returns>A AreaPDSA object</returns>
    public AreaPDSA GetAreaPDSA(Guid areaUid)
    {
      return Find(x => x.AreaUid == areaUid);
    }
    
    /// <summary>
    /// Get all AreaPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of AreaPDSA Objects</returns>
    public List<AreaPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<AreaPDSA>();
    }
        
    /// <summary>
    /// Get all AreaPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of AreaPDSA Objects where IsSelected=True</returns>
    public List<AreaPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<AreaPDSA>();
    }

  }
}
