using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonListPropertyItemUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonListPropertyItemUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonListPropertyItemUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonListPropertyItemUniquePDSA Entity
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
    /// Clones the current IsPersonListPropertyItemUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonListPropertyItemUniquePDSA object</returns>
    public IsPersonListPropertyItemUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonListPropertyItemUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonListPropertyItemUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonListPropertyItemUniquePDSA object</returns>
    public IsPersonListPropertyItemUniquePDSA CloneEntity(IsPersonListPropertyItemUniquePDSA entityToClone)
    {
      IsPersonListPropertyItemUniquePDSA newEntity = new IsPersonListPropertyItemUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonListPropertyItemUid, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_PersonListPropertyItemUid_Header", "Person List Property Item Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_PersonListPropertyItemUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_UserDefinedListPropertyItemUid_Header", "User Defined List Property Item Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_UserDefinedListPropertyItemUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonListPropertyItemUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonListPropertyItemUid).Value = Entity.PersonListPropertyItemUid;
      this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid).Value = Entity.UserDefinedListPropertyItemUid;
      this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonListPropertyItemUid).IsNull == false)
        Entity.PersonListPropertyItemUid = this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonListPropertyItemUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid).IsNull == false)
        Entity.UserDefinedListPropertyItemUid = this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonListPropertyItemUniquePDSA class.
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
    /// Returns '@PersonListPropertyItemUid'
    /// </summary>
    public static string PersonListPropertyItemUid = "@PersonListPropertyItemUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@UserDefinedListPropertyItemUid'
    /// </summary>
    public static string UserDefinedListPropertyItemUid = "@UserDefinedListPropertyItemUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonListPropertyItemUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonListPropertyItemUid'
    /// </summary>
    public static string PersonListPropertyItemUid = "@PersonListPropertyItemUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@UserDefinedListPropertyItemUid'
    /// </summary>
    public static string UserDefinedListPropertyItemUid = "@UserDefinedListPropertyItemUid";
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
