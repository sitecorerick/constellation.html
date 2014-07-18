namespace Constellation.Html
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderTimeExtension
	{
		/// <summary>
		/// Creates a time HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="dateTime">
		/// The date Time formatted for Zulu time if appropriate using this format:
		/// yyyy-MM-ddTHH:mm:ssZ
		/// </param>
		/// <param name="id">
		/// The value of the id attribute.
		/// </param>
		/// <param name="cssClass">
		/// The value of the class attribute.
		/// </param>
		/// <returns>
		/// Span HTML tag with attributes.
		/// </returns>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here."), SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderTime(this HtmlTextWriter writer, string dateTime = null, string id = null, string cssClass = null)
		{
			return writer.RenderTime(ToAttributes(dateTime, id, cssClass));
		}

		/// <summary>
		/// Creates a time HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="dateTime">
		/// The date Time.
		/// </param>
		/// <param name="id">
		/// The value of the id attribute.
		/// </param>
		/// <param name="cssClass">
		/// The value of the class attribute.
		/// </param>
		/// <returns>
		/// Span HTML tag with attributes.
		/// </returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderTime(this HtmlTextWriter writer, DateTime dateTime, string id = null, string cssClass = null)
		{
			// YYYY-MM-DDThh:mm:ssTZD
			return writer.RenderTime(ToAttributes(dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"), id, cssClass));
		}

		/// <summary>
		/// Creates a time HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>Span HTML tag with attributes.</returns>
		public static HtmlTag RenderTime(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, "time", attributes);
		}

		/// <summary>
		/// The to attributes.
		/// </summary>
		/// <param name="dateTime">
		/// The date time.
		/// </param>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <param name="cssClass">
		/// The CSS class.
		/// </param>
		/// <returns>
		/// The <see cref="HtmlAttribute"/>.
		/// </returns>
		private static HtmlAttribute[] ToAttributes(string dateTime, string id, string cssClass)
		{
			var attributes = new List<HtmlAttribute>();

			if (!string.IsNullOrEmpty(id))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Id, id));
			}

			if (!string.IsNullOrEmpty(cssClass))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Class, cssClass));
			}

			if (!string.IsNullOrEmpty(dateTime))
			{
				attributes.Add(new HtmlAttribute("datetime", dateTime));
			}

			return attributes.ToArray();
		}
	}
}
