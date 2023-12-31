using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonalAccessGroupAccessPortalTempPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonalAccessGroupAccessPortalTempPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonalAccessGroupAccessPortalTempPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonalAccessGroupAccessPortalTempPDSA Entity
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
    /// Clones the current PersonalAccessGroupAccessPortalTempPDSA
    /// </summary>
    /// <returns>A cloned PersonalAccessGroupAccessPortalTempPDSA object</returns>
    public PersonalAccessGroupAccessPortalTempPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonalAccessGroupAccessPortalTempPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonalAccessGroupAccessPortalTempPDSA entity to clone</param>
    /// <returns>A cloned PersonalAccessGroupAccessPortalTempPDSA object</returns>
    public PersonalAccessGroupAccessPortalTempPDSA CloneEntity(PersonalAccessGroupAccessPortalTempPDSA entityToClone)
    {
      PersonalAccessGroupAccessPortalTempPDSA newEntity = new PersonalAccessGroupAccessPortalTempPDSA();

      newEntity.PersonalAccessGroupAccessPortalUid = entityToClone.PersonalAccessGroupAccessPortalUid;
      newEntity.PersonPersonalAccessGroupUid = entityToClone.PersonPersonalAccessGroupUid;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;

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
      
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonalAccessGroupAccessPortalUid, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_PersonalAccessGroupAccessPortalUid_Header", "Personal Access Group Access Portal Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_PersonalAccessGroupAccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonPersonalAccessGroupUid, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_PersonPersonalAccessGroupUid_Header", "Person Personal Access Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_PersonPersonalAccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.AccessPortalUid, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_AccessPortalUid_Header", "Access Portal Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonalAccessGroupAccessPortalTempPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonalAccessGroupAccessPortalUid = Guid.Empty;
      Entity.PersonPersonalAccessGroupUid = Guid.Empty;
      Entity.AccessPortalUid = Guid.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;

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
      
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonalAccessGroupAccessPortalUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonalAccessGroupAccessPortalUid).Value = Entity.PersonalAccessGroupAccessPortalUid;
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonPersonalAccessGroupUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonPersonalAccessGroupUid).Value = Entity.PersonPersonalAccessGroupUid;
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonalAccessGroupAccessPortalUid).IsNull == false)
        Entity.PersonalAccessGroupAccessPortalUid = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonalAccessGroupAccessPortalUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonPersonalAccessGroupUid).IsNull == false)
        Entity.PersonPersonalAccessGroupUid = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.PersonPersonalAccessGroupUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonalAccessGroupAccessPortalTempPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonalAccessGroupAccessPortalTempPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonalAccessGroupAccessPortalUid'
    /// </summary>
    public static string PersonalAccessGroupAccessPortalUid = "PersonalAccessGroupAccessPortalUid";
    /// <summary>
    /// Returns 'PersonPersonalAccessGroupUid'
    /// </summary>
    public static string PersonPersonalAccessGroupUid = "PersonPersonalAccessGroupUid";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    }
    #endregion
  }
}
