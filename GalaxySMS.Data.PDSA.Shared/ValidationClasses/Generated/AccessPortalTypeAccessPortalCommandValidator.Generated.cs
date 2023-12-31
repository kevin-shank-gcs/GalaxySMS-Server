using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalTypeAccessPortalCommandPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalTypeAccessPortalCommandPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalTypeAccessPortalCommandPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalTypeAccessPortalCommandPDSA Entity
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
    /// Clones the current AccessPortalTypeAccessPortalCommandPDSA
    /// </summary>
    /// <returns>A cloned AccessPortalTypeAccessPortalCommandPDSA object</returns>
    public AccessPortalTypeAccessPortalCommandPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalTypeAccessPortalCommandPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalTypeAccessPortalCommandPDSA entity to clone</param>
    /// <returns>A cloned AccessPortalTypeAccessPortalCommandPDSA object</returns>
    public AccessPortalTypeAccessPortalCommandPDSA CloneEntity(AccessPortalTypeAccessPortalCommandPDSA entityToClone)
    {
      AccessPortalTypeAccessPortalCommandPDSA newEntity = new AccessPortalTypeAccessPortalCommandPDSA();

      newEntity.AccessPortalTypeAccessPortalCommandUid = entityToClone.AccessPortalTypeAccessPortalCommandUid;
      newEntity.AccessPortalCommandUid = entityToClone.AccessPortalCommandUid;
      newEntity.AccessPortalTypeUid = entityToClone.AccessPortalTypeUid;
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
      
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeAccessPortalCommandUid, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_AccessPortalTypeAccessPortalCommandUid_Header", "Access Portal Type Access Portal Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_AccessPortalTypeAccessPortalCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalCommandUid, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_AccessPortalCommandUid_Header", "Access Portal Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_AccessPortalCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeUid, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_AccessPortalTypeUid_Header", "Access Portal Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_AccessPortalTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalTypeAccessPortalCommandPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalTypeAccessPortalCommandUid = Guid.Empty;
      Entity.AccessPortalCommandUid = Guid.Empty;
      Entity.AccessPortalTypeUid = Guid.Empty;
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
      
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeAccessPortalCommandUid).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeAccessPortalCommandUid).Value = Entity.AccessPortalTypeAccessPortalCommandUid;
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalCommandUid).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalCommandUid).Value = Entity.AccessPortalCommandUid;
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeUid).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeUid).Value = Entity.AccessPortalTypeUid;
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeAccessPortalCommandUid).IsNull == false)
        Entity.AccessPortalTypeAccessPortalCommandUid = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeAccessPortalCommandUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalCommandUid).IsNull == false)
        Entity.AccessPortalCommandUid = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalCommandUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeUid).IsNull == false)
        Entity.AccessPortalTypeUid = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.AccessPortalTypeUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalTypeAccessPortalCommandPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalTypeAccessPortalCommandPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalTypeAccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalTypeAccessPortalCommandUid = "AccessPortalTypeAccessPortalCommandUid";
    /// <summary>
    /// Returns 'AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "AccessPortalCommandUid";
    /// <summary>
    /// Returns 'AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "AccessPortalTypeUid";
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
