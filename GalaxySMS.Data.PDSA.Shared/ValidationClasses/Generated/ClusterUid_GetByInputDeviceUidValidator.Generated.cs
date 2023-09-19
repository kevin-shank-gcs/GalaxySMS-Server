using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the ClusterUid_GetByInputDeviceUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ClusterUid_GetByInputDeviceUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ClusterUid_GetByInputDeviceUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ClusterUid_GetByInputDeviceUidPDSA Entity
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
    /// Clones the current ClusterUid_GetByInputDeviceUidPDSA
    /// </summary>
    /// <returns>A cloned ClusterUid_GetByInputDeviceUidPDSA object</returns>
    public ClusterUid_GetByInputDeviceUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ClusterUid_GetByInputDeviceUidPDSA
    /// </summary>
    /// <param name="entityToClone">The ClusterUid_GetByInputDeviceUidPDSA entity to clone</param>
    /// <returns>A cloned ClusterUid_GetByInputDeviceUidPDSA object</returns>
    public ClusterUid_GetByInputDeviceUidPDSA CloneEntity(ClusterUid_GetByInputDeviceUidPDSA entityToClone)
    {
      ClusterUid_GetByInputDeviceUidPDSA newEntity = new ClusterUid_GetByInputDeviceUidPDSA();

      newEntity.ClusterUid = entityToClone.ClusterUid;

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
      
      props.Add(PDSAProperty.Create(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid, GetResourceMessage("GCS_ClusterUid_GetByInputDeviceUidPDSA_inputDeviceUid_Header", "input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ClusterUid_GetByInputDeviceUidPDSA_inputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_ClusterUid_GetByInputDeviceUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_ClusterUid_GetByInputDeviceUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid).Value = Entity.inputDeviceUid;
      this.Properties.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid).IsNull == false)
        Entity.inputDeviceUid = this.Properties.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterUid_GetByInputDeviceUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns '@inputDeviceUid'
    /// </summary>
    public static string inputDeviceUid = "@inputDeviceUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterUid_GetByInputDeviceUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@inputDeviceUid'
    /// </summary>
    public static string inputDeviceUid = "@inputDeviceUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
