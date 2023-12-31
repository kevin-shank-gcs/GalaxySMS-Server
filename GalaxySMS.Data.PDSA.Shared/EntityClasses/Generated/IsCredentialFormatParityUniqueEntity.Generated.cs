using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsCredentialFormatParityUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsCredentialFormatParityUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _CredentialFormatParityUid = Guid.Empty;
    private Guid _CredentialFormatUid = Guid.Empty;
    private short _ComputeSequence = 0;
    private short _BitPosition = 0;
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
    /// Get/Set the Credential Format Parity Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialFormatParityUid 
    { 
      get { return _CredentialFormatParityUid; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatParityUid, value, "@CredentialFormatParityUid"))
        {
          _CredentialFormatParityUid = value; 
          RaisePropertyChanged("CredentialFormatParityUid");
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
    /// Get/Set the Compute Sequence value
    /// </summary>
    
    [DataMember]
    
    public short ComputeSequence 
    { 
      get { return _ComputeSequence; }
      set 
      { 
        if(HasValueChanged(_ComputeSequence, value, "@ComputeSequence"))
        {
          _ComputeSequence = value; 
          RaisePropertyChanged("ComputeSequence");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Bit Position value
    /// </summary>
    
    [DataMember]
    
    public short BitPosition 
    { 
      get { return _BitPosition; }
      set 
      { 
        if(HasValueChanged(_BitPosition, value, "@BitPosition"))
        {
          _BitPosition = value; 
          RaisePropertyChanged("BitPosition");
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
