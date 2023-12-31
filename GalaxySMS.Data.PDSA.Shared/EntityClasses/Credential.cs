using System;
using System.Collections.Generic;
using System.Linq;

using GalaxySMS.BusinessLayer;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the CredentialPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class CredentialPDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the CredentialPDSA class
    /// </summary>
    public CredentialPDSA() : base()
    {
      ClassName = "CredentialPDSA";
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

      ret += "CredentialUid: " + CredentialUid.ToString() + " / ";
      ret += "CardNumber: " + CardNumber.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of CredentialPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class CredentialPDSACollection : List<CredentialPDSA>
  {
    /// <summary>
    /// Find a CredentialPDSA object
    /// </summary>
    /// <param name="credentialUid">The Credential Uid to find</param>
    /// <returns>A CredentialPDSA object</returns>
    public CredentialPDSA GetCredentialPDSA(Guid credentialUid)
    {
      return Find(x => x.CredentialUid == credentialUid);
    }
    
    /// <summary>
    /// Get all CredentialPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of CredentialPDSA Objects</returns>
    public List<CredentialPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<CredentialPDSA>();
    }
        
    /// <summary>
    /// Get all CredentialPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of CredentialPDSA Objects where IsSelected=True</returns>
    public List<CredentialPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<CredentialPDSA>();
    }

  }
}
