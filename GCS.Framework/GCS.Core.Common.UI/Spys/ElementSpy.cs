////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Spys\ElementSpy.cs
//
// summary:	Implements the element spy class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace GCS.Core.Common.UI.Spys
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// When placed into an element's Resources collection the spy's Element property returns that
    /// containing element. Use the  NameScopeSource attached property to bridge an element's
    /// NameScope to other elements.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ElementSpy
        : Freezable
    {
        #region Element

        /// <summary>   The element. </summary>
        DependencyObject _element;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the element. </summary>
        ///
        /// <value> The element. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DependencyObject Element
        {
            get
            {
                if (_element == null)
                {
                    var prop =
                        typeof(Freezable).GetProperty(
                        "InheritanceContext",
                        BindingFlags.Instance | BindingFlags.NonPublic
                        );

                    _element = prop.GetValue(this, null) as DependencyObject;

                    if (_element != null)
                        base.Freeze();
                }
                return _element;
            }
        }

        #endregion // Element

        #region NameScopeSource

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets name scope source. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ///
        /// <returns>   The name scope source. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ElementSpy GetNameScopeSource(
            DependencyObject obj)
        {
            return (ElementSpy) obj.GetValue(NameScopeSourceProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets name scope source. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">      The object. </param>
        /// <param name="value">    The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetNameScopeSource(
            DependencyObject obj, ElementSpy value)
        {
            obj.SetValue(NameScopeSourceProperty, value);
        }

        /// <summary>   The name scope source property. </summary>
        public static readonly DependencyProperty
            NameScopeSourceProperty =
            DependencyProperty.RegisterAttached(
            "NameScopeSource",
            typeof(ElementSpy),
            typeof(ElementSpy),
            new UIPropertyMetadata(
                null, OnNameScopeSourceChanged));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="depObj">   The dep object. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void OnNameScopeSourceChanged(
            DependencyObject depObj,
            DependencyPropertyChangedEventArgs e)
        {
            ElementSpy spy = e.NewValue as ElementSpy;
            if (spy == null || spy.Element == null)
                return;

            INameScope scope =
                NameScope.GetNameScope(spy.Element);
            if (scope == null)
                return;

            depObj.Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                (Action) delegate
                {
                    NameScope.SetNameScope(depObj, scope);
                });
        }

        #endregion // NameScopeSource

        #region CreateInstanceCore

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// When implemented in a derived class, creates a new instance of the
        /// <see cref="T:System.Windows.Freezable" /> derived class.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="NotSupportedException">    Thrown when the requested operation is not
        ///                                             supported. </exception>
        ///
        /// <returns>   The new instance. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override Freezable CreateInstanceCore()
        {
            // We are required to override this abstract method.
            throw new System.NotSupportedException();
        }

        #endregion // CreateInstanceCore
    }
}
