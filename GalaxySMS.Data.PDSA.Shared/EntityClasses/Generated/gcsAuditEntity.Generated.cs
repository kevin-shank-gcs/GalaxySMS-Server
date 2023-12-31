using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsAuditPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsAuditPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AuditId = Guid.NewGuid();
    private Guid _TransactionId = Guid.NewGuid();
    private string _TableName = string.Empty;
    private string _OperationType = string.Empty;
    private string _PrimaryKeyColumn = string.Empty;
    private Guid _PrimaryKeyValue = Guid.NewGuid();
    private string _RecordTag = string.Empty;
    private string _AuditXml = string.Empty;
    private string _ColumnName = string.Empty;
    private string _OriginalValue = string.Empty;
    private string _NewValue = string.Empty;
    private byte[] _OriginalBinaryValue = null;
    private byte[] _NewBinaryValue = null;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private Guid _AuditIdOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Audit Id value
    /// </summary>
    
    public Guid AuditId 
    { 
      get { return _AuditId; }
      set 
      { 
        if(HasValueChanged(_AuditId, value, "AuditId"))
        {
          _AuditId = value; 
          RaisePropertyChanged("AuditId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Transaction Id value
    /// </summary>
    
    public Guid TransactionId 
    { 
      get { return _TransactionId; }
      set 
      { 
        if(HasValueChanged(_TransactionId, value, "TransactionId"))
        {
          _TransactionId = value; 
          RaisePropertyChanged("TransactionId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Table Name value
    /// </summary>
    
    public string TableName 
    { 
      get { return _TableName; }
      set 
      { 
        if(HasValueChanged(_TableName, value, "TableName"))
        {
          _TableName = value; 
          RaisePropertyChanged("TableName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Operation Type value
    /// </summary>
    
    public string OperationType 
    { 
      get { return _OperationType; }
      set 
      { 
        if(HasValueChanged(_OperationType, value, "OperationType"))
        {
          _OperationType = value; 
          RaisePropertyChanged("OperationType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Primary Key Column value
    /// </summary>
    
    public string PrimaryKeyColumn 
    { 
      get { return _PrimaryKeyColumn; }
      set 
      { 
        if(HasValueChanged(_PrimaryKeyColumn, value, "PrimaryKeyColumn"))
        {
          _PrimaryKeyColumn = value; 
          RaisePropertyChanged("PrimaryKeyColumn");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Primary Key Value value
    /// </summary>
    
    public Guid PrimaryKeyValue 
    { 
      get { return _PrimaryKeyValue; }
      set 
      { 
        if(HasValueChanged(_PrimaryKeyValue, value, "PrimaryKeyValue"))
        {
          _PrimaryKeyValue = value; 
          RaisePropertyChanged("PrimaryKeyValue");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Record Tag value
    /// </summary>
    
    public string RecordTag 
    { 
      get { return _RecordTag; }
      set 
      { 
        if(HasValueChanged(_RecordTag, value, "RecordTag"))
        {
          _RecordTag = value; 
          RaisePropertyChanged("RecordTag");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Audit Xml value
    /// </summary>
    
    public string AuditXml 
    { 
      get { return _AuditXml; }
      set 
      { 
        if(HasValueChanged(_AuditXml, value, "AuditXml"))
        {
          _AuditXml = value; 
          RaisePropertyChanged("AuditXml");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Column Name value
    /// </summary>
    
    public string ColumnName 
    { 
      get { return _ColumnName; }
      set 
      { 
        if(HasValueChanged(_ColumnName, value, "ColumnName"))
        {
          _ColumnName = value; 
          RaisePropertyChanged("ColumnName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Original Value value
    /// </summary>
    
    public string OriginalValue 
    { 
      get { return _OriginalValue; }
      set 
      { 
        if(HasValueChanged(_OriginalValue, value, "OriginalValue"))
        {
          _OriginalValue = value; 
          RaisePropertyChanged("OriginalValue");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the New Value value
    /// </summary>
    
    public string NewValue 
    { 
      get { return _NewValue; }
      set 
      { 
        if(HasValueChanged(_NewValue, value, "NewValue"))
        {
          _NewValue = value; 
          RaisePropertyChanged("NewValue");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Original Binary Value value
    /// </summary>
    
    public byte[] OriginalBinaryValue 
    { 
      get { return _OriginalBinaryValue; }
      set 
      { 
        if(HasValueChanged(_OriginalBinaryValue, value, "OriginalBinaryValue"))
        {
          _OriginalBinaryValue = value; 
          RaisePropertyChanged("OriginalBinaryValue");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the New Binary Value value
    /// </summary>
    
    public byte[] NewBinaryValue 
    { 
      get { return _NewBinaryValue; }
      set 
      { 
        if(HasValueChanged(_NewBinaryValue, value, "NewBinaryValue"))
        {
          _NewBinaryValue = value; 
          RaisePropertyChanged("NewBinaryValue");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Name value
    /// </summary>
    
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
    /// Get/Set the Audit IdOld value
    /// </summary>
    
    public Guid AuditIdOld
    { 
      get { return _AuditIdOld; }
      set 
      { 
        if(HasValueChanged(_AuditIdOld, value, "AuditId"))
        {
          _AuditIdOld = value; 
          RaisePropertyChanged("AuditIdOld");
        }
      } 
    }
    #endregion
  }
}
