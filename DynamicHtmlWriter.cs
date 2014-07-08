namespace Constellation.Html
{
	using System;
	using System.Dynamic;
	using System.Linq;
	using System.Web.UI;

	/// <summary>
	/// A class that acts as a wrapper around an <see cref="HtmlTextWriter"/> instance to add dynamic type
	/// functionality when rendering html.
	/// The method name in a dynamic method call will serve as tag name and the named parameters will be attribute names.
	/// The underscore character in the named parameters will be replaced with a dash to support having a dash in attribute names.
	/// It's important to only use named parameters in the method rather than just passing the arguments or mixing named parameters with
	/// positional parameters. In such scenarios the behavior will be very nondeterministic.
	/// The only method that will not be translated to HTML tags is Write, and only the supported overloads will be called and an exception will be thrown 
	/// by CLR if a non supported overload is called.
	/// </summary>
	public class DynamicHtmlWriter : DynamicObject
	{
		/// <summary>
		/// These are all HTML self closing tags. the most common ones are put first to increase performance. 
		/// </summary>
		private static readonly string[] SelfClosingTags = { "img", "br", "input", "meta", "area", "hr", "base", "col", "command", "embed", "keygen", "link", "param", "source", "track", "wbr" };

		/// <summary>
		/// the <see cref="HtmlTextWriter"/> instance to output the generated Html to.
		/// </summary>
		private readonly HtmlTextWriter writer;

		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicHtmlWriter"/> class.
		/// </summary>
		/// <param name="writer">The <see cref="HtmlTextWriter"/> that the html will be outputted to</param>
		public DynamicHtmlWriter(HtmlTextWriter writer)
		{
			this.writer = writer;
		}

		/// <summary>
		/// Provides the implementation for operations that invoke a member. Classes
		/// derived from the System.Dynamic.DynamicObject class can override this method
		/// to specify dynamic behavior for operations such as calling a method.
		/// </summary>
		/// <param name="binder">
		/// Provides information about the dynamic operation. The binder.Name property
		/// provides the name of the member on which the dynamic operation is performed.
		/// For example, for the statement sampleObject.SampleMethod(100), where sampleObject
		/// is an instance of the class derived from the System.Dynamic.DynamicObject
		/// class, binder.Name returns "SampleMethod". The binder.IgnoreCase property
		/// specifies whether the member name is case-sensitive.
		/// </param>
		/// <param name="args">The arguments that are passed to the object member during the invoke operation.</param>
		/// <param name="result">The result of the member invocation.</param>
		/// <returns>true if the operation is successful; otherwise, false. </returns>
		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			var methodName = binder.Name.ToLower();

			// Checking to see if an overload of write is called that is not supported.
			// all supported overloads should be explicitly implemented in this type. 
			if (methodName == "Write")
			{
				result = null;
				return false;
			}

			// All string.Concat does is to do a null check on the arg.
			var attributes = binder.CallInfo.ArgumentNames
									.Select((it, i) => new HtmlAttribute(it.Replace('_', '-'), string.Concat(args[i]))).ToArray();

			if (Array.IndexOf(SelfClosingTags, methodName) == -1)
			{
				result = new HtmlTag(this.writer, methodName, attributes);
			}
			else
			{
				result = null;
				this.writer.RenderSelfClosingTag(methodName, attributes);
			}

			return true;
		}

		/// <summary>
		/// Writes the text representation of a Boolean value to the output stream, along
		/// with any pending tab spacing.
		/// </summary>
		/// <param name="value">The System.Boolean to write to the output stream.</param>
		public void Write(bool value)
		{
			this.writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a Unicode character to the output stream,
		/// along with any pending tab spacing.
		/// </summary>
		/// <param name="value">The Unicode character to write to the output stream.</param>
		public void Write(char value)
		{
			this.writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a double-precision floating-point number
		/// to the output stream, along with any pending tab spacing.
		/// </summary>
		/// <param name="value">The double-precision floating-point number to write to the output stream.</param>
		public void Write(double value)
		{
			this.writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a single-precision floating-point number
		/// to the output stream, along with any pending tab spacing.
		/// </summary>
		/// <param name="value">The single-precision floating-point number to write to the output stream.</param>
		public void Write(float value)
		{
			this.writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a 32-byte signed integer to the output
		/// stream, along with any pending tab spacing.
		/// </summary>
		/// <param name="value">The 32-byte signed integer to write to the output stream.</param>
		public void Write(int value)
		{
			this.writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a 64-byte signed integer to the output
		/// stream, along with any pending tab spacing.
		/// </summary>
		/// <param name="value">The 64-byte signed integer to write to the output stream.</param>
		public void Write(long value)
		{
			this.writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of an object to the output stream, along with
		/// any pending tab spacing.
		/// </summary>
		/// <param name="value">The object to write to the output stream.</param>
		public void Write(object value)
		{
			this.writer.Write(value);
		}

		/// <summary>
		/// Writes the specified string to the output stream, along with any pending
		/// tab spacing.
		/// </summary>
		/// <param name="s">The string to write to the output stream.</param>
		public void Write(string s)
		{
			this.writer.Write(s);
		}

		/// <summary>
		/// Writes a tab string and a formatted string to the output stream, using the
		/// same semantics as the System.String.Format(System.String,System.Object) method,
		/// along with any pending tab spacing.
		/// </summary>
		/// <param name="format">A string that contains zero or more format items.</param>
		/// <param name="arg0">An object to format.</param>
		public void Write(string format, object arg0)
		{
			this.writer.Write(format, arg0);
		}

		/// <summary>
		/// Writes a formatted string that contains the text representation of an object
		/// array to the output stream, along with any pending tab spacing. This method
		/// uses the same semantics as the System.String.Format(System.String,System.Object[])
		/// method.
		/// </summary>
		/// <param name="format">A string that contains zero or more format items.</param>
		/// <param name="arg">An object array to format.</param>
		public void Write(string format, params object[] arg)
		{
			this.writer.Write(format, arg);
		}

		/// <summary>
		/// Writes a formatted string that contains the text representation of two objects
		/// to the output stream, along with any pending tab spacing. This method uses
		/// the same semantics as the System.String.Format(System.String,System.Object,System.Object)
		/// method.
		/// </summary>
		/// <param name="format">A string that contains zero or more format items.</param>
		/// <param name="arg0">An object to format.</param>
		/// <param name="arg1">An object to format .</param>
		public void Write(string format, object arg0, object arg1)
		{
			this.writer.Write(format, arg0, arg1);
		}

		/// <summary>
		/// Encodes the specified text for the requesting device, and then writes it
		/// to the output stream.
		/// </summary>
		/// <param name="text">The text string to encode and write to the output stream.</param>
		public void WriteEncodedText(string text)
		{
			this.writer.WriteEncodedText(text);
		}
	}
}
