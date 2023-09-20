////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\ObjectBase.cs
//
// summary:	Implements the object base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using FluentValidation;
using FluentValidation.Results;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An object base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public abstract class ObjectBase : NotificationObject, IDirtyCapable, IExtensibleDataObject, IDataErrorInfo
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObjectBase()
        {
            _Validator = GetValidator();
            //            Validate();
            _CustomErrors = new ObservableCollection<CustomError>();
        }

        /// <summary>   True if this ObjectBase is dirty. </summary>
        protected bool _IsDirty = false;
        /// <summary>   True if this ObjectBase is any property dirty. </summary>
        protected bool _IsAnyPropertyDirty = false;

        /// <summary>   True if this ObjectBase is panel data dirty. </summary>
        protected bool _IsPanelDataDirty = false;
        /// <summary>   The validator. </summary>
        protected IValidator _Validator = null;

        /// <summary>   The validation errors. </summary>
        protected IEnumerable<ValidationFailure> _ValidationErrors = null;
        /// <summary>   The custom errors. </summary>
        protected ObservableCollection<CustomError> _CustomErrors = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the container. </summary>
        ///
        /// <value> The container. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CompositionContainer Container { get; set; }

        #region IExtensibleDataObject Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the structure that contains extra data. </summary>
        ///
        /// <value>
        /// An <see cref="T:System.Runtime.Serialization.ExtensionDataObject" /> that contains data that
        /// is not recognized as belonging to the data contract.
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion

        #region IDirtyCapable members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this IDirtyCapable is dirty. </summary>
        ///
        /// <value> True if this IDirtyCapable is dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]

#if NetCoreApi
#else
        [DataMember]
#endif
        public virtual bool IsDirty
        {
            get { return _IsDirty; }
            protected set
            {
                _IsDirty = value;
                OnPropertyChanged("IsDirty", false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this IDirtyCapable is any property dirty.
        /// </summary>
        ///
        /// <value> True if this IDirtyCapable is any property dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]

#if NetCoreApi
#else
        [DataMember]
#endif
        public virtual bool IsAnyPropertyDirty
        {
            get { return _IsAnyPropertyDirty; }
            protected set
            {
                _IsAnyPropertyDirty = value;
                OnPropertyChanged("IsAnyPropertyDirty", false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this IDirtyCapable is panel data dirty.
        /// </summary>
        ///
        /// <value> True if this IDirtyCapable is panel data dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]

#if NetCoreApi
#else
        [DataMember]
#endif
        public virtual bool IsPanelDataDirty
        {
            get { return _IsPanelDataDirty; }
            set
            {
                _IsPanelDataDirty = value;
                OnPropertyChanged("IsPanelDataDirty", false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if this IDirtyCapable is anything dirty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   True if anything dirty, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool IsAnythingDirty()
        {
            bool isDirty = this.IsDirty;

            if (isDirty == false)
            {
                WalkObjectGraph(
                    o =>
                    {
                        if (o.IsDirty)
                        {
                            isDirty = true;
                            _IsAnyPropertyDirty = isDirty;
                            return isDirty; // short circuit
                        }
                        else
                        {
                            _IsAnyPropertyDirty = false;
                            return false;
                        }
                    }, coll => { });
            }
            _IsAnyPropertyDirty = isDirty;
            return isDirty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if this ObjectBase is any panel data dirty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   True if any panel data dirty, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool IsAnyPanelDataDirty()
        {
            bool isDirty = this.IsPanelDataDirty;

            if (isDirty == false)
            {
                WalkObjectGraph(
                o =>
                {
                    if (o.IsPanelDataDirty)
                    {
                        isDirty = true;
                        return true; // short circuit
                    }
                    else
                        return false;
                }, coll => { });
            }
            return isDirty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets dirty objects. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The dirty objects. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDirtyCapable> GetDirtyObjects()
        {
            List<IDirtyCapable> dirtyObjects = new List<IDirtyCapable>();

            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                    dirtyObjects.Add(o);

                return false;
            }, coll => { });

            return dirtyObjects;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Walks the object graph cleaning any dirty object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CleanAll()
        {
            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                    o.IsDirty = false;
                if (o.IsPanelDataDirty)
                    o.IsPanelDataDirty = false;
                return false;
            }, coll => { });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes the dirty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MakeDirty()
        {
            IsDirty = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes panel data dirty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MakePanelDataDirty()
        { IsPanelDataDirty = true; }
        #endregion

        #region Protected methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Walk object graph. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="snippetForObject">     The snippet for object. </param>
        /// <param name="snippetForCollection"> Collection of snippet fors. </param>
        /// <param name="exemptProperties">     A variable-length parameters list containing exempt
        ///                                     properties. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void WalkObjectGraph(Func<ObjectBase, bool> snippetForObject,
                                       Action<IList> snippetForCollection,
                                       params string[] exemptProperties)
        {
            List<ObjectBase> visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;

            List<string> exemptions = new List<string>();
            if (exemptProperties != null)
                exemptions = exemptProperties.ToList();

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    bool exitWalk = snippetForObject.Invoke(o);

                    if (!exitWalk)
                    {
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (!exemptions.Contains(property.Name))
                            {
                                if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                                {
                                    ObjectBase obj = (ObjectBase)(property.GetValue(o, null));
                                    walk(obj);
                                }
                                else
                                {
                                    IList coll = property.GetValue(o, null) as IList;
                                    if (coll != null)
                                    {
                                        snippetForCollection.Invoke(coll);

                                        foreach (object item in coll)
                                        {
                                            if (item is ObjectBase)
                                                walk((ObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            walk(this);
        }

        #endregion

        #region Property change notification

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName"> Name of the property. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="propertyExpression">   The property expression. </param>
        /// <param name="makeDirty">            True to make dirty. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression, bool makeDirty)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName, makeDirty, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName"> Name of the property. </param>
        /// <param name="makeDirty">    True to make dirty. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            base.OnPropertyChanged(propertyName);

            if (makeDirty)
                IsDirty = true;

            Validate();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="propertyExpression">   The property expression. </param>
        /// <param name="makeDirty">            True to make dirty. </param>
        /// <param name="makePanelDataDirty">   True to make panel data dirty. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression, bool makeDirty, bool makePanelDataDirty)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName, makeDirty, makePanelDataDirty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName">         Name of the property. </param>
        /// <param name="makeDirty">            True to make dirty. </param>
        /// <param name="makePanelDataDirty">   True to make panel data dirty. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void OnPropertyChanged(string propertyName, bool makeDirty, bool makePanelDataDirty)
        {
            base.OnPropertyChanged(propertyName);

            if (makeDirty)
                IsDirty = true;

            if (makePanelDataDirty)
                IsPanelDataDirty = true;

            Validate();
        }

        #endregion

        #region Validation

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The validator. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual IValidator GetValidator()
        {
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the validation errors. </summary>
        ///
        /// <value> The validation errors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public IEnumerable<ValidationFailure> ValidationErrors
        {
            get { return _ValidationErrors; }
            set { _ValidationErrors = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Appends a validation error. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="error">    The error. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AppendValidationError(ValidationFailure error)
        {
            if (ValidationErrors == null)
                _ValidationErrors = new List<ValidationFailure>();
            _ValidationErrors = ValidationErrors.Append(error);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Appends a validation errors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="errors">   The errors. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AppendValidationErrors(IEnumerable<ValidationFailure> errors)
        {
            if (ValidationErrors == null)
                _ValidationErrors = new List<ValidationFailure>();
            foreach (var e in errors)
                _ValidationErrors = ValidationErrors.Append(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates this ObjectBase. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public void Validate()
        //{
        //    if (_Validator == null)
        //        _Validator = GetValidator();

        //    if (_Validator != null)
        //    {
        //        try
        //        {
        //            ValidationResult results = _Validator.Validate(this);
        //            _ValidationErrors = results.Errors;
        //        }
        //        catch (Exception e)
        //        {
        //            Trace.WriteLine(e);
        //        }
        //    }
        //}
        
        public void Validate()
        {
            if (_Validator == null)
                _Validator = GetValidator();

            if (_Validator != null)
            {
                try
                {
                    var context = new ValidationContext<object>(this);
                    var results = _Validator.Validate(context);
                    _ValidationErrors = results.Errors;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this ObjectBase is valid. </summary>
        ///
        /// <value> True if this ObjectBase is valid, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public virtual bool IsValid
        {
            get
            {
                if ((_ValidationErrors != null && _ValidationErrors.Count() > 0) ||
                    (CustomErrors != null && CustomErrors.Count > 0))
                    return false;
                else
                    return true;
            }
        }

        #endregion

        #region Error Messages

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the custom errors. </summary>
        ///
        /// <value> The custom errors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public ObservableCollection<CustomError> CustomErrors
        {
            get { return _CustomErrors; }
            set
            {
            }
        }
        #endregion

        #region IDataErrorInfo members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an error message indicating what is wrong with this object. </summary>
        ///
        /// <value>
        /// An error message indicating what is wrong with this object. The default is an empty string
        /// ("").
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string IDataErrorInfo.Error
        {
            get { return string.Empty; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the error message for the property with the given name. </summary>
        ///
        /// <param name="columnName">   The name of the property whose error message to get. </param>
        ///
        /// <returns>   The error message for the property. The default is an empty string (""). </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                StringBuilder errors = new StringBuilder();

                if (_ValidationErrors != null && _ValidationErrors.Count() > 0)
                {
                    foreach (ValidationFailure validationError in _ValidationErrors)
                    {
                        if (validationError.PropertyName == columnName)
                            errors.AppendLine(validationError.ErrorMessage);
                    }
                }

                return errors.ToString();
            }
        }

        #endregion

        //[DataMember]
        //public int EntityIdentifier { get; set; }

        //[DataMember]
        //public Guid EntityGuid { get; set; }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An object base simple. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public abstract class ObjectBaseSimple : NotificationObject, IExtensibleDataObject, IDataErrorInfo
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObjectBaseSimple()
        {
            _Validator = GetValidator();
            //            Validate();
            _CustomErrors = new ObservableCollection<CustomError>();
        }

        /// <summary>   The validator. </summary>
        protected IValidator _Validator = null;

        /// <summary>   The validation errors. </summary>
        protected IEnumerable<ValidationFailure> _ValidationErrors = null;
        /// <summary>   The custom errors. </summary>
        protected ObservableCollection<CustomError> _CustomErrors = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the container. </summary>
        ///
        /// <value> The container. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CompositionContainer Container { get; set; }

        #region IExtensibleDataObject Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the structure that contains extra data. </summary>
        ///
        /// <value>
        /// An <see cref="T:System.Runtime.Serialization.ExtensionDataObject" /> that contains data that
        /// is not recognized as belonging to the data contract.
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion

        #region Protected methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Walk object graph. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="snippetForObject">     The snippet for object. </param>
        /// <param name="snippetForCollection"> Collection of snippet fors. </param>
        /// <param name="exemptProperties">     A variable-length parameters list containing exempt
        ///                                     properties. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void WalkObjectGraph(Func<ObjectBaseSimple, bool> snippetForObject,
                                       Action<IList> snippetForCollection,
                                       params string[] exemptProperties)
        {
            List<ObjectBaseSimple> visited = new List<ObjectBaseSimple>();
            Action<ObjectBaseSimple> walk = null;

            List<string> exemptions = new List<string>();
            if (exemptProperties != null)
                exemptions = exemptProperties.ToList();

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    bool exitWalk = snippetForObject.Invoke(o);

                    if (!exitWalk)
                    {
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (!exemptions.Contains(property.Name))
                            {
                                if (property.PropertyType.IsSubclassOf(typeof(ObjectBaseSimple)))
                                {
                                    ObjectBaseSimple obj = (ObjectBaseSimple)(property.GetValue(o, null));
                                    walk(obj);
                                }
                                else
                                {
                                    IList coll = property.GetValue(o, null) as IList;
                                    if (coll != null)
                                    {
                                        snippetForCollection.Invoke(coll);

                                        foreach (object item in coll)
                                        {
                                            if (item is ObjectBaseSimple)
                                                walk((ObjectBaseSimple)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            walk(this);
        }

        #endregion
        
        #region Property change notification

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="propertyExpression">   The property expression. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName"> Name of the property. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            Validate();
        }

        #endregion

        #region Validation

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the validator. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The validator. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual IValidator GetValidator()
        {
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the validation errors. </summary>
        ///
        /// <value> The validation errors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public IEnumerable<ValidationFailure> ValidationErrors
        {
            get { return _ValidationErrors; }
            set { _ValidationErrors = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Appends a validation error. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="error">    The error. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AppendValidationError(ValidationFailure error)
        {
            if (ValidationErrors == null)
                _ValidationErrors = new List<ValidationFailure>();
            _ValidationErrors = ValidationErrors.Append(error);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Appends a validation errors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="errors">   The errors. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AppendValidationErrors(IEnumerable<ValidationFailure> errors)
        {
            if (ValidationErrors == null)
                _ValidationErrors = new List<ValidationFailure>();
            foreach (var e in errors)
                _ValidationErrors = ValidationErrors.Append(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates this ObjectBaseSimple. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public void Validate()
        //{
        //    if (_Validator == null)
        //        _Validator = GetValidator();

        //    if (_Validator != null)
        //    {
        //        try
        //        {
        //            ValidationResult results = _Validator.Validate(this);
        //            _ValidationErrors = results.Errors;
        //        }
        //        catch (Exception e)
        //        {
        //            Trace.WriteLine(e);
        //        }
        //    }
        //}
        public void Validate()
        {
            if (_Validator == null)
                _Validator = GetValidator();

            if (_Validator != null)
            {
                try
                {
                    var context = new ValidationContext<object>(this);
                    var results = _Validator.Validate(context);
                    //ValidationResult results = _Validator.Validate(this);
                    _ValidationErrors = results.Errors;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this ObjectBaseSimple is valid. </summary>
        ///
        /// <value> True if this ObjectBaseSimple is valid, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public virtual bool IsValid
        {
            get
            {
                if ((_ValidationErrors != null && _ValidationErrors.Count() > 0) ||
                    (CustomErrors != null && CustomErrors.Count > 0))
                    return false;
                else
                    return true;
            }
        }

        #endregion

        #region Error Messages

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the custom errors. </summary>
        ///
        /// <value> The custom errors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public ObservableCollection<CustomError> CustomErrors
        {
            get { return _CustomErrors; }
            set
            {
            }
        }
        #endregion

        #region IDataErrorInfo members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an error message indicating what is wrong with this object. </summary>
        ///
        /// <value>
        /// An error message indicating what is wrong with this object. The default is an empty string
        /// ("").
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string IDataErrorInfo.Error
        {
            get { return string.Empty; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the error message for the property with the given name. </summary>
        ///
        /// <param name="columnName">   The name of the property whose error message to get. </param>
        ///
        /// <returns>   The error message for the property. The default is an empty string (""). </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                StringBuilder errors = new StringBuilder();

                if (_ValidationErrors != null && _ValidationErrors.Count() > 0)
                {
                    foreach (ValidationFailure validationError in _ValidationErrors)
                    {
                        if (validationError.PropertyName == columnName)
                            errors.AppendLine(validationError.ErrorMessage);
                    }
                }

                return errors.ToString();
            }
        }

        #endregion

    }

}
