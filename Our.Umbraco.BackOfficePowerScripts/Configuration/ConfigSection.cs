using System.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration
{
	public class ConfigSection : ConfigurationSection
	{
		private static readonly ConfigurationProperty scripts = new ConfigurationProperty("scripts", typeof(ScriptCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
		private static readonly ConfigurationProperty styles = new ConfigurationProperty("styles", typeof(StyleCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

		private static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();

		static ConfigSection()
		{
			properties.Add(scripts);
			properties.Add(styles);
		}

		[ConfigurationProperty("scripts", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public ScriptCollection Scripts
		{
			get
			{
				return (ScriptCollection)base[scripts];
			}
		}

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