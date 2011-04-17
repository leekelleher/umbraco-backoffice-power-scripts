using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.UI;

using ClientDependency.Core;
using ClientDependency.Core.Controls;
using Our.Umbraco.BackOfficePowerScripts.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Extensions;
using Our.Umbraco.BackOfficePowerScripts.Filters;
using umbraco;
using umbraco.IO;
using umbraco.presentation;

namespace Our.Umbraco.BackOfficePowerScripts.Modules
{
	public class RegisterFilters : IHttpModule
	{
		/// <summary>
		/// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
		/// </summary>
		public void Dispose()
		{
		}

		/// <summary>
		/// Initializes a module and prepares it to handle requests.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
		public void Init(HttpApplication context)
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
				context.PostReleaseRequestState += new EventHandler(context_PostReleaseRequestState);
			}
		}

		protected void context_PostReleaseRequestState(object sender, EventArgs e)
		{
			HttpContext.Current.Response.Filter = new AppendScripts(HttpContext.Current.Response.Filter);
		}
	}
}