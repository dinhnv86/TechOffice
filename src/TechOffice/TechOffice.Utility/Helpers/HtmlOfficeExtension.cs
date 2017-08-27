using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace AnThinhPhat.Utilities
{
    public static class HtmlOfficeExtension
    {
        public static MvcHtmlString OfficeEnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var items =
                values.Select(
                    value =>
                        new SelectListItem
                        {
                            Text = GetEnumDescription(value),
                            Value = Convert.ToInt32(value).ToString(),
                            Selected = value.Equals(metadata.Model)
                        });
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            return htmlHelper.DropDownListFor(expression, items, attributes);
        }

        public static MvcHtmlString OfficeEnumListBoxFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum>> expression, Type type, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var values = Enum.GetValues(type).Cast<Type>();

            var items =
                values.Select(
                    value =>
                        new SelectListItem
                        {
                            Text = GetEnumDescription(value),
                            Value = Convert.ToInt32(value).ToString(),
                            Selected = value.Equals(metadata.Model)
                        });
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            return htmlHelper.ListBoxFor(expression, items, attributes);
        }

        /// <summary>
        /// Converts a NameValueCollection into a RouteValueDictionary containing all of the elements in the collection, and optionally appends
        /// {newKey: newValue} if they are not null
        /// </summary>
        /// <param name="collection">NameValue collection to convert into a RouteValueDictionary</param>
        /// <param name="newKey">the name of a key to add to the RouteValueDictionary</param>
        /// <param name="newValue">the value associated with newKey to add to the RouteValueDictionary</param>
        /// <returns>A RouteValueDictionary containing all of the keys in collection, as well as {newKey: newValue} if they are not null</returns>
        public static RouteValueDictionary ToRouteValueDictionary(this NameValueCollection collection, string newKey, string newValue)
        {
            var routeValueDictionary = new RouteValueDictionary();
            foreach (var key in collection.AllKeys)
            {
                if (key == null) continue;
                if (routeValueDictionary.ContainsKey(key))
                    routeValueDictionary.Remove(key);

                routeValueDictionary.Add(key, collection[key]);
            }
            if (string.IsNullOrEmpty(newValue))
            {
                routeValueDictionary.Remove(newKey);
            }
            else
            {
                if (routeValueDictionary.ContainsKey(newKey))
                    routeValueDictionary.Remove(newKey);

                routeValueDictionary.Add(newKey, newValue);
            }
            return routeValueDictionary;
        }

        public static IHtmlString TechTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool disabled = false)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            //Attempt to get the StringLengthAttribute from the Model
            MaxLengthAttribute stringLengthAttribute = memberExpression.Member.GetCustomAttributes(typeof(MaxLengthAttribute), false).FirstOrDefault() as MaxLengthAttribute;

            var attributes = new RouteValueDictionary(htmlAttributes);
            if (stringLengthAttribute != null && stringLengthAttribute.Length > 0)
            {
                attributes.Add("maxlength", Convert.ToString(stringLengthAttribute.Length));
                attributes.Add("onkeyup", string.Format("if (this.value.length > this.getAttribute('maxlength')) this.value = this.value.substring(0, this.getAttribute('maxlength'));"));
            }

            if (disabled)
            {
                attributes["disabled"] = "disabled";
            }
            return htmlHelper.TextBoxFor(expression, attributes);
        }

        public static IHtmlString TechTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool disabled = false)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            //Attempt to get the StringLengthAttribute from the Model
            MaxLengthAttribute stringLengthAttribute = memberExpression.Member.GetCustomAttributes(typeof(MaxLengthAttribute), false).FirstOrDefault() as MaxLengthAttribute;

            var attributes = new RouteValueDictionary(htmlAttributes);
            if (stringLengthAttribute != null && stringLengthAttribute.Length > 0)
            {
                attributes.Add("maxlength", Convert.ToString(stringLengthAttribute.Length));
                attributes.Add("onkeyup", string.Format("if (this.value.length > this.getAttribute('maxlength')) this.value = this.value.substring(0, this.getAttribute('maxlength'));"));
            }

            if (disabled)
            {
                attributes["disabled"] = "disabled";
            }
            return htmlHelper.TextAreaFor(expression, attributes);
        }

        public static IHtmlString TechCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes, bool disabled)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            if (disabled)
            {
                attributes["disabled"] = "disabled";
            }
            return htmlHelper.CheckBoxFor(expression, attributes);
        }

        public static IHtmlString TechShowFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string templateName, bool disabled)
        {
            return disabled ?
                            htmlHelper.DisplayFor(expression, templateName)
                            :
                            htmlHelper.EditorFor(expression, templateName);
        }

        /// <summary>
        /// Ebrs the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <returns></returns>
        public static IHtmlString TechDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes, bool disabled)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            if (disabled)
            {
                attributes["disabled"] = "disabled";
            }
            return htmlHelper.DropDownListFor(expression, selectList, attributes);
        }

        /// <summary>
        /// Ebrs the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <returns></returns>
        public static IHtmlString TechDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes, bool disabled)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            if (disabled)
            {
                attributes["disabled"] = "disabled";
            }
            return htmlHelper.DropDownListFor(expression, selectList, optionLabel, attributes);
        }


        private static string GetEnumDescription<TEnum>(TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}