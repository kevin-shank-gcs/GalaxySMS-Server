using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedByCpuUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _CredentialToDeleteFromCpuUid = Guid.Empty;
    private Guid _CpuUid = Guid.Empty;
    private byte[] _CardBinaryData = null;
    private DateTimeOffset _DeletedFromDatabaseDate = DateTimeOffset.MinValue;
    private DateTimeOffset? _DeletedFromCpuDate = null;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _CpuNumber = 0;
    private int _ClusterGroupId = 0;
    private string _ServerAddress = string.Empty;
    private bool _IsConnected = false;
    private short _DataLength = 0;
    private bool _IsExtended = false;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Credential To Delete From Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialToDeleteFromCpuUid 
    { 
      get { return _CredentialToDeleteFromCpuUid; }
      set 
      { 
        if(HasValueChanged(_CredentialToDeleteFromCpuUid, value, "CredentialToDeleteFromCpuUid"))
        {
          _CredentialToDeleteFromCpuUid = value; 
          RaisePropertyChanged("CredentialToDeleteFromCpuUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CpuUid 
    { 
      get { return _CpuUid; }
      set 
      { 
        if(HasValueChanged(_CpuUid, value, "CpuUid"))
        {
          _CpuUid = value; 
          RaisePropertyChanged("CpuUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Card Binary Data value
    /// </summary>
    
    [DataMember]
    
    public byte[] CardBinaryData 
    { 
      get { return _CardBinaryData; }
      set 
      { 
        if(HasValueChanged(_CardBinaryData, value, "CardBinaryData"))
        {
          _CardBinaryData = value; 
          RaisePropertyChanged("CardBinaryData");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Deleted From Database Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset DeletedFromDatabaseDate 
    { 
      get { return _DeletedFromDatabaseDate; }
      set 
      { 
        if(HasValueChanged(_DeletedFromDatabaseDate, value, "DeletedFromDatabaseDate"))
        {
          _DeletedFromDatabaseDate = value; 
          RaisePropertyChanged("DeletedFromDatabaseDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Deleted From Cpu Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? DeletedFromCpuDate 
    { 
      get { return _DeletedFromCpuDate; }
      set 
      { 
        if(HasValueChanged(_DeletedFromCpuDate, value, "DeletedFromCpuDate"))
        {
          _DeletedFromCpuDate = value; 
          RaisePropertyChanged("DeletedFromCpuDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Number value
    /// </summary>
    
    [DataMember]
    
    public int ClusterNumber 
    { 
      get { return _ClusterNumber; }
      set 
      { 
        if(HasValueChanged(_ClusterNumber, value, "ClusterNumber"))
        {
          _ClusterNumber = value; 
          RaisePropertyChanged("ClusterNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Panel Number value
    /// </summary>
    
    [DataMember]
    
    public int PanelNumber 
    { 
      get { return _PanelNumber; }
      set 
      { 
        if(HasValueChanged(_PanelNumber, value, "PanelNumber"))
        {
          _PanelNumber = value; 
          RaisePropertyChanged("PanelNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Number value
    /// </summary>
    
    [DataMember]
    
    public short CpuNumber 
    { 
      get { return _CpuNumber; }
      set 
      { 
        if(HasValueChanged(_CpuNumber, value, "CpuNumber"))
        {
          _CpuNumber = value; 
          RaisePropertyChanged("CpuNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Group Id value
    /// </summary>
    
    [DataMember]
    
    public int ClusterGroupId 
    { 
      get { return _ClusterGroupId; }
      set 
      { 
        if(HasValueChanged(_ClusterGroupId, value, "ClusterGroupId"))
        {
          _ClusterGroupId = value; 
          RaisePropertyChanged("ClusterGroupId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Server Address value
    /// </summary>
    
    [DataMember]
    
    public string ServerAddress 
    { 
      get { return _ServerAddress; }
      set 
      { 
        if(HasValueChanged(_ServerAddress, value, "ServerAddress"))
        {
          _ServerAddress = value; 
          RaisePropertyChanged("ServerAddress");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Connected value
    /// </summary>
    
    [DataMember]
    
    public bool IsConnected 
    { 
      get { return _IsConnected; }
      set 
      { 
        if(HasValueChanged(_IsConnected, value, "IsConnected"))
        {
          _IsConnected = value; 
          RaisePropertyChanged("IsConnected");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Data Length value
    /// </summary>
    
    [DataMember]
    
    public short DataLength 
    { 
      get { return _DataLength; }
      set 
      { 
        if(HasValueChanged(_DataLength, value, "DataLength"))
        {
          _DataLength = value; 
          RaisePropertyChanged("DataLength");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Extended value
    /// </summary>
    
    [DataMember]
    
    public bool IsExtended 
    { 
      get { return _IsExtended; }
      set 
      { 
        if(HasValueChanged(_IsExtended, value, "IsExtended"))
        {
          _IsExtended = value; 
          RaisePropertyChanged("IsExtended");
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
