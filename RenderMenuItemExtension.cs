namespace Constellation.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderMenuItemExtension
	{
		/// <summary>
		/// Creates a Menu Item HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="label">
		/// The label.
		/// </param>
		/// <param name="icon">
		/// The icon.
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
		public static HtmlTag RenderMenuItem(this HtmlTextWriter writer, string label = null, string icon = null, string id = null, string cssClass = null)
		{
			return writer.RenderMenuItem(ToAttributes(label, icon, id, cssClass));
		}

		/// <summary>
		/// Creates a Menu Item HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>Div HTML tag with attributes.</returns>
		public static HtmlTag RenderMenuItem(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, "menuitem", attributes);
		}

		/// <summary>
		/// The to attributes.
		/// </summary>
		/// <param name="label">
		/// The label.
		/// </param>
		/// <param name="icon">
		/// The icon.
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
		private static HtmlAttribute[] ToAttributes(string label, string icon, string id, string cssClass)
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

			if (!string.IsNullOrEmpty(label))
			{
				attributes.Add(new HtmlAttribute("label", label));
			}

			if (!string.IsNullOrEmpty(icon))
			{
				attributes.Add(new HtmlAttribute("icon", icon));
			}

			return attributes.ToArray();
		}
	}
}
