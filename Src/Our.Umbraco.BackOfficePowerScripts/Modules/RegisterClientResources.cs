using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using umbraco.BusinessLogic;
using umbraco.IO;
using umbraco.uicontrols;

namespace Our.Umbraco.BackOfficePowerScripts.Modules
{
	/// <summary>
	/// HttpModule for registering the resources (on their targets)
	/// </summary>
	public sealed class RegisterClientResources : IHttpModule
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
			context.PreRequestHandlerExecute += new EventHandler(this.RegisterTargetClientResources);
		}

		/// <summary>
		/// Handles the PreRequestHandlerExecute event of the context control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void RegisterTargetClientResources(object sender, EventArgs e)
		{
			var context = sender as HttpApplication;

			if (string.Equals(context.Response.ContentType, MediaTypeNames.Text.Html, StringComparison.OrdinalIgnoreCase) && context.Context.Handler is Page)
			{
				var page = context.Context.Handler as Page;
				var currentExecutionFilePath = context.Request.CurrentExecutionFilePath;
				var registeredClientResources = this.GetRegisteredClientResources(currentExecutionFilePath);

				if (page != null && registeredClientResources != null && registeredClientResources.Count > 0)
				{
					page.Load += (s2, e2) =>
					{
						try
						{
							bool created;
							var loader = UmbracoClientDependencyLoader.TryCreate(page, out created);
							if (loader != null)
							{
								foreach (var clientResource in registeredClientResources)
								{
									loader.RegisterDependency(clientResource.Priority, IOHelper.ResolveUrl(clientResource.Path), clientResource.Type);
								}
							}
						}
						catch (Exception ex)
						{
							Log.Add(LogTypes.Error, -1, string.Concat("Error loading Our.Umbraco.BackOfficePowerScripts.Modules.RegisterClientResources: ", ex));
						}
					};
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
			if (Application.Instance.ClientResources.Count > 0)
			{
				return Helper.GetRegisteredTargets<ClientResource>(path, Application.Instance.ClientResources);
			}

			return null;
		}
	}
}