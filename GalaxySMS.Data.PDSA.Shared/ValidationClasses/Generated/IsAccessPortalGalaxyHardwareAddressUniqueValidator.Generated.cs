using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalGalaxyHardwareAddressUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalGalaxyHardwareAddressUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalGalaxyHardwareAddressUniquePDSA Entity
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
    /// Clones the current IsAccessPortalGalaxyHardwareAddressUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalGalaxyHardwareAddressUniquePDSA object</returns>
    public IsAccessPortalGalaxyHardwareAddressUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalGalaxyHardwareAddressUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalGalaxyHardwareAddressUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalGalaxyHardwareAddressUniquePDSA object</returns>
    public IsAccessPortalGalaxyHardwareAddressUniquePDSA CloneEntity(IsAccessPortalGalaxyHardwareAddressUniquePDSA entityToClone)
    {
      IsAccessPortalGalaxyHardwareAddressUniquePDSA newEntity = new IsAccessPortalGalaxyHardwareAddressUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalGalaxyHardwareAddressUid, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_AccessPortalGalaxyHardwareAddressUid_Header", "Access Portal Galaxy Hardware Address Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_AccessPortalGalaxyHardwareAddressUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Header", "Galaxy Interface Board Section Node Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalGalaxyHardwareAddressUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalGalaxyHardwareAddressUid).Value = Entity.AccessPortalGalaxyHardwareAddressUid;
      this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).Value = Entity.GalaxyInterfaceBoardSectionNodeUid;
      this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalGalaxyHardwareAddressUid).IsNull == false)
        Entity.AccessPortalGalaxyHardwareAddressUid = this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalGalaxyHardwareAddressUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionNodeUid = this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalGalaxyHardwareAddressUniquePDSA class.
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
    /// Returns '@AccessPortalGalaxyHardwareAddressUid'
    /// </summary>
    public static string AccessPortalGalaxyHardwareAddressUid = "@AccessPortalGalaxyHardwareAddressUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "@GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalGalaxyHardwareAddressUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalGalaxyHardwareAddressUid'
    /// </summary>
    public static string AccessPortalGalaxyHardwareAddressUid = "@AccessPortalGalaxyHardwareAddressUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "@GalaxyInterfaceBoardSectionNodeUid";
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
