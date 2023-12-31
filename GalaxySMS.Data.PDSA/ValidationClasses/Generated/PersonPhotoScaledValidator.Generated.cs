using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonPhotoScaledPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonPhotoScaledPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonPhotoScaledPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonPhotoScaledPDSA Entity
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
    /// Clones the current PersonPhotoScaledPDSA
    /// </summary>
    /// <returns>A cloned PersonPhotoScaledPDSA object</returns>
    public PersonPhotoScaledPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonPhotoScaledPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonPhotoScaledPDSA entity to clone</param>
    /// <returns>A cloned PersonPhotoScaledPDSA object</returns>
    public PersonPhotoScaledPDSA CloneEntity(PersonPhotoScaledPDSA entityToClone)
    {
      PersonPhotoScaledPDSA newEntity = new PersonPhotoScaledPDSA();

      newEntity.PersonPhotoScaledUid = entityToClone.PersonPhotoScaledUid;
      newEntity.PersonPhotoUid = entityToClone.PersonPhotoUid;
      newEntity.UniqueFilename = entityToClone.UniqueFilename;
      newEntity.Tag = entityToClone.Tag;
      newEntity.PhotoImage = entityToClone.PhotoImage;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.PublicUrl = entityToClone.PublicUrl;

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
      
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoScaledUid, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PersonPhotoScaledUid_Header", "Person Photo Scaled Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PersonPhotoScaledUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoUid, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PersonPhotoUid_Header", "Person Photo Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PersonPhotoUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.UniqueFilename, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UniqueFilename_Header", "Unique Filename"), true, typeof(string), 255, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UniqueFilename_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_PersonPhotoScaledPDSA_Tag_Header", "Tag"), true, typeof(string), 65, GetResourceMessage("GCS_PersonPhotoScaledPDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.PhotoImage, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PhotoImage_Header", "Photo Image"), true, typeof(byte[]), 2147483647, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PhotoImage_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonPhotoScaledPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_PersonPhotoScaledPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonPhotoScaledPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonPhotoScaledPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonPhotoScaledPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonPhotoScaledPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonPhotoScaledPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonPhotoScaledPDSAValidator.ColumnNames.PublicUrl, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PublicUrl_Header", "Public Url"), false, typeof(string), 2048, GetResourceMessage("GCS_PersonPhotoScaledPDSA_PublicUrl_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonPhotoScaledUid = Guid.Empty;
      Entity.PersonPhotoUid = Guid.Empty;
      Entity.UniqueFilename = string.Empty;
      Entity.Tag = string.Empty;
      Entity.PhotoImage = null;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.PublicUrl = string.Empty;

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
      
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoScaledUid).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoScaledUid).Value = Entity.PersonPhotoScaledUid;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoUid).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoUid).Value = Entity.PersonPhotoUid;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UniqueFilename).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UniqueFilename).Value = Entity.UniqueFilename;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.Tag).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PhotoImage).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PhotoImage).Value = Entity.PhotoImage;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PublicUrl).SetAsNull)
        Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PublicUrl).Value = Entity.PublicUrl;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoScaledUid).IsNull == false)
        Entity.PersonPhotoScaledUid = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoScaledUid).GetAsGuid();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoUid).IsNull == false)
        Entity.PersonPhotoUid = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PersonPhotoUid).GetAsGuid();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UniqueFilename).IsNull == false)
        Entity.UniqueFilename = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UniqueFilename).GetAsString();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.Tag).GetAsString();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PhotoImage).IsNull == false)
        Entity.PhotoImage = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PhotoImage).GetAsByteArray();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PublicUrl).IsNull == false)
        Entity.PublicUrl = Properties.GetByName(PersonPhotoScaledPDSAValidator.ColumnNames.PublicUrl).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonPhotoScaledPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonPhotoScaledUid'
    /// </summary>
    public static string PersonPhotoScaledUid = "PersonPhotoScaledUid";
    /// <summary>
    /// Returns 'PersonPhotoUid'
    /// </summary>
    public static string PersonPhotoUid = "PersonPhotoUid";
    /// <summary>
    /// Returns 'UniqueFilename'
    /// </summary>
    public static string UniqueFilename = "UniqueFilename";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
    /// <summary>
    /// Returns 'PhotoImage'
    /// </summary>
    public static string PhotoImage = "PhotoImage";
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
    /// <summary>
    /// Returns 'PublicUrl'
    /// </summary>
    public static string PublicUrl = "PublicUrl";
    }
    #endregion
  }
}
