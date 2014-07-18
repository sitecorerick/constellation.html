namespace Constellation.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderProgressExtension
	{
		/// <summary>
		/// Creates a Progress HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="value">
		/// The value.
		/// </param>
		/// <param name="max">
		/// The max.
		/// </param>
		/// <param name="id">
		/// The value of the id attribute.
		/// </param>
		/// <param name="cssClass">
		/// The value of the class attribute.
		/// </param>
		/// <returns>
		/// Nav HTML tag with attributes.
		/// </returns>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here."), SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderProgress(this HtmlTextWriter writer, int value, int max, string id = null, string cssClass = null)
		{
			return writer.RenderProgress(ToAttributes(value, max, id, cssClass));
		}

		/// <summary>
		/// Creates a Progress HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>Nav HTML tag with attributes.</returns>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		public static HtmlTag RenderProgress(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, "progress", attributes);
		}

		/// <summary>
		/// The to attributes.
		/// </summary>
		/// <param name="value">
		/// The value.
		/// </param>
		/// <param name="max">
		/// The max.
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
		private static HtmlAttribute[] ToAttributes(int value, int max, string id, string cssClass)
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

			attributes.Add(new HtmlAttribute("value", value.ToString(CultureInfo.InvariantCulture)));

			attributes.Add(new HtmlAttribute("max", max.ToString(CultureInfo.InvariantCulture)));

			return attributes.ToArray();
		}
	}
}
