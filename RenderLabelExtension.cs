namespace Spark.Html
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// Extension to make working with HtmlTextWriter easier.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "HTML Tags are not English, FX Cop. Stop correcting my spelling.")]
	public static class RenderLabelExtension
	{
		/// <summary>
		/// Creates a Label HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="forelement">The element the label is for.</param>
		/// <param name="id">The value of the id attribute.</param>
		/// <param name="cssClass">The value of the class attribute.</param>
		/// <returns>Label HTML tag with attributes.</returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Welcome to .NET 4.0 FX Cop.")]
		public static HtmlTag RenderLabel(this HtmlTextWriter writer, string forelement, string id = null, string cssClass = null)
		{
			return RenderLabel(writer, ToAttributes(forelement, id, cssClass));
		}

		/// <summary>
		/// Creates a Label HTML tag and adds any provided attributes to the tag.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="attributes">HTML attributes.</param>
		/// <returns>Label HTML tag with attributes.</returns>
		public static HtmlTag RenderLabel(this HtmlTextWriter writer, params HtmlAttribute[] attributes)
		{
			return new HtmlTag(writer, HtmlTextWriterTag.Label, attributes);
		}

		#region Attribute Management
		/// <summary>
		/// Converts a series of strings to an array of HtmlAttributes.
		/// </summary>
		/// <param name="forelement">
		/// The forelement.
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
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "I had to make up a word.")]
		private static HtmlAttribute[] ToAttributes(string forelement, string id, string cssClass)
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

			if (!string.IsNullOrEmpty(forelement))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.For, forelement));
			}

			return attributes.ToArray();
		}
		#endregion
	}
}
