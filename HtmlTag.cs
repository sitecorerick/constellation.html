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
		/// <summary>
		/// The HTMLTextWriter.
		/// </summary>
		private readonly HtmlTextWriter writer;

		/// <summary>
		/// Initializes a new instance of the HtmlTag class. Renders the opening tag of an HTML node, including any attributes.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="attributes">HTML attributes.</param>
		public HtmlTag(HtmlTextWriter writer, HtmlTextWriterTag tag, params HtmlAttribute[] attributes)
		{
			this.writer = writer;
			this.RenderAttributes(attributes);
			writer.RenderBeginTag(tag);
		}

		/// <summary>
		/// Initializes a new instance of the HtmlTag class. Renders the opening tag of an HTML node, including any attributes.
		/// </summary>
		/// <param name="writer">The HTMLTextWriter.</param>
		/// <param name="tag">The type of HTML tag.</param>
		/// <param name="attributes">HTML attributes.</param>
		public HtmlTag(HtmlTextWriter writer, string tag, params HtmlAttribute[] attributes)
		{
			this.writer = writer;
			this.RenderAttributes(attributes);
			writer.RenderBeginTag(tag);
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
				this.writer.RenderEndTag();
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
