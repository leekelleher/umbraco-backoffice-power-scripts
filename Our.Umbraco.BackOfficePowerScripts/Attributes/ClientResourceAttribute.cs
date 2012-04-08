using System;
using Our.Umbraco.BackOfficePowerScripts.Interfaces;

namespace Our.Umbraco.BackOfficePowerScripts.Attributes
{
	/// <summary>
	/// Custom attribute for registering a client resource.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class ClientResourceAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientResourceAttribute"/> class.
		/// </summary>
		/// <param name="clientResource">The client resource.</param>
		public ClientResourceAttribute(IClientResource clientResource)
		{
			this.ClientResource = new ClientResource(clientResource);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientResourceAttribute"/> class.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="priority">The priority.</param>
		/// <param name="targets">The targets.</param>
		/// <param name="type">The type.</param>
		public ClientResourceAttribute(string path, int priority, string targets, ClientResourceType type)
		{
			this.ClientResource = new ClientResource(path, priority, targets, type);
		}

		/// <summary>
		/// Gets or sets the client resource.
		/// </summary>
		/// <value>The client resource.</value>
		public ClientResource ClientResource { get; set; }

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>The path.</value>
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets the type of the client resource.
		/// </summary>
		/// <value>The type of the client resource.</value>
		public ClientResourceType Type { get; set; }

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
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			if (this.ClientResource != null)
			{
				return this.ClientResource.ToString();
			}

			return base.ToString();
		}
	}
}
