using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsBadgeSystemTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsBadgeSystemTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsBadgeSystemTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsBadgeSystemTypeUniquePDSA Entity
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
    /// Clones the current IsBadgeSystemTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsBadgeSystemTypeUniquePDSA object</returns>
    public IsBadgeSystemTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsBadgeSystemTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsBadgeSystemTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsBadgeSystemTypeUniquePDSA object</returns>
    public IsBadgeSystemTypeUniquePDSA CloneEntity(IsBadgeSystemTypeUniquePDSA entityToClone)
    {
      IsBadgeSystemTypeUniquePDSA newEntity = new IsBadgeSystemTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.BadgeSystemTypeUid, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_BadgeSystemTypeUid_Header", "Badge System Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_BadgeSystemTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Name, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_Name_Header", "Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_Name_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.TypeCode, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_TypeCode_Header", "Type Code"), false, typeof(string), 8000, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_TypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsBadgeSystemTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.BadgeSystemTypeUid).Value = Entity.BadgeSystemTypeUid;
      this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Name).Value = Entity.Name;
      this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.TypeCode).Value = Entity.TypeCode;
      this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.BadgeSystemTypeUid).IsNull == false)
        Entity.BadgeSystemTypeUid = this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.BadgeSystemTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Name).IsNull == false)
        Entity.Name = this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Name).GetAsString();
      if(this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.TypeCode).IsNull == false)
        Entity.TypeCode = this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.TypeCode).GetAsString();
      if(this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsBadgeSystemTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsBadgeSystemTypeUniquePDSA class.
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
    /// Returns '@BadgeSystemTypeUid'
    /// </summary>
    public static string BadgeSystemTypeUid = "@BadgeSystemTypeUid";
    /// <summary>
    /// Returns '@Name'
    /// </summary>
    public static string Name = "@Name";
    /// <summary>
    /// Returns '@TypeCode'
    /// </summary>
    public static string TypeCode = "@TypeCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsBadgeSystemTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@BadgeSystemTypeUid'
    /// </summary>
    public static string BadgeSystemTypeUid = "@BadgeSystemTypeUid";
    /// <summary>
    /// Returns '@Name'
    /// </summary>
    public static string Name = "@Name";
    /// <summary>
    /// Returns '@TypeCode'
    /// </summary>
    public static string TypeCode = "@TypeCode";
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
