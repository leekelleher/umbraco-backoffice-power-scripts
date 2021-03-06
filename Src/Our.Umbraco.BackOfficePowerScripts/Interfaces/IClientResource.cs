﻿using ClientDependency.Core;

namespace Our.Umbraco.BackOfficePowerScripts.Interfaces
{
	/// <summary>
	/// Interface for a ClientResource item.
	/// </summary>
	public interface IClientResource : IClientTarget
	{
		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>The path.</value>
		string Path { get; set; }

		/// <summary>
		/// Gets or sets the priority.
		/// </summary>
		/// <value>The priority.</value>
		int Priority { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="ClientDependency.Core.ClientDependencyType"/> type.
		/// </summary>
		/// <value>The type.</value>
		ClientDependencyType Type { get; set; }
	}
}