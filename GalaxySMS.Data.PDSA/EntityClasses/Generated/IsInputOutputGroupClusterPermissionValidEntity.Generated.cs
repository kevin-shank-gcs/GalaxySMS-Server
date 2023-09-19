using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsInputOutputGroupClusterPermissionValidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsInputOutputGroupClusterPermissionValidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _InputOutputGroupUid = Guid.Empty;
    private short _OrderNumber = 0;
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
    /// Get/Set the Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ClusterUid 
    { 
      get { return _ClusterUid; }
      set 
      { 
        if(HasValueChanged(_ClusterUid, value, "@ClusterUid"))
        {
          _ClusterUid = value; 
          RaisePropertyChanged("ClusterUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputOutputGroupUid 
    { 
      get { return _InputOutputGroupUid; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroupUid, value, "@InputOutputGroupUid"))
        {
          _InputOutputGroupUid = value; 
          RaisePropertyChanged("InputOutputGroupUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Order Number value
    /// </summary>
    
    [DataMember]
    
    public short OrderNumber 
    { 
      get { return _OrderNumber; }
      set 
      { 
        if(HasValueChanged(_OrderNumber, value, "@OrderNumber"))
        {
          _OrderNumber = value; 
          RaisePropertyChanged("OrderNumber");
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
