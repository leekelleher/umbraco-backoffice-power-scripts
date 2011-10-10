using System.Web.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Configuration;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;
using Our.Umbraco.BackOfficePowerScripts.Extensions;
using umbraco.BusinessLogic;

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
			this.LoadRegisteredScripts();
		}

		/// <summary>
		/// Loads the registered scripts.
		/// </summary>
		private void LoadRegisteredScripts()
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
		}
	}
}
