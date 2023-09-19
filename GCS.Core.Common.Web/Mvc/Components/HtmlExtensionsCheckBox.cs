////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Mvc\Components\HtmlExtensionsCheckBox.cs
//
// summary:	Implements the HTML extensions check box class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace GCS.Core.Common.Web.Mvc.Components
{
  ////////////////////////////////////////////////////////////////////////////////////////////////////
  /// <summary> A HTML extensions check box. </summary>
  ///
  /// <remarks> Kevin, 12/26/2018. </remarks>
  ////////////////////////////////////////////////////////////////////////////////////////////////////

  public static class HtmlExtensionsCheckBox
  {
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HtmlHelper&lt;TModel&gt; extension method that bootstrap check box for. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    /// <param name="htmlHelper">       The htmlHelper to act on. </param>
    /// <param name="expression">       The expression. </param>
    /// <param name="text">             The text. </param>
    /// <param name="htmlAttributes">   The HTML attributes. </param>
    ///
    /// <returns>   A MvcHtmlString. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MvcHtmlString BootstrapCheckBoxFor<TModel>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, bool>> expression,
      string text,
      object htmlAttributes = null) {
      return HtmlExtensionsCheckBox.BootstrapCheckBoxFor(
        htmlHelper, expression, text, string.Empty, false, false, null);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HtmlHelper&lt;TModel&gt; extension method that bootstrap check box for. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    /// <param name="htmlHelper">       The htmlHelper to act on. </param>
    /// <param name="expression">       The expression. </param>
    /// <param name="text">             The text. </param>
    /// <param name="title">            The title. </param>
    /// <param name="isAutoFocus">      True if this HtmlExtensionsCheckBox is automatic focus. </param>
    /// <param name="htmlAttributes">   The HTML attributes. </param>
    ///
    /// <returns>   A MvcHtmlString. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MvcHtmlString BootstrapCheckBoxFor<TModel>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, bool>> expression,
      string text,
      string title,
      bool isAutoFocus,
      object htmlAttributes = null) {
      return HtmlExtensionsCheckBox.BootstrapCheckBoxFor(
        htmlHelper, expression, text, title, isAutoFocus, false, null);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// A HtmlHelper&lt;TModel&gt; extension method that bootstrap check box for.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    /// <param name="htmlHelper">       The htmlHelper to act on. </param>
    /// <param name="expression">       The expression. </param>
    /// <param name="text">             The text. </param>
    /// <param name="title">            The title. </param>
    /// <param name="isAutoFocus">      True if this HtmlExtensionsCheckBox is automatic focus. </param>
    /// <param name="useInline">        True to use inline. </param>
    /// <param name="htmlAttributes">   The HTML attributes. </param>
    ///
    /// <returns>   A MvcHtmlString. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static MvcHtmlString BootstrapCheckBoxFor<TModel>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, bool>> expression,
      string text,
      string title,
      bool isAutoFocus,
      bool useInline,
      object htmlAttributes = null) {

      StringBuilder sb = new StringBuilder(512);
      RouteValueDictionary rvd;

      rvd = new RouteValueDictionary(
        HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

      if (string.IsNullOrWhiteSpace(title)) {
        title = text;
      }
      rvd.Add("title", title);
      if (isAutoFocus) {
        rvd.Add("autofocus", "autofocus");
      }

      // Open the CheckBox element
      if (useInline) {
        sb.Append("<label class='checkbox-inline'>");
      }
      else {
        sb.Append("<div class='checkbox'>");
        sb.Append("<label>");
      }

      // Build the CheckBox using InputExtensions class
      sb.Append(InputExtensions.CheckBoxFor(
        htmlHelper, expression, rvd));

      // Add the Text
      sb.Append(text);

      // Close the CheckBox element
      if (useInline) {
        sb.Append("</label>");
      }
      else {
        sb.Append("</label>");
        sb.Append("</div>");
      }

      return MvcHtmlString.Create(sb.ToString());
    }
  }
}