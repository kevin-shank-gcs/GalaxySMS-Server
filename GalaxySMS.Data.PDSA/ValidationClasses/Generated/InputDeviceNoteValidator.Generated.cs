using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputDeviceNotePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDeviceNotePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputDeviceNotePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputDeviceNotePDSA Entity
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
    /// Clones the current InputDeviceNotePDSA
    /// </summary>
    /// <returns>A cloned InputDeviceNotePDSA object</returns>
    public InputDeviceNotePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputDeviceNotePDSA
    /// </summary>
    /// <param name="entityToClone">The InputDeviceNotePDSA entity to clone</param>
    /// <returns>A cloned InputDeviceNotePDSA object</returns>
    public InputDeviceNotePDSA CloneEntity(InputDeviceNotePDSA entityToClone)
    {
      InputDeviceNotePDSA newEntity = new InputDeviceNotePDSA();

      newEntity.InputDeviceNoteUid = entityToClone.InputDeviceNoteUid;
      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
      newEntity.NoteUid = entityToClone.NoteUid;
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
      
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceNoteUid, GetResourceMessage("GCS_InputDeviceNotePDSA_InputDeviceNoteUid_Header", "Input Device Note Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceNotePDSA_InputDeviceNoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceUid, GetResourceMessage("GCS_InputDeviceNotePDSA_InputDeviceUid_Header", "Input Device Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceNotePDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.NoteUid, GetResourceMessage("GCS_InputDeviceNotePDSA_NoteUid_Header", "Note Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceNotePDSA_NoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_InputDeviceNotePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputDeviceNotePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_InputDeviceNotePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputDeviceNotePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_InputDeviceNotePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputDeviceNotePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_InputDeviceNotePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputDeviceNotePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceNotePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_InputDeviceNotePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_InputDeviceNotePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputDeviceNoteUid = Guid.Empty;
      Entity.InputDeviceUid = Guid.Empty;
      Entity.NoteUid = Guid.Empty;
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
      
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceNoteUid).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceNoteUid).Value = Entity.InputDeviceNoteUid;
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceUid).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.NoteUid).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.NoteUid).Value = Entity.NoteUid;
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceNoteUid).IsNull == false)
        Entity.InputDeviceNoteUid = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceNoteUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.NoteUid).IsNull == false)
        Entity.NoteUid = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.NoteUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(InputDeviceNotePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDeviceNotePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputDeviceNoteUid'
    /// </summary>
    public static string InputDeviceNoteUid = "InputDeviceNoteUid";
    /// <summary>
    /// Returns 'InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "InputDeviceUid";
    /// <summary>
    /// Returns 'NoteUid'
    /// </summary>
    public static string NoteUid = "NoteUid";
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
