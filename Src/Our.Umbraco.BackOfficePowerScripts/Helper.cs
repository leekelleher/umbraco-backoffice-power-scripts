using System;
using System.Web.UI;
using Our.Umbraco.BackOfficePowerScripts.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Our.Umbraco.BackOfficePowerScripts
{
	/// <summary>
	/// Class for helper methods.
	/// </summary>
	public class Helper
	{
		/// <summary>
		/// Finds the control by ID.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="controlId">The control id.</param>
		/// <returns>Returns the control for the specified id.</returns>
		public static Control FindControlById(Control source, string controlId)
		{
			if (string.IsNullOrWhiteSpace(controlId))
			{
				return null;
			}

			if (string.Equals(source.ID, controlId, StringComparison.OrdinalIgnoreCase))
			{
				return source;
			}

			foreach (Control child in source.Controls)
			{
				var control = Helper.FindControlById(child, controlId);
				if (control != null)
				{
					return control;
				}
			}

			return null;
		}

		/// <summary>
		/// Gets the registered targets.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="path">The path.</param>
		/// <param name="clientTargets">The client targets.</param>
		/// <returns>Returns a list of registered targets.</returns>
		internal static List<T> GetRegisteredTargets<T>(string path, List<T> clientTargets) where T : IClientTarget
		{
			var registeredTargets = new List<T>();

			if (clientTargets.Count > 0)
			{
				// loop through client target
				foreach (var clientTarget in clientTargets)
				{
					// check that the targets is not empty
					if (string.IsNullOrWhiteSpace(clientTarget.Targets))
						continue;

					// split the targets
					var targets = clientTarget.Targets.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

					// loop through each target (regex pattern)
					foreach (var pattern in targets)
					{
						// check that the target (regex pattern) is not empty
						if (string.IsNullOrWhiteSpace(pattern))
							continue;

						// apply the regex pattern to the current path
						var match = Regex.Match(path, pattern, RegexOptions.IgnoreCase);

						// check if regex match was a success, add the client target to the list!
						if (match.Success)
							registeredTargets.Add(clientTarget);
					}
				}
			}

			return registeredTargets;
		}
	}
}