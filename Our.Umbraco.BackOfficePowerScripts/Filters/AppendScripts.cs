using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Our.Umbraco.BackOfficePowerScripts.Extensions;
using umbraco;
using umbraco.cms.helpers;
using umbraco.presentation.umbracobase;

namespace Our.Umbraco.BackOfficePowerScripts.Filters
{
	/// <summary>
	/// Response filter for parsing shortcodes.
	/// </summary>
	public class AppendScripts : MemoryStream
	{
		const string HTML_BODY_CLOSING = "</body>";

		/// <summary>
		/// Field for the response output stream.
		/// </summary>
		private Stream OutputStream = null;

		private StringBuilder HtmlScripts;

		/// <summary>
		/// Initializes a new instance of the <see cref="ParseShortcodes"/> class.
		/// </summary>
		/// <param name="output">The output.</param>
		public AppendScripts(Stream output)
		{
			// grab the response output stream.
			this.OutputStream = output;
			this.HtmlScripts = new StringBuilder();

			var scripts = Common.RegisteredScripts;
			if (scripts != null && scripts.Count > 0)
			{
				for (int i = 0; i < scripts.Count; i++)
				{
					this.HtmlScripts.Append(scripts[i]).AppendLine();
				}
			}

			this.HtmlScripts.AppendLine(HTML_BODY_CLOSING);
		}

		/// <summary>
		/// Writes a block of bytes to the current stream using data read from buffer.
		/// </summary>
		/// <param name="buffer">The buffer to write data from.</param>
		/// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin writing from.</param>
		/// <param name="count">The maximum number of bytes to write.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// 	<paramref name="buffer"/> is null. </exception>
		/// <exception cref="T:System.NotSupportedException">The stream does not support writing. For additional information see <see cref="P:System.IO.Stream.CanWrite"/>.-or- The current position is closer than <paramref name="count"/> bytes to the end of the stream, and the capacity cannot be modified. </exception>
		/// <exception cref="T:System.ArgumentException">
		/// 	<paramref name="offset"/> subtracted from the buffer length is less than <paramref name="count"/>. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// 	<paramref name="offset"/> or <paramref name="count"/> are negative. </exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
		/// <exception cref="T:System.ObjectDisposedException">The current stream instance is closed. </exception>
		public override void Write(byte[] buffer, int offset, int count)
		{
			// get the string from the buffer.
			string content = UTF8Encoding.UTF8.GetString(buffer);

			// append the <script> tags to the closing </body> tag.
			content = content.Replace(HTML_BODY_CLOSING, this.HtmlScripts.ToString());

			// write the content changes back to the buffer.
			byte[] outputBuffer = UTF8Encoding.UTF8.GetBytes(content);
			this.OutputStream.Write(outputBuffer, 0, outputBuffer.Length);
		}
	}
}