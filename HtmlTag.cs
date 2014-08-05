namespace Constellation.Html
{
	using System;
	using System.Collections.Generic;
	using System.Web.UI;

	/// <summary>
	/// Creates opening and closing HTML tags.
	/// </summary>
	public class HtmlTag : IDisposable
	{
		private readonly HtmlTextWriter writer;
		private readonly HtmlAttribute[] attributes;
		private readonly string tag;
		private readonly TagStyle tagStyle;

		/// <summary>
		/// Initializes a new instance of the HtmlTag class. Renders the opening tag of an HTML node, including any attributes.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="tag">
		/// The type of HTML tag.
		/// </param>
		/// <param name="attributes">
		/// HTML attributes.
		/// </param>
		public HtmlTag(HtmlTextWriter writer, HtmlTextWriterTag tag, params HtmlAttribute[] attributes)
		{
			this.writer = writer;
			this.attributes = attributes;
			this.tag = tag.ToString().ToLower();
			this.tagStyle = TagStyle.Inline;
			this.StartRender();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlTag class. Renders the opening tag of an HTML node, including any attributes.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="tag">
		/// The type of HTML tag.
		/// </param>
		/// <param name="attributes">
		/// HTML attributes.
		/// </param>
		public HtmlTag(HtmlTextWriter writer, string tag, params HtmlAttribute[] attributes)
		{
			this.writer = writer;
			this.attributes = attributes;
			this.tag = tag;
			this.tagStyle = TagStyle.Inline;
			this.StartRender();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlTag class. Renders the opening tag of an HTML node, including any attributes.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="tag">
		/// The type of HTML tag.
		/// </param>
		/// <param name="style">
		/// The style.
		/// </param>
		/// <param name="attributes">
		/// HTML attributes.
		/// </param>
		public HtmlTag(HtmlTextWriter writer, HtmlTextWriterTag tag, TagStyle style, params HtmlAttribute[] attributes)
		{
			this.writer = writer;
			this.attributes = attributes;
			this.tag = tag.ToString().ToLower();
			this.tagStyle = style;
			this.StartRender();
		}

		/// <summary>
		/// Initializes a new instance of the HtmlTag class. Renders the opening tag of an HTML node, including any attributes.
		/// </summary>
		/// <param name="writer">
		/// The HTMLTextWriter.
		/// </param>
		/// <param name="tag">
		/// The type of HTML tag.
		/// </param>
		/// <param name="style">
		/// The style.
		/// </param>
		/// <param name="attributes">
		/// HTML attributes.
		/// </param>
		public HtmlTag(HtmlTextWriter writer, string tag, TagStyle style, params HtmlAttribute[] attributes)
		{
			this.writer = writer;
			this.attributes = attributes;
			this.tag = tag;
			this.tagStyle = style;
			this.StartRender();
		}

		/// <summary>
		/// Determines how the tag and surrounding whitespace is rendered.
		/// </summary>
		public enum TagStyle
		{
			/// <summary>
			/// Tag is rendered without any preceding space and without any line break between the tag and inner text.
			/// </summary>
			Inline,

			/// <summary>
			/// Tag is rendered on a new line with indenting but without any line break between the tag and inner text.
			/// </summary>
			TagOnOneLine,

			/// <summary>
			/// Tag is rendered on a new line with indenting, a line break separates the tag from the inner text on both ends of the tag.
			/// </summary>
			TagOnSeparateLine
		}

		/// <summary>
		/// Closes the HTML tag.
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Closes the HTML tag.
		/// </summary>
		/// <param name="disposing">Whether we're actually disposing.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.tagStyle == TagStyle.TagOnSeparateLine)
				{
					this.writer.WriteLine();
				}

				this.writer.RenderEndTag();

				if (this.tagStyle != TagStyle.Inline)
				{
					this.writer.WriteLine();
					this.writer.Indent = this.writer.Indent - 1;
				}
			}
		}

		/// <summary>
		/// The start render.
		/// </summary>
		private void StartRender()
		{

			if (this.tagStyle != TagStyle.Inline)
			{
				this.writer.Indent = this.writer.Indent + 1;
				this.writer.WriteLine();
			}

			this.RenderAttributes(this.attributes);
			this.writer.RenderBeginTag(this.tag);

			if (this.tagStyle == TagStyle.TagOnSeparateLine)
			{
				this.writer.WriteLine();
			}
		}

		/// <summary>
		/// Renders the attributes for an HTML tag.
		/// </summary>
		/// <param name="attributes">HTML attributes.</param>
		private void RenderAttributes(IEnumerable<HtmlAttribute> attributes)
		{
			if (attributes == null)
			{
				return;
			}

			foreach (var attr in attributes)
			{
				this.writer.AddAttribute(attr.Name, attr.Value, false);
			}
		}
	}
}
