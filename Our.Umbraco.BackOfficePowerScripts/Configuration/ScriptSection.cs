using System;
using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration
{
	public class ScriptSection : ConfigurationSection
	{
		private static readonly ConfigurationProperty scripts = new ConfigurationProperty(null, typeof(ScriptCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

		private static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();

		static ScriptSection()
		{
			properties.Add(scripts);
		}

		[ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public ScriptCollection Scripts
		{
			get
			{
				return (ScriptCollection)base[scripts];
			}
		}
	}
}