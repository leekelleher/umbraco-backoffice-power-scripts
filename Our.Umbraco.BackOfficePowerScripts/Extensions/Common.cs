using System;

using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;

namespace Our.Umbraco.BackOfficePowerScripts.Extensions
{
	public class Common
	{
		public static string ConfigName
		{
			get
			{
				return "BackOfficePowerScripts";
			}
		}

		public static ScriptsCollection RegisteredScripts { get; set; }
	}
}
