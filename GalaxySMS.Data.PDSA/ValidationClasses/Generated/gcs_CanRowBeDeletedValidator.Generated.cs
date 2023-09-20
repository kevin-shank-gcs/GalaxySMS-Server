using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_CanRowBeDeletedPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_CanRowBeDeletedPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_CanRowBeDeletedPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_CanRowBeDeletedPDSA Entity
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
    /// Clones the current gcs_CanRowBeDeletedPDSA
    /// </summary>
    /// <returns>A cloned gcs_CanRowBeDeletedPDSA object</returns>
    public gcs_CanRowBeDeletedPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_CanRowBeDeletedPDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_CanRowBeDeletedPDSA entity to clone</param>
    /// <returns>A cloned gcs_CanRowBeDeletedPDSA object</returns>
    public gcs_CanRowBeDeletedPDSA CloneEntity(gcs_CanRowBeDeletedPDSA entityToClone)
    {
      gcs_CanRowBeDeletedPDSA newEntity = new gcs_CanRowBeDeletedPDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.SchemaName, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_SchemaName_Header", "Schema Name"), false, typeof(string), 8000, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_SchemaName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.TableName, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_TableName_Header", "Table Name"), true, typeof(string), 8000, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_TableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.ColumnName, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_ColumnName_Header", "Column Name"), true, typeof(string), 8000, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_ColumnName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.GuidValue, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_GuidValue_Header", "Guid Value"), true, typeof(Guid), 0, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_GuidValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.Result, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("dbo_gcs_CanRowBeDeletedPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.SchemaName).Value = Entity.SchemaName;
      this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.GuidValue).Value = Entity.GuidValue;
      this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.SchemaName).IsNull == false)
        Entity.SchemaName = this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.SchemaName).GetAsString();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.TableName).IsNull == false)
        Entity.TableName = this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.TableName).GetAsString();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.ColumnName).IsNull == false)
        Entity.ColumnName = this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.ColumnName).GetAsString();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.GuidValue).IsNull == false)
        Entity.GuidValue = this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.GuidValue).GetAsGuid();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_CanRowBeDeletedPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_CanRowBeDeletedPDSA class.
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
    /// Contains static string properties that represent the name of each property in the gcs_CanRowBeDeletedPDSA class.
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
