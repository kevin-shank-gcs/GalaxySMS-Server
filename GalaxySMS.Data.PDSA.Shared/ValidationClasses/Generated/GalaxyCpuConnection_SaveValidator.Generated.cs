using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyCpuConnection_SavePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyCpuConnection_SavePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyCpuConnection_SavePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyCpuConnection_SavePDSA Entity
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
    /// Clones the current GalaxyCpuConnection_SavePDSA
    /// </summary>
    /// <returns>A cloned GalaxyCpuConnection_SavePDSA object</returns>
    public GalaxyCpuConnection_SavePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyCpuConnection_SavePDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyCpuConnection_SavePDSA entity to clone</param>
    /// <returns>A cloned GalaxyCpuConnection_SavePDSA object</returns>
    public GalaxyCpuConnection_SavePDSA CloneEntity(GalaxyCpuConnection_SavePDSA entityToClone)
    {
      GalaxyCpuConnection_SavePDSA newEntity = new GalaxyCpuConnection_SavePDSA();


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
      
      props.Add(PDSAProperty.Create(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.IsConnected, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_IsConnected_Header", "Is Connected"), false, typeof(bool), 0, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_IsConnected_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.ServerAddress, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_ServerAddress_Header", "Server Address"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_ServerAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuConnection_SavePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.IsConnected).Value = Entity.IsConnected;
      Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.ServerAddress).Value = Entity.ServerAddress;
      Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.IsConnected).IsNull == false)
        Entity.IsConnected = Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.IsConnected).GetAsBool();
      if(Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.ServerAddress).IsNull == false)
        Entity.ServerAddress = Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.ServerAddress).GetAsString();
      if(Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(GalaxyCpuConnection_SavePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyCpuConnection_SavePDSA class.
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
    /// Returns '@IsConnected'
    /// </summary>
    public static string IsConnected = "@IsConnected";
    /// <summary>
    /// Returns '@ServerAddress'
    /// </summary>
    public static string ServerAddress = "@ServerAddress";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
