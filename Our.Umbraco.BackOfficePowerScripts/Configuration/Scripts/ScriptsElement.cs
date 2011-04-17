using System;
using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts
{
	public class ScriptsElement : ConfigurationElement
	{
		private static ConfigurationPropertyCollection properties;
		private static ConfigurationProperty path;
		private static ConfigurationProperty priority;

		static ScriptsElement()
		{
			path = new ConfigurationProperty("path", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
			priority = new ConfigurationProperty("priority", typeof(int), 100, ConfigurationPropertyOptions.None);

			properties = new ConfigurationPropertyCollection();
			properties.Add(path);
			properties.Add(priority);
		}

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

		[ConfigurationProperty("priority", DefaultValue = 100)]
		public int Priority
		{
			get
			{
				return (int)base[priority];
			}
			set
			{
				base[priority] = value;
			}
		}

		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return properties;
			}
		}
	}
}
