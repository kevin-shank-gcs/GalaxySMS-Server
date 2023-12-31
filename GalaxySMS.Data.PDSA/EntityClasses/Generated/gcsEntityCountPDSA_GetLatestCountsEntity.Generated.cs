using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the gcsEntityCountPDSA_GetLatestCountsPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsEntityCountPDSA_GetLatestCountsPDSA : PDSAEntityBase
  {
    #region Private Variables
    private string _CountType = string.Empty;
    private long _CountValue = 0;
    private Guid _EntityId = Guid.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Count Type value
    /// </summary>
    
    [DataMember]
    
    public string CountType 
    { 
      get { return _CountType; }
      set 
      { 
        if(HasValueChanged(_CountType, value, "CountType"))
        {
          _CountType = value; 
          RaisePropertyChanged("CountType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Count Value value
    /// </summary>
    
    [DataMember]
    
    public long CountValue 
    { 
      get { return _CountValue; }
      set 
      { 
        if(HasValueChanged(_CountValue, value, "CountValue"))
        {
          _CountValue = value; 
          RaisePropertyChanged("CountValue");
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
        if(HasValueChanged(_EntityId, value, "EntityId"))
        {
          _EntityId = value; 
          RaisePropertyChanged("EntityId");
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
