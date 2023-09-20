////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Mvc\Components\HtmlExtensionsPassword.cs
//
// summary:	Implements the HTML extensions password class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace GCS.Core.Common.Web.Mvc.Components
{
  ////////////////////////////////////////////////////////////////////////////////////////////////////
  /// <summary> A HTML extensions password. </summary>
  ///
  /// <remarks> Kevin, 12/26/2018. </remarks>
  ////////////////////////////////////////////////////////////////////////////////////////////////////

  public static class HtmlExtensionsPassword
  {
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HtmlHelper&lt;TModel&gt; extension method that bootstrap password for. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    /// <typeparam name="TValue">   Type of the value. </typeparam>
    /// <param name="htmlHelper">       The htmlHelper to act on. </param>
    /// <param name="expression">       The expression. </param>
    /// <param name="type">             The type. </param>
    /// <param name="htmlAttributes">   The HTML attributes. </param>
    ///
    /// <returns>   A MvcHtmlString. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MvcHtmlString BootstrapPasswordFor<TModel, TValue>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TValue>> expression,
      HtmlExtensionsCommon.Html5InputTypes type,    
      object htmlAttributes = null
      ) {
      return HtmlExtensionsPassword.BootstrapPasswordFor(htmlHelper,
        expression, type, string.Empty, string.Empty, false, false,
        string.Empty, htmlAttributes);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HtmlHelper&lt;TModel&gt; extension method that bootstrap password for. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    /// <typeparam name="TValue">   Type of the value. </typeparam>
    /// <param name="htmlHelper">       The htmlHelper to act on. </param>
    /// <param name="expression">       The expression. </param>
    /// <param name="type">             The type. </param>
    /// <param name="cssClass">         The CSS class. </param>
    /// <param name="htmlAttributes">   The HTML attributes. </param>
    ///
    /// <returns>   A MvcHtmlString. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MvcHtmlString BootstrapPasswordFor<TModel, TValue>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TValue>> expression,
      HtmlExtensionsCommon.Html5InputTypes type,
      string cssClass,
      object htmlAttributes = null
      ) {
      return HtmlExtensionsPassword.BootstrapPasswordFor(htmlHelper,
        expression, type, string.Empty, string.Empty, false, false,
        cssClass, htmlAttributes);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HtmlHelper&lt;TModel&gt; extension method that bootstrap password for. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    /// <typeparam name="TValue">   Type of the value. </typeparam>
    /// <param name="htmlHelper">       The htmlHelper to act on. </param>
    /// <param name="expression">       The expression. </param>
    /// <param name="type">             The type. </param>
    /// <param name="title">            The title. </param>
    /// <param name="placeholder">      The placeholder. </param>
    /// <param name="isRequired">       True if this HtmlExtensionsPassword is required. </param>
    /// <param name="isAutoFocus">      True if this HtmlExtensionsPassword is automatic focus. </param>
    /// <param name="htmlAttributes">   The HTML attributes. </param>
    ///
    /// <returns>   A MvcHtmlString. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MvcHtmlString BootstrapPasswordFor<TModel, TValue>(
     this HtmlHelper<TModel> htmlHelper,
     Expression<Func<TModel, TValue>> expression,
     HtmlExtensionsCommon.Html5InputTypes type,
     string title,
     string placeholder,
     bool isRequired,
     bool isAutoFocus,
     object htmlAttributes = null
     ) {
      return HtmlExtensionsPassword.BootstrapPasswordFor(htmlHelper,
        expression, type, title, placeholder, isRequired, isAutoFocus,
        string.Empty, htmlAttributes);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// A HtmlHelper&lt;TModel&gt; extension method that bootstrap password for.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    /// <typeparam name="TValue">   Type of the value. </typeparam>
    /// <param name="htmlHelper">       The htmlHelper to act on. </param>
    /// <param name="expression">       The expression. </param>
    /// <param name="type">             The type. </param>
    /// <param name="title">            The title. </param>
    /// <param name="placeholder">      The placeholder. </param>
    /// <param name="isRequired">       True if this HtmlExtensionsPassword is required. </param>
    /// <param name="isAutoFocus">      True if this HtmlExtensionsPassword is automatic focus. </param>
    /// <param name="cssClass">         The CSS class. </param>
    /// <param name="htmlAttributes">   The HTML attributes. </param>
    ///
    /// <returns>   A MvcHtmlString. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MvcHtmlString BootstrapPasswordFor<TModel, TValue>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TValue>> expression,
      HtmlExtensionsCommon.Html5InputTypes type,
      string title,
      string placeholder,
      bool isRequired,
      bool isAutoFocus,
      string cssClass,
      object htmlAttributes = null
      ) {
      RouteValueDictionary rvd;

      // Creates the route value dictionary
      rvd = new RouteValueDictionary(
        HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

      // Add all other attributes below here
      rvd.Add("type", type.ToString());
      if (!string.IsNullOrWhiteSpace(title)) {
        rvd.Add("title", title);
      }
      if (!string.IsNullOrWhiteSpace(placeholder)) {
        rvd.Add("placeholder", placeholder);
      }
      if (isRequired) {
        rvd.Add("required", "required");
      }
      if (isAutoFocus) {
        rvd.Add("autofocus", "autofocus");
      }
      if (string.IsNullOrWhiteSpace(cssClass)) {
        cssClass = "form-control";
      }
      else {
        cssClass = "form-control " + cssClass;
      }
      rvd.Add("class", cssClass);

      return InputExtensions.TextBoxFor(htmlHelper, 
        expression, rvd);
    }
  }
}