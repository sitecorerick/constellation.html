namespace Constellation.Html
{
	using System.Diagnostics.CodeAnalysis;
	using System.Web.UI;

	/// <summary>
	/// An HTML attribute.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Accurate name for class.")]
	public class HtmlAttribute
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the HtmlAttribute class.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <param name="value">The value of the attribute.</param>
		public HtmlAttribute(HtmlTextWriterAttribute attribute, string value)
		{
			this.Name = attribute.ToString().ToLower();
			this.Value = value;
		}

		/// <summary>
		/// Initializes a new instance of the HtmlAttribute class.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <param name="value">The value of the attribute.</param>
		public HtmlAttribute(string attribute, string value)
		{
			this.Name = attribute;
			this.Value = value;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name of the attribute(class, id, etc).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the value of the attribute.
		/// </summary>
		public string Value { get; set; }
		#endregion
	}
}
