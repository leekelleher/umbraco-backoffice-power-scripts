using System;
using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts
{
	public class ScriptsSection : ConfigurationSection
	{
		private static readonly ConfigurationProperty scripts = new ConfigurationProperty("scripts", typeof(ScriptsCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

		private static ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();

		static ScriptsSection()
		{
			properties.Add(scripts);
		}

		[ConfigurationProperty("scripts", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public ScriptsCollection Scripts
		{
			get
			{
				return (ScriptsCollection)base[scripts];
			}
		}
	}
}