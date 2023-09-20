using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsCredentialFormatEntityMapUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsCredentialFormatEntityMapUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _CredentialFormatEntityMapUid = Guid.Empty;
    private Guid _CredentialFormatUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
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
    /// Get/Set the Credential Format Entity Map Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialFormatEntityMapUid 
    { 
      get { return _CredentialFormatEntityMapUid; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatEntityMapUid, value, "@CredentialFormatEntityMapUid"))
        {
          _CredentialFormatEntityMapUid = value; 
          RaisePropertyChanged("CredentialFormatEntityMapUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Format Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialFormatUid 
    { 
      get { return _CredentialFormatUid; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatUid, value, "@CredentialFormatUid"))
        {
          _CredentialFormatUid = value; 
          RaisePropertyChanged("CredentialFormatUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Id value
    /// </summary>
    
    [DataMember]
    
    public Guid EntityId 
    { 
      get { return _EntityId; }
      set 
      { 
        if(HasValueChanged(_EntityId, value, "@EntityId"))
        {
          _EntityId = value; 
          RaisePropertyChanged("EntityId");
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
