using System.Web.Configuration;
using ClientResourceInjector.Attributes;
using Our.Umbraco.BackOfficePowerScripts.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;
using Our.Umbraco.BackOfficePowerScripts.Extensions;
using umbraco.BusinessLogic;
using umbraco.BusinessLogic.Utils;
using System;

namespace Our.Umbraco.BackOfficePowerScripts.Events
{
	/// <summary>
	/// Application for BackOfficePowerScripts.
	/// </summary>
	public class ApplicationEventsHandler : ApplicationBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationEventsHandler"/> class.
		/// </summary>
		public ApplicationEventsHandler()
		{
			this.LoadRegisteredControls();
			this.LoadRegisteredResources();
		}

		/// <summary>
		/// Loads the registered controls.
		/// </summary>
		private void LoadRegisteredControls()
		{
			var injector = ClientResourceInjector.Application.Instance;

			foreach (var type in TypeFinder.FindClassesOfType<ClientResourceInjector.ClientControl>())
			{
				try
				{
					var clientControl = Activator.CreateInstance(type) as ClientResourceInjector.ClientControl;
					if (clientControl != null)
					{
						injector.AddClientControl(clientControl);
					}
				}
				catch (Exception ex)
				{
					Log.Add(LogTypes.Error, -1, string.Concat("Error loading ClientResourceInjector.ClientControl: ", ex));
					continue;
				}
			}
		}

		/// <summary>
		/// Loads the registered resources.
		/// </summary>
		private void LoadRegisteredResources()
		{
			var config = WebConfigurationManager.OpenWebConfiguration("~/");
			var section = config.GetSection(Common.ConfigName) as ConfigSection;
			var injector = ClientResourceInjector.Application.Instance;

			foreach (ScriptElement script in section.Scripts)
			{
				injector.AddJavaScript(script.Path, 100, script.Targets);
			}

			foreach (StyleElement style in section.Styles)
			{
				injector.AddCss(style.Path, 100, style.Targets);
			}

			foreach (var type in TypeFinder.FindClassesMarkedWithAttribute(typeof(ClientResourceAttribute)))
			{
				foreach (ClientResourceAttribute attribute in type.GetCustomAttributes(typeof(ClientResourceAttribute), false))
				{
					injector.AddClientResource(attribute.ClientResource);
				}
			}
		}
	}
}