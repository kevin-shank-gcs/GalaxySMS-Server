using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a MercScpStatusPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class MercScpStatusPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _MercScpUid = Guid.Empty;
    private bool? _Online = null;
    private DateTimeOffset? _LastConnected = null;
    private DateTimeOffset? _LastDisconnected = null;
    private Guid _MercScpUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Merc Scp Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid MercScpUid 
    { 
      get { return _MercScpUid; }
      set 
      { 
        if(HasValueChanged(_MercScpUid, value, "MercScpUid"))
        {
          _MercScpUid = value; 
          RaisePropertyChanged("MercScpUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Online value
    /// </summary>
    
    [DataMember]
    
    public bool? Online 
    { 
      get { return _Online; }
      set 
      { 
        if(HasValueChanged(_Online, value, "Online"))
        {
          _Online = value; 
          RaisePropertyChanged("Online");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Last Connected value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? LastConnected 
    { 
      get { return _LastConnected; }
      set 
      { 
        if(HasValueChanged(_LastConnected, value, "LastConnected"))
        {
          _LastConnected = value; 
          RaisePropertyChanged("LastConnected");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Last Disconnected value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? LastDisconnected 
    { 
      get { return _LastDisconnected; }
      set 
      { 
        if(HasValueChanged(_LastDisconnected, value, "LasDisconnected"))
        {
          _LastDisconnected = value; 
          RaisePropertyChanged("LasDisconnected");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Merc Scp UidOld value
    /// </summary>
    
    public Guid MercScpUidOld
    { 
      get { return _MercScpUidOld; }
      set 
      { 
        if(HasValueChanged(_MercScpUidOld, value, "MercScpUid"))
        {
          _MercScpUidOld = value; 
          RaisePropertyChanged("MercScpUidOld");
        }
      } 
    }
    #endregion
  }
}
