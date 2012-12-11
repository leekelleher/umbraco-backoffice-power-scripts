using System;
using System.Web.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Attributes;
using Our.Umbraco.BackOfficePowerScripts.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;
using Our.Umbraco.BackOfficePowerScripts.Extensions;
using umbraco.BusinessLogic;
using umbraco.BusinessLogic.Utils;

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
			var application = Application.Instance;

			foreach (var type in TypeFinder.FindClassesOfType<ClientControl>())
			{
				try
				{
					var clientControl = Activator.CreateInstance(type) as ClientControl;
					if (clientControl != null)
					{
						application.AddClientControl(clientControl);
					}
				}
				catch (Exception ex)
				{
					Log.Add(LogTypes.Error, -1, string.Concat("Error loading Our.Umbraco.BackOfficePowerScripts.ClientControl: ", ex));
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
			var application = Application.Instance;

			foreach (ScriptElement script in section.Scripts)
			{
				application.AddJavaScript(script.Path, script.Targets, 100);
			}

			foreach (StyleElement style in section.Styles)
			{
				application.AddCss(style.Path, style.Targets, 100);
			}

			foreach (var type in TypeFinder.FindClassesMarkedWithAttribute(typeof(ClientResourceAttribute)))
			{
				foreach (ClientResourceAttribute attribute in type.GetCustomAttributes(typeof(ClientResourceAttribute), false))
				{
					application.AddClientResource(attribute.ClientResource);
				}
			}
		}
	}
}