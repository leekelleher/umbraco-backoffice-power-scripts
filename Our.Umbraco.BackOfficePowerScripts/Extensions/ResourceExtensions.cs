using System;
using System.Web.UI;

using ClientDependency.Core;
using ClientDependency.Core.Controls;
using umbraco;

namespace Our.Umbraco.BackOfficePowerScripts.Extensions
{
	/// <summary>
	/// Extension methods for embedded resources
	/// </summary>
	public static class ResourceExtensions
	{
		/// <summary>
		/// Adds an embedded resource to the ClientDependency output by name
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="filePath">The file path.</param>
		/// <param name="type">The type.</param>
		public static void AddResourceToClientDependency(this Control control, string filePath, ClientDependencyType type)
		{
			control.Page.AddResourceToClientDependency(filePath, type, 100);
		}

		/// <summary>
		/// Adds an embedded resource to the ClientDependency output by name
		/// </summary>
		/// <param name="page">The Page to add the resource to</param>
		/// <param name="filePath">The file path.</param>
		/// <param name="type">The type.</param>
		/// <param name="priority">The priority.</param>
		public static void AddResourceToClientDependency(this Page page, string filePath, ClientDependencyType type, int priority)
		{
			ClientDependencyLoader.Instance.RegisterDependency(priority, filePath, type);
		}
	}
}
