using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the DateTypeDefaultBehavior_GetPanelLoadDataPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DateTypeDefaultBehavior_GetPanelLoadDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DateTypeDefaultBehavior_GetPanelLoadDataPDSA Entity
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
    /// Clones the current DateTypeDefaultBehavior_GetPanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned DateTypeDefaultBehavior_GetPanelLoadDataPDSA object</returns>
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DateTypeDefaultBehavior_GetPanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The DateTypeDefaultBehavior_GetPanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned DateTypeDefaultBehavior_GetPanelLoadDataPDSA object</returns>
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSA CloneEntity(DateTypeDefaultBehavior_GetPanelLoadDataPDSA entityToClone)
    {
      DateTypeDefaultBehavior_GetPanelLoadDataPDSA newEntity = new DateTypeDefaultBehavior_GetPanelLoadDataPDSA();

      newEntity.DateTypeDefaultBehaviorUid = entityToClone.DateTypeDefaultBehaviorUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.SundayDayCode = entityToClone.SundayDayCode;
      newEntity.MondayDayCode = entityToClone.MondayDayCode;
      newEntity.TuesdayDayCode = entityToClone.TuesdayDayCode;
      newEntity.WednesdayDayCode = entityToClone.WednesdayDayCode;
      newEntity.ThursdayDayCode = entityToClone.ThursdayDayCode;
      newEntity.FridayDayCode = entityToClone.FridayDayCode;
      newEntity.SaturdayDayCode = entityToClone.SaturdayDayCode;

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
      
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateTypeDefaultBehavior_GetPanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DateTypeDefaultBehaviorUid'
    /// </summary>
    public static string DateTypeDefaultBehaviorUid = "DateTypeDefaultBehaviorUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'SundayDayCode'
    /// </summary>
    public static string SundayDayCode = "SundayDayCode";
    /// <summary>
    /// Returns 'MondayDayCode'
    /// </summary>
    public static string MondayDayCode = "MondayDayCode";
    /// <summary>
    /// Returns 'TuesdayDayCode'
    /// </summary>
    public static string TuesdayDayCode = "TuesdayDayCode";
    /// <summary>
    /// Returns 'WednesdayDayCode'
    /// </summary>
    public static string WednesdayDayCode = "WednesdayDayCode";
    /// <summary>
    /// Returns 'ThursdayDayCode'
    /// </summary>
    public static string ThursdayDayCode = "ThursdayDayCode";
    /// <summary>
    /// Returns 'FridayDayCode'
    /// </summary>
    public static string FridayDayCode = "FridayDayCode";
    /// <summary>
    /// Returns 'SaturdayDayCode'
    /// </summary>
    public static string SaturdayDayCode = "SaturdayDayCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateTypeDefaultBehavior_GetPanelLoadDataPDSA class.
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
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
