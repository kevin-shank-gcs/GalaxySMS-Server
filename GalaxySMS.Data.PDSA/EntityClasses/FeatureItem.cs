using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the FeatureItemPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class FeatureItemPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the FeatureItemPDSA class
    /// </summary>
    public FeatureItemPDSA() : base()
    {
      ClassName = "FeatureItemPDSA";
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

      ret += "FeatureItemUid: " + FeatureItemUid.ToString() + " / ";
      ret += "[Value]: " + Value.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of FeatureItemPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class FeatureItemPDSACollection : List<FeatureItemPDSA>
  {
    /// <summary>
    /// Find a FeatureItemPDSA object
    /// </summary>
    /// <param name="featureItemUid">The Feature Item Uid to find</param>
    /// <returns>A FeatureItemPDSA object</returns>
    public FeatureItemPDSA GetFeatureItemPDSA(Guid featureItemUid)
    {
      return Find(x => x.FeatureItemUid == featureItemUid);
    }
    
    /// <summary>
    /// Get all FeatureItemPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of FeatureItemPDSA Objects</returns>
    public List<FeatureItemPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<FeatureItemPDSA>();
    }
        
    /// <summary>
    /// Get all FeatureItemPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of FeatureItemPDSA Objects where IsSelected=True</returns>
    public List<FeatureItemPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<FeatureItemPDSA>();
    }

  }
}
