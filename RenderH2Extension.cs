namespace Constellation.Html
{
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderH2Extension
	{
		/// <summary>
		/// Creates a H2 HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="id">The value of the id attribute.</param>
		/// <param name="cssClass">The value of the class attribute.</param>
		/// <returns>H2 HTML tag with attributes.</returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderH2(this HtmlTextWriter writer, string id = null, string cssClass = null)
		{
			return writer.RenderTag(HtmlTextWriterTag.H2, id, cssClass);
		}

		/// <summary>
		/// Creates a H2 HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>H2 HTML tag with attributes.</returns>
		public static HtmlTag RenderH2(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, HtmlTextWriterTag.H2, attributes);
		}
	}
}
