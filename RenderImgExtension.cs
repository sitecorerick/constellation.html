namespace Constellation.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderImgExtension
	{
		/// <summary>
		/// Creates an Image HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="src">
		/// The value of the src attribute.
		/// </param>
		/// <param name="alt">
		/// The value of the alt attribute.
		/// </param>
		/// <param name="title">
		/// The value of the title attribute.
		/// </param>
		/// <param name="id">
		/// The value of the id attribute.
		/// </param>
		/// <param name="cssClass">
		/// The value of the class attribute.
		/// </param>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static void RenderImg(this HtmlTextWriter writer, string src, string alt = null, string title = null, string id = null, string cssClass = null)
		{
			RenderImg(writer, ToAttributes(src, alt, title, id, cssClass));
		}

		/// <summary>
		/// Creates an Image HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		public static void RenderImg(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			writer.RenderSelfClosingTag(HtmlTextWriterTag.Img, attributes);
		}

		#region Attribute Management
		/// <summary>
		/// Converts a series of strings to an array of HtmlAttributes.
		/// </summary>
		/// <param name="src">
		/// A src string.
		/// </param>
		/// <param name="alt">
		/// An alt string.
		/// </param>
		/// <param name="title">
		/// The title.
		/// </param>
		/// <param name="id">
		/// A CSS ID string.
		/// </param>
		/// <param name="cssClass">
		/// A CSS Class string.
		/// </param>
		/// <returns>
		/// An array of HtmlAttributes. The Array may be empty.
		/// </returns>
		private static HtmlAttribute[] ToAttributes(string src, string alt, string title, string id, string cssClass)
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

			if (!string.IsNullOrEmpty(src))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Src, src));
			}

			if (!string.IsNullOrEmpty(alt))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Alt, alt));
			}

			if (!string.IsNullOrEmpty(title))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Title, title));
			}

			return attributes.ToArray();
		}
		#endregion
	}
}
