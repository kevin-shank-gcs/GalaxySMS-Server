using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_DoesRowExistPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_DoesRowExistPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_DoesRowExistPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_DoesRowExistPDSA Entity
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
    /// Clones the current gcs_DoesRowExistPDSA
    /// </summary>
    /// <returns>A cloned gcs_DoesRowExistPDSA object</returns>
    public gcs_DoesRowExistPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_DoesRowExistPDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_DoesRowExistPDSA entity to clone</param>
    /// <returns>A cloned gcs_DoesRowExistPDSA object</returns>
    public gcs_DoesRowExistPDSA CloneEntity(gcs_DoesRowExistPDSA entityToClone)
    {
      gcs_DoesRowExistPDSA newEntity = new gcs_DoesRowExistPDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_DoesRowExistPDSAValidator.ParameterNames.SchemaName, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_SchemaName_Header", "Schema Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_SchemaName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesRowExistPDSAValidator.ParameterNames.TableName, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_TableName_Header", "Table Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_TableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesRowExistPDSAValidator.ParameterNames.ColumnName, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_ColumnName_Header", "Column Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_ColumnName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesRowExistPDSAValidator.ParameterNames.GuidValue, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_GuidValue_Header", "Guid Value"), false, typeof(Guid), 0, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_GuidValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesRowExistPDSAValidator.ParameterNames.Result, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesRowExistPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_DoesRowExistPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.SchemaName).Value = Entity.SchemaName;
      this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.GuidValue).Value = Entity.GuidValue;
      this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.SchemaName).IsNull == false)
        Entity.SchemaName = this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.SchemaName).GetAsString();
      if(this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.TableName).IsNull == false)
        Entity.TableName = this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.TableName).GetAsString();
      if(this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.ColumnName).IsNull == false)
        Entity.ColumnName = this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.ColumnName).GetAsString();
      if(this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.GuidValue).IsNull == false)
        Entity.GuidValue = this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.GuidValue).GetAsGuid();
      if(this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_DoesRowExistPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_DoesRowExistPDSA class.
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
    /// Returns '@GuidValue'
    /// </summary>
    public static string GuidValue = "@GuidValue";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_DoesRowExistPDSA class.
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
    /// Returns '@GuidValue'
    /// </summary>
    public static string GuidValue = "@GuidValue";
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
