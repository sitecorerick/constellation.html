namespace Constellation.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderLinkExtension
	{
		/// <summary>
		/// Creates a Link HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="href">The value of the href attribute.</param>
		/// <param name="rel">The value of the rel attribute.</param>
		/// <param name="type">The value of the type attribute.</param>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static void RenderLink(this HtmlTextWriter writer, string href, string rel = null, string type = null)
		{
			RenderLink(writer, ToAttributes(href, rel, type));
		}

		/// <summary>
		/// Creates a Link HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		public static void RenderLink(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			writer.RenderSelfClosingTag(HtmlTextWriterTag.Link, attributes);
		}

		#region Attribute Management
		/// <summary>
		/// Converts a series of strings to an array of HtmlAttributes.
		/// </summary>
		/// <param name="href">A URL string.</param>
		/// <param name="rel">A rel string.</param>
		/// <param name="type">A type string.</param>
		/// <returns>An array of HtmlAttributes. The Array may be empty.</returns>
		private static HtmlAttribute[] ToAttributes(string href, string rel, string type)
		{
			var attributes = new List<HtmlAttribute>();

			if (!string.IsNullOrEmpty(rel))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Rel, rel));
			}

			if (!string.IsNullOrEmpty(href))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Href, href));
			}

			if (!string.IsNullOrEmpty(type))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Type, type));
			}

			return attributes.ToArray();
		}
		#endregion
	}
}
