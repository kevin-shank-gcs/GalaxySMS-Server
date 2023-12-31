using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a UploadedFilePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class UploadedFilePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _UploadedFileUid = Guid.Empty;
    private string _Tag = string.Empty;
    private string _UniqueFilename = string.Empty;
    private string _OriginalFilename = string.Empty;
    private string _ContentType = string.Empty;
    private byte[] _PhotoImage = null;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _UploadedFileUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Uploaded File Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid UploadedFileUid 
    { 
      get { return _UploadedFileUid; }
      set 
      { 
        if(HasValueChanged(_UploadedFileUid, value, "UploadedFileUid"))
        {
          _UploadedFileUid = value; 
          RaisePropertyChanged("UploadedFileUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Tag value
    /// </summary>
    
    [DataMember]
    
    public string Tag 
    { 
      get { return _Tag; }
      set 
      { 
        if(HasValueChanged(_Tag, value, "Tag"))
        {
          _Tag = value; 
          RaisePropertyChanged("Tag");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Unique Filename value
    /// </summary>
    
    [DataMember]
    
    public string UniqueFilename 
    { 
      get { return _UniqueFilename; }
      set 
      { 
        if(HasValueChanged(_UniqueFilename, value, "UniqueFilename"))
        {
          _UniqueFilename = value; 
          RaisePropertyChanged("UniqueFilename");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Original Filename value
    /// </summary>
    
    [DataMember]
    
    public string OriginalFilename 
    { 
      get { return _OriginalFilename; }
      set 
      { 
        if(HasValueChanged(_OriginalFilename, value, "OriginalFilename"))
        {
          _OriginalFilename = value; 
          RaisePropertyChanged("OriginalFilename");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Content Type value
    /// </summary>
    
    [DataMember]
    
    public string ContentType 
    { 
      get { return _ContentType; }
      set 
      { 
        if(HasValueChanged(_ContentType, value, "ContentType"))
        {
          _ContentType = value; 
          RaisePropertyChanged("ContentType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Photo Image value
    /// </summary>
    
    [DataMember]
    
    public byte[] PhotoImage 
    { 
      get { return _PhotoImage; }
      set 
      { 
        if(HasValueChanged(_PhotoImage, value, "PhotoImage"))
        {
          _PhotoImage = value; 
          RaisePropertyChanged("PhotoImage");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Name value
    /// </summary>
    
    [DataMember]
    
    public string InsertName 
    { 
      get { return _InsertName; }
      set 
      { 
        if(HasValueChanged(_InsertName, value, "InsertName"))
        {
          _InsertName = value; 
          RaisePropertyChanged("InsertName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset InsertDate 
    { 
      get { return _InsertDate; }
      set 
      { 
        if(HasValueChanged(_InsertDate, value, "InsertDate"))
        {
          _InsertDate = value; 
          RaisePropertyChanged("InsertDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Name value
    /// </summary>
    
    [DataMember]
    
    public string UpdateName 
    { 
      get { return _UpdateName; }
      set 
      { 
        if(HasValueChanged(_UpdateName, value, "UpdateName"))
        {
          _UpdateName = value; 
          RaisePropertyChanged("UpdateName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset UpdateDate 
    { 
      get { return _UpdateDate; }
      set 
      { 
        if(HasValueChanged(_UpdateDate, value, "UpdateDate"))
        {
          _UpdateDate = value; 
          RaisePropertyChanged("UpdateDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Concurrency Value value
    /// </summary>
    
    [DataMember]
    
    public short ConcurrencyValue 
    { 
      get { return _ConcurrencyValue; }
      set 
      { 
        if(HasValueChanged(_ConcurrencyValue, value, "ConcurrencyValue"))
        {
          _ConcurrencyValue = value; 
          RaisePropertyChanged("ConcurrencyValue");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Uploaded File UidOld value
    /// </summary>
    
    public Guid UploadedFileUidOld
    { 
      get { return _UploadedFileUidOld; }
      set 
      { 
        if(HasValueChanged(_UploadedFileUidOld, value, "UploadedFileUid"))
        {
          _UploadedFileUidOld = value; 
          RaisePropertyChanged("UploadedFileUidOld");
        }
      } 
    }
    #endregion
  }
}
