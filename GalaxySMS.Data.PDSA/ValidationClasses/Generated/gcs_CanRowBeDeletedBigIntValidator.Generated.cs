using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_CanRowBeDeletedBigIntPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_CanRowBeDeletedBigIntPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_CanRowBeDeletedBigIntPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_CanRowBeDeletedBigIntPDSA Entity
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
    /// Clones the current gcs_CanRowBeDeletedBigIntPDSA
    /// </summary>
    /// <returns>A cloned gcs_CanRowBeDeletedBigIntPDSA object</returns>
    public gcs_CanRowBeDeletedBigIntPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_CanRowBeDeletedBigIntPDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_CanRowBeDeletedBigIntPDSA entity to clone</param>
    /// <returns>A cloned gcs_CanRowBeDeletedBigIntPDSA object</returns>
    public gcs_CanRowBeDeletedBigIntPDSA CloneEntity(gcs_CanRowBeDeletedBigIntPDSA entityToClone)
    {
      gcs_CanRowBeDeletedBigIntPDSA newEntity = new gcs_CanRowBeDeletedBigIntPDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.SchemaName, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_SchemaName_Header", "Schema Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_SchemaName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.TableName, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_TableName_Header", "Table Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_TableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.ColumnName, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_ColumnName_Header", "Column Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_ColumnName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.BigIntValue, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_BigIntValue_Header", "Big Int Value"), false, typeof(long), 0, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_BigIntValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.Result, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_CanRowBeDeletedBigIntPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.SchemaName).Value = Entity.SchemaName;
      this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.BigIntValue).Value = Entity.BigIntValue;
      this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.SchemaName).IsNull == false)
        Entity.SchemaName = this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.SchemaName).GetAsString();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.TableName).IsNull == false)
        Entity.TableName = this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.TableName).GetAsString();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.ColumnName).IsNull == false)
        Entity.ColumnName = this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.ColumnName).GetAsString();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.BigIntValue).IsNull == false)
        Entity.BigIntValue = this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.BigIntValue).GetAsLong();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_CanRowBeDeletedBigIntPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_CanRowBeDeletedBigIntPDSA class.
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
    /// Returns '@BigIntValue'
    /// </summary>
    public static string BigIntValue = "@BigIntValue";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_CanRowBeDeletedBigIntPDSA class.
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
    /// Returns '@BigIntValue'
    /// </summary>
    public static string BigIntValue = "@BigIntValue";
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
