using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsAccessProfileInputOutputGroupUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsAccessProfileInputOutputGroupUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _AccessProfileInputOutputGroupUid = Guid.Empty;
    private Guid _AccessProfileClusterUid = Guid.Empty;
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
    /// Get/Set the Access Profile Input Output Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessProfileInputOutputGroupUid 
    { 
      get { return _AccessProfileInputOutputGroupUid; }
      set 
      { 
        if(HasValueChanged(_AccessProfileInputOutputGroupUid, value, "@AccessProfileInputOutputGroupUid"))
        {
          _AccessProfileInputOutputGroupUid = value; 
          RaisePropertyChanged("AccessProfileInputOutputGroupUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Profile Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessProfileClusterUid 
    { 
      get { return _AccessProfileClusterUid; }
      set 
      { 
        if(HasValueChanged(_AccessProfileClusterUid, value, "@AccessProfileClusterUid"))
        {
          _AccessProfileClusterUid = value; 
          RaisePropertyChanged("AccessProfileClusterUid");
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
