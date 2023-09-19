using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsAccessPortalAlertEventUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsAccessPortalAlertEventUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _AccessPortalAlertEventUid = Guid.NewGuid();
    private Guid _AccessPortalUid = Guid.NewGuid();
    private Guid _AccessPortalAlertEventTypeUid = Guid.NewGuid();
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
    /// Get/Set the Access Portal Alert Event Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalAlertEventUid 
    { 
      get { return _AccessPortalAlertEventUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalAlertEventUid, value, "@AccessPortalAlertEventUid"))
        {
          _AccessPortalAlertEventUid = value; 
          RaisePropertyChanged("AccessPortalAlertEventUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalUid 
    { 
      get { return _AccessPortalUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalUid, value, "@AccessPortalUid"))
        {
          _AccessPortalUid = value; 
          RaisePropertyChanged("AccessPortalUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Alert Event Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalAlertEventTypeUid 
    { 
      get { return _AccessPortalAlertEventTypeUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalAlertEventTypeUid, value, "@AccessPortalAlertEventTypeUid"))
        {
          _AccessPortalAlertEventTypeUid = value; 
          RaisePropertyChanged("AccessPortalAlertEventTypeUid");
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
