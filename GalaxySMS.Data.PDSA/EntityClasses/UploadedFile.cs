using System;
using System.Collections.Generic;
using System.Linq;


namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the UploadedFilePDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class.
  /// </summary>
  //[Serializable]
  public partial class UploadedFilePDSA
  {
    #region Constructor
    /// <summary>
    /// Constructor for the UploadedFilePDSA class
    /// </summary>
    public UploadedFilePDSA() : base()
    {
      ClassName = "UploadedFilePDSA";
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

      ret += "UploadedFileUid: " + UploadedFileUid.ToString() + " / ";
      ret += "Tag: " + Tag.ToString() + " / ";
      
      return ret;
    }
    #endregion
  }
  
  /// <summary>
  /// This class is used when you wish to create a collection of UploadedFilePDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class UploadedFilePDSACollection : List<UploadedFilePDSA>
  {
    /// <summary>
    /// Find a UploadedFilePDSA object
    /// </summary>
    /// <param name="uploadedFileUid">The Uploaded File Uid to find</param>
    /// <returns>A UploadedFilePDSA object</returns>
    public UploadedFilePDSA GetUploadedFilePDSA(Guid uploadedFileUid)
    {
      return Find(x => x.UploadedFileUid == uploadedFileUid);
    }
    
    /// <summary>
    /// Get all UploadedFilePDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of UploadedFilePDSA Objects</returns>
    public List<UploadedFilePDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<UploadedFilePDSA>();
    }
        
    /// <summary>
    /// Get all UploadedFilePDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of UploadedFilePDSA Objects where IsSelected=True</returns>
    public List<UploadedFilePDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<UploadedFilePDSA>();
    }

  }
}
