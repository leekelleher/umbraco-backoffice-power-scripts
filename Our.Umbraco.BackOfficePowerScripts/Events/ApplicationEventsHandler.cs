﻿using System;
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
			this.LoadRegisteredScripts();
		}

		private static bool modulesRegistered;

		public static void RegisterModules()
		{
			if (modulesRegistered)
			{
				return;
			}

			modulesRegistered = true;

			DynamicModuleUtility.RegisterModule(typeof(RegisterFilters));
		}

		private void LoadRegisteredScripts()
		{
			var config = WebConfigurationManager.OpenWebConfiguration("~/");
			var section = config.GetSection(Common.ConfigName) as ConfigSection;
			Common.RegisteredScripts = section.Scripts;
			Common.RegisteredStyles = section.Styles;

			// TODO: Load up the targets
			// ScriptTargets
			// StyleTargets
		}
	}
}
