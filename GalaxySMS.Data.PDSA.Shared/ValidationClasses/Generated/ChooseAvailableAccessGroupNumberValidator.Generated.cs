using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the ChooseAvailableAccessGroupNumberPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ChooseAvailableAccessGroupNumberPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ChooseAvailableAccessGroupNumberPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ChooseAvailableAccessGroupNumberPDSA Entity
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
    /// Clones the current ChooseAvailableAccessGroupNumberPDSA
    /// </summary>
    /// <returns>A cloned ChooseAvailableAccessGroupNumberPDSA object</returns>
    public ChooseAvailableAccessGroupNumberPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ChooseAvailableAccessGroupNumberPDSA
    /// </summary>
    /// <param name="entityToClone">The ChooseAvailableAccessGroupNumberPDSA entity to clone</param>
    /// <returns>A cloned ChooseAvailableAccessGroupNumberPDSA object</returns>
    public ChooseAvailableAccessGroupNumberPDSA CloneEntity(ChooseAvailableAccessGroupNumberPDSA entityToClone)
    {
      ChooseAvailableAccessGroupNumberPDSA newEntity = new ChooseAvailableAccessGroupNumberPDSA();

      newEntity.AccessGroupNumber = entityToClone.AccessGroupNumber;

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
      
      props.Add(PDSAProperty.Create(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_ChooseAvailableAccessGroupNumberPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ChooseAvailableAccessGroupNumberPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.Extended, GetResourceMessage("GCS_ChooseAvailableAccessGroupNumberPDSA_Extended_Header", "Extended"), false, typeof(bool), 0, GetResourceMessage("GCS_ChooseAvailableAccessGroupNumberPDSA_Extended_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_ChooseAvailableAccessGroupNumberPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_ChooseAvailableAccessGroupNumberPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.Extended).Value = Entity.Extended;
      this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.Extended).IsNull == false)
        Entity.Extended = this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.Extended).GetAsBool();
      if(this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(ChooseAvailableAccessGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ChooseAvailableAccessGroupNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessGroupNumber'
    /// </summary>
    public static string AccessGroupNumber = "AccessGroupNumber";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@Extended'
    /// </summary>
    public static string Extended = "@Extended";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ChooseAvailableAccessGroupNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@Extended'
    /// </summary>
    public static string Extended = "@Extended";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
