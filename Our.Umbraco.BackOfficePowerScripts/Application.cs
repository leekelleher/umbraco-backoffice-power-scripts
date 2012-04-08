using System.Collections.Generic;
using Our.Umbraco.BackOfficePowerScripts.Modules;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace Our.Umbraco.BackOfficePowerScripts
{
	/// <summary>
	/// The ClientInjection application.
	/// </summary>
	public sealed class Application
	{
		/// <summary>
		/// Field for the instance of the ClientInjection application.
		/// </summary>
		private static readonly Application instance = new Application();

		/// <summary>
		/// Field to flag that the HttpModules have been registered.
		/// </summary>
		private static bool modulesRegistered;

		/// <summary>
		/// Prevents a default instance of the <see cref="Application"/> class from being created.
		/// </summary>
		private Application()
		{
			this.ClientControls = new List<ClientControl>();
			this.ClientResources = new List<ClientResource>();
		}

		/// <summary>
		/// Gets the instance of the ClientInjection application.
		/// </summary>
		/// <value>The instance.</value>
		public static Application Instance
		{
			get
			{
				return instance;
			}
		}

		/// <summary>
		/// Gets or sets the client controls.
		/// </summary>
		/// <value>The client controls.</value>
		public List<ClientControl> ClientControls { get; set; }

		/// <summary>
		/// Gets or sets the client resources.
		/// </summary>
		/// <value>The client resources.</value>
		public List<ClientResource> ClientResources { get; set; }

		/// <summary>
		/// Registers the HttpModules.
		/// </summary>
		public static void RegisterModules()
		{
			if (modulesRegistered)
			{
				return;
			}

			DynamicModuleUtility.RegisterModule(typeof(RegisterControls));
			DynamicModuleUtility.RegisterModule(typeof(RegisterFilters));

			modulesRegistered = true;
		}

		/// <summary>
		/// Adds the client control to the target.
		/// </summary>
		/// <param name="clientControl">The client control.</param>
		public void AddClientControl(ClientControl clientControl)
		{
			this.ClientControls.Add(clientControl);
		}

		/// <summary>
		/// Adds the client resource to the target.
		/// </summary>
		/// <param name="clientResource">The client resource.</param>
		public void AddClientResource(ClientResource clientResource)
		{
			this.ClientResources.Add(clientResource);
		}

		/// <summary>
		/// Adds the client resource to the target.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="type">The type.</param>
		/// <param name="priority">The priority.</param>
		/// <param name="targets">The targets.</param>
		public void AddClientResource(string path, ClientResourceType type, int priority = 100, string targets = "")
		{
			this.ClientResources.Add(new ClientResource(path, priority, targets, type));
		}

		/// <summary>
		/// Adds the CSS to the target.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="priority">The priority.</param>
		/// <param name="targets">The targets.</param>
		public void AddCss(string path, int priority = 100, string targets = "")
		{
			this.AddClientResource(path, ClientResourceType.Css, priority, targets);
		}

		/// <summary>
		/// Adds the JavaScript to the target.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="priority">The priority.</param>
		/// <param name="targets">The targets.</param>
		public void AddJavaScript(string path, int priority = 100, string targets = "")
		{
			this.AddClientResource(path, ClientResourceType.JavaScript, priority, targets);
		}
	}
}