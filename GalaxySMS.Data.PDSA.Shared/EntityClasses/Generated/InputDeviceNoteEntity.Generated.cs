using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a InputDeviceNotePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class InputDeviceNotePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _InputDeviceNoteUid = Guid.Empty;
    private Guid _InputDeviceUid = Guid.Empty;
    private Guid _NoteUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _InputDeviceNoteUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Input Device Note Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceNoteUid 
    { 
      get { return _InputDeviceNoteUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceNoteUid, value, "InputDeviceNoteUid"))
        {
          _InputDeviceNoteUid = value; 
          RaisePropertyChanged("InputDeviceNoteUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceUid 
    { 
      get { return _InputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceUid, value, "InputDeviceUid"))
        {
          _InputDeviceUid = value; 
          RaisePropertyChanged("InputDeviceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Note Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid NoteUid 
    { 
      get { return _NoteUid; }
      set 
      { 
        if(HasValueChanged(_NoteUid, value, "NoteUid"))
        {
          _NoteUid = value; 
          RaisePropertyChanged("NoteUid");
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
    /// Get/Set the Input Device Note UidOld value
    /// </summary>
    
    public Guid InputDeviceNoteUidOld
    { 
      get { return _InputDeviceNoteUidOld; }
      set 
      { 
        if(HasValueChanged(_InputDeviceNoteUidOld, value, "InputDeviceNoteUid"))
        {
          _InputDeviceNoteUidOld = value; 
          RaisePropertyChanged("InputDeviceNoteUidOld");
        }
      } 
    }
    #endregion
  }
}
