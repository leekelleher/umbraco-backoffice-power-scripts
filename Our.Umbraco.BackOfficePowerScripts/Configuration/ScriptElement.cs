using System;
using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration
{
	public class ScriptElement : ConfigurationElement
	{
		private static ConfigurationPropertyCollection properties;
		private static ConfigurationProperty name;
		private static ConfigurationProperty path;
		private static ConfigurationProperty priority;
		private static ConfigurationProperty type;

		static ScriptElement()
		{
			name = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsKey);
			path = new ConfigurationProperty("path", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
			priority = new ConfigurationProperty("priority", typeof(int), 100, ConfigurationPropertyOptions.None);
			type = new ConfigurationProperty("type", typeof(string), null, ConfigurationPropertyOptions.None);

			properties = new ConfigurationPropertyCollection();
			properties.Add(name);
			properties.Add(path);
			properties.Add(priority);
			properties.Add(type);
		}

		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name
		{
			get
			{
				return (string)base[name];
			}
			set
			{
				base[name] = value;
			}
		}

		[ConfigurationProperty("path", IsRequired = true)]
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

		[ConfigurationProperty("type")]
		public string Type
		{
			get
			{
				return (string)base[type];
			}
			set
			{
				base[type] = value;
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
