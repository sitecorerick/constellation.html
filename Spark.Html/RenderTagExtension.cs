namespace Spark.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderTagExtension
	{
		#region Strongly Typed Tags
		/// <summary>
		/// Creates an HTML tag and adds the provided ID and CSS Class to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="id">The CSS ID of the HTML tag.</param>
		/// <param name="cssClass">The CSS Class of the HTML tag.</param>
		/// <returns>HTML tag with id and class attributes.</returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderTag(this HtmlTextWriter writer, HtmlTextWriterTag tag, string id = null, string cssClass = null)
		{
			return RenderTag(writer, tag, ToAttributes(id, cssClass));
		}

		/// <summary>
		/// Creates an HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>HTML tag with attributes.</returns>
		public static HtmlTag RenderTag(this HtmlTextWriter writer, HtmlTextWriterTag tag, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, tag, attributes);
		}
		#endregion

		#region Self-Closing
		/// <summary>
		/// Creates an HTML tag and adds the provided ID and CSS Class to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="id">The CSS ID of the HTML tag.</param>
		/// <param name="cssClass">The CSS Class of the HTML tag.</param>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static void RenderSelfClosingTag(this HtmlTextWriter writer, HtmlTextWriterTag tag, string id = null, string cssClass = null)
		{
			RenderSelfClosingTag(writer, tag, ToAttributes(id, cssClass));
		}

		/// <summary>
		/// Creates a self closing HTML tag, such as line break or image.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="attributes">HTML attributes.</param>
		public static void RenderSelfClosingTag(this HtmlTextWriter writer, HtmlTextWriterTag tag, params HtmlAttribute[] attributes)
		{
			using (new HtmlTag(writer, tag, attributes))
			{
			}
		}
		#endregion

		#region Ad-Hoc Self Closing Tags by Text
		/// <summary>
		/// Creates an HTML tag and adds the provided ID and CSS Class to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag as a string.</param>
		/// <param name="id">The CSS ID of the HTML tag.</param>
		/// <param name="cssClass">The CSS Class of the HTML tag.</param>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static void RenderSelfClosingTag(this HtmlTextWriter writer, string tag, string id = null, string cssClass = null)
		{
			RenderSelfClosingTag(writer, tag, ToAttributes(id, cssClass));
		}

		/// <summary>
		/// Creates a self closing HTML tag, such as line break or image.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag as a string.</param>
		/// <param name="attributes">HTML attributes.</param>
		public static void RenderSelfClosingTag(this HtmlTextWriter writer, string tag, params HtmlAttribute[] attributes)
		{
			writer.WriteBeginTag(tag);
			foreach (var attribute in attributes)
			{
				writer.WriteAttribute(attribute.Name, attribute.Value);
			}

			writer.Write("/>");
		}

		#endregion

		#region Ad-Hoc Tags by Text
		/// <summary>
		/// Creates an HTML tag and adds the provided ID and CSS Class to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="id">The CSS ID of the HTML tag.</param>
		/// <param name="cssClass">The CSS Class of the HTML tag.</param>
		/// <returns>HTML tag with id and class attributes.</returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderTag(this HtmlTextWriter writer, string tag, string id = null, string cssClass = null)
		{
			return RenderTag(writer, tag, ToAttributes(id, cssClass));
		}

		/// <summary>
		/// Creates an HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>HTML tag with attributes.</returns>
		public static HtmlTag RenderTag(this HtmlTextWriter writer, string tag, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, tag, attributes);
		}
		#endregion

		#region Attribute Management
		/// <summary>
		/// Converts a series of strings to an array of HtmlAttributes.
		/// </summary>
		/// <param name="id">A CSS ID string.</param>
		/// <param name="cssClass">A CSS Class string.</param>
		/// <returns>An array of HtmlAttributes. The Array may be empty.</returns>
		private static HtmlAttribute[] ToAttributes(string id, string cssClass)
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

			return attributes.ToArray();
		}
		#endregion
	}
}