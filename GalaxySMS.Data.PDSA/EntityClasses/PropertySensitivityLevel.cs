using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the PropertySensitivityLevelPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class PropertySensitivityLevelPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the PropertySensitivityLevelPDSA class
    /// </summary>
    public PropertySensitivityLevelPDSA() : base()
    {
      ClassName = "PropertySensitivityLevelPDSA";
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

      ret += "PropertySensitivityLevelUid: " + PropertySensitivityLevelUid.ToString() + " / ";
      ret += "Display: " + Display.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of PropertySensitivityLevelPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class PropertySensitivityLevelPDSACollection : List<PropertySensitivityLevelPDSA>
  {
    /// <summary>
    /// Find a PropertySensitivityLevelPDSA object
    /// </summary>
    /// <param name="propertySensitivityLevelUid">The Property Sensitivity Level Uid to find</param>
    /// <returns>A PropertySensitivityLevelPDSA object</returns>
    public PropertySensitivityLevelPDSA GetPropertySensitivityLevelPDSA(Guid propertySensitivityLevelUid)
    {
      return Find(x => x.PropertySensitivityLevelUid == propertySensitivityLevelUid);
    }
    
    /// <summary>
    /// Get all PropertySensitivityLevelPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of PropertySensitivityLevelPDSA Objects</returns>
    public List<PropertySensitivityLevelPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<PropertySensitivityLevelPDSA>();
    }
        
    /// <summary>
    /// Get all PropertySensitivityLevelPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of PropertySensitivityLevelPDSA Objects where IsSelected=True</returns>
    public List<PropertySensitivityLevelPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<PropertySensitivityLevelPDSA>();
    }

  }
}
