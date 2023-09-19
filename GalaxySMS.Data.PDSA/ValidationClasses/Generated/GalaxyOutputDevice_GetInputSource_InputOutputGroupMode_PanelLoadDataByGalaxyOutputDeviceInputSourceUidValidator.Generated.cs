using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        base.Entity = value;
      }
    }
    #endregion
  
    #region Clone Entity Class
    /// <summary>
    /// Clones the current GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA
    /// </summary>
    /// <returns>A cloned GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA object</returns>
    public GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA entity to clone</param>
    /// <returns>A cloned GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA object</returns>
    public GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA CloneEntity(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA entityToClone)
    {
      GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA newEntity = new GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA();

      newEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid = entityToClone.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
      newEntity.GalaxyOutputDeviceInputSourceUid = entityToClone.GalaxyOutputDeviceInputSourceUid;
      newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
      newEntity.IOGroupName = entityToClone.IOGroupName;

      return newEntity;
    }
    #endregion

    #region CreateProperties Method
    /// <summary>
    /// Creates the collection of PDSAProperty objects. These are used to control validation and null handling.
    /// </summary>
    /// <returns>A collection of PDSAProperty objects</returns>
    public override PDSAProperties CreateProperties()
    {
      PDSAProperties props = new PDSAProperties();
      
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA_GalaxyOutputDeviceInputSourceUid_Header", "Galaxy Output Device Input Source Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA_GalaxyOutputDeviceInputSourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion
    
    #region InitProperties Method
    /// <summary>
    /// Called by the constructor to create the PDSAProperties collection of all properties that will be validated.
    /// </summary>
    protected override void InitProperties()
    {
      // Set the Properties collection to the collection of Entity Properties
      Properties = CreateProperties();
    }
    #endregion

    #region EntityDataToProperties Method
    /// <summary>
    /// Moves the Entity class data into the Properties collection.
    /// </summary>
    protected override void EntityDataToProperties()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid).Value = Entity.GalaxyOutputDeviceInputSourceUid;
      this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid).IsNull == false)
        Entity.GalaxyOutputDeviceInputSourceUid = this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.GalaxyOutputDeviceInputSourceUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyOutputDeviceInputSourceInputOutputGroupUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceInputOutputGroupUid = "GalaxyOutputDeviceInputSourceInputOutputGroupUid";
    /// <summary>
    /// Returns 'GalaxyOutputDeviceInputSourceUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceUid = "GalaxyOutputDeviceInputSourceUid";
    /// <summary>
    /// Returns 'IOGroupNumber'
    /// </summary>
    public static string IOGroupNumber = "IOGroupNumber";
    /// <summary>
    /// Returns 'IOGroupName'
    /// </summary>
    public static string IOGroupName = "IOGroupName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyOutputDeviceInputSourceUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceUid = "@GalaxyOutputDeviceInputSourceUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
