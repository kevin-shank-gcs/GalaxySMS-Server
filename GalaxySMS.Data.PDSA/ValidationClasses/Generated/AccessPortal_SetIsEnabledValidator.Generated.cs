using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessPortal_SetIsEnabledPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortal_SetIsEnabledPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortal_SetIsEnabledPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortal_SetIsEnabledPDSA Entity
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
    /// Clones the current AccessPortal_SetIsEnabledPDSA
    /// </summary>
    /// <returns>A cloned AccessPortal_SetIsEnabledPDSA object</returns>
    public AccessPortal_SetIsEnabledPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortal_SetIsEnabledPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortal_SetIsEnabledPDSA entity to clone</param>
    /// <returns>A cloned AccessPortal_SetIsEnabledPDSA object</returns>
    public AccessPortal_SetIsEnabledPDSA CloneEntity(AccessPortal_SetIsEnabledPDSA entityToClone)
    {
      AccessPortal_SetIsEnabledPDSA newEntity = new AccessPortal_SetIsEnabledPDSA();


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
      
      props.Add(PDSAProperty.Create(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_AccessPortal_SetIsEnabledPDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessPortal_SetIsEnabledPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.IsEnabled, GetResourceMessage("GCS_AccessPortal_SetIsEnabledPDSA_IsEnabled_Header", "Is Enabled"), false, typeof(bool), 0, GetResourceMessage("GCS_AccessPortal_SetIsEnabledPDSA_IsEnabled_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessPortal_SetIsEnabledPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessPortal_SetIsEnabledPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.IsEnabled).Value = Entity.IsEnabled;
      Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.IsEnabled).IsNull == false)
        Entity.IsEnabled = Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.IsEnabled).GetAsBool();
      if(Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(AccessPortal_SetIsEnabledPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortal_SetIsEnabledPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@IsEnabled'
    /// </summary>
    public static string IsEnabled = "@IsEnabled";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
