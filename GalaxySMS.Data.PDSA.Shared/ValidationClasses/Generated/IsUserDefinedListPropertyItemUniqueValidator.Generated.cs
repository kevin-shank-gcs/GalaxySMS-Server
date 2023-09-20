using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsUserDefinedListPropertyItemUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsUserDefinedListPropertyItemUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsUserDefinedListPropertyItemUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsUserDefinedListPropertyItemUniquePDSA Entity
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
    /// Clones the current IsUserDefinedListPropertyItemUniquePDSA
    /// </summary>
    /// <returns>A cloned IsUserDefinedListPropertyItemUniquePDSA object</returns>
    public IsUserDefinedListPropertyItemUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsUserDefinedListPropertyItemUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsUserDefinedListPropertyItemUniquePDSA entity to clone</param>
    /// <returns>A cloned IsUserDefinedListPropertyItemUniquePDSA object</returns>
    public IsUserDefinedListPropertyItemUniquePDSA CloneEntity(IsUserDefinedListPropertyItemUniquePDSA entityToClone)
    {
      IsUserDefinedListPropertyItemUniquePDSA newEntity = new IsUserDefinedListPropertyItemUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_UserDefinedListPropertyItemUid_Header", "User Defined List Property Item Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_UserDefinedListPropertyItemUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Display, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_Display_Header", "Display"), false, typeof(string), 8000, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedListPropertyItemUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid).Value = Entity.UserDefinedListPropertyItemUid;
      this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid).IsNull == false)
        Entity.UserDefinedListPropertyItemUid = this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedListPropertyItemUid).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Display).IsNull == false)
        Entity.Display = this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Display).GetAsString();
      if(this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsUserDefinedListPropertyItemUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedListPropertyItemUniquePDSA class.
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
    /// Returns '@UserDefinedListPropertyItemUid'
    /// </summary>
    public static string UserDefinedListPropertyItemUid = "@UserDefinedListPropertyItemUid";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedListPropertyItemUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserDefinedListPropertyItemUid'
    /// </summary>
    public static string UserDefinedListPropertyItemUid = "@UserDefinedListPropertyItemUid";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
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
