using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Our.Umbraco.BackOfficePowerScripts.Interfaces;

namespace Our.Umbraco.BackOfficePowerScripts.Filters
{
	/// <summary>
	/// Response filter for injecting resources.
	/// </summary>
	public sealed class InjectResources : MemoryStream
	{
		/// <summary>
		/// Constant for the closing HTML 'body' tag.
		/// </summary>
		private const string HtmlBodyClosing = "</body>";

		/// <summary>
		/// Constant for the closing HTML 'head' tag.
		/// </summary>
		private const string HtmlHeadClosing = "</head>";

		/// <summary>
		/// Field for the response output stream.
		/// </summary>
		private Stream OutputStream = null;

		/// <summary>
		/// Field for the HTML output for the JavaScript references.
		/// </summary>
		private StringBuilder HtmlScripts;

		/// <summary>
		/// Field for the HTML output for the CSS references.
		/// </summary>
		private StringBuilder HtmlStyles;

		/// <summary>
		/// Initializes a new instance of the <see cref="InjectResources"/> class.
		/// </summary>
		/// <param name="output">The output.</param>
		/// <param name="clientResources">The client resources.</param>
		public InjectResources(Stream output, List<ClientResource> clientResources)
		{
			this.OutputStream = output;

			this.HtmlScripts = new StringBuilder();
			this.HtmlStyles = new StringBuilder();

			if (clientResources != null && clientResources.Count > 0)
			{
				// CSS resources
				var styles = clientResources.Where(r => r.Type == ClientResourceType.Css).ToList();
				if (styles != null && styles.Count > 0)
				{
					styles.Sort((a, b) => a.Priority.CompareTo(b.Priority));

					foreach (var style in styles)
					{
						this.HtmlStyles.Append(style).AppendLine();
					}
				}

				// JavaScript resources
				var scripts = clientResources.Where(r => r.Type == ClientResourceType.JavaScript).ToList();
				if (scripts != null && scripts.Count > 0)
				{
					scripts.Sort((a, b) => a.Priority.CompareTo(b.Priority));

					foreach (var script in scripts)
					{
						this.HtmlScripts.Append(script).AppendLine();
					}
				}
			}

			this.HtmlScripts.AppendLine(HtmlBodyClosing);
			this.HtmlStyles.AppendLine(HtmlHeadClosing);
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

			if (content.Contains(HtmlHeadClosing))
			{
				// append the <link> tags to the closing </head> tag.
				content = content.Replace(HtmlHeadClosing, this.HtmlStyles.ToString());
			}

			if (content.Contains(HtmlBodyClosing))
			{
				// append the <script> tags to the closing </body> tag.
				content = content.Replace(HtmlBodyClosing, this.HtmlScripts.ToString());	
			}

			// write the content changes back to the buffer.
			byte[] outputBuffer = UTF8Encoding.UTF8.GetBytes(content);
			this.OutputStream.Write(outputBuffer, 0, outputBuffer.Length);
		}
	}
}