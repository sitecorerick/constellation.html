namespace Spark.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderMetaExtension
	{
		/// <summary>
		/// Creates a Meta HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="name">The value of the name attribute.</param>
		/// <param name="content">The value of the content attribute.</param>
		public static void RenderMeta(this HtmlTextWriter writer, string name, string content)
		{
			RenderMeta(writer, ToAttributes(name, content));
		}

		/// <summary>
		/// Creates a Meta HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		public static void RenderMeta(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			writer.RenderSelfClosingTag(HtmlTextWriterTag.Meta, attributes);
		}

		#region Attribute Management
		/// <summary>
		/// Converts a series of strings to an array of HtmlAttributes.
		/// </summary>
		/// <param name="name">A name string.</param>
		/// <param name="content">A content string.</param>
		/// <returns>An array of HtmlAttributes. The Array may be empty.</returns>
		private static HtmlAttribute[] ToAttributes(string name, string content)
		{
			var attributes = new List<HtmlAttribute>();

			if (!string.IsNullOrEmpty(name))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Name, name));
			}

			if (!string.IsNullOrEmpty(content))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Content, content));
			}

			return attributes.ToArray();
		}
		#endregion
	}
}
