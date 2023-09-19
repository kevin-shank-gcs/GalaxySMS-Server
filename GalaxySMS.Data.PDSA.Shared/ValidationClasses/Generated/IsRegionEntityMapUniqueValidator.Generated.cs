using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRegionEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRegionEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRegionEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRegionEntityMapUniquePDSA Entity
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
    /// Clones the current IsRegionEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRegionEntityMapUniquePDSA object</returns>
    public IsRegionEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRegionEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRegionEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRegionEntityMapUniquePDSA object</returns>
    public IsRegionEntityMapUniquePDSA CloneEntity(IsRegionEntityMapUniquePDSA entityToClone)
    {
      IsRegionEntityMapUniquePDSA newEntity = new IsRegionEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionEntityMapUid, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_RegionEntityMapUid_Header", "Region Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_RegionEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionUid, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_RegionUid_Header", "Region Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_RegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRegionEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionEntityMapUid).Value = Entity.RegionEntityMapUid;
      this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionUid).Value = Entity.RegionUid;
      this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionEntityMapUid).IsNull == false)
        Entity.RegionEntityMapUid = this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionUid).IsNull == false)
        Entity.RegionUid = this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RegionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRegionEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRegionEntityMapUniquePDSA class.
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
    /// Returns '@RegionEntityMapUid'
    /// </summary>
    public static string RegionEntityMapUid = "@RegionEntityMapUid";
    /// <summary>
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
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
    /// Contains static string properties that represent the name of each property in the IsRegionEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RegionEntityMapUid'
    /// </summary>
    public static string RegionEntityMapUid = "@RegionEntityMapUid";
    /// <summary>
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
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
