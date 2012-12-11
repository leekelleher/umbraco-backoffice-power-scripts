using System.Web.UI;
using Our.Umbraco.BackOfficePowerScripts.Interfaces;

namespace Our.Umbraco.BackOfficePowerScripts
{
	/// <summary>
	/// The ClientControl.
	/// </summary>
	public abstract class ClientControl : IClientControl
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientControl"/> class.
		/// </summary>
		/// <param name="targets">The targets.</param>
		public ClientControl(string targets)
		{
			this.Targets = targets;
		}

		/// <summary>
		/// Gets or sets the targets.
		/// </summary>
		/// <value>The targets.</value>
		public virtual string Targets { get; set; }

		/// <summary>
		/// Intercepts the page.
		/// </summary>
		/// <param name="page">The page.</param>
		public abstract void InterceptPage(Page page);
	}
}