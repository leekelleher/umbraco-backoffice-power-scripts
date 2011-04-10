using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.UI;

using ClientDependency.Core;
using Our.Umbraco.BackOfficePowerScripts.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Extensions;
using umbraco;
using umbraco.IO;
using umbraco.presentation;

namespace Our.Umbraco.BackOfficePowerScripts.Modules
{
	public class RegisterClientResources : IHttpModule
	{
		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.PostMapRequestHandler += (sender, e) =>
			{
				string currentExecutionFilePath = context.Request.CurrentExecutionFilePath;
				string umbracoPath = SystemDirectories.Umbraco.TrimStart('~');
				string umbracoDefault = string.Concat(umbracoPath, "/default.aspx");
				string umbracoUmbraco = string.Concat(umbracoPath, "/umbraco.aspx");

				if (string.Equals(currentExecutionFilePath, umbracoDefault, StringComparison.InvariantCultureIgnoreCase))
				{
					context.Response.Redirect(umbracoUmbraco);
					return;
				}

				if (string.Equals(currentExecutionFilePath, umbracoUmbraco, StringComparison.InvariantCultureIgnoreCase))
				{
					var page = HttpContext.Current.CurrentHandler as Page;
					if (page != null && !UmbracoContext.Current.InPreviewMode)
					{
						page.Load += (s2, e2) =>
						{
							var config = WebConfigurationManager.OpenWebConfiguration("~/");
							var scripts = (config.GetSection(Common.ConfigName) as ScriptSection).Scripts;

							if (scripts != null && scripts.Count > 0)
							{
								for (int i = 0; i < scripts.Count; i++)
								{
									var script = scripts[i];
									var type = string.Equals(script.Type, "CSS", StringComparison.InvariantCultureIgnoreCase) ? ClientDependencyType.Css : ClientDependencyType.Javascript;

									// add the script to client dependency
									page.AddResourceToClientDependency(script.Path, type, script.Priority);
								}
							}
						};
					}
				}
			};
		}
	}
}
