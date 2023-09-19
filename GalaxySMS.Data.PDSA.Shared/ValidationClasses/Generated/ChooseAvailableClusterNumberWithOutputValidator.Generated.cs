using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the ChooseAvailableClusterNumberWithOutputPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ChooseAvailableClusterNumberWithOutputPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ChooseAvailableClusterNumberWithOutputPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ChooseAvailableClusterNumberWithOutputPDSA Entity
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
    /// Clones the current ChooseAvailableClusterNumberWithOutputPDSA
    /// </summary>
    /// <returns>A cloned ChooseAvailableClusterNumberWithOutputPDSA object</returns>
    public ChooseAvailableClusterNumberWithOutputPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ChooseAvailableClusterNumberWithOutputPDSA
    /// </summary>
    /// <param name="entityToClone">The ChooseAvailableClusterNumberWithOutputPDSA entity to clone</param>
    /// <returns>A cloned ChooseAvailableClusterNumberWithOutputPDSA object</returns>
    public ChooseAvailableClusterNumberWithOutputPDSA CloneEntity(ChooseAvailableClusterNumberWithOutputPDSA entityToClone)
    {
      ChooseAvailableClusterNumberWithOutputPDSA newEntity = new ChooseAvailableClusterNumberWithOutputPDSA();


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
      
      props.Add(PDSAProperty.Create(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_ChooseAvailableClusterNumberWithOutputPDSA_AccountCode_Header", "Account Code"), false, typeof(string), 8000, GetResourceMessage("GCS_ChooseAvailableClusterNumberWithOutputPDSA_AccountCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_ChooseAvailableClusterNumberWithOutputPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_ChooseAvailableClusterNumberWithOutputPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_ChooseAvailableClusterNumberWithOutputPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_ChooseAvailableClusterNumberWithOutputPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(ChooseAvailableClusterNumberWithOutputPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ChooseAvailableClusterNumberWithOutputPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
