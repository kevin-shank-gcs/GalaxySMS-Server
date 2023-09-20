using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonPropertyBagUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonPropertyBagUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonPropertyBagUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonPropertyBagUniquePDSA Entity
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
    /// Clones the current IsPersonPropertyBagUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonPropertyBagUniquePDSA object</returns>
    public IsPersonPropertyBagUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonPropertyBagUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonPropertyBagUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonPropertyBagUniquePDSA object</returns>
    public IsPersonPropertyBagUniquePDSA CloneEntity(IsPersonPropertyBagUniquePDSA entityToClone)
    {
      IsPersonPropertyBagUniquePDSA newEntity = new IsPersonPropertyBagUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonPropertyBagUid, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_PersonPropertyBagUid_Header", "Person Property Bag Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_PersonPropertyBagUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Tag, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_Tag_Header", "Tag"), false, typeof(string), 8000, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PropertyName, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_PropertyName_Header", "Property Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_PropertyName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonPropertyBagUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonPropertyBagUid).Value = Entity.PersonPropertyBagUid;
      this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Tag).Value = Entity.Tag;
      this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PropertyName).Value = Entity.PropertyName;
      this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonPropertyBagUid).IsNull == false)
        Entity.PersonPropertyBagUid = this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonPropertyBagUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Tag).IsNull == false)
        Entity.Tag = this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Tag).GetAsString();
      if(this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PropertyName).IsNull == false)
        Entity.PropertyName = this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.PropertyName).GetAsString();
      if(this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonPropertyBagUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPropertyBagUniquePDSA class.
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
    /// Returns '@PersonPropertyBagUid'
    /// </summary>
    public static string PersonPropertyBagUid = "@PersonPropertyBagUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
    /// <summary>
    /// Returns '@PropertyName'
    /// </summary>
    public static string PropertyName = "@PropertyName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPropertyBagUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonPropertyBagUid'
    /// </summary>
    public static string PersonPropertyBagUid = "@PersonPropertyBagUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
    /// <summary>
    /// Returns '@PropertyName'
    /// </summary>
    public static string PropertyName = "@PropertyName";
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
