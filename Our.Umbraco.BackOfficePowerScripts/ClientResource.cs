using System.Web;
using ClientDependency.Core;
using Our.Umbraco.BackOfficePowerScripts.Interfaces;

namespace Our.Umbraco.BackOfficePowerScripts
{
	/// <summary>
	/// The ClientResource.
	/// </summary>
	public class ClientResource : IClientResource
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientResource"/> class.
		/// </summary>
		public ClientResource()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientResource"/> class.
		/// </summary>
		/// <param name="clientResource">The client resource.</param>
		public ClientResource(IClientResource clientResource)
		{
			this.Path = clientResource.Path;
			this.Priority = clientResource.Priority;
			this.Targets = clientResource.Targets;
			this.Type = clientResource.Type;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientResource"/> class.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="priority">The priority.</param>
		/// <param name="targets">The targets.</param>
		/// <param name="type">The type.</param>
		public ClientResource(string path, int priority, string targets, ClientDependencyType type)
		{
			this.Path = path;
			this.Priority = priority;
			this.Targets = targets;
			this.Type = type;
		}

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>The path.</value>
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets the priority.
		/// </summary>
		/// <value>The priority.</value>
		public int Priority { get; set; }

		/// <summary>
		/// Gets or sets the targets.
		/// </summary>
		/// <value>The targets.</value>
		public string Targets { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="ClientDependency.Core.ClientDependencyType"/> type.
		/// </summary>
		/// <value>The type.</value>
		public ClientDependencyType Type { get; set; }

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			var path = VirtualPathUtility.ToAbsolute(this.Path);

			switch (this.Type)
			{
				case ClientDependencyType.Css:
					return string.Format("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\"/>", path);

				case ClientDependencyType.Javascript:
					return string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", path);

				default:
					return base.ToString();
			}
		}
	}
}