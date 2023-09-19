using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the DateTypeDefaultBehavior_PanelLoadDataPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateTypeDefaultBehavior_PanelLoadDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DateTypeDefaultBehavior_PanelLoadDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DateTypeDefaultBehavior_PanelLoadDataPDSA Entity
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
    /// Clones the current DateTypeDefaultBehavior_PanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned DateTypeDefaultBehavior_PanelLoadDataPDSA object</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DateTypeDefaultBehavior_PanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The DateTypeDefaultBehavior_PanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned DateTypeDefaultBehavior_PanelLoadDataPDSA object</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA CloneEntity(DateTypeDefaultBehavior_PanelLoadDataPDSA entityToClone)
    {
      DateTypeDefaultBehavior_PanelLoadDataPDSA newEntity = new DateTypeDefaultBehavior_PanelLoadDataPDSA();

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
      
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 65, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SundayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_SundayDayCode_Header", "Sunday Day Code"), false, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_SundayDayCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.MondayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_MondayDayCode_Header", "Monday Day Code"), false, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_MondayDayCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_TuesdayDayCode_Header", "Tuesday Day Code"), false, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_TuesdayDayCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_WednesdayDayCode_Header", "Wednesday Day Code"), false, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_WednesdayDayCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_ThursdayDayCode_Header", "Thursday Day Code"), false, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_ThursdayDayCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.FridayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_FridayDayCode_Header", "Friday Day Code"), false, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_FridayDayCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_SaturdayDayCode_Header", "Saturday Day Code"), false, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehavior_PanelLoadDataPDSA_SaturdayDayCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.EntityId = Guid.Empty;
      Entity.EntityName = string.Empty;
      Entity.SundayDayCode = 0;
      Entity.MondayDayCode = 0;
      Entity.TuesdayDayCode = 0;
      Entity.WednesdayDayCode = 0;
      Entity.ThursdayDayCode = 0;
      Entity.FridayDayCode = 0;
      Entity.SaturdayDayCode = 0;

      Entity.ResetAllIsDirtyProperties();
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
        InitProperties();
      
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityName).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).Value = Entity.SundayDayCode;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).Value = Entity.MondayDayCode;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).Value = Entity.TuesdayDayCode;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).Value = Entity.WednesdayDayCode;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).Value = Entity.ThursdayDayCode;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).Value = Entity.FridayDayCode;
      if(!Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).Value = Entity.SaturdayDayCode;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityName).GetAsString();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).IsNull == false)
        Entity.SundayDayCode = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).GetAsShort();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).IsNull == false)
        Entity.MondayDayCode = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).GetAsShort();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).IsNull == false)
        Entity.TuesdayDayCode = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).GetAsShort();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).IsNull == false)
        Entity.WednesdayDayCode = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).GetAsShort();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).IsNull == false)
        Entity.ThursdayDayCode = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).GetAsShort();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).IsNull == false)
        Entity.FridayDayCode = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).GetAsShort();
      if(Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).IsNull == false)
        Entity.SaturdayDayCode = Properties.GetByName(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateTypeDefaultBehavior_PanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
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
    }
    #endregion
  }
}
