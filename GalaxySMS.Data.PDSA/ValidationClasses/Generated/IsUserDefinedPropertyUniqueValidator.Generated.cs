using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsUserDefinedPropertyUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsUserDefinedPropertyUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsUserDefinedPropertyUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsUserDefinedPropertyUniquePDSA Entity
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
    /// Clones the current IsUserDefinedPropertyUniquePDSA
    /// </summary>
    /// <returns>A cloned IsUserDefinedPropertyUniquePDSA object</returns>
    public IsUserDefinedPropertyUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsUserDefinedPropertyUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsUserDefinedPropertyUniquePDSA entity to clone</param>
    /// <returns>A cloned IsUserDefinedPropertyUniquePDSA object</returns>
    public IsUserDefinedPropertyUniquePDSA CloneEntity(IsUserDefinedPropertyUniquePDSA entityToClone)
    {
      IsUserDefinedPropertyUniquePDSA newEntity = new IsUserDefinedPropertyUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.PropertyName, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_PropertyName_Header", "Property Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_PropertyName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.SchemaName, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_SchemaName_Header", "Schema Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_SchemaName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.TableName, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_TableName_Header", "Table Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_TableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.ColumnName, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_ColumnName_Header", "Column Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_ColumnName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UniquePropertyName, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_UniquePropertyName_Header", "Unique Property Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_UniquePropertyName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedPropertyUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.PropertyName).Value = Entity.PropertyName;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.SchemaName).Value = Entity.SchemaName;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UniquePropertyName).Value = Entity.UniquePropertyName;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.PropertyName).IsNull == false)
        Entity.PropertyName = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.PropertyName).GetAsString();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.SchemaName).IsNull == false)
        Entity.SchemaName = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.SchemaName).GetAsString();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.TableName).IsNull == false)
        Entity.TableName = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.TableName).GetAsString();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.ColumnName).IsNull == false)
        Entity.ColumnName = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.ColumnName).GetAsString();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UniquePropertyName).IsNull == false)
        Entity.UniquePropertyName = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.UniquePropertyName).GetAsString();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsUserDefinedPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedPropertyUniquePDSA class.
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
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@PropertyName'
    /// </summary>
    public static string PropertyName = "@PropertyName";
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
    /// Returns '@UniquePropertyName'
    /// </summary>
    public static string UniquePropertyName = "@UniquePropertyName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedPropertyUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@PropertyName'
    /// </summary>
    public static string PropertyName = "@PropertyName";
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
    /// Returns '@UniquePropertyName'
    /// </summary>
    public static string UniquePropertyName = "@UniquePropertyName";
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
