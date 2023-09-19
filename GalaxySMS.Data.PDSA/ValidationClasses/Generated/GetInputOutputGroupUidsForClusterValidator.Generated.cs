using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GetInputOutputGroupUidsForClusterPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GetInputOutputGroupUidsForClusterPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GetInputOutputGroupUidsForClusterPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GetInputOutputGroupUidsForClusterPDSA Entity
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
    /// Clones the current GetInputOutputGroupUidsForClusterPDSA
    /// </summary>
    /// <returns>A cloned GetInputOutputGroupUidsForClusterPDSA object</returns>
    public GetInputOutputGroupUidsForClusterPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GetInputOutputGroupUidsForClusterPDSA
    /// </summary>
    /// <param name="entityToClone">The GetInputOutputGroupUidsForClusterPDSA entity to clone</param>
    /// <returns>A cloned GetInputOutputGroupUidsForClusterPDSA object</returns>
    public GetInputOutputGroupUidsForClusterPDSA CloneEntity(GetInputOutputGroupUidsForClusterPDSA entityToClone)
    {
      GetInputOutputGroupUidsForClusterPDSA newEntity = new GetInputOutputGroupUidsForClusterPDSA();

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
      
      props.Add(PDSAProperty.Create(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid, GetResourceMessage("GCS_GetInputOutputGroupUidsForClusterPDSA_uid_Header", "uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetInputOutputGroupUidsForClusterPDSA_uid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GetInputOutputGroupUidsForClusterPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GetInputOutputGroupUidsForClusterPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid).Value = Entity.uid;
      this.Properties.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid).IsNull == false)
        Entity.uid = this.Properties.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid).GetAsGuid();
      if(this.Properties.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetInputOutputGroupUidsForClusterPDSA class.
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
    /// Returns '@uid'
    /// </summary>
    public static string uid = "@uid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetInputOutputGroupUidsForClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@uid'
    /// </summary>
    public static string uid = "@uid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
