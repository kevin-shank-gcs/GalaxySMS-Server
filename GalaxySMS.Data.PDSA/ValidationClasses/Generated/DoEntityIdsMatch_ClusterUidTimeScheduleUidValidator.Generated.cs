using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA Entity
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
    /// Clones the current DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA
    /// </summary>
    /// <returns>A cloned DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA object</returns>
    public DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA
    /// </summary>
    /// <param name="entityToClone">The DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA entity to clone</param>
    /// <returns>A cloned DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA object</returns>
    public DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA CloneEntity(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA entityToClone)
    {
      DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA newEntity = new DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA();

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
      
      props.Add(PDSAProperty.Create(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.PreventSystemEntityMatches, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_PreventSystemEntityMatches_Header", "Prevent System Entity Matches"), false, typeof(bool), 0, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_PreventSystemEntityMatches_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_Result_Header", "Result"), false, typeof(bool), 0, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.PreventSystemEntityMatches).Value = Entity.PreventSystemEntityMatches;
      this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.PreventSystemEntityMatches).IsNull == false)
        Entity.PreventSystemEntityMatches = this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.PreventSystemEntityMatches).GetAsBool();
      if(this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.Result).GetAsBool();
      if(this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA class.
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
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@PreventSystemEntityMatches'
    /// </summary>
    public static string PreventSystemEntityMatches = "@PreventSystemEntityMatches";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@PreventSystemEntityMatches'
    /// </summary>
    public static string PreventSystemEntityMatches = "@PreventSystemEntityMatches";
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
