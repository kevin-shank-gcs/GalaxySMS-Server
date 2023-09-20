using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the gcs_CanRowBeDeletedBigIntPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcs_CanRowBeDeletedBigIntPDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private string _SchemaName = string.Empty;
    private string _TableName = string.Empty;
    private string _ColumnName = string.Empty;
    private long _BigIntValue = 0;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Result value
    /// </summary>
    
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
    /// Get/Set the Schema Name value
    /// </summary>
    
    public string SchemaName 
    { 
      get { return _SchemaName; }
      set 
      { 
        if(HasValueChanged(_SchemaName, value, "@SchemaName"))
        {
          _SchemaName = value; 
          RaisePropertyChanged("SchemaName");
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
        if(HasValueChanged(_TableName, value, "@TableName"))
        {
          _TableName = value; 
          RaisePropertyChanged("TableName");
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
        if(HasValueChanged(_ColumnName, value, "@ColumnName"))
        {
          _ColumnName = value; 
          RaisePropertyChanged("ColumnName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Big Int Value value
    /// </summary>
    
    public long BigIntValue 
    { 
      get { return _BigIntValue; }
      set 
      { 
        if(HasValueChanged(_BigIntValue, value, "@BigIntValue"))
        {
          _BigIntValue = value; 
          RaisePropertyChanged("BigIntValue");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the return value value
    /// </summary>
    
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
