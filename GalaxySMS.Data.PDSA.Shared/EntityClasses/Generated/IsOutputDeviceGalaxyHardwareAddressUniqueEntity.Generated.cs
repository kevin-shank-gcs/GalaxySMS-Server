using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsOutputDeviceGalaxyHardwareAddressUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsOutputDeviceGalaxyHardwareAddressUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _OutputDeviceGalaxyHardwareAddressUid = Guid.NewGuid();
    private Guid _OutputDeviceUid = Guid.NewGuid();
    private Guid _GalaxyInterfaceBoardSectionNodeUid = Guid.NewGuid();
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
    /// Get/Set the Output Device Galaxy Hardware Address Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid OutputDeviceGalaxyHardwareAddressUid 
    { 
      get { return _OutputDeviceGalaxyHardwareAddressUid; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceGalaxyHardwareAddressUid, value, "@OutputDeviceGalaxyHardwareAddressUid"))
        {
          _OutputDeviceGalaxyHardwareAddressUid = value; 
          RaisePropertyChanged("OutputDeviceGalaxyHardwareAddressUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Output Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid OutputDeviceUid 
    { 
      get { return _OutputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceUid, value, "@OutputDeviceUid"))
        {
          _OutputDeviceUid = value; 
          RaisePropertyChanged("OutputDeviceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Interface Board Section Node Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardSectionNodeUid 
    { 
      get { return _GalaxyInterfaceBoardSectionNodeUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionNodeUid, value, "@GalaxyInterfaceBoardSectionNodeUid"))
        {
          _GalaxyInterfaceBoardSectionNodeUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionNodeUid");
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
