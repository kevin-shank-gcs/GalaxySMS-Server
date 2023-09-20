using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsEntity_SetAutoMapTimeSchedulesPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsEntity_SetAutoMapTimeSchedulesPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsEntity_SetAutoMapTimeSchedulesPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsEntity_SetAutoMapTimeSchedulesPDSA Entity
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
    /// Clones the current gcsEntity_SetAutoMapTimeSchedulesPDSA
    /// </summary>
    /// <returns>A cloned gcsEntity_SetAutoMapTimeSchedulesPDSA object</returns>
    public gcsEntity_SetAutoMapTimeSchedulesPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsEntity_SetAutoMapTimeSchedulesPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsEntity_SetAutoMapTimeSchedulesPDSA entity to clone</param>
    /// <returns>A cloned gcsEntity_SetAutoMapTimeSchedulesPDSA object</returns>
    public gcsEntity_SetAutoMapTimeSchedulesPDSA CloneEntity(gcsEntity_SetAutoMapTimeSchedulesPDSA entityToClone)
    {
      gcsEntity_SetAutoMapTimeSchedulesPDSA newEntity = new gcsEntity_SetAutoMapTimeSchedulesPDSA();


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
      
      props.Add(PDSAProperty.Create(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcsEntity_SetAutoMapTimeSchedulesPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsEntity_SetAutoMapTimeSchedulesPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.AutoMapTimeSchedules, GetResourceMessage("GCS_gcsEntity_SetAutoMapTimeSchedulesPDSA_AutoMapTimeSchedules_Header", "Auto Map Time Schedules"), false, typeof(bool), 0, GetResourceMessage("GCS_gcsEntity_SetAutoMapTimeSchedulesPDSA_AutoMapTimeSchedules_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsEntity_SetAutoMapTimeSchedulesPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsEntity_SetAutoMapTimeSchedulesPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.AutoMapTimeSchedules).Value = Entity.AutoMapTimeSchedules;
      Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.AutoMapTimeSchedules).IsNull == false)
        Entity.AutoMapTimeSchedules = Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.AutoMapTimeSchedules).GetAsBool();
      if(Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(gcsEntity_SetAutoMapTimeSchedulesPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsEntity_SetAutoMapTimeSchedulesPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@AutoMapTimeSchedules'
    /// </summary>
    public static string AutoMapTimeSchedules = "@AutoMapTimeSchedules";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
