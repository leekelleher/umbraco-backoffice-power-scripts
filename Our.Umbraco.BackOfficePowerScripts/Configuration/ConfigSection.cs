using System.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration
{
	/// <summary>
	/// The configuration section.
	/// </summary>
	public class ConfigSection : ConfigurationSection
	{
		/// <summary>
		/// Field for the ScriptCollection.
		/// </summary>
		private static readonly ConfigurationProperty scripts = new ConfigurationProperty("scripts", typeof(ScriptCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

		/// <summary>
		/// Field for the StyleCollection.
		/// </summary>
		private static readonly ConfigurationProperty styles = new ConfigurationProperty("styles", typeof(StyleCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

		/// <summary>
		/// Field for the properties.
		/// </summary>
		private static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();

		/// <summary>
		/// Initializes the <see cref="ConfigSection"/> class.
		/// </summary>
		static ConfigSection()
		{
			properties.Add(scripts);
			properties.Add(styles);
		}

		/// <summary>
		/// Gets the scripts.
		/// </summary>
		/// <value>The scripts.</value>
		[ConfigurationProperty("scripts", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public ScriptCollection Scripts
		{
			get
			{
				return (ScriptCollection)base[scripts];
			}
		}

		/// <summary>
		/// Gets the styles.
		/// </summary>
		/// <value>The styles.</value>
		[ConfigurationProperty("styles", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public StyleCollection Styles
		{
			get
			{
				return (StyleCollection)base[styles];
			}
		}
	}
}