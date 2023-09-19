using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRegionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRegionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRegionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRegionUniquePDSA Entity
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
    /// Clones the current IsRegionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRegionUniquePDSA object</returns>
    public IsRegionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRegionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRegionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRegionUniquePDSA object</returns>
    public IsRegionUniquePDSA CloneEntity(IsRegionUniquePDSA entityToClone)
    {
      IsRegionUniquePDSA newEntity = new IsRegionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRegionUniquePDSAValidator.ParameterNames.RegionUid, GetResourceMessage("GCS_IsRegionUniquePDSA_RegionUid_Header", "Region Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRegionUniquePDSA_RegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionUniquePDSAValidator.ParameterNames.RegionName, GetResourceMessage("GCS_IsRegionUniquePDSA_RegionName_Header", "Region Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsRegionUniquePDSA_RegionName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionUniquePDSAValidator.ParameterNames.RegionId, GetResourceMessage("GCS_IsRegionUniquePDSA_RegionId_Header", "Region Id"), false, typeof(string), 8000, GetResourceMessage("GCS_IsRegionUniquePDSA_RegionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsRegionUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRegionUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRegionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRegionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRegionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRegionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionUid).Value = Entity.RegionUid;
      this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionName).Value = Entity.RegionName;
      this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionId).Value = Entity.RegionId;
      this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionUid).IsNull == false)
        Entity.RegionUid = this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionName).IsNull == false)
        Entity.RegionName = this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionName).GetAsString();
      if(this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionId).IsNull == false)
        Entity.RegionId = this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RegionId).GetAsString();
      if(this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRegionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRegionUniquePDSA class.
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
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
    /// <summary>
    /// Returns '@RegionName'
    /// </summary>
    public static string RegionName = "@RegionName";
    /// <summary>
    /// Returns '@RegionId'
    /// </summary>
    public static string RegionId = "@RegionId";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRegionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
    /// <summary>
    /// Returns '@RegionName'
    /// </summary>
    public static string RegionName = "@RegionName";
    /// <summary>
    /// Returns '@RegionId'
    /// </summary>
    public static string RegionId = "@RegionId";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
