namespace Constellation.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderAExtension
	{
		/// <summary>
		/// Creates a A HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="href">The value of the href attribute.</param>
		/// <param name="target">The value of the target attribute.</param>
		/// <param name="title">The value of the title attribute.</param>
		/// <param name="id">The value of the id attribute.</param>
		/// <param name="cssClass">The value of the class attribute.</param>
		/// <returns>A HTML tag with attributes.</returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderA(this HtmlTextWriter writer, string href, string target = null, string title = null, string id = null, string cssClass = null)
		{
			return RenderA(writer, ToAttributes(href, target, title, id, cssClass));
		}

		/// <summary>
		/// Creates a A HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">The tag attributes.</param>
		/// <returns>A HTML tag with attributes.</returns>
		public static HtmlTag RenderA(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, HtmlTextWriterTag.A, attributes);
		}

		#region Attribute Management
		/// <summary>
		/// Converts a series of strings to an array of HtmlAttributes.
		/// </summary>
		/// <param name="href">A URL string.</param>
		/// <param name="target">A target string.</param>
		/// <param name="title">The value of the title attribute if any.</param>
		/// <param name="id">A CSS ID string.</param>
		/// <param name="cssClass">A CSS Class string.</param>
		/// <returns>An array of HtmlAttributes. The Array may be empty.</returns>
		private static HtmlAttribute[] ToAttributes(string href, string target, string title, string id, string cssClass)
		{
			var attributes = new List<HtmlAttribute>();

			if (!string.IsNullOrEmpty(href))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Href, href));
			}

			if (!string.IsNullOrEmpty(target))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Target, target));
			}

			if (!string.IsNullOrEmpty(title))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Title, title));
			}

			if (!string.IsNullOrEmpty(id))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Id, id));
			}

			if (!string.IsNullOrEmpty(cssClass))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Class, cssClass));
			}

			return attributes.ToArray();
		}
		#endregion
	}
}
