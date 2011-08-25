using System.Configuration;
using System.Web;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts
{
	/// <summary>
	/// The configuration element for a script.
	/// </summary>
	public class ScriptElement : ConfigurationElement
	{
		/// <summary>
		/// Field for the properties.
		/// </summary>
		private static ConfigurationPropertyCollection properties;

		/// <summary>
		/// Field for the path.
		/// </summary>
		private static ConfigurationProperty path;

		/// <summary>
		/// Field for the targets.
		/// </summary>
		private static ConfigurationProperty targets;

		/// <summary>
		/// Initializes the <see cref="ScriptElement"/> class.
		/// </summary>
		static ScriptElement()
		{
			path = new ConfigurationProperty("path", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
			targets = new ConfigurationProperty("targets", typeof(string), null, ConfigurationPropertyOptions.None);

			properties = new ConfigurationPropertyCollection();
			properties.Add(path);
			properties.Add(targets);
		}

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>The path.</value>
		[ConfigurationProperty("path", IsKey = true, IsRequired = true)]
		public string Path
		{
			get
			{
				return (string)base[path];
			}
			set
			{
				base[path] = value;
			}
		}

		/// <summary>
		/// Gets or sets the targets.
		/// </summary>
		/// <value>The targets.</value>
		[ConfigurationProperty("targets", DefaultValue = "umbraco.aspx")]
		public string Targets
		{
			get
			{
				return (string)base[targets];
			}
			set
			{
				base[targets] = value;
			}
		}

		/// <summary>
		/// Gets the collection of properties.
		/// </summary>
		/// <value></value>
		/// <returns>The <see cref="T:System.Configuration.ConfigurationPropertyCollection"/> of properties for the element.</returns>
		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return properties;
			}
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			var path = VirtualPathUtility.ToAbsolute(this.Path);
			return string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", path);
		}
	}
}
