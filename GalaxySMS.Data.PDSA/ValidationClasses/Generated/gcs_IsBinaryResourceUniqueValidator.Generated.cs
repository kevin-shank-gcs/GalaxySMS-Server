using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsBinaryResourceUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsBinaryResourceUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsBinaryResourceUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsBinaryResourceUniquePDSA Entity
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
    /// Clones the current gcs_IsBinaryResourceUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsBinaryResourceUniquePDSA object</returns>
    public gcs_IsBinaryResourceUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsBinaryResourceUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsBinaryResourceUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsBinaryResourceUniquePDSA object</returns>
    public gcs_IsBinaryResourceUniquePDSA CloneEntity(gcs_IsBinaryResourceUniquePDSA entityToClone)
    {
      gcs_IsBinaryResourceUniquePDSA newEntity = new gcs_IsBinaryResourceUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_BinaryResourceUid_Header", "Binary Resource Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_BinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_DataType_Header", "Data Type"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_DataType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_Category_Header", "Category"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_Category_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_Tag_Header", "Tag"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType).Value = Entity.DataType;
      this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category).Value = Entity.Category;
      this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag).Value = Entity.Tag;
      this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType).IsNull == false)
        Entity.DataType = this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType).GetAsString();
      if(this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category).IsNull == false)
        Entity.Category = this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category).GetAsString();
      if(this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag).IsNull == false)
        Entity.Tag = this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag).GetAsString();
      if(this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsBinaryResourceUniquePDSA class.
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
    /// Returns '@BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "@BinaryResourceUid";
    /// <summary>
    /// Returns '@DataType'
    /// </summary>
    public static string DataType = "@DataType";
    /// <summary>
    /// Returns '@Category'
    /// </summary>
    public static string Category = "@Category";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsBinaryResourceUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "@BinaryResourceUid";
    /// <summary>
    /// Returns '@DataType'
    /// </summary>
    public static string DataType = "@DataType";
    /// <summary>
    /// Returns '@Category'
    /// </summary>
    public static string Category = "@Category";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
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
