using System;
using System.Collections.Generic;
using System.Linq;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class is an extension of the ChooseAvailableInputOutputGroupNumberPDSA Entity class
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add additional properties to this class. 
  /// </summary>
  //[Serializable]
  public partial class ChooseAvailableInputOutputGroupNumberPDSA : PDSAEntityBase
  {
    #region Constructor
    /// <summary>
    /// Constructor for the ChooseAvailableInputOutputGroupNumberPDSA class
    /// </summary>
    public ChooseAvailableInputOutputGroupNumberPDSA() : base()
    {
      ClassName = "ChooseAvailableInputOutputGroupNumberPDSA";
    }
    #endregion
  }  
      
  /// <summary>
  /// This class is used when you wish to create a collection of ChooseAvailableInputOutputGroupNumberPDSA classes.
  /// You may add additional methods to this class.
  /// </summary>
  public class ChooseAvailableInputOutputGroupNumberPDSACollection : List<ChooseAvailableInputOutputGroupNumberPDSA>
  {
    
    /// <summary>
    /// Get all ChooseAvailableInputOutputGroupNumberPDSA objects where IsDirty=True
    /// </summary>
    /// <returns>A List of ChooseAvailableInputOutputGroupNumberPDSA Objects</returns>
    public List<ChooseAvailableInputOutputGroupNumberPDSA> GetChanged()
    {
      return (from item in this
              where item.IsDirty == true
              select item).ToList<ChooseAvailableInputOutputGroupNumberPDSA>();
    }
        
    /// <summary>
    /// Get all ChooseAvailableInputOutputGroupNumberPDSA objects where IsSelected=True
    /// </summary>
    /// <returns>A List of ChooseAvailableInputOutputGroupNumberPDSA Objects where IsSelected=True</returns>
    public List<ChooseAvailableInputOutputGroupNumberPDSA> GetSelected()
    {
      return (from item in this
              where item.IsSelected == true
              select item).ToList<ChooseAvailableInputOutputGroupNumberPDSA>();
    }

  }
}
