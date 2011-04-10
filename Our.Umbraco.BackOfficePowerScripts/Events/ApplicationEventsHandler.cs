using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Our.Umbraco.BackOfficePowerScripts.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Extensions;
using Our.Umbraco.BackOfficePowerScripts.Modules;
using umbraco.BusinessLogic;

[assembly: PreApplicationStartMethod(typeof(Our.Umbraco.BackOfficePowerScripts.Events.ApplicationEventsHandler), "RegisterModules")]

namespace Our.Umbraco.BackOfficePowerScripts.Events
{
	public class ApplicationEventsHandler : ApplicationBase
	{
		public ApplicationEventsHandler()
		{
			this.CheckWebConfigSectionExists();
		}

		private static bool modulesRegistered;

		public static void RegisterModules()
		{
			if (modulesRegistered)
			{
				return;
			}

			modulesRegistered = true;

			DynamicModuleUtility.RegisterModule(typeof(RegisterClientResources));
		}

		public void CheckWebConfigSectionExists()
		{
			try
			{
				var webConfig = WebConfigurationManager.OpenWebConfiguration("~/");
				if (webConfig.Sections[Common.ConfigName] == null)
				{
					webConfig.Sections.Add(Common.ConfigName, new ScriptSection());

					string configPath = string.Concat("config", Path.DirectorySeparatorChar, Common.ConfigName, ".config");
					string xml;

					using (var resource = this.GetType().Assembly.GetManifestResourceStream(Common.ResourceName))
					using (var reader = new StreamReader(resource))
					{
						xml = reader.ReadToEnd();
					}

					webConfig.Sections[Common.ConfigName].SectionInformation.SetRawXml(xml);
					webConfig.Sections[Common.ConfigName].SectionInformation.ConfigSource = configPath;

					webConfig.Save(ConfigurationSaveMode.Modified);

					// copy the example script
					this.CopyExampleScripts();
				}
			}
			catch (Exception ex)
			{
				Log.Add(LogTypes.Error, -1, ex.ToString());
			}
		}

		private void CopyExampleScripts()
		{
			var scripts = new string[] { "btn-our-umbraco.js", "sections-href-fix.js" };
			foreach (var script in scripts)
			{
				var resourceName = string.Concat("Our.Umbraco.BackOfficePowerScripts.Resources.Scripts.", script);
				Common.CopyResourceToFile(this.GetType(), resourceName, Common.GetScriptPath(script));
			}
		}
	}
}
