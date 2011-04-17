using System;
using System.Configuration;

using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration
{
	public class ConfigSection : ConfigurationSection
	{
		private static readonly ConfigurationProperty scripts = new ConfigurationProperty("scripts", typeof(ScriptsCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
		private static readonly ConfigurationProperty styles = new ConfigurationProperty("styles", typeof(StylesCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

		private static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();

		static ConfigSection()
		{
			properties.Add(scripts);
			properties.Add(styles);
		}

		[ConfigurationProperty("scripts", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public ScriptsCollection Scripts
		{
			get
			{
				return (ScriptsCollection)base[scripts];
			}
		}

		[ConfigurationProperty("styles", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public StylesCollection Styles
		{
			get
			{
				return (StylesCollection)base[styles];
			}
		}
	}
}