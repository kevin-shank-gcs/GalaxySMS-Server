using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_GetRowCountFromTableByNVarCharColumnValuePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_GetRowCountFromTableByNVarCharColumnValuePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_GetRowCountFromTableByNVarCharColumnValuePDSA Entity
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
    /// Clones the current gcs_GetRowCountFromTableByNVarCharColumnValuePDSA
    /// </summary>
    /// <returns>A cloned gcs_GetRowCountFromTableByNVarCharColumnValuePDSA object</returns>
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_GetRowCountFromTableByNVarCharColumnValuePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_GetRowCountFromTableByNVarCharColumnValuePDSA entity to clone</param>
    /// <returns>A cloned gcs_GetRowCountFromTableByNVarCharColumnValuePDSA object</returns>
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSA CloneEntity(gcs_GetRowCountFromTableByNVarCharColumnValuePDSA entityToClone)
    {
      gcs_GetRowCountFromTableByNVarCharColumnValuePDSA newEntity = new gcs_GetRowCountFromTableByNVarCharColumnValuePDSA();

      newEntity.Result = entityToClone.Result;

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
      
      props.Add(PDSAProperty.Create(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_SchemaName_Header", "Schema Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_SchemaName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_TableName_Header", "Table Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_TableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_ColumnName_Header", "Column Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_ColumnName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_Value_Header", "Value"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_Value_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Result, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName).Value = Entity.SchemaName;
      this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value).Value = Entity.Value;
      this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName).IsNull == false)
        Entity.SchemaName = this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName).GetAsString();
      if(this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName).IsNull == false)
        Entity.TableName = this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName).GetAsString();
      if(this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName).IsNull == false)
        Entity.ColumnName = this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName).GetAsString();
      if(this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value).IsNull == false)
        Entity.Value = this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value).GetAsString();
      if(this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_GetRowCountFromTableByNVarCharColumnValuePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Result'
    /// </summary>
    public static string Result = "Result";
    /// <summary>
    /// Returns '@SchemaName'
    /// </summary>
    public static string SchemaName = "@SchemaName";
    /// <summary>
    /// Returns '@TableName'
    /// </summary>
    public static string TableName = "@TableName";
    /// <summary>
    /// Returns '@ColumnName'
    /// </summary>
    public static string ColumnName = "@ColumnName";
    /// <summary>
    /// Returns '@Value'
    /// </summary>
    public static string Value = "@Value";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_GetRowCountFromTableByNVarCharColumnValuePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@SchemaName'
    /// </summary>
    public static string SchemaName = "@SchemaName";
    /// <summary>
    /// Returns '@TableName'
    /// </summary>
    public static string TableName = "@TableName";
    /// <summary>
    /// Returns '@ColumnName'
    /// </summary>
    public static string ColumnName = "@ColumnName";
    /// <summary>
    /// Returns '@Value'
    /// </summary>
    public static string Value = "@Value";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
