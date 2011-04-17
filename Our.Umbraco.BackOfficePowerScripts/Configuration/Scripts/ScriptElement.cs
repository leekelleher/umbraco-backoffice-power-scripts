using System;
using System.Configuration;
using System.Web;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts
{
	public class ScriptElement : ConfigurationElement
	{
		private static ConfigurationPropertyCollection properties;
		private static ConfigurationProperty path;

		static ScriptElement()
		{
			path = new ConfigurationProperty("path", typeof(string), null, ConfigurationPropertyOptions.IsRequired);

			properties = new ConfigurationPropertyCollection();
			properties.Add(path);
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
			return string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", path);
		}
	}
}
