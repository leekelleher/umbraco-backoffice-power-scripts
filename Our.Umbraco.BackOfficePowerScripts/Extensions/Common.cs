using System;

using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;

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
		
		public static StylesCollection RegisteredStyles { get; set; }
	}
}
