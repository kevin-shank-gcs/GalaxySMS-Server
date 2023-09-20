using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GetTableColumnInformationPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GetTableColumnInformationPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GetTableColumnInformationPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GetTableColumnInformationPDSA Entity
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
    /// Clones the current GetTableColumnInformationPDSA
    /// </summary>
    /// <returns>A cloned GetTableColumnInformationPDSA object</returns>
    public GetTableColumnInformationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GetTableColumnInformationPDSA
    /// </summary>
    /// <param name="entityToClone">The GetTableColumnInformationPDSA entity to clone</param>
    /// <returns>A cloned GetTableColumnInformationPDSA object</returns>
    public GetTableColumnInformationPDSA CloneEntity(GetTableColumnInformationPDSA entityToClone)
    {
      GetTableColumnInformationPDSA newEntity = new GetTableColumnInformationPDSA();

      newEntity.DatabaseName = entityToClone.DatabaseName;
      newEntity.TableSchema = entityToClone.TableSchema;
      newEntity.TableName = entityToClone.TableName;
      newEntity.ColumnName = entityToClone.ColumnName;
      newEntity.IsNullable = entityToClone.IsNullable;
      newEntity.ColumnOrdinalPosition = entityToClone.ColumnOrdinalPosition;
      newEntity.DefaultValue = entityToClone.DefaultValue;
      newEntity.DataType = entityToClone.DataType;
      newEntity.CharacterMaximumLength = entityToClone.CharacterMaximumLength;
      newEntity.NumericPrecision = entityToClone.NumericPrecision;
      newEntity.NumericPrecisionRadix = entityToClone.NumericPrecisionRadix;
      newEntity.NumericScale = entityToClone.NumericScale;
      newEntity.DateTimePrecision = entityToClone.DateTimePrecision;
      newEntity.IsComputed = entityToClone.IsComputed;

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
      
      props.Add(PDSAProperty.Create(GetTableColumnInformationPDSAValidator.ParameterNames.TableSchema, GetResourceMessage("GCS_GetTableColumnInformationPDSA_TableSchema_Header", "Table Schema"), false, typeof(string), 8000, GetResourceMessage("GCS_GetTableColumnInformationPDSA_TableSchema_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetTableColumnInformationPDSAValidator.ParameterNames.TableName, GetResourceMessage("GCS_GetTableColumnInformationPDSA_TableName_Header", "Table Name"), false, typeof(string), 8000, GetResourceMessage("GCS_GetTableColumnInformationPDSA_TableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetTableColumnInformationPDSAValidator.ParameterNames.ColumnName, GetResourceMessage("GCS_GetTableColumnInformationPDSA_ColumnName_Header", "Column Name"), false, typeof(string), 8000, GetResourceMessage("GCS_GetTableColumnInformationPDSA_ColumnName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetTableColumnInformationPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GetTableColumnInformationPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GetTableColumnInformationPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.TableSchema).Value = Entity.TableSchema;
      this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.TableSchema).IsNull == false)
        Entity.TableSchema = this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.TableSchema).GetAsString();
      if(this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.TableName).IsNull == false)
        Entity.TableName = this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.TableName).GetAsString();
      if(this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.ColumnName).IsNull == false)
        Entity.ColumnName = this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.ColumnName).GetAsString();
      if(this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GetTableColumnInformationPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetTableColumnInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DatabaseName'
    /// </summary>
    public static string DatabaseName = "DatabaseName";
    /// <summary>
    /// Returns 'TableSchema'
    /// </summary>
    public static string TableSchema = "TableSchema";
    /// <summary>
    /// Returns 'TableName'
    /// </summary>
    public static string TableName = "TableName";
    /// <summary>
    /// Returns 'ColumnName'
    /// </summary>
    public static string ColumnName = "ColumnName";
    /// <summary>
    /// Returns 'IsNullable'
    /// </summary>
    public static string IsNullable = "IsNullable";
    /// <summary>
    /// Returns 'ColumnOrdinalPosition'
    /// </summary>
    public static string ColumnOrdinalPosition = "ColumnOrdinalPosition";
    /// <summary>
    /// Returns 'DefaultValue'
    /// </summary>
    public static string DefaultValue = "DefaultValue";
    /// <summary>
    /// Returns 'DataType'
    /// </summary>
    public static string DataType = "DataType";
    /// <summary>
    /// Returns 'CharacterMaximumLength'
    /// </summary>
    public static string CharacterMaximumLength = "CharacterMaximumLength";
    /// <summary>
    /// Returns 'NumericPrecision'
    /// </summary>
    public static string NumericPrecision = "NumericPrecision";
    /// <summary>
    /// Returns 'NumericPrecisionRadix'
    /// </summary>
    public static string NumericPrecisionRadix = "NumericPrecisionRadix";
    /// <summary>
    /// Returns 'NumericScale'
    /// </summary>
    public static string NumericScale = "NumericScale";
    /// <summary>
    /// Returns 'DateTimePrecision'
    /// </summary>
    public static string DateTimePrecision = "DateTimePrecision";
    /// <summary>
    /// Returns 'IsComputed'
    /// </summary>
    public static string IsComputed = "IsComputed";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetTableColumnInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TableSchema'
    /// </summary>
    public static string TableSchema = "@TableSchema";
    /// <summary>
    /// Returns '@TableName'
    /// </summary>
    public static string TableName = "@TableName";
    /// <summary>
    /// Returns '@ColumnName'
    /// </summary>
    public static string ColumnName = "@ColumnName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
