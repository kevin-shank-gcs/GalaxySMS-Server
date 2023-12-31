using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyFlashImagePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyFlashImagePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyFlashImagePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyFlashImagePDSA Entity
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
    /// Clones the current GalaxyFlashImagePDSA
    /// </summary>
    /// <returns>A cloned GalaxyFlashImagePDSA object</returns>
    public GalaxyFlashImagePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyFlashImagePDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyFlashImagePDSA entity to clone</param>
    /// <returns>A cloned GalaxyFlashImagePDSA object</returns>
    public GalaxyFlashImagePDSA CloneEntity(GalaxyFlashImagePDSA entityToClone)
    {
      GalaxyFlashImagePDSA newEntity = new GalaxyFlashImagePDSA();

      newEntity.GalaxyFlashImageUid = entityToClone.GalaxyFlashImageUid;
      newEntity.GalaxyCpuModelUid = entityToClone.GalaxyCpuModelUid;
      newEntity.Package = entityToClone.Package;
      newEntity.Description = entityToClone.Description;
      newEntity.ImportedFilename = entityToClone.ImportedFilename;
      newEntity.FileDateTime = entityToClone.FileDateTime;
      newEntity.Checksum = entityToClone.Checksum;
      newEntity.Version = entityToClone.Version;
      newEntity.DataFormat = entityToClone.DataFormat;
      newEntity.Data = entityToClone.Data;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.GalaxyCpuModelTypeCode = entityToClone.GalaxyCpuModelTypeCode;

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
      
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyFlashImageUid, GetResourceMessage("GCS_GalaxyFlashImagePDSA_GalaxyFlashImageUid_Header", "Galaxy Flash Image Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyFlashImagePDSA_GalaxyFlashImageUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelUid, GetResourceMessage("GCS_GalaxyFlashImagePDSA_GalaxyCpuModelUid_Header", "Galaxy Cpu Model Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyFlashImagePDSA_GalaxyCpuModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.Package, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Package_Header", "Package"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Package_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Description_Header", "Description"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.ImportedFilename, GetResourceMessage("GCS_GalaxyFlashImagePDSA_ImportedFilename_Header", "Imported Filename"), true, typeof(string), 255, GetResourceMessage("GCS_GalaxyFlashImagePDSA_ImportedFilename_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.FileDateTime, GetResourceMessage("GCS_GalaxyFlashImagePDSA_FileDateTime_Header", "File Date Time"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyFlashImagePDSA_FileDateTime_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.Checksum, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Checksum_Header", "Checksum"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Checksum_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.Version, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Version_Header", "Version"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Version_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.DataFormat, GetResourceMessage("GCS_GalaxyFlashImagePDSA_DataFormat_Header", "Data Format"), true, typeof(string), 20, GetResourceMessage("GCS_GalaxyFlashImagePDSA_DataFormat_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.Data, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Data_Header", "Data"), true, typeof(byte[]), 2147483647, GetResourceMessage("GCS_GalaxyFlashImagePDSA_Data_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyFlashImagePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyFlashImagePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyFlashImagePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyFlashImagePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyFlashImagePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyFlashImagePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyFlashImagePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyFlashImagePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyFlashImagePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyFlashImagePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelTypeCode, GetResourceMessage("GCS_GalaxyFlashImagePDSA_GalaxyCpuModelTypeCode_Header", "Galaxy Cpu Model Type Code"), false, typeof(string), 2147483647, GetResourceMessage("GCS_GalaxyFlashImagePDSA_GalaxyCpuModelTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyFlashImageUid = Guid.Empty;
      Entity.GalaxyCpuModelUid = Guid.Empty;
      Entity.Package = string.Empty;
      Entity.Description = string.Empty;
      Entity.ImportedFilename = string.Empty;
      Entity.FileDateTime = DateTimeOffset.Now;
      Entity.Checksum = string.Empty;
      Entity.Version = string.Empty;
      Entity.DataFormat = string.Empty;
      Entity.Data = null;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.GalaxyCpuModelTypeCode = string.Empty;

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
      
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyFlashImageUid).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyFlashImageUid).Value = Entity.GalaxyFlashImageUid;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelUid).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelUid).Value = Entity.GalaxyCpuModelUid;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Package).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Package).Value = Entity.Package;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ImportedFilename).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ImportedFilename).Value = Entity.ImportedFilename;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.FileDateTime).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.FileDateTime).Value = Entity.FileDateTime;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Checksum).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Checksum).Value = Entity.Checksum;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Version).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Version).Value = Entity.Version;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.DataFormat).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.DataFormat).Value = Entity.DataFormat;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Data).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Data).Value = Entity.Data;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelTypeCode).SetAsNull)
        Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelTypeCode).Value = Entity.GalaxyCpuModelTypeCode;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyFlashImageUid).IsNull == false)
        Entity.GalaxyFlashImageUid = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyFlashImageUid).GetAsGuid();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelUid).IsNull == false)
        Entity.GalaxyCpuModelUid = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Package).IsNull == false)
        Entity.Package = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Package).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ImportedFilename).IsNull == false)
        Entity.ImportedFilename = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ImportedFilename).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.FileDateTime).IsNull == false)
        Entity.FileDateTime = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.FileDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Checksum).IsNull == false)
        Entity.Checksum = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Checksum).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Version).IsNull == false)
        Entity.Version = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Version).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.DataFormat).IsNull == false)
        Entity.DataFormat = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.DataFormat).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Data).IsNull == false)
        Entity.Data = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.Data).GetAsByteArray();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelTypeCode).IsNull == false)
        Entity.GalaxyCpuModelTypeCode = Properties.GetByName(GalaxyFlashImagePDSAValidator.ColumnNames.GalaxyCpuModelTypeCode).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyFlashImagePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyFlashImageUid'
    /// </summary>
    public static string GalaxyFlashImageUid = "GalaxyFlashImageUid";
    /// <summary>
    /// Returns 'GalaxyCpuModelUid'
    /// </summary>
    public static string GalaxyCpuModelUid = "GalaxyCpuModelUid";
    /// <summary>
    /// Returns 'Package'
    /// </summary>
    public static string Package = "Package";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'ImportedFilename'
    /// </summary>
    public static string ImportedFilename = "ImportedFilename";
    /// <summary>
    /// Returns 'FileDateTime'
    /// </summary>
    public static string FileDateTime = "FileDateTime";
    /// <summary>
    /// Returns 'Checksum'
    /// </summary>
    public static string Checksum = "Checksum";
    /// <summary>
    /// Returns 'Version'
    /// </summary>
    public static string Version = "Version";
    /// <summary>
    /// Returns 'DataFormat'
    /// </summary>
    public static string DataFormat = "DataFormat";
    /// <summary>
    /// Returns 'Data'
    /// </summary>
    public static string Data = "Data";
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
    /// Returns 'GalaxyCpuModelTypeCode'
    /// </summary>
    public static string GalaxyCpuModelTypeCode = "GalaxyCpuModelTypeCode";
    }
    #endregion
  }
}
