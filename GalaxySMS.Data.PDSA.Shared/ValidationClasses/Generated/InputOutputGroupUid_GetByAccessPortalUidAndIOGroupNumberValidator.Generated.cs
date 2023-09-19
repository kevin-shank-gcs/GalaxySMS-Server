using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA Entity
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
    /// Clones the current InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA
    /// </summary>
    /// <returns>A cloned InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA object</returns>
    public InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA
    /// </summary>
    /// <param name="entityToClone">The InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA entity to clone</param>
    /// <returns>A cloned InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA object</returns>
    public InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA CloneEntity(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA entityToClone)
    {
      InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA newEntity = new InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA();

      newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;

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
      
      props.Add(PDSAProperty.Create(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.accessPortalUid, GetResourceMessage("GCS_InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA_accessPortalUid_Header", "access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA_accessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber, GetResourceMessage("GCS_InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA_ioGroupNumber_Header", "io Group Number"), false, typeof(int), 0, GetResourceMessage("GCS_InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA_ioGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.accessPortalUid).Value = Entity.accessPortalUid;
      this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).Value = Entity.ioGroupNumber;
      this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.accessPortalUid).IsNull == false)
        Entity.accessPortalUid = this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.accessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).IsNull == false)
        Entity.ioGroupNumber = this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).GetAsInteger();
      if(this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "InputOutputGroupUid";
    /// <summary>
    /// Returns '@accessPortalUid'
    /// </summary>
    public static string accessPortalUid = "@accessPortalUid";
    /// <summary>
    /// Returns '@ioGroupNumber'
    /// </summary>
    public static string ioGroupNumber = "@ioGroupNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@accessPortalUid'
    /// </summary>
    public static string accessPortalUid = "@accessPortalUid";
    /// <summary>
    /// Returns '@ioGroupNumber'
    /// </summary>
    public static string ioGroupNumber = "@ioGroupNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
