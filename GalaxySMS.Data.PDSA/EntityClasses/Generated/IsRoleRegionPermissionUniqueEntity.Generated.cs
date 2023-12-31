using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsRoleRegionPermissionUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsRoleRegionPermissionUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _RoleRegionPermissionUid = Guid.Empty;
    private Guid _RoleRegionUid = Guid.Empty;
    private Guid _PermissionId = Guid.Empty;
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
    /// Get/Set the Role Region Permission Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleRegionPermissionUid 
    { 
      get { return _RoleRegionPermissionUid; }
      set 
      { 
        if(HasValueChanged(_RoleRegionPermissionUid, value, "@RoleRegionPermissionUid"))
        {
          _RoleRegionPermissionUid = value; 
          RaisePropertyChanged("RoleRegionPermissionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Role Region Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleRegionUid 
    { 
      get { return _RoleRegionUid; }
      set 
      { 
        if(HasValueChanged(_RoleRegionUid, value, "@RoleRegionUid"))
        {
          _RoleRegionUid = value; 
          RaisePropertyChanged("RoleRegionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Permission Id value
    /// </summary>
    
    [DataMember]
    
    public Guid PermissionId 
    { 
      get { return _PermissionId; }
      set 
      { 
        if(HasValueChanged(_PermissionId, value, "@PermissionId"))
        {
          _PermissionId = value; 
          RaisePropertyChanged("PermissionId");
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
