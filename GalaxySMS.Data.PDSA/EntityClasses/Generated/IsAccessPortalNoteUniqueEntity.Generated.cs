using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsAccessPortalNoteUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsAccessPortalNoteUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _AccessPortalNoteUid = Guid.NewGuid();
    private Guid _AccessPortalUid = Guid.NewGuid();
    private Guid _NoteUid = Guid.NewGuid();
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Result value
    /// </summary>
    
    [DataMember]
    
    public int Result 
    { 
      get { return _Result; }
      set 
      { 
        if(HasValueChanged(_Result, value, "Result"))
        {
          _Result = value; 
          RaisePropertyChanged("Result");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Note Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalNoteUid 
    { 
      get { return _AccessPortalNoteUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalNoteUid, value, "@AccessPortalNoteUid"))
        {
          _AccessPortalNoteUid = value; 
          RaisePropertyChanged("AccessPortalNoteUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalUid 
    { 
      get { return _AccessPortalUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalUid, value, "@AccessPortalUid"))
        {
          _AccessPortalUid = value; 
          RaisePropertyChanged("AccessPortalUid");
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
        if(HasValueChanged(_NoteUid, value, "@NoteUid"))
        {
          _NoteUid = value; 
          RaisePropertyChanged("NoteUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the return value value
    /// </summary>
    
    [DataMember]
    
    public int RETURNVALUE 
    { 
      get { return _RETURNVALUE; }
      set 
      { 
        if(HasValueChanged(_RETURNVALUE, value, "@RETURN_VALUE"))
        {
          _RETURNVALUE = value; 
          RaisePropertyChanged("RETURNVALUE");
        }
      } 
    }
        

    #endregion
  }
}
