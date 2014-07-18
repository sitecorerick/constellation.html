namespace Constellation.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderDialogExtension
	{
		/// <summary>
		/// Creates a Div HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="open">
		/// The open.
		/// </param>
		/// <param name="id">
		/// The value of the id attribute.
		/// </param>
		/// <param name="cssClass">
		/// The value of the class attribute.
		/// </param>
		/// <returns>
		/// Div HTML tag with attributes.
		/// </returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderDialog(this HtmlTextWriter writer, bool open, string id = null, string cssClass = null)
		{
			return writer.RenderDialog(ToAttributes(open, id, cssClass));
		}

		/// <summary>
		/// Creates a Div HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>Div HTML tag with attributes.</returns>
		public static HtmlTag RenderDialog(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, "dialog", attributes);
		}

		/// <summary>
		/// The to attributes.
		/// </summary>
		/// <param name="open">
		/// The open.
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
		private static HtmlAttribute[] ToAttributes(bool open, string id, string cssClass)
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

			if (open)
			{
				attributes.Add(new HtmlAttribute("open", "open"));
			}

			return attributes.ToArray();
		}
	}
}
