using System;
using System.Configuration;
using System.Web;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Styles
{
	public class StyleElement : ConfigurationElement
	{
		private static ConfigurationPropertyCollection properties;
		private static ConfigurationProperty path;
		private static ConfigurationProperty targets;

		static StyleElement()
		{
			path = new ConfigurationProperty("path", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
			targets = new ConfigurationProperty("targets", typeof(string), null, ConfigurationPropertyOptions.None);

			properties = new ConfigurationPropertyCollection();
			properties.Add(path);
			properties.Add(targets);
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

		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return properties;
			}
		}

		public override string ToString()
		{
			var path = VirtualPathUtility.ToAbsolute(this.Path);
			return string.Format("<link rel='stylesheet' type='text/css' href='{0}' />", path);
		}
	}
}
