using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroupLoadToCpu_CreatePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroupLoadToCpu_CreatePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroupLoadToCpu_CreatePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroupLoadToCpu_CreatePDSA Entity
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
    /// Clones the current AccessGroupLoadToCpu_CreatePDSA
    /// </summary>
    /// <returns>A cloned AccessGroupLoadToCpu_CreatePDSA object</returns>
    public AccessGroupLoadToCpu_CreatePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroupLoadToCpu_CreatePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroupLoadToCpu_CreatePDSA entity to clone</param>
    /// <returns>A cloned AccessGroupLoadToCpu_CreatePDSA object</returns>
    public AccessGroupLoadToCpu_CreatePDSA CloneEntity(AccessGroupLoadToCpu_CreatePDSA entityToClone)
    {
      AccessGroupLoadToCpu_CreatePDSA newEntity = new AccessGroupLoadToCpu_CreatePDSA();


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
      
      props.Add(PDSAProperty.Create(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_AccessGroupLoadToCpu_CreatePDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroupLoadToCpu_CreatePDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.AccessGroupUid, GetResourceMessage("GCS_AccessGroupLoadToCpu_CreatePDSA_AccessGroupUid_Header", "Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroupLoadToCpu_CreatePDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroupLoadToCpu_CreatePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupLoadToCpu_CreatePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.AccessGroupUid).GetAsGuid();
      if(Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(AccessGroupLoadToCpu_CreatePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroupLoadToCpu_CreatePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
