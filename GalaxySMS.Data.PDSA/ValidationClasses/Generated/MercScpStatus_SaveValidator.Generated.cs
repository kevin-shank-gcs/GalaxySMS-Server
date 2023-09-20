using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the MercScpStatus_SavePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class MercScpStatus_SavePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private MercScpStatus_SavePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new MercScpStatus_SavePDSA Entity
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
    /// Clones the current MercScpStatus_SavePDSA
    /// </summary>
    /// <returns>A cloned MercScpStatus_SavePDSA object</returns>
    public MercScpStatus_SavePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in MercScpStatus_SavePDSA
    /// </summary>
    /// <param name="entityToClone">The MercScpStatus_SavePDSA entity to clone</param>
    /// <returns>A cloned MercScpStatus_SavePDSA object</returns>
    public MercScpStatus_SavePDSA CloneEntity(MercScpStatus_SavePDSA entityToClone)
    {
      MercScpStatus_SavePDSA newEntity = new MercScpStatus_SavePDSA();


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
      
      props.Add(PDSAProperty.Create(MercScpStatus_SavePDSAValidator.ParameterNames.MercScpUid, GetResourceMessage("GCS_MercScpStatus_SavePDSA_MercScpUid_Header", "Merc Scp Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_MercScpStatus_SavePDSA_MercScpUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpStatus_SavePDSAValidator.ParameterNames.Online, GetResourceMessage("GCS_MercScpStatus_SavePDSA_Online_Header", "Online"), false, typeof(bool), 0, GetResourceMessage("GCS_MercScpStatus_SavePDSA_Online_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(MercScpStatus_SavePDSAValidator.ParameterNames.LastConnected, GetResourceMessage("GCS_MercScpStatus_SavePDSA_LastConnected_Header", "Last Connected"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_MercScpStatus_SavePDSA_LastConnected_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(MercScpStatus_SavePDSAValidator.ParameterNames.LastDisconnected, GetResourceMessage("GCS_MercScpStatus_SavePDSA_LastDisconnected_Header", "Last Disconnected"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_MercScpStatus_SavePDSA_LastDisconnected_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(MercScpStatus_SavePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_MercScpStatus_SavePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_MercScpStatus_SavePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.MercScpUid).Value = Entity.MercScpUid;
      Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.Online).Value = Entity.Online;
      Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.LastConnected).Value = Entity.LastConnected;
      Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.LastDisconnected).Value = Entity.LastDisconnected;
      Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.MercScpUid).IsNull == false)
        Entity.MercScpUid = Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.MercScpUid).GetAsGuid();
      if(Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.Online).IsNull == false)
        Entity.Online = Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.Online).GetAsBool();
      if(Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.LastConnected).IsNull == false)
        Entity.LastConnected = Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.LastConnected).GetAsDateTimeOffset();
      if(Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.LastDisconnected).IsNull == false)
        Entity.LastDisconnected = Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.LastDisconnected).GetAsDateTimeOffset();
      if(Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(MercScpStatus_SavePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the MercScpStatus_SavePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@MercScpUid'
    /// </summary>
    public static string MercScpUid = "@MercScpUid";
    /// <summary>
    /// Returns '@Online'
    /// </summary>
    public static string Online = "@Online";
    /// <summary>
    /// Returns '@LastConnected'
    /// </summary>
    public static string LastConnected = "@LastConnected";
    /// <summary>
    /// Returns '@LastDisconnected'
    /// </summary>
    public static string LastDisconnected = "@LastDisconnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
