using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsAccessProfileClusterUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsAccessProfileClusterUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _AccessProfileClusterUid = Guid.Empty;
    private Guid _AccessProfileUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
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
    /// Get/Set the Access Profile Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessProfileUid 
    { 
      get { return _AccessProfileUid; }
      set 
      { 
        if(HasValueChanged(_AccessProfileUid, value, "@AccessProfileUid"))
        {
          _AccessProfileUid = value; 
          RaisePropertyChanged("AccessProfileUid");
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
