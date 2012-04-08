using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace Our.Umbraco.BackOfficePowerScripts.Modules
{
	/// <summary>
	/// HttpModule for registering the control injections.
	/// </summary>
	public class RegisterControls : IHttpModule
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
			context.PreRequestHandlerExecute += new EventHandler(this.context_PreRequestHandlerExecute);
		}

		/// <summary>
		/// Handles the PreRequestHandlerExecute event of the context control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void context_PreRequestHandlerExecute(object sender, EventArgs e)
		{
			var context = sender as HttpApplication;

			if (string.Equals(context.Response.ContentType, MediaTypeNames.Text.Html, StringComparison.OrdinalIgnoreCase))
			{
				var currentExecutionFilePath = context.Request.CurrentExecutionFilePath;
				var registeredControls = this.GetRegisteredControls(currentExecutionFilePath);

				if (registeredControls.Count > 0)
				{
					foreach (var registeredControl in registeredControls)
					{
						var page = context.Context.Handler as Page;
						if (page != null)
						{
							registeredControl.InterceptPage(page);
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets the registered controls.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>Returns a list of registered client controls for the specified path.</returns>
		private List<ClientControl> GetRegisteredControls(string path)
		{
			return Helper.GetRegisteredTargets<ClientControl>(path, Application.Instance.ClientControls);
		}
	}
}