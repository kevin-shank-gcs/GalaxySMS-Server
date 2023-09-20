using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the CredentialReaderTypeFeatureMapPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class CredentialReaderTypeFeatureMapPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the CredentialReaderTypeFeatureMapPDSA class
    /// </summary>
    public CredentialReaderTypeFeatureMapPDSA() : base()
    {
      ClassName = "CredentialReaderTypeFeatureMapPDSA";
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

      ret += "CredentialReaderTypeFeatureMapUid: " + CredentialReaderTypeFeatureMapUid.ToString() + " / ";
      ret += "InsertName: " + InsertName.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of CredentialReaderTypeFeatureMapPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  //[Serializable]
  public class CredentialReaderTypeFeatureMapPDSACollection : List<CredentialReaderTypeFeatureMapPDSA>
  {
    /// <summary>
    /// Find a CredentialReaderTypeFeatureMapPDSA object
    /// </summary>
    /// <param name="credentialReaderTypeFeatureMapUid">The Credential Reader Type Feature Map Uid to find</param>
    /// <returns>A CredentialReaderTypeFeatureMapPDSA object</returns>
    public CredentialReaderTypeFeatureMapPDSA GetCredentialReaderTypeFeatureMapPDSA(Guid credentialReaderTypeFeatureMapUid)
    {
      return Find(x => x.CredentialReaderTypeFeatureMapUid == credentialReaderTypeFeatureMapUid);
    }
    
    /// <summary>
    /// Get all CredentialReaderTypeFeatureMapPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of CredentialReaderTypeFeatureMapPDSA Objects</returns>
    public List<CredentialReaderTypeFeatureMapPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<CredentialReaderTypeFeatureMapPDSA>();
    }
        
    /// <summary>
    /// Get all CredentialReaderTypeFeatureMapPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of CredentialReaderTypeFeatureMapPDSA Objects where IsSelected=True</returns>
    public List<CredentialReaderTypeFeatureMapPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<CredentialReaderTypeFeatureMapPDSA>();
    }

  }
}
