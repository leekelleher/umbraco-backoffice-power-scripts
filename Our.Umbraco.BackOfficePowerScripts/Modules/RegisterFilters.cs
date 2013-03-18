using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using Our.Umbraco.BackOfficePowerScripts.Filters;
using Our.Umbraco.BackOfficePowerScripts.Interfaces;

namespace Our.Umbraco.BackOfficePowerScripts.Modules
{
	/// <summary>
	/// HttpModule for registering the Response.Filters.
	/// </summary>
	public sealed class RegisterFilters : IHttpModule
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
			context.PostReleaseRequestState += new EventHandler(this.context_PostReleaseRequestState);
		}

		/// <summary>
		/// Handles the PostReleaseRequestState event of the context control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void context_PostReleaseRequestState(object sender, EventArgs e)
		{
			var context = sender as HttpApplication;

			if (string.Equals(context.Response.ContentType, MediaTypeNames.Text.Html, StringComparison.OrdinalIgnoreCase))
			{
                var currentExecutionFilePath = context.Request.RawUrl;
				var registeredClientResources = this.GetRegisteredClientResources(currentExecutionFilePath);

				if (registeredClientResources.Count > 0)
				{
					context.Response.Filter = new InjectResources(context.Response.Filter, registeredClientResources);
				}
			}
		}

		/// <summary>
		/// Gets the registered ClientResource items.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>Returns a list of registered ClientResource items.</returns>
		private List<ClientResource> GetRegisteredClientResources(string path)
		{
			return Helper.GetRegisteredTargets<ClientResource>(path, Application.Instance.ClientResources);
		}
	}
}