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
		/// Gets or sets the current execution file path.
		/// </summary>
		/// <value>The current execution file path.</value>
		public string CurrentExecutionFilePath { get; set; }

		/// <summary>
		/// Gets or sets the umbraco/default.aspx.
		/// </summary>
		/// <value>The umbraco default aspx.</value>
		public string UmbracoDefaultAspx { get; set; }

		/// <summary>
		/// Gets or sets the umbraco/umbraco.aspx.
		/// </summary>
		/// <value>The umbraco/umbraco.aspx.</value>
		public string UmbracoUmbracoAspx { get; set; }

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
			string umbracoPath = SystemDirectories.Umbraco.TrimStart('~');
			this.UmbracoDefaultAspx = string.Concat(umbracoPath, "/default.aspx");
			this.UmbracoUmbracoAspx = string.Concat(umbracoPath, "/umbraco.aspx");

			context.PostMapRequestHandler += new EventHandler(context_PostMapRequestHandler);
			context.PostReleaseRequestState += new EventHandler(context_PostReleaseRequestState);
		}

		/// <summary>
		/// Handles the PostMapRequestHandler event of the context control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void context_PostMapRequestHandler(object sender, EventArgs e)
		{
			var context = sender as HttpApplication;
			this.CurrentExecutionFilePath = context.Request.CurrentExecutionFilePath;
			
			if (string.Equals(this.CurrentExecutionFilePath, this.UmbracoDefaultAspx, StringComparison.InvariantCultureIgnoreCase))
			{
				context.Response.Redirect(this.UmbracoUmbracoAspx, true);
				return;
			}
		}

		/// <summary>
		/// Handles the PostReleaseRequestState event of the context control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void context_PostReleaseRequestState(object sender, EventArgs e)
		{
			if (string.Equals(this.CurrentExecutionFilePath, this.UmbracoUmbracoAspx, StringComparison.InvariantCultureIgnoreCase))
			{
				var context = sender as HttpApplication;
				context.Response.Filter = new AppendScripts(context.Response.Filter);
			}
		}
	}
}